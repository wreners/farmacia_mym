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
            // Aqu� puedes inicializar cualquier dato necesario para el m�todo GET.
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Aqu� debes agregar la l�gica para autenticar al usuario.

            // Si la autenticaci�n es exitosa, redirige a la p�gina deseada.
            return RedirectToPage("/Index");
        }
    }
}
