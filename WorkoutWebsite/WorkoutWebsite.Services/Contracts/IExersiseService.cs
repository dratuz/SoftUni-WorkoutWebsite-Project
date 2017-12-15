namespace WorkoutWebsite.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using WorkoutWebsite.Data.Models.Enums;
    using WorkoutWebsite.Services.Models;

    public interface IExersiseService
    {
        void Create(string name, MuscleGroupType muscleGroup, string imageUrl);
        
        void Edit(int Id, string name, MuscleGroupType muscleGroup, string imageUrl);

        void Delete(int Id);

        ExersiseInfoModel ById(int Id);

        Task<IEnumerable<ExersiseInfoModel>> AllAsync();
    }
}
