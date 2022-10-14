using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace E_Library.DataModels.entities
{
    public partial class E_LibraryManagementContext : DbContext
    {
        public E_LibraryManagementContext()
        {
        }

        public E_LibraryManagementContext(DbContextOptions<E_LibraryManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BookDetail> BookDetails { get; set; } = null!;
        public virtual DbSet<CheckRole> CheckRoles { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserRequest> UserRequests { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=E_LibraryManagement;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookDetail>(entity =>
            {
                entity.HasKey(e => e.BookId)
                    .HasName("PK__BookDeta__3DE0C20717F250D3");

                entity.Property(e => e.BookId).ValueGeneratedNever();

                entity.Property(e => e.AuthorName)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.BookName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.ImageUrl).IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.BookDetails)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__BookDetai__UserI__403A8C7D");
            });

            modelBuilder.Entity<CheckRole>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__CheckRol__8AFACE1A0F645252");

                entity.ToTable("CheckRole");

                entity.Property(e => e.RoleId).ValueGeneratedNever();

                entity.Property(e => e.Role).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email, "UQ__Users__A9D10534607F9038")
                    .IsUnique();

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("gender");

                entity.Property(e => e.MobileNo).HasColumnName("MobileNO");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("password");
            });

            modelBuilder.Entity<UserRequest>(entity =>
            {
                entity.HasKey(e => e.RequestId)
                    .HasName("PK__UserRequ__33A8517A47CD2F98");

                entity.Property(e => e.RequestId).ValueGeneratedNever();

                entity.Property(e => e.Date).HasColumnType("date");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.UserRequests)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("FK__UserReque__BookI__60A75C0F");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRequests)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__UserReque__UserI__5FB337D6");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
