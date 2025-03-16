using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validators;

public class CentralProcessingUnitValidator : IValidator
{
    public CompareResult CheckCompatibility(ValidationComputerModel computerComponents)
    {
        var errors = new List<string>();
        bool isCompatible = true;

        if (computerComponents.Motherboard.Bios.PossibleProcessors.Contains(computerComponents.CentralProcessingUnit.Name) is false)
        {
            isCompatible = false;
            errors.Add("ERROR! CPU is not comparable with motherboard due to BIOS");
        }

        if (computerComponents.CentralProcessingUnit.IntegratedGraphicsProcessor is null && computerComponents.GraphicsCard is null)
        {
            isCompatible = false;
            errors.Add("ERROR! No integrated graphics processor and no graphics card");
        }

        if (computerComponents.CentralProcessingUnit.Socket.Type != computerComponents.Motherboard.Socket.Type)
        {
            isCompatible = false;
            errors.Add("ERROR! CPU is not comparable with motherboard due to socket");
        }

        if (isCompatible && errors.Count == 0)
        {
            return new CompareResult.Compatible();
        }

        return new CompareResult.Incompatible(errors);
    }
}