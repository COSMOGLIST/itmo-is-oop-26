using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public static class DataForTestGenerator
{
    public static IEnumerable<object[]> DataForTest()
    {
        yield return new object[] { "connect C:\\ -m local", typeof(ConnectCommand) };
        yield return new object[] { "disconnect", typeof(DisconnectCommand) };
        yield return new object[] { "tree goto C:\\", typeof(TreeGotoCommand) };
        yield return new object[] { "tree list -d 1 -m console", typeof(TreeListCommand) };
        yield return new object[] { "file show text.txt -m console", typeof(FileShowCommand) };
        yield return new object[] { "file move C:\\Users\\y2008\\test\\file1.txt C:\\Users\\y2008\\test\\test1\\", typeof(FileMoveCommand) };
        yield return new object[] { "file copy C:\\Users\\y2008\\test\\file1.txt C:\\Users\\y2008\\test\\test1\\", typeof(FileCopyCommand) };
        yield return new object[] { "file delete text.txt", typeof(FileDeleteCommand) };
        yield return new object[] { "file rename C:\\Users\\y2008\\test\\file1.txt text.txt", typeof(FileRenameCommand) };
    }
}