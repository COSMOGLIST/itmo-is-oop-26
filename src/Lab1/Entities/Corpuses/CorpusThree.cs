using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Corpuses;

public class CorpusThree : ICorpus
{
    private const double MaximumEndurance = 10;
    private readonly DamageCoefficient _currentDamageCoefficient = new(0.5, 1, 1);
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