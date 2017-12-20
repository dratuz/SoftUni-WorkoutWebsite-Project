namespace WorkoutWebsite.Web.Areas.Models.ExersiseViewModels
{
    using System.ComponentModel.DataAnnotations;
    using WorkoutWebsite.Common.Mapping;
    using WorkoutWebsite.Data.Models;
    using WorkoutWebsite.Data.Models.Enums;

    public class ExersiseViewModel : IMapFrom<Exersise>
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public MuscleGroupType MuscleGroups { get; set; }

        [Display(Name = "Image URL")]
        [Required]
        [MinLength(10)]
        [MaxLength(2000)]
        public string ImageUrl { get; set; }

        public bool IsEdit { get; set; }
    }
}
