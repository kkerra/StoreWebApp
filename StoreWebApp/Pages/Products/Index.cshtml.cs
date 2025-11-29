using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StoreWebApp.Contexts;
using StoreWebApp.Models;

namespace StoreWebApp.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly StoreWebApp.Contexts.Dbde3503Context _context;

        public IndexModel(StoreWebApp.Contexts.Dbde3503Context context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; } = default!;

        public string UserRole { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            UserRole = HttpContext.Session.GetString("UserRole");
            if(String.IsNullOrEmpty(UserRole))
                return RedirectToPage("../Login");

            Product = await _context.Products
                .Include(p => p.Manufacturer)
                .Include(p => p.Supplier).ToListAsync();
            return Page();
        }
    }
}
