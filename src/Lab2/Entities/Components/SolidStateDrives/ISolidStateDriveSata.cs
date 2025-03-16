namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.SolidStateDrives;

public interface ISolidStateDriveSata : ISolidStateDrive
{
    string SataVersion { get; }
}