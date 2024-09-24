using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions dbcontextOptions)
        : base(dbcontextOptions)
        {

        }
        public DbSet<Menu> menus {get; set;}
        public DbSet<News> news {get; set;}
    }
}