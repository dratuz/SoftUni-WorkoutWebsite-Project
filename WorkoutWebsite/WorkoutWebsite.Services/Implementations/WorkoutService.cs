namespace WorkoutWebsite.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using WorkoutWebsite.Data;
    using WorkoutWebsite.Data.Models;
    using WorkoutWebsite.Data.Models.Enums;
    using WorkoutWebsite.Services.Contracts;
    using WorkoutWebsite.Services.Models;

    public class WorkoutService : IWorkoutService
    {
        private readonly WorkoutWebsiteDbContext db;

        public WorkoutService(WorkoutWebsiteDbContext db)
        {
            this.db = db;
        }

        public void Create(
            string name,
            WorkoutType type,
            FocusType focus,
            DifficultyType difficulty,
            string imageUrl)
        {
            var workout = new Workout
            {
                Name = name,
                Type = type,
                Focus = focus,
                Difficulty = difficulty,
                ImageUrl = imageUrl,
                DateTime = DateTime.Now
            };

            this.db.Workouts.Add(workout);
            this.db.SaveChanges();
        }

        public void Edit(
            int id,
            string name,
            WorkoutType type,
            FocusType focus,
            DifficultyType difficulty,
            string imageUrl)
        {
            var workout = this.db.Workouts.Find(id);

            if (workout == null)
            {
                return;
            }

            workout.Name = name;
            workout.Type = type;
            workout.Focus = focus;
            workout.Difficulty = difficulty;
            workout.ImageUrl = imageUrl;

            this.db.SaveChanges();
        }

        public void Delete(int id)
        {
            var workout = this.db.Workouts.Find(id);

            if (workout == null)
            {
                return;
            }

            this.db.Workouts.Remove(workout);
            this.db.SaveChanges();
        }

        public IEnumerable<WorkoutInfoModel> All()
        {
            var workouts = this.db.Workouts
                .ProjectTo<WorkoutInfoModel>()
                .ToList();

            return workouts;
        }

        public WorkoutInfoModel GetWorkoutById(int id)
        {
            var workout = this.db.Workouts
                .ProjectTo<WorkoutInfoModel>()
                .FirstOrDefault(w => w.Id == id);

            return workout;
        }
    }
}
