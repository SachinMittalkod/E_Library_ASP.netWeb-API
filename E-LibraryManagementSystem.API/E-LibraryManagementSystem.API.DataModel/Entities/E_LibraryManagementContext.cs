using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace E_LibraryManagementSystem.API.DataModel.Entities
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
        public virtual DbSet<IssuedBook> IssuedBooks { get; set; } = null!;
        public virtual DbSet<RequestedBook> RequestedBooks { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

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
                    .HasName("PK__BookDeta__3DE0C2075A314EDA");

                entity.ToTable("BookDetail");

                entity.Property(e => e.AuthorName)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.BookName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.ImageUrl).IsUnicode(false);
            });

            modelBuilder.Entity<CheckRole>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__CheckRol__8AFACE1A0F645252");

                entity.ToTable("CheckRole");

                entity.Property(e => e.RoleId).ValueGeneratedNever();

                entity.Property(e => e.Role).HasMaxLength(50);
            });

            modelBuilder.Entity<IssuedBook>(entity =>
            {
                entity.HasKey(e => e.IssueId)
                    .HasName("PK__IssuedBo__6C861604532B6E62");

                entity.ToTable("IssuedBook");

                entity.Property(e => e.IssueDate).HasColumnType("date");

                entity.Property(e => e.ReturnDate).HasColumnType("date");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.IssuedBooks)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("FK__IssuedBoo__BookI__2A164134");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.IssuedBooks)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__IssuedBoo__UserI__29221CFB");
            });

            modelBuilder.Entity<RequestedBook>(entity =>
            {
                entity.HasKey(e => e.RequestId);

                entity.ToTable("RequestedBook");

                entity.Property(e => e.RequestDate).HasColumnType("date");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.RequestedBooks)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("FK__Requested__BookI__2DE6D218");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.RequestedBooks)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Requested__UserI__2EDAF651");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email, "UQ__Users__A9D10534607F9038")
                    .IsUnique();

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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
