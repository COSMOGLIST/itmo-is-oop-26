using Application.Models;
using Application.PresentationPort;

namespace BuisnessLogic;

public class CurrentUserSession : ICurrentUserSession
{
    public User? User { get; set; }
}