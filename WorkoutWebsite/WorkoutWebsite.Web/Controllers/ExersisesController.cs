namespace WorkoutWebsite.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
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

        [Authorize]
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
        [Authorize]
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

        [Authorize]
        public IActionResult Delete(int id)
        {
            return this.View(id);
        }
        
        [Authorize]
        public IActionResult Destory(int id)
        {
            this.exersises.Delete(id);

            return this.RedirectToAction(nameof(this.All));
        }
        
        public async Task<IActionResult> All()
        {
            var allExersises = await this.exersises.AllAsync();

            return this.View(allExersises);
        }
    }
}
