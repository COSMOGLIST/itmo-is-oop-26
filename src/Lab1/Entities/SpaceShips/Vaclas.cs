using Itmo.ObjectOrientedProgramming.Lab1.Entities.Corpuses;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips;

public class Vaclas : ISpaceShip
{
    private readonly ICorpus _corpus = new CorpusTwo();

    public Vaclas()
    {
        DeflectorThisShip = new DeflectorClassOne();
    }

    public Vaclas(IDeflector deflector)
    {
        DeflectorThisShip = deflector;
    }

    public IImpulseEngine ImpulseEngineThisShip { get; } = new ImpulseEngineTypeE();
    public IJumpingEngine JumpingEngineThisShip { get; } = new JumpingEngineGamma();
    public IDeflector DeflectorThisShip { get; }
    public ResultOfFlight GetHit(double amountOfDamage)
    {
        DamageResult situationAfterDeflectorAttack = DeflectorThisShip.GetHit(amountOfDamage);
        if (situationAfterDeflectorAttack is DamageResult.DamagePassed)
        {
            return _corpus.GetHit(((DamageResult.DamagePassed)situationAfterDeflectorAttack).PassedDamage);
        }

        return ResultOfFlight.Success;
    }
}