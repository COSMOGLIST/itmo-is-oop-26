using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.WiFiModiles;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Chipsets;

public class Chipset : IComponent<Chipset>, IChipsetBuilderDirector
{
    public Chipset(bool xmpCompatibility, IEnumerable<string> possibleMemoryFrequencies, IntegratedWiFiModule? integratedWiFiModule)
    {
        XmpCompatibility = xmpCompatibility;
        PossibleMemoryFrequencies = possibleMemoryFrequencies;
        IntegratedWiFiModule = integratedWiFiModule;
    }

    public IEnumerable<string> PossibleMemoryFrequencies { get; }
    public bool XmpCompatibility { get; }
    public IntegratedWiFiModule? IntegratedWiFiModule { get; }

    public ChipsetBuilder Direct(ChipsetBuilder builder)
    {
        builder.HasXmpCompatibility();
        foreach (string possibleMemoryFrequency in PossibleMemoryFrequencies)
        {
            builder.AddPossibleMemoryFrequency(possibleMemoryFrequency);
        }

        if (IntegratedWiFiModule is not null)
        {
            builder.AddiIntegratedWiFiModule(IntegratedWiFiModule);
        }

        return builder;
    }

    public Chipset Clone()
    {
        return new Chipset(XmpCompatibility, PossibleMemoryFrequencies, IntegratedWiFiModule);
    }
}