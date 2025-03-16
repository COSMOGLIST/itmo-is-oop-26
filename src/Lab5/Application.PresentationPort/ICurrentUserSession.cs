using Application.Models;

namespace Application.PresentationPort;

public interface ICurrentUserSession
{
    public User? User { get; }
}