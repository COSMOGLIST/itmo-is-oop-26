using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.CommandArguments;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.ErrorsWarningWriters;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;

public interface IFileSystem
{
    void ShowFile(FileShowArguments arguments, string? catalogPath, IErrorsWarningWriter errorsWarningWriter);
    void CopyFile(FileCopyArguments arguments, string? catalogPath, IErrorsWarningWriter errorsWarningWriter);
    void MoveFile(FileMoveArguments arguments, string? catalogPath, IErrorsWarningWriter errorsWarningWriter);
    void RenameFile(FileRenameArguments arguments, string? catalogPath, IErrorsWarningWriter errorsWarningWriter);
    void DeleteFile(FileDeleteArguments arguments, string? catalogPath, IErrorsWarningWriter errorsWarningWriter);
    DirectoryElementResult GetDirectoryElement(int depth, string? catalogPath);
}