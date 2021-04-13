using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Models;


namespace WebApplication1.Pages
{
    public class AdminpageModel : PageModel
    {
        public readonly AppDataContext _db;

        [BindProperty]
        public Product Products { get; set; }

        [BindProperty (SupportsGet =true)]
        public int Id { get; set; }
        public AdminpageModel(AppDataContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            Products = _db.Product.Find(Id);
        }

        public IActionResult OnPostAdd()
        {

            _db.Product.Update(Products);
           
            _db.SaveChanges();
            return Page();
            
        }

        public IActionResult OnPostDelete()
        {

            _db.Product.Remove(Products);
            _db.SaveChanges();
            return Page();

        }

    }
}
