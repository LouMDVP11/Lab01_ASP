using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab01_ASP
{
    public class clsTemp
    {
        string nombre, temp; int temperatura;
        public int Temperatura { get => temperatura; set => temperatura = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Temp { get => temp; set => temp = value; }
    }
}