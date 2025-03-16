using Itmo.ObjectOrientedProgramming.Lab2.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.WiFiAdapters;

public class WiFiAdapter : IComponent<WiFiAdapter>, IWiFiAdapterBuilderDirector
{
    public WiFiAdapter(bool bluetoothModule, int powerConsumption, string wiFiVersion, string pciExpressVersion)
    {
        BluetoothModule = bluetoothModule;
        PowerConsumption = powerConsumption;
        WiFiVersion = wiFiVersion;
        PciExpressVersion = pciExpressVersion;
    }

    public string PciExpressVersion { get; }
    public string WiFiVersion { get; }
    public bool BluetoothModule { get; }
    public int PowerConsumption { get; }
    public WiFiAdapterBuilder Direct(WiFiAdapterBuilder builder)
    {
        builder.AddPowerConsumption(PowerConsumption);
        builder.HasBluetoothModule();
        builder.AddWiFiVersion(WiFiVersion);
        builder.AddPciExpressVersion(PciExpressVersion);

        return builder;
    }

    public WiFiAdapter Clone()
    {
        return new WiFiAdapter(BluetoothModule, PowerConsumption, WiFiVersion, PciExpressVersion);
    }
}