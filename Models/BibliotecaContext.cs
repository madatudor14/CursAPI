using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using LibraryProject.Models;

namespace LibraryProject.Models;

public partial class BibliotecaContext : DbContext
{
    public BibliotecaContext()
    {
    }

    public BibliotecaContext(DbContextOptions<BibliotecaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Autori> Autori { get; set; }

    public virtual DbSet<Carti> Carti { get; set; }

    public virtual DbSet<Categorii> Categorii { get; set; }

    public virtual DbSet<Imprumuturi> Imprumuturi { get; set; }

    public virtual DbSet<Utilizatori> Utilizatori { get; set; }

    public virtual DbSet<ContactMessages> ContactMessages { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=Biblioteca;Trusted_Connection=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Autori>(entity =>
        {
            entity.HasKey(e => e.IdAutor).HasName("PK__Autori__DD33B0319A7AE7C5");

            entity.ToTable("Autori");

            entity.Property(e => e.NumeAutor).HasMaxLength(100);
            entity.Property(e => e.PrenumeAutor).HasMaxLength(100);
        });

        modelBuilder.Entity<Carti>(entity =>
        {
            entity.HasKey(e => e.IdCarte).HasName("PK__Carti__6C9FD03394E0EB77");

            entity.ToTable("Carti");

            entity.Property(e => e.StocDisponibil).HasDefaultValue(0);
            entity.Property(e => e.Titlu).HasMaxLength(200);

            entity.HasOne(d => d.IdAutorNavigation).WithMany(p => p.Cartis)
                .HasForeignKey(d => d.IdAutor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Carti_Autori");

            entity.HasOne(d => d.IdCategorieNavigation).WithMany(p => p.Cartis)
                .HasForeignKey(d => d.IdCategorie)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Carti_Categorii");
        });

        modelBuilder.Entity<Categorii>(entity =>
        {
            entity.HasKey(e => e.IdCategorie).HasName("PK__Categori__A3C02A1CDC9EBE3F");

            entity.ToTable("Categorii");

            entity.Property(e => e.NumeCategorie).HasMaxLength(100);
        });

        modelBuilder.Entity<Imprumuturi>(entity =>
        {
            entity.HasKey(e => e.IdImprumut).HasName("PK__Imprumut__E7A328E731E495B1");

            entity.ToTable("Imprumuturi");

            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValue("Imprumutat");

            entity.HasOne(d => d.IdCarteNavigation).WithMany(p => p.Imprumuturis)
                .HasForeignKey(d => d.IdCarte)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Imprumuturi_Carti");

            entity.HasOne(d => d.IdUtilizatorNavigation).WithMany(p => p.Imprumuturis)
                .HasForeignKey(d => d.IdUtilizator)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Imprumuturi_Utilizatori");
        });

        modelBuilder.Entity<Utilizatori>(entity =>
        {
            entity.HasKey(e => e.IdUtilizator).HasName("PK__Utilizat__99101D6D1915A876");

            entity.ToTable("Utilizatori");

            entity.HasIndex(e => e.Email, "UQ__Utilizat__A9D1053479668F63").IsUnique();

            entity.Property(e => e.DataInregistrare).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Email).HasMaxLength(200);
            entity.Property(e => e.NumeUtilizator).HasMaxLength(100);
            entity.Property(e => e.PrenumeUtilizator).HasMaxLength(100);
            entity.Property(e => e.Telefon).HasMaxLength(15);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

public DbSet<LibraryProject.Models.Users> Users { get; set; } = default!;
}
