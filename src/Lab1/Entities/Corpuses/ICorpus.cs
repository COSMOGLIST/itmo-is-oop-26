using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Corpuses;

public interface ICorpus
{
    ResultOfFlight GetHit(double amountOfDamage);
}