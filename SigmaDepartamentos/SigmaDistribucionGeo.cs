using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace SigmaDepartamentos
{
    public class SigmaDistribucionGeo
    {
        // Consumir API URL de departamentos:
        public static async Task<string> ObtenerDepartamentos()
        {
            try
            {
                List<object> listDistribucionGeo = new List<object>();
                //Obtener URL parametrizada en el Web.config:
                string urlDepartamentos = WebConfigurationManager.AppSettings["url_departamentos"];
                HttpClient httpClient = new HttpClient();
                string json = await httpClient.GetStringAsync(urlDepartamentos);

                return json;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return "";
            }
        }
    }
}
