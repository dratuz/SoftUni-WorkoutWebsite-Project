using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WorkoutWebsite.Data.Models;
using WorkoutWebsite.Services.Admin.Contracts;
using WorkoutWebsite.Web.Areas.Admin.Models;

namespace WorkoutWebsite.Web.Areas.Admin.Controllers
{
    public class UsersController : AdminBaseController
    {
        private readonly IAdminUserService users;

        public UsersController(IAdminUserService users)
        {
            this.users = users;
        }

        public IActionResult Index()
        {
            var result = this.users.All();

            return this.View(result);
        }
    }
}
