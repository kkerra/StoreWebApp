using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StoreWebApp.Models;

namespace StoreWebApp.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly StoreWebApp.Contexts.Dbde3503Context _context;

        public CreateModel(StoreWebApp.Contexts.Dbde3503Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ManufacturerId"] = new SelectList(_context.Manufacturers, "Id", "Name");
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            Product.Id = _context.Products.Max(p => p.Id) + 1;

            _context.Products.Add(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
