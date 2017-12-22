namespace WorkoutWebsite.Web.Areas.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using WorkoutWebsite.Data.Models;
    using WorkoutWebsite.Services.Contracts;
    using WorkoutWebsite.Web.Areas.Exersises.Controllers;
    using WorkoutWebsite.Web.Areas.Models.ExersiseViewModels;
    using WorkoutWebsite.Web.Infrastructure;

    public class ExersisesController : ExersisesBaseController
    {
        private readonly IExersiseService exersises;
        private readonly UserManager<User> userManager;

        public ExersisesController(
            IExersiseService exersises,
            UserManager<User> userManager)
        {
            this.exersises = exersises;
            this.userManager = userManager;
        }
        
        [Authorize(Roles = RoleConstants.AdminRole)]
        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize(Roles = RoleConstants.AdminRole)]
        public IActionResult Add(ExersiseViewModel exersiseModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View(exersiseModel);
            }

            this.exersises.Create(
                exersiseModel.Name,
                exersiseModel.MuscleGroups,
                exersiseModel.ImageUrl);

            return this.RedirectToAction(nameof(this.All));
        }

        [Authorize(Roles = RoleConstants.AdminRole)]
        public IActionResult Edit(int id)
        {
            var exersise = this.exersises.ById(id);

            if (exersise == null)
            {
                return this.NotFound();
            }

            return this.View(new ExersiseViewModel
            {
                Name = exersise.Name,
                MuscleGroups = exersise.MuscleGroups,
                ImageUrl = exersise.ImageUrl,
                IsEdit = true
            });
        }

        [HttpPost]
        [Authorize(Roles = RoleConstants.AdminRole)]
        public IActionResult Edit(int id, ExersiseViewModel exersiseModel)
        {
            if (!ModelState.IsValid)
            {
                exersiseModel.IsEdit = true;
                return this.View(exersiseModel);
            }

            this.exersises.Edit(
                id,
                exersiseModel.Name, 
                exersiseModel.MuscleGroups, 
                exersiseModel.ImageUrl);

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
            this.exersises.Delete(id);

            return this.RedirectToAction(nameof(this.All));
        }
        
        public IActionResult All()
        {
            var allExersises = this.exersises.All();

            return this.View(allExersises);
        }
    }
}
