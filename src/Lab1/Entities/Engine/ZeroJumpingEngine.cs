using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;

public class ZeroJumpingEngine : IJumpingEngine
{
    public Result Flight(double wayLength)
    {
        return new Result.NotSuccessResult(ResultOfFlight.SpaceShipLostUnsuitableBiome);
    }
}