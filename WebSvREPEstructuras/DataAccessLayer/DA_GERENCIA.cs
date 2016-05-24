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
    /// En esta clase se encuentran todos los metodos para las consultas de la tabla GERENCIAS
    /// </summary>
    public class DA_GERENCIA
    {
        /// <summary>
        ///  Devuelve los datos de todas las GERENCIAS.
        /// </summary>
        /// <returns> List de BE_GERENCIA con los objetos de la entidad, que a su vez representan la tabla GERENCIAS de la base de datos.En caso no haiga datos devuelve nothing </returns>
        public List<BE_GERENCIA> SeleccionarGerencia()
        {

            SqlConnection cnx = new SqlConnection();
            DbDataReader dr;
            cnx = DC_Connection.getConnection();
            List<BE_GERENCIA> oGERENCIA = null;
            try
            {
                using (SqlCommand objCmd = new SqlCommand()
                {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_GERENCIA_SELECCIONAR"
                })
                {
                    cnx.Open();
                    dr = objCmd.ExecuteReader();

                    // Se crea una variable tipo int por cada posicion de cada campo
                    int GERENCIA_ID = dr.GetOrdinal("GERENCIA_ID");
                    int GERENCIA_CODIGO = dr.GetOrdinal("GERENCIA_CODIGO");
                    int GERENCIA_DESCRIPCION = dr.GetOrdinal("GERENCIA_DESCRIPCION");
                    int USUARIO_CREACION = dr.GetOrdinal("USUARIO_CREACION");
                    int FECHA_CREACION = dr.GetOrdinal("FECHA_CREACION");
                    int USUARIO_ACTUALIZACION = dr.GetOrdinal("USUARIO_ACTUALIZACION");
                    int FECHA_ACTUALIZACION = dr.GetOrdinal("FECHA_ACTUALIZACION");
                    int GERENCIA_ESTADO = dr.GetOrdinal("GERENCIA_ESTADO");
                    int EMPRESA_ID = dr.GetOrdinal("EMPRESA_ID");


                    // creamos un objeto del tamaño de la tupla en el array de objeto Valores
                    object[] Valores = new object[dr.FieldCount];

                    // Preguntamos si el DbDatGERENCIAder tiene registros
                    if (dr.HasRows)
                    {

                        // Instancionamos la lista para empezar a setearla
                        oGERENCIA = new List<BE_GERENCIA>();
                        while (dr.Read())
                        {
                            // Obetemos los valores para la tupla
                            dr.GetValues(Valores);
                            BE_GERENCIA oBE_GERENCIA = new BE_GERENCIA();
                            oBE_GERENCIA.ID = (Guid)Valores.GetValue(GERENCIA_ID);
                            oBE_GERENCIA.CODIGO = Valores.GetValue(GERENCIA_CODIGO).ToString();
                            oBE_GERENCIA.DESCRIPCION = Valores.GetValue(GERENCIA_DESCRIPCION).ToString();
                            oBE_GERENCIA.USUARIO_CREACION = (Guid)Valores.GetValue(USUARIO_CREACION);
                            oBE_GERENCIA.FECHA_CREACION = Convert.ToDateTime(Valores.GetValue(FECHA_CREACION));
                            oBE_GERENCIA.USUARIO_ACTUALIZACION = (Guid)Valores.GetValue(USUARIO_ACTUALIZACION);
                            oBE_GERENCIA.FECHA_ACTUALIZACION = Convert.ToDateTime(Valores.GetValue(FECHA_ACTUALIZACION));
                            oBE_GERENCIA.ESTADO = Convert.ToInt32(Valores.GetValue(GERENCIA_ESTADO));
                            oBE_GERENCIA.EMPRESA_ID = (Guid)Valores.GetValue(EMPRESA_ID);
                            oGERENCIA.Add(oBE_GERENCIA);
                        }
                    }


                }

                return oGERENCIA;
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
        /// Devuelve los datos de una gerencia específica
        /// </summary>
        /// <param name="gerencia_id">Codigo del la Gerencia al cual se desea consultar</param>
        /// <returns> BE_GERENCIA con todos sus atributos de la entidad, que a su vez representan la tabla GERENCIAS de la base de datos.En caso no haiga datos devuelve nothing </returns>
        public List<BE_GERENCIA> SeleccionarGerenciaPorId(Guid gerencia_id)
        {

            SqlConnection cnx = new SqlConnection();
            DbDataReader dr;
            cnx = DC_Connection.getConnection();
            List<BE_GERENCIA> oGERENCIA = null;
            try
            {
                using (SqlCommand objCmd = new SqlCommand()
                {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_GERENCIA_SELECCIONAR_POR_ID"


                })
                {

                    objCmd.Parameters.Add("@GERENCIA_ID", SqlDbType.UniqueIdentifier).Value = gerencia_id;


                    cnx.Open();
                    dr = objCmd.ExecuteReader();

                    // Se crea una variable tipo int por cada posicion de cada campo
                    int GERENCIA_ID = dr.GetOrdinal("GERENCIA_ID");
                    int GERENCIA_CODIGO = dr.GetOrdinal("GERENCIA_CODIGO");
                    int GERENCIA_DESCRIPCION = dr.GetOrdinal("GERENCIA_DESCRIPCION");
                    int USUARIO_CREACION = dr.GetOrdinal("USUARIO_CREACION");
                    int FECHA_CREACION = dr.GetOrdinal("FECHA_CREACION");
                    int USUARIO_ACTUALIZACION = dr.GetOrdinal("USUARIO_ACTUALIZACION");
                    int FECHA_ACTUALIZACION = dr.GetOrdinal("FECHA_ACTUALIZACION");
                    int GERENCIA_ESTADO = dr.GetOrdinal("GERENCIA_ESTADO");
                    int EMPRESA_ID = dr.GetOrdinal("EMPRESA_ID");


                    // creamos un objeto del tamaño de la tupla en el array de objeto Valores
                    object[] Valores = new object[dr.FieldCount];

                    // Preguntamos si el DbDatGERENCIAder tiene registros
                    if (dr.HasRows)
                    {

                        // Instancionamos la lista para empezar a setearla
                        oGERENCIA = new List<BE_GERENCIA>();
                        while (dr.Read())
                        {
                            // Obetemos los valores para la tupla
                            dr.GetValues(Valores);
                            BE_GERENCIA oBE_GERENCIA = new BE_GERENCIA();
                            oBE_GERENCIA.ID = (Guid)Valores.GetValue(GERENCIA_ID);
                            oBE_GERENCIA.CODIGO = Valores.GetValue(GERENCIA_CODIGO).ToString();
                            oBE_GERENCIA.DESCRIPCION = Valores.GetValue(GERENCIA_DESCRIPCION).ToString();
                            oBE_GERENCIA.USUARIO_CREACION = (Guid)Valores.GetValue(USUARIO_CREACION);
                            oBE_GERENCIA.FECHA_CREACION = Convert.ToDateTime(Valores.GetValue(FECHA_CREACION));
                            oBE_GERENCIA.USUARIO_ACTUALIZACION = (Guid)Valores.GetValue(USUARIO_ACTUALIZACION);
                            oBE_GERENCIA.FECHA_ACTUALIZACION = Convert.ToDateTime(Valores.GetValue(FECHA_ACTUALIZACION));
                            oBE_GERENCIA.ESTADO = Convert.ToInt32(Valores.GetValue(GERENCIA_ESTADO));
                            oBE_GERENCIA.EMPRESA_ID = (Guid)Valores.GetValue(EMPRESA_ID);
                            oGERENCIA.Add(oBE_GERENCIA);
                        }
                    }


                }

                return oGERENCIA;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { cnx.Close(); }


        }

        /// <summary>
        /// Devuelve los datos de una gerencia específica
        /// </summary>
        /// <param name="empresa_id">Codigo de la empresa en la cual se desea consultar sus gerencias</param>
        /// <returns> BE_GERENCIA con todos sus atributos de la entidad, que a su vez representan la tabla GERENCIAS de la base de datos.En caso no haiga datos devuelve nothing </returns>
        public List<BE_GERENCIA> SeleccionarGerenciaPorEmpresa(Guid empresa_id)
        {

            SqlConnection cnx = new SqlConnection();
            DbDataReader dr;
            cnx = DC_Connection.getConnection();
            List<BE_GERENCIA> oGERENCIA = null;
            try
            {
                using (SqlCommand objCmd = new SqlCommand()
                {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_GERENCIA_SELECCIONAR_POR_EMPRESA"


                })
                {

                    objCmd.Parameters.Add("@EMPRESA_ID", SqlDbType.UniqueIdentifier).Value = empresa_id;


                    cnx.Open();
                    dr = objCmd.ExecuteReader();

                    // Se crea una variable tipo int por cada posicion de cada campo
                    int GERENCIA_ID = dr.GetOrdinal("GERENCIA_ID");
                    int GERENCIA_CODIGO = dr.GetOrdinal("GERENCIA_CODIGO");
                    int GERENCIA_DESCRIPCION = dr.GetOrdinal("GERENCIA_DESCRIPCION");
                    int USUARIO_CREACION = dr.GetOrdinal("USUARIO_CREACION");
                    int FECHA_CREACION = dr.GetOrdinal("FECHA_CREACION");
                    int USUARIO_ACTUALIZACION = dr.GetOrdinal("USUARIO_ACTUALIZACION");
                    int FECHA_ACTUALIZACION = dr.GetOrdinal("FECHA_ACTUALIZACION");
                    int GERENCIA_ESTADO = dr.GetOrdinal("GERENCIA_ESTADO");



                    // creamos un objeto del tamaño de la tupla en el array de objeto Valores
                    object[] Valores = new object[dr.FieldCount];

                    // Preguntamos si el DbDatGERENCIAder tiene registros
                    if (dr.HasRows)
                    {

                        // Instancionamos la lista para empezar a setearla
                        oGERENCIA = new List<BE_GERENCIA>();
                        while (dr.Read())
                        {
                            // Obetemos los valores para la tupla
                            dr.GetValues(Valores);
                            BE_GERENCIA oBE_GERENCIA = new BE_GERENCIA();
                            oBE_GERENCIA.ID = (Guid)Valores.GetValue(GERENCIA_ID);
                            oBE_GERENCIA.CODIGO = Valores.GetValue(GERENCIA_CODIGO).ToString();
                            oBE_GERENCIA.DESCRIPCION = Valores.GetValue(GERENCIA_DESCRIPCION).ToString();
                            oBE_GERENCIA.USUARIO_CREACION = (Guid)Valores.GetValue(USUARIO_CREACION);
                            oBE_GERENCIA.FECHA_CREACION = Convert.ToDateTime(Valores.GetValue(FECHA_CREACION));
                            oBE_GERENCIA.USUARIO_ACTUALIZACION = (Guid)Valores.GetValue(USUARIO_ACTUALIZACION);
                            oBE_GERENCIA.FECHA_ACTUALIZACION = Convert.ToDateTime(Valores.GetValue(FECHA_ACTUALIZACION));
                            oBE_GERENCIA.ESTADO = Convert.ToInt32(Valores.GetValue(GERENCIA_ESTADO));
                            oGERENCIA.Add(oBE_GERENCIA);
                        }
                    }


                }

                return oGERENCIA;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { cnx.Close(); }


        }        

        /// <summary>
        /// Inserta los datos de una Gerencia
        /// </summary>
        /// <param name="oBE_GERENCIA">Entidad BE_GERENCIA, que representa la tabla GERENCIA, con todos sus atributos </param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean InsertarGerencia(BE_GERENCIA oBE_GERENCIA)
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
                        CommandText = "USP_GERENCIA_INSERTAR"
                    }
                    )
                {
                    //Se crea el objeto Parameters por cada parametro
                    objCmd.Parameters.Add("@GERENCIA_CODIGO ", SqlDbType.VarChar).Value = oBE_GERENCIA.CODIGO;
                    objCmd.Parameters.Add("@GERENCIA_DESCRIPCION ", SqlDbType.VarChar).Value = oBE_GERENCIA.DESCRIPCION;
                    objCmd.Parameters.Add("@USUARIO", SqlDbType.UniqueIdentifier).Value = oBE_GERENCIA.USUARIO_CREACION;
                    objCmd.Parameters.Add("@GERENCIA_ESTADO", SqlDbType.Int).Value = oBE_GERENCIA.ESTADO;
                    objCmd.Parameters.Add("@EMPRESA_ID", SqlDbType.UniqueIdentifier).Value = oBE_GERENCIA.EMPRESA_ID;

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
        /// Actualiza los datos de una Gerencia
        /// </summary>
        /// <param name="oBE_GERENCIA">Entidad BE_GERENCIA, que representa la tabla GERENCIA, con todos sus atributos </param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean ActualizarGerencia(BE_GERENCIA oBE_GERENCIA)
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
                        CommandText = "USP_GERENCIA_ACTUALIZAR"
                    }
                    )
                {
                    //Se crea el objeto Parameters por cada parametro

                    objCmd.Parameters.Add("@GERENCIA_ID", SqlDbType.UniqueIdentifier).Value = oBE_GERENCIA.ID;
                    objCmd.Parameters.Add("@GERENCIA_CODIGO", SqlDbType.VarChar).Value = oBE_GERENCIA.CODIGO;
                    objCmd.Parameters.Add("@GERENCIA_DESCRIPCION", SqlDbType.VarChar).Value = oBE_GERENCIA.DESCRIPCION;
                    objCmd.Parameters.Add("@USUARIO", SqlDbType.UniqueIdentifier).Value = oBE_GERENCIA.USUARIO_CREACION;
                    objCmd.Parameters.Add("@GERENCIA_ESTADO", SqlDbType.Int).Value = oBE_GERENCIA.ESTADO;
                    objCmd.Parameters.Add("@EMPRESA_ID", SqlDbType.UniqueIdentifier).Value = oBE_GERENCIA.EMPRESA_ID;

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
        /// Elimina los dato de una gerencia
        /// </summary>
        /// <param name="gerencia_id">Codigo del la Gerencia al cual se desea eliminar</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean EliminarGerencia(Guid gerencia_id)
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
                        CommandText = "USP_GERENCIA_ELIMINAR"
                    }
                    )
                {
                    //Se crea el objeto Parameters por cada parametro

                    objCmd.Parameters.Add("@GERENCIA_ID", SqlDbType.UniqueIdentifier).Value = gerencia_id;


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
