using MVCMusicStore.Models;

namespace MvcMusicStore.ViewModel
{
    public class ShoppingCartViewModel
    {
        public List<Cart> CartItems { get; set; }
        public decimal CartTotal { get; set; }

    }
}
