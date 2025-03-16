using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;

public interface IImpulseEngine
{
    Result Flight(double wayLength, double spaceDensity);
}