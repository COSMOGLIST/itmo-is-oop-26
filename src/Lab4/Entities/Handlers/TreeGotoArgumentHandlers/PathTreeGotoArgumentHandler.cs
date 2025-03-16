using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.CommandArguments;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Handlers.TreeGotoArgumentHandlers;

public class PathTreeGotoArgumentHandler : AbstractTreeGotoArgumentHandler
{
    public override ArgumentHandlerResult Handle(IEnumerator<string> commandText, TreeGotoArguments.Builder builder)
    {
        string sourcePath = commandText.Current;
        builder.WithCatalogPath(sourcePath);
        return base.Handle(commandText, builder);
    }
}