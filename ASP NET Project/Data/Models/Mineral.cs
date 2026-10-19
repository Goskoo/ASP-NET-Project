using System.ComponentModel.DataAnnotations;
using static ASP_NET_Project.Data.Constants.ValidationConstants;

namespace ASP_NET_Project.Data.Models
{
    public class Mineral
    {
        public int Id { get; set; }
        [Required]
        [StringLength(MineralNameMaxLength, MinimumLength = MineralNameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(CategoryMaxLength)]
        public string Category { get; set; } = null!;
        

        [Required]
        [StringLength(ColorsMaxLength)]
        public string Colors { get; set; } = null!;

        [Required]
        [StringLength(LusterMaxLength)]
        public string Luster { get; set; } = null!;

        [Required]
        [StringLength(TransparencyMaxLength)]
        public string Transparency { get; set; } = null!;

        [Required]
        [StringLength(MohsScaleMaxLength)]
        public string MohsScale{ get; set; } = null!;

        [StringLength(CrystalSystemMaxLength)]
        public string? CrystalSystem { get; set; }

        [StringLength(CrystalHabitMaxLength)]
        public string? Crystalhabit { get; set; }

        [StringLength(CleavageMaxLength)]
        public string? Cleavage { get; set; }

        [StringLength(FractureMaxLength)]
        public string? Fracture { get; set; }

        [StringLength(StreakMaxLength)]
        public string? Streak { get; set; }

        [StringLength(DescriptionMaxLength)]
        public string? Description { get; set; }

        [StringLength(CollectingTipsMaxLength)]
        public string? CollectingTips { get; set; }

        [StringLength(TipsMaxLength)]
        public string? ProcessingTIps { get; set; }

        [Required]
        public int LocationId { get; set; }

        public Location Location { get; set; } = null!;
        
        [Required]
        public int MuseumId { get; set; }

        public Museum Museum { get; set; } = null!;

    }
}
