using System.Diagnostics.CodeAnalysis;
using Presentation.Console.Scenarios;

namespace Presentation.Console.ScenarioProviders;

public interface IScenarioProvider
{
    bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario);
}