using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Ram;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validators;

public class ChipsetValidator : IValidator
{
    public CompareResult CheckCompatibility(ValidationComputerModel computerComponents)
    {
        var errors = new List<string>();
        bool isCompatible = true;

        if (computerComponents.Motherboard.Chipset.IntegratedWiFiModule is not null && computerComponents.WiFiAdapter is not null)
        {
            isCompatible = false;
            errors.Add("ERROR! Wi-Fi adapter is not comparable with motherboard: network equipment conflict");
        }

        if (computerComponents.CentralProcessingUnit.PossibleMemoryFrequencies
                .Intersect(computerComponents.Motherboard.Chipset.PossibleMemoryFrequencies)
                .Any() is false)
        {
            isCompatible = false;
            errors.Add("ERROR! CPU is not comparable with motherboard due to no matching memory frequencies");
        }

        foreach (RandomAccessMemory ram in computerComponents.RandomAccessMemoryModules)
        {
            if (ram.JedecStandard.PossibleMemoryFrequencies
                    .Intersect(computerComponents.Motherboard.Chipset.PossibleMemoryFrequencies)
                    .Any() is false)
            {
                isCompatible = false;
                errors.Add("ERROR! RAM is not comparable with motherboard: no matching memory frequencies in JEDEC");
            }

            if (ram.XmpProfile is not null)
            {
                if (computerComponents.Motherboard.Chipset.XmpCompatibility is false)
                {
                    isCompatible = false;
                    errors.Add("ERROR! RAM is not comparable with motherboard: no XMP compatibility");
                }
                else
                {
                    if (ram.XmpProfile.PossibleMemoryFrequency.Intersect(computerComponents.Motherboard.Chipset.PossibleMemoryFrequencies).Any() is false)
                    {
                        isCompatible = false;
                        errors.Add("ERROR! RAM is not comparable with motherboard: no matching memory frequencies in XMP");
                    }
                }
            }
        }

        if (isCompatible && errors.Count == 0)
        {
            return new CompareResult.Compatible();
        }

        return new CompareResult.Incompatible(errors);
    }
}