using Application.InfrastructurePort;
using Application.Models;
using Itmo.Dev.Platform.Postgres.Connection;
using Npgsql;

namespace Infrastructure.Database.Repositories;

public class AdminRepository : IAdminRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public AdminRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public ConnectAdminResult Connect(string password)
    {
        string query =
            """
            select password
            from passwords
            where password = :password;
            """;
        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .GetAwaiter()
            .GetResult();
        using var command = new NpgsqlCommand(query, connection);
        command.Parameters.AddWithValue("password", password);
        if (command.ExecuteScalar() is null)
        {
            return new ConnectAdminResult.NotSuccess();
        }

        return new ConnectAdminResult.Success();
    }

    public CreateAccountResult CreateAccount(string number, string pin)
    {
        string query =
            """
            insert into bank (number, pin, money)
            values (:number, :pin, 0);
            """;
        string queryCheck =
            """
            select number
            from bank
            where number = :number;
            """;
        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .GetAwaiter()
            .GetResult();
        using var commandCheck = new NpgsqlCommand(queryCheck, connection);
        commandCheck.Parameters.AddWithValue("number", number);
        if (commandCheck.ExecuteScalar() is not null)
        {
            return new CreateAccountResult.NotSuccess();
        }

        using var command = new NpgsqlCommand(query, connection);
        command.Parameters.AddWithValue("number", number);
        command.Parameters.AddWithValue("pin", pin);
        command.ExecuteNonQuery();
        return new CreateAccountResult.Success();
    }
}