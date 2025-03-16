using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.CoreProcessors;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.IntegratedGraphicsProcessors;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Sockets;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Cpu;

public class CentralProcessingUnit : IComponent<CentralProcessingUnit>, ICpuBuilderDirector
{
    public CentralProcessingUnit(CoreProcessor coreProcessor, Socket socket, IntegratedGraphicsProcessor? integratedGraphicsProcessor, IEnumerable<string> possibleMemoryFrequencies, int thermalDesignPower, int powerConsumption, string name)
    {
        CoreProcessor = coreProcessor;
        Socket = socket;
        IntegratedGraphicsProcessor = integratedGraphicsProcessor;
        PossibleMemoryFrequencies = possibleMemoryFrequencies;
        ThermalDesignPower = thermalDesignPower;
        PowerConsumption = powerConsumption;
        Name = name;
    }

    public string Name { get; }
    public CoreProcessor CoreProcessor { get; }
    public Socket Socket { get; }
    public IntegratedGraphicsProcessor? IntegratedGraphicsProcessor { get; }
    public IEnumerable<string> PossibleMemoryFrequencies { get; }
    public int ThermalDesignPower { get; }
    public int PowerConsumption { get; }

    public CentralProcessingUnitBuilder Direct(CentralProcessingUnitBuilder centralProcessingUnitBuilder)
    {
        centralProcessingUnitBuilder.AddPowerConsumption(PowerConsumption);
        centralProcessingUnitBuilder.AddName(Name);
        centralProcessingUnitBuilder.AddSocket(Socket);
        centralProcessingUnitBuilder.AddCoreProcessor(CoreProcessor);
        centralProcessingUnitBuilder.AddThermalDesignPower(ThermalDesignPower);
        foreach (string possibleMemoryFrequency in PossibleMemoryFrequencies)
        {
            centralProcessingUnitBuilder.AddPossibleMemoryFrequency(possibleMemoryFrequency);
        }

        if (IntegratedGraphicsProcessor is not null)
        {
            centralProcessingUnitBuilder.AddIntegratedGraphicsProcessor(IntegratedGraphicsProcessor);
        }

        return centralProcessingUnitBuilder;
    }

    public CentralProcessingUnit Clone()
    {
        return new CentralProcessingUnit(
            CoreProcessor,
            Socket,
            IntegratedGraphicsProcessor,
            PossibleMemoryFrequencies,
            ThermalDesignPower,
            PowerConsumption,
            Name);
    }
}