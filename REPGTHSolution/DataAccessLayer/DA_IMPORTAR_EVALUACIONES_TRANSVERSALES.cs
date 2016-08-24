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
   public class DA_IMPORTAR_EVALUACIONES_TRANSVERSALES
    {
       /// <summary>
       /// Devuelve la Evaluacion al selleccionar por codigo
       /// </summary>
       /// <param name="codigo_competencia">Codigo de Competencia que se desea Consultar</param>
       /// <returns></returns>
       public string EvaluacionSeleccionarporCodigo(string codigo_competencia)
       {
           SqlConnection cnx = new SqlConnection();
           string codigo;
           cnx = DC_Connection.getConnection();
           try
           {
               using (SqlCommand objCmd = new SqlCommand()
               {
                   Connection = cnx,
                   CommandType = CommandType.StoredProcedure,
                   CommandText = "USP_COMPETENCIA_TRANSVERSAL_SELECCIONAR_POR_CODIGO"

               })
               {
                   objCmd.Parameters.Add("@COMPETENCIA_TRANSVERSAL_CODIGO", SqlDbType.VarChar).Value =codigo_competencia;
                   cnx.Open();
                 codigo =(string) objCmd.ExecuteScalar().ToString().ToUpper();
               }
               return codigo;

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


       /// <summary>
       /// Insertar a la Hora de Importar el Archivo de Evaluaciones de Competencias Transversales
       /// </summary>
       /// <param name="OBE_COMPE_TRANS">Objeto BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES con todos sus valores llenos </param>
       /// <returns></returns>
       public Boolean InsertarTransversales(BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES OBE_COMPE_TRANS)
       {
           SqlConnection cnx = new SqlConnection();
           bool bIndicador = false;

           cnx = DC_Connection.getConnection();

           try
           {

               using (
                   SqlCommand objCmd = new SqlCommand()
                   {
                       Connection = cnx,
                       CommandType = CommandType.StoredProcedure,
                       CommandText = "USP_IMPORTAR_EVALACIONES_TRANSVERSALES_INSERTAR"
                   }
                   )
               {
                   //Se crea el objeto Parameters por cada parametro
                   objCmd.Parameters.Add("@PERSONAL_ID", SqlDbType.UniqueIdentifier).Value = OBE_COMPE_TRANS.PERSONAL_ID;
                   objCmd.Parameters.Add("@COMPETENCIA_TRANSVERSAL_ID", SqlDbType.UniqueIdentifier).Value = OBE_COMPE_TRANS.COMPETENCIA_TRANSVERSAL_ID;
                   objCmd.Parameters.Add("@EVALUACION_COMPETENCIA_TRANSVERSAL_PORCENTAJE", SqlDbType.Decimal).Value =OBE_COMPE_TRANS.PORCENTAJE;
                   objCmd.Parameters.Add("@PUESTO_ID", SqlDbType.UniqueIdentifier).Value =OBE_COMPE_TRANS.PUESTO_ID;
                   objCmd.Parameters.Add("@EVALUACION_COMPETENCIA_TRANSVERSAL_ANIO", SqlDbType.Int).Value = OBE_COMPE_TRANS.ANIO;

                   objCmd.Parameters.Add("@USUARIO", SqlDbType.UniqueIdentifier).Value = OBE_COMPE_TRANS.USUARIO_CREACION;

                   cnx.Open();

                   bIndicador = objCmd.ExecuteNonQuery() > 0;
               }

           }
           catch (Exception ex)
           {
               throw new Exception("Error: " + ex.Message);

           }
           finally
           {
               cnx.Close();
           }

           return bIndicador;
       }
    }
}
