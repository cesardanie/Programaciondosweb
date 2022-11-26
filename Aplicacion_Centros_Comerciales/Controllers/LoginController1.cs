using Microsoft.AspNetCore.Mvc;

namespace Aplicacion_Centros_Comerciales.Controllers
{
    public class LoginController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult LoginView(string Correo, string contraseña)
        {
            bool TipoUsuario = false;

            return View();
        }

    }
}
