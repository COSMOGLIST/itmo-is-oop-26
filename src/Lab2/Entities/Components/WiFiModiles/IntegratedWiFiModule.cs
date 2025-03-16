using Itmo.ObjectOrientedProgramming.Lab2.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.WiFiModiles;

public class IntegratedWiFiModule : IComponent<IntegratedWiFiModule>, IWiFiModuleBuilderDirector
{
    public IntegratedWiFiModule(bool bluetoothModule, int powerConsumption, string wiFiVersion)
    {
        BluetoothModule = bluetoothModule;
        PowerConsumption = powerConsumption;
        WiFiVersion = wiFiVersion;
    }

    public string WiFiVersion { get; }
    public bool BluetoothModule { get; }
    public int PowerConsumption { get; }

    public IntegratedWiFiModuleBuilder Direct(IntegratedWiFiModuleBuilder builder)
    {
        builder.AddPowerConsumption(PowerConsumption);
        builder.HasBluetoothModule();
        builder.AddWiFiVersion(WiFiVersion);

        return builder;
    }

    public IntegratedWiFiModule Clone()
    {
        return new IntegratedWiFiModule(BluetoothModule, PowerConsumption, WiFiVersion);
    }
}