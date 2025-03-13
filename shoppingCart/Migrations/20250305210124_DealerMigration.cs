using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shoppingCart.Migrations
{
    /// <inheritdoc />
    public partial class DealerMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_Dealer",
                columns: table => new
                {
                    Dealer_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dealer_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dealer_email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dealer_password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dealer_image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Dealer", x => x.Dealer_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_Dealer");
        }
    }
}
