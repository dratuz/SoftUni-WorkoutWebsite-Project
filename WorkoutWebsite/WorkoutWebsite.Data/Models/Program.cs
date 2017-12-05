namespace WorkoutWebsite.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Program
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Name { get; set; }

        public List<WorkoutProgram> Workouts { get; set; } = new List<WorkoutProgram>();
    }
}
