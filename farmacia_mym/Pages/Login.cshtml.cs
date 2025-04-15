using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using BCrypt.Net;

namespace farmacia_mym.Pages
{
    public class LoginModel : PageModel
    {

        private readonly string connectionString = "Server=127.0.0.1;Port=3306;Database=farmacia;User Id=FARMACIAMYM;Password=123456;";

        [BindProperty]
        public string User { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        public void OnGet()
        {
   
        }

        public IActionResult OnPost()
        {
            // Validación de entradas
            if (string.IsNullOrEmpty(User) || string.IsNullOrEmpty(Password))
            {
                ErrorMessage = "El correo y la contraseña son obligatorios.";
                return Page();
            }

            // Conexión a la base de datos
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT clave, rol FROM Usuarios WHERE user = @User";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@User", User);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Recuperar el hash de la contraseña almacenada
                            string passwordHash = reader.GetString(0);
                            string userRole = reader.GetString(1);

                            // Verificar la contraseña ingresada con el hash almacenado
                            if (BCrypt.Net.BCrypt.Verify(Password, passwordHash))
                            {
                                // Inicio de sesión exitoso
                                if (userRole == "Admin")
                                {
                                    return RedirectToPage("/AdminDashboard");
                                }
                                else
                                {
                                    return RedirectToPage("/UserDashboard");
                                }
                            }
                        }
                        else
                        {
                            ErrorMessage = "Credenciales incorrectas.";
                        }
                    }
                }
            }

            return Page();
        }
        }
}
