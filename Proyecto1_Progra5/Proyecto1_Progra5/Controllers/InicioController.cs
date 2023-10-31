using Microsoft.AspNetCore.Mvc;
using Proyecto1_Progra5.Data;
using Proyecto1_Progra5.Models;

namespace Proyecto1_Progra5.Controllers
{
    public class InicioController : Controller
    {
        public IActionResult IniciarSesion()
        {
            return View("IniciarSesion"); // Muestra la vista de inicio de sesión 
        }

        public IActionResult Registrarse()
        {
            return View("Registrarse"); // Muestra la vista de registro
        }
    }
}
