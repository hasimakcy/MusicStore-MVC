using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCMusicStore.Data;
using MvcMusicStore.Models;



namespace MVCMusicStore.Controllers
{
    public class StoreController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StoreController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StoreController
        public async Task<ActionResult> Index()
        {
            return _context.Genre != null ?
                       View(await _context.Genre.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Genre'  is null.");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Album == null)
            {
                return NotFound();
            }

            var album = await _context.Album
                .Include(a => a.Artist)
                .Include(a => a.Genre)
                .FirstOrDefaultAsync(m => m.AlbumId == id);
            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }
        public async Task<ActionResult> Browse(int? id)
        {
            var gelen = _context.Album.Where(a => a.GenreId == id);
            return View(await gelen.ToListAsync());
        }


        //GET: /Store/GenreMenu
        [System.Web.Mvc.ChildActionOnly]
        public ActionResult GenreMenu()
        {
            var genres = _context.Genre.ToList();
            return PartialView(genres);
        }
    }
}
