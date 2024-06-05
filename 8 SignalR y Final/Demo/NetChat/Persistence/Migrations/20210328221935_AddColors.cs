using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AddColors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "PrimaryAppColor",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecondaryAppColor",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Channels",
                columns: new[] { "Id", "ChannelType", "Description", "Name", "PrivateChannelId" },
                values: new object[] { new Guid("0fdcf4ba-e282-49b8-95a6-67062bf44344"), 0, "Canal dedicado a dotnet core", "DotNetCore", null });

            migrationBuilder.InsertData(
                table: "Channels",
                columns: new[] { "Id", "ChannelType", "Description", "Name", "PrivateChannelId" },
                values: new object[] { new Guid("bd2b24cc-be83-4fc6-bf23-1a11ac1e3eea"), 0, "Canal dedicado a Angular", "Angular", null });

            migrationBuilder.InsertData(
                table: "Channels",
                columns: new[] { "Id", "ChannelType", "Description", "Name", "PrivateChannelId" },
                values: new object[] { new Guid("6bb63644-08bd-44af-8a25-6d49c8cb22d8"), 0, "Canal dedicado a ReactJs", "Reactjs", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Channels",
                keyColumn: "Id",
                keyValue: new Guid("0fdcf4ba-e282-49b8-95a6-67062bf44344"));

            migrationBuilder.DeleteData(
                table: "Channels",
                keyColumn: "Id",
                keyValue: new Guid("6bb63644-08bd-44af-8a25-6d49c8cb22d8"));

            migrationBuilder.DeleteData(
                table: "Channels",
                keyColumn: "Id",
                keyValue: new Guid("bd2b24cc-be83-4fc6-bf23-1a11ac1e3eea"));

            migrationBuilder.DropColumn(
                name: "PrimaryAppColor",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SecondaryAppColor",
                table: "AspNetUsers");

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
        }
    }
}
