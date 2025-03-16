using Application.PresentationPort;
using Spectre.Console;

namespace Presentation.Console.Scenarios;

public class UserLogInScenario : IScenario
{
    private readonly IUserService _userService;

    public UserLogInScenario(IUserService userService)
    {
        _userService = userService;
        Name = "Connect to user";
    }

    public string Name { get; }
    public void Run()
    {
        string number = AnsiConsole.Ask<string>("Enter number");
        string pin = AnsiConsole.Ask<string>("Enter pin");
        LogInResult logInResult = _userService.UserLogIn(number, pin);
        if (logInResult is LogInResult.Success)
        {
            AnsiConsole.Write("Entered successfully");
        }
        else if (logInResult is LogInResult.NoSuccess)
        {
            AnsiConsole.Write("No such user");
        }

        AnsiConsole.Ask<string>(string.Empty);
    }
}