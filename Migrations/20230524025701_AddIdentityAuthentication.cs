using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoAnTKPMNC.Migrations
{
    public partial class AddIdentityAuthentication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.GameId);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    RoleName = table.Column<string>(type: "char(50)", unicode: false, fixedLength: true, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfStore",
                columns: table => new
                {
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfStore", x => x.TypeId);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "('False')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.AccountId);
                    table.ForeignKey(
                        name: "FK_Account_Role",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId");
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "('False')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customer_Account",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "AccountId");
                });

            migrationBuilder.CreateTable(
                name: "Partner",
                columns: table => new
                {
                    PartnerId = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    PartnerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "('False')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partner", x => x.PartnerId);
                    table.ForeignKey(
                        name: "FK_Partner_Partner",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "AccountId");
                });

            migrationBuilder.CreateTable(
                name: "Campaign",
                columns: table => new
                {
                    CampaignId = table.Column<int>(type: "int", nullable: false),
                    CpDescrip = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    StartDate = table.Column<DateTime>(type: "date", nullable: true),
                    EndDate = table.Column<DateTime>(type: "date", nullable: true),
                    PartnerId = table.Column<int>(type: "int", nullable: true),
                    MaxTimePaticipant = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "('False')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaign", x => x.CampaignId);
                    table.ForeignKey(
                        name: "FK_Campaign_Partner",
                        column: x => x.PartnerId,
                        principalTable: "Partner",
                        principalColumn: "PartnerId");
                });

            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: true),
                    Address = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    PartnerId = table.Column<int>(type: "int", nullable: true),
                    StoredName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Long = table.Column<decimal>(type: "decimal(18,12)", nullable: true),
                    Lat = table.Column<decimal>(type: "decimal(18,12)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "('False')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.StoreId);
                    table.ForeignKey(
                        name: "FK_Store_Partner",
                        column: x => x.PartnerId,
                        principalTable: "Partner",
                        principalColumn: "PartnerId");
                    table.ForeignKey(
                        name: "FK_Store_TypeOfStore",
                        column: x => x.TypeId,
                        principalTable: "TypeOfStore",
                        principalColumn: "TypeId");
                });

            migrationBuilder.CreateTable(
                name: "CampaignGame",
                columns: table => new
                {
                    CampaignGameId = table.Column<int>(type: "int", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: true),
                    CampaignId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "('False')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignGame", x => x.CampaignGameId);
                    table.ForeignKey(
                        name: "FK_CampaignGame_Campaign",
                        column: x => x.CampaignGameId,
                        principalTable: "Campaign",
                        principalColumn: "CampaignId");
                    table.ForeignKey(
                        name: "FK_CampaignGame_Game",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "GameId");
                });

            migrationBuilder.CreateTable(
                name: "Voucher",
                columns: table => new
                {
                    VoucherId = table.Column<int>(type: "int", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: true),
                    Pcent = table.Column<bool>(type: "bit", nullable: true),
                    VND = table.Column<bool>(type: "bit", nullable: true),
                    Value = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "('False')"),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voucher", x => x.VoucherId);
                    table.ForeignKey(
                        name: "FK_Voucher_Store",
                        column: x => x.StoreId,
                        principalTable: "Store",
                        principalColumn: "StoreId");
                });

            migrationBuilder.CreateTable(
                name: "CampaignVoucher",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    VoucherId = table.Column<int>(type: "int", nullable: true),
                    ExpiredDate = table.Column<DateTime>(type: "date", nullable: true),
                    CampaignId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    UsedQuantity = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "('False')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignVoucher", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CampaignVoucher_Campaign",
                        column: x => x.CampaignId,
                        principalTable: "Campaign",
                        principalColumn: "CampaignId");
                    table.ForeignKey(
                        name: "FK_CampaignVoucher_Voucher",
                        column: x => x.VoucherId,
                        principalTable: "Voucher",
                        principalColumn: "VoucherId");
                });

            migrationBuilder.CreateTable(
                name: "CpVchCustomer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    CpVchId = table.Column<int>(type: "int", nullable: true),
                    PaticipantDate = table.Column<DateTime>(type: "date", nullable: true),
                    IsUsed = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "('False')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CpVchCustomer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CpVchCustomer_CampaignVoucher",
                        column: x => x.CpVchId,
                        principalTable: "CampaignVoucher",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CpVchCustomer_Customer",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_RoleId",
                table: "Account",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Campaign_PartnerId",
                table: "Campaign",
                column: "PartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignGame_GameId",
                table: "CampaignGame",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignVoucher_CampaignId",
                table: "CampaignVoucher",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignVoucher_VoucherId",
                table: "CampaignVoucher",
                column: "VoucherId");

            migrationBuilder.CreateIndex(
                name: "IX_CpVchCustomer_CpVchId",
                table: "CpVchCustomer",
                column: "CpVchId");

            migrationBuilder.CreateIndex(
                name: "IX_CpVchCustomer_CustomerId",
                table: "CpVchCustomer",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_AccountId",
                table: "Customer",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Partner_AccountId",
                table: "Partner",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Store_PartnerId",
                table: "Store",
                column: "PartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Store_TypeId",
                table: "Store",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Voucher_StoreId",
                table: "Voucher",
                column: "StoreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CampaignGame");

            migrationBuilder.DropTable(
                name: "CpVchCustomer");

            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropTable(
                name: "CampaignVoucher");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Campaign");

            migrationBuilder.DropTable(
                name: "Voucher");

            migrationBuilder.DropTable(
                name: "Store");

            migrationBuilder.DropTable(
                name: "Partner");

            migrationBuilder.DropTable(
                name: "TypeOfStore");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
