using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Routes;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Service.ServisesForFlying;

public class GetAllReports
{
    private readonly Route _route;

    public GetAllReports(Route newRoute)
    {
        _route = newRoute;
    }

    public IEnumerable<Result> GetReports(IEnumerable<ISpaceShip> allSpaceShips)
    {
        return
            from spaceShip in allSpaceShips
            select _route.Flight(spaceShip);
    }
}