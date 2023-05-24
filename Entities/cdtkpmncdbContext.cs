using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DoAnTKPMNC.Entities
{
    public partial class cdtkpmncdbContext : IdentityDbContext<ApplicationUser>
    {
        public cdtkpmncdbContext()
        {
        }

        public cdtkpmncdbContext(DbContextOptions<cdtkpmncdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Campaign> Campaigns { get; set; } = null!;
        public virtual DbSet<CampaignGame> CampaignGames { get; set; } = null!;
        public virtual DbSet<CampaignVoucher> CampaignVouchers { get; set; } = null!;
        public virtual DbSet<CpVchCustomer> CpVchCustomers { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Game> Games { get; set; } = null!;
        public virtual DbSet<Partner> Partners { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Store> Stores { get; set; } = null!;
        public virtual DbSet<TypeOfStore> TypeOfStores { get; set; } = null!;
        public virtual DbSet<Voucher> Vouchers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("workstation id=cdtkpmncdb.mssql.somee.com;packet size=4096;user id=venus2410_SQLLogin_1;pwd=uwhc7nel32;data source=cdtkpmncdb.mssql.somee.com;persist security info=False;initial catalog=cdtkpmncdb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.AccountId).ValueGeneratedNever();

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("('False')");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Account_Role");
            });

            modelBuilder.Entity<Campaign>(entity =>
            {
                entity.ToTable("Campaign");

                entity.Property(e => e.CampaignId).ValueGeneratedNever();

                entity.Property(e => e.CpDescrip)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("('False')");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Partner)
                    .WithMany(p => p.Campaigns)
                    .HasForeignKey(d => d.PartnerId)
                    .HasConstraintName("FK_Campaign_Partner");
            });

            modelBuilder.Entity<CampaignGame>(entity =>
            {
                entity.ToTable("CampaignGame");

                entity.Property(e => e.CampaignGameId).ValueGeneratedNever();

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("('False')");

                entity.HasOne(d => d.CampaignGameNavigation)
                    .WithOne(p => p.CampaignGame)
                    .HasForeignKey<CampaignGame>(d => d.CampaignGameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CampaignGame_Campaign");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.CampaignGames)
                    .HasForeignKey(d => d.GameId)
                    .HasConstraintName("FK_CampaignGame_Game");
            });

            modelBuilder.Entity<CampaignVoucher>(entity =>
            {
                entity.ToTable("CampaignVoucher");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ExpiredDate).HasColumnType("date");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("('False')");

                entity.HasOne(d => d.Campaign)
                    .WithMany(p => p.CampaignVouchers)
                    .HasForeignKey(d => d.CampaignId)
                    .HasConstraintName("FK_CampaignVoucher_Campaign");

                entity.HasOne(d => d.Voucher)
                    .WithMany(p => p.CampaignVouchers)
                    .HasForeignKey(d => d.VoucherId)
                    .HasConstraintName("FK_CampaignVoucher_Voucher");
            });

            modelBuilder.Entity<CpVchCustomer>(entity =>
            {
                entity.ToTable("CpVchCustomer");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("('False')");

                entity.Property(e => e.PaticipantDate).HasColumnType("date");

                entity.HasOne(d => d.CpVch)
                    .WithMany(p => p.CpVchCustomers)
                    .HasForeignKey(d => d.CpVchId)
                    .HasConstraintName("FK_CpVchCustomer_CampaignVoucher");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CpVchCustomers)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_CpVchCustomer_Customer");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.CustomerId).ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("('False')");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer_Account");
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.ToTable("Game");

                entity.Property(e => e.GameId).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Partner>(entity =>
            {
                entity.ToTable("Partner");

                entity.Property(e => e.PartnerId).ValueGeneratedNever();

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("('False')");

                entity.Property(e => e.PartnerName).HasMaxLength(100);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Partners)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Partner_Partner");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleId).ValueGeneratedNever();

                entity.Property(e => e.RoleName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("Store");

                entity.Property(e => e.StoreId).ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(255);

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("('False')");

                entity.Property(e => e.Lat).HasColumnType("decimal(18, 12)");

                entity.Property(e => e.Long).HasColumnType("decimal(18, 12)");

                entity.Property(e => e.StoredName).HasMaxLength(100);

                entity.HasOne(d => d.Partner)
                    .WithMany(p => p.Stores)
                    .HasForeignKey(d => d.PartnerId)
                    .HasConstraintName("FK_Store_Partner");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Stores)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK_Store_TypeOfStore");
            });

            modelBuilder.Entity<TypeOfStore>(entity =>
            {
                entity.HasKey(e => e.TypeId);

                entity.ToTable("TypeOfStore");

                entity.Property(e => e.TypeId).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Voucher>(entity =>
            {
                entity.ToTable("Voucher");

                entity.Property(e => e.VoucherId).ValueGeneratedNever();

                entity.Property(e => e.ImgUrl)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("imgURL");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("('False')");

                entity.Property(e => e.Vnd).HasColumnName("VND");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Vouchers)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK_Voucher_Store");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
