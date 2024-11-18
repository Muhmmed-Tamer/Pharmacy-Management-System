using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pharmacy_Management_System.Models;

namespace Pharmacy_Management_System.Data
{
    public class PharamyContext:IdentityDbContext<User, IdentityRole, string>
    {
        public PharamyContext() : base(){ }
        public PharamyContext(DbContextOptions<PharamyContext> options) : base(options) { }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Order> Orders { get; set; }
        public  DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public override DbSet<IdentityRole> Roles { get => base.Roles; set => base.Roles = value; }

    }
}
