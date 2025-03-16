using Application.Models;

namespace Application.PresentationPort;

public interface IUserService
{
    LogInResult UserLogIn(string number, string pin);
    MoneyOperationResult AddMoney(decimal amountOfMoney);
    MoneyOperationResult TakeMoney(decimal amountOfMoney);
    BalanceAskResult GetMoneyAmount();
    IEnumerable<HistoryElement> GetHistory();
}