using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Ram;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validators;

public class RandomAccessMemoryModulesValidator : IValidator
{
    public CompareResult CheckCompatibility(ValidationComputerModel computerComponents)
    {
        var warnings = new List<string>();
        bool isCompatible = true;

        if (computerComponents.RandomAccessMemoryModules.Count() > computerComponents.Motherboard.RamSlots.NumberOfSlots)
        {
            isCompatible = false;
            warnings.Add("ERROR! Too much RAM modules");
        }

        foreach (RandomAccessMemory ram in computerComponents.RandomAccessMemoryModules)
        {
            if (ram.Ddr.Type != computerComponents.Motherboard.PossibleDdr.Type)
            {
                isCompatible = false;
                warnings.Add("ERROR! RAM is not comparable with motherboard due to no matching DDR");
            }

            if (ram.JedecStandard.PossibleMemoryFrequencies
                    .Intersect(computerComponents.Motherboard.Chipset.PossibleMemoryFrequencies)
                    .Any() is false)
            {
                isCompatible = false;
                warnings.Add("ERROR! RAM is not comparable with motherboard: no matching memory frequencies in JEDEC");
            }

            if (ram.FormFactor != computerComponents.Motherboard.FormFactor)
            {
                isCompatible = false;
                warnings.Add("ERROR! RAM is not comparable with motherboard due to no matching Form-Factor");
            }

            if (ram.XmpProfile is not null && ram.XmpProfile.PossibleMemoryFrequency
                    .Intersect(computerComponents.CentralProcessingUnit.PossibleMemoryFrequencies)
                    .Any() is false)
            {
                isCompatible = false;
                warnings.Add("ERROR! RAM is not comparable with CPU: no matching memory frequencies in XMP");
            }
        }

        if (isCompatible && warnings.Count == 0)
        {
            return new CompareResult.Compatible();
        }

        if (isCompatible && warnings.Count != 0)
        {
            return new CompareResult.CompatibleWithWarning(warnings);
        }

        return new CompareResult.Incompatible(warnings);
    }
}