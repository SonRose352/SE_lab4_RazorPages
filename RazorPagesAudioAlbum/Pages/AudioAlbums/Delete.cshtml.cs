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
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesAudioAlbum.Data.RazorPagesAudioAlbumContext _context;

        public DeleteModel(RazorPagesAudioAlbum.Data.RazorPagesAudioAlbumContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var audioalbum = await _context.AudioAlbum.FindAsync(id);
            if (audioalbum != null)
            {
                AudioAlbum = audioalbum;
                _context.AudioAlbum.Remove(AudioAlbum);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
