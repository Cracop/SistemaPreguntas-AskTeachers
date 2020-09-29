using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;

namespace SistemaPreguntas
{
    public partial class nuevoAlum : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("login.aspx");
        }

        protected void ButtonCreate_Click(object sender, EventArgs e)
        {
            //insert into Alumno values('emi',1,'Emilio','pass'); 
            //Usuario, CU, Nombre, Passwd
            String queryNuevo = "insert into Alumno values(?,?,?,?)";
            //Creo la conexión
            OdbcConnection conexion = new ConexionBD().con;
            OdbcCommand nuevoAlumno = new OdbcCommand(queryNuevo, conexion);
           
            try
            {
                int cu = Int32.Parse(TextCU.Text);
                if (cu < 1)
                {
                    throw new Exception();
                }//if-then
                if (TextUser.Text == "")//Checo que el usuario no esté vacio
                {
                    throw new Exception("No puedes dejar el usuario vació");
                }
                if (TextName.Text == "")//Checo que el nombre no este vacio
                {
                    throw new Exception("No puedes dejar el nombre vació");
                }

                nuevoAlumno.Parameters.AddWithValue("Usuario", TextUser.Text);
                nuevoAlumno.Parameters.AddWithValue("CU", cu);
                nuevoAlumno.Parameters.AddWithValue("Nombre", TextName.Text);
                if (TextPass1.Text != TextPass2.Text)
                {
                    LabelExcep.Text = "Las contraseñas no coinciden";
                }//if
                else
                {
                    if(TextPass1.Text == "")//Checo que la contreseña no este vacía
                    {
                        LabelExcep.Text = "Tiene que ser una contraseña válida";
                    }//if
                    else
                    {
                        nuevoAlumno.Parameters.AddWithValue("Passwd", TextPass2.Text);

                        try
                        {

                            LabelExcep.Text = "";
                            nuevoAlumno.ExecuteNonQuery();

                            Session["usuarioAlumno"] = TextUser.Text;
                            Session["nombreUsuario"] = TextName.Text;
                            Session.Timeout = 15;
                            Response.Redirect("alumno.aspx");

                        }//try
                        catch (Exception ex)
                        {
                            LabelExcep.Text = "Ese usuario ya esta tomado. Elige otro.";//ex.Message;
                        }//catch 
                    }//else
                    
                }//else
            }//try
            catch
            {
                LabelExcep.Text = "Tienes que poner una Clave Única válida";
            }//catch
            

        }//Metodo
    }
}