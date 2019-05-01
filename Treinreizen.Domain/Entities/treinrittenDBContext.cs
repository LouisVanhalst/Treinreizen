using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Treinreizen.Domain.Entities
{
    public partial class treinrittenDBContext : DbContext
    {
        public treinrittenDBContext()
        {
        }

        public treinrittenDBContext(DbContextOptions<treinrittenDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<Hotels> Hotels { get; set; }
        public virtual DbSet<Klanten> Klanten { get; set; }
        public virtual DbSet<Klasse> Klasse { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<ReisMogelijkheden> ReisMogelijkheden { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Steden> Steden { get; set; }
        public virtual DbSet<Ticket> Ticket { get; set; }
        public virtual DbSet<Treinen> Treinen { get; set; }
        public virtual DbSet<TreinenVanOrder> TreinenVanOrder { get; set; }
        public virtual DbSet<TreinRoutes> TreinRoutes { get; set; }
        public virtual DbSet<Zitplaats> Zitplaats { get; set; }

        // Unable to generate entity type for table 'dbo.Vakanties'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQL_VIVES3; Database=treinrittenDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Hotels>(entity =>
            {
                entity.HasKey(e => e.HotelId);

                entity.HasIndex(e => e.HotelId)
                    .HasName("Hotels_HotelId")
                    .IsUnique();

                entity.Property(e => e.Beschrijving)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Foto)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Naam)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Site)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Stad)
                    .WithMany(p => p.Hotels)
                    .HasForeignKey(d => d.StadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("bevindt zich in");
            });

            modelBuilder.Entity<Klanten>(entity =>
            {
                entity.HasKey(e => e.KlantId);

                entity.HasIndex(e => e.KlantId)
                    .HasName("Klanten_KlantId")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Geboortedatum).HasColumnType("date");

                entity.Property(e => e.Land)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Naam)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Paswoord)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Straat)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Voornaam)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Klasse>(entity =>
            {
                entity.Property(e => e.Klassenaam)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasIndex(e => e.OrderId)
                    .HasName("Order_OrderId")
                    .IsUnique();

                entity.Property(e => e.Boekingsdatum).HasColumnType("date");

                entity.Property(e => e.Class)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Prijs).HasColumnType("decimal(19, 0)");

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.HotelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("verblijft in");

                entity.HasOne(d => d.Klant)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.KlantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Heeft geboekt");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKOrder512612");
            });

            modelBuilder.Entity<ReisMogelijkheden>(entity =>
            {
                entity.HasIndex(e => e.ReisMogelijkhedenId)
                    .HasName("ReisMogelijkheden_ReisMogelijkhedenId")
                    .IsUnique();

                entity.HasOne(d => d.AankomstNavigation)
                    .WithMany(p => p.ReisMogelijkhedenAankomstNavigation)
                    .HasForeignKey(d => d.Aankomst)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Heeft als bestemming");

                entity.HasOne(d => d.VertrekNavigation)
                    .WithMany(p => p.ReisMogelijkhedenVertrekNavigation)
                    .HasForeignKey(d => d.Vertrek)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Vertrekt vanuit");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.HasIndex(e => e.StatusId)
                    .HasName("Status_StatusId")
                    .IsUnique();

                entity.Property(e => e.Naam)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Steden>(entity =>
            {
                entity.HasKey(e => e.StadId);

                entity.HasIndex(e => e.StadId)
                    .HasName("Steden_StadId")
                    .IsUnique();

                entity.Property(e => e.Naam)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasIndex(e => e.TicketId)
                    .HasName("Ticket_TicketId")
                    .IsUnique();

                entity.Property(e => e.AchternaamPassagier)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.VoornaamPassagier)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Trip)
                    .WithMany(p => p.Ticket)
                    .HasForeignKey(d => d.TripId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKTicket272428");

                entity.HasOne(d => d.Zitplaats)
                    .WithMany(p => p.Ticket)
                    .HasForeignKey(d => new { d.TreinNummer, d.Zetelnummer })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKTicket314765");
            });

            modelBuilder.Entity<Treinen>(entity =>
            {
                entity.HasKey(e => e.TreinNummer);

                entity.HasIndex(e => e.TreinNummer)
                    .HasName("Treinen_TreinNummer")
                    .IsUnique();

                entity.Property(e => e.TreinNaam)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TreinenVanOrder>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.RouteId });

                entity.HasIndex(e => e.OrderId)
                    .HasName("TreinenVanOrder_OrderId");

                entity.HasIndex(e => e.RouteId)
                    .HasName("TreinenVanOrder_RouteId");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.TreinenVanOrder)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("heeft treinen van");

                entity.HasOne(d => d.Route)
                    .WithMany(p => p.TreinenVanOrder)
                    .HasForeignKey(d => d.RouteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("zit in trip van");
            });

            modelBuilder.Entity<TreinRoutes>(entity =>
            {
                entity.HasKey(e => e.RouteId);

                entity.HasIndex(e => e.RouteId)
                    .HasName("TreinRoutes_RouteId")
                    .IsUnique();

                entity.Property(e => e.Vertrekdatum).HasColumnType("date");

                entity.HasOne(d => d.ReisMogelijkheden)
                    .WithMany(p => p.TreinRoutes)
                    .HasForeignKey(d => d.ReisMogelijkhedenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Heeft als route");

                entity.HasOne(d => d.TreinNummerNavigation)
                    .WithMany(p => p.TreinRoutes)
                    .HasForeignKey(d => d.TreinNummer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKTreinRoute536929");
            });

            modelBuilder.Entity<Zitplaats>(entity =>
            {
                entity.HasKey(e => new { e.TreinNummer, e.Zetelnummer });

                entity.HasOne(d => d.Klasse)
                    .WithMany(p => p.Zitplaats)
                    .HasForeignKey(d => d.KlasseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKZitplaats926147");

                entity.HasOne(d => d.TreinNummerNavigation)
                    .WithMany(p => p.Zitplaats)
                    .HasForeignKey(d => d.TreinNummer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKZitplaats963178");
            });

            modelBuilder.HasSequence("Seq_Hotels");

            modelBuilder.HasSequence("Seq_klanten");

            modelBuilder.HasSequence("Seq_Order");

            modelBuilder.HasSequence("Seq_ReisMogelijkheden");

            modelBuilder.HasSequence("Seq_Status");

            modelBuilder.HasSequence("Seq_Steden");

            modelBuilder.HasSequence("Seq_Ticket");

            modelBuilder.HasSequence("Seq_Treinen");

            modelBuilder.HasSequence("Seq_TreinenVanOrder");

            modelBuilder.HasSequence("Seq_TreinRoutes");

            modelBuilder.HasSequence("Seq_Trip");

            modelBuilder.HasSequence("Seq_Vakanties");

            modelBuilder.HasSequence("Seq_Zitplaats");
        }
    }
}
