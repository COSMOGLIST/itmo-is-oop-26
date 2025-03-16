using Itmo.ObjectOrientedProgramming.Lab2.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.GraphicCards;

public interface IGraphicsCardBuilderDirector
{
    GraphicsCardBuilder Direct(GraphicsCardBuilder builder);
}