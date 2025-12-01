using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StoreWebApp.Pages
{
    public class AuthPageModel : PageModel
    {
        public string UserRole => HttpContext.Session.GetString("UserRole");

        protected IActionResult HasRole()
        {
            if (String.IsNullOrEmpty(UserRole))
                return RedirectToPage("Login");

            return null;
        }
    }
}
