﻿// <auto-generated />
using System;
using DoAnTKPMNC.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DoAnTKPMNC.Migrations
{
    [DbContext(typeof(TKPMNCContext))]
    [Migration("20230524025701_AddIdentityAuthentication")]
    partial class AddIdentityAuthentication
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DoAnTKPMNC.Entities.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<bool?>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("('False')");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("AccountId");

                    b.HasIndex("RoleId");

                    b.ToTable("Account", (string)null);
                });

            modelBuilder.Entity("DoAnTKPMNC.Entities.Campaign", b =>
                {
                    b.Property<int>("CampaignId")
                        .HasColumnType("int");

                    b.Property<string>("CpDescrip")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("date");

                    b.Property<bool?>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("('False')");

                    b.Property<int?>("MaxTimePaticipant")
                        .HasColumnType("int");

                    b.Property<int?>("PartnerId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("date");

                    b.HasKey("CampaignId");

                    b.HasIndex("PartnerId");

                    b.ToTable("Campaign", (string)null);
                });

            modelBuilder.Entity("DoAnTKPMNC.Entities.CampaignGame", b =>
                {
                    b.Property<int>("CampaignGameId")
                        .HasColumnType("int");

                    b.Property<int?>("CampaignId")
                        .HasColumnType("int");

                    b.Property<int?>("GameId")
                        .HasColumnType("int");

                    b.Property<bool?>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("('False')");

                    b.HasKey("CampaignGameId");

                    b.HasIndex("GameId");

                    b.ToTable("CampaignGame", (string)null);
                });

            modelBuilder.Entity("DoAnTKPMNC.Entities.CampaignVoucher", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int?>("CampaignId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ExpiredDate")
                        .HasColumnType("date");

                    b.Property<bool?>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("('False')");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("UsedQuantity")
                        .HasColumnType("int");

                    b.Property<int?>("VoucherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CampaignId");

                    b.HasIndex("VoucherId");

                    b.ToTable("CampaignVoucher", (string)null);
                });

            modelBuilder.Entity("DoAnTKPMNC.Entities.CpVchCustomer", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int?>("CpVchId")
                        .HasColumnType("int");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<bool?>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("('False')");

                    b.Property<bool?>("IsUsed")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("PaticipantDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("CpVchId");

                    b.HasIndex("CustomerId");

                    b.ToTable("CpVchCustomer", (string)null);
                });

            modelBuilder.Entity("DoAnTKPMNC.Entities.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<bool?>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("('False')");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("CustomerId");

                    b.HasIndex("AccountId");

                    b.ToTable("Customer", (string)null);
                });

            modelBuilder.Entity("DoAnTKPMNC.Entities.Game", b =>
                {
                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("GameId");

                    b.ToTable("Game", (string)null);
                });

            modelBuilder.Entity("DoAnTKPMNC.Entities.Partner", b =>
                {
                    b.Property<int>("PartnerId")
                        .HasColumnType("int");

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<bool?>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("('False')");

                    b.Property<string>("PartnerName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("PartnerId");

                    b.HasIndex("AccountId");

                    b.ToTable("Partner", (string)null);
                });

            modelBuilder.Entity("DoAnTKPMNC.Entities.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("char(50)")
                        .IsFixedLength();

                    b.HasKey("RoleId");

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("DoAnTKPMNC.Entities.Store", b =>
                {
                    b.Property<int>("StoreId")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<bool?>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("('False')");

                    b.Property<decimal?>("Lat")
                        .HasColumnType("decimal(18,12)");

                    b.Property<decimal?>("Long")
                        .HasColumnType("decimal(18,12)");

                    b.Property<int?>("PartnerId")
                        .HasColumnType("int");

                    b.Property<string>("StoredName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("StoreId");

                    b.HasIndex("PartnerId");

                    b.HasIndex("TypeId");

                    b.ToTable("Store", (string)null);
                });

            modelBuilder.Entity("DoAnTKPMNC.Entities.TypeOfStore", b =>
                {
                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("TypeId");

                    b.ToTable("TypeOfStore", (string)null);
                });

            modelBuilder.Entity("DoAnTKPMNC.Entities.Voucher", b =>
                {
                    b.Property<int>("VoucherId")
                        .HasColumnType("int");

                    b.Property<string>("ImgUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("('False')");

                    b.Property<bool?>("Pcent")
                        .HasColumnType("bit");

                    b.Property<int?>("StoreId")
                        .HasColumnType("int");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.Property<bool?>("Vnd")
                        .HasColumnType("bit")
                        .HasColumnName("VND");

                    b.HasKey("VoucherId");

                    b.HasIndex("StoreId");

                    b.ToTable("Voucher", (string)null);
                });

            modelBuilder.Entity("DoAnTKPMNC.Entities.Account", b =>
                {
                    b.HasOne("DoAnTKPMNC.Entities.Role", "Role")
                        .WithMany("Accounts")
                        .HasForeignKey("RoleId")
                        .IsRequired()
                        .HasConstraintName("FK_Account_Role");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("DoAnTKPMNC.Entities.Campaign", b =>
                {
                    b.HasOne("DoAnTKPMNC.Entities.Partner", "Partner")
                        .WithMany("Campaigns")
                        .HasForeignKey("PartnerId")
                        .HasConstraintName("FK_Campaign_Partner");

                    b.Navigation("Partner");
                });

            modelBuilder.Entity("DoAnTKPMNC.Entities.CampaignGame", b =>
                {
                    b.HasOne("DoAnTKPMNC.Entities.Campaign", "CampaignGameNavigation")
                        .WithOne("CampaignGame")
                        .HasForeignKey("DoAnTKPMNC.Entities.CampaignGame", "CampaignGameId")
                        .IsRequired()
                        .HasConstraintName("FK_CampaignGame_Campaign");

                    b.HasOne("DoAnTKPMNC.Entities.Game", "Game")
                        .WithMany("CampaignGames")
                        .HasForeignKey("GameId")
                        .HasConstraintName("FK_CampaignGame_Game");

                    b.Navigation("CampaignGameNavigation");

                    b.Navigation("Game");
                });

            modelBuilder.Entity("DoAnTKPMNC.Entities.CampaignVoucher", b =>
                {
                    b.HasOne("DoAnTKPMNC.Entities.Campaign", "Campaign")
                        .WithMany("CampaignVouchers")
                        .HasForeignKey("CampaignId")
                        .HasConstraintName("FK_CampaignVoucher_Campaign");

                    b.HasOne("DoAnTKPMNC.Entities.Voucher", "Voucher")
                        .WithMany("CampaignVouchers")
                        .HasForeignKey("VoucherId")
                        .HasConstraintName("FK_CampaignVoucher_Voucher");

                    b.Navigation("Campaign");

                    b.Navigation("Voucher");
                });

            modelBuilder.Entity("DoAnTKPMNC.Entities.CpVchCustomer", b =>
                {
                    b.HasOne("DoAnTKPMNC.Entities.CampaignVoucher", "CpVch")
                        .WithMany("CpVchCustomers")
                        .HasForeignKey("CpVchId")
                        .HasConstraintName("FK_CpVchCustomer_CampaignVoucher");

                    b.HasOne("DoAnTKPMNC.Entities.Customer", "Customer")
                        .WithMany("CpVchCustomers")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK_CpVchCustomer_Customer");

                    b.Navigation("CpVch");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("DoAnTKPMNC.Entities.Customer", b =>
                {
                    b.HasOne("DoAnTKPMNC.Entities.Account", "Account")
                        .WithMany("Customers")
                        .HasForeignKey("AccountId")
                        .IsRequired()
                        .HasConstraintName("FK_Customer_Account");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("DoAnTKPMNC.Entities.Partner", b =>
                {
                    b.HasOne("DoAnTKPMNC.Entities.Account", "Account")
                        .WithMany("Partners")
                        .HasForeignKey("AccountId")
                        .IsRequired()
                        .HasConstraintName("FK_Partner_Partner");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("DoAnTKPMNC.Entities.Store", b =>
                {
                    b.HasOne("DoAnTKPMNC.Entities.Partner", "Partner")
                        .WithMany("Stores")
                        .HasForeignKey("PartnerId")
                        .HasConstraintName("FK_Store_Partner");

                    b.HasOne("DoAnTKPMNC.Entities.TypeOfStore", "Type")
                        .WithMany("Stores")
                        .HasForeignKey("TypeId")
                        .HasConstraintName("FK_Store_TypeOfStore");

                    b.Navigation("Partner");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("DoAnTKPMNC.Entities.Voucher", b =>
                {
                    b.HasOne("DoAnTKPMNC.Entities.Store", "Store")
                        .WithMany("Vouchers")
                        .HasForeignKey("StoreId")
                        .HasConstraintName("FK_Voucher_Store");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("DoAnTKPMNC.Entities.Account", b =>
                {
                    b.Navigation("Customers");

                    b.Navigation("Partners");
                });

            modelBuilder.Entity("DoAnTKPMNC.Entities.Campaign", b =>
                {
                    b.Navigation("CampaignGame");

                    b.Navigation("CampaignVouchers");
                });

            modelBuilder.Entity("DoAnTKPMNC.Entities.CampaignVoucher", b =>
                {
                    b.Navigation("CpVchCustomers");
                });

            modelBuilder.Entity("DoAnTKPMNC.Entities.Customer", b =>
                {
                    b.Navigation("CpVchCustomers");
                });

            modelBuilder.Entity("DoAnTKPMNC.Entities.Game", b =>
                {
                    b.Navigation("CampaignGames");
                });

            modelBuilder.Entity("DoAnTKPMNC.Entities.Partner", b =>
                {
                    b.Navigation("Campaigns");

                    b.Navigation("Stores");
                });

            modelBuilder.Entity("DoAnTKPMNC.Entities.Role", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("DoAnTKPMNC.Entities.Store", b =>
                {
                    b.Navigation("Vouchers");
                });

            modelBuilder.Entity("DoAnTKPMNC.Entities.TypeOfStore", b =>
                {
                    b.Navigation("Stores");
                });

            modelBuilder.Entity("DoAnTKPMNC.Entities.Voucher", b =>
                {
                    b.Navigation("CampaignVouchers");
                });
#pragma warning restore 612, 618
        }
    }
}
