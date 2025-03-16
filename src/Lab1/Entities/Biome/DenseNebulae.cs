using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Biome;

public class DenseNebulae : IBiome
{
    private readonly double _length;
    private readonly ObstacleList _allObstacles;
    public DenseNebulae(double length, IEnumerable<IDenseNebulaeObstacle> allObstacles)
    {
        _allObstacles = new ObstacleList(allObstacles);
        _length = length;
    }

    public Result Flight(ISpaceShip spaceShip)
    {
        ResultOfFlight finalResult = ObstacleAttack(spaceShip);
        if (finalResult != ResultOfFlight.Success)
        {
            return new Result.NotSuccessResult(finalResult);
        }

        return spaceShip.JumpingEngineThisShip.Flight(_length);
    }

    private ResultOfFlight ObstacleAttack(ISpaceShip attackedSpaceShip)
    {
        return _allObstacles.Attack(attackedSpaceShip);
    }
}