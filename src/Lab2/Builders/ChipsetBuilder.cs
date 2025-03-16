using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Chipsets;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.WiFiModiles;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class ChipsetBuilder
{
    private List<string> _possibleMemoryFrequencies = new();
    private bool _xmpCompatibility;
    private IntegratedWiFiModule? _integratedWiFiModule;

    public ChipsetBuilder AddiIntegratedWiFiModule(IntegratedWiFiModule integratedWiFiModule)
    {
        _integratedWiFiModule = integratedWiFiModule;
        return this;
    }

    public ChipsetBuilder HasXmpCompatibility()
    {
        _xmpCompatibility = true;
        return this;
    }

    public ChipsetBuilder AddPossibleMemoryFrequency(string possibleMemoryFrequency)
    {
        _possibleMemoryFrequencies.Add(possibleMemoryFrequency);
        return this;
    }

    public Chipset Build()
    {
        return new Chipset(
            _xmpCompatibility,
            _possibleMemoryFrequencies,
            _integratedWiFiModule);
    }
}