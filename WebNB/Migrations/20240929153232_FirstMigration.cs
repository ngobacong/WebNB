using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebNB.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gia_CLS",
                columns: table => new
                {
                    STT = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ma = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    DVT = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Gia_TH = table.Column<decimal>(type: "decimal(9,0)", precision: 9, scale: 0, nullable: false),
                    Gia_BH = table.Column<decimal>(type: "decimal(9,0)", precision: 9, scale: 0, nullable: false),
                    LoaiVP = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NhomVP = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NhomVP_BHYT = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    QD366 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Ten43 = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    GhiChuKt = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gia_CLS", x => x.STT);
                });

            migrationBuilder.CreateTable(
                name: "Gia_DV",
                columns: table => new
                {
                    STT = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ma = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    DVT = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Gia_TH = table.Column<decimal>(type: "decimal(9,0)", precision: 9, scale: 0, nullable: false),
                    Gia_BH = table.Column<decimal>(type: "decimal(9,0)", precision: 9, scale: 0, nullable: false),
                    LoaiVP = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NhomVP = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NhomVP_BHYT = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    QD366 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Ten43 = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    MaGiuong = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GhiChuKt = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gia_DV", x => x.STT);
                });

            migrationBuilder.CreateTable(
                name: "Gia_GIUONG",
                columns: table => new
                {
                    STT = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ma = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    DVT = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Gia_TH = table.Column<decimal>(type: "decimal(9,0)", precision: 9, scale: 0, nullable: false),
                    Gia_BH = table.Column<decimal>(type: "decimal(9,0)", precision: 9, scale: 0, nullable: false),
                    LoaiVP = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NhomVP = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NhomVP_BHYT = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    QD366 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Ten43 = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    MaGiuong = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GhiChuKt = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gia_GIUONG", x => x.STT);
                });

            migrationBuilder.CreateTable(
                name: "Gia_PTTT",
                columns: table => new
                {
                    STT = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ma = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    DVT = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Gia_TH = table.Column<decimal>(type: "decimal(9,0)", precision: 9, scale: 0, nullable: false),
                    Gia_BH = table.Column<decimal>(type: "decimal(9,0)", precision: 9, scale: 0, nullable: false),
                    LoaiVP = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NhomVP = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NhomVP_BHYT = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    QD366 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Ten43 = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    GhiChuKt = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gia_PTTT", x => x.STT);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gia_CLS");

            migrationBuilder.DropTable(
                name: "Gia_DV");

            migrationBuilder.DropTable(
                name: "Gia_GIUONG");

            migrationBuilder.DropTable(
                name: "Gia_PTTT");
        }
    }
}
