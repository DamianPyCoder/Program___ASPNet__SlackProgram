using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
  public partial class MessageAdded : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DeleteData(
          table: "Channels",
          keyColumn: "Id",
          keyValue: new Guid("458a1b8e-0ca4-4926-a1dd-eec6252ad02d"));

      migrationBuilder.DeleteData(
          table: "Channels",
          keyColumn: "Id",
          keyValue: new Guid("48def534-5e61-40b7-8cc5-ead18caab836"));

      migrationBuilder.DeleteData(
          table: "Channels",
          keyColumn: "Id",
          keyValue: new Guid("6347ccac-bb22-41f9-a221-d2a6f99e5d5b"));

      migrationBuilder.AddColumn<int>(
          name: "ChannelType",
          table: "Channels",
          nullable: false,
          defaultValue: 0);

      migrationBuilder.AddColumn<string>(
          name: "Avatar",
          table: "AspNetUsers",
          nullable: true);

      migrationBuilder.CreateTable(
          name: "Messages",
          columns: table => new
          {
            Id = table.Column<Guid>(nullable: false),
            Content = table.Column<string>(nullable: true),
            CreatedAt = table.Column<DateTime>(nullable: false),
            SenderId = table.Column<string>(nullable: true),
            ChannelId = table.Column<Guid>(nullable: false),
            MessageType = table.Column<int>(nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Messages", x => x.Id);
            table.ForeignKey(
                      name: "FK_Messages_Channels_ChannelId",
                      column: x => x.ChannelId,
                      principalTable: "Channels",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
            table.ForeignKey(
                      name: "FK_Messages_AspNetUsers_SenderId",
                      column: x => x.SenderId,
                      principalTable: "AspNetUsers",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Restrict);
          });

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

      migrationBuilder.CreateIndex(
          name: "IX_Messages_ChannelId",
          table: "Messages",
          column: "ChannelId");

      migrationBuilder.CreateIndex(
          name: "IX_Messages_SenderId",
          table: "Messages",
          column: "SenderId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "Messages");

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

      migrationBuilder.DropColumn(
          name: "ChannelType",
          table: "Channels");

      migrationBuilder.DropColumn(
          name: "Avatar",
          table: "AspNetUsers");

      migrationBuilder.InsertData(
          table: "Channels",
          columns: new[] { "Id", "Description", "Name" },
          values: new object[] { new Guid("48def534-5e61-40b7-8cc5-ead18caab836"), "Canal dedicado a dotnet core", "DotNetCore" });

      migrationBuilder.InsertData(
          table: "Channels",
          columns: new[] { "Id", "Description", "Name" },
          values: new object[] { new Guid("458a1b8e-0ca4-4926-a1dd-eec6252ad02d"), "Canal dedicado a Angular", "Angular" });

      migrationBuilder.InsertData(
          table: "Channels",
          columns: new[] { "Id", "Description", "Name" },
          values: new object[] { new Guid("6347ccac-bb22-41f9-a221-d2a6f99e5d5b"), "Canal dedicado a ReactJs", "Reactjs" });
    }
  }
}
