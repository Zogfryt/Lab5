using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using lab5.Entities;

namespace lab5.Context
{
    public partial class CukierniaContext : DbContext
    {
        public CukierniaContext()
        {
        }

        public CukierniaContext(DbContextOptions<CukierniaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<artykuly> artykulies { get; set; } = null!;
        public virtual DbSet<czekoladki> czekoladkis { get; set; } = null!;
        public virtual DbSet<klienci> kliencis { get; set; } = null!;
        public virtual DbSet<pudelka> pudelkas { get; set; } = null!;
        public virtual DbSet<zamowienium> zamowienia { get; set; } = null!;
        public virtual DbSet<zawartosc> zawartoscs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Database=MyDatabase;Username=postgres;Password=super2012");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<artykuly>(entity =>
            {
                entity.HasKey(e => new { e.idzamowienia, e.idpudelka })
                    .HasName("artykuly_pkey");

                entity.Property(e => e.idpudelka).IsFixedLength();

                entity.HasOne(d => d.idpudelkaNavigation)
                    .WithMany(p => p.artykulies)
                    .HasForeignKey(d => d.idpudelka)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("artykuly_idpudelka_fkey");

                entity.HasOne(d => d.idzamowieniaNavigation)
                    .WithMany(p => p.artykulies)
                    .HasForeignKey(d => d.idzamowienia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("artykuly_idzamowienia_fkey");
            });

            modelBuilder.Entity<czekoladki>(entity =>
            {
                entity.HasKey(e => e.idczekoladki)
                    .HasName("czekoladki_pkey");

                entity.Property(e => e.idczekoladki).IsFixedLength();
            });

            modelBuilder.Entity<klienci>(entity =>
            {
                entity.HasKey(e => e.idklienta)
                    .HasName("klienci_pkey");

                entity.Property(e => e.idklienta).ValueGeneratedNever();

                entity.Property(e => e.kod).IsFixedLength();
            });

            modelBuilder.Entity<pudelka>(entity =>
            {
                entity.HasKey(e => e.idpudelka)
                    .HasName("pudelka_pkey");

                entity.Property(e => e.idpudelka).IsFixedLength();
            });

            modelBuilder.Entity<zamowienium>(entity =>
            {
                entity.HasKey(e => e.idzamowienia)
                    .HasName("zamowienia_pkey");

                entity.Property(e => e.idzamowienia).ValueGeneratedNever();

                entity.HasOne(d => d.idklientaNavigation)
                    .WithMany(p => p.zamowienia)
                    .HasForeignKey(d => d.idklienta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("zamowienia_idklienta_fkey");
            });

            modelBuilder.Entity<zawartosc>(entity =>
            {
                entity.HasKey(e => new { e.idpudelka, e.idczekoladki })
                    .HasName("zawartosc_pkey");

                entity.Property(e => e.idpudelka).IsFixedLength();

                entity.Property(e => e.idczekoladki).IsFixedLength();

                entity.HasOne(d => d.idczekoladkiNavigation)
                    .WithMany(p => p.zawartoscs)
                    .HasForeignKey(d => d.idczekoladki)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("zawartosc_idczekoladki_fkey");

                entity.HasOne(d => d.idpudelkaNavigation)
                    .WithMany(p => p.zawartoscs)
                    .HasForeignKey(d => d.idpudelka)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("zawartosc_idpudelka_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
