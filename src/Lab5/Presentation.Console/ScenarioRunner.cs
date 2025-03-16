using Presentation.Console.ScenarioProviders;
using Presentation.Console.Scenarios;
using Spectre.Console;

namespace Presentation.Console;

public class ScenarioRunner
{
    private IEnumerable<IScenarioProvider> _scenarioProviders;

    public ScenarioRunner(IEnumerable<IScenarioProvider> scenarioProviders)
    {
        _scenarioProviders = scenarioProviders;
    }

    public void Run()
    {
        IEnumerable<IScenario> scenarios = GetScenarios();

        SelectionPrompt<IScenario> selector = new SelectionPrompt<IScenario>()
            .AddChoices(scenarios)
            .UseConverter(x => x.Name);

        IScenario scenario = AnsiConsole.Prompt(selector);
        scenario.Run();
    }

    private IEnumerable<IScenario> GetScenarios()
    {
        foreach (IScenarioProvider provider in _scenarioProviders)
        {
            if (provider.TryGetScenario(out IScenario? scenario))
                yield return scenario;
        }
    }
}