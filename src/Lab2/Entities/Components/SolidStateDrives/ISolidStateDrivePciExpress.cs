namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components.SolidStateDrives;

public interface ISolidStateDrivePciExpress : ISolidStateDrive
{
    string PciExpressVersion { get; }
}