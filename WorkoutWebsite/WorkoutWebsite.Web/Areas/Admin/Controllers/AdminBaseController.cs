namespace WorkoutWebsite.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WorkoutWebsite.Web.Infrastructure;

    [Area(GlobalConstants.AdminArea)]
    [Authorize(Roles = GlobalConstants.AdminRole)]
    public class AdminBaseController : Controller
    {
    }
}
