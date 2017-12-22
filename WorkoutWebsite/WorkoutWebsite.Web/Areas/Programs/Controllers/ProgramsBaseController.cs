namespace WorkoutWebsite.Web.Areas.Programs.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WorkoutWebsite.Web.Infrastructure;

    [Area(GlobalConstants.ProgramArea)]
    [Authorize]
    public class ProgramsBaseController : Controller
    {
    }
}
