using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesAudioAlbum.Data;
using RazorPagesAudioAlbum.Models;

namespace RazorPagesAudioAlbum.Pages.AudioAlbums
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesAudioAlbum.Data.RazorPagesAudioAlbumContext _context;

        public IndexModel(RazorPagesAudioAlbum.Data.RazorPagesAudioAlbumContext context)
        {
            _context = context;
        }

        public IList<AudioAlbum> AudioAlbum { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Genres { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? AudioAlbumGenre { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> genreQuery = from a in _context.AudioAlbum
                                            orderby a.Genre
                                            select a.Genre;

            var albums = from a in _context.AudioAlbum
                         select a;
            if (!string.IsNullOrEmpty(SearchString))
            {
                albums = albums.Where(s => s.Title.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(AudioAlbumGenre))
            {
                albums = albums.Where(x => x.Genre == AudioAlbumGenre);
            }
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());

            AudioAlbum = await albums.ToListAsync();
        }
    }
}
