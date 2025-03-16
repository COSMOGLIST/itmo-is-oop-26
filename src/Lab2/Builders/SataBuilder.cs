using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.SataPortses;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class SataBuilder
{
    private int? _numberOfPorts;
    private string? _version;

    public SataBuilder AddNumberOfPorts(int numberOfPorts)
    {
        _numberOfPorts = numberOfPorts;
        return this;
    }

    public SataBuilder AddVersion(string version)
    {
        _version = version;
        return this;
    }

    public SataPorts Build()
    {
        return new SataPorts(
            _numberOfPorts ?? throw new ArgumentNullException(nameof(_numberOfPorts)),
            _version ?? throw new ArgumentNullException(nameof(_version)));
    }
}