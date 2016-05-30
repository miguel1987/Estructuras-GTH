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



       public static List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES> SeleccionarCompetenciasTransversalesPorPersonal(Guid PERSONAL_ID)
      {

          SqlConnection cnx = new SqlConnection();
          DbDataReader dr;
          cnx = DC_Connection.getConnection();
          List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES> oCOMPETENCIASTRANSVERSALESPORPERSONAL = null;
          try
          {
              using (SqlCommand objCmd = new SqlCommand()
              {
                  Connection = cnx,
                  CommandType = CommandType.StoredProcedure,
                  CommandText = "USP_EVALUACIONES_COMPETENCIA_TRANSVERSALES_SELECCIONAR_POR_PERSONAL"
              })
              {

                  objCmd.Parameters.Add("@PERSONAL_ID", SqlDbType.UniqueIdentifier).Value = PERSONAL_ID;
                  


                  cnx.Open();
                  dr = objCmd.ExecuteReader();

                  // Se crea una variable tipo int por cada posicion de cada campo
                  int COMPETENCIA_TRANSVERSAL_ID = dr.GetOrdinal("COMPETENCIA_TRANSVERSAL_ID");
                  int COMPETENCIA_TRANSVERSAL_CODIGO = dr.GetOrdinal("COMPETENCIA_TRANSVERSAL_CODIGO");
                  int COMPETENCIA_TRANSVERSAL_DESCRIPCION = dr.GetOrdinal("COMPETENCIA_TRANSVERSAL_DESCRIPCION");
                  int EVALUACION_COMPETENCIA_TRANSVERSAL_PORCENTAJE = dr.GetOrdinal("EVALUACION_COMPETENCIA_TRANSVERSAL_PORCENTAJE");
                  

                  // creamos un objeto del tamaño de la tupla en el array de objeto Valores
                  object[] Valores = new object[dr.FieldCount];

                  // Preguntamos si el DbDataReader tiene registros
                  if (dr.HasRows)
                  {

                      // Instancionamos la lista para empezar a setearla
                      oCOMPETENCIASTRANSVERSALESPORPERSONAL = new List<BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES>();
                      while (dr.Read())
                      {
                          // Obetemos los valores para la tupla
                          dr.GetValues(Valores);
                          BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES oBE_COMPETENCIASPERSONAL = new BE_EVALUACIONES_COMPETENCIAS_TRANSVERSALES();
                          oBE_COMPETENCIASPERSONAL.COMPETENCIA_TRANSVERSAL_ID = (Guid)Valores.GetValue(COMPETENCIA_TRANSVERSAL_ID);
                          oBE_COMPETENCIASPERSONAL.CODIGO = Valores.GetValue(COMPETENCIA_TRANSVERSAL_CODIGO).ToString();
                          oBE_COMPETENCIASPERSONAL.COMPETENCIA_TRANSVERSAL_DESCRIPCION = Valores.GetValue(COMPETENCIA_TRANSVERSAL_DESCRIPCION).ToString();
                          oBE_COMPETENCIASPERSONAL.PORCENTAJE = (decimal)Valores.GetValue(EVALUACION_COMPETENCIA_TRANSVERSAL_PORCENTAJE);

                          oCOMPETENCIASTRANSVERSALESPORPERSONAL.Add(oBE_COMPETENCIASPERSONAL);
                      }
                  }


              }

              return oCOMPETENCIASTRANSVERSALESPORPERSONAL;
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


       public static int ParametroSistemaporValor(String PARAMETRO_DESCRIPCION)
       {

           SqlConnection cnx = new SqlConnection();

           cnx = DC_Connection.getConnection();

           try
           {
               using (SqlCommand objCmd = new SqlCommand()
               {
                   Connection = cnx,
                   CommandType = CommandType.StoredProcedure,
                   CommandText = "USP_PARAMETROS_SISTEMA_POR_VALOR"
               })
               {
                   objCmd.Parameters.Add("@CODIGO ", SqlDbType.VarChar).Value = PARAMETRO_DESCRIPCION;

                   cnx.Open();
                   Int32 valor = Convert.ToInt32(objCmd.ExecuteScalar());

                   return valor;

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
