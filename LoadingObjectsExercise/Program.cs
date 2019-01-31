using System;
using System.Data.Entity;
using System.Linq;

namespace LoadingObjectsExercise
{
    class Program
    {
        private static void EagerLoading()
        {
            var context = new VidzyContext();

            var videos = context.Videos.Include(e => e.Genre);

            foreach (var video in videos)
            {
                Console.WriteLine("Name:" + video.Name);
                Console.WriteLine("Genre:" + video.Genre.Name);
            }
        }

        static private void ExplicitLoading()
        {
            var context = new VidzyContext();

            var expression = context.Videos.Where(g => g.Id == 2);
            expression.Load();

            foreach (var video in expression)
            {
                Console.WriteLine("Name:" + video.Name);
                Console.WriteLine("Genre:" + context.Genres.Single(g => g.Id == video.GenreId).Name);
            }
        }

        static private void LazyLoading()
        {
            var context = new VidzyContext();

            var videos = context.Videos.ToList();

            foreach (var video in videos)
            {
                Console.WriteLine("Name:" + video.Name);
                Console.WriteLine("Genre:" + context.Genres.Single(g => g.Id == video.GenreId).Name);
            }
        }

        static void Main(string[] args)
        {
            LazyLoading();
            Console.ReadKey();

            ExplicitLoading();
            Console.ReadKey();

            EagerLoading();
            Console.ReadKey();
        }
    }
}
