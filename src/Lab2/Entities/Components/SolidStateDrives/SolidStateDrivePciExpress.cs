using Itmo.ObjectOrientedProgramming.Lab2.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.SolidStateDrives;

public class SolidStateDrivePciExpress : ISolidStateDrive
{
    public SolidStateDrivePciExpress(int memoryVolume, int maxWorkSpeed, int powerConsumption, string pciExpressVersion)
    {
        MemoryVolume = memoryVolume;
        MaximumWorkSpeed = maxWorkSpeed;
        PowerConsumption = powerConsumption;
        PciExpressVersion = pciExpressVersion;
    }

    public string PciExpressVersion { get; }
    public int MemoryVolume { get; }
    public int MaximumWorkSpeed { get; }
    public int PowerConsumption { get; }

    public SsdBuilder Direct(SsdBuilder ssdBuilder)
    {
        ssdBuilder.AddMemoryVolume(MemoryVolume);
        ssdBuilder.AddPowerConsumption(PowerConsumption);
        ssdBuilder.AddMaximumWorkSpeed(MaximumWorkSpeed);
        ssdBuilder.IsPciExpressPort(PciExpressVersion);
        return ssdBuilder;
    }

    public ISolidStateDrive Clone()
    {
        return new SolidStateDrivePciExpress(MemoryVolume, MaximumWorkSpeed, PowerConsumption, PciExpressVersion);
    }
}