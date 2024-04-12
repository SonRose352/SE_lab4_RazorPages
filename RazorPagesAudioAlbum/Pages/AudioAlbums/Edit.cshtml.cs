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
    public class EditModel : PageModel
    {
        private readonly RazorPagesAudioAlbum.Data.RazorPagesAudioAlbumContext _context;

        public EditModel(RazorPagesAudioAlbum.Data.RazorPagesAudioAlbumContext context)
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

            var audioalbum =  await _context.AudioAlbum.FirstOrDefaultAsync(m => m.Id == id);
            if (audioalbum == null)
            {
                return NotFound();
            }
            AudioAlbum = audioalbum;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(AudioAlbum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AudioAlbumExists(AudioAlbum.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AudioAlbumExists(int id)
        {
            return _context.AudioAlbum.Any(e => e.Id == id);
        }
    }
}
