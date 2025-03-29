using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using farmacia_mym.Models;
using farmacia_mym.Data;

namespace farmacia_mym.Pages.Usuarios
{
    public class DetailsModel : PageModel
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public DetailsModel(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public Usuario Usuario { get; set; }

        public IActionResult OnGet(int id)
        {
            Usuario = _usuarioRepository.GetById(id);

            if (Usuario == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
