using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.ComputerCoolings;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Corpuses;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Cpu;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.GraphicCards;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Hdd;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Motherboards;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.PowerSupplyUnits;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Ram;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.SolidStateDrives;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.WiFiAdapters;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Validators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class ComputerBuilder
{
    private readonly IValidator _validator;
    private Motherboard? _motherboard;
    private CentralProcessingUnit? _centralProcessingUnit;
    private ComputerCooling? _computerCooling;
    private List<RandomAccessMemory> _randomAccessMemoryModules = new();
    private GraphicsCard? _graphicsCard;
    private List<ISolidStateDrive> _solidStateDrives = new();
    private List<HardDiskDrive> _hardDiskDrives = new();
    private Corpus? _corpus;
    private PowerSupplyUnit? _powerSupplyUnit;
    private WiFiAdapter? _wiFiAdapter;

    public ComputerBuilder(IValidator validator)
    {
        _validator = validator;
    }

    public ComputerBuilder AddMotherboard(Motherboard motherboard)
    {
        _motherboard = motherboard;
        return this;
    }

    public ComputerBuilder AddCentralProcessingUnit(CentralProcessingUnit centralProcessingUnit)
    {
        _centralProcessingUnit = centralProcessingUnit;
        return this;
    }

    public ComputerBuilder AddComputerCooling(ComputerCooling? computerCooling)
    {
        _computerCooling = computerCooling;
        return this;
    }

    public ComputerBuilder AddRandomAccessMemory(RandomAccessMemory randomAccessMemoryModules)
    {
        _randomAccessMemoryModules.Add(randomAccessMemoryModules);
        return this;
    }

    public ComputerBuilder AddGraphicsCard(GraphicsCard? graphicsCard)
    {
        _graphicsCard = graphicsCard;
        return this;
    }

    public ComputerBuilder AddSolidStateDrive(ISolidStateDrive solidStateDrive)
    {
        _solidStateDrives.Add(solidStateDrive);
        return this;
    }

    public ComputerBuilder AddHardDiskDrive(HardDiskDrive hardDiskDrive)
    {
        _hardDiskDrives.Add(hardDiskDrive);
        return this;
    }

    public ComputerBuilder AddCorpus(Corpus corpus)
    {
        _corpus = corpus;
        return this;
    }

    public ComputerBuilder AddPowerSupplyUnit(PowerSupplyUnit powerSupplyUnit)
    {
        _powerSupplyUnit = powerSupplyUnit;
        return this;
    }

    public ComputerBuilder AddWiFiAdapter(WiFiAdapter wiFiAdapter)
    {
        _wiFiAdapter = wiFiAdapter;
        return this;
    }

    public ComputerBuildResult Build()
    {
        if (_motherboard is null)
        {
            throw new ArgumentNullException(nameof(_motherboard), "The computer requires motherboard");
        }

        if (_centralProcessingUnit is null)
        {
            throw new ArgumentNullException(nameof(_centralProcessingUnit), "The computer requires Central Processing Unit");
        }
        else if (_centralProcessingUnit.IntegratedGraphicsProcessor is null && _graphicsCard is null)
        {
            throw new ArgumentException("No integrated graphics processor and no graphics card");
        }

        if (_corpus is null)
        {
            throw new ArgumentNullException(nameof(_corpus), "The computer requires Corpus");
        }

        if (_randomAccessMemoryModules.Count == 0)
        {
            throw new ArgumentException("The computer requires at least one RAM module");
        }

        if ((_solidStateDrives.Count == 0) && (_hardDiskDrives.Count == 0))
        {
            throw new ArgumentException("The computer requires at least one type of drive");
        }

        if (_powerSupplyUnit is null)
        {
            throw new ArgumentNullException(nameof(_powerSupplyUnit), "The computer requires Power Supply Unit");
        }

        var validationModel = new ValidationComputerModel(
            _motherboard,
            _centralProcessingUnit,
            _computerCooling,
            _randomAccessMemoryModules,
            _graphicsCard,
            _solidStateDrives,
            _hardDiskDrives,
            _corpus,
            _powerSupplyUnit,
            _wiFiAdapter);
        CompareResult compareResult = _validator.CheckCompatibility(validationModel);
        if (compareResult is CompareResult.Incompatible incompatible)
            return new ComputerBuildResult.NotSuccessfulBuild(incompatible.Errors);
        var computer = new Computer(validationModel);
        switch (compareResult)
        {
            case CompareResult.CompatibleWithWarning resultWithWarning:
                return new ComputerBuildResult.SuccessfulBuildWithWarning(computer, resultWithWarning.Warnings);
            case CompareResult.Compatible:
                return new ComputerBuildResult.SuccessfulBuild(computer);
        }

        throw new ArgumentException("Unknown compare result");
    }
}