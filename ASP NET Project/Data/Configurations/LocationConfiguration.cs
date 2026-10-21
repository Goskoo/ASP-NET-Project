using ASP_NET_Project.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASP_NET_Project.Data.Configurations
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public readonly IEnumerable<Location> locations = new List<Location>
        {
            new Location
            {
                Id = 1,
                Country = "USA",
                RegionName = "California",
                MiningHistoryNotes = "California has a rich mining history, particularly during the Gold Rush era.",
                IsActiveMiningSite = true
            },
            new Location
            {
                Id = 2,
                Country = "Australia",
                RegionName = "New South Wales",
                MiningHistoryNotes = "New South Wales is known for its coal mining industry.",
                IsActiveMiningSite = true
            },
            new Location
            {
                Id = 3,
                Country = "South Africa",
                RegionName = "Gauteng",
                MiningHistoryNotes = "Gauteng is famous for its gold and diamond mines.",
                IsActiveMiningSite = false
            }
        };

        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasData(locations);
        }
    }
}
