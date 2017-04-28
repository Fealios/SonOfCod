using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SonOfCod.Models
{
    public class SonOfCodDbContext : IdentityDbContext<User>
    {
        public DbSet<MenuInfo> MenuInfo { get; set; }
        public DbSet<Mailuser> Mailusers { get; set; }
        public SonOfCodDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=SonOfCod;integrated security=True;");
        }

        public SonOfCodDbContext(DbContextOptions<SonOfCodDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
