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
    public class IndexModel : AuthPageModel
    {
        private readonly StoreWebApp.Contexts.Dbde3503Context _context;

        public IndexModel(StoreWebApp.Contexts.Dbde3503Context context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; } = default!;


        public async Task<IActionResult> OnGetAsync()
        {
            HasRole();

            Product = await _context.Products
                .Include(p => p.Manufacturer)
                .Include(p => p.Supplier).ToListAsync();
            return Page();
        }
    }
}
