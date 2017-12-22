namespace WorkoutWebsite.Services.Admin.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using WorkoutWebsite.Common.Mapping;
    using WorkoutWebsite.Data.Models;
    using WorkoutWebsite.Services.Admin.Models;

    public interface IAdminUserService: IMapFrom<User>
    {
        IEnumerable<AdminUserInfoModel> All();
    }
}
