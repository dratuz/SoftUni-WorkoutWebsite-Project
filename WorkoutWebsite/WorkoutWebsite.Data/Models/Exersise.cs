namespace WorkoutWebsite.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using WorkoutWebsite.Data.Models.Enums;

    public class Exersise
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

        public string UserId { get; set; }

        public User User { get; set; }

        public List<ExersiseWorkout> Workouts { get; set; } = new List<ExersiseWorkout>();
    }
}
