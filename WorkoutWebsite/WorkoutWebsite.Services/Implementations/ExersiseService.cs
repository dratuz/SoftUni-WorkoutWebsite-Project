namespace WorkoutWebsite.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using WorkoutWebsite.Data;
    using WorkoutWebsite.Data.Models;
    using WorkoutWebsite.Data.Models.Enums;
    using WorkoutWebsite.Services.Contracts;
    using WorkoutWebsite.Services.Models;

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

        public void Edit(int Id, string name, MuscleGroupType muscleGroup, string imageUrl)
        {
            var exersise = this.db.Exersises.Find(Id);

            if (exersise == null)
            {
                return;
            }

            exersise.Name = name;
            exersise.MuscleGroups = muscleGroup;
            exersise.ImageUrl = imageUrl;

            this.db.SaveChanges();
        }

        public void Delete(int Id)
        {
            var exersise = this.db.Exersises.Find(Id);

            if (exersise == null)
            {
                return;
            }

            this.db.Exersises.Remove(exersise);
            this.db.SaveChanges();
        }

        public ExersiseInfoModel ById(int Id)
        {
            var result = this.db.Exersises
                .Where(a => a.Id == Id)
                .ProjectTo<ExersiseInfoModel>()
                .FirstOrDefault();

            return result;
        }

        public async Task<IEnumerable<ExersiseInfoModel>> AllAsync()
        {
            var exersises = await this.db.Exersises
                .ProjectTo<ExersiseInfoModel>()
                .ToListAsync();

            return exersises;
        }
    }
}
