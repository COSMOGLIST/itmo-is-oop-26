using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Biome;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Routes;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Service.ServisesForFlying;
using Xunit;
namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

[SuppressMessage("Test", "CA1707", Justification = "Test method naming convention")]
public class Tests
{
    [Theory]
    [MemberData(nameof(DataForTestsGenerator.DataForTest1), MemberType = typeof(DataForTestsGenerator))]
    public void Tourist_Shuttle_Should_Be_Lost_Due_To_The_Unsuitable_Biome_And_Augur_Should_Be_Lost_Due_To_Bad_Jump(ISpaceShip spaceShip, Type expectedResult)
    {
        // arrange
        var route = new Route(new List<IBiome>() { new DenseNebulae(25000, new List<IDenseNebulaeObstacle>()) });

        // act
        Result spaceShipResult = route.Flight(spaceShip);

        // assert
        Assert.Equal(expectedResult, spaceShipResult.GetType());
    }

    [Theory]
    [MemberData(nameof(DataForTestsGenerator.DataForTest2), MemberType = typeof(DataForTestsGenerator))]
    public void Vaclas_With_PhotonModification_Should_Survive_And_Vaclas_With_No_PhotonModification_Should_Not_Survive(ISpaceShip spaceShip, Type expectedResult)
    {
        // arrange
        var route = new Route(new List<IBiome>() { new DenseNebulae(25000, new List<IDenseNebulaeObstacle> { new Flash() }) });

        // act
        Result spaceShipResult = route.Flight(spaceShip);

        // assert
        Assert.Equal(expectedResult, spaceShipResult.GetType());
    }

    [Theory]
    [MemberData(nameof(DataForTestsGenerator.DataForTest3), MemberType = typeof(DataForTestsGenerator))]
    public void Vaclas_Should_Be_Destroyed_And_Augur_Should_Survive_After_Attack_And_Meridian_Should_Survive_With_AntiNeutrinoEmitter(ISpaceShip spaceShip, Type expectedResult)
    {
        // arrange
        var route = new Route(new List<IBiome>() { new NeutrinoNebulae(500, new List<INeutrinoNebulaeObstacle> { new SpaceWhale() }) });

        // act
        Result spaceShipResult = route.Flight(spaceShip);

        // assert
        Assert.Equal(expectedResult, spaceShipResult.GetType());
    }

    [Fact]
    public void Tourist_Shuttle_Should_Be_Cheaper_Than_Vaclas()
    {
        // arrange
        var route = new Route(new List<IBiome>() { new Cosmos(500, new List<ICosmosObstacle>()) });
        var vaclas = new Vaclas();
        var touristShuttle = new TouristShuttle();
        var allSpaceShips = new List<ISpaceShip> { vaclas, touristShuttle };

        // act and assert
        Assert.Equal(touristShuttle, new GetOptimalByMoney(route).GetOptimal(allSpaceShips));
    }

    [Fact]
    public void Stella_Should_Be_Chosen_Because_Stella_Can_Jump_Longer()
    {
        // arrange
        var route = new Route(new List<IBiome>() { new DenseNebulae(7500, new List<IDenseNebulaeObstacle>()) });
        ISpaceShip augur = new Augur();
        ISpaceShip stella = new Stella();
        var allSpaceShips = new List<ISpaceShip> { augur, stella };

        // act and assert
        Assert.Equal(stella, new GetOptimalByTime(route).GetOptimal(allSpaceShips));
        Assert.Equal(ResultOfFlight.SpaceShipIsLostBadJump, ((Result.NotSuccessResult)route.Flight(augur)).FlightResult);
    }

    [Fact]
    public void Vaclas_Should_Be_More_Effective_On_Long_Distances()
    {
        // arrange
        var route = new Route(new List<IBiome>() { new NeutrinoNebulae(7500, new List<INeutrinoNebulaeObstacle>()) });
        ISpaceShip vaclas = new Vaclas();
        ISpaceShip touristShuttle = new TouristShuttle();
        var allSpaceShips = new List<ISpaceShip> { vaclas, touristShuttle };

        // act and assert
        Assert.Equal(vaclas, new GetOptimalByTime(route).GetOptimal(allSpaceShips));
        Assert.Equal(vaclas, new GetOptimalByMoney(route).GetOptimal(allSpaceShips));
    }

