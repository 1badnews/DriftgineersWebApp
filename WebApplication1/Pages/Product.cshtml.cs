using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Models;

namespace WebApplication1.Pages
{
    public class ProductModel : PageModel
    {



        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public Product Products { get; set; }

        private readonly UserManager<AppUser> _userManager;

        public readonly AppDataContext _db;

        public ProductModel(AppDataContext db, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _db = db;
        }

        public Product product { get; set; }

        public Cart cart { get; set; }
        public List<Cart> carts { get; set; }
        public void OnGet()
        {
            Products = _db.Product.Find(Id);
        }

        public IActionResult OnGetCart(int Id)
        {
            product = new Product();
            cart = new Cart();
            carts = _db.Cart.Where(e => e.UserID == _userManager.GetUserId(User)).ToList();
            product = _db.Product.Find(Id);


            foreach (var item in carts)
            {
                if (item.Name == product.Name && item.UserID == _userManager.GetUserId(User))
                {
                    item.Quantity++;
                    _db.SaveChanges();
                    return RedirectToPage("shop");

                }

            }


            cart.Name = product.Name;
            cart.price = product.Price;
            cart.Quantity = 1;
            cart.ProductImage = product.ProductImage;
            cart.UserID = _userManager.GetUserId(User);

            _db.Cart.Add(cart);
            _db.SaveChanges();
            return RedirectToPage("shop");


        }
    }
}
