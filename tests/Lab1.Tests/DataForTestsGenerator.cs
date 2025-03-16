using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public static class DataForTestsGenerator
{
    public static IEnumerable<object[]> DataForTest1()
    {
        yield return new object[] { new TouristShuttle(), typeof(Result.NotSuccessResult) };
        yield return new object[] { new Augur(), typeof(Result.NotSuccessResult) };
    }

    public static IEnumerable<object[]> DataForTest2()
    {
        yield return new object[] { new Vaclas(), typeof(Result.NotSuccessResult) };
        yield return new object[] { new Vaclas(new PhotonDefenceDeflector(new DeflectorClassOne())), typeof(Result.SuccessResult) };
    }

    public static IEnumerable<object[]> DataForTest3()
    {
        yield return new object[] { new Vaclas(), typeof(Result.NotSuccessResult) };
        yield return new object[] { new Augur(), typeof(Result.SuccessResult) };
        yield return new object[] { new Meridian(), typeof(Result.SuccessResult) };
    }
}