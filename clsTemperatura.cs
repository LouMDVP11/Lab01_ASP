using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab01_ASP
{
    public class clsTemperatura
    {
        string noIdentificacion;
        int grados;
        DateTime fecha;

        public string NoIdentificacion { get => noIdentificacion; set => noIdentificacion = value; }
        public int Grados { get => grados; set => grados = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
    }
}