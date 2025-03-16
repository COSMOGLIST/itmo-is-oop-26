using Application.Models;
using Application.PresentationPort;
using Spectre.Console;

namespace Presentation.Console.Scenarios;

public class AddNewUserScenario : IScenario
{
    private readonly IAdminService _adminService;

    public AddNewUserScenario(IAdminService adminService)
    {
        _adminService = adminService;
        Name = "Add new user";
    }

    public string Name { get; }
    public void Run()
    {
        string number = AnsiConsole.Ask<string>("Enter number");
        string pin = AnsiConsole.Ask<string>("Enter pin");
        CreateAccountResult createAccountResult = _adminService.AddNewUser(number, pin);
        if (createAccountResult is CreateAccountResult.Success)
        {
            AnsiConsole.Write("Added Successfully");
        }
        else if (createAccountResult is CreateAccountResult.NotSuccess)
        {
            AnsiConsole.Write("Not success");
        }

        AnsiConsole.Ask<string>(string.Empty);
    }
}