using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validators;

public interface IValidator
{
    CompareResult CheckCompatibility(ValidationComputerModel computerComponents);
}