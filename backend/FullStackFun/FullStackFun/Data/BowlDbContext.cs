using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FullStackFun.Data;

public partial class BowlingLeagueContext : DbContext
{
    public BowlingLeagueContext()
    {
    }

    public BowlingLeagueContext(DbContextOptions<BowlingLeagueContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bowler> Bowlers { get; set; }

    public virtual DbSet<Team> Teams { get; set; }
    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=BowlingLeague.sqlite");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bowler>(entity =>
        {
            entity.HasIndex(e => e.BowlerLastName, "BowlerLastName");

            entity.HasIndex(e => e.TeamId, "BowlersTeamID");

            entity.Property(e => e.BowlerId)
                .HasColumnType("INT")
                .HasColumnName("BowlerID");
            entity.Property(e => e.BowlerAddress).HasColumnType("nvarchar (50)");
            entity.Property(e => e.BowlerCity).HasColumnType("nvarchar (50)");
            entity.Property(e => e.BowlerFirstName).HasColumnType("nvarchar (50)");
            entity.Property(e => e.BowlerLastName).HasColumnType("nvarchar (50)");
            entity.Property(e => e.BowlerMiddleInit).HasColumnType("nvarchar (1)");
            entity.Property(e => e.BowlerPhoneNumber).HasColumnType("nvarchar (14)");
            entity.Property(e => e.BowlerState).HasColumnType("nvarchar (2)");
            entity.Property(e => e.BowlerZip).HasColumnType("nvarchar (10)");
            entity.Property(e => e.TeamId)
                .HasColumnType("INT")
                .HasColumnName("TeamID");

            entity.HasOne(d => d.Team).WithMany(p => p.Bowlers).HasForeignKey(d => d.TeamId);
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasIndex(e => e.TeamId, "TeamID").IsUnique();

            entity.Property(e => e.TeamId)
                .HasColumnType("INT")
                .HasColumnName("TeamID");
            entity.Property(e => e.CaptainId)
                .HasColumnType("INT")
                .HasColumnName("CaptainID");
            entity.Property(e => e.TeamName).HasColumnType("nvarchar (50)");
        });
        
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
