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
        
        
        public ShopModel(AppDataContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            Products = _db.Product.ToList();
        }
        public IActionResult OnGetDelete(int Id)
        {
            _db.Remove(_db.Product.Find(Id));
            _db.SaveChanges();
            return Page();
        }

    }

}
    

