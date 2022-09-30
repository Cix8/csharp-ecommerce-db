// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;

public class E_commerce : DbContext
{
    private string connString = "Data Source=localhost;Initial Catalog = e_commerce_db; Integrated Security = True";
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(this.connString);
    }
}