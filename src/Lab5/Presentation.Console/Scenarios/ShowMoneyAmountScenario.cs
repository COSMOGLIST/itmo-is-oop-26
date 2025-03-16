using Application.Models;
using Application.PresentationPort;
using Spectre.Console;

namespace Presentation.Console.Scenarios;

public class ShowMoneyAmountScenario : IScenario
{
    private readonly IUserService _userService;

    public ShowMoneyAmountScenario(IUserService userService)
    {
        _userService = userService;
        Name = "Show balance";
    }

    public string Name { get; }
    public void Run()
    {
        BalanceAskResult balanceAskResult = _userService.GetMoneyAmount();
        if (balanceAskResult is BalanceAskResult.Success success)
        {
            AnsiConsole.Write("Money on account " + success.AmountOfMoney);
        }
        else
        {
            AnsiConsole.Write("No user");
        }

        AnsiConsole.Ask<string>(string.Empty);
    }
}