using EntityFrameworkMasterclass.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkMasterclass.Context
{
    public class EfContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-5Q1ARH5E;initial catalog=EfMasterclass;integrated security=true; trust server certificate=true;");
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Todo> Todos { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
