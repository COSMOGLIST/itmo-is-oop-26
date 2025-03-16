using Itmo.ObjectOrientedProgramming.Lab2.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.SataPortses;

public class SataPorts : IComponent<SataPorts>, ISataPortsBuilderDirector
{
    public SataPorts(int numberOfPorts, string version)
    {
        NumberOfPorts = numberOfPorts;
        Version = version;
    }

    public int NumberOfPorts { get; }
    public string Version { get; }

    public SataBuilder Direct(SataBuilder builder)
    {
        builder.AddNumberOfPorts(NumberOfPorts);
        builder.AddVersion(Version);

        return builder;
    }

    public SataPorts Clone()
    {
        return new SataPorts(NumberOfPorts, Version);
    }
}