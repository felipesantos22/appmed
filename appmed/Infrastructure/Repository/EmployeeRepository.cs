using appmed.Domain.Entities;
using appmed.Domain.Interfaces;
using appmed.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace appmed.Infrastructure.Repository;

public class EmployeeRepository: IEmployee
{
    private readonly DataContext _dataContext;

    public EmployeeRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    
    public async Task<Employee> Create(Employee employee)
    {
        await _dataContext.Employees.AddAsync(employee);
        await _dataContext.SaveChangesAsync();
        return employee;
    }

    public async Task<List<Employee>> Index()
    {
        var employees = await _dataContext.Employees.ToListAsync();
        return employees;
    }

    public Task<Employee> Show(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Employee> Update(int id, Employee employee)
    {
        throw new NotImplementedException();
    }

    public Task<Employee> Destroy(int id)
    {
        throw new NotImplementedException();
    }
    
    // Function verify user in database
    public async Task<Employee> ShowEmployee(string name, string password)
    {
        var existingEmployee = await _dataContext.Employees
            .FirstOrDefaultAsync(e => e.Name == name && e.Password == password);

        return existingEmployee;
    }
}