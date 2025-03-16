using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Biome;

public class Cosmos : IBiome
{
    private const double SpaceDensity = 0; // Влияние плотности простанства среды на скорость(a, СГ/ч^2)
    private readonly double _length;
    private readonly ObstacleList _allObstacles;
    public Cosmos(double length, IEnumerable<ICosmosObstacle> allObstacles)
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

        return spaceShip.ImpulseEngineThisShip.Flight(_length, SpaceDensity);
    }

    private ResultOfFlight ObstacleAttack(ISpaceShip attackedSpaceShip)
    {
        return _allObstacles.Attack(attackedSpaceShip);
    }
}