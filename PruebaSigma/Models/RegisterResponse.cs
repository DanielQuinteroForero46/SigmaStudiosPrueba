using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaSigma.Models
{
    public class RegisterResponse
    {
        public static MsgResponse ERROR_REGISTRO = new MsgResponse
        {
            Success = false,
            Mensaje = "Se ha presentado un inconveniente al registrar la información."
        };

        public static MsgResponse REGISTRO_EXITOSO = new MsgResponse
        {
            Success = true,
            Mensaje = "Tu información ha sido recibida satisfactoriamente."
        };
    }
}