namespace WorkoutWebsite.Services.Models
{
    using System.Collections.Generic;
    using WorkoutWebsite.Common.Mapping;
    using WorkoutWebsite.Data.Models;

    public class ProgramInfoModel : IMapFrom<Program>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }
        
        public IEnumerable<WorkoutProgram> Workouts { get; set; }
    }
}
