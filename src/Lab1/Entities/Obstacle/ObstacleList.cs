using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

public class ObstacleList : IObstacle
{
    private readonly IObstacle[] _allObstacles;

    public ObstacleList(IEnumerable<IObstacle> allObstacles)
    {
        _allObstacles = allObstacles.ToArray();
    }

    public ResultOfFlight Attack(ISpaceShip attackedSpaceShip)
    {
        foreach (IObstacle obstacle in _allObstacles)
        {
            ResultOfFlight result = obstacle.Attack(attackedSpaceShip);
            if (result != ResultOfFlight.Success)
            {
                return result;
            }
        }

        return ResultOfFlight.Success;
    }
}