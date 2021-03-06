﻿using System;
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
      /// <summary>
      /// Se lista las competencias por puesto y tipo
      /// </summary>
      /// <param name="PUESTO_ID">Codigo del Puesto que se desea consultar</param>
      /// <param name="COMPETENCIA_TIPO_ID">Codigo de Tipo de Competencia que se desea consultar</param>
      /// <returns></returns>
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


      /// <summary>
      /// Se Lista la competencia por puesto y tipo se sobre carga el metodo
      /// </summary>
      /// <param name="PUESTO_ID">Codigo del Puesto que sea desea consultar</param>
      /// <param name="COMPETENCIA_TIPO_ID">Codigo del Tipo de Competencia que se desea consultar</param>
      /// <param name="PERSONAL_ID">Codigo de Personal que se desea consultar</param>
      /// <returns></returns>
      public List<BE_COMPETENCIAS_POR_PUESTO> SeleccionarCompetenciasPorPuestoyTipo(Guid PUESTO_ID, Guid COMPETENCIA_TIPO_ID, Guid PERSONAL_ID)
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
                  CommandText = "USP_COMPETENCIA_PUESTO_SELECCIONAR_POR_PUESTO_Y_TIPO_PERSONAL"
              })
              {

                  objCmd.Parameters.Add("@PUESTO_ID", SqlDbType.UniqueIdentifier).Value = PUESTO_ID;
                  objCmd.Parameters.Add("@COMPETENCIA_TIPO_ID", SqlDbType.UniqueIdentifier).Value = COMPETENCIA_TIPO_ID;
                  objCmd.Parameters.Add("@PERSONAL_ID", SqlDbType.UniqueIdentifier).Value = PERSONAL_ID;

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
                          oBE_COMPETENCIASPUESTO.COMENTARIO = Valores.GetValue(EVALUACION_COMPETENCIA_COMENTARIO).ToString();
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

      /// <summary>
      /// Devuelve la lista de compentencias por puesto a consultar
      /// </summary>
      /// <returns></returns>
      public List<BE_COMPETENCIAS_POR_PUESTO> SeleccionarCompetenciasPorPuesto()
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
                  CommandText = "USP_COMPETENCIA_PUESTO_SELECCIONAR"
              })
              {
                  cnx.Open();
                  dr = objCmd.ExecuteReader();

                  // Se crea una variable tipo int por cada posicion de cada campo
                  int COMPETENCIA_PUESTO_ID = dr.GetOrdinal("COMPETENCIA_PUESTO_ID");
                  int PUESTO_ID = dr.GetOrdinal("PUESTO_ID");
                  int COMPETENCIA_ID = dr.GetOrdinal("COMPETENCIA_ID");
                  int COMPETENCIA_TIPO_ID = dr.GetOrdinal("COMPETENCIA_TIPO_ID");
                  int COMPETENCIA_DESCRIPCION = dr.GetOrdinal("COMPETENCIA_DESCRIPCION");
                  int COMPETENCIA_PUESTO_VALOR_REQUERIDO = dr.GetOrdinal("COMPETENCIA_PUESTO_VALOR_REQUERIDO");
                  int EMPRESA_ID = dr.GetOrdinal("EMPRESA_ID");
                  int GERENCIA_ID = dr.GetOrdinal("GERENCIA_ID");
                  int AREA_ID = dr.GetOrdinal("AREA_ID");
                  int COORDINACION_ID = dr.GetOrdinal("COORDINACION_ID");
                  int EMPRESA_DESCRIPCION = dr.GetOrdinal("EMPRESA_DESCRIPCION");
                  int GERENCIA_DESCRIPCION = dr.GetOrdinal("GERENCIA_DESCRIPCION");
                  int AREA_DESCRIPCION = dr.GetOrdinal("AREA_DESCRIPCION");                  
                  int COORDINACION_DESCRIPCION = dr.GetOrdinal("COORDINACION_DESCRIPCION");
                  int PUESTO_DESCRIPCION = dr.GetOrdinal("PUESTO_DESCRIPCION");

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
                          oBE_COMPETENCIASPUESTO.ID = (Guid)Valores.GetValue(COMPETENCIA_PUESTO_ID);
                          oBE_COMPETENCIASPUESTO.PUESTO_ID = (Guid)Valores.GetValue(PUESTO_ID);
                          oBE_COMPETENCIASPUESTO.COMPETENCIA_ID = (Guid)Valores.GetValue(COMPETENCIA_ID);
                          oBE_COMPETENCIASPUESTO.COMPETENCIA_TIPO_ID = (Guid)Valores.GetValue(COMPETENCIA_TIPO_ID);
                          oBE_COMPETENCIASPUESTO.COMPETENCIA_DESCRIPCION = Valores.GetValue(COMPETENCIA_DESCRIPCION).ToString(); 
                          oBE_COMPETENCIASPUESTO.COMPETENCIA_PUESTO_VALOR_REQUERIDO = (int)Valores.GetValue(COMPETENCIA_PUESTO_VALOR_REQUERIDO);
                          oBE_COMPETENCIASPUESTO.EMPRESA_ID = (Guid)Valores.GetValue(EMPRESA_ID);

                          BE_COMPETENCIA oBE_COMPETENCIA = new BE_COMPETENCIA();
                          oBE_COMPETENCIA.ID = oBE_COMPETENCIASPUESTO.COMPETENCIA_ID;
                          oBE_COMPETENCIA.DESCRIPCION = oBE_COMPETENCIASPUESTO.COMPETENCIA_DESCRIPCION;
                          oBE_COMPETENCIASPUESTO.oBE_COMPETENCIA = oBE_COMPETENCIA;

                          BE_COMPETENCIAS_TIPOS oBE_COMPETENCIA_TIPO = new BE_COMPETENCIAS_TIPOS();
                          DA_COMPETENCIAS_TIPOS DA_COMPETENCIAS_TIPOS = new DA_COMPETENCIAS_TIPOS();
                          oBE_COMPETENCIA_TIPO = DA_COMPETENCIAS_TIPOS.SeleccionarCompetenciasTiposPorId(oBE_COMPETENCIASPUESTO.COMPETENCIA_TIPO_ID)[0];
                          oBE_COMPETENCIASPUESTO.oBE_COMPETENCIA_TIPO = oBE_COMPETENCIA_TIPO;

                          BE_EMPRESA oBE_EMPRESA = new BE_EMPRESA();
                          oBE_EMPRESA.ID = oBE_COMPETENCIASPUESTO.EMPRESA_ID;
                          oBE_EMPRESA.DESCRIPCION = Valores.GetValue(EMPRESA_DESCRIPCION).ToString();
                          oBE_COMPETENCIASPUESTO.oBE_EMPRESA = oBE_EMPRESA;

                          BE_GERENCIA oBE_GERENCIA = new BE_GERENCIA();
                          oBE_GERENCIA.ID = (Guid)Valores.GetValue(GERENCIA_ID);
                          oBE_GERENCIA.DESCRIPCION = Valores.GetValue(GERENCIA_DESCRIPCION).ToString();
                          oBE_COMPETENCIASPUESTO.oBE_GERENCIA = oBE_GERENCIA;

                          BE_AREA oBE_AREA = new BE_AREA();
                          oBE_AREA.ID = (Guid)Valores.GetValue(AREA_ID);
                          oBE_AREA.DESCRIPCION = Valores.GetValue(AREA_DESCRIPCION).ToString();
                          oBE_COMPETENCIASPUESTO.oBE_AREA = oBE_AREA;

                          BE_COORDINACION oBE_COORDINACION = new BE_COORDINACION();
                          oBE_COORDINACION.ID = (Guid)Valores.GetValue(COORDINACION_ID);
                          oBE_COORDINACION.DESCRIPCION = Valores.GetValue(COORDINACION_DESCRIPCION).ToString();
                          oBE_COMPETENCIASPUESTO.oBE_COORDINACION = oBE_COORDINACION;

                          BE_PUESTO oBE_PUESTO = new BE_PUESTO();
                          oBE_PUESTO.ID = oBE_COMPETENCIASPUESTO.PUESTO_ID;
                          oBE_PUESTO.DESCRIPCION = Valores.GetValue(PUESTO_DESCRIPCION).ToString();
                          oBE_COMPETENCIASPUESTO.oBE_PUESTO = oBE_PUESTO;

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

      /// <summary>
      /// devuelve el tipo de evaluacion 
      /// </summary> 
      /// <param name="PUESTO_ID">Codigo de Puesto que se desea consultar</param>
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

      /// <summary>
      /// Ingresa una nueva Competencia 
      /// </summary>
      /// <param name="oBE_COMPETENCIA_PUESTO">Objeto BE_COMPETENCIAS_POR_PUESTO con todos sus campos llenos</param>
      /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
      public Boolean InsertarCompetenciaPuesto(BE_COMPETENCIAS_POR_PUESTO oBE_COMPETENCIA_PUESTO)
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
                      CommandText = "USP_COMPETENCIA_PUESTO_INSERTAR"
                  }
                  )
              {
                  //Se crea el objeto Parameters por cada parametro

                  objCmd.Parameters.Add("@PUESTO_ID", SqlDbType.UniqueIdentifier).Value = oBE_COMPETENCIA_PUESTO.PUESTO_ID;
                  objCmd.Parameters.Add("@COMPETENCIA_ID", SqlDbType.UniqueIdentifier).Value = oBE_COMPETENCIA_PUESTO.COMPETENCIA_ID;
                  objCmd.Parameters.Add("@COMPETENCIA_PUESTO_VALOR_REQUERIDO", SqlDbType.Int).Value = oBE_COMPETENCIA_PUESTO.COMPETENCIA_PUESTO_VALOR_REQUERIDO;
                  objCmd.Parameters.Add("@USUARIO", SqlDbType.UniqueIdentifier).Value = oBE_COMPETENCIA_PUESTO.USUARIO_CREACION;

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

      /// <summary>
      /// Actualizar una Competencia 
      /// </summary>
      /// <param name="oBE_COMPETENCIA_PUESTO">Objeto BE_COMPETENCIAS_POR_PUESTO con todos sus campos llenos</param>
      /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
      public Boolean ActualizarCompetenciaPuesto(BE_COMPETENCIAS_POR_PUESTO oBE_COMPETENCIA_PUESTO)
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
                      CommandText = "USP_COMPETENCIA_PUESTO_ACTUALIZAR"
                  }
                  )
              {
                  //Se crea el objeto Parameters por cada parametro
                  objCmd.Parameters.Add("@COMPETENCIA_PUESTO_ID", SqlDbType.UniqueIdentifier).Value = oBE_COMPETENCIA_PUESTO.ID;
                  objCmd.Parameters.Add("@PUESTO_ID", SqlDbType.UniqueIdentifier).Value = oBE_COMPETENCIA_PUESTO.PUESTO_ID;
                  objCmd.Parameters.Add("@COMPETENCIA_ID", SqlDbType.UniqueIdentifier).Value = oBE_COMPETENCIA_PUESTO.COMPETENCIA_ID;
                  objCmd.Parameters.Add("@COMPETENCIA_PUESTO_VALOR_REQUERIDO", SqlDbType.Int).Value = oBE_COMPETENCIA_PUESTO.COMPETENCIA_PUESTO_VALOR_REQUERIDO;
                  objCmd.Parameters.Add("@USUARIO", SqlDbType.UniqueIdentifier).Value = oBE_COMPETENCIA_PUESTO.USUARIO_CREACION;

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

      /// <summary>
      /// Eliminar una Competencia Puesto
      /// </summary>
      /// <param name="competencia_puesto_id">Identificador de la competencia puesto a eliminar</param>        
      /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
      public Boolean EliminarCompetenciaPuesto(Guid competencia_puesto_id)
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
                      CommandText = "USP_COMPETENCIA_PUESTO_ELIMINAR"
                  }
                  )
              {
                  objCmd.Parameters.Add("@COMPETENCIA_PUESTO_ID", SqlDbType.UniqueIdentifier).Value = competencia_puesto_id;


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


      /// <summary>
      /// devuelve el codigo del valor requerido
      /// </summary>
      /// <param name="oBE_COMPE_PUESTO_PERSONAL">Objeto BE_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL, con todos sus campos llenos</param>
      public int SeleccionarValorRequerido(BE_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL oBE_COMPE_PUESTO_PERSONAL)
      {
          SqlConnection cnx = new SqlConnection();
          int codigo;
          cnx = DC_Connection.getConnection();
          try
          {
              using (SqlCommand objCmd = new SqlCommand()
              {
                  Connection = cnx,
                  CommandType = CommandType.StoredProcedure,
                  CommandText = "USP_COMPETENCIAS_PUESTOS_SELECCIONAR_VALOR_REQUERIDO"

              })
              {
                  objCmd.Parameters.Add("@PUESTO_ID", SqlDbType.UniqueIdentifier).Value = oBE_COMPE_PUESTO_PERSONAL.PUESTO_ID;
                  objCmd.Parameters.Add("@COMPETENCIA_ID", SqlDbType.UniqueIdentifier).Value = oBE_COMPE_PUESTO_PERSONAL.COMPETENCIA_ID;
                  cnx.Open();
                  codigo = (int)objCmd.ExecuteScalar();
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






    }
}
