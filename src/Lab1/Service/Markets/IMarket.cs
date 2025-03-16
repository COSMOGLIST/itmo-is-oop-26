using Itmo.ObjectOrientedProgramming.Lab1.Entities.Fuels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Service.Markets;

public interface IMarket
{
    decimal BuyAllFuel(FuelUsage fuelUsage);
}