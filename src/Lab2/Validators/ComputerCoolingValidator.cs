using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validators;

public class ComputerCoolingValidator : IValidator
{
    private static readonly string[] Warnings = { "Disclaimer of warranty obligations: no cooling" };

    public CompareResult CheckCompatibility(ValidationComputerModel computerComponents)
    {
        if (computerComponents.ComputerCooling is null)
        {
            return new CompareResult.CompatibleWithWarning(Warnings);
        }
        else
        {
            var errors = new List<string>();
            var warnings = new List<string>();
            bool isCompatible = true;

            if (computerComponents.ComputerCooling.PossibleSocketType.Contains(computerComponents.Motherboard.Socket.Type) is false)
            {
                isCompatible = false;
                errors.Add("ERROR! Computer cooling is not comparable with motherboard due to socket");
            }

            if (computerComponents.CentralProcessingUnit.ThermalDesignPower > computerComponents.ComputerCooling.MaximumTdp)
            {
                warnings.Add("Disclaimer of warranty obligations: not enough cooling");
            }

            if (errors.Count != 0) return new CompareResult.Incompatible(errors);
            if (isCompatible && warnings.Count != 0)
            {
                return new CompareResult.CompatibleWithWarning(warnings);
            }

            return new CompareResult.Compatible();
        }
    }
}