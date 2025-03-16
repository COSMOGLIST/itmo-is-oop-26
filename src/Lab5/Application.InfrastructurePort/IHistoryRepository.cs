using Application.Models;

namespace Application.InfrastructurePort;

public interface IHistoryRepository
{
    void LogHistory(string number, decimal amountBefore, decimal amountAfter);
    IEnumerable<HistoryElement> GetAccountHistory(string number);
}