namespace WorkoutWebsite.Web.Areas.Programs.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area(AreaConstants.ProgramArea)]
    [Authorize]
    public class ProgramsBaseController : Controller
    {
    }
}
