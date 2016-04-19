using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;
using DataConnectionComponent;
using BussinesEntities;

namespace DataAccessLayer
{
    /// <summary>
    /// En esta clase se encuentran todos los metodos para las consultas de la tabla COORDINACIONES
    /// </summary>
    public class DA_COORDINACION
    {
        /// <summary>
        ///  Devuelve los datos de todas las coordinaciones.
        /// </summary>
        /// <returns> List de BE_COORDINACION con los objetos de la entidad, que a su vez representan la tabla COORDINACIONES de la base de datos.En caso no haiga datos devuelve nothing </returns>
        public List<BE_COORDINACION> SeleccionarCoordinaciones()
        {

            SqlConnection cnx = new SqlConnection();
            DbDataReader dr;
            cnx = DC_Connection.getConnection();
            List<BE_COORDINACION> oCOORDINACION = null;
            try
            {
                using (SqlCommand objCmd = new SqlCommand()
                {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_COORDINACION_SELECCIONAR"
                })
                {
                    cnx.Open();
                    dr = objCmd.ExecuteReader();

                    // Se crea una variable tipo int por cada posicion de cada campo
                    int COORDINACION_ID = dr.GetOrdinal("COORDINACION_ID");
                    int AREA_ID = dr.GetOrdinal("AREA_ID");
                    int COORDINACION_CODIGO = dr.GetOrdinal("COORDINACION_CODIGO");
                    int COORDINACION_DESCRIPCION = dr.GetOrdinal("COORDINACION_DESCRIPCION");
                    int USUARIO_CREACION = dr.GetOrdinal("USUARIO_CREACION");
                    int FECHA_CREACION = dr.GetOrdinal("FECHA_CREACION");
                    int USUARIO_ACTUALIZACION = dr.GetOrdinal("USUARIO_ACTUALIZACION");
                    int FECHA_ACTUALIZACION = dr.GetOrdinal("FECHA_ACTUALIZACION");
                    int COORDINACION_ESTADO = dr.GetOrdinal("COORDINACION_ESTADO");


                    // creamos un objeto del tamaño de la tupla en el array de objeto Valores
                    object[] Valores = new object[dr.FieldCount];

                    // Preguntamos si el DbDataReader tiene registros
                    if (dr.HasRows)
                    {

                        // Instancionamos la lista para empezar a setearla
                        oCOORDINACION = new List<BE_COORDINACION>();
                        while (dr.Read())
                        {
                            // Obetemos los valores para la tupla
                            dr.GetValues(Valores);
                            BE_COORDINACION oBE_COORDINACION = new BE_COORDINACION();

                            oBE_COORDINACION.ID = (Guid)Valores.GetValue(COORDINACION_ID);
                            oBE_COORDINACION.AREA_ID = (Guid)Valores.GetValue(AREA_ID);
                            oBE_COORDINACION.CODIGO = Valores.GetValue(COORDINACION_CODIGO).ToString();
                            oBE_COORDINACION.DESCRIPCION = Valores.GetValue(COORDINACION_DESCRIPCION).ToString();
                            oBE_COORDINACION.USUARIO_CREACION = (Guid)Valores.GetValue(USUARIO_CREACION);
                            oBE_COORDINACION.FECHA_CREACION = Convert.ToDateTime(Valores.GetValue(FECHA_CREACION));
                            oBE_COORDINACION.USUARIO_ACTUALIZACION = (Guid)Valores.GetValue(USUARIO_ACTUALIZACION);
                            oBE_COORDINACION.FECHA_ACTUALIZACION = Convert.ToDateTime(Valores.GetValue(FECHA_ACTUALIZACION));
                            oBE_COORDINACION.ESTADO = Convert.ToInt32(Valores.GetValue(COORDINACION_ESTADO));
                            oCOORDINACION.Add(oBE_COORDINACION);
                        }
                    }


                }

                return oCOORDINACION;
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
        /// Devuelve los datos de una coordinación específica.
        /// </summary>
        /// <param name="coordinacion_id">Codigo de la coordinación a consultar</param>
        /// <returns>BE_COORDINACION, entidad que representa la tabla COORDINACIONES, con todas sus atributos. En caso no haiga datos devuelve nothing</returns>
        public BE_COORDINACION SeleccionarCoordinacionPorId(Guid coordinacion_id)
        {

            SqlConnection cnx = new SqlConnection();
            DbDataReader dr;
            cnx = DC_Connection.getConnection();
            BE_COORDINACION oBE_COORDINACION = null;
            try
            {
                using (SqlCommand objCmd = new SqlCommand()
                {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_COORDINACION_SELECCIONAR_POR_ID"
                })
                {
                    objCmd.Parameters.Add("@COORDINACION_ID", SqlDbType.UniqueIdentifier).Value = coordinacion_id;

                    cnx.Open();
                    dr = objCmd.ExecuteReader();

                    // Se crea una variable tipo int por cada posicion de cada campo
                    int COORDINACION_ID = dr.GetOrdinal("COORDINACION_ID");
                    int COORDINACION_CODIGO = dr.GetOrdinal("COORDINACION_CODIGO");
                    int COORDINACION_DESCRIPCION = dr.GetOrdinal("COORDINACION_DESCRIPCION");
                    int COORDINACION_ESTADO = dr.GetOrdinal("COORDINACION_ESTADO");
                    int AREA_ID = dr.GetOrdinal("AREA_ID");
                    int USUARIO_CREACION = dr.GetOrdinal("USUARIO_CREACION");
                    int FECHA_CREACION = dr.GetOrdinal("FECHA_CREACION");
                    int USUARIO_ACTUALIZACION = dr.GetOrdinal("USUARIO_ACTUALIZACION");
                    int FECHA_ACTUALIZACION = dr.GetOrdinal("FECHA_ACTUALIZACION");
                    
                    // creamos un objeto del tamaño de la tupla en el array de objeto Valores
                    object[] Valores = new object[dr.FieldCount];

                    // Preguntamos si el DbDataReader tiene registros
                    if (dr.HasRows)
                    {

                        // Instancionamos la lista para empezar a setearla
                        oBE_COORDINACION = new BE_COORDINACION();
                        if (dr.Read())
                        {
                            // Obetemos los valores para la tupla
                            dr.GetValues(Valores);

                            oBE_COORDINACION.ID = (Guid)Valores.GetValue(COORDINACION_ID);                            
                            oBE_COORDINACION.CODIGO = Valores.GetValue(COORDINACION_CODIGO).ToString();
                            oBE_COORDINACION.DESCRIPCION = Valores.GetValue(COORDINACION_DESCRIPCION).ToString();
                            oBE_COORDINACION.ESTADO = Convert.ToInt32(Valores.GetValue(COORDINACION_ESTADO));
                            oBE_COORDINACION.AREA_ID = (Guid)Valores.GetValue(AREA_ID);
                            oBE_COORDINACION.USUARIO_CREACION = (Guid)Valores.GetValue(USUARIO_CREACION);
                            oBE_COORDINACION.FECHA_CREACION = Convert.ToDateTime(Valores.GetValue(FECHA_CREACION));
                            oBE_COORDINACION.USUARIO_ACTUALIZACION = (Guid)Valores.GetValue(USUARIO_ACTUALIZACION);
                            oBE_COORDINACION.FECHA_ACTUALIZACION = Convert.ToDateTime(Valores.GetValue(FECHA_ACTUALIZACION));
                        }
                    }


                }

                return oBE_COORDINACION;
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
        /// Devuelve los datos de las coordinaciones de un área específica
        /// </summary>
        /// <param name="area_id">Codigo del area al cual se desea consultar</param>
        /// <returns>BE_COORDINACION, entidad que representa la tabla COORDINACIONES, con todas sus atributos.Ademas, esa entidad trae tambien un atributo que se llama oBE_COORDINACION, donde se obtiene todos los datos de la entidad COORDINACION En caso no haiga datos devuelve nothing</returns>
        public List<BE_COORDINACION> SeleccionarCoordinacionPorArea(Guid area_id)
        {

            SqlConnection cnx = new SqlConnection();
            DbDataReader dr;
            cnx = DC_Connection.getConnection();
            List<BE_COORDINACION> oCOORDINACION = null;
            try
            {
                using (SqlCommand objCmd = new SqlCommand()
                {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_COORDDINACION_SELECCIONAR_POR_AREA"
                })
                {

                    objCmd.Parameters.Add("@AREA_ID", SqlDbType.UniqueIdentifier).Value = area_id;

                    cnx.Open();
                    dr = objCmd.ExecuteReader();

                    // Se crea una variable tipo int por cada posicion de cada campo                    
                    int COORDINACION_ID = dr.GetOrdinal("COORDINACION_ID");
                    int COORDINACION_CODIGO = dr.GetOrdinal("COORDINACION_CODIGO");
                    int COORDINACION_DESCRIPCION = dr.GetOrdinal("COORDINACION_DESCRIPCION");
                    int COORDINACION_ESTADO = dr.GetOrdinal("COORDINACION_ESTADO");
                    int AREA_ID = dr.GetOrdinal("AREA_ID");
                    int USUARIO_CREACION = dr.GetOrdinal("USUARIO_CREACION");
                    int FECHA_CREACION = dr.GetOrdinal("FECHA_CREACION");
                    int USUARIO_ACTUALIZACION = dr.GetOrdinal("USUARIO_ACTUALIZACION");
                    int FECHA_ACTUALIZACION = dr.GetOrdinal("FECHA_ACTUALIZACION");



                    // creamos un objeto del tamaño de la tupla en el array de objeto Valores
                    object[] Valores = new object[dr.FieldCount];

                    // Preguntamos si el DbDataReader tiene registros
                    if (dr.HasRows)
                    {
                        // instanciamos la entidad de Coordinacion para relacionar el objeto con área
                        oCOORDINACION = new List<BE_COORDINACION>();
                        while (dr.Read())
                        {
                            // Obetemos los valores para la tupla
                            dr.GetValues(Valores);


                            BE_COORDINACION oBE_COORDINACION = new BE_COORDINACION();

                            // Seteamos los valores del Area
                            oBE_COORDINACION.ID = (Guid)Valores.GetValue(COORDINACION_ID);
                            oBE_COORDINACION.CODIGO = Valores.GetValue(COORDINACION_CODIGO).ToString();
                            oBE_COORDINACION.DESCRIPCION = Valores.GetValue(COORDINACION_DESCRIPCION).ToString();
                            oBE_COORDINACION.ESTADO = Convert.ToSByte(Valores.GetValue(COORDINACION_ESTADO));
                            oBE_COORDINACION.AREA_ID = (Guid)Valores.GetValue(AREA_ID);
                            oBE_COORDINACION.USUARIO_CREACION = (Guid)Valores.GetValue(USUARIO_CREACION);
                            oBE_COORDINACION.FECHA_CREACION = Convert.ToDateTime(Valores.GetValue(FECHA_CREACION));
                            oBE_COORDINACION.USUARIO_ACTUALIZACION = (Guid)Valores.GetValue(USUARIO_ACTUALIZACION);
                            oBE_COORDINACION.FECHA_ACTUALIZACION = Convert.ToDateTime(Valores.GetValue(FECHA_ACTUALIZACION));
                            
                            oCOORDINACION.Add(oBE_COORDINACION);
                        }
                    }


                }

                return oCOORDINACION;
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
