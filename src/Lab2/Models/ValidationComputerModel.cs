using System.Collections.Generic;
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

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public record ValidationComputerModel(
Motherboard Motherboard,
CentralProcessingUnit CentralProcessingUnit,
ComputerCooling? ComputerCooling,
IEnumerable<RandomAccessMemory> RandomAccessMemoryModules,
GraphicsCard? GraphicsCard,
IEnumerable<ISolidStateDrive> SolidStateDrives,
IEnumerable<HardDiskDrive> HardDiskDrives,
Corpus Corpus,
PowerSupplyUnit PowerSupplyUnit,
WiFiAdapter? WiFiAdapter);