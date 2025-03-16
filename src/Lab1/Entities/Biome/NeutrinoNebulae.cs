using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Biome;

public class NeutrinoNebulae : IBiome
{
    private const double SpaceDensity = 0.5; // Влияние плотности простанства среды на скорость(a, СГ/ч^2)
    private readonly double _length;
    private readonly ObstacleList _allObstacles;

    public NeutrinoNebulae(double length, IEnumerable<INeutrinoNebulaeObstacle> allObstacles)
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