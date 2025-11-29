using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreWebApp.Models;

namespace StoreWebApp.Pages
{
    public class LoginModel : PageModel
    {
        private readonly StoreWebApp.Contexts.Dbde3503Context _context;

        public LoginModel(StoreWebApp.Contexts.Dbde3503Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public User User { get; set; } = default!;

        // логин
        public async Task<IActionResult> OnPostLoginAsync()
        {
            var user = _context.Users.FirstOrDefault(u => u.Login == User.Login);
            if (user != null && user.Password == User.Password)
            {
                HttpContext.Session.SetString("UserRole", user.Role);
                HttpContext.Session.SetString("UserName", user.FullName);
                return RedirectToPage("Products/Index");
            }
            return Page();
        }

        // вход гостя:
        public IActionResult OnPostGuest()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.SetString("UserRole", "Гость");
            return RedirectToPage("Products/Index");
        }

        // выход
        public IActionResult OnGetLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("Products/Index"); // return Page();
        }
    }
}
