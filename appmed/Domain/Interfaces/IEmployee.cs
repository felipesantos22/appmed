using appmed.Domain.Entities;

namespace appmed.Domain.Interfaces;

public interface IEmployee
{
    public Task<Employee> Create(Employee employee);
    public Task<List<Employee>> Index();
    public Task<Employee> Show(int id);
    public Task<Employee> Update(int id, Employee employee);
    public Task<Employee> Destroy(int id);
}