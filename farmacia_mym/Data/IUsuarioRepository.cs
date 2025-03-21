using farmacia_mym.Models;

namespace farmacia_mym.Data
{
    public interface IUsuarioRepository
    {
        //interfaz web
        IEnumerable<Usuario> GetAll();
        Usuario GetById(int id);
        void Add(Usuario usuario);
        void Update(Usuario usuario);
        void Delete(int id);
    }
}
