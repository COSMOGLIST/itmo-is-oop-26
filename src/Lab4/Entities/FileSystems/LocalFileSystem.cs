using System.Collections.Generic;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.CommandArguments;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.ErrorsWarningWriters;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems.Elements;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;

public class LocalFileSystem : IFileSystem
{
    private readonly string _fileSystemPath;

    public LocalFileSystem(string fileSystemPath)
    {
        _fileSystemPath = fileSystemPath;
    }

    public void ShowFile(FileShowArguments arguments, string? catalogPath, IErrorsWarningWriter errorsWarningWriter)
    {
        string filePath = GetPath(arguments.FilePath, catalogPath);
        try
        {
            string allText = File.ReadAllText(filePath);
            arguments.OutputMode.Write(allText);
        }
        catch (FileNotFoundException)
        {
            errorsWarningWriter.Write("Couldn't find the file");
        }
    }

    public void CopyFile(FileCopyArguments arguments, string? catalogPath, IErrorsWarningWriter errorsWarningWriter)
    {
        FilePathAskResult sourceFile = GetFile(arguments.SourcePath, catalogPath);
        FilePathAskResult destinationFile = GetFile(arguments.DestinationPath, catalogPath);
        if (destinationFile is FilePathAskResult.NoResult && sourceFile is FilePathAskResult.FileResult fileResult)
        {
            fileResult.File.CopyTo(GetPath(arguments.DestinationPath, catalogPath));
        }
        else if (sourceFile is FilePathAskResult.NoResult)
        {
            errorsWarningWriter.Write("Couldn't find the file");
        }
        else
        {
            errorsWarningWriter.Write("There is already a file with this name in destination");
        }
    }

    public void MoveFile(FileMoveArguments arguments, string? catalogPath, IErrorsWarningWriter errorsWarningWriter)
    {
        FilePathAskResult sourceFile = GetFile(arguments.SourcePath, catalogPath);
        FilePathAskResult destinationFile = GetFile(arguments.DestinationPath, catalogPath);
        if (destinationFile is FilePathAskResult.NoResult && sourceFile is FilePathAskResult.FileResult fileResult)
        {
            fileResult.File.MoveTo(GetPath(arguments.DestinationPath, catalogPath));
        }
        else if (sourceFile is FilePathAskResult.NoResult)
        {
            errorsWarningWriter.Write("Couldn't find the file");
        }
        else
        {
            errorsWarningWriter.Write("There is already a file with this name in destination");
        }
    }

    public void RenameFile(FileRenameArguments arguments, string? catalogPath, IErrorsWarningWriter errorsWarningWriter)
    {
        string newName = Path.GetDirectoryName(arguments.FilePath) + '\\' + arguments.Name;
        string oldName = GetPath(arguments.FilePath, catalogPath);
        FilePathAskResult oldNameFilePathAskResult = GetFile(oldName, catalogPath);
        FilePathAskResult newNameFilePathAskResult = GetFile(newName, catalogPath);
        if (newNameFilePathAskResult is FilePathAskResult.NoResult && oldNameFilePathAskResult is FilePathAskResult.FileResult fileResult)
        {
            fileResult.File.MoveTo(newName);
        }
        else if (oldNameFilePathAskResult is FilePathAskResult.NoResult)
        {
            errorsWarningWriter.Write("Couldn't find the file");
        }
        else
        {
            errorsWarningWriter.Write("There is already a file with this name");
        }
    }

    public void DeleteFile(FileDeleteArguments arguments, string? catalogPath, IErrorsWarningWriter errorsWarningWriter)
    {
        FilePathAskResult result = GetFile(arguments.FilePath, catalogPath);
        if (result is FilePathAskResult.FileResult fileResult)
        {
            fileResult.File.Delete();
        }
        else
        {
            errorsWarningWriter.Write("Couldn't find the file");
        }
    }

    public DirectoryElementResult GetDirectoryElement(int depth, string? catalogPath)
    {
        DirectoryPathAskResult directoryResult = GetDirectory(catalogPath);
        if (directoryResult is DirectoryPathAskResult.DirectoryResult result)
        {
            return new DirectoryElementResult.SuccessResult(GetElement(depth + 1, depth + 1, result.Directory));
        }
        else
        {
            return new DirectoryElementResult.NoResult();
        }
    }

    private IElement GetElement(int maxDepth, int depth, DirectoryInfo directoryMain)
    {
        depth--;
        if (depth <= 0)
        {
            return new DirectoryElement(directoryMain.Name, System.Array.Empty<IElement>(), maxDepth - 1);
        }

        var elements = new List<IElement>();
        DirectoryInfo[] directories = directoryMain.GetDirectories();
        FileInfo[] files = directoryMain.GetFiles();
        foreach (DirectoryInfo directory in directories)
        {
            elements.Add(GetElement(maxDepth, depth, directory));
        }

        foreach (FileInfo file in files)
        {
            elements.Add(new FileElement(file.Name, maxDepth - depth));
        }

        return new DirectoryElement(directoryMain.Name, elements, maxDepth - depth - 1);
    }

    private string GetPath(string fileInfo, string? catalogPath)
    {
        var directoryInfo = new DirectoryInfo(fileInfo);
        if (directoryInfo.Parent is null)
        {
            return fileInfo;
        }
        else
        {
            return _fileSystemPath + catalogPath + fileInfo;
        }
    }

    private FilePathAskResult GetFile(string fileInfo, string? catalogPath)
    {
        try
        {
            return new FilePathAskResult.FileResult(new FileInfo(GetPath(fileInfo, catalogPath)));
        }
        catch (FileNotFoundException)
        {
            return new FilePathAskResult.NoResult();
        }
    }

    private DirectoryPathAskResult GetDirectory(string? catalogPath)
    {
        try
        {
            if (catalogPath is not null)
            {
                var directoryInfo = new DirectoryInfo(catalogPath);
                if (directoryInfo.Parent is null)
                {
                    return new DirectoryPathAskResult.DirectoryResult(new DirectoryInfo(catalogPath));
                }
                else
                {
                    return new DirectoryPathAskResult.DirectoryResult(new DirectoryInfo(_fileSystemPath + catalogPath));
                }
            }
            else
            {
                return new DirectoryPathAskResult.DirectoryResult(new DirectoryInfo(_fileSystemPath));
            }
        }
        catch (DirectoryNotFoundException)
        {
            return new DirectoryPathAskResult.NoResult();
        }
    }

    private record FilePathAskResult
    {
        private FilePathAskResult() { }

        public record NoResult() : FilePathAskResult;
        public record FileResult(FileInfo File) : FilePathAskResult;
    }

    private record DirectoryPathAskResult
    {
        private DirectoryPathAskResult() { }

        public record NoResult() : DirectoryPathAskResult;
        public record DirectoryResult(DirectoryInfo Directory) : DirectoryPathAskResult;
    }
}