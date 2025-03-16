using Itmo.ObjectOrientedProgramming.Lab2.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.SolidStateDrives;

public class SolidStateDriveSata : ISolidStateDrive
{
    public SolidStateDriveSata(int memoryVolume, int maxWorkSpeed, int powerConsumption, string sataVersion)
    {
        MemoryVolume = memoryVolume;
        MaximumWorkSpeed = maxWorkSpeed;
        PowerConsumption = powerConsumption;
        SataVersion = sataVersion;
    }

    public string SataVersion { get; }
    public int MemoryVolume { get; }
    public int MaximumWorkSpeed { get; }
    public int PowerConsumption { get; }
    public SsdBuilder Direct(SsdBuilder ssdBuilder)
    {
        ssdBuilder.AddMemoryVolume(MemoryVolume);
        ssdBuilder.AddPowerConsumption(PowerConsumption);
        ssdBuilder.AddMaximumWorkSpeed(MaximumWorkSpeed);
        ssdBuilder.IsSataPort(SataVersion);
        return ssdBuilder;
    }

    public ISolidStateDrive Clone()
    {
        return new SolidStateDrivePciExpress(MemoryVolume, MaximumWorkSpeed, PowerConsumption, SataVersion);
    }
}