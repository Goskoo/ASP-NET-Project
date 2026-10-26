using ASP_NET_Project.Data.Enum;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using static ASP_NET_Project.Data.Constants.ValidationConstants;

namespace ASP_NET_Project.ViewModels
{
    public class MineralFormViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Mineral name is required.")]
        [StringLength(MineralNameMaxLength, MinimumLength = MineralNameMinLength,
            ErrorMessage = "Name must be between {2} and {1} characters.")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Mineral category is required.")]
        public MineralCategory Category { get; set; }

        [Required(ErrorMessage = "Color is required.")]
        [StringLength(ColorsMaxLength, MinimumLength = ColorsMinLength,
            ErrorMessage = "Colors must be between {2} and {1} characters.")]
        public string Colors { get; set; } = null!;

        [Required(ErrorMessage = "Luster is required.")]
        [StringLength(LusterMaxLength, MinimumLength = LusterMinLength,
            ErrorMessage = "Luster must be between {2} and {1} characters.")]
        public string Luster { get; set; } = null!;

        [Required(ErrorMessage = "Transparency is required.")]
        public Transparency Transparency { get; set; }

        [Required(ErrorMessage = "Mohs Scale is required.")]
        [StringLength(MohsScaleMaxLength,
            ErrorMessage = "Mohs Scale must be a maximum of {1} characters.")]
        public string MohsScale { get; set; } = null!;

        public CrystalSystem CrystalSystem { get; set; }

        [StringLength(CleavageMaxLength, ErrorMessage = "Cleavage must be a maximum of {1} characters.")]
        public string? Cleavage { get; set; }

        [StringLength(CrystalHabitMaxLength, ErrorMessage = "Crystal habit must be a maximum of {1} characters.")]
        public string? CrystalHabit { get; set; }

        [StringLength(FractureMaxLength, ErrorMessage = "Fracture must be a maximum of {1} characters.")]
        public string? Fracture { get; set; }

        [StringLength(StreakMaxLength, ErrorMessage = "Streak must be a maximum of {1} characters.")]
        public string? Streak { get; set; }

        [StringLength(DescriptionMaxLength, ErrorMessage = "Description must be a maximum of {1} characters.")]
        public string? Description { get; set; }

        [StringLength(CollectingTipsMaxLength, ErrorMessage = "Collecting tips must be a maximum of {1} characters.")]
        public string? CollectingTips { get; set; }

        [StringLength(TipsMaxLength, ErrorMessage = "Processing tips must be a maximum of {1} characters.")]
        public string? ProcessingTips { get; set; }

        public List<int> SelectedLocationIds { get; set; } = new();


        public List<int> SelectedMuseumIds { get; set; } = new();

        public IEnumerable<SelectListItem> Locations { get; set; } = new List<SelectListItem>();


        public IEnumerable<SelectListItem> Museums { get; set; } = new List<SelectListItem>();
    }
}
