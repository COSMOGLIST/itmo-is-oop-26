using SourceKit.Generators.Builder.Annotations;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.CommandArguments;

[GenerateBuilder]
public partial record ConnectArguments(string FileSystemPath, string FileSystemRegime);