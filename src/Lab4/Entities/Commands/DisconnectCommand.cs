namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class DisconnectCommand : ICommand
{
    public void Execute(Context context)
    {
        context.FileSystemRegime = null;
    }
}