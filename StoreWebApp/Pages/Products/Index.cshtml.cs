using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;
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

        public IList<Product> Product { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string Search {  get; set; }

        [BindProperty(SupportsGet = true)]
        public string Sort { get; set; }

        [BindProperty(SupportsGet = true)]
        public int Filter { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (HasRole() is IActionResult result)
                return result;

            var manufacturers = _context.Manufacturers.ToList();
            manufacturers.Insert(0, new Manufacturer { Id = 0, Name = "Все производители" });

            ViewData["ManufacturerId"] = new SelectList(manufacturers, "Id", "Name");

            Product = await _context.Products
                .Include(p => p.Manufacturer)
                .Include(p => p.Supplier).ToListAsync();

            if (Search != null)
                Product = Product.Where(p => 
                    p.Article.Contains(Search) || 
                    p.Title.Contains(Search))
                    .ToList();

            if(Sort != null && Sort == "price")
                Product = Product.OrderBy(p => p.Price).ToList();
            if(Sort != null && Sort == "price_desc")
                Product = Product.OrderByDescending(p => p.Price).ToList();

            if(Filter != null && Filter > 0)
                Product = Product.Where(p => p.ManufacturerId == Filter).ToList();

            return Page();
        }
    }
}
