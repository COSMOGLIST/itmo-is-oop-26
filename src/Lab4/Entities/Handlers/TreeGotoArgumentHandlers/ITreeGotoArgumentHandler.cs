using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.CommandArguments;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Handlers.TreeGotoArgumentHandlers;

public interface ITreeGotoArgumentHandler
{
    ITreeGotoArgumentHandler SetNext(ITreeGotoArgumentHandler handler);

    ArgumentHandlerResult Handle(IEnumerator<string> commandText, TreeGotoArguments.Builder builder);
}