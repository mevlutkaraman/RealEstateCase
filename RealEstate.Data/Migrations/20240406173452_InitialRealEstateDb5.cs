using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstate.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialRealEstateDb5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_ItemImage_Item_Id",
            //    table: "ItemImage");

            //migrationBuilder.AlterColumn<int>(
            //    name: "Id",
            //    table: "ItemImage",
            //    type: "int",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int")
            //    .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_ItemImage_ItemId",
                table: "ItemImage",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemImage_Item_ItemId",
                table: "ItemImage",
                column: "ItemId",
                principalTable: "Item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_ItemImage_Item_ItemId",
            //    table: "ItemImage");

            migrationBuilder.DropIndex(
                name: "IX_ItemImage_ItemId",
                table: "ItemImage");

            //migrationBuilder.AlterColumn<int>(
            //    name: "Id",
            //    table: "ItemImage",
            //    type: "int",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int")
            //    .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemImage_Item_Id",
                table: "ItemImage",
                column: "Id",
                principalTable: "Item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
