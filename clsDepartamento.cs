using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab01_ASP
{
    public class clsDepartamento
    {
        string noIdentificacion, nombre;

        public string NoIdentificacion { get => noIdentificacion; set => noIdentificacion = value; }
        public string Nombre { get => nombre; set => nombre = value; }
    }
}