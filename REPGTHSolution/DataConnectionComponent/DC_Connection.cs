using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace DataConnectionComponent
{
    /// <summary>
    /// En esta clase se encuentran los metodos para configurar la cadena de conexión a la base de datos
    /// </summary>
    public class DC_Connection
    {        
        public static string connStr = ConfigurationManager.ConnectionStrings["SFT_VIRTUAL"].ConnectionString;
       

        /// <summary>
        /// Método que devuelve la cadena de conexión a la base de datos.
        /// </summary>        
        /// <returns>Devuelve la cadena de conexión a la base de datos</returns>
        public static SqlConnection getConnection()
        {            
            SqlConnection cnxSftVirtual = new SqlConnection();
           
            cnxSftVirtual.ConnectionString = connStr;

            return cnxSftVirtual;

        }
    }
}
