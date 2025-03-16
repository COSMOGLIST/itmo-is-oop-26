using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Corpuses;

public class CorpusTwo : ICorpus
{
    private const double MaximumEndurance = 4;
    private readonly DamageCoefficient _currentDamageCoefficient = new(0.8, 1, 1);
    private double _currentEndurance = MaximumEndurance;
    public ResultOfFlight GetHit(double amountOfDamage)
    {
        double currentDamage = _currentDamageCoefficient.ProcessDamage(amountOfDamage);
        if (_currentEndurance <= currentDamage)
        {
            return ResultOfFlight.SpaceShipIsDestroyed;
        }

        _currentEndurance -= currentDamage;
        return ResultOfFlight.Success;
    }
}