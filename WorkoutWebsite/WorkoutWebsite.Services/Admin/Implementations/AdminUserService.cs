namespace WorkoutWebsite.Services.Admin.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using WorkoutWebsite.Data;
    using WorkoutWebsite.Services.Admin.Contracts;
    using WorkoutWebsite.Services.Admin.Models;

    public class AdminUserService : IAdminUserService
    {
        private readonly WorkoutWebsiteDbContext db;

        public AdminUserService(WorkoutWebsiteDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<AdminUserInfoModel> All()
        {
            var result = this.db.Users
                .ProjectTo<AdminUserInfoModel>()
                .ToList();

            return result;
        }
    }
}
