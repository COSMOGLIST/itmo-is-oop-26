using Microsoft.Extensions.DependencyInjection;
using Presentation.Console.ScenarioProviders;

namespace Presentation.Console;

public static class PresentationExtensions
{
    public static IServiceCollection AddPresentationConsole(this IServiceCollection collection)
    {
        collection.AddScoped<ScenarioRunner>();

        collection.AddScoped<IScenarioProvider, UserLogInScenarioProvider>();
        collection.AddScoped<IScenarioProvider, AdminConnectScenarioProvider>();
        collection.AddScoped<IScenarioProvider, AddMoneyScenarioProvider>();
        collection.AddScoped<IScenarioProvider, AddNewUserScenarioProvider>();
        collection.AddScoped<IScenarioProvider, GetHistoryScenarioProvider>();
        collection.AddScoped<IScenarioProvider, ShowMoneyScenarioProvider>();
        collection.AddScoped<IScenarioProvider, TakeMoneyScenarioProvider>();

        return collection;
    }
}