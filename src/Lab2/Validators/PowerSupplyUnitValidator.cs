using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Hdd;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Ram;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.SolidStateDrives;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validators;

public class PowerSupplyUnitValidator : IValidator
{
    public CompareResult CheckCompatibility(ValidationComputerModel computerComponents)
    {
        var warnings = new List<string>();
        var errors = new List<string>();
        bool isCompatible = true;
        int powerConsumption = 0;
        powerConsumption += computerComponents.CentralProcessingUnit.PowerConsumption;
        foreach (RandomAccessMemory ram in computerComponents.RandomAccessMemoryModules)
        {
            powerConsumption += ram.PowerConsumption;
        }

        foreach (ISolidStateDrive ssd in computerComponents.SolidStateDrives)
        {
            powerConsumption += ssd.PowerConsumption;
        }

        foreach (HardDiskDrive hhd in computerComponents.HardDiskDrives)
        {
            powerConsumption += hhd.PowerConsumption;
        }

        if (computerComponents.GraphicsCard is not null)
        {
            powerConsumption += computerComponents.GraphicsCard.PowerConsumption;
        }

        if (computerComponents.WiFiAdapter is not null)
        {
            powerConsumption += computerComponents.WiFiAdapter.PowerConsumption;
        }

        if (computerComponents.Motherboard.Chipset.IntegratedWiFiModule is not null)
        {
            powerConsumption += computerComponents.Motherboard.Chipset.IntegratedWiFiModule.PowerConsumption;
        }

        if (powerConsumption > computerComponents.PowerSupplyUnit.MaximumPowerConsumption)
        {
            isCompatible = false;
            errors.Add("ERROR! Too much power consumption");
        }
        else if (powerConsumption > computerComponents.PowerSupplyUnit.RecommendedPowerConsumption)
        {
            warnings.Add("Power consumption is more than recommended");
        }

        if (isCompatible && errors.Count == 0)
        {
            if (isCompatible && warnings.Count != 0)
            {
                return new CompareResult.CompatibleWithWarning(warnings);
            }

            return new CompareResult.Compatible();
        }

        return new CompareResult.Incompatible(errors);
    }
}