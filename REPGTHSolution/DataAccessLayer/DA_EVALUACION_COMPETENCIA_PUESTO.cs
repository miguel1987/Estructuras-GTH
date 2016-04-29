using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;
using DataConnectionComponent;
using BusinessEntities;

namespace DataAccessLayer
{
    public class DA_EVALUACION_COMPETENCIA_PUESTO
    {

        public  int SeleccionarEvaluacionEstadoPorPersonal(Guid PERSONAL_ID)
        {

            SqlConnection cnx = new SqlConnection();
            
            cnx = DC_Connection.getConnection();
           
            try
            {
                using (SqlCommand objCmd = new SqlCommand()
                {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL_SELECCIONAR_ESTADO_POR_PERSONAL_ID"
                })
                {
                    objCmd.Parameters.Add("@PERSONAL_ID ", SqlDbType.UniqueIdentifier).Value = PERSONAL_ID;

                    cnx.Open();
                    Int32 estado = Convert.ToInt32(objCmd.ExecuteScalar());                   

                    return estado;
                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cnx.Close();
            }
        }
    }
}
