using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Models;

namespace WebApplication1.Pages
{
    public class checkoutModel : PageModel
    {

        public List<Cart> cart { get; set; }
        public readonly AppDataContext _db;

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        public double total { get; set; }


        public Cart cart1 { get; set; }
        public checkoutModel(AppDataContext db) { _db = db; }

        public IActionResult OnGetCheckout()
        {

            _db.Cart.RemoveRange(_db.Cart);
            _db.SaveChanges();

            return RedirectToPage("cart");

        }
        public void OnGet()
        {
            cart = _db.Cart.ToList();
            total = 0;
            foreach (var item in cart)
            {
                total = total + item.price;

            }
        }
    }
}
