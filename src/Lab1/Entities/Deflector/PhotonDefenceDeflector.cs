using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;

public class PhotonDefenceDeflector : IDeflector
{
    private const int MaximumPhotonDefence = 3;
    private readonly IDeflector _deflector;
    private int _currentPhotonDefence = MaximumPhotonDefence;
    public PhotonDefenceDeflector(IDeflector deflector)
    {
        _deflector = deflector;
    }

    public DamageResult GetHit(double amountOfDamage)
    {
        return _deflector.GetHit(amountOfDamage);
    }

    public ResultOfFlight FlashHit()
    {
        if (_currentPhotonDefence is 0)
        {
            return ResultOfFlight.CrewDied;
        }

        _currentPhotonDefence -= 1;
        return ResultOfFlight.Success;
    }
}