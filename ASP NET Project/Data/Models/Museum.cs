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

        [StringLength(CityCountryMaxLength)]
        public string City{ get; set; } = null!;

        public string Description { get; set; } =null!;

        public ICollection<Mineral> Minerals { get; set; } = new List<Mineral>();
    }
}
