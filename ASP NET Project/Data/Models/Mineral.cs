using ASP_NET_Project.Data.Enum;
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
        public MineralCategory Category { get; set; }
        

        [Required]
        [StringLength(ColorsMaxLength)]
        public string Colors { get; set; } = null!;

        [Required]
        [StringLength(LusterMaxLength)]
        public string Luster { get; set; } = null!;

        [Required]
        public Transparency Transparency { get; set; }

        [Required]
        [StringLength(MohsScaleMaxLength)]
        public string MohsScale{ get; set; } = null!;

        public CrystalSystem CrystalSystem { get; set; }

        [StringLength(CrystalHabitMaxLength)]
        public string? CrystalHabit { get; set; }

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
        public string? ProcessingTips { get; set; }

        public ICollection<Location> Locations { get; set; } = new HashSet<Location>();
        public ICollection<Museum> Museums { get; set; } = new HashSet<Museum>();

    }
}
