﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaSigma.Models
{
    public class MsgResponse
    {
        public bool Success { get; set; }
        public string Mensaje { get; set; }
        public int VisitanteId { get; set; }
    }
}