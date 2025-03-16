using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.PciExpresses;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class PciExpressBuilder
{
    private int? _numberOfPorts;
    private string? _version;

    public PciExpressBuilder AddNumberOfPorts(int numberOfPorts)
    {
        _numberOfPorts = numberOfPorts;
        return this;
    }

    public PciExpressBuilder AddVersion(string version)
    {
        _version = version;
        return this;
    }

    public PciExpress Build()
    {
        return new PciExpress(
            _numberOfPorts ?? throw new ArgumentNullException(nameof(_numberOfPorts)),
            _version ?? throw new ArgumentNullException(nameof(_version)));
    }
}