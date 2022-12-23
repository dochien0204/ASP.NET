using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace De02.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Shop2DB")
        {
        }

        public virtual DbSet<account> accounts { get; set; }
        public virtual DbSet<category> categories { get; set; }
        public virtual DbSet<product> products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<category>()
                .HasMany(e => e.products)
                .WithRequired(e => e.category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<product>()
                .Property(e => e.price)
                .HasPrecision(10, 2);

            modelBuilder.Entity<product>()
                .Property(e => e.stock)
                .HasPrecision(10, 2);
        }
    }
}
