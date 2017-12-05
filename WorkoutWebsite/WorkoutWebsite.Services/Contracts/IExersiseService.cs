namespace WorkoutWebsite.Services.Contracts
{
    using WorkoutWebsite.Data.Models.Enums;

    public interface IExersiseService
    {
        void Create(string name, MuscleGroupType muscleGroup, string imageUrl);
    }
}
