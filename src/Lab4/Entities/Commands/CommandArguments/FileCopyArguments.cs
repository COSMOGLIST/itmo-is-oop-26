using SourceKit.Generators.Builder.Annotations;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.CommandArguments;

[GenerateBuilder]
public partial record FileCopyArguments(string SourcePath, string DestinationPath);