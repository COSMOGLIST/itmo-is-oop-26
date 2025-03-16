using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.CommandArguments;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Handlers.FileMoveArgumentHandlers;

public interface IFileMoveArgumentHandler
{
    IFileMoveArgumentHandler SetNext(IFileMoveArgumentHandler handler);

    ArgumentHandlerResult Handle(IEnumerator<string> commandText, FileMoveArguments.Builder builder);
}