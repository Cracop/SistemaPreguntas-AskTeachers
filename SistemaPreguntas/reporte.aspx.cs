using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;

namespace SistemaPreguntas
{
    public partial class reporte : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            updateGridViews();
            //Checar que de verdad haya entrado como administrador
            if (Session["usuarioAdministrador"] == null)
            {
                Session.Abandon();
                Response.Redirect("login.aspx");
            }
            Panel4.Visible = false;//Esconde el panel que me deja borrar la pregunta
            if (DropAlumnos.Items.Count == 0)
                //Carga los nombres de los alumnos al dropdown
            {
                String queryDropDown = "select Usuario,Nombre from Alumno";
                OdbcConnection conexion = new ConexionBD().con;
                OdbcCommand comando = new OdbcCommand(queryDropDown, conexion);
                OdbcDataReader lector = comando.ExecuteReader();
                DropAlumnos.DataSource = lector;
                DropAlumnos.DataValueField = "Usuario";
                DropAlumnos.DataTextField = "Nombre";
                DropAlumnos.DataBind();
                DropAlumnos.Items.Insert(0, new ListItem("Todos", ""));
            }

            if (DropProfesores.Items.Count == 0)
                //Carga el nombre de los profesores al dropdown
            {
                String queryDropDown = "select Usuario,Nombre from Prof";
                OdbcConnection conexion = new ConexionBD().con;
                OdbcCommand comando = new OdbcCommand(queryDropDown, conexion);
                OdbcDataReader lector = comando.ExecuteReader();
                DropProfesores.DataSource = lector;
                DropProfesores.DataValueField = "Usuario";
                DropProfesores.DataTextField = "Nombre";
                DropProfesores.DataBind();
                DropProfesores.Items.Insert(0, new ListItem("Todos", ""));
            }

        }

        protected void updateGridViews()
        {
            //Preguntas no contestadas
            String query = "select Folio,prof.Nombre as 'Profesor',alumno.nombre as 'Alumno',FechaPregunta,Pregunta from Pregunta inner join Prof on Pregunta.UsuarioProf=Prof.Usuario inner join Alumno on pregunta.UsuarioAlumno = Alumno.usuario where Pregunta.Respuesta is null";
            bool filtroAlum = false;
            bool filtroProf = false;

            if(!DropAlumnos.SelectedValue.ToString().Equals("") || !DropProfesores.SelectedValue.ToString().Equals(""))//Si algun filtro esta seleccionado
            {
                if (!DropAlumnos.SelectedValue.ToString().Equals("") && !DropProfesores.SelectedValue.ToString().Equals(""))//Si ambos filtros lo estan
                {
                    filtroAlum = true;
                    filtroProf = true;
                    query = "select Folio,prof.Nombre as 'profesor',alumno.nombre as 'alumno',FechaPregunta,Pregunta from Pregunta " +
                        "inner join Prof on Pregunta.UsuarioProf=Prof.Usuario inner join Alumno on pregunta.UsuarioAlumno = Alumno.usuario where Pregunta.Respuesta is " +
                        "null and alumno.usuario = ? and prof.usuario = ?";
                }
                else//si solo uno lo esta
                {
                    if (!DropAlumnos.SelectedValue.ToString().Equals(""))//Solo esta seleccionado el alumno
                    {
                        filtroAlum = true;
                        query = "select Folio,prof.Nombre as 'profesor',alumno.nombre as 'alumno',FechaPregunta,Pregunta from Pregunta " +
                        "inner join Prof on Pregunta.UsuarioProf=Prof.Usuario inner join Alumno on pregunta.UsuarioAlumno = Alumno.usuario where Pregunta.Respuesta is " +
                        "null and alumno.usuario = ?";

                    }
                    else//Solo esta seleccionado el prof
                    {
                        filtroProf = true;
                        query = "select Folio,prof.Nombre as 'profesor',alumno.nombre as 'alumno',FechaPregunta,Pregunta from Pregunta " +
                            "inner join Prof on Pregunta.UsuarioProf=Prof.Usuario inner join Alumno on pregunta.UsuarioAlumno = Alumno.usuario where Pregunta.Respuesta is " +
                            "null and prof.usuario = ?";
                    }
                }
            }
 

            ConexionBD objetoParaConexion = new ConexionBD();
            OdbcConnection conexion = objetoParaConexion.con;
            OdbcCommand comando = new OdbcCommand(query, conexion);

            if(filtroAlum || filtroProf)//Algun filtro esta seleccionado
            {
                if (filtroProf && filtroAlum)//Ambos filtros
                {
                    comando.Parameters.AddWithValue("alumno.usuario", DropAlumnos.SelectedValue.ToString());
                    comando.Parameters.AddWithValue("prof.usuario", DropProfesores.SelectedValue.ToString());
                    
                }
                else
                {
                    if (filtroAlum)//Solo alumnos
                    {
                        comando.Parameters.AddWithValue("alumno.usuario", DropAlumnos.SelectedValue.ToString());
                    }
                    else //Solo profesores
                    {
                        comando.Parameters.AddWithValue("prof.usuario", DropProfesores.SelectedValue.ToString());
                    }
                }
            }

            OdbcDataReader lector = comando.ExecuteReader();
            GridSinContestar.DataSource = lector;
            GridSinContestar.DataBind();

            //Preguntas contestadas
            query = "select Folio,prof.Nombre as 'profesor',alumno.nombre as 'alumno',FechaPregunta,Pregunta,FechaRespuesta,Respuesta from Pregunta inner join Prof on Pregunta.UsuarioProf=Prof.Usuario inner join Alumno on pregunta.UsuarioAlumno = Alumno.usuario where Pregunta.Respuesta is not null";
            filtroAlum = false;
            filtroProf = false;

            if (!DropAlumnos.SelectedValue.ToString().Equals("") || !DropProfesores.SelectedValue.ToString().Equals(""))//Si algun filtro esta seleccionado
            {
                if (!DropAlumnos.SelectedValue.ToString().Equals("") && !DropProfesores.SelectedValue.ToString().Equals(""))//Si ambos filtros lo estan
                {
                    filtroAlum = true;
                    filtroProf = true;
                    query = "select Folio,prof.Nombre as 'profesor',alumno.nombre as 'alumno',FechaPregunta,Pregunta,FechaRespuesta,Respuesta from Pregunta " +
                        "inner join Prof on Pregunta.UsuarioProf=Prof.Usuario inner join Alumno on pregunta.UsuarioAlumno = Alumno.usuario where Pregunta.Respuesta is " +
                        "not null and alumno.usuario = ? and prof.usuario = ?";
                }
                else//si solo uno lo esta
                {
                    if (!DropAlumnos.SelectedValue.ToString().Equals(""))//Solo esta seleccionado el alumno
                    {
                        filtroAlum = true;
                        query = "select Folio,prof.Nombre as 'profesor',alumno.nombre as 'alumno',FechaPregunta,Pregunta,FechaRespuesta,Respuesta from Pregunta " +
                        "inner join Prof on Pregunta.UsuarioProf=Prof.Usuario inner join Alumno on pregunta.UsuarioAlumno = Alumno.usuario where Pregunta.Respuesta is " +
                        "not null and alumno.usuario = ?";

                    }
                    else//Solo esta seleccionado el prof
                    {
                        filtroProf = true;
                        query = "select Folio,prof.Nombre as 'profesor',alumno.nombre as 'alumno',FechaPregunta,Pregunta,FechaRespuesta,Respuesta from Pregunta " +
                            "inner join Prof on Pregunta.UsuarioProf=Prof.Usuario inner join Alumno on pregunta.UsuarioAlumno = Alumno.usuario where Pregunta.Respuesta is " +
                            "not null and prof.usuario = ?";
                    }
                }
            }


            objetoParaConexion = new ConexionBD();
            conexion = objetoParaConexion.con;
            comando = new OdbcCommand(query, conexion);

            if (filtroAlum || filtroProf)//Algun filtro esta seleccionado
            {
                if (filtroProf && filtroAlum)//Ambos filtros
                {
                    comando.Parameters.AddWithValue("alumno.usuario", DropAlumnos.SelectedValue.ToString());
                    comando.Parameters.AddWithValue("prof.usuario", DropProfesores.SelectedValue.ToString());

                }
                else
                {
                    if (filtroAlum)//Solo alumnos
                    {
                        comando.Parameters.AddWithValue("alumno.usuario", DropAlumnos.SelectedValue.ToString());
                    }
                    else //Solo profesores
                    {
                        comando.Parameters.AddWithValue("prof.usuario", DropProfesores.SelectedValue.ToString());
                    }
                }
            }

            lector = comando.ExecuteReader();
            GridContestado.DataSource = lector;
            GridContestado.DataBind();
        }

        protected void ButtonRegresar_Click(object sender, EventArgs e)
            //Me regresa a la ventana del administrador
        {
            Response.Redirect("administrador.aspx");
        }



        protected void Filtrar_Click(object sender, EventArgs e)
            //Filtra las preguntas de acuerdo al alumno y profesor seleccionado
        {
            //Boton de Filtro
            updateGridViews();
        }

        protected void GridSinContestar_SelectedIndexChanged(object sender, EventArgs e)
            //Pregunta sin contestar seleccionada
        {
            Panel4.Visible = true;
            LabelFechaRespuesta.Visible = false;
            LabelRespuesta.Visible = false;
            TextBoxRespuesta.Visible = false;
            Panel4.Focus();

            LabelFolio.Text = GridSinContestar.SelectedRow.Cells[1].Text;//Folio de la pregunta
            LabelProfesor.Text = GridSinContestar.SelectedRow.Cells[2].Text;//Profesor a quien se le hizo la pregunta
            LabelAlumno.Text = GridSinContestar.SelectedRow.Cells[3].Text;//Alumno que hizo la pregunta
            LabelFechaPregunta.Text = GridSinContestar.SelectedRow.Cells[4].Text;//Fecha en la que se hizo la pregunta
            LabelPregunta.Text = GridSinContestar.SelectedRow.Cells[5].Text;//Pregunta

        }

        protected void GridContestado_SelectedIndexChanged(object sender, EventArgs e)
        {
            Panel4.Visible = true;
            LabelFechaRespuesta.Visible = true;
            LabelRespuesta.Visible = true;
            TextBoxRespuesta.Visible = true;
            Panel4.Focus();

            LabelFolio.Text = GridContestado.SelectedRow.Cells[1].Text;//Folio de la pregunta
            LabelProfesor.Text = GridContestado.SelectedRow.Cells[2].Text;//Profesor a quien se le hizo la pregunta
            LabelAlumno.Text = GridContestado.SelectedRow.Cells[3].Text;//Alumno que hizo la pregunta
            LabelFechaPregunta.Text = GridContestado.SelectedRow.Cells[4].Text;//Fecha en la que se hizo la pregunta
            LabelPregunta.Text = GridContestado.SelectedRow.Cells[5].Text;//Pregunta
            LabelFechaRespuesta.Text = "Fecha de Respuesta: " + GridContestado.SelectedRow.Cells[6].Text;//Fecha de respuesta
            TextBoxRespuesta.Text = System.Web.HttpUtility.HtmlDecode(GridContestado.SelectedRow.Cells[7].Text);//Respuesta
        }

        protected void ButtonBorrar_Click(object sender, EventArgs e)
        {
            String query = "delete from pregunta where folio=?";
            OdbcConnection conexion = new ConexionBD().con;
            OdbcCommand comando = new OdbcCommand(query, conexion);
            comando.Parameters.AddWithValue("folio", LabelFolio.Text);
            try
            {
                comando.ExecuteNonQuery();
            }
            catch
            {

            }
            updateGridViews();
        }
    }
}