using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab01_ASP
{
    public partial class About : Page
    {
        List<clsDepartamento> lstDepartamentos = new List<clsDepartamento>();
        List<clsTemperatura> lstTemperaturas = new List<clsTemperatura>();
        List<clsTemp> lstAux = new List<clsTemp>();
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
            foreach (var l in lstTemperaturas)
            {
                foreach (var d in lstDepartamentos)
                {
                    if (l.NoIdentificacion == d.NoIdentificacion)
                    {
                        clsTemp aux = new clsTemp();
                        aux.Temp = l.Grados;
                        aux.Nombre = d.Nombre;
                        aux.Cent = aux.Temp + "°C";
                        lstAux.Add(aux);
                    }
                }
            }
            if (!IsPostBack)
                if (lstDepartamentos.Count > 0)
                {
                    DropDownList1.Items.Clear();
                    DropDownList1.DataValueField = "NoIdentificacion";
                    DropDownList1.DataTextField = "NoIdentificacion";
                    DropDownList1.DataSource = lstDepartamentos;
                    DropDownList1.DataBind();
                    mostrarDep();
                }
            if (lstTemperaturas.Count > 0)
            {
                GridView1.DataSource = null;
                GridView1.DataSource = lstTemperaturas;
                GridView1.DataBind();
            }

        }
        protected void txtNombre0_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (txtTemperatura.Text.Trim().Length > 0)
            {
                FileStream stream;
                string fileName = Server.MapPath("Temperaturas.txt");
                if (lstDepartamentos.Count == 0) stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
                else stream = new FileStream(fileName, FileMode.Append, FileAccess.Write);
                StreamWriter writer = new StreamWriter(stream);
                clsTemperatura nuevaTemp = new clsTemperatura();
                nuevaTemp.NoIdentificacion = DropDownList1.SelectedValue.ToString();
                nuevaTemp.Grados = Convert.ToInt32(txtTemperatura.Text); ;
                nuevaTemp.Fecha = Calendar1.SelectedDate;
                writer.WriteLine(nuevaTemp.NoIdentificacion);
                writer.WriteLine(nuevaTemp.Grados);
                writer.WriteLine(nuevaTemp.Fecha);
                writer.Close();
                this.lstTemperaturas.Add(nuevaTemp);
                txtTemperatura.Text = "";
                DropDownList1.SelectedIndex = 0;
                string script = "alert(\"Registro agregado exitosamente.\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                        "ServerControlScript", script, true);
                leer();
            }
            else
            {
                string script = "alert(\"Debe agregar una temperatura\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                        "ServerControlScript", script, true);
            }
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            mostrarDep();
        }
        public void mostrarDep()
        {
            clsDepartamento depTemp = lstDepartamentos.Find(d => d.NoIdentificacion == DropDownList1.SelectedItem.ToString());
            txtNombre.Text = depTemp.Nombre;
        }
    }
}