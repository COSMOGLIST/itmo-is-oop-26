using System.Diagnostics.CodeAnalysis;
using Application.Models;
using Application.PresentationPort;
using Presentation.Console.Scenarios;

namespace Presentation.Console.ScenarioProviders;

public class AddMoneyScenarioProvider : IScenarioProvider
{
    private readonly IUserService _userService;
    private ICurrentRoleSession _currentRoleSession;

    public AddMoneyScenarioProvider(IUserService userService, ICurrentRoleSession currentRoleSession)
    {
        _userService = userService;
        _currentRoleSession = currentRoleSession;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentRoleSession.Role is Role.User)
        {
            scenario = new AddMoneyScenario(_userService);
            return true;
        }

        scenario = null;
        return false;
    }
}