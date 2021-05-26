using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CdiscTest",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CdiscTest", x => x.Id);
                });

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
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LabTests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestName = table.Column<string>(nullable: false),
                    Specimen = table.Column<int>(nullable: false),
                    Category = table.Column<int>(nullable: false),
                    UnitId = table.Column<int>(nullable: true),
                    CdiscTestId = table.Column<int>(nullable: true),
                    CdiscTestNameId = table.Column<int>(nullable: true),
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
                    table.ForeignKey(
                        name: "FK_LabTests_CdiscTest_CdiscTestNameId",
                        column: x => x.CdiscTestNameId,
                        principalTable: "CdiscTest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LabTests_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LabTestConversions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitFromId = table.Column<int>(nullable: false),
                    UnitToId = table.Column<int>(nullable: false),
                    ConFac = table.Column<string>(nullable: true),
                    LabTestId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabTestConversions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LabTestConversions_LabTests_LabTestId",
                        column: x => x.LabTestId,
                        principalTable: "LabTests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LabTestConversions_Units_UnitFromId",
                        column: x => x.UnitFromId,
                        principalTable: "Units",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LabTestConversions_Units_UnitToId",
                        column: x => x.UnitToId,
                        principalTable: "Units",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LabTestRefRanges",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sex = table.Column<int>(nullable: false),
                    ULN = table.Column<string>(nullable: true),
                    LLN = table.Column<string>(nullable: true),
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
                table: "CdiscTest",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Hemoglobin" },
                    { 2, "Hematocrit" },
                    { 3, "Protein" },
                    { 4, "Calcium" }
                });

            migrationBuilder.InsertData(
                table: "CdiscTestCds",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "HGB" },
                    { 2, "HCT" },
                    { 3, "PROT" },
                    { 4, "CA" }
                });

            migrationBuilder.InsertData(
                table: "LabTests",
                columns: new[] { "Id", "Category", "CdiscTestCdId", "CdiscTestId", "CdiscTestNameId", "Specimen", "TestName", "UnitId" },
                values: new object[,]
                {
                    { 4, 0, null, null, null, 1, "Calcium (Non-Ionized)", null },
                    { 3, 5, null, null, null, 3, "Urine Protein", null },
                    { 1, 2, null, null, null, 0, "Hemoglobin", null },
                    { 2, 2, null, null, null, 0, "Hematocrit", null }
                });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 5, "mmol/L" },
                    { 1, "g/L" },
                    { 2, "mg/dL" },
                    { 3, "%" },
                    { 4, "ng/dL" },
                    { 6, "g/dL" }
                });

            migrationBuilder.InsertData(
                table: "LabTestConversions",
                columns: new[] { "Id", "ConFac", "LabTestId", "UnitFromId", "UnitToId" },
                values: new object[,]
                {
                    { 1, "100", 1, 1, 2 },
                    { 3, "100", 3, 1, 2 },
                    { 5, ".25", 4, 5, 2 },
                    { 2, "10", 1, 1, 6 },
                    { 4, "10", 3, 1, 6 },
                    { 6, "2.5", 4, 5, 6 },
                    { 7, "10", 4, 1, 6 }
                });

            migrationBuilder.InsertData(
                table: "LabTestRefRanges",
                columns: new[] { "Id", "LLN", "LabTestId", "Sex", "ULN" },
                values: new object[,]
                {
                    { 1, "11.5", 1, 1, "15.0" },
                    { 2, "10", 1, 2, "14.0" },
                    { 3, "35", 2, 1, "45" },
                    { 4, "33", 2, 2, "43" },
                    { 5, "5", 3, 2, "25" },
                    { 6, "5", 3, 1, "24" },
                    { 7, "8.5", 4, 0, "10.5" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LabTestConversions_LabTestId",
                table: "LabTestConversions",
                column: "LabTestId");

            migrationBuilder.CreateIndex(
                name: "IX_LabTestConversions_UnitFromId",
                table: "LabTestConversions",
                column: "UnitFromId");

            migrationBuilder.CreateIndex(
                name: "IX_LabTestConversions_UnitToId",
                table: "LabTestConversions",
                column: "UnitToId");

            migrationBuilder.CreateIndex(
                name: "IX_LabTestRefRanges_LabTestId",
                table: "LabTestRefRanges",
                column: "LabTestId");

            migrationBuilder.CreateIndex(
                name: "IX_LabTests_CdiscTestCdId",
                table: "LabTests",
                column: "CdiscTestCdId");

            migrationBuilder.CreateIndex(
                name: "IX_LabTests_CdiscTestNameId",
                table: "LabTests",
                column: "CdiscTestNameId");

            migrationBuilder.CreateIndex(
                name: "IX_LabTests_UnitId",
                table: "LabTests",
                column: "UnitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LabTestConversions");

            migrationBuilder.DropTable(
                name: "LabTestRefRanges");

            migrationBuilder.DropTable(
                name: "LabTests");

            migrationBuilder.DropTable(
                name: "CdiscTestCds");

            migrationBuilder.DropTable(
                name: "CdiscTest");

            migrationBuilder.DropTable(
                name: "Units");
        }
    }
}
