using Application.InfrastructurePort;
using Application.Models;
using Itmo.Dev.Platform.Postgres.Connection;
using Npgsql;

namespace Infrastructure.Database.Repositories;

public class HistoryRepository : IHistoryRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public HistoryRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public void LogHistory(string number, decimal amountBefore, decimal amountAfter)
    {
        string query =
            """
            insert into history (number, MoneyBefore, MoneyAfter)
            values (:number, :amountBefore, :amountAfter);
            """;
        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .GetAwaiter()
            .GetResult();
        using var command = new NpgsqlCommand(query, connection);
        command.Parameters.AddWithValue("number", number);
        command.Parameters.AddWithValue("amountBefore", amountBefore);
        command.Parameters.AddWithValue("amountAfter", amountAfter);
        command.ExecuteNonQuery();
    }

    public IEnumerable<HistoryElement> GetAccountHistory(string number)
    {
        string query =
            """
            select number, MoneyBefore, MoneyAfter
            from history
            where number = :number;
            """;
        NpgsqlConnection connection = _connectionProvider
            .GetConnectionAsync(default)
            .GetAwaiter()
            .GetResult();
        using var command = new NpgsqlCommand(query, connection);
        command.Parameters.AddWithValue("number", number);
        using NpgsqlDataReader result = command.ExecuteReader();
        while (result.Read())
        {
            yield return new HistoryElement(
                result.GetString(0),
                result.GetDecimal(1),
                result.GetDecimal(2));
        }
    }
}