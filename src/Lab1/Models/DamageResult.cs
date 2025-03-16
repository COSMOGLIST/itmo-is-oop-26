namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public record DamageResult
{
    private DamageResult() { }
    public sealed record DamageDidNotPass : DamageResult;
    public sealed record DamagePassed(double PassedDamage) : DamageResult;
}