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
   public class DA_COMPETENCIAS_TIPOS
    {
        /// <summary>
        ///  Devuelve los datos de todas las competencias por tipo
        /// </summary>
        /// <returns> List de BE_COMPETENCIAS_TIPOS con los objetos de la entidad, que a su vez representan la tabla COMPETENCIAS_TIPOS de la base de datos.En caso no haiga datos devuelve nothing </returns>
        /// 

       public List<BE_COMPETENCIAS_TIPOS> SeleccionarCompetenciasTipos()
       {
           SqlConnection cnx = new SqlConnection();
           DbDataReader dr;
           cnx = DC_Connection.getConnection();
           List<BE_COMPETENCIAS_TIPOS> oCOMPETENCIAS_TIPOS = null;
           try
           {
               using (SqlCommand objCmd = new SqlCommand()
                   {
                       Connection = cnx,
                       CommandType = CommandType.StoredProcedure,
                       CommandText = "USP_COMPETENCIA_TIPO_SELECCIONAR"
                   })
               {
                   cnx.Open();
                   dr = objCmd.ExecuteReader();
                   //se crea una variable tipo int por cada posicion de cada campo
                   int COMPETENCIA_TIPO_ID = dr.GetOrdinal("COMPETENCIA_TIPO_ID");
                   int COMPETENCIA_TIPO_CODIGO = dr.GetOrdinal("COMPETENCIA_TIPO_CODIGO");
                   int COMPETENCIA_TIPO_DESCRIPCION = dr.GetOrdinal("COMPETENCIA_TIPO_DESCRIPCION");
                   int USUARIOS_CREACION = dr.GetOrdinal("USUARIOS_CREACION");
                   int FECHA_CREACION = dr.GetOrdinal("FECHA_CREACION");
                   int USUARIO_ACTUALIZACION = dr.GetOrdinal("USUARIO_ACTUALIZACION");
                   int FECHA_ACTUALIZACION = dr.GetOrdinal("FECHA_ACTUALIZACION");
                   int COMPETENCIA_TIPO_ESTADO = dr.GetOrdinal("COMPETENCIA_TIPO_ESTADO");

                   // creamos un objeto del tamaño de la tupla en el array de objeto Valores
                   object[] Valores = new object[dr.FieldCount];

                   // Preguntamos si el DbDataReader tiene registros
                   if (dr.HasRows)
                   {

                       // Instancionamos la lista para empezar a setearla
                       oCOMPETENCIAS_TIPOS = new List<BE_COMPETENCIAS_TIPOS>();
                       while (dr.Read())
                       {
                           // Obetemos los valores para la tupla
                           dr.GetValues(Valores);
                          BE_COMPETENCIAS_TIPOS oBE_COMPETENCIAS_TIPOS = new BE_COMPETENCIAS_TIPOS();
                          oBE_COMPETENCIAS_TIPOS.ID = (Guid)Valores.GetValue(COMPETENCIA_TIPO_ID);
                          oBE_COMPETENCIAS_TIPOS.COMPETENCIA_TIPO_CODIGO = Valores.GetValue(COMPETENCIA_TIPO_CODIGO).ToString();
                          oBE_COMPETENCIAS_TIPOS.COMPETENCIA_TIPO_DESCRIPCION = Valores.GetValue(COMPETENCIA_TIPO_DESCRIPCION).ToString();
                          oBE_COMPETENCIAS_TIPOS.USUARIO_CREACION = (Guid)Valores.GetValue(USUARIOS_CREACION);
                          oBE_COMPETENCIAS_TIPOS.FECHA_CREACION = Convert.ToDateTime(Valores.GetValue(FECHA_CREACION));
                          oBE_COMPETENCIAS_TIPOS.USUARIO_ACTUALIZACION = (Guid)Valores.GetValue(USUARIO_ACTUALIZACION);
                          oBE_COMPETENCIAS_TIPOS.FECHA_ACTUALIZACION = Convert.ToDateTime(Valores.GetValue(FECHA_ACTUALIZACION));
                          oBE_COMPETENCIAS_TIPOS.COMPETENCIA_TIPO_ESTADO = Convert.ToInt32(Valores.GetValue(COMPETENCIA_TIPO_ESTADO));
                          oCOMPETENCIAS_TIPOS.Add(oBE_COMPETENCIAS_TIPOS);
                       }
                   }

               }
               return oCOMPETENCIAS_TIPOS;
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
       ///  Devuelve los datos de un tipo de competencia
       /// </summary>
       /// <param name="competencia_tipo_id">Codigo de Tipo Competencia que se desea Consultar</param>
       /// <returns> LIST BE_COMPETENCIAS_TIPOS con los objetos de la entidad, que a su vez representan la tabla COMPETENCIAS_TIPOS de la base de datos.En caso no haiga datos devuelve nothing </returns>
       /// 

       public List<BE_COMPETENCIAS_TIPOS> SeleccionarCompetenciasTiposPorId(Guid competencia_tipo_id)
       {
           SqlConnection cnx = new SqlConnection();
           DbDataReader dr;
           cnx = DC_Connection.getConnection();
           List<BE_COMPETENCIAS_TIPOS> oCOMPETENCIAS_TIPOS = null;
           try
           {
               using (SqlCommand objCmd = new SqlCommand()
               {
                   Connection = cnx,
                   CommandType = CommandType.StoredProcedure,
                   CommandText = "USP_COMPETENCIA_TIPO_SELECCIONAR_POR_ID"
               })
               {
                   objCmd.Parameters.Add("@COMPETENCIA_TIPO_ID", SqlDbType.UniqueIdentifier).Value = competencia_tipo_id;

                   cnx.Open();
                   dr = objCmd.ExecuteReader();
                   //se crea una variable tipo int por cada posicion de cada campo
                   int COMPETENCIA_TIPO_ID = dr.GetOrdinal("COMPETENCIA_TIPO_ID");
                   int COMPETENCIA_TIPO_CODIGO = dr.GetOrdinal("COMPETENCIA_TIPO_CODIGO");
                   int COMPETENCIA_TIPO_DESCRIPCION = dr.GetOrdinal("COMPETENCIA_TIPO_DESCRIPCION");
                   int USUARIOS_CREACION = dr.GetOrdinal("USUARIOS_CREACION");
                   int FECHA_CREACION = dr.GetOrdinal("FECHA_CREACION");
                   int USUARIO_ACTUALIZACION = dr.GetOrdinal("USUARIO_ACTUALIZACION");
                   int FECHA_ACTUALIZACION = dr.GetOrdinal("FECHA_ACTUALIZACION");
                   int COMPETENCIA_TIPO_ESTADO = dr.GetOrdinal("COMPETENCIA_TIPO_ESTADO");

                   // creamos un objeto del tamaño de la tupla en el array de objeto Valores
                   object[] Valores = new object[dr.FieldCount];

                   // Preguntamos si el DbDataReader tiene registros
                   if (dr.HasRows)
                   {

                       // Instancionamos la lista para empezar a setearla
                       oCOMPETENCIAS_TIPOS = new List<BE_COMPETENCIAS_TIPOS>();
                       while (dr.Read())
                       {
                           // Obetemos los valores para la tupla
                           dr.GetValues(Valores);
                           BE_COMPETENCIAS_TIPOS oBE_COMPETENCIAS_TIPOS = new BE_COMPETENCIAS_TIPOS();
                           oBE_COMPETENCIAS_TIPOS.ID = (Guid)Valores.GetValue(COMPETENCIA_TIPO_ID);
                           oBE_COMPETENCIAS_TIPOS.COMPETENCIA_TIPO_CODIGO = Valores.GetValue(COMPETENCIA_TIPO_CODIGO).ToString();
                           oBE_COMPETENCIAS_TIPOS.COMPETENCIA_TIPO_DESCRIPCION = Valores.GetValue(COMPETENCIA_TIPO_DESCRIPCION).ToString();
                           oBE_COMPETENCIAS_TIPOS.USUARIO_CREACION = (Guid)Valores.GetValue(USUARIOS_CREACION);
                           oBE_COMPETENCIAS_TIPOS.FECHA_CREACION = Convert.ToDateTime(Valores.GetValue(FECHA_CREACION));
                           oBE_COMPETENCIAS_TIPOS.USUARIO_ACTUALIZACION = (Guid)Valores.GetValue(USUARIO_ACTUALIZACION);
                           oBE_COMPETENCIAS_TIPOS.FECHA_ACTUALIZACION = Convert.ToDateTime(Valores.GetValue(FECHA_ACTUALIZACION));
                           oBE_COMPETENCIAS_TIPOS.COMPETENCIA_TIPO_ESTADO = Convert.ToInt32(Valores.GetValue(COMPETENCIA_TIPO_ESTADO));
                           oCOMPETENCIAS_TIPOS.Add(oBE_COMPETENCIAS_TIPOS);
                       }
                   }
               }
               return oCOMPETENCIAS_TIPOS;
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
