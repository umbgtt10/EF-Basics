using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace UpdatingDataExercise
{
    class Program
    {
        private static void Step1()
        {
            var newVideoName = "Terminator 1";

            using (var context = new VidzyContext())
            {
                if (!context.Videos.Any(n => n.Name.Equals(newVideoName)))
                {
                    var newVideo = new Video()
                    {
                        Name = newVideoName,
                        GenreId = 2,
                        ReleaseDate = new DateTime(1984, 8, 26),
                        Classification = Classification.Silver
                    };

                    context.Videos.Add(newVideo);
                    context.SaveChanges();
                }
            }
        }

        private static void Step2()
        {
            var tagName1 = "Classic";
            var tagName2 = "Drama";

            using (var context = new VidzyContext())
            {
                if (!context.Tags.Any(n => n.Name.Equals(tagName1)))
                {
                    var tag1 = new Tag()
                    {
                        Id = 1,
                        Name = tagName1,
                    };

                    context.Tags.Add(tag1);
                }

                if (!context.Tags.Any(n => n.Name.Equals(tagName2)))
                {
                    var tag2 = new Tag()
                    {
                        Id = 2,
                        Name = tagName2,
                    };

                    context.Tags.Add(tag2);
                }                

                context.SaveChanges();
            }
        }

        private static void AddVideoToTagIfRequired(Tag tag, Video video)
        {
            if (tag.Videos.Count(v => v.Name.Equals(video.Name)) == 0)
            {
                tag.Videos.Add(video);
            }
        }

        private static void UpdateTagVideoList(VidzyContext context, Tag tag, Video video)
        {
            if (!context.Tags.Any(t => t.Name.Equals(tag.Name)))
            {
                context.Tags.Add(tag);
            }
            else
            {
                if (context.Tags.Any(t => t.Name.Equals(tag.Name)))
                {
                    var videos = context.Tags.Single(t => t.Name.Equals(tag.Name)).Videos;
                    if (videos.Count(v => v.Name.Equals(video.Name)) == 0)
                    {
                        videos.Add(video);
                    }
                }
                else
                {
                    context.Tags.Attach(tag);
                }
            }
        }

        private static void Step3()
        {
            var godFatherVideoName = "The Godfather";
            var tag1 = new Tag()
            {
                Id = 1,
                Name= "Classic",
            }; 
            var tag2 = new Tag()
            {
                Id = 2,
                Name = "Drama"
            };
            var tag3 = new Tag()
            {
                Id = 3,
                Name = "Comedy"
            };

            var tags = new List<Tag>()
            {
                tag1,
                tag2,
                tag3
            };

            using (var context = new VidzyContext())
            {
                if (context.Videos.Count(v => v.Name.Equals(godFatherVideoName)) == 1)
                {
                    var godFatherVideo = context.Videos.Include(e => e.Tags).Single(v => v.Name.Equals(godFatherVideoName));

                    AddVideoToTagIfRequired(tag1, godFatherVideo);
                    AddVideoToTagIfRequired(tag2, godFatherVideo);
                    AddVideoToTagIfRequired(tag3, godFatherVideo);

                    UpdateTagVideoList(context, tag1, godFatherVideo);
                    UpdateTagVideoList(context, tag2, godFatherVideo);
                    UpdateTagVideoList(context, tag3, godFatherVideo);

                    context.SaveChanges();
                }
            }
        }

        private static void Step4()
        {
            var godFatherVideoName = "The Godfather";

            using (var context = new VidzyContext())
            {
                if (context.Videos.Count(v => v.Name.Equals(godFatherVideoName)) == 1)
                {
                    var godFatherVideo = context.Videos.Single(v => v.Name.Equals(godFatherVideoName));
                    var tags = godFatherVideo.Tags.Where(e => e.Name == "Comedy");
                    context.Tags.RemoveRange(tags);

                    context.SaveChanges();
                }
            }
        }

        private static void Step5()
        {
            var godFatherVideoName = "The Godfather";

            using (var context = new VidzyContext())
            {
                if (context.Videos.Any(v => v.Name.Equals(godFatherVideoName)))
                {
                    var video = context.Videos.Single(v => v.Name.Equals(godFatherVideoName));
                    context.Videos.Remove(video);
                    context.SaveChanges();
                }
            }
        }

        private static void Step6()
        {
            var genreType = "Action";

            using (var context = new VidzyContext())
            {
                if (context.Genres.Any(v => v.Name.Equals(genreType)))
                {
                    var genreToBeDeleted = context.Genres.Single(v => v.Name.Equals(genreType));

                    var videosToBeDeleted = context.Videos.Where(v => v.Genre.Name.Equals(genreType));

                    context.Videos.RemoveRange(videosToBeDeleted);

                    context.Genres.Remove(genreToBeDeleted);

                    context.SaveChanges();
                }
            }
        }

        static void Main(string[] args)
        {
            Step1();

            Step2();

            Step3();

            Step4();

            Step5();

            Step6();
        }
    }
}
