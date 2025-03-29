using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using farmacia_mym.Models;
using farmacia_mym.Data;
using System.Collections.Generic;

namespace farmacia_mym.Pages.Usuarios
{
    public class IndexModel : PageModel
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public IndexModel(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public IEnumerable<Usuario> Usuarios { get; set; }

        public void OnGet()
        {
            Usuarios = _usuarioRepository.GetAll();
        }
    }
}