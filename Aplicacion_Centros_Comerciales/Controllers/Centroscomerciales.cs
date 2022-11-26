using Microsoft.AspNetCore.Mvc;

namespace Aplicacion_Centros_Comerciales.Controllers
{
    public class Centroscomerciales : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult CentrocomercialView(string change)
        {
            if (change == "1")
            {
                return View("CentrocomercialPortal80");
            }
            if (change=="2")
            {
                return View("CentrocomercialAndino");
            }
            if(change=="3")
            {
                return View("CentrocomercialParquelacolina");
            }

            return View();
        }
    }
}
