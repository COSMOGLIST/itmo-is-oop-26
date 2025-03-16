using System.Diagnostics.CodeAnalysis;
using Application.PresentationPort;
using Presentation.Console.Scenarios;

namespace Presentation.Console.ScenarioProviders;

public class UserLogInScenarioProvider : IScenarioProvider
{
    private readonly IUserService _userService;
    private ICurrentRoleSession _currentRoleSession;

    public UserLogInScenarioProvider(IUserService userService, ICurrentRoleSession currentRoleSession)
    {
        _userService = userService;
        _currentRoleSession = currentRoleSession;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentRoleSession.Role is null)
        {
            scenario = new UserLogInScenario(_userService);
            return true;
        }

        scenario = null;
        return false;
    }
}