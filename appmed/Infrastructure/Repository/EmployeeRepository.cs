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

    public async Task<Employee?> Show(int id)
    {
        var employee = await _dataContext.Employees.FirstOrDefaultAsync(c => c.Id == id);
        return employee;
    }

    public async Task<Employee> Update(int id, Employee employee)
    {
        var employeeUpdate = await _dataContext.Employees.FirstOrDefaultAsync(c => c.Id == id);
        employeeUpdate!.Name = employee.Name;
        employeeUpdate.Password = employee.Password;
        await _dataContext.SaveChangesAsync();
        return employeeUpdate;
    }

    public async Task<Employee> Destroy(int id)
    {
        var deleteEmployee = await _dataContext.Employees.FirstOrDefaultAsync(c => c.Id == id);
        _dataContext.Employees.Remove(deleteEmployee);
        await _dataContext.SaveChangesAsync();
        return deleteEmployee;
    }
    
    // Function verify user in database
    public async Task<Employee?> ShowEmployee(string name, string password)
    {
        var existingEmployee = await _dataContext.Employees
            .FirstOrDefaultAsync(e => e.Name == name && e.Password == password);

        return existingEmployee;
    }
}