namespace WorkoutWebsite.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WorkoutWebsite.Services.Contracts;
    using WorkoutWebsite.Web.Models.ExersiseViewModels;

    public class ExersisesController : Controller
    {
        private readonly IExersiseService exersises;

        public ExersisesController(IExersiseService exersises)
        {
            this.exersises = exersises;
        }

        [Authorize]
        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
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

            return this.RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
