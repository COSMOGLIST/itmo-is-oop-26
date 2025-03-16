using System.Collections.Generic;
using System.Globalization;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.CommandArguments;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Handlers.TreeListArgumentHandlers;

public class DepthFlagTreeListArgumentHandler : AbstractFlagsTreeListArgumentHandler
{
    public override ArgumentHandlerResult Handle(IEnumerator<string> commandText, TreeListArguments.Builder builder)
    {
        if (commandText.Current == "-d" && commandText.MoveNext())
        {
            int depth = int.Parse(commandText.Current, CultureInfo.CurrentCulture);
            builder.WithDepth(depth);
            return new ArgumentHandlerResult.SuccessResult();
        }
        else
        {
            return base.Handle(commandText, builder);
        }
    }
}