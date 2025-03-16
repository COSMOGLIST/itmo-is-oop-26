using Itmo.ObjectOrientedProgramming.Lab2.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.PowerSupplyUnits;

public class PowerSupplyUnit : IComponent<PowerSupplyUnit>, IPowerSupplyUnitBuilderDirector
{
    public PowerSupplyUnit(int maximumPowerConsumption, int recommendedPowerConsumption)
    {
        MaximumPowerConsumption = maximumPowerConsumption;
        RecommendedPowerConsumption = recommendedPowerConsumption;
    }

    public int MaximumPowerConsumption { get; }
    public int RecommendedPowerConsumption { get; }

    public PowerSupplyUnitBuilder Direct(PowerSupplyUnitBuilder builder)
    {
        builder.AddMaximumPowerConsumption(MaximumPowerConsumption);
        builder.AddRecommendedPowerConsumption(RecommendedPowerConsumption);

        return builder;
    }

    public PowerSupplyUnit Clone()
    {
        return new PowerSupplyUnit(MaximumPowerConsumption, RecommendedPowerConsumption);
    }
}