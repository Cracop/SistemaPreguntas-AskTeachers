using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;

namespace SistemaPreguntas
{
    public partial class alumno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Checa si hizo login como Alumno
            if (Session["usuarioAlumno"] == null)
            {
                Session.Abandon();
                Response.Redirect("login.aspx");
            }
            //Dar bienvenida, ocultar panel de seleccion y cargar GridViews
            Label1.Text = Session["nombreUsuario"].ToString();
            Panel1.Visible = false;
            updateGridViews();
            //DropDownList de Profesores en Nueva Pregunta
            if (DropDownList1.Items.Count == 0)
            {
                String queryDropDown = "select Usuario,Nombre from Prof";
                OdbcConnection conexion = new ConexionBD().con;
                OdbcCommand comando = new OdbcCommand(queryDropDown, conexion);
                OdbcDataReader lector = comando.ExecuteReader();
                DropDownList1.DataSource = lector;
                DropDownList1.DataValueField = "Usuario";
                DropDownList1.DataTextField = "Nombre";
                DropDownList1.DataBind();
            }
            //DropDownList de Profesores en Filtro
            if (DropDownList2.Items.Count == 0)
            {
                String queryDropDown = "select Usuario,Nombre from Prof";
                OdbcConnection conexion = new ConexionBD().con;
                OdbcCommand comando = new OdbcCommand(queryDropDown, conexion);
                OdbcDataReader lector = comando.ExecuteReader();
                DropDownList2.DataSource = lector;
                DropDownList2.DataValueField = "Usuario";
                DropDownList2.DataTextField = "Nombre";
                DropDownList2.DataBind();
                DropDownList2.Items.Insert(0, new ListItem("Todos", ""));
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Botton de Cerrar Sesion
            Session.Abandon();
            Response.Redirect("login.aspx");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Pregunta respondida seleccionada. Usuario puede ver respuesta.
            //Cargar Datos de Pregunta en Panel de Seleccion
            Label2.Text = GridView1.SelectedRow.Cells[1].Text; //Folio
            Label3.Text = GridView1.SelectedRow.Cells[3].Text; //Fecha Pregunta
            Label4.Text = "Fecha Respuesta: "+GridView1.SelectedRow.Cells[5].Text; //Fecha Respuesta
            Label8.Text = GridView1.SelectedRow.Cells[4].Text; //Pregunta
            Label9.Text = "Respuesta: \"" + GridView1.SelectedRow.Cells[6].Text + "\""; //Respuesta
            Label7.Text= GridView1.SelectedRow.Cells[2].Text; //Profesor
            Panel1.Visible = true;
            Button2.Visible = false;
            Button3.Visible = false;
            TextBox1.Visible = false;
            Panel1.Focus();    

        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Pregunta no contestada seleccionada
            //Cargar Pregunta en Panel de Seleccion 
            Label2.Text = GridView2.SelectedRow.Cells[1].Text; //Folio
            Label3.Text = GridView2.SelectedRow.Cells[3].Text; //Fecha Pregunta
            //byte[] bytes = System.Text.UTF8Encoding.Default.GetBytes(GridView2.SelectedRow.Cells[4].Text);
            //TextBox1.Text = System.Text.UTF8Encoding.UTF8.GetString(bytes);

            TextBox1.Text = System.Web.HttpUtility.HtmlDecode(GridView2.SelectedRow.Cells[4].Text); //Pregunta
            Label7.Text = GridView2.SelectedRow.Cells[2].Text; //Profesor
            Label6.Text = ""; //Respuesta
            Label4.Text = ""; //Fecha Respuesta
            Panel1.Visible = true;
            Button2.Enabled = true;
            Button3.Enabled = true;
            Label6.Text = "";
            Label9.Text = "";
            Label8.Text = "";
            Button2.Visible = true;
            Button3.Visible = true;
            TextBox1.Visible = true;
            Panel1.Focus();

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //Editar Pregunta
            string folio = GridView2.SelectedRow.Cells[1].Text;
            string pregunta = TextBox1.Text;
            string query = "update Pregunta set Pregunta=? where folio=?";
            OdbcConnection conexion = new ConexionBD().con;
            OdbcCommand comando = new OdbcCommand(query, conexion);
            comando.Parameters.AddWithValue("Pregunta", pregunta);
            comando.Parameters.AddWithValue("folio", folio);
            try
            {
                comando.ExecuteNonQuery();
                Label6.Text = "Edito la pregunta exitosamente";
                
            }
            catch (Exception ex)
            {
                Label6.Text = "Error al editar pregunta:" + ex.ToString();
            }
            conexion.Close();
            updateGridViews();
        }
        protected void updateGridViews()
        {
            //Metodo que carga los datos de ambos GridViews. Se usa varias veces.
            //Preguntas contestadas
            string query = "select Folio,Nombre,FechaPregunta,Pregunta,FechaRespuesta,Respuesta from Pregunta inner join Prof on Pregunta.UsuarioProf=Prof.Usuario where Pregunta.Respuesta is not null and Pregunta.UsuarioAlumno=?";
            bool filtro = false;
            if (!DropDownList2.SelectedValue.ToString().Equals(""))
            {
                query = "select Folio,Nombre,FechaPregunta,Pregunta,FechaRespuesta,Respuesta from Pregunta inner join Prof on Pregunta.UsuarioProf=Prof.Usuario where Pregunta.Respuesta is not null and Pregunta.UsuarioAlumno=? and Pregunta.UsuarioProf=?";
                filtro = true;
            }
            ConexionBD objetoParaConexion = new ConexionBD();
            OdbcConnection conexion = objetoParaConexion.con;
            OdbcCommand comando = new OdbcCommand(query, conexion);
            comando.Parameters.AddWithValue("Pregunta.UsuarioAlumno", Session["usuarioAlumno"]);
            if (filtro)
            {
                comando.Parameters.AddWithValue("Pregunta.UsuarioProf", DropDownList2.SelectedValue.ToString());

            }
            OdbcDataReader lector = comando.ExecuteReader();
            GridView1.DataSource = lector;
            GridView1.DataBind();
            //Preguntas no contestadas
            query = "select Folio,Nombre,FechaPregunta,Pregunta from Pregunta inner join Prof on Pregunta.UsuarioProf=Prof.Usuario where Pregunta.Respuesta is null and Pregunta.UsuarioAlumno=?";
            if (filtro)
            {
                query = "select Folio,Nombre,FechaPregunta,Pregunta from Pregunta inner join Prof on Pregunta.UsuarioProf=Prof.Usuario where Pregunta.Respuesta is null and Pregunta.UsuarioAlumno=? and Pregunta.UsuarioProf=?";
            }
            objetoParaConexion = new ConexionBD();
            conexion = objetoParaConexion.con;
            comando = new OdbcCommand(query, conexion);
            comando.Parameters.AddWithValue("Pregunta.UsuarioAlumno", Session["usuarioAlumno"]);
            if (filtro)
            {
                comando.Parameters.AddWithValue("Pregunta.UsuarioProf", DropDownList2.SelectedValue.ToString());
            }
            lector = comando.ExecuteReader();
            GridView2.DataSource = lector;
            GridView2.DataBind();
        }


