using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Routes;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Service.Markets;

namespace Itmo.ObjectOrientedProgramming.Lab1.Service.ServisesForFlying;

public class GetOptimalByMoney : IGetOptimal
{
    private readonly Route _route;

    public GetOptimalByMoney(Route newRoute)
    {
        _route = newRoute;
    }

    public ISpaceShip? GetOptimal(IEnumerable<ISpaceShip> allSpaceShips)
    {
        ISpaceShip? theFastestSpaceShip = null;
        decimal? bestPrice = null;
        foreach (ISpaceShip spaceShip in allSpaceShips)
        {
            Result currentReport = _route.Flight(spaceShip);
            if (currentReport is Result.SuccessResult)
            {
                IMarket currentCourse = new MiningGuildMarket();
                decimal currentPrice = currentCourse.BuyAllFuel(((Result.SuccessResult)currentReport).SpentFuel);
                if (bestPrice is null || bestPrice > currentPrice)
                {
                    bestPrice = currentPrice;
                    theFastestSpaceShip = spaceShip;
                }
            }
        }

        return theFastestSpaceShip;
    }
}