using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;

namespace SistemaPreguntas
{
    public partial class nuevoProf : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Checar que de verdad haya entrado como administrador
            if (Session["usuarioAdministrador"] == null)
            {
                Session.Abandon();
                Response.Redirect("login.aspx");
            }
        }

        protected void ButtonRegresar_Click(object sender, EventArgs e)
            //Me regresa a la ventana del administrador
        {
             Response.Redirect("administrador.aspx");
        }

        protected void ButtonAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                String usuario = TextBoxUser.Text;
                String nombre = TextBoxName.Text;
                String contra1 = TextBoxPass1.Text;
                String contra2 = TextBoxPass2.Text;

                if (usuario == "")
                {
                    throw new Exception("No puedes dejar el usuario en blanco");
                }
                if (nombre == "")
                {
                    throw new Exception("No puedes dejar el nombre en blanco");
                }
                if (contra1 != contra2)
                {
                    throw new Exception("Las contraseñas no coinciden");
                }
                if (contra1 == "")
                {
                    throw new Exception("No puedes tener la contraseña en blanco");
                }
                //usuario, nombre, passwd
                String query = "insert into Prof values(?,?,?)";
                OdbcConnection conexion = new ConexionBD().con;
                OdbcCommand nuevoProf= new OdbcCommand(query, conexion);
                nuevoProf.Parameters.AddWithValue("Usuario", usuario);
                nuevoProf.Parameters.AddWithValue("Nombre", nombre);
                nuevoProf.Parameters.AddWithValue("Passwd", contra1);

               
                nuevoProf.ExecuteNonQuery();
                LabelExcep.Text = "";
                Response.Redirect("administrador.aspx");
            }
            catch(Exception ex)
            {
                LabelExcep.Text = ex.Message;
            }
        }
    }
}