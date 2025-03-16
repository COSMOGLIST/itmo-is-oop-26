using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.SolidStateDrives;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validators;

public class SataValidator : IValidator
{
    public CompareResult CheckCompatibility(ValidationComputerModel computerComponents)
    {
        var errors = new List<string>();
        bool isCompatible = true;

        int amountOfOccupiedSataPorts = computerComponents.HardDiskDrives.Count() + computerComponents.SolidStateDrives.OfType<ISolidStateDriveSata>().Count();

        if (amountOfOccupiedSataPorts > computerComponents.Motherboard.SataPorts.NumberOfPorts)
        {
            isCompatible = false;
            errors.Add("ERROR! Too many components for SATA ports");
        }

        if (isCompatible && errors.Count == 0)
        {
            return new CompareResult.Compatible();
        }

        return new CompareResult.Incompatible(errors);
    }
}