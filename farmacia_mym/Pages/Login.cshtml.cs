using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace farmacia_mym.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        public void OnGet()
        {
            // Aquí puedes inicializar cualquier dato necesario para el método GET.
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Aquí debes agregar la lógica para autenticar al usuario.

            // Si la autenticación es exitosa, redirige a la página deseada.
            return RedirectToPage("/Index");
        }
    }
}
