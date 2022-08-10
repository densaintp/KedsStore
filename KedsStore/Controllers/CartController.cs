using KedsStore.Data;
using KedsStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace KedsStore.Controllers
{
    public class CartController : Controller
    {
        private readonly KedsStoreContext _context;
        private readonly Cart _cart;

        public CartController(KedsStoreContext context, Cart cart)
        {
            _context = context;
            _cart = cart;
        }

        public IActionResult Index()
        {
            var items = _cart.GetAllCartItems();
            _cart.CartItems = items;
            return View(_cart);
        }

        public IActionResult AddToCart(int id)
        {
            var selectedItem = GetItemById(id);

            if (selectedItem != null)
            {
                _cart.AddToCart(selectedItem, 1);
            }

            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromCart(int id)
        {
            var selectedItem = GetItemById(id);

            if (selectedItem != null)
            {
                _cart.RemoveFromCart(selectedItem);
            }

            return RedirectToAction("Index");
        }

        public IActionResult ReduceQuantity(int id)
        {
            var selectedItem = GetItemById(id);

            if (selectedItem != null)
            {
                _cart.ReduceQuantity(selectedItem);
            }

            return RedirectToAction("Index");
        }

        public IActionResult IncreaseQuantity(int id)
        {
            var selectedItem = GetItemById(id);

            if (selectedItem != null)
            {
                _cart.IncreaseQuantity(selectedItem);
            }

            return RedirectToAction("Index");
        }

        public IActionResult ClearCart()
        {
            _cart.ClearCart();

            return RedirectToAction("Index");
        }

        public Item GetItemById(int id)
        {
            return _context.Items.FirstOrDefault(i => i.Id == id);
        }
    }
}
