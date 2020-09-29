using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;

namespace SistemaPreguntas
{
    public partial class administrador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Checar que de verdad haya entrado como administrador
            if (Session["usuarioAdministrador"] == null)
            {
                Session.Abandon();
                Response.Redirect("https://www.youtube.com/watch?v=dQw4w9WgXcQ");
            }
            upgradeGridViews();
            updateResumen();


        }
        protected void updateResumen()
        {
            //Resumen
            //Alumno
            string query = "select UsuarioAlumno, Alumno.CU,Alumno.Nombre,count(UsuarioAlumno) as 'Preguntas Hechas',sum(case when Respuesta is not null then 1 else 0 end) as 'Con Respuesta',(sum(case when Respuesta is not null then 1 else 0 end)*100.0)/ count(UsuarioAlumno) as '% Con Respuesta' from Pregunta inner join Alumno on Pregunta.UsuarioAlumno = Alumno.Usuario group by UsuarioAlumno,Alumno.CU,Alumno.Nombre";
            OdbcConnection conexion = new ConexionBD().con;
            OdbcCommand comando = new OdbcCommand(query, conexion);
            OdbcDataReader lector = comando.ExecuteReader();
            ResumenAlum.DataSource = lector;
            ResumenAlum.DataBind();
            //Prof
            query = "select UsuarioProf, Prof.Nombre,count(UsuarioProf) as 'Preguntas Recibidas',sum(case when Respuesta is not null then 1 else 0 end) as 'Contestadas',(sum(case when Respuesta is not null then 1 else 0 end)*100.0)/ count(UsuarioAlumno) as '% Contestadas' from Pregunta inner join Prof on Pregunta.UsuarioProf = Prof.Usuario group by UsuarioProf,Prof.Nombre";
            comando = new OdbcCommand(query, conexion);
            lector = comando.ExecuteReader();
            ResumenProf.DataSource = lector;
            ResumenProf.DataBind();
            //Totales
            LabelTotalPreguntas.Text = simpleQuery("select count(Folio) from Pregunta");
            LabelTotalAlumnos.Text = simpleQuery("select count(Usuario) from Alumno");
            LabelTotalProfesores.Text = simpleQuery("select count(Usuario) from Prof");
        }
        protected string simpleQuery(string query) {
            OdbcConnection conexion = new ConexionBD().con;
            OdbcCommand comando = new OdbcCommand(query, conexion);
            OdbcDataReader lector = comando.ExecuteReader();
            if (lector.HasRows)
            {
                return lector.GetString(0);
            }
            return "";
        }

        protected void ButtonCerrar_Click(object sender, EventArgs e)
            //Cierra la sesion
        {
            Session.Abandon();
            Response.Redirect("login.aspx");
        }

        protected void TotsProf_SelectedIndexChanged(object sender, EventArgs e)
        //Te permite seleccionar a un profesor de la gridview
        {
            LabelFn.Text = TotsProf.SelectedRow.Cells[1].Text;//Usuario
            TextBoxNameProf.Text = System.Web.HttpUtility.HtmlDecode(TotsProf.SelectedRow.Cells[2].Text);//Nombre
            TextBoxPassProf.Attributes["value"] = cProf(LabelFn.Text);//Contraseña
            LabelFn.Focus();
        }

        protected void upgradeGridViews()
            //Se encarga de cargar la informacion en las gridviews
        {
            //Carga la info al gridview de alumnos
            String query = "select Usuario, CU, Nombre from Alumno";
            ConexionBD objetoParaConexion = new ConexionBD();
            OdbcConnection conexion = objetoParaConexion.con;
            OdbcCommand comando = new OdbcCommand(query, conexion);
            OdbcDataReader lector = comando.ExecuteReader();
            TotsAlum.DataSource = lector;
            TotsAlum.DataBind();

            //Carga la info al gridview de profes
            query = "select Usuario, Nombre from Prof";
            comando = new OdbcCommand(query, conexion);
            lector = comando.ExecuteReader();
            TotsProf.DataSource = lector;
            TotsProf.DataBind();

        }

        protected void TotsAlum_SelectedIndexChanged(object sender, EventArgs e)
            //Te permite seleccionar a un alumno de la gridview
        {
            LabelAn.Text = TotsAlum.SelectedRow.Cells[1].Text;//Usuario
            TextBoxCU.Text = TotsAlum.SelectedRow.Cells[2].Text;//CU
            TextBoxNameAlum.Text = System.Web.HttpUtility.HtmlDecode(TotsAlum.SelectedRow.Cells[3].Text);//Nombre
            TextBoxPassAlum.Attributes["value"] = cAlumno(LabelAn.Text);//Contraseña
            LabelAn.Focus();
        }

        protected String cAlumno(String usuario)
            //Te da la contraseña del alumno indicado
        {
            String query = "select passwd from Alumno where Usuario=?";
            OdbcConnection conexion = new ConexionBD().con;
            OdbcCommand comando = new OdbcCommand(query, conexion);
            comando.Parameters.AddWithValue("Usuario", usuario);
            OdbcDataReader lector = comando.ExecuteReader();
            lector.Read();
            return lector.GetString(0);
        }
        protected String cProf(String usuario)
            //Te da la contraseña del prof indicado
        {
            String query = "select passwd from Prof where Usuario = ?";
            OdbcConnection conexion = new ConexionBD().con;
            OdbcCommand comando = new OdbcCommand(query, conexion);
            comando.Parameters.AddWithValue("Usuario", usuario);
            OdbcDataReader lector = comando.ExecuteReader();
            lector.Read();
            return lector.GetString(0);

        }

        protected void ButtonModAl_Click(object sender, EventArgs e)
        //Modifica el nombre, CU y contraseña del alumno seleccionado
        {
            if (LabelAn.Text == "")//Esto evita que hagas acciones cuando no tienes seleccionado a ningun usuaio
            {
                return;
            }
            String query = "update Alumno set Passwd=? ,Nombre=? , CU=? where Usuario =?";
            OdbcConnection conexion = new ConexionBD().con;
            OdbcCommand comando = new OdbcCommand(query, conexion);
            try
            {
                int cu = Int32.Parse(TextBoxCU.Text);
                if (cu < 1)
                {
                    throw new Exception("Debe de ser una Clave Única válida");
                }

                comando.Parameters.AddWithValue("Passwd", TextBoxPassAlum.Text);
                comando.Parameters.AddWithValue("Nombre", TextBoxNameAlum.Text);
                comando.Parameters.AddWithValue("CU", cu);
                comando.Parameters.AddWithValue("Usuario", LabelAn.Text);

                comando.ExecuteNonQuery();
                LabelExcAlum.Text = "";
                upgradeGridViews();
                updateResumen();

                //Borro la seleccion
                LabelAn.Text = "";
                TextBoxPassAlum.Attributes["value"] = "";
                TextBoxNameAlum.Text = "";
                TextBoxCU.Text = "";
            }
            catch(Exception ex)
            {
                LabelExcAlum.Text = ex.Message;
            }

        }

        protected void ButtonModProd_Click(object sender, EventArgs e)
            //Modifica el nombre y contraseña del profesor que tienes seleccionado
        {
            if (LabelFn.Text == "")//Esto evita que hagas acciones cuando no tienes seleccionado a ningun usuaio
            {
                return;
            }
            String query = "update Prof set Passwd=?,Nombre=? where Usuario=?";
            OdbcConnection conexion = new ConexionBD().con;
            OdbcCommand comando = new OdbcCommand(query, conexion);

            comando.Parameters.AddWithValue("Passwd", TextBoxPassProf.Text);
            comando.Parameters.AddWithValue("Nombre", TextBoxNameProf.Text);
            comando.Parameters.AddWithValue("Usuario", LabelFn.Text);

            try
            {
                comando.ExecuteNonQuery();
                LabelExcProf.Text = "";
                upgradeGridViews();
                updateResumen();

                //Borro la seleccion
                LabelFn.Text = "";
                TextBoxPassProf.Attributes["value"] = "";
                TextBoxNameProf.Text = "";
            }
            catch(Exception ex)
            {
                LabelExcProf.Text = ex.Message;
            }
        }

        protected void ButtonAddProf_Click(object sender, EventArgs e)
            //Te manda a la pagina para agregar un nuevo profesor
        {
            Response.Redirect("nuevoProf.aspx");
        }

        protected void ButtonBorrarAlum_Click(object sender, EventArgs e)
            //Se elimina al alumno que se tiene seleccionado
        {
            if (LabelAn.Text == "")//Esto evita que hagas acciones cuando no tienes seleccionado a ningun usuaio
            {
                return;
            }
            borrarPreguntasAlum(LabelAn.Text);
            String query = "delete from Alumno where Usuario =?";
            OdbcConnection conexion = new ConexionBD().con;
            OdbcCommand comando = new OdbcCommand(query, conexion);
            comando.Parameters.AddWithValue("Usuario", LabelAn.Text);
            try
            {
                comando.ExecuteNonQuery();
                LabelExcAlum.Text = "";
                upgradeGridViews();
                updateResumen();

                //Borro la seleccion
                LabelAn.Text = "";
                TextBoxPassAlum.Attributes["value"] = "";
                TextBoxNameAlum.Text = "";
                TextBoxCU.Text = "";
            }
            catch(Exception ex)
            {
                LabelExcAlum.Text=ex.Message;
            }

        }
        protected void borrarPreguntasAlum(String usuarioAlumno)
            //Se encarga de borrar todas las preguntas hechas por el alumno indicado
        {
            String query = "delete from pregunta where UsuarioAlumno=?";
            OdbcConnection conexion = new ConexionBD().con;
            OdbcCommand comando = new OdbcCommand(query, conexion);
            comando.Parameters.AddWithValue("UsuarioAlumno", usuarioAlumno);
            try
            {
                comando.ExecuteNonQuery();
                LabelExcAlum.Text = "";
            }
            catch (Exception ex)
            {
                LabelExcAlum.Text = ex.Message;
            }
        }

        protected void borrarPreguntasProf(String usuarioProf)
            //Se encarga de borrar todas las preguntas al profesor indicado
        {
            String query = "delete from pregunta where UsuarioProf=?";
            OdbcConnection conexion = new ConexionBD().con;
            OdbcCommand comando = new OdbcCommand(query, conexion);
            comando.Parameters.AddWithValue("UsuarioProf", usuarioProf);
            try
            {
                comando.ExecuteNonQuery();
                LabelExcProf.Text = "";
            }
            catch (Exception ex)
            {
                LabelExcProf.Text = ex.Message;
            }
        }

        protected void ButtonBorrarProfe_Click(object sender, EventArgs e)
        {
            if (LabelFn.Text == "")//Esto evita que hagas acciones cuando no tienes seleccionado a ningun usuario
            {
                return;
            }
            borrarPreguntasProf(LabelFn.Text);
            String query = "delete from Prof where Usuario =?";
            OdbcConnection conexion = new ConexionBD().con;
            OdbcCommand comando = new OdbcCommand(query, conexion);
            comando.Parameters.AddWithValue("Usuario", LabelFn.Text);
            try
            {
                comando.ExecuteNonQuery();
                LabelExcProf.Text = "";
                upgradeGridViews();
                updateResumen();

                //Borro la seleccion
                LabelFn.Text = "";
                TextBoxPassProf.Attributes["value"] = "";
                TextBoxNameProf.Text="";

            }
            catch (Exception ex)
            {
                LabelExcProf.Text = ex.Message;
            }
        }

        protected void ButtonReporte_Click(object sender, EventArgs e)
        {
            Response.Redirect("reporte.aspx");
        }
    }
}