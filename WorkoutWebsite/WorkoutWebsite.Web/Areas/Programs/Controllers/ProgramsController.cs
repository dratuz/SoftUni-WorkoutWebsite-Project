namespace WorkoutWebsite.Web.Areas.Programs.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WorkoutWebsite.Services.Contracts;
    using WorkoutWebsite.Web.Areas.Programs.Models;
    using WorkoutWebsite.Web.Infrastructure;

    public class ProgramsController : ProgramsBaseController
    {
        private readonly IProgramService programs;

        public ProgramsController(IProgramService programs)
        {
            this.programs = programs;
        }

        [Authorize(Roles = RoleConstants.AdminRole)]
        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize(Roles = RoleConstants.AdminRole)]
        public IActionResult Add(ProgramViewModel programModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View(programModel);
            }

            this.programs.Create(
                programModel.Name,
                programModel.ImageUrl);

            return this.RedirectToAction(nameof(this.All));
        }

        public IActionResult All()
        {
            var allPrograms = this.programs.All();

            return this.View(allPrograms);
        }

        public IActionResult Details(int id)
        {
            var program = this.programs.GetProgramById(id);

            return this.View(program);
        }
    }
}
