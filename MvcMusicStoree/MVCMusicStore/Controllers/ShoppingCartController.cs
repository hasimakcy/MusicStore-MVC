using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcMusicStore.Models;
using MvcMusicStore.ViewModel;
using MVCMusicStore.Data;
using System.Web;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace MVCMusicStore.Controllers
{
    public class ShoppingCartController : Controller
    {
        //MusicStoreEntities storeDB = new MusicStoreEntities();
        
        private readonly ApplicationDbContext _context;

        public ShoppingCartController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: /ShoppingCart/
        public ActionResult Index()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext, _context);

            // Set up our ViewModel
            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };
            // Return the view
            return View(viewModel);
        }
        //
        // GET: /Store/AddToCart/5
        public ActionResult AddToCart(int id)
        {
            // Retrieve the album from the database
            var addedAlbum = _context.Album
                .Single(album => album.AlbumId == id);

            // Add it to the shopping cart
            var cart = ShoppingCart.GetCart(this.HttpContext,_context);

            cart.AddToCart(addedAlbum);

            // Go back to the main store page for more shopping
            return RedirectToAction("Index");
        }
        //
        // AJAX: /ShoppingCart/RemoveFromCart/5
        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            // Remove the item from the cart
            var cart = ShoppingCart.GetCart(HttpContext, _context);

            // Get the name of the album to display confirmation
            string albumName = _context.Carts.Include(a => a.Album).Single(item => item.RecordId == id).Album.Title;
            
            // Remove from cart
            int itemCount = cart.RemoveFromCart(id);

            // Display the confirmation message
            var results = new ShoppingCartRemoveViewModel
            {
                Message = albumName +
                    " has been removed from your shopping cart.",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };
            return Json(results);
        }

        //GET: /ShoppingCart/CartSummary
        //[System.Web.Mvc.ChildActionOnly]

        [HttpGet]
        public JsonResult CartSummary()
        {


            var cart = ShoppingCart.GetCart(this.HttpContext, _context) ;

            ViewData["CartCount"] = cart.GetCount();

            return Json(cart.GetCount());
        }




    }
}