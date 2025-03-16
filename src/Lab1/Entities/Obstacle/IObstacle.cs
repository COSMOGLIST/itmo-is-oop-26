using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

public interface IObstacle
{
    ResultOfFlight Attack(ISpaceShip attackedSpaceShip);
}