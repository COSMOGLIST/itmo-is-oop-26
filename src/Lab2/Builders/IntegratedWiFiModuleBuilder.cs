using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.WiFiModiles;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class IntegratedWiFiModuleBuilder
{
    private int? _powerConsumption;
    private string? _wiFiVersion;
    private bool _bluetoothModule;

    public IntegratedWiFiModuleBuilder AddWiFiVersion(string wiFiVersion)
    {
        _wiFiVersion = wiFiVersion;
        return this;
    }

    public IntegratedWiFiModuleBuilder AddPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public IntegratedWiFiModuleBuilder HasBluetoothModule()
    {
        _bluetoothModule = true;
        return this;
    }

    public IntegratedWiFiModule Build()
    {
        return new IntegratedWiFiModule(
            _bluetoothModule,
            _powerConsumption ?? throw new ArgumentNullException(nameof(_powerConsumption)),
            _wiFiVersion ?? throw new ArgumentNullException(nameof(_wiFiVersion)));
    }
}