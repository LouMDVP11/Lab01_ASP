using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab01_ASP
{
    public class clsTemp
    {
        string nombre, temp; int temperatura;
        public string Nombre { get => nombre; set => nombre = value; }
        public int Temp { get => temperatura; set => temperatura = value; }
        public string Cent { get => temp; set => temp = value; }
    }
}