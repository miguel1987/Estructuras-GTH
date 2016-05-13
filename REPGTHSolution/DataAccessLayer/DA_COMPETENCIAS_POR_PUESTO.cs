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
  public  class DA_COMPETENCIAS_POR_PUESTO
    {


      public List<BE_COMPETENCIAS_POR_PUESTO>SeleccionarCompetenciasPorPuestoyTipo(Guid PUESTO_ID, Guid COMPETENCIA_TIPO_ID)
      {

          SqlConnection cnx = new SqlConnection();
          DbDataReader dr;
          cnx = DC_Connection.getConnection();
          List<BE_COMPETENCIAS_POR_PUESTO> oCOMPETENCIASPORPUESTO = null;
          try
          {
              using (SqlCommand objCmd = new SqlCommand()
              {
                  Connection = cnx,
                  CommandType = CommandType.StoredProcedure,
                  CommandText = "USP_COMPETENCIA_PUESTO_SELECCIONAR_POR_PUESTO_Y_TIPO"
              })
              {

                  objCmd.Parameters.Add("@PUESTO_ID", SqlDbType.UniqueIdentifier).Value =PUESTO_ID;
                  objCmd.Parameters.Add("@COMPETENCIA_TIPO_ID", SqlDbType.UniqueIdentifier).Value =COMPETENCIA_TIPO_ID;


                  cnx.Open();
                  dr = objCmd.ExecuteReader();

                  // Se crea una variable tipo int por cada posicion de cada campo
                  int COMPETENCIA_ID = dr.GetOrdinal("COMPETENCIA_ID");
                  int COMPETENCIA_DESCRIPCION = dr.GetOrdinal("COMPETENCIA_DESCRIPCION");
                  int COMPETENCIA_PUESTO_VALOR_REQUERIDO = dr.GetOrdinal("COMPETENCIA_PUESTO_VALOR_REQUERIDO");
                  int EVALUACION_COMPETENCIA_VALOR_REAL = dr.GetOrdinal("EVALUACION_COMPETENCIA_VALOR_REAL");
                  int EVALUACION_COMPETENCIA_BRECHA = dr.GetOrdinal("EVALUACION_COMPETENCIA_BRECHA");
                  int EVALUACION_COMPETENCIA_COMENTARIO = dr.GetOrdinal("EVALUACION_COMPETENCIA_COMENTARIO");
                  int EVALUACION_COMPETENCIA_ESTADO = dr.GetOrdinal("EVALUACION_COMPETENCIA_ESTADO");

                  // creamos un objeto del tamaño de la tupla en el array de objeto Valores
                  object[] Valores = new object[dr.FieldCount];

                  // Preguntamos si el DbDataReader tiene registros
                  if (dr.HasRows)
                  {

                      // Instancionamos la lista para empezar a setearla
                      oCOMPETENCIASPORPUESTO = new List<BE_COMPETENCIAS_POR_PUESTO>();
                      while (dr.Read())
                      {
                          // Obetemos los valores para la tupla
                          dr.GetValues(Valores);
                          BE_COMPETENCIAS_POR_PUESTO oBE_COMPETENCIASPUESTO = new BE_COMPETENCIAS_POR_PUESTO();
                          oBE_COMPETENCIASPUESTO.COMPETENCIA_ID = (Guid)Valores.GetValue(COMPETENCIA_ID);
                          oBE_COMPETENCIASPUESTO.COMPETENCIA_DESCRIPCION = Valores.GetValue(COMPETENCIA_DESCRIPCION).ToString();
                          oBE_COMPETENCIASPUESTO.COMPETENCIA_PUESTO_VALOR_REQUERIDO = (int)Valores.GetValue(COMPETENCIA_PUESTO_VALOR_REQUERIDO);
                          oBE_COMPETENCIASPUESTO.REAL = (int)Valores.GetValue(EVALUACION_COMPETENCIA_VALOR_REAL);
                          oBE_COMPETENCIASPUESTO.BRECHA = (int)Valores.GetValue(EVALUACION_COMPETENCIA_BRECHA);
                          oBE_COMPETENCIASPUESTO.COMENTARIO =Valores.GetValue(EVALUACION_COMPETENCIA_COMENTARIO).ToString();
                          oBE_COMPETENCIASPUESTO.ESTADO_EVALUACION = (int)Valores.GetValue(EVALUACION_COMPETENCIA_ESTADO);

                          oCOMPETENCIASPORPUESTO.Add(oBE_COMPETENCIASPUESTO);
                      }
                  }


              }

              return oCOMPETENCIASPORPUESTO;
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


      public int EvaluacionFinalGrabar(Guid PUESTO_ID)
      {

          SqlConnection cnx = new SqlConnection();
          DbDataReader dr;
          int evaluacion = 0;
          cnx = DC_Connection.getConnection();
          
          try
          {
              using (SqlCommand objCmd = new SqlCommand()
              {
                  Connection = cnx,
                  CommandType = CommandType.StoredProcedure,
                  CommandText = "USP_COMPETENCIAS_PUESTOS_EVALUACION_FINAL_GRABAR"
              })
              {

                  objCmd.Parameters.Add("@PUESTO_ID", SqlDbType.UniqueIdentifier).Value = PUESTO_ID;



                  cnx.Open();
                  evaluacion =(int) objCmd.ExecuteScalar();

              }

              return evaluacion;
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
