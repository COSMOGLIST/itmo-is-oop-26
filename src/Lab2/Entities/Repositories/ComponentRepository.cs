using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Repositories;

public class ComponentRepository<T> : IRepository<T>
where T : IComponent<T>
{
    private List<T> _allComponents = new();
    public void Add(T newComponent)
    {
        _allComponents.Add(newComponent);
    }

    public T GetComponentById(int id)
    {
        return _allComponents[id].Clone();
    }
}