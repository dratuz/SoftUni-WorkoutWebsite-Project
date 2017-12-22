namespace WorkoutWebsite.Services.Contracts
{
    using System.Collections.Generic;
    using WorkoutWebsite.Services.Models;

    public interface IProgramService
    {
        void Create(
            string name,
            string imageUrl);

        IEnumerable<ProgramInfoModel> All();

        ProgramInfoModel GetProgramById(int id);
    }
}
