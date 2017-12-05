namespace WorkoutWebsite.Services.Implementations
{
    using WorkoutWebsite.Data;
    using WorkoutWebsite.Data.Models;
    using WorkoutWebsite.Data.Models.Enums;
    using WorkoutWebsite.Services.Contracts;

    public class ExersiseService : IExersiseService
    {
        private readonly WorkoutWebsiteDbContext db;

        public ExersiseService(WorkoutWebsiteDbContext db)
        {
            this.db = db;
        }

        public void Create(string name, MuscleGroupType muscleGroup, string imageUrl)
        {
            Exersise exersise = new Exersise
            {
                Name = name,
                MuscleGroups = muscleGroup,
                ImageUrl = imageUrl
            };

            this.db.Exersises.Add(exersise);
            this.db.SaveChanges();
        }
    }
}
