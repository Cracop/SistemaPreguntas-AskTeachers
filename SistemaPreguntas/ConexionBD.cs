using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Odbc;
namespace SistemaPreguntas
{
    public class ConexionBD
    {
        //Aqui van los atributos de la clase
        public OdbcConnection con { get; set; }

        public ConexionBD()
        {
            //Abrir el web config para sacar el string de conexion
            System.Configuration.Configuration webConfig;
            webConfig = System.Web.Configuration
                .WebConfigurationManager
                .OpenWebConfiguration("/SistemaPreguntas"); //<-- hay que decirle donde se encuentra el web.config
            //Sacar el string de conexion del web config
            System.Configuration.ConnectionStringSettings connectionString;
            connectionString = webConfig
                .ConnectionStrings
                .ConnectionStrings["BDPreguntas"];
            con = new OdbcConnection(connectionString.ToString());
            con.Open();
        }
    }

}