    [Fact]
    public void Stella_Should_Not_Fly_Through_NeutrinoNebulae_And_Augur_Should_Be_Cheaper_Than_Vaclas()
    {
        // arrange
        var route = new Route(new List<IBiome>()
        {
            new NeutrinoNebulae(7500, new List<INeutrinoNebulaeObstacle>()),
            new Cosmos(2000, new List<ICosmosObstacle>()),
            new DenseNebulae(5000, new List<IDenseNebulaeObstacle>()),
        });
        ISpaceShip stella = new Stella();
        ISpaceShip augur = new Augur();
        ISpaceShip vaclas = new Vaclas();
        var allSpaceShips = new List<ISpaceShip> { stella, augur, vaclas };

        // act and assert
        Assert.Equal(ResultOfFlight.SpaceShipLostUnsuitableBiome, ((Result.NotSuccessResult)route.Flight(stella)).FlightResult);
        Assert.Equal(augur, new GetOptimalByMoney(route).GetOptimal(allSpaceShips));
    }

    [Fact]
    public void All_Ships_Should_Not_Succeed_Due_To_Their_Weaknesses()
    {
        // arrange
        var route = new Route(new List<IBiome>()
        {
            new NeutrinoNebulae(100, new List<INeutrinoNebulaeObstacle>()),
            new Cosmos(2000, new List<ICosmosObstacle>() { new Asteroid(), new Asteroid(), new Asteroid(), new Asteroid(), new Meteor(), new Meteor() }),
            new DenseNebulae(5000, new List<IDenseNebulaeObstacle> { new Flash() }),
        });
        ISpaceShip stella = new Stella();
        ISpaceShip augur = new Augur();
        ISpaceShip vaclas = new Vaclas();

        // act and assert
        Assert.Equal(ResultOfFlight.SpaceShipIsDestroyed, ((Result.NotSuccessResult)route.Flight(stella)).FlightResult);
        Assert.Equal(ResultOfFlight.CrewDied, ((Result.NotSuccessResult)route.Flight(augur)).FlightResult);
        Assert.Equal(ResultOfFlight.SpaceShipIsDestroyed, ((Result.NotSuccessResult)route.Flight(vaclas)).FlightResult);
    }

    [Fact]
    public void Stella_Should_Not_Fly_Through_NeutrinoNebulae_And_Vaclas_Should_Be_Destroyed_By_Whale_Other_Should_Succeed()
    {
        // arrange
        var route = new Route(new List<IBiome>()
        {
            new NeutrinoNebulae(3500, new List<INeutrinoNebulaeObstacle>() { new SpaceWhale() }),
            new Cosmos(2000, new List<ICosmosObstacle>() { new Asteroid(), new Asteroid(), new Asteroid(), new Asteroid(), new Meteor(), new Meteor() }),
        });
        ISpaceShip stella = new Stella();
        ISpaceShip augur = new Augur();
        ISpaceShip vaclas = new Vaclas();
        ISpaceShip meridian = new Meridian();
        var allSpaceShips = new List<ISpaceShip> { stella, augur, vaclas, meridian };

        // act
        var allReports = new GetAllReports(route).GetReports(allSpaceShips).ToList();

        // assert
        Assert.Equal(ResultOfFlight.SpaceShipIsDestroyed, ((Result.NotSuccessResult)allReports[0]).FlightResult);
        Assert.Equal(typeof(Result.SuccessResult), allReports[1].GetType());
        Assert.Equal(ResultOfFlight.SpaceShipIsDestroyed, ((Result.NotSuccessResult)allReports[2]).FlightResult);
        Assert.Equal(typeof(Result.SuccessResult), allReports[3].GetType());
    }

    [Fact]
    public void Augur_Should_Be_Destroyed_After_Attack_And_Meridian_Should_Survive_With_AntiNeutrinoEmitter()
    {
        // arrange
        var route = new Route(new List<IBiome>()
        {
            new NeutrinoNebulae(3500, new List<INeutrinoNebulaeObstacle>() { new SpaceWhale(), new SpaceWhale(), new SpaceWhale(), new SpaceWhale(), new SpaceWhale(), new SpaceWhale(), new SpaceWhale(), new SpaceWhale() }),
            new Cosmos(2000, new List<ICosmosObstacle>()),
        });
        ISpaceShip augur = new Augur();
        ISpaceShip meridian = new Meridian();

        // act
        Result augurReport = route.Flight(augur);
        Result meridianReport = route.Flight(meridian);

        // assert
        Assert.Equal(ResultOfFlight.SpaceShipIsDestroyed, ((Result.NotSuccessResult)augurReport).FlightResult);
        Assert.Equal(typeof(Result.SuccessResult), meridianReport.GetType());
    }
}