using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_VisionTask.Model
{
    public class DataContext : DbContext
    {
      
            public DataContext(DbContextOptions<DataContext> options)
                : base(options)
            {
            }

            public virtual DbSet<Product> Product { get; set; }
            public virtual DbSet<Category> Category { get; set; }
            public virtual DbSet<Cat_Product> Cat_Product { get; set; }

            //protected override void OnModelCreating(ModelBuilder modelBuilder)
            //{
            //    base.OnModelCreating(modelBuilder);

            //}
        }
    }

