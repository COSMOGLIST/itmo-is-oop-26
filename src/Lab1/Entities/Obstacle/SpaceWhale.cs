using Itmo.ObjectOrientedProgramming.Lab1.Entities.AntiNeutrinoEmitters;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

public class SpaceWhale : INeutrinoNebulaeObstacle
{
    private const int Damage = 1000;

    public ResultOfFlight Attack(ISpaceShip attackedSpaceShip)
    {
        if (attackedSpaceShip is IAntiNeutrinoEmitter)
        {
            return ResultOfFlight.Success;
        }

        return attackedSpaceShip.GetHit(Damage);
    }
}