using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StoreWebApp.Contexts;
using StoreWebApp.Models;

namespace StoreWebApp.Pages.Orders
{
    public class IndexModel : AuthPageModel
    {
        private readonly StoreWebApp.Contexts.Dbde3503Context _context;

        public IndexModel(StoreWebApp.Contexts.Dbde3503Context context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            if (HasRole() is IActionResult result)
                return result;

            Order = await _context.Orders
                .Include(o => o.User).ToListAsync();
            return Page();
        }
    }
}
