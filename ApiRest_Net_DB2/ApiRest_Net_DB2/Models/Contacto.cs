using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiRest_Net_DB2.Models
{
    public class Contacto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public int Edad { get; set; }
    }
}