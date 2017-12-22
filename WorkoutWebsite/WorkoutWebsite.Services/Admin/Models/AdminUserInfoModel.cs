namespace WorkoutWebsite.Services.Admin.Models
{
    using WorkoutWebsite.Common.Mapping;
    using WorkoutWebsite.Data.Models;

    public class AdminUserInfoModel : IMapFrom<User>
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }
    }
}
