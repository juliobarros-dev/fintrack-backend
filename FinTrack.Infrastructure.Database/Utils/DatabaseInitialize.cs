using Microsoft.Extensions.Configuration;
using Npgsql;

namespace FinTrack.Infrastructure.Database.Utils;

public static class DatabaseInitialize
{
	public static async Task Initialize(string? connectionString)
	{
		if (string.IsNullOrWhiteSpace(connectionString))
			throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

		// conecta no banco postgres
		await using var adminConnection = new NpgsqlConnection(connectionString);
		await adminConnection.OpenAsync();

		// cria o banco se não existir
		await using (var cmd = new NpgsqlCommand("SELECT 1 FROM pg_database WHERE datname = 'fintrack'", adminConnection))
		{
			var exists = await cmd.ExecuteScalarAsync();
			if (exists == null)
			{
				await using var createCmd = new NpgsqlCommand("CREATE DATABASE fintrack", adminConnection);
				await createCmd.ExecuteNonQueryAsync();
			}
		}

		await adminConnection.CloseAsync();

		// conecta no banco fintrack e cria os schemas
		var fintrackConnStr = connectionString.Replace("Database=postgres", "Database=fintrack");

		await using var fintrackConnection = new NpgsqlConnection(fintrackConnStr);
		await fintrackConnection.OpenAsync();

		var createSchemasCmd = new NpgsqlCommand(@"
            DO $$
            BEGIN
                IF NOT EXISTS (SELECT 1 FROM pg_namespace WHERE nspname = 'budget') THEN
                    EXECUTE 'CREATE SCHEMA budget';
                END IF;

                IF NOT EXISTS (SELECT 1 FROM pg_namespace WHERE nspname = 'expense') THEN
                    EXECUTE 'CREATE SCHEMA expense';
                END IF;
            END
            $$;", fintrackConnection);

		await createSchemasCmd.ExecuteNonQueryAsync();
	}
}