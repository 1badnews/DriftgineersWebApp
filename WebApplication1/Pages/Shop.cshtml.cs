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


        public readonly AppDataContext _db;
        [BindProperty]
        public List<Product> Products { get; set; }
        public List<Cart> carts { get; set; }


        [BindProperty(SupportsGet = true)]
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
            carts = _db.Cart.ToList();
            product = _db.Product.Find(Id);

            if (carts.Count() == 0)
            {
                cart.Name = product.Name;
                cart.price = product.Price;
                cart.Quantity = 1;

                _db.Cart.Add(cart);
                _db.SaveChanges();
                return RedirectToPage("shop");
            }
            else
            {
                foreach (var item in carts)
                {
                    if (item.Name == product.Name)
                    {
                        item.Quantity++;
                        _db.SaveChanges();
                        return RedirectToPage("shop");

                    }
                }

            }
            cart.Name = product.Name;
            cart.price = product.Price;
            cart.Quantity = 1;

            _db.Cart.Add(cart);
            _db.SaveChanges();
            return RedirectToPage("shop");


        }
    }

            }











