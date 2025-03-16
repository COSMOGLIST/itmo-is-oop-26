using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Fuels;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;

public class ImpulseEngineTypeC : IImpulseEngine
{
    private const double Speed = 20; // Константная скорость этого типа двигателей, световых лет в час
    private const double FuelConsumptionPerOneHour = 2.5;
    private const double FuelConsumptionForStart = 5;

    public Result Flight(double wayLength, double spaceDensity)
    {
        // Формула равноускоренного движения (УСКОРЕНИЕ*ВРЕМЯ^2)/2 - (НАЧАЛЬНАЯ СКОРОСТЬ)*ВРЕМЯ + РАССТОЯНИЕ = 0; УСКОРЕНИЕ = ЗАМЕДЛЕНИЕ(spaceDensity)
        // ВРЕМЯ - неизвестная. Все остальное знаем, получаем квадратное уравнение
        // Дискриминант = (НАЧАЛЬНАЯ СКОРОСТЬ)^2 - 2*УСКОРЕНИЕ*РАССТОЯНИЕ
        // Если дискриминант < 0, то решений нет, тогда, если РАССТОЯНИЕ > ((НАЧАЛЬНАЯ СКОРОСТЬ)^2)/(2*УСКОРЕНИЕ), то решения нет
        double discriminant = (Speed * Speed) - (2 * wayLength * spaceDensity);
        if (discriminant < 0)
        {
            return new Result.NotSuccessResult(ResultOfFlight.SpaceShipLostUnsuitableBiome);
        }

        TimeSpan timeForTravel;
        if (spaceDensity == 0)
        {
            timeForTravel = TimeSpan.FromHours(wayLength / Speed);
        }
        else
        {
            // По формуле иксов из квадратного уравнения при решении через дискриминант, получаем первый(если смотреть на график, то левее изгиба)double unknownTime = (Speed - double.Sqrt((Speed * Speed) - (2 * wayLength * spaceDensity))) / spaceDensity
            double unknownTimeOne = (Speed - double.Sqrt(discriminant)) / spaceDensity;
            timeForTravel = TimeSpan.FromHours(unknownTimeOne);
        }

        double fuelNeeded = (timeForTravel.TotalHours * FuelConsumptionPerOneHour) + FuelConsumptionForStart;
        var fuelUsage = new FuelUsage(new List<IFuelTypes> { new FuelClassic(fuelNeeded) });
        return new Result.SuccessResult(timeForTravel, fuelUsage);
    }
}