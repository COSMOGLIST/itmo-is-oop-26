using Itmo.ObjectOrientedProgramming.Lab2.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Ram;

public interface IRamBuilderDirector
{
    RamBuilder Direct(RamBuilder builder);
}