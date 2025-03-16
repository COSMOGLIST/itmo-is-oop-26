using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Builders;
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

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Computer : IComputerBuilderDirector
{
    private readonly Motherboard _motherboard;
    private readonly CentralProcessingUnit _centralProcessingUnit;
    private readonly ComputerCooling? _computerCooling;
    private readonly IEnumerable<RandomAccessMemory> _randomAccessMemoryModules;
    private readonly GraphicsCard? _graphicsCard;
    private readonly IEnumerable<ISolidStateDrive> _solidStateDrives;
    private readonly IEnumerable<HardDiskDrive> _hardDiskDrives;
    private readonly Corpus _corpus;
    private readonly PowerSupplyUnit _powerSupplyUnit;
    private readonly WiFiAdapter? _wiFiAdapter;
    public Computer(
        Motherboard motherboard,
        CentralProcessingUnit centralProcessingUnit,
        IEnumerable<RandomAccessMemory> randomAccessMemoryModules,
        Corpus corpus,
        PowerSupplyUnit powerSupplyUnit,
        ComputerCooling? computerCooling,
        GraphicsCard? graphicsCard,
        WiFiAdapter? wiFiAdapter,
        IEnumerable<HardDiskDrive> hardDiskDrives,
        IEnumerable<ISolidStateDrive> solidStateDrives)
     {
         _motherboard = motherboard;
         _centralProcessingUnit = centralProcessingUnit;
         _randomAccessMemoryModules = randomAccessMemoryModules;
         _corpus = corpus;
         _powerSupplyUnit = powerSupplyUnit;
         _computerCooling = computerCooling;
         _graphicsCard = graphicsCard;
         _wiFiAdapter = wiFiAdapter;
         _hardDiskDrives = hardDiskDrives;
         _solidStateDrives = solidStateDrives;
     }

    public Computer(ValidationComputerModel validationComputerModel)
    {
        _motherboard = validationComputerModel.Motherboard;
        _centralProcessingUnit = validationComputerModel.CentralProcessingUnit;
        _randomAccessMemoryModules = validationComputerModel.RandomAccessMemoryModules;
        _corpus = validationComputerModel.Corpus;
        _powerSupplyUnit = validationComputerModel.PowerSupplyUnit;
        _computerCooling = validationComputerModel.ComputerCooling;
        _graphicsCard = validationComputerModel.GraphicsCard;
        _wiFiAdapter = validationComputerModel.WiFiAdapter;
        _hardDiskDrives = validationComputerModel.HardDiskDrives;
        _solidStateDrives = validationComputerModel.SolidStateDrives;
    }

    public ComputerBuilder Direct(ComputerBuilder computerBuilder)
    {
        computerBuilder.AddMotherboard(_motherboard);
        computerBuilder.AddCentralProcessingUnit(_centralProcessingUnit);
        foreach (RandomAccessMemory ram in _randomAccessMemoryModules)
        {
            computerBuilder.AddRandomAccessMemory(ram);
        }

        computerBuilder.AddCorpus(_corpus);
        computerBuilder.AddPowerSupplyUnit(_powerSupplyUnit);
        if (_computerCooling is not null)
        {
            computerBuilder.AddComputerCooling(_computerCooling);
        }

        computerBuilder.AddGraphicsCard(_graphicsCard);
        if (_wiFiAdapter is not null)
        {
           computerBuilder.AddWiFiAdapter(_wiFiAdapter);
        }

        foreach (HardDiskDrive hdd in _hardDiskDrives)
        {
            computerBuilder.AddHardDiskDrive(hdd);
        }

        foreach (ISolidStateDrive ssd in _solidStateDrives)
        {
            computerBuilder.AddSolidStateDrive(ssd);
        }

        return computerBuilder;
    }
 }