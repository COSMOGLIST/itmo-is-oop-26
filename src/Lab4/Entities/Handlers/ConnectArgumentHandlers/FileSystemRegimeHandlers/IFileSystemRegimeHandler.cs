using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.CommandArguments;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Handlers.ConnectArgumentHandlers.FileSystemRegimeHandlers;

public interface IFileSystemRegimeHandler
{
    IFileSystemRegimeHandler SetNext(IFileSystemRegimeHandler handler);

    ArgumentHandlerResult Handle(IEnumerator<string> commandText, ConnectArguments.Builder builder);
}