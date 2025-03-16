using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

public class Meteor : ICosmosObstacle
{
    private const int Damage = 2;

    public ResultOfFlight Attack(ISpaceShip attackedSpaceShip)
    {
        return attackedSpaceShip.GetHit(Damage);
    }
}