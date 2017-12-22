namespace WorkoutWebsite.Web.Areas.Workouts.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area(AreaConstants.WorkoutArea)]
    [Authorize]
    public class WorkoutsBaseController : Controller
    {
    }
}
