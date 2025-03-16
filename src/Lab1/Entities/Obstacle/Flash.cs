using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

public class Flash : IDenseNebulaeObstacle
{
    public ResultOfFlight Attack(ISpaceShip attackedSpaceShip)
    {
        if (attackedSpaceShip.DeflectorThisShip is PhotonDefenceDeflector)
        {
            return ((PhotonDefenceDeflector)attackedSpaceShip.DeflectorThisShip).FlashHit();
        }

        return ResultOfFlight.CrewDied;
    }
}