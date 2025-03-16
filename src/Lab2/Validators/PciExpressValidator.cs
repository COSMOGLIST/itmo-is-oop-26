using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.SolidStateDrives;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validators;

public class PciExpressValidator : IValidator
{
    public CompareResult CheckCompatibility(ValidationComputerModel computerComponents)
    {
        var errors = new List<string>();
        bool isCompatible = true;

        int amountOfOccupiedPciPorts = 0;

        if (computerComponents.WiFiAdapter is not null)
        {
            amountOfOccupiedPciPorts += 1;
            if (computerComponents.WiFiAdapter.PciExpressVersion != computerComponents.Motherboard.PciExpress.Version)
            {
                isCompatible = false;
                errors.Add("ERROR! Wi-Fi adapter is not comparable with motherboard: inappropriate PCI-Express version");
            }
        }

        if (computerComponents.GraphicsCard is not null)
        {
            amountOfOccupiedPciPorts += computerComponents.GraphicsCard.AmountOfOccupiedPciPorts;
            if (computerComponents.GraphicsCard.PciExpressVersion != computerComponents.Motherboard.PciExpress.Version)
            {
                isCompatible = false;
                errors.Add("ERROR! Graphics card is not comparable with motherboard: inappropriate PCI-Express version");
            }
        }

        foreach (ISolidStateDrive ssd in computerComponents.SolidStateDrives)
        {
            if (ssd is ISolidStateDrivePciExpress ssdPciExpress)
            {
                amountOfOccupiedPciPorts += 1;
                if (ssdPciExpress.PciExpressVersion != computerComponents.Motherboard.PciExpress.Version)
                {
                    isCompatible = false;
                    errors.Add("ERROR! SSD is not comparable with motherboard: inappropriate PCI-Express version");
                }
            }
        }

        if (amountOfOccupiedPciPorts > computerComponents.Motherboard.PciExpress.NumberOfLines)
        {
            isCompatible = false;
            errors.Add("ERROR! Too many components for PCI-Express ports");
        }

        if (isCompatible && errors.Count == 0)
        {
            return new CompareResult.Compatible();
        }

        return new CompareResult.Incompatible(errors);
    }
}