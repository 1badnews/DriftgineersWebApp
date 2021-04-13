using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Pages
{
    [BindProperties]
    public class RegisterModel : PageModel
    {
        public string Message { get; set; }


        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public void OnGet()
        {

        }

        public void OnPostMethodOne(string name)
        {
            Message = name;
        }

        public IActionResult OnPostMethodTwo()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                return RedirectToPage("Index");
            }


        }
    }
}
