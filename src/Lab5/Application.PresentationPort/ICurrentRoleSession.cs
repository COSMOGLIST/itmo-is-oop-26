using Application.Models;

namespace Application.PresentationPort;

public interface ICurrentRoleSession
{
    Role? Role { get; }
}