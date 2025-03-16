using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;

public interface IJumpingEngine
{
    Result Flight(double wayLength);
}