using Itmo.ObjectOrientedProgramming.Lab2.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Cpu;

public interface ICpuBuilderDirector
{
    CentralProcessingUnitBuilder Direct(CentralProcessingUnitBuilder centralProcessingUnitBuilder);
}