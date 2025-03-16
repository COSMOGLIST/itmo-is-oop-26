using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

public class Asteroid : ICosmosObstacle
{
    private const int Damage = 1;

    public ResultOfFlight Attack(ISpaceShip attackedSpaceShip)
    {
        return attackedSpaceShip.GetHit(Damage);
    }
}