using Application.Models;
using Application.PresentationPort;
using Spectre.Console;

namespace Presentation.Console.Scenarios;

public class TakeMoneyScenario : IScenario
{
    private readonly IUserService _userService;

    public TakeMoneyScenario(IUserService userService)
    {
        _userService = userService;
        Name = "Take Money";
    }

    public string Name { get; }
    public void Run()
    {
        decimal number = AnsiConsole.Ask<decimal>("Enter number");
        MoneyOperationResult moneyOperationResult = _userService.TakeMoney(number);
        if (moneyOperationResult is MoneyOperationResult.Success)
        {
            AnsiConsole.Write("Money were taken successfully");
        }
        else if (moneyOperationResult is MoneyOperationResult.NotEnoughMoney)
        {
            AnsiConsole.Write("Not enough money");
        }
        else if (moneyOperationResult is MoneyOperationResult.NoSuchUser)
        {
            AnsiConsole.Write("No such user");
        }

        AnsiConsole.Ask<string>(string.Empty);
    }
}