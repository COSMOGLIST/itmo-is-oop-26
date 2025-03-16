using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Handlers.CommandHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Handlers.CommandHandlers.FileCommandsHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Handlers.CommandHandlers.TreeCommandsHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Handlers.ConnectArgumentHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Handlers.ConnectArgumentHandlers.FileSystemRegimeHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Handlers.FileCopyArgumentHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Handlers.FileDeleteArgumentHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Handlers.FileMoveArgumentHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Handlers.FileRenameArgumentHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Handlers.FileShowArgumentHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Handlers.FileShowArgumentHandlers.OutputModeFileShowHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Handlers.TreeGotoArgumentHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Handlers.TreeListArgumentHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Handlers.TreeListArgumentHandlers.OutputModeTreeListHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities;

public class Chain
{
    private ICommandHandler _handlers;
    public Chain()
    {
        IConnectArgumentHandler addressConnectArgumentHandler = new AddressConnectArgumentHandler();
        IFileSystemRegimeHandler fileSystemRegimeHandler = new LocalFileSystemRegimeHandler();
        IConnectArgumentHandler modeFlagConnectArgumentHandler = new ModeFlagConnectArgumentHandler(fileSystemRegimeHandler);
        IConnectArgumentHandler justFlagsConnectHandlerComposite = new JustFlagsConnectHandlerComposite(modeFlagConnectArgumentHandler);
        addressConnectArgumentHandler.SetNext(justFlagsConnectHandlerComposite);

        IFileCopyArgumentHandler sourcePathFileCopyArgumentHandler = new SourcePathFileCopyArgumentHandler();
        IFileCopyArgumentHandler destinationPathFileCopyArgumentHandler = new DestinationPathFileCopyArgumentHandler();
        sourcePathFileCopyArgumentHandler.SetNext(destinationPathFileCopyArgumentHandler);

        IFileMoveArgumentHandler sourcePathFileMoveArgumentHandler = new SourcePathFileMoveArgumentHandler();
        IFileMoveArgumentHandler destinationPathFileMoveArgumentHandler = new DestinationPathFileMoveArgumentHandler();
        sourcePathFileMoveArgumentHandler.SetNext(destinationPathFileMoveArgumentHandler);

        IFileRenameArgumentHandler pathFileRenameArgumentHandler = new PathFileRenameArgumentHandler();
        IFileRenameArgumentHandler nameFileRenameArgumentHandler = new NameFileRenameArgumentHandler();
        pathFileRenameArgumentHandler.SetNext(nameFileRenameArgumentHandler);

        IFileShowArgumentHandler pathFileShowArgumentHandler = new PathFileShowArgumentHandler();
        IOutputModeFileShowHandler consoleOutputModeFileShowHandler = new ConsoleOutputModeFileShowHandler();
        IFileShowArgumentHandler modelFlagFileShowArgumentHandler = new ModelFlagFileShowArgumentHandler(consoleOutputModeFileShowHandler);
        IFileShowArgumentHandler justFlagsFileShowHandlerComposite = new JustFlagsFileShowHandlerComposite(modelFlagFileShowArgumentHandler);
        pathFileShowArgumentHandler.SetNext(justFlagsFileShowHandlerComposite);

        ITreeListArgumentHandler depthTreeListArgumentHandler = new DepthFlagTreeListArgumentHandler();
        IOutputModeTreeListHandler consoleOutputModeTreeListHandler = new ConsoleOutputModeTreeListHandler();
        ITreeListArgumentHandler modelFlagTreeListArgumentHandler = new ModelFlagTreeListArgumentHandler(consoleOutputModeTreeListHandler);
        depthTreeListArgumentHandler.SetNext(modelFlagTreeListArgumentHandler);
        ITreeListArgumentHandler justFlagsTreeListHandlerComposite = new JustFlagsTreeListHandlerComposite(depthTreeListArgumentHandler);

        IFileDeleteArgumentHandler pathFileDeleteArgumentHandler = new PathFileDeleteArgumentHandler();

        ITreeGotoArgumentHandler pathTreeGotoArgumentHandler = new PathTreeGotoArgumentHandler();

        ICommandHandler treeGotoHandler = new TreeGotoHandler(pathTreeGotoArgumentHandler);
        ICommandHandler treeListHandler = new TreeListHandler(justFlagsTreeListHandlerComposite);
        treeGotoHandler.SetNext(treeListHandler);

        ICommandHandler fileCopyHandler = new FileCopyHandler(sourcePathFileCopyArgumentHandler);
        ICommandHandler fileDeleteHandler = new FileDeleteHandler(pathFileDeleteArgumentHandler);
        ICommandHandler fileMoveHandler = new FileMoveHandler(sourcePathFileMoveArgumentHandler);
        ICommandHandler fileRenameHandler = new FileRenameHandler(pathFileRenameArgumentHandler);
        ICommandHandler fileShowHandler = new FileShowHandler(pathFileShowArgumentHandler);
        fileCopyHandler
            .SetNext(fileDeleteHandler)
            .SetNext(fileMoveHandler)
            .SetNext(fileRenameHandler)
            .SetNext(fileShowHandler);

        ICommandHandler connectHandler = new ConnectHandler(addressConnectArgumentHandler);
        ICommandHandler disconnectHandler = new DisconnectHandler();
        ICommandHandler treeHandler = new TreeHandler(treeGotoHandler);
        ICommandHandler fileHandler = new FileHandler(fileCopyHandler);

        connectHandler.SetNext(treeHandler).SetNext(fileHandler).SetNext(disconnectHandler);
        _handlers = connectHandler;
    }

    public HandlerResult Handle(IEnumerable<string> commands)
    {
        IEnumerator<string> enumerator = commands.GetEnumerator();
        if (enumerator.MoveNext())
        {
            return _handlers.Handle(enumerator);
        }
        else
        {
            return new HandlerResult.ErrorResult("No command");
        }
    }
}