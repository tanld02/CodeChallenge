﻿using CodeChallenge.App.Core.Interfaces;
using CodeChallenge.App.Core.Dto;
using Microsoft.EntityFrameworkCore;
using CodeChallenge.App.Core.Entities;

namespace CodeChallenge.App.Infrastructure;

public partial class CodeChallengeContext : DbContext, IDbContext
{
    public CodeChallengeContext(DbContextOptions<CodeChallengeContext> options) : base(options)
    {
    }

    public DbSet<T> GetSet<T>() where T : class
    {
        return this.Set<T>();
    }

    public async Task SaveAsync()
    {
        try { await this.SaveChangesAsync(); }
        catch { throw; }
    }

    public void SetAsNoTracking()
    {
        this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    public virtual DbSet<Director> Directors { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("integrated security=False;encrypt=True;connection timeout=30;data source=(localdb)\\MSSQLLocalDB;Initial Catalog=CodeChallenge;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Director>(entity =>
        {
            entity.HasKey(e => e.Uuid);

            entity.ToTable("Director");

            entity.Property(e => e.Uuid)
                .ValueGeneratedNever()
                .HasColumnName("uuid");
            entity.Property(e => e.Birthdate)
                .HasColumnType("datetime")
                .HasColumnName("birthdate");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("name");

            //entity.HasOne(d => d.Movie).WithOne(s => s.Uu)
            //    .HasForeignKey<Movie>(ad => ad.Uuid)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_Director_Movie");
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.Uuid);

            entity.ToTable("Movie");

            entity.Property(e => e.Uuid)
                .ValueGeneratedNever()
                .HasColumnName("uuid");
            entity.Property(e => e.DirectorUuid).HasColumnName("director_uuid");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.ReleaseDate)
                .HasColumnType("datetime")
                .HasColumnName("release_date");
            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("title");

            entity.HasOne(d => d.Uu).WithOne(s => s.Movie)
                .HasForeignKey<Movie>(ad => ad.DirectorUuid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Movie_Director");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
