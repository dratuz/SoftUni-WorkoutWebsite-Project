namespace WorkoutWebsite.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WorkoutWebsite.Web.Infrastructure;

    [Area(AreaConstants.AdminArea)]
    [Authorize(Roles = RoleConstants.AdminRole)]
    public class AdminBaseController : Controller
    {
    }
}
