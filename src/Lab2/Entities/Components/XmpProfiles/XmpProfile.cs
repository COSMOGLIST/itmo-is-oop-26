using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.XmpProfiles;

public class XmpProfile : IComponent<XmpProfile>, IXmpBuilderDirector
{
    public XmpProfile(double voltage, string timing, IEnumerable<string> possibleMemoryFrequency)
    {
        Voltage = voltage;
        Timing = timing;
        PossibleMemoryFrequency = possibleMemoryFrequency;
    }

    public string Timing { get; }
    public double Voltage { get; }
    public IEnumerable<string> PossibleMemoryFrequency { get; }

    public XmpBuilder Direct(XmpBuilder builder)
    {
        builder.AddTiming(Timing);
        builder.AddVoltage(Voltage);
        foreach (string possibleMemoryFrequency in PossibleMemoryFrequency)
        {
            builder.AddPossibleMemoryFrequency(possibleMemoryFrequency);
        }

        return builder;
    }

    public XmpProfile Clone()
    {
        return new XmpProfile(Voltage, Timing, PossibleMemoryFrequency);
    }
}