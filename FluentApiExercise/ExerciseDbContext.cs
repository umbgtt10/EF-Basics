using System.Data.Entity;
using FluentApiExercise.EntitiesConfiguration;

namespace FluentApiExercise
{
    public partial class ExerciseDbContext : DbContext
    {
        public ExerciseDbContext()
          : base("name=ExerciseDb")
        {
        }

        public virtual DbSet<Video> Videos { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new VideoConfiguration());
            modelBuilder.Configurations.Add(new GenreConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
