using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.XmpProfiles;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class XmpBuilder
{
    private string? _timing;
    private double? _voltage;
    private List<string> _possibleMemoryFrequency = new();

    public XmpBuilder AddTiming(string timing)
    {
        _timing = timing;
        return this;
    }

    public XmpBuilder AddVoltage(double voltage)
    {
        _voltage = voltage;
        return this;
    }

    public XmpBuilder AddPossibleMemoryFrequency(string possibleMemoryFrequency)
    {
        _possibleMemoryFrequency.Add(possibleMemoryFrequency);
        return this;
    }

    public XmpProfile Build()
    {
        return new XmpProfile(
            _voltage ?? throw new ArgumentNullException(nameof(_voltage)),
            _timing ?? throw new ArgumentNullException(nameof(_timing)),
            _possibleMemoryFrequency);
    }
}