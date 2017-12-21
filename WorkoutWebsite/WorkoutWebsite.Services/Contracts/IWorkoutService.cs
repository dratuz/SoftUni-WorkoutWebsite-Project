namespace WorkoutWebsite.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using WorkoutWebsite.Data.Models;
    using WorkoutWebsite.Data.Models.Enums;
    using WorkoutWebsite.Services.Models;

    public interface IWorkoutService
    {
        void Create(
            string name,
            WorkoutType type, 
            FocusType focus, 
            DifficultyType difficulty,
            string imageUrl);

        void Edit(
            int id,
            string name,
            WorkoutType type,
            FocusType focus,
            DifficultyType difficulty,
            string imageUrl);

        void Delete(int id);

        IEnumerable<WorkoutInfoModel> All();

        WorkoutInfoModel GetWorkoutById(int id);
    }
}
