using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Routes;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Service.ServisesForFlying;

public class GetOptimalByTime : IGetOptimal
{
    private readonly Route _route;

    public GetOptimalByTime(Route newRoute)
    {
        _route = newRoute;
    }

    public ISpaceShip? GetOptimal(IEnumerable<ISpaceShip> allSpaceShips)
    {
        ISpaceShip? theFastestSpaceShip = null;
        TimeSpan? bestTime = null;
        foreach (ISpaceShip spaceShip in allSpaceShips)
        {
            Result currentReport = _route.Flight(spaceShip);
            if (currentReport is Result.SuccessResult)
            {
                if (bestTime is null || bestTime > ((Result.SuccessResult)currentReport).SpentTime)
                {
                    bestTime = ((Result.SuccessResult)currentReport).SpentTime;
                    theFastestSpaceShip = spaceShip;
                }
            }
        }

        return theFastestSpaceShip;
    }
}