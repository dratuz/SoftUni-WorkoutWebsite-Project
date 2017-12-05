namespace WorkoutWebsite.Data.Models
{
    public class WorkoutProgram
    {
        public int WorkoutId { get; set; }

        public Workout Workout { get; set; }

        public int ProgramId { get; set; }

        public Program Program { get; set; }
    }
}
