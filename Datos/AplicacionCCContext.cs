using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Datos
{
    public partial class AplicacionCCContext : DbContext
    {
        public AplicacionCCContext()
        {
        }

        public AplicacionCCContext(DbContextOptions<AplicacionCCContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoria> Categorias { get; set; } = null!;
        public virtual DbSet<ShopingCenter> ShopingCenters { get; set; } = null!;
        public virtual DbSet<ShopingCenterStore> ShopingCenterStores { get; set; } = null!;
        public virtual DbSet<Store> Stores { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=SQL8003.site4now.net;Initial Catalog=db_a8f07a_centroscomerciales;User Id=db_a8f07a_centroscomerciales_admin;Password=Emilio0105");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Modern_Spanish_CI_AS");

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategorias);

                entity.Property(e => e.IdCategorias).ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ShopingCenter>(entity =>
            {
                entity.HasKey(e => e.IdCentroComercial)
                    .HasName("PK_SC");

                entity.ToTable("ShopingCenter");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Imagen)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ShopingCenterStore>(entity =>
            {
                entity.HasKey(e => e.IdTcc)
                    .HasName("PK_TCC");

                entity.Property(e => e.IdTcc).HasColumnName("IdTCC");

                entity.HasOne(d => d.IdCentroComercialNavigation)
                    .WithMany(p => p.ShopingCenterStores)
                    .HasForeignKey(d => d.IdCentroComercial)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TCC_SC");

                entity.HasOne(d => d.IdTiendaNavigation)
                    .WithMany(p => p.ShopingCenterStores)
                    .HasForeignKey(d => d.IdTienda)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShopingCenterStores_Store");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.HasKey(e => e.IdTienda)
                    .HasName("PK_Tiendas");

                entity.ToTable("Store");

                entity.Property(e => e.IdTienda).ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Horario)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Imagen)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.NoLocal)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Username);

                entity.Property(e => e.Username)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Contraseña)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
