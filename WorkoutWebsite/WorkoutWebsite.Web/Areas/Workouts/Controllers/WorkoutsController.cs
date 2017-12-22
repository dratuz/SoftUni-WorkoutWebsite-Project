namespace WorkoutWebsite.Web.Areas.Workouts.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using WorkoutWebsite.Data.Models;
    using WorkoutWebsite.Services.Contracts;
    using WorkoutWebsite.Web.Areas.Workouts.Models;
    using WorkoutWebsite.Web.Infrastructure;

    public class WorkoutsController : WorkoutsBaseController
    {
        private readonly IWorkoutService workouts;

        public WorkoutsController(IWorkoutService workouts)
        {
            this.workouts = workouts;
        }
        
        public IActionResult All()
        {
            var allWorkouts = this.workouts.All();

            return this.View(allWorkouts);
        }

        [Authorize(Roles = RoleConstants.AdminRole)]
        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize(Roles = RoleConstants.AdminRole)]
        public IActionResult Add(WorkoutViewModel workoutModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View(workoutModel);
            }

            this.workouts.Create(
                workoutModel.Name,
                workoutModel.Type,
                workoutModel.Focus,
                workoutModel.Difficulty,
                workoutModel.ImageUrl);

            return RedirectToAction(nameof(this.All));
        }

        [Authorize(Roles = RoleConstants.AdminRole)]
        public IActionResult Edit(int id)
        {
            var workout = this.workouts.GetWorkoutById(id);

            if (workout == null)
            {
                return this.NotFound();
            }

            return this.View(new WorkoutViewModel
            {
                Name = workout.Name,
                Type = workout.Type,
                Focus = workout.Focus,
                Difficulty = workout.Difficulty,
                ImageUrl = workout.ImageUrl
            });
        }

        [HttpPost]
        [Authorize(Roles = RoleConstants.AdminRole)]
        public IActionResult Edit(int id, WorkoutViewModel workoutModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View(workoutModel);
            }

            this.workouts.Edit(
                id,
                workoutModel.Name,
                workoutModel.Type,
                workoutModel.Focus,
                workoutModel.Difficulty,
                workoutModel.ImageUrl);

            return this.RedirectToAction(nameof(this.All));
        }

        [Authorize(Roles = RoleConstants.AdminRole)]
        public IActionResult Delete(int id)
        {
            return this.View(id);
        }

        [Authorize(Roles = RoleConstants.AdminRole)]
        public IActionResult Destroy(int id)
        {
            this.workouts.Delete(id);

            return this.RedirectToAction(nameof(this.All));
        }

        public IActionResult Details(int id)
        {
            var workout = this.workouts.GetWorkoutById(id);

            return this.View(workout);
        }
    }
}
