using System.ComponentModel.DataAnnotations;
using static ASP_NET_Project.Data.Constants.ValidationConstants;

namespace ASP_NET_Project.Data.Models
{
    public class Museum
    {
        public int Id { get; set; }

        [Required]
        [StringLength(MuseumNameMaxLength, MinimumLength = MuseumNameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(CityMaxLength, MinimumLength = CityMinLength)]
        public string City{ get; set; } = null!;

        [Required]
        [StringLength(CountryMaxLength, MinimumLength = CountryMinLength)]
        public string Country { get; set; } = null!;

        [StringLength(DescriptionMaxLengthMuseum)]
        public string? Description { get; set; }

        public ICollection<Mineral> Minerals { get; set; } = new List<Mineral>();
    }
}
