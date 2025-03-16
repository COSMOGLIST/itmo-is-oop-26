using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.CommandArguments;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Handlers.TreeListArgumentHandlers;

public interface ITreeListArgumentHandler
{
    ITreeListArgumentHandler SetNext(ITreeListArgumentHandler handler);

    ArgumentHandlerResult Handle(IEnumerator<string> commandText, TreeListArguments.Builder builder);
}