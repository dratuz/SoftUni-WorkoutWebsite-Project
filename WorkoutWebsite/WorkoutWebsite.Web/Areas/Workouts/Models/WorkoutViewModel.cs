namespace WorkoutWebsite.Web.Areas.Workouts.Models
{
    using System.ComponentModel.DataAnnotations;
    using WorkoutWebsite.Data.Models.Enums;

    public class WorkoutViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public WorkoutType Type { get; set; }

        [Required]
        public FocusType Focus { get; set; }

        [Required]
        public DifficultyType Difficulty { get; set; }

        [Display(Name = "Image URL")]
        [Required]
        [MinLength(10)]
        [MaxLength(2000)]
        public string ImageUrl { get; set; }
    }
}
