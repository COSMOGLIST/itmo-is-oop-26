using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.SolidStateDrives;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class SsdBuilder
{
    private int? _memoryVolume;
    private int? _maximumWorkSpeed;
    private int? _powerConsumption;
    private bool _sata;
    private string? _version;
    public SsdBuilder AddMemoryVolume(int memoryVolume)
    {
        _memoryVolume = memoryVolume;
        return this;
    }

    public SsdBuilder AddMaximumWorkSpeed(int maximumWorkSpeed)
    {
        _maximumWorkSpeed = maximumWorkSpeed;
        return this;
    }

    public SsdBuilder AddPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public SsdBuilder IsPciExpressPort(string pciVersion)
    {
        _version = pciVersion;
        _sata = false;
        return this;
    }

    public SsdBuilder IsSataPort(string sataVersion)
    {
        _version = sataVersion;
        _sata = true;
        return this;
    }

    public ISolidStateDrive Build()
    {
        if (_sata)
        {
            return new SolidStateDriveSata(
                _memoryVolume ?? throw new ArgumentNullException(nameof(_memoryVolume)),
                _maximumWorkSpeed ?? throw new ArgumentNullException(nameof(_maximumWorkSpeed)),
                _powerConsumption ?? throw new ArgumentNullException(nameof(_powerConsumption)),
                _version ?? throw new ArgumentNullException(nameof(_version)));
        }

        return new SolidStateDrivePciExpress(
            _memoryVolume ?? throw new ArgumentNullException(nameof(_memoryVolume)),
            _maximumWorkSpeed ?? throw new ArgumentNullException(nameof(_maximumWorkSpeed)),
            _powerConsumption ?? throw new ArgumentNullException(nameof(_powerConsumption)),
            _version ?? throw new ArgumentNullException(nameof(_version)));
    }
}