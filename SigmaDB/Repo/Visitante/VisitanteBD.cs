using System;
using SigmaDB;
using System.Data.Entity;
using System.Linq;
using System.Diagnostics;

namespace PruebaSigma.Models.Repo.Visitante
{
    public class VisitanteBD
    {
        public static bool GuardarVisitante(visitante visitante)
        {
            try
            {
                bool success = visitante == null ? false : true;
                if (success)
                {
                    using (var context = new SigmaPruebaDBEntities())
                    {
                        context.Entry(visitante).State = EntityState.Added;

                        success = context.SaveChanges() > 0 ? true : false;
                        context.Dispose();
                    }
                }
                return success;
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message, "Error al guardar Visitante");
                return false;
            }
        }
    }
}