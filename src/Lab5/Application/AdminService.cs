using Application.InfrastructurePort;
using Application.Models;
using Application.PresentationPort;

namespace BuisnessLogic;

public class AdminService : IAdminService
{
    private readonly IAdminRepository _adminRepository;
    private CurrentRoleSession _currentRoleSession;

    public AdminService(IAdminRepository adminRepository, CurrentRoleSession currentRoleSession)
    {
        _adminRepository = adminRepository;
        _currentRoleSession = currentRoleSession;
    }

    public ConnectAdminResult ConnectAdmin(string password)
    {
        ConnectAdminResult result = _adminRepository.Connect(password);
        if (result is ConnectAdminResult.Success)
        {
            _currentRoleSession.Role = Role.Admin;
        }

        return result;
    }

    public CreateAccountResult AddNewUser(string number, string pin)
    {
        if (_currentRoleSession.Role is Role.Admin)
        {
            return _adminRepository.CreateAccount(number, pin);
        }

        return new CreateAccountResult.NotSuccess();
    }
}