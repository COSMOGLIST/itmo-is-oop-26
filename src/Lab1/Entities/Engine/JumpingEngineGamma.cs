using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Fuels;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;

public class JumpingEngineGamma : IJumpingEngine
{
    private const double Speed = 120; // Скорость этого типа двигателей во время прыжка, световых лет в час
    private const double FuelConsumption = 2; // Значение отребления топлива для формулы
    private const double JumpMaximumLength = 50200;

    public Result Flight(double wayLength)
    {
        if (wayLength > JumpMaximumLength)
        {
            return new Result.NotSuccessResult(ResultOfFlight.SpaceShipIsLostBadJump);
        }

        var timeForTravel = TimeSpan.FromHours(wayLength / Speed);
        double fuelNeeded = Math.Pow(timeForTravel.TotalHours, FuelConsumption);
        var fuelUsage = new FuelUsage(new List<IFuelTypes> { new FuelGravitationalMatter(fuelNeeded) });
        return new Result.SuccessResult(timeForTravel, fuelUsage);
    }
}