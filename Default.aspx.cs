using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab01_ASP
{
    public partial class _Default : Page
    {
        List<clsDepartamento> lstDepartamentos = new List<clsDepartamento>();
        List<clsTemperatura> lstTemperaturas = new List<clsTemperatura>();
        List<clsTemp> lstAux = new List<clsTemp>();
        double temperaturaProm;
        protected void Page_Load(object sender, EventArgs e)
        {
            leer();
        }
        private void leer()
        {
            lstDepartamentos = new List<clsDepartamento>();
            lstTemperaturas = new List<clsTemperatura>();
            lstAux = new List<clsTemp>();
            string fileName = Server.MapPath("Departamentos.txt");
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                clsDepartamento departamentoTemp = new clsDepartamento();
                departamentoTemp.NoIdentificacion = reader.ReadLine();
                departamentoTemp.Nombre = reader.ReadLine();
                lstDepartamentos.Add(departamentoTemp);
            }
            reader.Close();
            string fileName2 = Server.MapPath("Temperaturas.txt");
            FileStream stream2 = new FileStream(fileName2, FileMode.Open, FileAccess.Read);
            StreamReader reader2 = new StreamReader(stream2);
            while (reader2.Peek() > -1)
            {
                clsTemperatura temperaturaTemp = new clsTemperatura();
                temperaturaTemp.NoIdentificacion = reader2.ReadLine();
                temperaturaTemp.Grados = Convert.ToInt32(reader2.ReadLine());
                temperaturaTemp.Fecha = Convert.ToDateTime(reader2.ReadLine());
                lstTemperaturas.Add(temperaturaTemp);
            }
            reader2.Close();
            temperaturaProm = 0;
            foreach (var l in lstTemperaturas)
            {
                foreach (var d in lstDepartamentos)
                {
                    if (l.NoIdentificacion == d.NoIdentificacion)
                    {
                        clsTemp aux = new clsTemp();
                        aux.Temperatura = l.Grados;
                        aux.Nombre = d.Nombre;
                        aux.Temp = aux.Temp + "°C";
                        lstAux.Add(aux);
                    }
                }
            }
            if (lstDepartamentos.Count > 0)
            {
                DropDownList1.DataValueField = "NoIdentificacion";
                DropDownList1.DataTextField = "Nombre";
                DropDownList1.DataSource = lstDepartamentos;
                DropDownList1.DataBind();
            }
            if (lstTemperaturas.Count > 0)
            {
                
            }
            foreach (var l in lstTemperaturas)
            {
                temperaturaProm += l.Grados;
            }
            temperaturaProm = temperaturaProm / lstTemperaturas.Count;
            lblTemp.Text = temperaturaProm + " °C";
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int tempP = 0;
            clsDepartamento depTemp = lstDepartamentos.Find(d => d.NoIdentificacion == DropDownList1.SelectedValue.ToString());
            if(depTemp!=null)
                foreach (var t in lstTemperaturas) {
                    if (depTemp.NoIdentificacion.Equals(t.NoIdentificacion)) {
                        tempP += t.Grados;
                    }    
                }
            lblTemp.Text = "Temperatura promedio en el Departamento: " + tempP + "°C";
        }
    }
}