using Microsoft.AspNetCore.Http;
using Npgsql;
using System;
using System.Net;
using System.Threading.Tasks;

namespace API.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                string message = "Ocorreu um erro inesperado.";
                if (ex.InnerException is PostgresException postgresEx && postgresEx.SqlState == "23503")
                {
                    message = "Há inconsistencias nesta operacao ao comunicar com o banco. Verifique possíveis relacionamentos";
                }

                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await context.Response.WriteAsJsonAsync(new
                {
                    message,
                    details = ex.Message
                });
            }
        }
    }
}