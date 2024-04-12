using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesAudioAlbum.Models;

namespace RazorPagesAudioAlbum.Data
{
    public class RazorPagesAudioAlbumContext : DbContext
    {
        public RazorPagesAudioAlbumContext (DbContextOptions<RazorPagesAudioAlbumContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesAudioAlbum.Models.AudioAlbum> AudioAlbum { get; set; } = default!;
    }
}
