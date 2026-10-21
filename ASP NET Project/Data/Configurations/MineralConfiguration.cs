using ASP_NET_Project.Data.Enum;
using ASP_NET_Project.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASP_NET_Project.Data.Configurations
{
    public class MineralConfiguration : IEntityTypeConfiguration<Mineral>
    {
        public readonly IEnumerable<Mineral> minerals = new List<Mineral>
        {
            new Mineral
            {
                Id = 1,
                Name = "Quartz",
                Category = MineralCategory.Silicate,
                Colors = "Colorless, white, purple, pink, yellow, brown, black",
                Luster = "Vitreous",
                Transparency = Transparency.Transparent,
                MohsScale = "7",
                CrystalSystem = CrystalSystem.Rhombohedral,
                CrystalHabit = "Six-sided prismatic crystals with pyramidal terminations",
                Cleavage = "None",
                Fracture = "Conchoidal",
                Streak = "White",
                Description = "Quartz is one of the most abundant minerals in the Earth's crust, made of silicon and oxygen. It forms many popular varieties such as amethyst, citrine and rose quartz.",
                CollectingTips = "Look in granite pegmatites, hydrothermal veins and geodes. Crystals are often found loose in weathered soil near veins.",
                ProcessingTips = "Rinse with water and a soft brush. Avoid harsh acids on specimens with other minerals attached.",

            },
            new Mineral
            {
                Id = 2,
                Name = "Calcite",
                Category = MineralCategory.Carbonate,
                Colors = "Colorless, white, yellow, orange, blue, green",
                Luster = "Vitreous",
                Transparency = Transparency.Transparent,
                MohsScale = "3",
                CrystalSystem = CrystalSystem.Rhombohedral,
                CrystalHabit = "Rhombohedral, scalenohedral (dogtooth) and massive forms",
                Cleavage = "Perfect rhombohedral in three directions",
                Fracture = "Conchoidal",
                Streak = "White",
                Description = "Calcite is a calcium carbonate mineral found in limestone, marble and cave formations. It is famous for strong double refraction and its reaction with dilute acid.",
                CollectingTips = "Common in limestone quarries, caves and hydrothermal veins. Handle carefully because it is soft and cleaves easily.",
                ProcessingTips = "Never use acid to clean it, as it will dissolve. Use water and a soft brush only.",

            },
            new Mineral
            {
                Id = 3,
                Name = "Pyrite",
                Category = MineralCategory.Sulfide,
                Colors = "Pale brass-yellow",
                Luster = "Metallic",
                Transparency = Transparency.Opaque,
                MohsScale = "6-6.5",
                CrystalSystem = CrystalSystem.Cubic,
                CrystalHabit = "Cubes, pyritohedrons and octahedrons",
                Cleavage = "Indistinct",
                Fracture = "Uneven to conchoidal",
                Streak = "Greenish-black to brownish-black",
                Description = "Pyrite, often called fool's gold, is an iron sulfide with a bright metallic luster. It is the most common sulfide mineral and forms in many geological environments.",
                CollectingTips = "Found in sedimentary rocks, coal seams and hydrothermal veins. Collect dry specimens and store them away from moisture.",
                ProcessingTips = "Keep in a low-humidity place, since pyrite can oxidize and decay over time.",

            },
            new Mineral
            {
                Id = 4,
                Name = "Fluorite",
                Category = MineralCategory.Halide,
                Colors = "Purple, green, blue, yellow, colorless, pink",
                Luster = "Vitreous",
                Transparency = Transparency.Transparent,
                MohsScale = "4",
                CrystalSystem = CrystalSystem.Cubic,
                CrystalHabit = "Cubes and octahedrons, often with interpenetrating twins",
                Cleavage = "Perfect octahedral in four directions",
                Fracture = "Subconchoidal to uneven",
                Streak = "White",
                Description = "Fluorite is a calcium fluoride mineral known for its wide range of colors and for fluorescing under ultraviolet light.",
                CollectingTips = "Occurs in hydrothermal veins and carbonate rocks. Wrap specimens well, because they break easily along cleavage planes.",
                ProcessingTips = "Clean gently with water. Avoid prolonged sunlight, which can fade some colors.",

            },
            new Mineral
            {
                Id = 5,
                Name = "Hematite",
                Category = MineralCategory.Oxide,
                Colors = "Steel-gray, silver, reddish-brown, black",
                Luster = "Metallic to earthy",
                Transparency = Transparency.Opaque,
                MohsScale = "5-6.5",
                CrystalSystem = CrystalSystem.Rhombohedral,
                CrystalHabit = "Tabular crystals, rosettes, botryoidal and massive forms",
                Cleavage = "None",
                Fracture = "Uneven to subconchoidal",
                Streak = "Red to reddish-brown",
                Description = "Hematite is an iron oxide and the most important ore of iron. Its red streak is the key way to identify it, even when the specimen looks black or gray.",
                CollectingTips = "Found in banded iron formations, sedimentary deposits and volcanic environments.",
                ProcessingTips = "Clean with water and a soft brush. It is stable and does not need special storage.",

            }
        };

        public void Configure(EntityTypeBuilder<Mineral> builder)
        {
            builder.HasMany(m => m.Locations)
                .WithMany(l => l.Minerals)
                .UsingEntity(j => j.HasData(
                    new { MineralsId = 1, LocationsId = 1 },
                    new { MineralsId = 1, LocationsId = 2 },
                    new { MineralsId = 1, LocationsId = 3 },
                    new { MineralsId = 2, LocationsId = 2 },
                    new { MineralsId = 2, LocationsId = 3 },
                    new { MineralsId = 3, LocationsId = 1 },
                    new { MineralsId = 3, LocationsId = 3 },
                    new { MineralsId = 4, LocationsId = 1 },
                    new { MineralsId = 5, LocationsId = 2 },
                    new { MineralsId = 5, LocationsId = 3 }));

            builder.HasMany(m => m.Museums)
                .WithMany(mu => mu.Minerals)
                .UsingEntity(j => j.HasData(
                    new { MineralsId = 1, MuseumsId = 1 },
                    new { MineralsId = 1, MuseumsId = 2 },
                    new { MineralsId = 1, MuseumsId = 3 },
                    new { MineralsId = 2, MuseumsId = 2 },
                    new { MineralsId = 3, MuseumsId = 1 },
                    new { MineralsId = 3, MuseumsId = 3 },
                    new { MineralsId = 4, MuseumsId = 1 },
                    new { MineralsId = 4, MuseumsId = 2 },
                    new { MineralsId = 5, MuseumsId = 2 },
                    new { MineralsId = 5, MuseumsId = 3 }));

            builder.HasData(minerals);
        }
    }
}