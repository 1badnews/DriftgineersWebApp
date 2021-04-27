using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Models;

namespace WebApplication1.Pages
{
    public class CartModel : PageModel
    {
        public List<Product> products { get; set; }
        public List<Cart> cart { get; set; }
        public readonly AppDataContext _db;

        [BindProperty(SupportsGet =true)]
        public string Id { get; set; }
        public double total { get; set; }
        public CartModel(AppDataContext db) { _db = db; }

        public void OnGet()
        {
            products = _db.Product.ToList();
            cart = _db.Cart.ToList();
            total = 0;
            foreach(var item in cart)
            {
                total = total + item.price;
                
            }
        }
    }
}
