using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AddPrivateChannel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Channels",
                keyColumn: "Id",
                keyValue: new Guid("0b553aaa-e79c-421b-8b48-7575c96cc621"));

            migrationBuilder.DeleteData(
                table: "Channels",
                keyColumn: "Id",
                keyValue: new Guid("4064a7b9-06db-485e-bcff-acf13314ef38"));

            migrationBuilder.DeleteData(
                table: "Channels",
                keyColumn: "Id",
                keyValue: new Guid("baaa7c07-cb20-4bd3-9be5-b05566eca3cb"));

            migrationBuilder.AddColumn<string>(
                name: "PrivateChannelId",
                table: "Channels",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsOnline",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "PrivateChannelId",
                table: "Channels");

            migrationBuilder.DropColumn(
                name: "IsOnline",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "Channels",
                columns: new[] { "Id", "ChannelType", "Description", "Name" },
                values: new object[] { new Guid("baaa7c07-cb20-4bd3-9be5-b05566eca3cb"), 0, "Canal dedicado a dotnet core", "DotNetCore" });

            migrationBuilder.InsertData(
                table: "Channels",
                columns: new[] { "Id", "ChannelType", "Description", "Name" },
                values: new object[] { new Guid("0b553aaa-e79c-421b-8b48-7575c96cc621"), 0, "Canal dedicado a Angular", "Angular" });

            migrationBuilder.InsertData(
                table: "Channels",
                columns: new[] { "Id", "ChannelType", "Description", "Name" },
                values: new object[] { new Guid("4064a7b9-06db-485e-bcff-acf13314ef38"), 0, "Canal dedicado a ReactJs", "Reactjs" });
        }
    }
}
