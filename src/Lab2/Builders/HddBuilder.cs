using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Hdd;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class HddBuilder
{
    private int? _memoryVolume;
    private int? _maximumWorkSpeed;
    private int? _powerConsumption;

    public HddBuilder AddMemoryVolume(int memoryVolume)
    {
        _memoryVolume = memoryVolume;
        return this;
    }

    public HddBuilder AddMaximumWorkSpeed(int maximumWorkSpeed)
    {
        _maximumWorkSpeed = maximumWorkSpeed;
        return this;
    }

    public HddBuilder AddPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public HardDiskDrive Build()
    {
        return new HardDiskDrive(
            _memoryVolume ?? throw new ArgumentNullException(nameof(_memoryVolume)),
            _maximumWorkSpeed ?? throw new ArgumentNullException(nameof(_maximumWorkSpeed)),
            _powerConsumption ?? throw new ArgumentNullException(nameof(_powerConsumption)));
    }
}