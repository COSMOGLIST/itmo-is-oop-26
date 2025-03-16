using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.CommandArguments;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Handlers.FileRenameArgumentHandlers;

public interface IFileRenameArgumentHandler
{
    IFileRenameArgumentHandler SetNext(IFileRenameArgumentHandler handler);

    ArgumentHandlerResult Handle(IEnumerator<string> commandText, FileRenameArguments.Builder builder);
}