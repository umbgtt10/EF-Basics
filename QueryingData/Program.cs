using System;
using System.Linq;

namespace QueryingData
{
    class Program
    {
        private static void Query1()
        {
            var context = new VidzyContext();

            var videos1 = context.Videos
                .Where(g => g.Genre.Name.Equals("Action")).OrderBy(o => o.Name);

            foreach (var video in videos1)
            {
                Console.WriteLine("Video : " + video.Name);
            }

            context.Dispose();
        }

        private static void Query2()
        {
            var context = new VidzyContext();

            var videos2 = context.Videos
                .Where(g => g.Genre.Name.Equals("Drama")).OrderByDescending(o => o.ReleaseDate);

            foreach (var video in videos2)
            {
                Console.WriteLine("video : " + video.Name);
            }

            context.Dispose();
        }

        private static void Query3()
        {
            var context = new VidzyContext();

            var videos3 = context.Videos.Select(element => new
            {
                MovieName = element.Name,
                Genre = element.Genre.Name
            });

            foreach (var video in videos3)
            {
                Console.WriteLine("Name : " + video.MovieName + " Genre:" + video.Genre);
            }

            context.Dispose();
        }

        private static void Query4()
        {
            var context = new VidzyContext();

            var videos4 = context.Videos.GroupBy(g => g.Classification)
                .Select(element => new
                {
                    Classification = element.Key,
                    Movies = element.AsQueryable()
                });

            foreach (var classification in videos4)
            {
                Console.WriteLine("Classification : " + classification.Classification);
                foreach (var video in classification.Movies)
                {
                    Console.WriteLine("    Video:    " + video.Name);
                }
            }

            context.Dispose();
        }

        private static void Query5()
        {
            var context = new VidzyContext();

            var classifications = context.Videos.GroupBy(c => c.Classification).OrderBy(o => o.Key.ToString()).Select(
                element => new
                {
                    Classification = element.Key,
                    Count = element.Count()
                });

            foreach (var classification in classifications)
            {
                Console.WriteLine("Classification : " + classification.Classification + "(" + classification.Count + ")");
            }

            context.Dispose();
        }

        private static void Query6()
        {
            var context = new VidzyContext();

            var genres = context.Genres.GroupJoin(context.Videos, genre => genre.Id, video => video.GenreId,
                (genre, videos) => new
                {
                    Genre = genre.Name,
                    Count = videos.Count()
                }).OrderByDescending(c => c.Count);

            foreach (var genre in genres)
            {
                Console.WriteLine("Genres : " + genre.Genre + "(" + genre.Count + ")");
            }

            context.Dispose();
        }

        static void Main(string[] args)
        {           
            Query1();
            Console.ReadKey();

            Query2();
            Console.ReadKey();

            Query3();
            Console.ReadKey();

            Query4();
            Console.ReadKey();

            Query5();
            Console.ReadKey();

            Query6();
            Console.ReadKey();
        }
    }
}
