using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApi.Data.EntityModels
{
    public partial class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Teste> Teste { get; set; }
        public virtual DbSet<Teste2> Teste2 { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

//         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//         {
//             if (!optionsBuilder.IsConfigured)
//             {
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                 optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=root;database=webapidb");
//             }
//         }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teste>(entity =>
            {
                entity.ToTable("teste");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Endereco)
                    .HasColumnName("endereco")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<Teste2>(entity =>
            {
                entity.ToTable("teste2");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.ToTable("usuarios");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("userName")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasColumnName("userPassword")
                    .HasColumnType("varchar(255)");
            });
        }
    }
}
