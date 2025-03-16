using Application.Models;
using Application.PresentationPort;
using Spectre.Console;

namespace Presentation.Console.Scenarios;

public class AdminConnectScenario : IScenario
{
    private readonly IAdminService _adminService;

    public AdminConnectScenario(IAdminService adminService)
    {
        _adminService = adminService;
        Name = "Connect to admin";
    }

    public string Name { get; }
    public void Run()
    {
        string number = AnsiConsole.Ask<string>("Enter password");
        ConnectAdminResult connectAdminResult = _adminService.ConnectAdmin(number);
        if (connectAdminResult is ConnectAdminResult.Success)
        {
            AnsiConsole.Write("Entered successfully");
        }
        else
        {
            AnsiConsole.Write("Incorrect password");
        }

        AnsiConsole.Ask<string>(string.Empty);
    }
}