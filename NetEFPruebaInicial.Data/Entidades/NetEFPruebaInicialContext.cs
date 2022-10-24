using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NetEFPruebaInicial.Data.Entidades
{
    public partial class NetEFPruebaInicialContext : DbContext
    {
        public NetEFPruebaInicialContext()
        {
        }

        public NetEFPruebaInicialContext(DbContextOptions<NetEFPruebaInicialContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Especie> Especies { get; set; } = null!;
        public virtual DbSet<Tipoespecie> Tipoespecies { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=NetEFPruebaInicial;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Especie>(entity =>
            {
                entity.HasKey(e => e.IdEspecie);

                entity.ToTable("ESPECIE");

                entity.Property(e => e.Nombre).HasMaxLength(10);

                entity.Property(e => e.PesoPromedio).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.IdTipoEspecieNavigation)
                    .WithMany(p => p.Especies)
                    .HasForeignKey(d => d.IdTipoEspecie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ESPECIE_TIPOESPECIE");
            });

            modelBuilder.Entity<Tipoespecie>(entity =>
            {
                entity.HasKey(e => e.IdTipoEspecie);

                entity.ToTable("TIPOESPECIE");

                entity.Property(e => e.IdTipoEspecie).ValueGeneratedNever();

                entity.Property(e => e.Nombre).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
