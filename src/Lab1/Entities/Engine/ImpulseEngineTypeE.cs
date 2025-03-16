using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Fuels;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;

public class ImpulseEngineTypeE : IImpulseEngine
{
    private const double Acceleration = 2; // Значение для формулы роста скорости этого типа двигателей(Ускорение, СГ/ч^2)
    private const double FuelConsumptionPerOneHour = 10;
    private const double FuelConsumptionForStart = 50;

    public Result Flight(double wayLength, double spaceDensity)
    {
        if (spaceDensity >= Acceleration)
        {
            return new Result.NotSuccessResult(ResultOfFlight.SpaceShipLostUnsuitableBiome);
        }

        double positiveTime = double.Sqrt(wayLength * 2 / (Acceleration - spaceDensity));
        var timeForTravel = TimeSpan.FromHours(positiveTime);
        double fuelNeeded = (timeForTravel.TotalHours * FuelConsumptionPerOneHour) + FuelConsumptionForStart;
        var fuelUsage = new FuelUsage(new List<IFuelTypes> { new FuelClassic(fuelNeeded) });
        return new Result.SuccessResult(timeForTravel, fuelUsage);
    }
}