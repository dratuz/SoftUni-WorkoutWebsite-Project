namespace WorkoutWebsite.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using System.Collections.Generic;
    using System.Linq;
    using WorkoutWebsite.Data;
    using WorkoutWebsite.Data.Models;
    using WorkoutWebsite.Services.Contracts;
    using WorkoutWebsite.Services.Models;

    public class ProgramService : IProgramService
    {
        private readonly WorkoutWebsiteDbContext db;

        public ProgramService(WorkoutWebsiteDbContext db)
        {
            this.db = db;
        }

        public void Create(string name, string imageUrl)
        {
            var program = new Program
            {
                Name = name,
                ImageUrl = imageUrl
            };

            this.db.Programs.Add(program);
            this.db.SaveChanges();
        }

        public IEnumerable<ProgramInfoModel> All()
        {
            var programs = this.db.Programs
                .ProjectTo<ProgramInfoModel>()
                .ToList();

            return programs;
        }

        public ProgramInfoModel GetProgramById(int id)
        {
            var program = this.db.Programs
                .ProjectTo<ProgramInfoModel>()
                .FirstOrDefault(w => w.Id == id);

            return program;
        }
    }
}
