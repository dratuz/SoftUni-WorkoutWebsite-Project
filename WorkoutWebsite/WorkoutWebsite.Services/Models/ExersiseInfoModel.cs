namespace WorkoutWebsite.Services.Models
{
    using WorkoutWebsite.Common.Mapping;
    using WorkoutWebsite.Data.Models;
    using WorkoutWebsite.Data.Models.Enums;

    public class ExersiseInfoModel : IMapFrom<Exersise>
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public MuscleGroupType MuscleGroups { get; set; }
        
        public string ImageUrl { get; set; }
    }
}
