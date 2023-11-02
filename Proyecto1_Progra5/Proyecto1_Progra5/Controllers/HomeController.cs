using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto1_Progra5.Data;
using Proyecto1_Progra5.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace Proyecto1_Progra5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Reservar()
        {
            var lista = _context.Productos.ToList();
            var PImg = new List<ProductoImagen>();
            foreach (var item in lista)
            {
                string base64 = Convert.ToBase64String(item.Foto);
                PImg.Add(
                    new ProductoImagen()
                    {
                        Id = item.Id,
                        Nombre = item.Nombre,
                        Descripcion = item.Descripcion,
                        Precio = item.Precio,
                        Tipo = item.Tipo,
                        Foto = string.Format("data:imagen/jpeg;base64,{0}", base64)
                    });
            }

            /*ClaimsPrincipal claimuser = HttpContext.User;
            string nombreUsuario = "";
            if (claimuser.Identity.IsAuthenticated)
            {
                nombreUsuario = claimuser.Claims.Where(c => c.Type == ClaimTypes.Name)
                    .Select(c => c.Value).SingleOrDefault();
            }

            ViewData["nombreUsuario"] = nombreUsuario;*/

            return View(PImg);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}