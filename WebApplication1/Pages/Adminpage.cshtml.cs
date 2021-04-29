using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;


namespace WebApplication1.Pages
{
    [Authorize (Roles="Admin")]
    public class AdminpageModel : PageModel
    {
        
        public readonly AppDataContext _db;

        [BindProperty]
        public Product Products { get; set; }

        [BindProperty (SupportsGet =true)]
        public int Id { get; set; }

        [BindProperty(SupportsGet = true)]
        public string RoleId { get; set; }

        [BindProperty(SupportsGet = true)]
        public string UserId { get; set; }

        [BindProperty(SupportsGet = true)]
        public string roleName { get; set; }




        [BindProperty(SupportsGet=true)]
        public string passwordString { get; set; }

        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        public AdminpageModel(AppDataContext db, RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
            _db = db;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public List<AppUser> users { get; set; }
        public List<IdentityRole> roles { get; set; }
      
        public void OnGet()
        {
            roles = _roleManager.Roles.ToList();
            
            Products = _db.Product.Find(Id);
            users = _userManager.Users.ToList();
        }
        public async Task<IActionResult> OnGetDeleteUserAsync()
        {

            var delete = await _userManager.FindByIdAsync(UserId);
            var result = await _userManager.DeleteAsync(delete);

            return RedirectToPage("/Adminpage");


        }

        public async Task<IActionResult> OnPostChangePasswordAsync() // ????????????????????????? WHY
        {

            var users = await _userManager.FindByIdAsync(UserId);
             await _userManager.RemovePasswordAsync(users);
            await _userManager.AddPasswordAsync(users, passwordString);

            return RedirectToPage("/index");


        }
        public async Task<IActionResult> OnGetDeleteRoleAsync()
        {
            
                var delete = await _roleManager.FindByIdAsync(RoleId);
                var result = await _roleManager.DeleteAsync(delete);
            
            return RedirectToPage("/Adminpage");


        }
        public async Task<IActionResult> OnPostAddRoleAsync()
        {
            await _roleManager.CreateAsync(new IdentityRole(roleName.Trim()));
            return RedirectToPage("/Adminpage");
        }

        public IActionResult OnPostAdd()
        {

            _db.Product.Update(Products);
           
            _db.SaveChanges();
            return RedirectToPage("/Adminpage");

        }

        public IActionResult OnPostDelete()
        {

            _db.Product.Remove(Products);
            _db.SaveChanges();
            return Page();

        }

        public async Task<IActionResult> OnGetChangeRoleAsync()
        {

            var userinfo = await _userManager.FindByIdAsync(UserId);


            var rolesToclear = await _userManager.GetRolesAsync(userinfo);
            await _userManager.RemoveFromRolesAsync(userinfo, rolesToclear.ToArray());
            await _userManager.AddToRoleAsync(userinfo, roleName);

            return RedirectToPage("/Adminpage");
        }

    }
}
