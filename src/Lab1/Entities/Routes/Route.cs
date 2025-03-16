using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Biome;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Fuels;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Routes;

public class Route
{
    private readonly IBiome[] _allBiomes;

    public Route(IEnumerable<IBiome> allBiomes)
    {
        _allBiomes = allBiomes.ToArray();
    }

    public Result Flight(ISpaceShip spaceShip)
    {
        IEnumerable<IFuelTypes> allSpentFuel = Enumerable.Empty<IFuelTypes>();
        var spentTime = new TimeSpan(0, 0, 0);
        foreach (IBiome biome in _allBiomes)
        {
            Result oneBiomeSuccessReport = biome.Flight(spaceShip);
            if (oneBiomeSuccessReport is Result.SuccessResult)
            {
                allSpentFuel = allSpentFuel.Concat(((Result.SuccessResult)oneBiomeSuccessReport).SpentFuel.AllFuel);
                spentTime += ((Result.SuccessResult)oneBiomeSuccessReport).SpentTime;
            }
            else
            {
                return oneBiomeSuccessReport;
            }
        }

        var fuelUsage = new FuelUsage(allSpentFuel);
        return new Result.SuccessResult(spentTime, fuelUsage);
    }
}