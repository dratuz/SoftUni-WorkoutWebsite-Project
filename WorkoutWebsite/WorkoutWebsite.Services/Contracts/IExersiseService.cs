namespace WorkoutWebsite.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using WorkoutWebsite.Data.Models.Enums;
    using WorkoutWebsite.Services.Models;

    public interface IExersiseService
    {
        void Create(string name, MuscleGroupType muscleGroup, string imageUrl);
        
        void Edit(int id, string name, MuscleGroupType muscleGroup, string imageUrl);

        void Delete(int id);

        ExersiseInfoModel ById(int id);

        IEnumerable<ExersiseInfoModel> All();
    }
}
