using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Fuels;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public record Result
{
    private Result() { }

    public record SuccessResult(TimeSpan SpentTime, FuelUsage SpentFuel) : Result;
    public record NotSuccessResult(ResultOfFlight FlightResult) : Result;
}