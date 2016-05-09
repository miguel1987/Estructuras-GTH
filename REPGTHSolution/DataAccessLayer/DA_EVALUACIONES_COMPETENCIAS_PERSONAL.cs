using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using BusinessEntities;
using DataConnectionComponent;
using System.Data;
using System.Data.Common;

namespace DataAccessLayer
{
    /// <summary>
    /// En esta clase se encuentran todos los metodos para las consultas de la tabla EVALUACIONES_COMPETENCIAS_PERSONAL
    /// </summary>
   public class DA_EVALUACIONES_COMPETENCIAS_PERSONAL
    {

        /// <summary>
        /// Inserta los datos de  EVALUACIONES_COMPETENCIAS_PERSONAL
        /// </summary>
        /// <param name="oBE_EVALUACIONES_COMPETENCIAS_PERSONAL">Objeto de tipo BE_EVALUACIONES_COMPETENCIAS_PERSONAL, que representa la tabla EVALUACIONES_COMPETENCIAS_PERSONAL, con todos sus atributos </param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
       public Boolean InsertarEvalucionCompetenciaPersonal(BE_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL oBE_EVALUACIONES_COMPETENCIAS_PERSONAL, SqlTransaction otransaction, SqlCommand objCmd)
        {
            bool bIndicador = false;

            try
            {

                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "USP_EVALUACIONES_COMPETENCIAS_PERSONAL_INSERTAR";
                objCmd.Transaction = otransaction;

                objCmd.Parameters.Clear();
                objCmd.Parameters.Add("@PERSONAL_ID", SqlDbType.UniqueIdentifier).Value = oBE_EVALUACIONES_COMPETENCIAS_PERSONAL.PERSONAL_ID;
                objCmd.Parameters.Add("@COMPETENCIA_ID", SqlDbType.UniqueIdentifier).Value = oBE_EVALUACIONES_COMPETENCIAS_PERSONAL.COMPETENCIA_ID;
                objCmd.Parameters.Add("@EVALUACION_COMPETENCIA_BRECHA", SqlDbType.Int).Value = oBE_EVALUACIONES_COMPETENCIAS_PERSONAL.BRECHA;             


                bIndicador = objCmd.ExecuteNonQuery() > 0;

                return bIndicador;

            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }


        }



       public Boolean ActalizarEvalucionCompetenciaPersonal(BE_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL oBE_EVALUACIONES_COMPETENCIAS_PERSONAL, SqlTransaction otransaction, SqlCommand objCmd)
       {
           bool bIndicador = false;

           try
           {

               objCmd.CommandType = CommandType.StoredProcedure;
               objCmd.CommandText = "USP_EVALUACIONES_COMPETENCIAS_PERSONAL_ACTUALIZAR";
               objCmd.Transaction = otransaction;

               objCmd.Parameters.Clear();
               objCmd.Parameters.Add("@EVALUACION_COMPETENCIA_BRECHA", SqlDbType.Int).Value = oBE_EVALUACIONES_COMPETENCIAS_PERSONAL.BRECHA;
               

               bIndicador = objCmd.ExecuteNonQuery() > 0;

               return bIndicador;

           }
           catch (Exception ex)
           {
               throw new Exception("Error: " + ex.Message);
           }


       }





    }
}
