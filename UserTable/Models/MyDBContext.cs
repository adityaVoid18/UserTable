using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace UserTable.Models
{
    public partial class MyDBContext : DbContext
    {
        public MyDBContext()
        {
        }

        public MyDBContext(DbContextOptions<MyDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bank> Banks { get; set; } = null!;
        public virtual DbSet<Bike> Bikes { get; set; } = null!;
        public virtual DbSet<FlatDetail> FlatDetails { get; set; } = null!;
        public virtual DbSet<ImageB> ImageBs { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserDataTable> UserDataTables { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-RBUJ59QI\\MSSQLSERVER02; Database=MyDB; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bank>(entity =>
            {
                entity.HasKey(e => e.AcNo)
                    .HasName("PK__Bank__7EFC9354C1755DBE");

                entity.ToTable("Bank");

                entity.Property(e => e.AcNo).ValueGeneratedNever();

                entity.Property(e => e.BankName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ImageFileName).HasMaxLength(255);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Bike>(entity =>
            {
                entity.ToTable("Bike");

                entity.Property(e => e.BikeName).HasMaxLength(100);
            });

            modelBuilder.Entity<FlatDetail>(entity =>
            {
                entity.HasKey(e => e.FlatNo)
                    .HasName("PK__FlatDeta__7CD6F60AFA563DC7");

                entity.Property(e => e.FlatNo).ValueGeneratedNever();

                entity.Property(e => e.MobNo)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.OwnerName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ImageB>(entity =>
            {
                entity.ToTable("ImageB");

                entity.Property(e => e.ImageString).IsUnicode(false);

                entity.Property(e => e.ImageUrl).IsUnicode(false);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.SNo)
                    .HasName("PK__Product__A3DD670A0E36217D");

                entity.ToTable("Product");

                entity.Property(e => e.SNo)
                    .ValueGeneratedNever()
                    .HasColumnName("S_No");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.HasIndex(e => e.Username, "UQ__User__536C85E46B4A8D30")
                    .IsUnique();

                entity.Property(e => e.Username).HasMaxLength(255);
            });

            modelBuilder.Entity<UserDataTable>(entity =>
            {
                entity.ToTable("UserDataTable");

                entity.Property(e => e.Password).HasMaxLength(255);

                entity.Property(e => e.Username).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
