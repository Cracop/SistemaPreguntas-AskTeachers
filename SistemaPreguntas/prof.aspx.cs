using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;
namespace SistemaPreguntas
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Checa si hizo login como Profesor
            if (Session["usuarioProf"]==null)
            {
                Session.Abandon();
                Response.Redirect("login.aspx");
            }
            else
            {
                //Dar bienvenida, ocultar panel de seleccion y cargar GridViews
                Label1.Text = Session["nombreUsuario"].ToString();
                Panel1.Visible = false;
                updateGridViews();
                //Llenar DropDownList
                if (DropDownList1.Items.Count == 0)
                {
                    
                    String queryDropDown = "select Usuario,Nombre+' (CU:'+str(CU)+')' as NomCU from Alumno";
                    OdbcConnection conexion = new ConexionBD().con;
                    OdbcCommand comando = new OdbcCommand(queryDropDown, conexion);
                    OdbcDataReader lector = comando.ExecuteReader();
                    DropDownList1.DataSource = lector;
                    DropDownList1.DataValueField = "Usuario";
                    DropDownList1.DataTextField = "NomCU";
                    DropDownList1.DataBind();
                    DropDownList1.Items.Insert(0, new ListItem("Todos", ""));
                }

            }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Boton de Cerrar Sesion
            Session.Abandon();
            Response.Redirect("login.aspx");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Pregunta por responder seleccionada
            //Cargar datos de Pregunta en panel de seleccion
            Label3.Text = GridView1.SelectedRow.Cells[1].Text; //Folio
            Label5.Text = GridView1.SelectedRow.Cells[2].Text; //Alumno
            Label6.Text = GridView1.SelectedRow.Cells[4].Text; //Fecha Pregunta
            Label7.Text = "\""+GridView1.SelectedRow.Cells[5].Text+"\""; //Pregunta
            TextBox1.Text = ""; //Respuesta
            Label8.Text = ""; //Fecha Respuesta
            Panel1.Visible = true; //Panel de Seleccion
            Label4.Text = ""; //Mensaje exito/error
            Button2.Enabled = true; //Boton Mandar Respuesta
            TextBox1.Focus();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //Boton de contestar pregunta
            string folio =GridView1.SelectedRow.Cells[1].Text;
            string respuesta = TextBox1.Text;
            string query = "update Pregunta set Respuesta=?,fechaRespuesta=GETDATE() where folio=?";
            OdbcConnection conexion = new ConexionBD().con;
            OdbcCommand comando = new OdbcCommand(query, conexion);
            comando.Parameters.AddWithValue("Respuesta", respuesta);
            comando.Parameters.AddWithValue("folio", folio);
            try
            {
                comando.ExecuteNonQuery();
                Label4.Text = "Se contesto la pregunta";
            }
            catch (Exception ex)
            {
                Label4.Text = "Error al contestar pregunta:" + ex.ToString();
            }
            conexion.Close();
            updateGridViews();

        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Pregunta contestada seleccionada
            //Cargar datos de Pregunta en Panel de Seleccion
            Label3.Text = GridView2.SelectedRow.Cells[1].Text; //Folio
            Label5.Text = GridView2.SelectedRow.Cells[2].Text; //Alumno
            Label6.Text = GridView2.SelectedRow.Cells[4].Text; //Fecha Pregunta
            Label7.Text = "\"" + GridView2.SelectedRow.Cells[5].Text + "\""; //Pregunta
            Label8.Text="Fecha Respuesta: "+ GridView2.SelectedRow.Cells[7].Text; //Fecha Respuesta
            TextBox1.Text= System.Web.HttpUtility.HtmlDecode(GridView2.SelectedRow.Cells[6].Text); //Respuesta
            Panel1.Visible = true; //Panel Seleccion
            Button2.Enabled = false; //Boton Mandar Respuesta
            Label4.Text = ""; //Mensaje exito/error
            Panel1.Focus();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //Boton de Filtro
            updateGridViews();

        }
        protected void updateGridViews()
        {
            //Metodo que carga los datos de ambos GridViews.Determina si hay algun filtro y
            //cambia el query y agrega el parametro. Se usa varias veces.
            //GridView de Preguntas por contestar
            string query = "select Folio,Nombre,Alumno.CU,FechaPregunta,Pregunta from Pregunta inner join Alumno on Pregunta.UsuarioAlumno=Alumno.Usuario where Pregunta.Respuesta is null and Pregunta.UsuarioProf=?";
            bool filtro = false;
            if (!DropDownList1.SelectedValue.ToString().Equals(""))
            {
                query= "select Folio,Nombre,Alumno.CU,FechaPregunta,Pregunta from Pregunta inner join Alumno on Pregunta.UsuarioAlumno=Alumno.Usuario where Pregunta.Respuesta is null and Pregunta.UsuarioProf=? and Pregunta.UsuarioAlumno=?";
                filtro = true;              
            }
            ConexionBD objetoParaConexion = new ConexionBD();
            OdbcConnection conexion = objetoParaConexion.con;
            OdbcCommand comando = new OdbcCommand(query, conexion);
            comando.Parameters.AddWithValue("Pregunta.UsuarioProf", Session["usuarioProf"]);
            if (filtro)
            {
                comando.Parameters.AddWithValue("Pregunta.UsuarioAlumno", DropDownList1.SelectedValue.ToString());

            }
            OdbcDataReader lector = comando.ExecuteReader();
            GridView1.DataSource = lector;
            GridView1.DataBind();
            //GridView de Preguntas contestadas
            query = "select Folio,Nombre,Alumno.CU,FechaPregunta,Pregunta,Respuesta,FechaRespuesta from Pregunta inner join Alumno on Pregunta.UsuarioAlumno=Alumno.Usuario where Pregunta.Respuesta is not null and Pregunta.UsuarioProf=?";
            if (filtro) {
                query = "select Folio,Nombre,Alumno.CU,FechaPregunta,Pregunta,Respuesta,FechaRespuesta from Pregunta inner join Alumno on Pregunta.UsuarioAlumno=Alumno.Usuario where Pregunta.Respuesta is not null and Pregunta.UsuarioProf=? and Pregunta.UsuarioAlumno=?";

            }
            objetoParaConexion = new ConexionBD();
            conexion = objetoParaConexion.con;
            comando = new OdbcCommand(query, conexion);
            comando.Parameters.AddWithValue("Pregunta.UsuarioProf", Session["usuarioProf"]);
            if (filtro)
            {
                comando.Parameters.AddWithValue("Pregunta.UsuarioAlumno", DropDownList1.SelectedValue.ToString());

            }
            lector = comando.ExecuteReader();
            GridView2.DataSource = lector;
            GridView2.DataBind();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ButtonCambio_Click(object sender, EventArgs e)
        {
            Response.Redirect("CambioPasswd.aspx");
        }
    }
}