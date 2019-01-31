using System.Data.Entity.ModelConfiguration;

namespace FluentApiExercise.EntitiesConfiguration
{
    public class VideoConfiguration : EntityTypeConfiguration<Video>
    {
        public VideoConfiguration()
        {
            // Setting max length
            Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(255);

            // Overriding the column name to GenreId instead of Genre_Id
            Property(p => p.GenreId)
                .HasColumnName("GenreId");

            // Setting a custom type for this column
            Property(p => p.Classification)
                .HasColumnType("tinyint");

            // Renaming the table's name to VideoTags instead of TagVideos.
            // Setting the n-n relationship.
            // Setting the foreign keys
            HasMany(c => c.Tags)
                .WithMany(c => c.Videos)
                .Map(m =>
                    {
                        m.ToTable("VideoTags");
                        m.MapLeftKey("VideoId");
                        m.MapRightKey("TagsId");
                    }
                );
        }
    }
}
