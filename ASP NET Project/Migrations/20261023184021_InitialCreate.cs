using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ASP_NET_Project.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RegionName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MiningHistoryNotes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IsActiveMiningSite = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Minerals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    Colors = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Luster = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Transparency = table.Column<int>(type: "int", nullable: false),
                    MohsScale = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CrystalSystem = table.Column<int>(type: "int", nullable: false),
                    CrystalHabit = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Cleavage = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Fracture = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Streak = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CollectingTips = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ProcessingTips = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Minerals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Museums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "nvarchar(170)", maxLength: 170, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Museums", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LocationMineral",
                columns: table => new
                {
                    LocationsId = table.Column<int>(type: "int", nullable: false),
                    MineralsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationMineral", x => new { x.LocationsId, x.MineralsId });
                    table.ForeignKey(
                        name: "FK_LocationMineral_Locations_LocationsId",
                        column: x => x.LocationsId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocationMineral_Minerals_MineralsId",
                        column: x => x.MineralsId,
                        principalTable: "Minerals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MineralMuseum",
                columns: table => new
                {
                    MineralsId = table.Column<int>(type: "int", nullable: false),
                    MuseumsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MineralMuseum", x => new { x.MineralsId, x.MuseumsId });
                    table.ForeignKey(
                        name: "FK_MineralMuseum_Minerals_MineralsId",
                        column: x => x.MineralsId,
                        principalTable: "Minerals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MineralMuseum_Museums_MuseumsId",
                        column: x => x.MuseumsId,
                        principalTable: "Museums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Country", "IsActiveMiningSite", "MiningHistoryNotes", "RegionName" },
                values: new object[,]
                {
                    { 1, "USA", true, "California has a rich mining history, particularly during the Gold Rush era.", "California" },
                    { 2, "Australia", true, "New South Wales is known for its coal mining industry.", "New South Wales" },
                    { 3, "South Africa", false, "Gauteng is famous for its gold and diamond mines.", "Gauteng" }
                });

            migrationBuilder.InsertData(
                table: "Minerals",
                columns: new[] { "Id", "Category", "Cleavage", "CollectingTips", "Colors", "CrystalHabit", "CrystalSystem", "Description", "Fracture", "Luster", "MohsScale", "Name", "ProcessingTips", "Streak", "Transparency" },
                values: new object[,]
                {
                    { 1, 1, "None", "Look in granite pegmatites, hydrothermal veins and geodes. Crystals are often found loose in weathered soil near veins.", "Colorless, white, purple, pink, yellow, brown, black", "Six-sided prismatic crystals with pyramidal terminations", 6, "Quartz is one of the most abundant minerals in the Earth's crust, made of silicon and oxygen. It forms many popular varieties such as amethyst, citrine and rose quartz.", "Conchoidal", "Vitreous", "7", "Quartz", "Rinse with water and a soft brush. Avoid harsh acids on specimens with other minerals attached.", "White", 1 },
                    { 2, 4, "Perfect rhombohedral in three directions", "Common in limestone quarries, caves and hydrothermal veins. Handle carefully because it is soft and cleaves easily.", "Colorless, white, yellow, orange, blue, green", "Rhombohedral, scalenohedral (dogtooth) and massive forms", 6, "Calcite is a calcium carbonate mineral found in limestone, marble and cave formations. It is famous for strong double refraction and its reaction with dilute acid.", "Conchoidal", "Vitreous", "3", "Calcite", "Never use acid to clean it, as it will dissolve. Use water and a soft brush only.", "White", 1 },
                    { 3, 3, "Indistinct", "Found in sedimentary rocks, coal seams and hydrothermal veins. Collect dry specimens and store them away from moisture.", "Pale brass-yellow", "Cubes, pyritohedrons and octahedrons", 1, "Pyrite, often called fool's gold, is an iron sulfide with a bright metallic luster. It is the most common sulfide mineral and forms in many geological environments.", "Uneven to conchoidal", "Metallic", "6-6.5", "Pyrite", "Keep in a low-humidity place, since pyrite can oxidize and decay over time.", "Greenish-black to brownish-black", 3 },
                    { 4, 6, "Perfect octahedral in four directions", "Occurs in hydrothermal veins and carbonate rocks. Wrap specimens well, because they break easily along cleavage planes.", "Purple, green, blue, yellow, colorless, pink", "Cubes and octahedrons, often with interpenetrating twins", 1, "Fluorite is a calcium fluoride mineral known for its wide range of colors and for fluorescing under ultraviolet light.", "Subconchoidal to uneven", "Vitreous", "4", "Fluorite", "Clean gently with water. Avoid prolonged sunlight, which can fade some colors.", "White", 1 },
                    { 5, 2, "None", "Found in banded iron formations, sedimentary deposits and volcanic environments.", "Steel-gray, silver, reddish-brown, black", "Tabular crystals, rosettes, botryoidal and massive forms", 6, "Hematite is an iron oxide and the most important ore of iron. Its red streak is the key way to identify it, even when the specimen looks black or gray.", "Uneven to subconchoidal", "Metallic to earthy", "5-6.5", "Hematite", "Clean with water and a soft brush. It is stable and does not need special storage.", "Red to reddish-brown", 3 }
                });

            migrationBuilder.InsertData(
                table: "Museums",
                columns: new[] { "Id", "City", "Country", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Washington D.C.", "USA", "The Smithsonian National Museum of Natural History is one of the most renowned natural history museums in the world, located in the heart of Washington D.C. It houses a vast collection of specimens and artifacts related to natural history, including fossils, minerals, plants, animals, and cultural artifacts.", "Smithsonian National Museum of Natural History" },
                    { 2, "Sydney", "Australia", "The Australian Museum, located in Sydney, is the oldest museum in Australia and is dedicated to natural history and anthropology. It features extensive collections of minerals, fossils, and cultural artifacts from Australia and the Pacific region.", "Australian Museum" },
                    { 3, "Pretoria", "South Africa", "The Ditsong National Museum of Natural History, located in Pretoria, South Africa, is a leading institution for the study and preservation of natural history. It houses a diverse collection of minerals, fossils, and other specimens that showcase the rich biodiversity and geological history of South Africa.", "Ditsong National Museum of Natural History" }
                });

            migrationBuilder.InsertData(
                table: "LocationMineral",
                columns: new[] { "LocationsId", "MineralsId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 3 },
                    { 1, 4 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 5 },
                    { 3, 1 },
                    { 3, 2 },
                    { 3, 3 },
                    { 3, 5 }
                });

            migrationBuilder.InsertData(
                table: "MineralMuseum",
                columns: new[] { "MineralsId", "MuseumsId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 2 },
                    { 3, 1 },
                    { 3, 3 },
                    { 4, 1 },
                    { 4, 2 },
                    { 5, 2 },
                    { 5, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LocationMineral_MineralsId",
                table: "LocationMineral",
                column: "MineralsId");

            migrationBuilder.CreateIndex(
                name: "IX_MineralMuseum_MuseumsId",
                table: "MineralMuseum",
                column: "MuseumsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocationMineral");

            migrationBuilder.DropTable(
                name: "MineralMuseum");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Minerals");

            migrationBuilder.DropTable(
                name: "Museums");
        }
    }
}
