using Itmo.ObjectOrientedProgramming.Lab2.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.WiFiModiles;

public interface IWiFiModuleBuilderDirector
{
    IntegratedWiFiModuleBuilder Direct(IntegratedWiFiModuleBuilder builder);
}