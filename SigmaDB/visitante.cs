//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SigmaDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class visitante
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Por favor selecciona el departamento")]
        [StringLength(30, ErrorMessage = "Tamaño máximo del nombre del departamento: 30 caracteres")]
        public string Departamento { get; set; }
        [Required(ErrorMessage = "Por favor selecciona la ciudad")]
        [StringLength(50, ErrorMessage = "Tamaño máximo del nombre de la ciudad: 30 caracteres")]
        public string Ciudad { get; set; }
        [Required(ErrorMessage = "Por favor ingresa tu nombre")]
        [StringLength(50, ErrorMessage = "Nombre incorrecto, demasiado largo")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Por favor ingresa tu correo")]
        [StringLength(30, ErrorMessage = "Correo incorrecto, demasiado largo")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Correo incorrecto")]
        [EmailAddress(ErrorMessage = "Correo incorrecto")]
        public string Correo { get; set; }
    }
}
