using Itmo.ObjectOrientedProgramming.Lab2.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Chipsets;

public interface IChipsetBuilderDirector
{
    ChipsetBuilder Direct(ChipsetBuilder builder);
}