using Itmo.ObjectOrientedProgramming.Lab2.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.WiFiAdapters;

public interface IWiFiAdapterBuilderDirector
{
    WiFiAdapterBuilder Direct(WiFiAdapterBuilder builder);
}