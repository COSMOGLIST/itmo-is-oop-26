using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.CommandArguments;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Handlers.FileCopyArgumentHandlers;

public interface IFileCopyArgumentHandler
{
    IFileCopyArgumentHandler SetNext(IFileCopyArgumentHandler handler);

    ArgumentHandlerResult Handle(IEnumerator<string> commandText, FileCopyArguments.Builder builder);
}