using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Configuration;
using Npgsql;
namespace Infrastructure.HealthChecks
{
    public class DatabaseHealthCheck : IHealthCheck
    {
        private readonly string _connectionString;

        public DatabaseHealthCheck(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection") + ";Timeout=5";
        }

        public async Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                using var connection = new NpgsqlConnection(_connectionString);
                await connection.OpenAsync(cancellationToken);

                using var command = new NpgsqlCommand("SELECT 1", connection)
                {
                    CommandTimeout = 5
                };

                await command.ExecuteNonQueryAsync(cancellationToken);
                return HealthCheckResult.Healthy("Up");
            }
            catch (Exception ex)
            {
                return HealthCheckResult.Unhealthy("Down", ex);
            }
        }
    }
}
