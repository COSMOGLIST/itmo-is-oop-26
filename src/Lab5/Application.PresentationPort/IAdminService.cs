using Application.Models;

namespace Application.PresentationPort;

public interface IAdminService
{
    ConnectAdminResult ConnectAdmin(string password);
    CreateAccountResult AddNewUser(string number, string pin);
}