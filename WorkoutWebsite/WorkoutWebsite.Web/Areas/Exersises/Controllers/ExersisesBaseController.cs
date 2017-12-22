namespace WorkoutWebsite.Web.Areas.Exersises.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area(AreaConstants.ExersisesArea)]
    [Authorize]
    public class ExersisesBaseController : Controller
    {
    }
}
