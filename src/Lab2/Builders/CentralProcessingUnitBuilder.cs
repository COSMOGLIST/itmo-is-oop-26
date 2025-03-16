using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.CoreProcessors;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Cpu;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.IntegratedGraphicsProcessors;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Sockets;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class CentralProcessingUnitBuilder
{
    private string? _name;
    private CoreProcessor? _coreProcessor;
    private Socket? _socket;
    private IntegratedGraphicsProcessor? _integratedGraphicsProcessor;
    private List<string> _possibleMemoryFrequencies = new();
    private int? _thermalDesignPower;
    private int? _powerConsumption;

    public CentralProcessingUnitBuilder AddName(string name)
    {
        _name = name;
        return this;
    }

    public CentralProcessingUnitBuilder AddCoreProcessor(CoreProcessor coreProcessor)
    {
        _coreProcessor = coreProcessor;
        return this;
    }

    public CentralProcessingUnitBuilder AddSocket(Socket socket)
    {
        _socket = socket;
        return this;
    }

    public CentralProcessingUnitBuilder AddIntegratedGraphicsProcessor(IntegratedGraphicsProcessor integratedGraphicsProcessor)
    {
        _integratedGraphicsProcessor = integratedGraphicsProcessor;
        return this;
    }

    public CentralProcessingUnitBuilder AddPossibleMemoryFrequency(string possibleMemoryFrequency)
    {
        _possibleMemoryFrequencies.Add(possibleMemoryFrequency);
        return this;
    }

    public CentralProcessingUnitBuilder AddThermalDesignPower(int thermalDesignPower)
    {
        _thermalDesignPower = thermalDesignPower;
        return this;
    }

    public CentralProcessingUnitBuilder AddPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public CentralProcessingUnit Build()
    {
        return new CentralProcessingUnit(
            _coreProcessor ?? throw new ArgumentNullException(nameof(_coreProcessor)),
            _socket ?? throw new ArgumentNullException(nameof(_socket)),
            _integratedGraphicsProcessor,
            _possibleMemoryFrequencies,
            _thermalDesignPower ?? throw new ArgumentNullException(nameof(_thermalDesignPower)),
            _powerConsumption ?? throw new ArgumentNullException(nameof(_powerConsumption)),
            _name ?? throw new ArgumentNullException(nameof(_name)));
    }
}