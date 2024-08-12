using Inscricoes.Shared.Constants;
using System.ComponentModel.DataAnnotations;

namespace Inscricoes.Application.Validations;

public class CpfValidationAttribute : ValidationAttribute
{
	protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
	{
		if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
		{
			return new ValidationResult(MessageKeyConstants.MESSAGE_ERROR_CPF_INVALID);
		}

		string cpf = value.ToString().Replace(".", "").Replace("-", "").Trim();

		if (cpf.Length != 11 || cpf.All(c => c == cpf[0]))
		{
			return new ValidationResult(MessageKeyConstants.MESSAGE_ERROR_CPF_INVALID);
		}

		int[] multiplicador1 = [10, 9, 8, 7, 6, 5, 4, 3, 2];
		int[] multiplicador2 = [11, 10, 9, 8, 7, 6, 5, 4, 3, 2];

		string tempCpf = cpf.Substring(0, 9);
		int soma = 0;

		for (int i = 0; i < 9; i++)
		{
			soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
		}

		int resto = soma % 11;
		resto = resto < 2 ? 0 : 11 - resto;

		string digito = resto.ToString();
		tempCpf += digito;
		soma = 0;

		for (int i = 0; i < 10; i++)
		{
			soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
		}

		resto = soma % 11;
		resto = resto < 2 ? 0 : 11 - resto;

		digito += resto.ToString();

		return cpf.EndsWith(digito) ? ValidationResult.Success : new ValidationResult(MessageKeyConstants.MESSAGE_ERROR_CPF_INVALID);
	}
}
