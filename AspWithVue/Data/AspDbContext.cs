using AspWithVue.Model;
using Microsoft.EntityFrameworkCore;

namespace AspWithVue.Data;

public class AspDbContext : DbContext
{
    public AspDbContext(DbContextOptions<AspDbContext> options) : base(options)
    {
        
    }

    public DbSet<Contact> Contacts { get; set; }
    
    public DbSet<Department> Departments { get; set; }
    
    public DbSet<Employee> Employees { get; set; }
    
}