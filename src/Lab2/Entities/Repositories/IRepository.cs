namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Repositories;

public interface IRepository<T>
{
    void Add(T newComponent);
    T GetComponentById(int id); // Под id подразумевается номер в репозитории
}