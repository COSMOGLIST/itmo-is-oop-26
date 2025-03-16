using Itmo.ObjectOrientedProgramming.Lab2.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Bioses;

public interface IBiosBuilderDirector
{
    BiosBuilder Direct(BiosBuilder builder);
}