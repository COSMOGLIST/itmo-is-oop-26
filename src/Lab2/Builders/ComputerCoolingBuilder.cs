using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.ComputerCoolings;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class ComputerCoolingBuilder
{
    private double? _diameter;
    private List<string> _possibleSocketType = new();
    private int? _maximumTdp;

    public ComputerCoolingBuilder SetDiameter(double size)
    {
        _diameter = size;
        return this;
    }

    public ComputerCoolingBuilder SetMaximumTdp(int maximumTdp)
    {
        _maximumTdp = maximumTdp;
        return this;
    }

    public ComputerCoolingBuilder AddPossibleSocketType(string possibleSocketType)
    {
        _possibleSocketType.Add(possibleSocketType);
        return this;
    }

    public ComputerCooling Build()
    {
        return new ComputerCooling(
            _diameter ?? throw new ArgumentNullException(nameof(_diameter)),
            _possibleSocketType,
            _maximumTdp ?? throw new ArgumentNullException(nameof(_maximumTdp)));
    }
}