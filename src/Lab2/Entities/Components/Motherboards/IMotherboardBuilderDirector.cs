using Itmo.ObjectOrientedProgramming.Lab2.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Motherboards;

public interface IMotherboardBuilderDirector
{
    MotherboardBuilder Direct(MotherboardBuilder builder);
}