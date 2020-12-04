using PruebaSigma.Models;
using PruebaSigma.Models.Repo.Visitante;
using PruebaSigma.Validacion;
using SigmaDB;
using SigmaDepartamentos;
using System.Threading.Tasks;
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

            //Definir respuesta en formato JSON
            return new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = taskDistribucionGeo.Result
            };
        }

        [HttpPost]
        public ActionResult GuardarVisitante(visitante visitante)
        {
            //Definir respuesta en formato JSON
            JsonResult jsonResult = new JsonResult(){ JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            MsgResponse validacionCampos = ValidarCampos.Validar(visitante);
            if(!validacionCampos.Success)
            {
                jsonResult.Data = validacionCampos;
                return jsonResult;
            }

            int visitanteId = VisitanteBD.GuardarVisitante(visitante);
            if (visitanteId == 0)
                 jsonResult.Data = RegisterResponse.ERROR_REGISTRO;
            else
            {
                MsgResponse response = RegisterResponse.REGISTRO_EXITOSO;
                response.VisitanteId = visitanteId;
                jsonResult.Data = response;
            }
            return jsonResult;
        }
    }
}