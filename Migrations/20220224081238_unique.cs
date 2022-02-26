using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TPS.Migrations
{
    public partial class unique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        //    migrationBuilder.CreateTable(
        //        name: "t_ATM",
        //        columns: table => new
        //        {
        //            Id = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
        //            ATM_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
        //            ATM_Balance = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
        //            CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
        //            CreatedOn = table.Column<DateTime>(type: "smalldatetime", nullable: false),
        //            ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            ModifiedOn = table.Column<DateTime>(type: "smalldatetime", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_t_ATM", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "t_User",
        //        columns: table => new
        //        {
        //            Id = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
        //            UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
        //            Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
        //            Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            CreatedOn = table.Column<DateTime>(type: "smalldatetime", nullable: true),
        //            CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            ModifiedOn = table.Column<DateTime>(type: "smalldatetime", nullable: true),
        //            ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_t_User", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "t_User_Accounts",
        //        columns: table => new
        //        {
        //            Id = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
        //            User_Id = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
        //            Acc_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
        //            Acc_Balance = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
        //            CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
        //            CreatedOn = table.Column<DateTime>(type: "smalldatetime", nullable: true),
        //            ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            ModifiedOn = table.Column<DateTime>(type: "smalldatetime", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_t_User_Accounts", x => x.Id);
        //        });

            migrationBuilder.CreateIndex(
                name: "IX_t_User_Email",
                table: "t_User",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_t_User_UserName",
                table: "t_User",
                column: "UserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "t_ATM");

            //migrationBuilder.DropTable(
            //    name: "t_User");

            //migrationBuilder.DropTable(
            //    name: "t_User_Accounts");
        }
    }
}
