using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
 using System.Configuration;

namespace DataConnectionComponent
{
    public class DC_Connection
    {
        public static string _ServerName = ".";
        public static string _DataBaseName = "IPG";
        public static string connStr = ConfigurationManager.ConnectionStrings["SFT_VIRTUAL"].ConnectionString;

        public static string ServerName
        {
            get
            {
                return _ServerName;
            }
            set
            {
                if (_ServerName == value)
                    return;
                _ServerName = value;
            }
        }
        public static string DataBaseName
        {
            get
            {
                return _DataBaseName;
            }
            set
            {
                if (_DataBaseName == value)
                    return;
                _DataBaseName = value;
            }
        }


        public static SqlConnection getConnection()
        {

            //string strCadenaConexion;
            SqlConnection cnxSftVirtual = new SqlConnection();
            /*string strServer = "";
            string strBD = "";
            strServer = ServerName;
            strBD = DataBaseName;
            strCadenaConexion = String.Format("Data Source={0};Initial Catalog={1};Integrated Security=True;", strServer, strBD);
             */
            cnxSftVirtual.ConnectionString = connStr;

            return cnxSftVirtual;

        }


    }
}
