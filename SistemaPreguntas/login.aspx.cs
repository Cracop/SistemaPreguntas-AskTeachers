using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;
namespace SistemaPreguntas
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Checo si está en la tabla de administradores
            String usuario = TextBox1.Text;
            String passwd = TextBox2.Text;
            String query = "select Usuario, Passwd from Administrador where Usuario =? and Passwd = ?";
            OdbcConnection conexion = new ConexionBD().con;
            OdbcCommand comando = new OdbcCommand(query, conexion);
            comando.Parameters.AddWithValue("Usuario", usuario);
            comando.Parameters.AddWithValue("Passwd", passwd);
            OdbcDataReader lector = comando.ExecuteReader();
            if(lector.HasRows==true)
            {
                Session["usuarioAdministrador"] = lector.GetString(0);
                Session.Timeout = 10;
                Response.Redirect("administrador.aspx");
            }
            //Checo si está en la tabla de alumnos
            query = "select Usuario,Nombre from Alumno where Usuario=? and Passwd=?";
            comando = new OdbcCommand(query, conexion);
            comando.Parameters.AddWithValue("Usuario", usuario);
            comando.Parameters.AddWithValue("Passwd", passwd);
            lector = comando.ExecuteReader();
            if (lector.HasRows == true)
            {
                Session["usuarioAlumno"] = lector.GetString(0);
                Session["nombreUsuario"] = lector.GetString(1);
                Session.Timeout = 15;
                Response.Redirect("alumno.aspx");
            }

            //Checo si en la tabla de profesores
            query = "select Usuario,Nombre from Prof where Usuario=? and Passwd=?";
            comando = new OdbcCommand(query, conexion);
            comando.Parameters.AddWithValue("Usuario", usuario);
            comando.Parameters.AddWithValue("Passwd", passwd);
            lector = comando.ExecuteReader();
            if (lector.HasRows == true)
            {
                Session["usuarioProf"] = lector.GetString(0);
                Session["nombreUsuario"] = lector.GetString(1);
                Session.Timeout = 15;
                Response.Redirect("prof.aspx");
            }
            Label1.Text = "Credenciales Incorrectas.";
            
        }

        protected void Button2_Click(object sender, EventArgs e)
            //Me permite registrarme como nuevo alumno
        {
            Response.Redirect("nuevoAlum.aspx");
        }
    }
}