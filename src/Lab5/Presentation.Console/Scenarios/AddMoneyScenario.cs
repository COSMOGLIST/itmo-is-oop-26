using Application.Models;
using Application.PresentationPort;
using Spectre.Console;

namespace Presentation.Console.Scenarios;

public class AddMoneyScenario : IScenario
{
    private readonly IUserService _userService;

    public AddMoneyScenario(IUserService userService)
    {
        _userService = userService;
        Name = "Add Money";
    }

    public string Name { get; }
    public void Run()
    {
        decimal number = AnsiConsole.Ask<decimal>("Enter number");
        MoneyOperationResult moneyOperationResult = _userService.AddMoney(number);
        if (moneyOperationResult is MoneyOperationResult.Success)
        {
            AnsiConsole.Write("Money were added successfully");
        }
        else
        {
            AnsiConsole.Write("No such user");
        }

        AnsiConsole.Ask<string>(string.Empty);
    }
}