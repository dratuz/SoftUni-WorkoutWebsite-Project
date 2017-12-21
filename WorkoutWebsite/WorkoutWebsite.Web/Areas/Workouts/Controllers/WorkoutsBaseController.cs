namespace WorkoutWebsite.Web.Areas.Workouts.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WorkoutWebsite.Web.Infrastructure;

    [Area(GlobalConstants.WorkoutArea)]
    [Authorize]
    public class WorkoutsBaseController : Controller
    {
    }
}
