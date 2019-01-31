using System.Collections.Generic;

namespace FluentApiExercise
{
    public class Tag
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public ICollection<Video> Videos { get; set; }
    }
}
