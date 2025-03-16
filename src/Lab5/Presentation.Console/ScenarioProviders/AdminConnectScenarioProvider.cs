using System.Diagnostics.CodeAnalysis;
using Application.PresentationPort;
using Presentation.Console.Scenarios;

namespace Presentation.Console.ScenarioProviders;

public class AdminConnectScenarioProvider : IScenarioProvider
{
    private readonly IAdminService _adminService;
    private ICurrentRoleSession _currentRoleSession;

    public AdminConnectScenarioProvider(IAdminService adminService, ICurrentRoleSession currentRoleSession)
    {
        _adminService = adminService;
        _currentRoleSession = currentRoleSession;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentRoleSession.Role is null)
        {
            scenario = new AdminConnectScenario(_adminService);
            return true;
        }

        scenario = null;
        return false;
    }
}