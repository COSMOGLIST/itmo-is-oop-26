using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;

public class DeflectorClassZero : IDeflector
{
    public DamageResult GetHit(double amountOfDamage)
    {
        return new DamageResult.DamagePassed(amountOfDamage);
    }
}