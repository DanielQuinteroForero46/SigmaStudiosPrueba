using PruebaSigma.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PruebaSigma.Validacion
{
    public static class ValidarCampos
    {
        public static MsgResponse Validar(object form)
        {
            MsgResponse errorVal = new MsgResponse()
            {
                Mensaje = "",
                Success = true
            };
            try
            {
                //Obtener y validar DataAnnotations asociados a la clase del objeto form
                ValidationContext validationContext = new ValidationContext(form, null, null);
                List<ValidationResult> errors = new List<ValidationResult>();
                Validator.TryValidateObject(form, validationContext, errors, true);
                if (errors.Count > 0)
                {
                    foreach (var error in errors)
                    {
                        throw new Exception(error.ErrorMessage);
                    }
                }
                return errorVal;

            }
            catch (Exception ex)
            {
                errorVal.Mensaje = ex.Message;
                errorVal.Success = false;
                return errorVal;
            }
        }

    }
}