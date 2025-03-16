using Application.Models;

namespace Application.InfrastructurePort;

public interface IAdminRepository
{
    ConnectAdminResult Connect(string password);
    CreateAccountResult CreateAccount(string number, string pin);
}