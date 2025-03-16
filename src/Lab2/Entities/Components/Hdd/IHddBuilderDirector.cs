using Itmo.ObjectOrientedProgramming.Lab2.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Hdd;

public interface IHddBuilderDirector
{
    HddBuilder Direct(HddBuilder builder);
}