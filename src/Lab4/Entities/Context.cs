using Itmo.ObjectOrientedProgramming.Lab4.Entities.ErrorsWarningWriters;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities;

public record Context(IErrorsWarningWriter ErrorWriter, Symbols Symbols)
{
    public IFileSystem? FileSystemRegime { get; set; }
    public string? Catalog { get; set; }
}