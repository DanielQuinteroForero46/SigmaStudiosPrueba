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
        //Realizar validacio´n de campos de acuerdo a los DataAnnotations definidos para el objeto (visitante)
        public static MsgResponse Validar(object form)
        {
            MsgResponse errorVal = new MsgResponse()
            {
                Mensaje = "",
                Success = true
            };
            try
            {
                ValidationContext validationContext = new ValidationContext(form, null, null);
                List<ValidationResult> errors = new List<ValidationResult>();
                //Obtener y recorrer atributos de la clase para validar los DataAnnotations de cada uno:
                Validator.TryValidateObject(form, validationContext, errors, true);
                //En caso de incumplir un DataAnnotation, se genera excepción y se envía como error el mensaje definido para el DataAnnotation:
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
                //En caso de generarse excepción por incumplir algún DataAnnotation, se retorna el mensaje de error como respuesta
                errorVal.Mensaje = ex.Message;
                errorVal.Success = false;
                return errorVal;
            }
        }

    }
}