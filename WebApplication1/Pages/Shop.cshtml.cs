using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Models;

namespace WebApplication1.Pages
{
    public class ShopModel : PageModel
    {
      
      
        public readonly  AppDataContext _db;
        [BindProperty]
        public List<Product> Products { get; set; }

        
        [BindProperty(SupportsGet =true)]
        public int Id { get; set; }
        public ShopModel(AppDataContext db)
        {
            _db = db;
        }

        public Cart cart { get; set; }
        public Product product { get; set; }
        public void OnGet()
        {

            Products = _db.Product.ToList();
        }
        public IActionResult OnGetDelete(int Id)
        {
            _db.Remove(_db.Product.Find(Id));
            _db.SaveChanges();
            return RedirectToPage("shop");
        }

        public IActionResult OnGetCart(int Id)
        {
            product = new Product();
            cart = new Cart();

            
            product = _db.Product.Find(Id);
            
            cart.Name = product.Name;
            cart.price = product.Price;

            _db.Cart.Add(cart);
            _db.SaveChanges();
            return RedirectToPage("shop");
            
        }

    }

}
    

