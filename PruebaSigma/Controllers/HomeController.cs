using SigmaDepartamentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PruebaSigma.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ObtenerDepartamentos()
        {
            // Consultar método que consume API URL de Departamentos:
            Task<string> taskDistribucionGeo = Task.Run(() => SigmaDistribucionGeo.ObtenerDepartamentos());
            taskDistribucionGeo.Wait();

            return new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = taskDistribucionGeo.Result
            };
        }
    }
}