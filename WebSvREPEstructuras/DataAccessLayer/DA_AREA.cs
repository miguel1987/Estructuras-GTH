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
    /// En esta clase se encuentran todos los metodos para las consultas de la tabla AREAS
    /// </summary>
    public class DA_AREA
    {
        /// <summary>
        ///  Devuelve los datos de todas las áreas.
        /// </summary>
        /// <returns> List de BE_AREA con los objetos de la entidad, que a su vez representan la tabla AREAS de la base de datos.En caso no haiga datos devuelve nothing </returns>
        public List<BE_AREA> SeleccionarAreas()
        {

            SqlConnection cnx = new SqlConnection();
            DbDataReader dr;
            cnx = DC_Connection.getConnection();
            List<BE_AREA> oAREA = null ;
            try
            {
                using (SqlCommand objCmd = new SqlCommand() {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_AREA_SELECCIONAR" 
                })
                {
                    cnx.Open();
                    dr = objCmd.ExecuteReader();

                    // Se crea una variable tipo int por cada posicion de cada campo
                    int AREA_ID = dr.GetOrdinal("AREA_ID");
                    int AREA_CODIGO = dr.GetOrdinal("AREA_CODIGO");
                    int GERENCIA_ID = dr.GetOrdinal("GERENCIA_ID");
		            int AREA_DESCRIPCION  = dr.GetOrdinal("AREA_DESCRIPCION");
		            int USUARIO_CREACION = dr.GetOrdinal ("USUARIO_CREACION");
		            int FECHA_CREACION = dr.GetOrdinal("FECHA_CREACION");
		            int USUARIO_ACTUALIZACION = dr.GetOrdinal("USUARIO_ACTUALIZACION");
		            int FECHA_ACTUALIZACION = dr.GetOrdinal("FECHA_ACTUALIZACION");
                    int AREA_ESTADO = dr.GetOrdinal("AREA_ESTADO");


                    // creamos un objeto del tamaño de la tupla en el array de objeto Valores
                    object[] Valores = new object[dr.FieldCount];

                    // Preguntamos si el DbDataReader tiene registros
                    if (dr.HasRows)
                    {

                        // Instancionamos la lista para empezar a setearla
                        oAREA = new List<BE_AREA>();
                        while (dr.Read())
                        {
                            // Obetemos los valores para la tupla
                            dr.GetValues(Valores);
                            BE_AREA oBE_AREA = new BE_AREA();

                            oBE_AREA.ID = (Guid)Valores.GetValue(AREA_ID);
                            oBE_AREA.GERENCIA_ID = (Guid)Valores.GetValue(GERENCIA_ID);
                            oBE_AREA.CODIGO = Valores.GetValue(AREA_CODIGO).ToString();
                            oBE_AREA.DESCRIPCION = Valores.GetValue(AREA_DESCRIPCION).ToString();
                            oBE_AREA.USUARIO_CREACION = (Guid)Valores.GetValue(USUARIO_CREACION);
                            oBE_AREA.FECHA_CREACION = Convert.ToDateTime(Valores.GetValue(FECHA_CREACION));
                            oBE_AREA.USUARIO_ACTUALIZACION = (Guid) Valores.GetValue(USUARIO_ACTUALIZACION);
                            oBE_AREA.FECHA_ACTUALIZACION = Convert.ToDateTime(Valores.GetValue(FECHA_ACTUALIZACION));
                            oBE_AREA.ESTADO = Convert.ToInt32(Valores.GetValue(AREA_ESTADO));
                            oAREA.Add(oBE_AREA);
                        }
                    }

                    
                }

                return oAREA;
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
        /// Devuelve los datos de un área específica.
        /// </summary>
        /// <param name="area_id">Codigo del area al cual se desea consultar</param>
        /// <returns>BE_AREA, entidad que representa la tabla AREAS, con todas sus atributos. En caso no haiga datos devuelve nothing</returns>
        public BE_AREA SeleccionarAreaPorId(Guid area_id)
        {

            SqlConnection cnx = new SqlConnection();
            DbDataReader dr;
            cnx = DC_Connection.getConnection();
            BE_AREA oBE_AREA = null;
            try
            {
                using (SqlCommand objCmd = new SqlCommand()
                {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_AREA_SELECCIONAR_POR_ID"
                })
                {
                    objCmd.Parameters.Add("@AREA_ID", SqlDbType.UniqueIdentifier).Value = area_id;

                    cnx.Open();
                    dr = objCmd.ExecuteReader();

                    // Se crea una variable tipo int por cada posicion de cada campo
                    int AREA_ID = dr.GetOrdinal("AREA_ID");                    
                    int GERENCIA_ID = dr.GetOrdinal("GERENCIA_ID");
                    int AREA_CODIGO = dr.GetOrdinal("AREA_CODIGO");
                    int AREA_DESCRIPCION = dr.GetOrdinal("AREA_DESCRIPCION");
                    int USUARIO_CREACION = dr.GetOrdinal("USUARIO_CREACION");
                    int FECHA_CREACION = dr.GetOrdinal("FECHA_CREACION");
                    int USUARIO_ACTUALIZACION = dr.GetOrdinal("USUARIO_ACTUALIZACION");
                    int FECHA_ACTUALIZACION = dr.GetOrdinal("FECHA_ACTUALIZACION");
                    int AREA_ESTADO = dr.GetOrdinal("AREA_ESTADO");


                    // creamos un objeto del tamaño de la tupla en el array de objeto Valores
                    object[] Valores = new object[dr.FieldCount];

                    // Preguntamos si el DbDataReader tiene registros
                    if (dr.HasRows)
                    {

                        // Instancionamos la lista para empezar a setearla
                        oBE_AREA = new BE_AREA();
                        if (dr.Read())
                        {
                            // Obetemos los valores para la tupla
                            dr.GetValues(Valores);

                            oBE_AREA.ID = (Guid)Valores.GetValue(AREA_ID);
                            oBE_AREA.GERENCIA_ID = (Guid)Valores.GetValue(GERENCIA_ID);
                            oBE_AREA.CODIGO = Valores.GetValue(AREA_CODIGO).ToString();
                            oBE_AREA.DESCRIPCION = Valores.GetValue(AREA_DESCRIPCION).ToString();
                            oBE_AREA.USUARIO_CREACION = (Guid)Valores.GetValue(USUARIO_CREACION);
                            oBE_AREA.FECHA_CREACION = Convert.ToDateTime(Valores.GetValue(FECHA_CREACION));
                            oBE_AREA.USUARIO_ACTUALIZACION = (Guid)Valores.GetValue(USUARIO_ACTUALIZACION);
                            oBE_AREA.FECHA_ACTUALIZACION = Convert.ToDateTime(Valores.GetValue(FECHA_ACTUALIZACION));
                            oBE_AREA.ESTADO = Convert.ToInt32(Valores.GetValue(AREA_ESTADO));
                            
                        }
                    }


                }

                return oBE_AREA;
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
        /// Devuelve los datos de la gerencia de un área específica
        /// </summary>
        /// <param name="area_id">Codigo del area al cual se desea consultar</param>
        /// <returns>BE_AREA, entidad que representa la tabla GERENCIAS, con todas sus atributos.Ademas, esa entidad trae tambien un atributo que se llama oBE_GERENCIA, donde se obtiene todos los datos de la entidad GERENCIA En caso no haiga datos devuelve nothing</returns>
        public List<BE_AREA>  SeleccionarAreaPorGerencia(Guid gerencia_id)
        {

            SqlConnection cnx = new SqlConnection();
            DbDataReader dr;
            cnx = DC_Connection.getConnection();
            List<BE_AREA> oAREA = null;
            try
            {
                using (SqlCommand objCmd = new SqlCommand()
                {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_AREA_SELECCIONAR_POR_GERENCIA"
                })
                {

                    objCmd.Parameters.Add("@GERENCIA_ID", SqlDbType.UniqueIdentifier).Value = gerencia_id;

                    cnx.Open();
                    dr = objCmd.ExecuteReader();

                    // Se crea una variable tipo int por cada posicion de cada campo

                    
                    // Campos de l tabla AREA
                    int AREA_ID = dr.GetOrdinal("AREA_ID");
                    int AREA_CODIGO = dr.GetOrdinal("AREA_CODIGO");
                    int AREA_DESCRIPCION = dr.GetOrdinal("AREA_DESCRIPCION");
                    int USUARIO_CREACION = dr.GetOrdinal("USUARIO_CREACION");
                    int FECHA_CREACION = dr.GetOrdinal("FECHA_CREACION");
                    int USUARIO_ACTUALIZACION = dr.GetOrdinal("USUARIO_ACTUALIZACION");
                    int FECHA_ACTUALIZACION = dr.GetOrdinal("FECHA_ACTUALIZACION");
                    int AREA_ESTADO = dr.GetOrdinal("AREA_ESTADO");



                    // creamos un objeto del tamaño de la tupla en el array de objeto Valores
                    object[] Valores = new object[dr.FieldCount];

                    // Preguntamos si el DbDataReader tiene registros
                    if (dr.HasRows)
                    {

                        // Creamos la Entidad Gerencia para empezar a setearla
                        BE_GERENCIA oBE_GERENCIA = new BE_GERENCIA();

                        // instanciamos la entidad de Area para relacionar el objeto con gerencia
                        oAREA = new List<BE_AREA>();
                        while(dr.Read())
                        {
                            // Obetemos los valores para la tupla
                            dr.GetValues(Valores);


                            BE_AREA oBE_AREA = new BE_AREA();
                    
                            // Seteamos los valores del Area
                            oBE_AREA.ID = (Guid)Valores.GetValue(AREA_ID);
                            oBE_AREA.CODIGO = Valores.GetValue(AREA_CODIGO).ToString();
                            oBE_AREA.DESCRIPCION = Valores.GetValue(AREA_DESCRIPCION).ToString();
                            oBE_AREA.USUARIO_CREACION = (Guid)Valores.GetValue(USUARIO_CREACION);
                            oBE_AREA.FECHA_CREACION = Convert.ToDateTime(Valores.GetValue(FECHA_CREACION));
                            oBE_AREA.USUARIO_ACTUALIZACION = (Guid)Valores.GetValue(USUARIO_ACTUALIZACION);
                            oBE_AREA.FECHA_ACTUALIZACION = Convert.ToDateTime(Valores.GetValue(FECHA_ACTUALIZACION));
                            oBE_AREA.ESTADO = Convert.ToSByte(Valores.GetValue(AREA_ESTADO));
                            oAREA.Add(oBE_AREA);
                        }
                    }


                }

                return oAREA;
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
        /// Inserta los datos de un área
        /// </summary>
        /// <param name="oBE_AREA">Entidad BE_AREA, que representa la tabla AREA, con todos sus atributos </param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean InsertarArea(BE_AREA oBE_AREA)
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
                        CommandText = "USP_AREA_INSERTAR"
                    }
                    )
                {
                    //Se crea el objeto Parameters por cada parametro
                    objCmd.Parameters.Add("@GERENCIA_ID", SqlDbType.UniqueIdentifier ).Value = oBE_AREA.GERENCIA_ID;
                    objCmd.Parameters.Add("@AREA_CODIGO", SqlDbType.VarChar).Value = oBE_AREA.CODIGO;
                    objCmd.Parameters.Add("@AREA_DESCRIPCION", SqlDbType.VarChar).Value = oBE_AREA.DESCRIPCION ;
                    objCmd.Parameters.Add("@USUARIO", SqlDbType.UniqueIdentifier).Value = oBE_AREA.USUARIO_CREACION;
                    objCmd.Parameters.Add("@AREA_ESTADO", SqlDbType.Int ).Value = oBE_AREA.ESTADO;

                    cnx.Open();

                    bIndicador = objCmd.ExecuteNonQuery() > 0;
                }

                //AC_Transaction.Insert(1, "I", "DataAccessLayer", "DA_DOCUMENTO", "registrarSolicitudDocumento", "Registro de Solicitud Documento");

            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
                //AC_LogError.Insert(1, "I", "DataAccessLayer", "DA_DOCUMENTO", "registrarSolicitudDocumento", ex.Message);

            }
            finally
            {
                cnx.Close();
            }
            return bIndicador;
        }
        /// <summary>
        /// Actualiza los datos de una Area
        /// </summary>
        /// <param name="oBE_AREA">Entidad BE_AREA, que representa la tabla AREA, con todos sus atributos</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean ActualizarArea(BE_AREA oBE_AREA)
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
                        CommandText = "USP_AREA_ACTUALIZAR"
                    }
                    )
                {
                    //Se crea el objeto Parameters por cada parametro
                    objCmd.Parameters.Add("@AREA_ID", SqlDbType.UniqueIdentifier).Value = oBE_AREA.ID;
                    objCmd.Parameters.Add("@GERENCIA_ID", SqlDbType.UniqueIdentifier).Value = oBE_AREA.GERENCIA_ID;
                    objCmd.Parameters.Add("@AREA_CODIGO", SqlDbType.VarChar).Value = oBE_AREA.CODIGO;
                    objCmd.Parameters.Add("@AREA_DESCRIPCION", SqlDbType.VarChar).Value = oBE_AREA.DESCRIPCION;
                    objCmd.Parameters.Add("@USUARIO", SqlDbType.UniqueIdentifier).Value = oBE_AREA.USUARIO_CREACION;
                    objCmd.Parameters.Add("@AREA_ESTADO", SqlDbType.Int).Value = oBE_AREA.ESTADO;

                    cnx.Open();

                    bIndicador = objCmd.ExecuteNonQuery() > 0;
                }

                //AC_Transaction.Insert(1, "I", "DataAccessLayer", "DA_DOCUMENTO", "registrarSolicitudDocumento", "Registro de Solicitud Documento");

            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
                //AC_LogError.Insert(1, "I", "DataAccessLayer", "DA_DOCUMENTO", "registrarSolicitudDocumento", ex.Message);

            }
            finally
            {
                cnx.Close();
            }
            return bIndicador;
        }
        /// <summary>
        /// Elimina un Area es especifica
        /// </summary>
        /// <param name="area_id">Codigo del area al cual se desea Eliminar</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean EliminarArea(Guid area_id)
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
                        CommandText = "USP_AREA_ELIMINAR"
                    }
                    )
                {
                    //Se crea el objeto Parameters por cada parametro
                    objCmd.Parameters.Add("@AREA_ID", SqlDbType.UniqueIdentifier).Value = area_id;
 

                    cnx.Open();

                    bIndicador = objCmd.ExecuteNonQuery() > 0;
                }

                //AC_Transaction.Insert(1, "I", "DataAccessLayer", "DA_DOCUMENTO", "registrarSolicitudDocumento", "Registro de Solicitud Documento");

            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
                //AC_LogError.Insert(1, "I", "DataAccessLayer", "DA_DOCUMENTO", "registrarSolicitudDocumento", ex.Message);

            }
            finally
            {
                cnx.Close();
            }
            return bIndicador;
        }
    }
}
