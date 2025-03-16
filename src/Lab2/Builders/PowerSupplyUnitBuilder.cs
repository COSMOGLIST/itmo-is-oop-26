using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.PowerSupplyUnits;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class PowerSupplyUnitBuilder
{
    private int? _maximumPowerConsumption;
    private int? _recommendedPowerConsumption;
    public PowerSupplyUnitBuilder AddMaximumPowerConsumption(int powerConsumption)
    {
        _maximumPowerConsumption = powerConsumption;
        return this;
    }

    public PowerSupplyUnitBuilder AddRecommendedPowerConsumption(int powerConsumption)
    {
        _recommendedPowerConsumption = powerConsumption;
        return this;
    }

    public PowerSupplyUnit Build()
    {
        return new PowerSupplyUnit(
            _maximumPowerConsumption ?? throw new ArgumentNullException(nameof(_maximumPowerConsumption)),
            _recommendedPowerConsumption ?? throw new ArgumentNullException(nameof(_recommendedPowerConsumption)));
    }
}