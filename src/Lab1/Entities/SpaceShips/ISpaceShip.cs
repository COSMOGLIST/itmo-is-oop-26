using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips;

public interface ISpaceShip
{
    IImpulseEngine ImpulseEngineThisShip { get; }
    IJumpingEngine JumpingEngineThisShip { get; }

    IDeflector DeflectorThisShip { get; }

    ResultOfFlight GetHit(double amountOfDamage);
}