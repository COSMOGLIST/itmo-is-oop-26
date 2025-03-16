using System.Diagnostics.CodeAnalysis;
using Application.Models;
using Application.PresentationPort;
using Presentation.Console.Scenarios;

namespace Presentation.Console.ScenarioProviders;

public class AddNewUserScenarioProvider : IScenarioProvider
{
    private readonly IAdminService _adminService;
    private ICurrentRoleSession _currentRoleSession;
    public AddNewUserScenarioProvider(IAdminService adminService, ICurrentRoleSession currentRoleSession)
    {
        _adminService = adminService;
        _currentRoleSession = currentRoleSession;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentRoleSession.Role is Role.Admin)
        {
            scenario = new AddNewUserScenario(_adminService);
            return true;
        }

        scenario = null;
        return false;
    }
}