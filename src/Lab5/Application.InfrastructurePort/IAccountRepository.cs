using Application.Models;

namespace Application.InfrastructurePort;

public interface IAccountRepository
{
    decimal GetBalance(string number);
    GetAccountResult GetUser(string number, string pin);
    void SetMoney(string number, decimal amountOfMoney);
}