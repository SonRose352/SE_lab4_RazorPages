using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesAudioAlbum.Data;
using RazorPagesAudioAlbum.Models;

namespace RazorPagesAudioAlbum.Pages.AudioAlbums
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesAudioAlbum.Data.RazorPagesAudioAlbumContext _context;

        public CreateModel(RazorPagesAudioAlbum.Data.RazorPagesAudioAlbumContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public AudioAlbum AudioAlbum { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.AudioAlbum.Add(AudioAlbum);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
