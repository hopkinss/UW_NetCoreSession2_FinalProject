using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CdiscTestCds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CdiscTestCds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LabTests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestName = table.Column<string>(nullable: false),
                    Unit = table.Column<string>(nullable: true),
                    Specimen = table.Column<int>(nullable: false),
                    CdiscTestId = table.Column<int>(nullable: true),
                    CdiscTestCdId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabTests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LabTests_CdiscTestCds_CdiscTestCdId",
                        column: x => x.CdiscTestCdId,
                        principalTable: "CdiscTestCds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LabTestRefRanges",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sex = table.Column<string>(nullable: true),
                    ULN = table.Column<double>(nullable: false),
                    LLN = table.Column<double>(nullable: false),
                    LabTestId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabTestRefRanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LabTestRefRanges_LabTests_LabTestId",
                        column: x => x.LabTestId,
                        principalTable: "LabTests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CdiscTestCds",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "HGB" },
                    { 2, "HCT" },
                    { 3, "RBC" },
                    { 4, "CA" }
                });

            migrationBuilder.InsertData(
                table: "LabTests",
                columns: new[] { "Id", "CdiscTestCdId", "CdiscTestId", "Specimen", "TestName", "Unit" },
                values: new object[,]
                {
                    { 1, null, null, 0, "Hemoglobin", "mg/dL" },
                    { 2, null, null, 0, "Hematocrit", "%" },
                    { 3, null, null, 0, "Red Blood Cell Count", "10^6/uL" },
                    { 4, null, null, 1, "Calcium", "mg/dL" }
                });

            migrationBuilder.InsertData(
                table: "LabTestRefRanges",
                columns: new[] { "Id", "LLN", "LabTestId", "Sex", "ULN" },
                values: new object[] { 1, 12.5, 1, "Male", 17.0 });

            migrationBuilder.CreateIndex(
                name: "IX_LabTestRefRanges_LabTestId",
                table: "LabTestRefRanges",
                column: "LabTestId");

            migrationBuilder.CreateIndex(
                name: "IX_LabTests_CdiscTestCdId",
                table: "LabTests",
                column: "CdiscTestCdId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LabTestRefRanges");

            migrationBuilder.DropTable(
                name: "LabTests");

            migrationBuilder.DropTable(
                name: "CdiscTestCds");
        }
    }
}
