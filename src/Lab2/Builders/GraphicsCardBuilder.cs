using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.GraphicCards;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class GraphicsCardBuilder
{
    private double? _length;
    private double? _width;
    private int? _amountOfMemory;
    private string? _pciExpressVersion;
    private int? _amountOfOccupiedPciPorts;
    private int? _chipFrequency;
    private int? _powerConsumption;

    public GraphicsCardBuilder AddLength(double length)
    {
        _length = length;
        return this;
    }

    public GraphicsCardBuilder AddWidth(double width)
    {
        _width = width;
        return this;
    }

    public GraphicsCardBuilder AddAmountOfMemory(int amountOfMemory)
    {
        _amountOfMemory = amountOfMemory;
        return this;
    }

    public GraphicsCardBuilder AddPciExpressVersion(string pciExpressVersion)
    {
        _pciExpressVersion = pciExpressVersion;
        return this;
    }

    public GraphicsCardBuilder AddAmountOfOccupiedPciPorts(int amountOfOccupiedPciPorts)
    {
        _amountOfOccupiedPciPorts = amountOfOccupiedPciPorts;
        return this;
    }

    public GraphicsCardBuilder AddChipFrequency(int chipFrequency)
    {
        _chipFrequency = chipFrequency;
        return this;
    }

    public GraphicsCardBuilder AddPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public GraphicsCard Build()
    {
        return new GraphicsCard(
            _length ?? throw new ArgumentNullException(nameof(_length)),
            _width ?? throw new ArgumentNullException(nameof(_width)),
            _amountOfMemory ?? throw new ArgumentNullException(nameof(_amountOfMemory)),
            _pciExpressVersion ?? throw new ArgumentNullException(nameof(_pciExpressVersion)),
            _chipFrequency ?? throw new ArgumentNullException(nameof(_chipFrequency)),
            _powerConsumption ?? throw new ArgumentNullException(nameof(_powerConsumption)),
            _amountOfOccupiedPciPorts ?? throw new ArgumentNullException(nameof(_amountOfOccupiedPciPorts)));
    }
}