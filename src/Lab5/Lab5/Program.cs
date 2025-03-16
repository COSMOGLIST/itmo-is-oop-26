using BuisnessLogic;
using Infrastructure.Database;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Console;
using Spectre.Console;
var collection = new ServiceCollection();

collection.AddApplication().AddPresentationConsole().AddInfrastructureDataAccess(configuration =>
{
    configuration.Host = "localhost";
    configuration.Port = 9432;
    configuration.Username = "postgres";
    configuration.Password = "postgres";
    configuration.Database = "postgres";
    configuration.SslMode = "Prefer";
});

ServiceProvider provider = collection.BuildServiceProvider();
using IServiceScope scope = provider.CreateScope();
scope.UseInfrastructureDataAccess();
ScenarioRunner scenarioRunner = scope.ServiceProvider.GetRequiredService<ScenarioRunner>();

while (true)
{
    scenarioRunner.Run();
    AnsiConsole.Clear();
}