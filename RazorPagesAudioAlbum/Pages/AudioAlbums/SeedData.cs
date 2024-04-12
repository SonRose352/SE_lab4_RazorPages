using Microsoft.EntityFrameworkCore;
using RazorPagesAudioAlbum.Data;
using RazorPagesAudioAlbum.Models;

namespace RazorPagesAudioAlbum.Pages.AudioAlbums
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPagesAudioAlbumContext(
                serviceProvider.GetRequiredService<
                DbContextOptions<RazorPagesAudioAlbumContext>>()))
            {
                if (context == null || context.AudioAlbum == null)
                {
                    throw new ArgumentNullException("Null RazorPagesMovieContext");
                }

                // Look for any movies.
                if (context.AudioAlbum.Any())
                {
                    return;   // DB has been seeded
                }

                context.AudioAlbum.AddRange(
                    new AudioAlbum
                    {
                        Title = "MILLION DOLLAR: HAPPINESS",
                        ReleaseDate = DateTime.Parse("2021-5-17"),
                        Genre = "Hip-hop",
                        Executor = "MORGENSHTERN",
                        NumberOfTracks = 13,
                        Duration = new TimeSpan(0, 22, 18),
                        Rating = "R"
                    },

                    new AudioAlbum
                    {
                        Title = "POPSTAR",
                        ReleaseDate = DateTime.Parse("2022-12-16"),
                        Genre = "Hip-hop",
                        Executor = "INSTASAMKA",
                        NumberOfTracks = 11,
                        Duration = new TimeSpan(0, 25, 29),
                        Rating = "R"
                    },

                    new AudioAlbum
                    {
                        Title = "MONEYDEALER",
                        ReleaseDate = DateTime.Parse("2021-11-19"),
                        Genre = "Hip-hop",
                        Executor = "INSTASAMKA",
                        NumberOfTracks = 7,
                        Duration = new TimeSpan(0, 14, 2),
                        Rating = "R"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
