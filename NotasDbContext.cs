using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace M12_NotasEf
{
    public class NotasDbContext : DbContext
    {
        public DbSet<Estudiante> Estudiantes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=notas.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estudiante>(e =>
            {
                e.Property(x => x.Nombre).HasMaxLength(58).IsRequired();
                e.Property(x => x.Ciudad).HasMaxLength(30);
            }

            );
        }
    }
}