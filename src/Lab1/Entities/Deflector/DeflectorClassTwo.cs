using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;

public class DeflectorClassTwo : IDeflector
{
    private const int MaximumEndurance = 6;
    private readonly DamageCoefficient _currentDamageCoefficient = new(0.6, 1, 1);
    private double _currentEndurance = MaximumEndurance;

    public DamageResult GetHit(double amountOfDamage)
    {
        double currentEnduranceAfterThisHit = _currentEndurance - _currentDamageCoefficient.ProcessDamage(amountOfDamage);
        if (currentEnduranceAfterThisHit < 0)
        {
            _currentEndurance = 0;
            return new DamageResult.DamagePassed(-currentEnduranceAfterThisHit);
        }

        _currentEndurance = currentEnduranceAfterThisHit;
        return new DamageResult.DamageDidNotPass();
    }
}