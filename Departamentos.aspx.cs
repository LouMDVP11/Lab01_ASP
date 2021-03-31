using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab01_ASP
{
    public partial class Contact : Page
    {
        List<clsDepartamento> lstDepartamentos = new List<clsDepartamento>();
        protected void Button1_Click(object sender, EventArgs e)
        {
            clsDepartamento departamentoTemp = lstDepartamentos.Find(es => es.NoIdentificacion == txtNoIdentificacion.Text);
            if (departamentoTemp == null)
            {
                string nombre=txtNombre.Text.Trim();
                if (txtNoIdentificacion.Text.Trim().Length > 0 && !(nombre == ""))
                {
                    if (departamentoTemp == null && Convert.ToInt32(txtNoIdentificacion.Text) > 0 )
                    {
                        string fileName = Server.MapPath("Departamentos.txt");
                        FileStream stream;
                        if (lstDepartamentos.Count == 0) stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
                        else stream = new FileStream(fileName, FileMode.Append, FileAccess.Write);
                        StreamWriter writer = new StreamWriter(stream);
                        clsDepartamento nuevoDepartamento = new clsDepartamento();
                        nuevoDepartamento.NoIdentificacion = txtNoIdentificacion.Text.Trim();
                        nuevoDepartamento.Nombre = txtNombre.Text.Trim();
                        writer.WriteLine(nuevoDepartamento.NoIdentificacion);
                        writer.WriteLine(nuevoDepartamento.Nombre);
                        writer.Close();
                        this.lstDepartamentos.Add(nuevoDepartamento);
                        lstNoId.Items.Clear();
                        lstNoId.DataValueField = "NoIdentificacion";
                        lstNoId.DataTextField = "NoIdentificacion";
                        lstNoId.DataSource = lstDepartamentos;
                        lstNoId.DataBind();
                        lstNombre.Items.Clear();
                        lstNombre.DataValueField = "Nombre";
                        lstNombre.DataTextField = "Nombre";
                        lstNombre.DataSource = lstDepartamentos;
                        lstNombre.DataBind();
                        string script = "alert(\"Se ha registrado el departamento exitosamente.\");";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                              "ServerControlScript", script, true);
                        txtNoIdentificacion.Text = "";
                        txtNombre.Text = "";
                    }
                    else
                    {
                        string script = "alert(\"El numero de identificacion no es valido.\");";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                                "ServerControlScript", script, true);
                    }
                }
                else
                {
                    string script = "alert(\"Debe llenar todos los datos.\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                            "ServerControlScript", script, true);
                }
            }
            else
            {
                string script = "alert(\"El no. de identificación de departamento ya existe.\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                        "ServerControlScript", script, true);
                txtNoIdentificacion.Text = "";
            }

        }
        private void loadData() {
            lstDepartamentos = new List<clsDepartamento>();
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
            reader.Close(); if (!IsPostBack)
            if (lstDepartamentos.Count > 0)
            {
                lstNoId.Items.Clear();
                lstNoId.DataValueField = "NoIdentificacion";
                lstNoId.DataTextField = "NoIdentificacion";
                lstNoId.DataSource = lstDepartamentos;
                lstNoId.DataBind();
                lstNombre.Items.Clear();
                lstNombre.DataValueField = "Nombre";
                lstNombre.DataTextField = "Nombre";
                lstNombre.DataSource = lstDepartamentos;
                lstNombre.DataBind();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            loadData();
        }
    }
}