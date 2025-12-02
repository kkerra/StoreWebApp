using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StoreWebApp.Contexts;
using StoreWebApp.Models;

namespace StoreWebApp.Pages.Orders
{
    public class CreateModel : AuthPageModel
    {
        private readonly StoreWebApp.Contexts.Dbde3503Context _context;

        public CreateModel(StoreWebApp.Contexts.Dbde3503Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Order Order { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (CanEdit() is IActionResult result)
                return result;

            _context.Orders.Add(Order);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
