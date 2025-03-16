using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Validators;

public class CorpusValidator : IValidator
{
    public CompareResult CheckCompatibility(ValidationComputerModel computerComponents)
    {
        var errors = new List<string>();
        bool isCompatible = true;

        if (computerComponents.Corpus.PossibleFormFactorsForMatherBoard.Contains(computerComponents.Motherboard.FormFactor) is false)
        {
            isCompatible = false;
            errors.Add("ERROR! Corpus is not comparable with motherboard due to no matching Form-Factor");
        }

        if (computerComponents.ComputerCooling is not null
            && computerComponents.Corpus.MaximumComputerCoolingDiameter < computerComponents.ComputerCooling.Diameter)
        {
            isCompatible = false;
            errors.Add("ERROR! Too big computer cooling for corpus");
        }

        if (computerComponents.GraphicsCard is not null
            && (computerComponents.Corpus.MaximumGraphicsCardLength < computerComponents.GraphicsCard.Length
                || computerComponents.Corpus.MaximumGraphicsCardWidth < computerComponents.GraphicsCard.Width))
        {
            isCompatible = false;
            errors.Add("ERROR! Too big graphics card for corpus");
        }

        if (isCompatible && errors.Count == 0)
        {
            return new CompareResult.Compatible();
        }

        return new CompareResult.Incompatible(errors);
    }
}