using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using Wipster.Refactoring.Domain.Entities;

namespace Wipster.Refactoring.Persistence
{
    // Further abstractions are required here. The direct usage of DB context allows for multiple DB touch points thereby circumventing business logic
    // Consider the repository pattern + UOW. For complex object graphs consider using Views and model the behaviors for CRUD using other methods. Stay away from stored procedures
    // The Persistence Layer must own its models. 
    public class NorthwindDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            /*This belongs in a config file*/
            var dbFileName = "\\..\\..\\database\\Northwind_small.sqlite";
            var dbConnectionString = "Data Source=" + Environment.CurrentDirectory + dbFileName;
            /*Absolutely no magic strings*/
            options.UseSqlite(dbConnectionString);
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<EmployeeTerritory> EmployeeTerritories { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Region> Region { get; set; }

        public DbSet<Shipper> Shippers { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Territory> Territories { get; set; }
    }
}
