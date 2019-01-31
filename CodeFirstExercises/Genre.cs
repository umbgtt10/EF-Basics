using System.Collections.Generic;

namespace CodeFirstExercise
{
    public class Genre
    {
        public int Id { get; set; }
        public ICollection<Video> Videos { get; set; }
    }
}
