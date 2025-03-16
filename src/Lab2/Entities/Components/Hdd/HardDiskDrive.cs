using Itmo.ObjectOrientedProgramming.Lab2.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Hdd;

public class HardDiskDrive : IComponent<HardDiskDrive>, IHddBuilderDirector
{
    public HardDiskDrive(int memoryVolume, int maximumWorkSpeed, int powerConsumption)
    {
        MemoryVolume = memoryVolume;
        MaximumWorkSpeed = maximumWorkSpeed;
        PowerConsumption = powerConsumption;
    }

    public int MemoryVolume { get; }
    public int MaximumWorkSpeed { get; }
    public int PowerConsumption { get; }

    public HddBuilder Direct(HddBuilder builder)
    {
        builder.AddPowerConsumption(PowerConsumption);
        builder.AddMemoryVolume(MemoryVolume);
        builder.AddMaximumWorkSpeed(MaximumWorkSpeed);

        return builder;
    }

    public HardDiskDrive Clone()
    {
        return new HardDiskDrive(MemoryVolume, MaximumWorkSpeed, PowerConsumption);
    }
}