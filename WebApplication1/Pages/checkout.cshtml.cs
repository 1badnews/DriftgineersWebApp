using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Models;

namespace WebApplication1.Pages
{
    [BindProperties]
    public class checkoutModel : PageModel
    {

        public List<Cart> cart { get; set; }
        public readonly AppDataContext _db;

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        public double total { get; set; }

        [Required]
        // [CreditCard] requires additional jquery methods
        [Display(Name = "Card Number")]
        public string cardno { get; set; }
        
        [Required]
        [Display(Name = "Card Holder Name")]
        public string cardname { get; set; }

        [Required]
        [Display(Name = "CVC")]
        public string cvc { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string name { get; set; }
        [Required]
        [Display(Name = "Surname")]
        public string surname { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string address { get; set; }
        [Required]
        [Display(Name = "Country")]
        public string country { get; set; }
        [Required]
        [Display(Name = "Post Code")]
        public string post { get; set; }

        public void GetCartDetails()
        {

            cart = _db.Cart.Where(e => e.UserID == _userManager.GetUserId(User)).ToList();

            total = 0;
            foreach (var item in cart)
            {
                total = total + item.price;

            }
        }

        public Cart cart1 { get; set; }
        public checkoutModel(AppDataContext db, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _db = db;
        }

        private readonly UserManager<AppUser> _userManager;
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _db.Cart.RemoveRange(_db.Cart.Where(e => e.UserID == _userManager.GetUserId(User)));
                _db.SaveChanges();

                return RedirectToPage("thankyou");
            }
            else
                GetCartDetails();
            return Page();


     }
        public void OnGet()
        {
            GetCartDetails();
        }
    }
}
