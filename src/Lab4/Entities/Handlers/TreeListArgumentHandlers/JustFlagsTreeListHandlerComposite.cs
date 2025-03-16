using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.CommandArguments;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Handlers.TreeListArgumentHandlers;

public class JustFlagsTreeListHandlerComposite : AbstractTreeListArgumentHandler
{
    private ITreeListArgumentHandler _connectArgumentHandler;
    public JustFlagsTreeListHandlerComposite(ITreeListArgumentHandler connectArgumentHandler)
    {
        _connectArgumentHandler = connectArgumentHandler;
    }

    public override ArgumentHandlerResult Handle(IEnumerator<string> commandText, TreeListArguments.Builder builder)
    {
        while (true)
        {
            string currentCommand = commandText.Current;
            ArgumentHandlerResult result = _connectArgumentHandler.Handle(commandText, builder);
            if (currentCommand == commandText.Current)
            {
                return new ArgumentHandlerResult.ErrorResult("No such flag");
            }

            if (result is ArgumentHandlerResult.ErrorResult errorResult)
            {
                return errorResult;
            }

            if (commandText.MoveNext() is false)
            {
                return base.Handle(commandText, builder);
            }
        }
    }
}