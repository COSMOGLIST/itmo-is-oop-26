using Itmo.ObjectOrientedProgramming.Lab2.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.SataPortses;

public interface ISataPortsBuilderDirector
{
    SataBuilder Direct(SataBuilder builder);
}