using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public readonly AppDataContext _db;

        public ProductModel(AppDataContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            Products = _db.Product.Find(Id);
        }
    }
}
