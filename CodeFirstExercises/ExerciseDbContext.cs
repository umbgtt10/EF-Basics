using System.Data.Entity;

namespace CodeFirstExercise
{
    public partial class VidzyDbContext : DbContext
    {
        public VidzyDbContext()
          : base("name=VidzyDbConnection")
        {
        }

        public virtual DbSet<Video> Videos { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
    }
}
