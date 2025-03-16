using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.CommandArguments;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Handlers.ConnectArgumentHandlers;

public class AddressConnectArgumentHandler : AbstractConnectArgumentHandler
{
    public override ArgumentHandlerResult Handle(IEnumerator<string> commandText, ConnectArguments.Builder builder)
    {
        string address = commandText.Current;
        builder.WithFileSystemPath(address);
        return base.Handle(commandText, builder);
    }
}