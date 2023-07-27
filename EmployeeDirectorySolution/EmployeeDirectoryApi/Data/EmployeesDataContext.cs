using Microsoft.EntityFrameworkCore;

namespace EmployeeDirectoryApi.Data;

public class EmployeesDataContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }

    public EmployeesDataContext(DbContextOptions<EmployeesDataContext> options): base(options)
    {

    }
}
