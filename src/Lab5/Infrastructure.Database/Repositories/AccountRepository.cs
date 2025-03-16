using Application.InfrastructurePort;
using Application.Models;
using Itmo.Dev.Platform.Postgres.Connection;
using Npgsql;

namespace Infrastructure.Database.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public AccountRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public decimal GetBalance(string number)
    {
        string query =
            """
            select money
            from bank
            where number = :number;
            """;
        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .GetAwaiter()
            .GetResult();
        using var command = new NpgsqlCommand(query, connection);
        command.Parameters.AddWithValue("number", number);
        using NpgsqlDataReader result = command.ExecuteReader();
        result.Read();
        return result.GetDecimal(0);
    }

    public GetAccountResult GetUser(string number, string pin)
    {
        string query =
            """
            select number, pin, money
            from bank
            where number = :number and pin = :pin;
            """;
        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .GetAwaiter()
            .GetResult();
        using var command = new NpgsqlCommand(query, connection);
        command.Parameters.AddWithValue("number", number);
        command.Parameters.AddWithValue("pin", pin);
        using NpgsqlDataReader result = command.ExecuteReader();
        if (result.Read() is false)
        {
            return new GetAccountResult.NoSuchUser();
        }

        return new GetAccountResult.Success(new User(number, pin, result.GetDecimal(2)));
    }

    public void SetMoney(string number, decimal amountOfMoney)
    {
        string query =
            """
            update bank set money = :amountOfMoney
            where number = :number;
            """;
        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .GetAwaiter()
            .GetResult();
        using var command = new NpgsqlCommand(query, connection);
        command.Parameters.AddWithValue("number", number);
        command.Parameters.AddWithValue("amountOfMoney", amountOfMoney);
        command.ExecuteNonQuery();
    }
}