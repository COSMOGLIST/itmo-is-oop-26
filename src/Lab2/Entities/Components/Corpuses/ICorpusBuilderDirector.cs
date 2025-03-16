using Itmo.ObjectOrientedProgramming.Lab2.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.Corpuses;

public interface ICorpusBuilderDirector
{
    CorpusBuilder Direct(CorpusBuilder builder);
}