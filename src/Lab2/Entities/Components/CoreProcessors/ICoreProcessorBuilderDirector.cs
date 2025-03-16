using Itmo.ObjectOrientedProgramming.Lab2.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.CoreProcessors;

public interface ICoreProcessorBuilderDirector
{
    CoreProcessorBuilder Direct(CoreProcessorBuilder builder);
}