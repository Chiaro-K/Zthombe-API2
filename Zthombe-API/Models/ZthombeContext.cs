using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Zthombe_API.Models;

public partial class ZthombeContext : DbContext
{
    public ZthombeContext()
    {
    }

    public ZthombeContext(DbContextOptions<ZthombeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=Zthombe;Trusted_Connection=True;Integrated Security=SSPI;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.PostId);

            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.ImageUrl).HasMaxLength(2000);
            entity.Property(e => e.ImageThumbnaileUrl).HasMaxLength(2000);
            entity.Property(e => e.Title).HasMaxLength(150);
            entity.Property(e => e.ViewCount).HasDefaultValue(0);

            entity.HasOne(e => e.User).WithMany().HasForeignKey(f => f.UserId);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.Property(e => e.UserId);
            entity.Property(e => e.Username).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.FirebaseUserId).HasMaxLength(100);

            entity.HasMany(e => e.Posts).WithOne(p => p.User);
        });

            entity.HasNoKey();
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
