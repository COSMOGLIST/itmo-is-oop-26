using Application.Models;
using Application.PresentationPort;
using Spectre.Console;

namespace Presentation.Console.Scenarios;

public class GetHistoryScenario : IScenario
{
    private readonly IUserService _userService;

    public GetHistoryScenario(IUserService userService)
    {
        _userService = userService;
        Name = "Get history";
    }

    public string Name { get; }
    public void Run()
    {
        IEnumerable<HistoryElement> moneyOperationResult = _userService.GetHistory();
        foreach (HistoryElement element in moneyOperationResult)
        {
            AnsiConsole.Write("Money changed from " + element.AmountOfMoneyBefore + " to " + element.AmountOfMoneyAfter + ".\n");
        }

        AnsiConsole.Ask<string>(string.Empty);
    }
}