namespace WorkoutWebsite.Web.Areas.Admin.Models
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;
    using WorkoutWebsite.Services.Admin.Models;

    public class AdminUserViewModel
    {
        public IEnumerable<AdminUserInfoModel> Users { get; set; }

        public IEnumerable<SelectListItem> Roles { get; set; }
    }
}
