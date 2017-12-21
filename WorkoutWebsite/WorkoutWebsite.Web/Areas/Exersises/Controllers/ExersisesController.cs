namespace WorkoutWebsite.Web.Areas.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using WorkoutWebsite.Services.Contracts;
    using WorkoutWebsite.Web.Areas.Exersises.Controllers;
    using WorkoutWebsite.Web.Areas.Models.ExersiseViewModels;

    public class ExersisesController : ExersisesBaseController
    {
        private readonly IExersiseService exersises;

        public ExersisesController(IExersiseService exersises)
        {
            this.exersises = exersises;
        }
        
        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
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
        
        public IActionResult Delete(int id)
        {
            return this.View(id);
        }
        
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
