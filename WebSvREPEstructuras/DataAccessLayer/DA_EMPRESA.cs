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
    /// En esta clase se encuentran todos los metodos para las consultas de la tabla EMPRESAS
    /// </summary>
    public class DA_EMPRESA
    {
        /// <summary>
        ///  Devuelve los datos de todas las EMPRESAS.
        /// </summary>
        /// <returns> List de BE_EMPRESA con los objetos de la entidad, que a su vez representan la tabla EMPRESAS de la base de datos.En caso existan datos devuelve nothing </returns>
        public List<BE_EMPRESA> SeleccionarEmpresa()
        {

            SqlConnection cnx = new SqlConnection();
            DbDataReader dr;
            cnx = DC_Connection.getConnection();
            List<BE_EMPRESA> oEMPRESA = null;
            try
            {
                using (SqlCommand objCmd = new SqlCommand()
                {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_EMPRESA_SELECCIONAR"
                })
                {
                    cnx.Open();
                    dr = objCmd.ExecuteReader();

                    // Se crea una variable tipo int por cada posicion de cada campo
                    int EMPRESA_ID = dr.GetOrdinal("EMPRESA_ID");
                    int EMPRESA_CODIGO = dr.GetOrdinal("EMPRESA_CODIGO");
                    int EMPRESA_DESCRIPCION = dr.GetOrdinal("EMPRESA_DESCRIPCION");
                    int USUARIO_CREACION = dr.GetOrdinal("USUARIO_CREACION");
                    int FECHA_CREACION = dr.GetOrdinal("FECHA_CREACION");
                    int USUARIO_ACTUALIZACION = dr.GetOrdinal("USUARIO_ACTUALIZACION");
                    int FECHA_ACTUALIZACION = dr.GetOrdinal("FECHA_ACTUALIZACION");
                    int EMPRESA_ESTADO = dr.GetOrdinal("EMPRESA_ESTADO");


                    // creamos un objeto del tamaño de la tupla en el array de objeto Valores
                    object[] Valores = new object[dr.FieldCount];

                    // Preguntamos si el DbDatGERENCIAder tiene registros
                    if (dr.HasRows)
                    {

                        // Instancionamos la lista para empezar a setearla
                        oEMPRESA = new List<BE_EMPRESA>();
                        while (dr.Read())
                        {
                            // Obetemos los valores para la tupla
                            dr.GetValues(Valores);
                            BE_EMPRESA oBE_EMPRESA = new BE_EMPRESA();
                            oBE_EMPRESA.ID = (Guid)Valores.GetValue(EMPRESA_ID);
                            oBE_EMPRESA.CODIGO = Valores.GetValue(EMPRESA_CODIGO).ToString();
                            oBE_EMPRESA.DESCRIPCION = Valores.GetValue(EMPRESA_DESCRIPCION).ToString();
                            oBE_EMPRESA.USUARIO_CREACION = (Guid)Valores.GetValue(USUARIO_CREACION);
                            oBE_EMPRESA.FECHA_CREACION = Convert.ToDateTime(Valores.GetValue(FECHA_CREACION));
                            oBE_EMPRESA.USUARIO_ACTUALIZACION = (Guid)Valores.GetValue(USUARIO_ACTUALIZACION);
                            oBE_EMPRESA.FECHA_ACTUALIZACION = Convert.ToDateTime(Valores.GetValue(FECHA_ACTUALIZACION));
                            oBE_EMPRESA.ESTADO = Convert.ToInt32(Valores.GetValue(EMPRESA_ESTADO));
                            oEMPRESA.Add(oBE_EMPRESA);
                        }
                    }


                }

                return oEMPRESA;
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
        /// Devuelve los datos de una empresa específica
        /// </summary>
        /// <param name="gerencia_id">Codigo del la Gerencia al cual se desea consultar</param>
        /// <returns> BE_EMPRESA con todos sus atributos de la entidad, que a su vez representan la tabla EMPRESAS de la base de datos.En caso no haiga datos devuelve nothing </returns>
        public List<BE_EMPRESA> SeleccionarEmpresaPorId(Guid empresa_id)
        {

            SqlConnection cnx = new SqlConnection();
            DbDataReader dr;
            cnx = DC_Connection.getConnection();
            List<BE_EMPRESA> oEMPRESA = null;
            try
            {
                using (SqlCommand objCmd = new SqlCommand()
                {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_EMPRESA_SELECCIONAR_POR_ID"


                })
                {

                    objCmd.Parameters.Add("@EMPRESA_ID", SqlDbType.UniqueIdentifier).Value = empresa_id;


                    cnx.Open();
                    dr = objCmd.ExecuteReader();

                    // Se crea una variable tipo int por cada posicion de cada campo
                    int EMPRESA_ID = dr.GetOrdinal("EMPRESA_ID");
                    int EMPRESA_CODIGO = dr.GetOrdinal("EMPRESA_CODIGO");
                    int EMPRESA_DESCRIPCION = dr.GetOrdinal("EMPRESA_DESCRIPCION");
                    int USUARIO_CREACION = dr.GetOrdinal("USUARIO_CREACION");
                    int FECHA_CREACION = dr.GetOrdinal("FECHA_CREACION");
                    int USUARIO_ACTUALIZACION = dr.GetOrdinal("USUARIO_ACTUALIZACION");
                    int FECHA_ACTUALIZACION = dr.GetOrdinal("FECHA_ACTUALIZACION");
                    int EMPRESA_ESTADO = dr.GetOrdinal("EMPRESA_ESTADO");


                    // creamos un objeto del tamaño de la tupla en el array de objeto Valores
                    object[] Valores = new object[dr.FieldCount];

                    // Preguntamos si el DbDatGERENCIAder tiene registros
                    if (dr.HasRows)
                    {

                        // Instancionamos la lista para empezar a setearla
                        oEMPRESA = new List<BE_EMPRESA>();
                        while (dr.Read())
                        {
                            // Obetemos los valores para la tupla
                            dr.GetValues(Valores);
                            BE_EMPRESA oBE_EMPRESA = new BE_EMPRESA();
                            oBE_EMPRESA.ID = (Guid)Valores.GetValue(EMPRESA_ID);
                            oBE_EMPRESA.CODIGO = Valores.GetValue(EMPRESA_CODIGO).ToString();
                            oBE_EMPRESA.DESCRIPCION = Valores.GetValue(EMPRESA_DESCRIPCION).ToString();
                            oBE_EMPRESA.USUARIO_CREACION = (Guid)Valores.GetValue(USUARIO_CREACION);
                            oBE_EMPRESA.FECHA_CREACION = Convert.ToDateTime(Valores.GetValue(FECHA_CREACION));
                            oBE_EMPRESA.USUARIO_ACTUALIZACION = (Guid)Valores.GetValue(USUARIO_ACTUALIZACION);
                            oBE_EMPRESA.FECHA_ACTUALIZACION = Convert.ToDateTime(Valores.GetValue(FECHA_ACTUALIZACION));
                            oBE_EMPRESA.ESTADO = Convert.ToInt32(Valores.GetValue(EMPRESA_ESTADO));

                            oEMPRESA.Add(oBE_EMPRESA);
                        }
                    }


                }

                return oEMPRESA;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { cnx.Close(); }


        }
        /// <summary>
        /// Inserta los datos de una Empresa
        /// </summary>
        /// <param name="oBE_GERENCIA">Entidad BE_EMPRESA, que representa la tabla EMPRESAS, con todos sus atributos </param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean InsertarEmpresa(BE_EMPRESA oBE_EMPRESA)
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
                        CommandText = "USP_EMPRESA_INSERTAR"
                    }
                    )
                {
                    //Se crea el objeto Parameters por cada parametro
                    objCmd.Parameters.Add("@EMPRESA_CODIGO", SqlDbType.VarChar).Value = oBE_EMPRESA.CODIGO;
                    objCmd.Parameters.Add("@EMPRESA_DESCRIPCION", SqlDbType.VarChar).Value = oBE_EMPRESA.DESCRIPCION;
                    objCmd.Parameters.Add("@USUARIO", SqlDbType.UniqueIdentifier).Value = oBE_EMPRESA.USUARIO_CREACION;
                    objCmd.Parameters.Add("@EMPRESA_ESTADO", SqlDbType.Int).Value = oBE_EMPRESA.ESTADO;

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
        /// Actualiza los datos de una Empresa
        /// </summary>
        /// <param name="oBE_GERENCIA">Entidad BE_EMPRESA, que representa la tabla EMPRESAS, con todos sus atributos </param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean ActualizarEmpresa(BE_EMPRESA oBE_EMPRESA)
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
                        CommandText = "USP_EMPRESA_ACTUALIZAR"
                    }
                    )
                {
                    //Se crea el objeto Parameters por cada parametro

                    objCmd.Parameters.Add("@EMPRESA_ID", SqlDbType.UniqueIdentifier).Value = oBE_EMPRESA.ID;
                    objCmd.Parameters.Add("@EMPRESA_CODIGO", SqlDbType.VarChar).Value = oBE_EMPRESA.CODIGO;
                    objCmd.Parameters.Add("@EMPRESA_DESCRIPCION", SqlDbType.VarChar).Value = oBE_EMPRESA.DESCRIPCION;
                    objCmd.Parameters.Add("@USUARIO", SqlDbType.UniqueIdentifier).Value = oBE_EMPRESA.USUARIO_CREACION;
                    objCmd.Parameters.Add("@EMPRESA_ESTADO", SqlDbType.Int).Value = oBE_EMPRESA.ESTADO;

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
        /// Elimina los dato de una empresa
        /// </summary>
        /// <param name="gerencia_id">Codigo del la Empresa al cual se desea eliminar</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean EliminarEmpresa(Guid empresa_id)
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
                        CommandText = "USP_EMPRESA_ELIMINAR"
                    }
                    )
                {
                    //Se crea el objeto Parameters por cada parametro

                    objCmd.Parameters.Add("@EMPRESA_ID", SqlDbType.UniqueIdentifier).Value = empresa_id;


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
