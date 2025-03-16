using Itmo.ObjectOrientedProgramming.Lab2.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.SolidStateDrives;

public interface ISsdBuilderDirector
{
    SsdBuilder Direct(SsdBuilder ssdBuilder);
}