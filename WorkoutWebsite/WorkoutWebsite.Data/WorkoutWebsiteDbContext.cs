using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WorkoutWebsite.Data.Models;

namespace WorkoutWebsite.Data
{
    public class WorkoutWebsiteDbContext : IdentityDbContext<User>
    {
        public WorkoutWebsiteDbContext(DbContextOptions<WorkoutWebsiteDbContext> options)
            : base(options)
        {
        }

        public DbSet<Exersise> Exersises { get; set; }

        public DbSet<Workout> Workouts { get; set; }

        public DbSet<Program> Programs { get; set; }

        public DbSet<ExersiseWorkout> ExersiseWorkouts { get; set; }

        public DbSet<WorkoutProgram> WorkoutPrograms { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<WorkoutProgram>()
                .HasKey(wp => new { wp.WorkoutId, wp.ProgramId });

            builder
                .Entity<WorkoutProgram>()
                .HasOne(w => w.Workout)
                .WithMany(w => w.Programs)
                .HasForeignKey(w => w.WorkoutId);

            builder
                .Entity<WorkoutProgram>()
                .HasOne(p => p.Program)
                .WithMany(p => p.Workouts)
                .HasForeignKey(w => w.ProgramId);

            builder
                .Entity<ExersiseWorkout>()
                .HasKey(ew => new { ew.ExersiseId, ew.WorkoutId });

            builder
                .Entity<ExersiseWorkout>()
                .HasOne(e => e.Exersise)
                .WithMany(e => e.Workouts)
                .HasForeignKey(e => e.ExersiseId);

            builder
                .Entity<ExersiseWorkout>()
                .HasOne(w => w.Workout)
                .WithMany(w => w.Exersises)
                .HasForeignKey(w => w.WorkoutId);

            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
