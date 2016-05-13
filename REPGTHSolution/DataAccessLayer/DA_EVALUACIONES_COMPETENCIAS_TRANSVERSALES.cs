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
   public class DA_EVALUACIONES_COMPETENCIAS_TRANSVERSALES
    {
       public static decimal SeleccionarEvaluacionPorCompetenciaTransversal(Guid PERSONAL_ID,string COMPETENCIA_TRANSVERSALES_CODIGO)
       {

           SqlConnection cnx = new SqlConnection();

           cnx = DC_Connection.getConnection();

           try
           {
               using (SqlCommand objCmd = new SqlCommand()
               {
                   Connection = cnx,
                   CommandType = CommandType.StoredProcedure,
                   CommandText = "USP_EVALUACIONES_COMPETENCIA_TRANSVERSALES_SELECCIONAR_POR_PERSONA_COMPETENCIA"
               })
               {
                   objCmd.Parameters.Add("@PERSONAL_ID ", SqlDbType.UniqueIdentifier).Value = PERSONAL_ID;
                   objCmd.Parameters.Add("@COMPETENCIA_TRANSVERSAL_CODIGO ", SqlDbType.VarChar).Value = COMPETENCIA_TRANSVERSALES_CODIGO;

                   cnx.Open();
                   decimal porcentaje = Convert.ToDecimal(objCmd.ExecuteScalar());

                   return porcentaje;

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
