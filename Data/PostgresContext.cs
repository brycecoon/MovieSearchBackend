using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MovieSearchBackend.Data;

public partial class PostgresContext : DbContext
{
    public PostgresContext()
    {
    }

    public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<List> Lists { get; set; }

    public virtual DbSet<ListMovie> ListMovies { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresEnum("practicum2425", "status", new[] { "ACTIVE", "ARCHIVED", "COMPLETED" });

        modelBuilder.Entity<List>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("list_pkey");

            entity.ToTable("list", "MovieSearch");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .HasColumnName("name");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.User).WithMany(p => p.Lists)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("list_userId_fkey");
        });

        modelBuilder.Entity<ListMovie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("list_movie_pkey");

            entity.ToTable("list_movie", "MovieSearch");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ListId).HasColumnName("listId");
            entity.Property(e => e.MovieId).HasColumnName("movieId");

            entity.HasOne(d => d.List).WithMany(p => p.ListMovies)
                .HasForeignKey(d => d.ListId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("list_movie_listId_fkey");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("role_pkey");

            entity.ToTable("role", "MovieSearch");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_pkey");

            entity.ToTable("user", "MovieSearch");

            entity.Property(e => e.Id)
            .ValueGeneratedOnAdd()
            .HasColumnName("id");
            entity.Property(e => e.Biography)
                .HasMaxLength(200)
                .HasColumnName("biography");
            entity.Property(e => e.Email)
                .HasMaxLength(25)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .HasColumnName("name");
            entity.Property(e => e.RoleId).HasColumnName("roleId");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("user_roleId_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
