using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AddTyping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Channels",
                keyColumn: "Id",
                keyValue: new Guid("043784c2-1e18-4218-a618-67381473f702"));

            migrationBuilder.DeleteData(
                table: "Channels",
                keyColumn: "Id",
                keyValue: new Guid("12d546e1-5c61-4a3c-a234-000575de3b37"));

            migrationBuilder.DeleteData(
                table: "Channels",
                keyColumn: "Id",
                keyValue: new Guid("e1ed4ba1-ab04-4216-b9ef-f0d15d3fc4db"));

            migrationBuilder.CreateTable(
                name: "TypingNotification",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ChannelId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypingNotification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TypingNotification_Channels_ChannelId",
                        column: x => x.ChannelId,
                        principalTable: "Channels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TypingNotification_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Channels",
                columns: new[] { "Id", "ChannelType", "Description", "Name", "PrivateChannelId" },
                values: new object[] { new Guid("39961cf9-35ad-411f-bd99-5ff38937c88a"), 0, "Canal dedicado a dotnet core", "DotNetCore", null });

            migrationBuilder.InsertData(
                table: "Channels",
                columns: new[] { "Id", "ChannelType", "Description", "Name", "PrivateChannelId" },
                values: new object[] { new Guid("6d66ad0c-0ccd-4590-b834-a11232d42076"), 0, "Canal dedicado a Angular", "Angular", null });

            migrationBuilder.InsertData(
                table: "Channels",
                columns: new[] { "Id", "ChannelType", "Description", "Name", "PrivateChannelId" },
                values: new object[] { new Guid("7a306cdc-fada-44f3-9062-fc2c2bca457e"), 0, "Canal dedicado a ReactJs", "Reactjs", null });

            migrationBuilder.CreateIndex(
                name: "IX_TypingNotification_ChannelId",
                table: "TypingNotification",
                column: "ChannelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TypingNotification");

            migrationBuilder.DeleteData(
                table: "Channels",
                keyColumn: "Id",
                keyValue: new Guid("39961cf9-35ad-411f-bd99-5ff38937c88a"));

            migrationBuilder.DeleteData(
                table: "Channels",
                keyColumn: "Id",
                keyValue: new Guid("6d66ad0c-0ccd-4590-b834-a11232d42076"));

            migrationBuilder.DeleteData(
                table: "Channels",
                keyColumn: "Id",
                keyValue: new Guid("7a306cdc-fada-44f3-9062-fc2c2bca457e"));

            migrationBuilder.InsertData(
                table: "Channels",
                columns: new[] { "Id", "ChannelType", "Description", "Name", "PrivateChannelId" },
                values: new object[] { new Guid("e1ed4ba1-ab04-4216-b9ef-f0d15d3fc4db"), 0, "Canal dedicado a dotnet core", "DotNetCore", null });

            migrationBuilder.InsertData(
                table: "Channels",
                columns: new[] { "Id", "ChannelType", "Description", "Name", "PrivateChannelId" },
                values: new object[] { new Guid("043784c2-1e18-4218-a618-67381473f702"), 0, "Canal dedicado a Angular", "Angular", null });

            migrationBuilder.InsertData(
                table: "Channels",
                columns: new[] { "Id", "ChannelType", "Description", "Name", "PrivateChannelId" },
                values: new object[] { new Guid("12d546e1-5c61-4a3c-a234-000575de3b37"), 0, "Canal dedicado a ReactJs", "Reactjs", null });
        }
    }
}
