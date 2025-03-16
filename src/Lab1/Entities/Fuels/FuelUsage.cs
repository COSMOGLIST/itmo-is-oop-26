using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Fuels;

public record FuelUsage(IEnumerable<IFuelTypes> AllFuel);