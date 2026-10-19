namespace ASP_NET_Project.Data.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Country { get; set; } = null!;
        
        public string RegionName { get; set; } = null!;

        public string? MiningHistoryNotes { get; set; }

        public bool IsActiveMiningSite { get; set; } = true;

        public ICollection<Mineral> Minerals { get; set; } = new HashSet<Mineral>();

    }
}
