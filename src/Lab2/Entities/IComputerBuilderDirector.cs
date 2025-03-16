using Itmo.ObjectOrientedProgramming.Lab2.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public interface IComputerBuilderDirector
{
    ComputerBuilder Direct(ComputerBuilder computerBuilder);
}