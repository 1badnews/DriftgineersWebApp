using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Models;

namespace WebApplication1.Pages
{
    [Authorize]
    public class CartModel : PageModel
    {
        public List<Product> products { get; set; }
        public List<Cart> cart { get; set; }
        public readonly AppDataContext _db;

        [BindProperty(SupportsGet =true)]
        public int Id { get; set; }
        public double total { get; set; }
        private readonly UserManager<AppUser> _userManager;

        [BindProperty(SupportsGet = true)]
        public string customername { get; set; }
        public Cart cart1 { get; set; }
        public CartModel(AppDataContext db, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _db = db;
        }

        public IActionResult OnGetAddOne(int Id)
        {
            cart1 = _db.Cart.Find(Id);
            cart1.price = cart1.price / cart1.Quantity;
            cart1.Quantity = cart1.Quantity + 1;
            cart1.price = cart1.price * cart1.Quantity;

            _db.SaveChanges();
            return RedirectToPage("cart");
            
        }

        public IActionResult OnGetRemoveOne()
        {
           
            cart1 = _db.Cart.Find(Id);
                if (cart1.Quantity == 1)
                {
                    return RedirectToPage("cart");
                }
            
                cart1.price = cart1.price / cart1.Quantity;
            cart1.Quantity = cart1.Quantity - 1;
            cart1.price = cart1.price * cart1.Quantity;
            _db.SaveChanges();
            return RedirectToPage("cart");
        

    }
        public IActionResult OnGetDelete(int Id)
        {
            _db.Remove(_db.Cart.Find(Id));
            _db.SaveChanges();
            return RedirectToPage("cart");
        }
        public async void OnGetAsync()
        {
            customername = _userManager.GetUserAsync(User).Result.FirstName;
            products = _db.Product.ToList();
            cart = _db.Cart.Where(e => e.UserID == _userManager.GetUserId(User)).ToList();

            total = 0;
            foreach(var item in cart)
            {
                total = total + item.price;
                
            }

        }
    }
}
