using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MusicApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CountryId = table.Column<int>(type: "integer", nullable: false),
                    Gender = table.Column<bool>(type: "boolean", nullable: false),
                    Instrument = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    FormedIn = table.Column<int>(type: "integer", nullable: false),
                    Genre = table.Column<string>(type: "text", nullable: false),
                    CountryId = table.Column<int>(type: "integer", nullable: false),
                    CountriesId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bands_Countries_CountriesId",
                        column: x => x.CountriesId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Titre = table.Column<string>(type: "text", nullable: false),
                    BandId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Albums_Bands_BandId",
                        column: x => x.BandId,
                        principalTable: "Bands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BandMembers",
                columns: table => new
                {
                    BandId = table.Column<int>(type: "integer", nullable: false),
                    MemberId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BandMembers", x => new { x.BandId, x.MemberId });
                    table.ForeignKey(
                        name: "FK_BandMembers_Bands_BandId",
                        column: x => x.BandId,
                        principalTable: "Bands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BandMembers_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Bands",
                columns: new[] { "Id", "CountriesId", "CountryId", "FormedIn", "Genre", "Name", "Status" },
                values: new object[,]
                {
                    { 1, null, 1, 0, "Black Metal", "Vaino", "Active" },
                    { 2, null, 2, 0, "Black Metal", "Bedrag", "Active" },
                    { 3, null, 4, 2013, "Black Metal with folk influences", "Leftmuenang", "Changed name" },
                    { 4, null, 4, 2003, "Black/Thrash Metal", "Armageddon", "Active" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Finland" },
                    { 2, "Norway" },
                    { 3, "France" },
                    { 4, "Thailand" }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "CountryId", "Gender", "Instrument", "Name" },
                values: new object[,]
                {
                    { 1, 1, true, "Guitar", "Valtteri Pasanen" },
                    { 2, 1, true, "Guitar", "Nefandous" },
                    { 3, 4, true, "Vocals, Guitars, Bass (2013-2015), Vocals, All instruments (2015-?)", "Sand" },
                    { 4, 3, true, "Vocals, Guitars, Bass, Drums, Programming", "Armageddon" }
                });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "Id", "BandId", "Titre" },
                values: new object[,]
                {
                    { 1, 1, "Metsänpeitto" },
                    { 2, 2, "Diabolical Goat Cancer" },
                    { 3, 2, "Bedrag" },
                    { 4, 3, "Illusion" },
                    { 5, 4, "Necromantic Celebration" },
                    { 6, 4, "Through the Endless Torments of Hell" }
                });

            migrationBuilder.InsertData(
                table: "BandMembers",
                columns: new[] { "BandId", "MemberId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Albums_BandId",
                table: "Albums",
                column: "BandId");

            migrationBuilder.CreateIndex(
                name: "IX_BandMembers_MemberId",
                table: "BandMembers",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Bands_CountriesId",
                table: "Bands",
                column: "CountriesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "BandMembers");

            migrationBuilder.DropTable(
                name: "Bands");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
