using Itmo.ObjectOrientedProgramming.Lab2.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.XmpProfiles;

public interface IXmpBuilderDirector
{
    XmpBuilder Direct(XmpBuilder builder);
}