        protected void Button4_Click(object sender, EventArgs e)
        {
            //Boton de Cancelar en Panel de Seleccion
            Panel1.Visible = false;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //Borrar pregunta
            string query = "delete from Pregunta where folio=?";
            string folio = GridView2.SelectedRow.Cells[1].Text;
            OdbcConnection conexion = new ConexionBD().con;
            OdbcCommand comando = new OdbcCommand(query, conexion);
            comando.Parameters.AddWithValue("folio", folio);
            try
            {
                comando.ExecuteNonQuery();
                Label6.Text = "Borro la pregunta exitosamente";

            }
            catch (Exception ex)
            {
                Label6.Text = "Error al borrar pregunta:" + ex.ToString();
            }
            conexion.Close();
            updateGridViews();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            //Buton de Mandar Pregunta en Nueva Pregunta
            //Intenta hacer insert con folio aleatorio hasta que se encuentre uno que no este en la BD.
            string query = "insert into Pregunta values(?,?,?,?,null,GETDATE(),null);";
            while (true)
            {
                OdbcConnection conexion = new ConexionBD().con;
                OdbcCommand comando = new OdbcCommand(query, conexion);
                comando.Parameters.AddWithValue("Folio", new Random().Next(1000000));
                comando.Parameters.AddWithValue("UsuarioAlumno", Session["usuarioAlumno"]);
                comando.Parameters.AddWithValue("UsuarioProf", DropDownList1.SelectedValue.ToString());
                comando.Parameters.AddWithValue("Pregunta", TextBox2.Text);
                try
                {
                    comando.ExecuteNonQuery();
                    Label6.Text = "Mando la pregunta exitosamente";
                    break;

                }
                catch (Exception ex)
                {
                    Label6.Text = "Error al mandar pregunta:" + ex.ToString();
                }
                conexion.Close();
            }
            TextBox2.Text = "";
            updateGridViews();
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            //Boton de Filtro
            updateGridViews();
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            Response.Redirect("CambioPasswd.aspx");
        }

        protected void ButtonCambio_Click(object sender, EventArgs e)
        {
            Response.Redirect("CambioPasswd.aspx");
        }
    }
}