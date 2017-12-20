namespace WorkoutWebsite.Web.Areas.Exersises.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WorkoutWebsite.Web.Infrastructure;

    [Area(GlobalConstants.ExersisesArea)]
    [Authorize]
    public class ExersisesBaseController : Controller
    {
    }
}
