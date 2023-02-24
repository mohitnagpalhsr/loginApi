using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Models;

public partial class SportsEventManagementContext : DbContext
{
    public SportsEventManagementContext()
    {
    }

    public SportsEventManagementContext(DbContextOptions<SportsEventManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<LoginModel> LoginModels { get; set; }

    public virtual DbSet<Participation> Participations { get; set; }

    public virtual DbSet<Player> Players { get; set; }

    public virtual DbSet<Sport> Sports { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\sqlexpress;Database=SportsEventManagement;TrustServerCertificate=Yes;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("PK__Event__2DC7BD092B858452");

            entity.ToTable("Event");

            entity.Property(e => e.EventId).HasColumnName("eventId");
            entity.Property(e => e.EventDate)
                .HasColumnType("date")
                .HasColumnName("eventDate");
            entity.Property(e => e.EventName)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("eventName");
            entity.Property(e => e.NoofSlots).HasColumnName("noofSlots");
            entity.Property(e => e.SportsName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("sportsName");
            entity.Property(e => e.Status)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasDefaultValueSql("('scheduled')")
                .HasColumnName("status");
        });

        modelBuilder.Entity<LoginModel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LoginMod__3214EC07904A0096");

            entity.ToTable("LoginModel");

            entity.HasIndex(e => e.Username, "UQ__LoginMod__536C85E4E3BD4DC5").IsUnique();

            entity.Property(e => e.Role)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValueSql("('user')");
            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Participation>(entity =>
        {
            entity.HasKey(e => e.ParticipationId).HasName("PK__Particip__78B6F5059F46D61A");

            entity.ToTable("Participation");

            entity.Property(e => e.ParticipationId).HasColumnName("participationId");
            entity.Property(e => e.Comments)
                .IsUnicode(false)
                .HasColumnName("comments");
            entity.Property(e => e.EventId).HasColumnName("eventId");
            entity.Property(e => e.EventName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("eventName");
            entity.Property(e => e.PlayerId).HasColumnName("playerId");
            entity.Property(e => e.PlayerName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("playerName");
            entity.Property(e => e.SportsId).HasColumnName("sportsId");
            entity.Property(e => e.SportsName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("sportsName");
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValueSql("('pending')")
                .HasColumnName("status");

            entity.HasOne(d => d.Event).WithMany(p => p.Participations)
                .HasForeignKey(d => d.EventId)
                .HasConstraintName("FK__Participa__event__44FF419A");

            entity.HasOne(d => d.Player).WithMany(p => p.Participations)
                .HasForeignKey(d => d.PlayerId)
                .HasConstraintName("FK__Participa__playe__440B1D61");

            entity.HasOne(d => d.Sports).WithMany(p => p.Participations)
                .HasForeignKey(d => d.SportsId)
                .HasConstraintName("FK__Participa__sport__45F365D3");
        });

        modelBuilder.Entity<Player>(entity =>
        {
            entity.HasKey(e => e.PlayerId).HasName("PK__Player__2CDA01F1EA3CF11C");

            entity.ToTable("Player");

            entity.Property(e => e.PlayerId).HasColumnName("playerId");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.ContactNumber)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("contactNumber");
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Gender)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("gender");
            entity.Property(e => e.PlayerName)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("playerName");
            entity.Property(e => e.SportsName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("sportsName");
            entity.Property(e => e.Status)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasDefaultValueSql("('inactive')")
                .HasColumnName("status");
        });

        modelBuilder.Entity<Sport>(entity =>
        {
            entity.HasKey(e => e.SportsId).HasName("PK__Sport__1F4D71B6AC2CC16D");

            entity.ToTable("Sport");

            entity.HasIndex(e => e.SportsName, "UQ__Sport__DB7106D799E1AF15").IsUnique();

            entity.Property(e => e.SportsId).HasColumnName("sportsId");
            entity.Property(e => e.NoOfPlayers).HasColumnName("noOfPlayers");
            entity.Property(e => e.SportsName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("sportsName");
            entity.Property(e => e.SportsType)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("sportsType");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
