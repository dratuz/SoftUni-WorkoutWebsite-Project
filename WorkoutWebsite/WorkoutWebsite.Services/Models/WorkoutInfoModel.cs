namespace WorkoutWebsite.Services.Models
{
    using System;
    using System.Collections.Generic;
    using WorkoutWebsite.Common.Mapping;
    using WorkoutWebsite.Data.Models;
    using WorkoutWebsite.Data.Models.Enums;

    public class WorkoutInfoModel : IMapFrom<Workout>
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public WorkoutType Type { get; set; }
        
        public FocusType Focus { get; set; }
        
        public DifficultyType Difficulty { get; set; }

        public string ImageUrl { get; set; }

        public DateTime DateTime { get; set; }
    }
}
