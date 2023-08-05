using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TestTiendaApi.Models;

public partial class DbtesttiendaContext : DbContext
{
    public DbtesttiendaContext()
    {
    }

    public DbtesttiendaContext(DbContextOptions<DbtesttiendaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Articulo> Articulos { get; set; }

    public virtual DbSet<ArticuloTiendum> ArticuloTienda { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<ClienteArticulo> ClienteArticulos { get; set; }

    public virtual DbSet<Tienda> Tiendas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
               .AddJsonFile("appsettings.json")
               .Build();
        var connectString = configuration["ConnectionStrings:TestTiendaConnection"];
        optionsBuilder.UseSqlServer(connectString);

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Articulo>(entity =>
        {
            entity.Property(e => e.Codigo)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Imagen)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Precio)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<ArticuloTiendum>(entity =>
        {
            entity.HasIndex(e => new { e.IdTienda, e.IdArticulo }, "Index_ArticuloTienda_1").IsUnique();

            entity.Property(e => e.Fecha)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdArticuloNavigation).WithMany(p => p.ArticuloTienda)
                .HasForeignKey(d => d.IdArticulo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ArticuloTienda_Articulo");

            entity.HasOne(d => d.IdTiendaNavigation).WithMany(p => p.ArticuloTienda)
                .HasForeignKey(d => d.IdTienda)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ArticuloTienda_Tienda");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_NewTable");

            entity.Property(e => e.Apellidos)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ClienteArticulo>(entity =>
        {
            entity.HasKey(e => new { e.IdCliente, e.IdArticulo });

            entity.ToTable("ClienteArticulo");
            entity.Property(e => e.Fecha)
               .HasMaxLength(15)
               .IsUnicode(false);
            entity.HasOne(d => d.IdArticuloNavigation).WithMany(p => p.ClienteArticulos)
                .HasForeignKey(d => d.IdArticulo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ClienteArticulo_Articulos");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.ClienteArticulos)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ClienteArticulo_Clientes");
        });

        modelBuilder.Entity<Tienda>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Tienda");

            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Sucursal)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
