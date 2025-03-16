using Itmo.ObjectOrientedProgramming.Lab2.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.ComputerCoolings;

public interface IComputerCoolingBuilderDirector
{
    ComputerCoolingBuilder Direct(ComputerCoolingBuilder builder);
}