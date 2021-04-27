using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebApplication1.Models
{
    public class AppDataContext : IdentityDbContext<AppUser>
    {
        public AppDataContext(DbContextOptions<AppDataContext> options) :
        base(options)
        { }
        public DbSet<Product> Product { get; set; }

        public DbSet<Cart> Cart { get; set; }
    }
    }
