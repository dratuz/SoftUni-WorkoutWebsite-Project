namespace WorkoutWebsite.Data.Models
{
    public class ExersiseWorkout
    {
        public int ExersiseId { get; set; }

        public Exersise Exersise { get; set; }

        public int WorkoutId { get; set; }

        public Workout Workout { get; set; }
    }
}
