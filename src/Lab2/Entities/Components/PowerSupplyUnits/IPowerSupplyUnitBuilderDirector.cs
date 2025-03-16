using Itmo.ObjectOrientedProgramming.Lab2.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.PowerSupplyUnits;

public interface IPowerSupplyUnitBuilderDirector
{
    PowerSupplyUnitBuilder Direct(PowerSupplyUnitBuilder builder);
}