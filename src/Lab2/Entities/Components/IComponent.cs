namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

public interface IComponent<out T>
where T : IComponent<T>
{
    T Clone();
}