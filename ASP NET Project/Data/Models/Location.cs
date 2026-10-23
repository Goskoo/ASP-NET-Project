using System.ComponentModel.DataAnnotations;
using static ASP_NET_Project.Data.Constants.ValidationConstants;

namespace ASP_NET_Project.Data.Models
{
    public class Location
    {
        public int Id { get; set; }

        [Required]
        [StringLength(CountryMaxLength), MinLength(CountryMinLength)]
        public string Country { get; set; } = null!;

        [Required]
        [StringLength(RegionNameMaxLength), MinLength(RegionNameMinLength)]
        public string RegionName { get; set; } = null!;
        
        [StringLength(MiningHistoryNotesMaxLength)]
        public string? MiningHistoryNotes { get; set; }

        public bool IsActiveMiningSite { get; set; } = true;

        public ICollection<Mineral> Minerals { get; set; } = new HashSet<Mineral>();

    }
}
