using System.Data.Entity.ModelConfiguration;

namespace FluentApiExercise.EntitiesConfiguration
{
    public class GenreConfiguration : EntityTypeConfiguration<Genre>
    {
        public GenreConfiguration()
        {
            // Setting max length
            Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}
