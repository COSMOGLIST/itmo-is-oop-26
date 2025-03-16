using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Corpuses;

public class CorpusOne : ICorpus
{
    private const double MaximumEndurance = 1;
    private readonly DamageCoefficient _currentDamageCoefficient = new(1, 1, 1);
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