using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips;

namespace Itmo.ObjectOrientedProgramming.Lab1.Service;

public interface IGetOptimal
{
    ISpaceShip? GetOptimal(IEnumerable<ISpaceShip> allSpaceShips);
}