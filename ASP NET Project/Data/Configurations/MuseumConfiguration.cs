using ASP_NET_Project.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASP_NET_Project.Data.Configurations
{
    public class MuseumConfiguration : IEntityTypeConfiguration<Museum>
    {
        public readonly IEnumerable<Museum> museums = new List<Museum>
        {
            new Museum
            {
                Id = 1,
                Name = "Smithsonian National Museum of Natural History",
                City = "Washington D.C.",
                Country = "USA",
                Description = "The Smithsonian National Museum of Natural History is one of the most renowned natural history museums in the world, located in the heart of Washington D.C. It houses a vast collection of specimens and artifacts related to natural history, including fossils, minerals, plants, animals, and cultural artifacts.",

            },
            new Museum
            {
                Id = 2,
                Name = "Australian Museum",
                City = "Sydney",
                Country = "Australia",
                Description = "The Australian Museum, located in Sydney, is the oldest museum in Australia and is dedicated to natural history and anthropology. It features extensive collections of minerals, fossils, and cultural artifacts from Australia and the Pacific region.",

            },
            new Museum
            {
                Id = 3,
                Name = "Ditsong National Museum of Natural History",
                City = "Pretoria",
                Country = "South Africa",
                Description = "The Ditsong National Museum of Natural History, located in Pretoria, South Africa, is a leading institution for the study and preservation of natural history. It houses a diverse collection of minerals, fossils, and other specimens that showcase the rich biodiversity and geological history of South Africa.",

            }
        };

        public void Configure(EntityTypeBuilder<Museum> builder)
        {


            builder.HasData(museums);
        }
    }
}
