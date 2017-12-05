namespace WorkoutWebsite.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using WorkoutWebsite.Data.Models.Enums;

    public class Workout
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

        public List<ExersiseWorkout> Exersises { get; set; } = new List<ExersiseWorkout>();

        public List<WorkoutProgram> Programs { get; set; } = new List<WorkoutProgram>();
    }
}
