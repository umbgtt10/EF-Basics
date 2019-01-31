using System;
using System.Collections.Generic;

namespace FluentApiExercise
{
    public class Video
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public Genre Genres { get; set; }
        public int GenreId { get; set; }
        public Classification Classification { get; set; }
        public ICollection<Tag> Tags { get; set; }
    }
}
