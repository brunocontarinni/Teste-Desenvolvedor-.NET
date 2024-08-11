using Inscricoes.Application.DTOs.User;
using Inscricoes.Application.Interfaces;
using Inscricoes.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Inscricoes.Api.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
	private readonly ITokenService _tokenService;
	private readonly UserManager<ApplicationUser> _userManager;
	private readonly RoleManager<IdentityRole> _roleManager;
	private readonly IConfiguration _configuration;
	private readonly ILogger<AuthController> _logger;

	public AuthController(ITokenService tokenService,
						UserManager<ApplicationUser> userManager,
						RoleManager<IdentityRole> roleManager,
						IConfiguration configuration,
						ILogger<AuthController> logger)
	{
		_tokenService = tokenService;
		_userManager = userManager;
		_roleManager = roleManager;
		_configuration = configuration;
		_logger = logger;
	}

	[HttpPost]
	[Authorize(Roles = "Admin")]
	[Route("CreateRole")]
	[SwaggerOperation(Summary = "Criar uma nova role", Description = "Cria uma nova role no sistema.")]
	[SwaggerResponse(StatusCodes.Status200OK, "Role criada com sucesso", typeof(ResponseDTO))]
	[SwaggerResponse(StatusCodes.Status400BadRequest, "Erro ao criar a role", typeof(ResponseDTO))]
	public async Task<IActionResult> CreateRole(string roleName)
	{
		var roleExist = await _roleManager.RoleExistsAsync(roleName);

		if (!roleExist)
		{
			var roleResult = await _roleManager.CreateAsync(new IdentityRole(roleName));

			if (roleResult.Succeeded)
			{
				_logger.LogInformation(1, "Role adicionada com sucesso");
				return StatusCode(StatusCodes.Status200OK,
						new ResponseDTO
						{
							Status = "Success",
							Message = $"Role {roleName} adicionada com sucesso"
						});
			}
			else
			{
				_logger.LogInformation(2, "Erro ao adicionar a role");
				return StatusCode(StatusCodes.Status400BadRequest,
				   new ResponseDTO
				   {
					   Status = "Error",
					   Message = $"Erro ao adicionar a nova role {roleName}"
				   });
			}
		}
		return StatusCode(StatusCodes.Status400BadRequest,
		  new ResponseDTO { Status = "Error", Message = "A role já existe." });
	}

	[HttpPost]
	[Authorize(Roles = "Admin")]
	[Route("AddUserToRole")]
	[SwaggerOperation(Summary = "Adicionar usuário a uma role", Description = "Adiciona um usuário existente a uma role específica.")]
	[SwaggerResponse(StatusCodes.Status200OK, "Usuário adicionado à role com sucesso", typeof(ResponseDTO))]
	[SwaggerResponse(StatusCodes.Status400BadRequest, "Erro ao adicionar o usuário à role", typeof(ResponseDTO))]
	public async Task<IActionResult> AddUserToRole(string email, string roleName)
	{
		var user = await _userManager.FindByEmailAsync(email);

		if (user != null)
		{
			var result = await _userManager.AddToRoleAsync(user, roleName);
			if (result.Succeeded)
			{
				_logger.LogInformation(1, $"Usuário {user.Email} adicionado à role {roleName} com sucesso");
				return StatusCode(StatusCodes.Status200OK,
					   new ResponseDTO
					   {
						   Status = "Success",
						   Message = $"Usuário {user.Email} adicionado à role {roleName} com sucesso"
					   });
			}
			else
			{
				_logger.LogInformation(1, $"Erro ao adicionar usuário {user.Email} à role {roleName}");
				return StatusCode(StatusCodes.Status400BadRequest, new ResponseDTO
				{
					Status = "Error",
					Message = $"Erro ao adicionar usuário {user.Email} à role {roleName}"
				});
			}
		}
		return BadRequest(new { error = "Usuário não encontrado" });
	}

	[HttpPost]
	[Route("login")]
	[SwaggerOperation(Summary = "Realizar login", Description = "Realiza o login do usuário, gerando um token JWT de acesso e um token de refresh.")]
	[SwaggerResponse(StatusCodes.Status200OK, "Login realizado com sucesso", typeof(object))]
	[SwaggerResponse(StatusCodes.Status401Unauthorized, "Falha na autenticação")]
	public async Task<IActionResult> Login([FromBody] LoginRequestDTO model)
	{
		var user = await _userManager.FindByNameAsync(model.UserName!);

		if (user is not null && await _userManager.CheckPasswordAsync(user, model.Password!))
		{
			var userRoles = await _userManager.GetRolesAsync(user);

			var authClaims = new List<Claim>
			{
				new Claim(ClaimTypes.Name, user.UserName!),
				new Claim(ClaimTypes.Email, user.Email!),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
			};

			foreach (var userRole in userRoles)
			{
				authClaims.Add(new Claim(ClaimTypes.Role, userRole));
			}

			var token = _tokenService.GenerateAccessToken(authClaims, _configuration);
			var refreshToken = _tokenService.GenerateRefreshToken();

			_ = int.TryParse(_configuration["JWT:RefreshTokenValidityInMinutes"], out int refreshTokenValidityInMinutes);

			user.RefreshTokenExpiryTime = DateTime.UtcNow.AddMinutes(refreshTokenValidityInMinutes);
			user.RefreshToken = refreshToken;

			await _userManager.UpdateAsync(user);

			return Ok(new
			{
				Token = new JwtSecurityTokenHandler().WriteToken(token),
				RefreshToken = refreshToken,
				Expiration = token.ValidTo
			});
		}
		return Unauthorized();
	}

	[HttpPost]
	[Route("register")]
	[SwaggerOperation(Summary = "Registrar novo usuário", Description = "Registra um novo usuário no sistema.")]
	[SwaggerResponse(StatusCodes.Status200OK, "Usuário registrado com sucesso", typeof(ResponseDTO))]
	[SwaggerResponse(StatusCodes.Status400BadRequest, "Erro ao registrar o usuário", typeof(ResponseDTO))]
	public async Task<IActionResult> Register([FromBody] RegisterRequestDTO model)
	{
		var userExists = await _userManager.FindByNameAsync(model.Username!);

		if (userExists != null)
		{
			return StatusCode(StatusCodes.Status500InternalServerError,
				   new ResponseDTO { Status = "Error", Message = "Usuário já existe!" });
		}

		ApplicationUser user = new()
		{
			Email = model.Email,
			SecurityStamp = Guid.NewGuid().ToString(),
			UserName = model.Username
		};

		var result = await _userManager.CreateAsync(user, model.Password!);

		if (!result.Succeeded)
		{
			var errors = result.Errors.Select(e => e.Description).ToList();

			foreach (var error in errors)
			{
				_logger.LogError("Erro ao criar usuário: {Error}", error);
			}

			return BadRequest(new ResponseDTO
			{
				Status = "Error",
				Message = "Falha ao criar o usuário.",
				Errors = errors 
			});
		}

		return Ok(new ResponseDTO { Status = "Success", Message = "Usuário criado com sucesso!" });
	}

	[HttpPost]
	[Route("refresh-token")]
	[SwaggerOperation(Summary = "Renovar token de acesso", Description = "Renova o token JWT de acesso utilizando um refresh token válido.")]
	[SwaggerResponse(StatusCodes.Status200OK, "Token renovado com sucesso", typeof(object))]
	[SwaggerResponse(StatusCodes.Status400BadRequest, "Falha ao renovar o token")]
	public async Task<IActionResult> RefreshToken(TokenResponseDTO tokenModel)
	{
		if (tokenModel is null)
		{
			return BadRequest("Solicitação inválida");
		}

		string? accessToken = tokenModel.AccessToken
							  ?? throw new ArgumentNullException(nameof(tokenModel));

		string? refreshToken = tokenModel.RefreshToken
							   ?? throw new ArgumentException(nameof(tokenModel));

		var principal = _tokenService.GetPrincipalFromExpiredToken(accessToken!, _configuration);

		if (principal == null)
		{
			return BadRequest("Token de acesso/refresh token inválido");
		}

		string username = principal.Identity.Name;

		var user = await _userManager.FindByNameAsync(username!);

		if (user == null || user.RefreshToken != refreshToken
						 || user.RefreshTokenExpiryTime <= DateTime.Now)
		{
			return BadRequest("Token de acesso/refresh token inválido");
		}

		var newAccessToken = _tokenService.GenerateAccessToken(principal.Claims.ToList(), _configuration);
		var newRefreshToken = _tokenService.GenerateRefreshToken();

		user.RefreshToken = newRefreshToken;

		await _userManager.UpdateAsync(user);

		return new ObjectResult(new
		{
			accessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
			refreshToken = newRefreshToken
		});
	}

	[HttpPost]
	[Authorize]
	[Route("revoke/{username}")]
	[SwaggerOperation(Summary = "Revogar token de usuário", Description = "Revoga o token de refresh de um usuário, invalidando-o.")]
	[SwaggerResponse(StatusCodes.Status204NoContent, "Token revogado com sucesso")]
	[SwaggerResponse(StatusCodes.Status400BadRequest, "Erro ao revogar o token")]
	public async Task<IActionResult> Revoke(string username)
	{
		var user = await _userManager.FindByNameAsync(username);

		if (user == null) return BadRequest("Nome de usuário inválido");

		user.RefreshToken = null;

		await _userManager.UpdateAsync(user);

		return NoContent();
	}
}
