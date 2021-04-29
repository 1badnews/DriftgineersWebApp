using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Models;

namespace WebApplication1.Pages
{
    [Authorize]
    public class ShopModel : PageModel
    {


        public readonly AppDataContext _db;
        [BindProperty]
        public List<Product> Products { get; set; }
        public List<Cart> carts { get; set; }
        private readonly UserManager<AppUser> _userManager;

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        public ShopModel(AppDataContext db, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _db = db;
        }

        [BindProperty(SupportsGet = true)]
        public string Sort { get; set; }

        public Cart cart { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchName { get; set; }

        [BindProperty(SupportsGet = true)]
        public string EmptyMessage { get; set; }
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

        public IActionResult OnPostSearch()
        {
            if(SearchName == null)
            {
                return RedirectToPage("shop");
            }
            Products = _db.Product.Where(p => p.Name.Contains(SearchName)).ToList();
            if (Products.Count()==0)
            {
                EmptyMessage = "No Products Found.";
            }
            else
            {
                EmptyMessage = "";
            }
            return Page();
        }
        public IActionResult OnPostSort()
        {
            if (Sort == "PriceAsc")
            {
                Products = _db.Product.OrderBy(p => p.Price).ToList();
                return Page();
            }
            if (Sort == "Letter")
            {
                Products = _db.Product.OrderBy(p => p.Name).ToList();
                return Page();
            }
            if (Sort == "PriceDsc")
            {
                Products = _db.Product.OrderByDescending(p => p.Price).ToList();
                return Page();
            }
            return RedirectToPage();
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











