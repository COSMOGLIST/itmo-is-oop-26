using Itmo.ObjectOrientedProgramming.Lab1.Entities.Fuels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Service.Markets;

public class MiningGuildMarket : IMarket
{
    private readonly decimal _fuelCost = 1;
    private readonly decimal _gravitationalMatterCost = 3;

    public decimal BuyAllFuel(FuelUsage fuelUsage)
    {
        decimal amountOfMoney = 0;
        foreach (IFuelTypes fuel in fuelUsage.AllFuel)
        {
            if (fuel is FuelClassic)
            {
                amountOfMoney += (decimal)fuel.AmountOfFuel * _fuelCost;
            }
            else if (fuel is FuelGravitationalMatter)
            {
                amountOfMoney += (decimal)fuel.AmountOfFuel * _gravitationalMatterCost;
            }
        }

        return amountOfMoney;
    }
}