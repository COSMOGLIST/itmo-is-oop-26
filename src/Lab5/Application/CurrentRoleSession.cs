using Application.Models;
using Application.PresentationPort;

namespace BuisnessLogic;

public class CurrentRoleSession : ICurrentRoleSession
{
    public Role? Role { get; set; }
}