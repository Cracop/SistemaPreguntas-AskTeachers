using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;

namespace SistemaPreguntas
{
    public partial class CambioPasswd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuarioAlumno"] == null && Session["usuarioProf"] == null)
                //Checha que algun tipo de usuario haya comenzado la sesión
            {
                Session.Abandon();
                Response.Redirect("login.aspx");
            }
 
        }

        protected void ButtoCerrar_Click(object sender, EventArgs e)
            //Cierra sesión
        {
            Session.Abandon();
            Response.Redirect("login.aspx");
        }

        protected void ButtonRegresar_Click(object sender, EventArgs e)
            //Me regresa a la ventana anterior, ya sea alumno o profesor
        {
            if (Session["usuarioAlumno"] != null)
            {
                Response.Redirect("alumno.aspx");
            }
            else
            {
                Response.Redirect("prof.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Checo que las contraseñas sean iguales
            if (TextBoxPass1.Text == TextBoxPass2.Text)
            {
                String contra = TextBoxPass2.Text;
                if(contra != "")//Esto es para evitar que la contraseña sea un string vacio
                {

                    String query = "";
                    String usuario = "";
                    

                        if (Session["usuarioAlumno"] != null)//Checo si es un alumno
                    {
                        query = "Update Alumno set Passwd = ? where usuario = ?";
                        usuario = Session["usuarioAlumno"].ToString();
                    }//if
                    else//Si no, entonces es un profesor
                    {
                        query = "Update Prof set passwd = ? where usuario = ?";
                        usuario = Session["usuarioProf"].ToString();
                    }//else
                    //Creo la conexion y paso los parametros 
                    OdbcConnection conexion = new ConexionBD().con;
                    OdbcCommand comando = new OdbcCommand(query, conexion);
                    comando.Parameters.AddWithValue("passwd", contra);
                    comando.Parameters.AddWithValue("usuario", usuario);

                    //Ejecuto el comando
                    try
                    {
                        comando.ExecuteNonQuery();
                        LabelExep.Text = "Cambio de Contraseña Exitoso";
                        TextBoxPass1.Text = TextBoxPass2.Text = "";//Limpio los texfields

                    }catch(Exception ex)
                    {
                        LabelExep.Text = "Hubo un error al momento de cambiar la contraseña";
                    }

                }//if
                else
                {
                    LabelExep.Text = "Tienes que colocar una contraseña valida";
                }
            }//if
            else
            {
                LabelExep.Text = "Las contraseñas no coinciden";
            }//else
        }
    }
}