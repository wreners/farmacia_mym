using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using farmacia_mym.Models;
using farmacia_mym.Data;
using BCrypt.Net;

namespace farmacia_mym.Pages.Usuarios
{
    public class CreateModel : PageModel
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public CreateModel(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [BindProperty]
        public Usuario Usuario { get; set; }

        public void OnGet()
        {
            // Se puede usar para inicializar cualquier dato antes de mostrar el formulario
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                // Hashear la contraseña antes de almacenar
                Usuario.Clave = BCrypt.Net.BCrypt.HashPassword(Usuario.Clave);
                _usuarioRepository.Add(Usuario);
                return RedirectToPage("./Index"); // Redirigir a la lista después de crear
            }
            return Page(); // Retornar a la misma página si hay errores
        }
    }
}
