using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.WiFiAdapters;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class WiFiAdapterBuilder
{
    private string? _pciExpressVersion;
    private string? _wiFiVersion;
    private bool _bluetoothModule;
    private int? _powerConsumption;

    public WiFiAdapterBuilder AddPciExpressVersion(string pciExpressVersion)
    {
        _pciExpressVersion = pciExpressVersion;
        return this;
    }

    public WiFiAdapterBuilder AddWiFiVersion(string wiFiVersion)
    {
        _wiFiVersion = wiFiVersion;
        return this;
    }

    public WiFiAdapterBuilder AddPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public WiFiAdapterBuilder HasBluetoothModule()
    {
        _bluetoothModule = true;
        return this;
    }

    public WiFiAdapter Build()
    {
        return new WiFiAdapter(
            _bluetoothModule,
            _powerConsumption ?? throw new ArgumentNullException(nameof(_powerConsumption)),
            _wiFiVersion ?? throw new ArgumentNullException(nameof(_wiFiVersion)),
            _pciExpressVersion ?? throw new ArgumentNullException(nameof(_pciExpressVersion)));
    }
}