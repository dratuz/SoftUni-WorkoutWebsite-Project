namespace WorkoutWebsite.Web.Areas.Programs.Models
{
    using System.ComponentModel.DataAnnotations;
    using WorkoutWebsite.Common.Mapping;

    public class ProgramViewModel : IMapFrom<Program>
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Display(Name = "Image URL")]
        [Required]
        [MinLength(10)]
        [MaxLength(2000)]
        public string ImageUrl { get; set; }
    }
}
