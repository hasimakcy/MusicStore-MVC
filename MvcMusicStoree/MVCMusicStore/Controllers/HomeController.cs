using Microsoft.AspNetCore.Mvc;
using MvcMusicStore.Models;
using MVCMusicStore.Data;
using MVCMusicStore.Models;
using System.Diagnostics;

namespace MVCMusicStore.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        private readonly ApplicationDbContext _context;


        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var albums = GetTopSellingAlbums(5);
            return View(albums);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
      
        private List<Album> GetTopSellingAlbums(int count)
        {
            // Group the order details by album and return
            // the albums with the highest count
            return _context.Album
                .OrderByDescending(a => a.OrderDetails.Count())
                .Take(count)
                .ToList();
        }

       

    }
}