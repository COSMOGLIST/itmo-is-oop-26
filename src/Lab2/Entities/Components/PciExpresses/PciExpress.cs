using Itmo.ObjectOrientedProgramming.Lab2.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.PciExpresses;

public class PciExpress : IComponent<PciExpress>, IPciExpressBuilderDirector
{
    public PciExpress(int numberOfLines, string version)
    {
        NumberOfLines = numberOfLines;
        Version = version;
    }

    public int NumberOfLines { get; }
    public string Version { get; }
    public PciExpressBuilder Direct(PciExpressBuilder builder)
    {
        builder.AddNumberOfPorts(NumberOfLines);
        builder.AddVersion(Version);

        return builder;
    }

    public PciExpress Clone()
    {
        return new PciExpress(NumberOfLines, Version);
    }
}