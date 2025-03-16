using Itmo.ObjectOrientedProgramming.Lab2.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.PciExpresses;

public interface IPciExpressBuilderDirector
{
    PciExpressBuilder Direct(PciExpressBuilder builder);
}