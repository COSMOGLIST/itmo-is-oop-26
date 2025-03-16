namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public class DamageCoefficient
{
    private readonly double _littleDamageCoefficient;
    private readonly double _middleDamageCoefficient;
    private readonly double _hugeDamageCoefficient;

    public DamageCoefficient(double littleDamage, double middleDamage, double hugeDamage)
    {
        _littleDamageCoefficient = littleDamage;
        _middleDamageCoefficient = middleDamage;
        _hugeDamageCoefficient = hugeDamage;
    }

    public double ProcessDamage(double amountOfDamage)
    {
        if (amountOfDamage < 2)
        {
            amountOfDamage *= _littleDamageCoefficient;
        }
        else if (amountOfDamage < 1000)
        {
            amountOfDamage *= _middleDamageCoefficient;
        }
        else
        {
            amountOfDamage *= _hugeDamageCoefficient;
        }

        return amountOfDamage;
    }
}