using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API.Models
{
    public partial class NewsManagementDBContext : DbContext
    {
        public NewsManagementDBContext()
        {
        }

        public NewsManagementDBContext(DbContextOptions<NewsManagementDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Posts> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=ADMIN\\SQLEXPRESS;Initial Catalog=NewsManagementDB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.idCategory);

                entity.Property(e => e.icon)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.titleCategory)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<Posts>(entity =>
            {
                entity.HasKey(e => e.idPosts);

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.briefDescription).HasMaxLength(500);

                entity.Property(e => e.datePost).HasColumnType("date");

                entity.Property(e => e.image)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.metaDescription).HasMaxLength(500);

                entity.Property(e => e.metaKey).HasMaxLength(500);

                entity.HasOne(d => d.idCategoryNavigation)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.idCategory)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Posts_Category");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
