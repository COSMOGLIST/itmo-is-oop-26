using Itmo.ObjectOrientedProgramming.Lab4.Entities.OutputModes;
using SourceKit.Generators.Builder.Annotations;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.CommandArguments;

[GenerateBuilder]
public partial record TreeListArguments(int Depth, IOutputMode OutputMode);