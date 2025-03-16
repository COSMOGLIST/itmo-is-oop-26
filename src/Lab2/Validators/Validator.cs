using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validators;

public class Validator : IValidator
{
    public CompareResult CheckCompatibility(ValidationComputerModel computerComponents)
    {
        var errors = new List<string>();
        var warnings = new List<string>();
        bool isCompatible = true;

        IValidator[] allValidators =
        {
            new CentralProcessingUnitValidator(),
            new RandomAccessMemoryModulesValidator(),
            new CorpusValidator(),
            new PowerSupplyUnitValidator(),
            new ComputerCoolingValidator(),
            new SataValidator(),
            new PciExpressValidator(),
            new ChipsetValidator(),
        };
        foreach (IValidator validator in allValidators)
        {
            switch (validator.CheckCompatibility(computerComponents))
            {
                case CompareResult.Incompatible incompatible:
                    isCompatible = false;
                    errors.AddRange(incompatible.Errors);
                    break;
                case CompareResult.CompatibleWithWarning compatible:
                    warnings.AddRange(compatible.Warnings);
                    break;
            }
        }

        if (isCompatible && errors.Count == 0)
        {
            if (isCompatible && warnings.Count != 0)
            {
                return new CompareResult.CompatibleWithWarning(warnings);
            }

            return new CompareResult.Compatible();
        }

        return new CompareResult.Incompatible(errors);
    }
}