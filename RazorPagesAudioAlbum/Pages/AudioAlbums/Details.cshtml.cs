using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesAudioAlbum.Data;
using RazorPagesAudioAlbum.Models;

namespace RazorPagesAudioAlbum.Pages.AudioAlbums
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesAudioAlbum.Data.RazorPagesAudioAlbumContext _context;

        public DetailsModel(RazorPagesAudioAlbum.Data.RazorPagesAudioAlbumContext context)
        {
            _context = context;
        }

        public AudioAlbum AudioAlbum { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var audioalbum = await _context.AudioAlbum.FirstOrDefaultAsync(m => m.Id == id);
            if (audioalbum == null)
            {
                return NotFound();
            }
            else
            {
                AudioAlbum = audioalbum;
            }
            return Page();
        }
    }
}
