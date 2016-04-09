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
    /// <summary>
    /// En esta clase se encuentran todos los metodos para las consultas de los documentos de las solicitudes
    /// </summary>
    public class DA_DOCUMENTO
    {
        /// <summary>
        ///  Devuelve los datos de los Documentos  que pertenecen a una solicitud.
        /// </summary>
        /// <param name="solicitudId">Guid: Id de la solicitud</param>        
        /// <returns> List de BE_DOCUMENTO con los objetos de la entidad, que a su vez representan los documentos de la base de datos.En caso no existan datos devuelve nothing </returns>
        public List<BE_DOCUMENTO> SeleccionarDocumentosPorSolicitud(Guid solicitudId)
        {

            SqlConnection cnx = new SqlConnection();
            DbDataReader dr;
            cnx = DC_Connection.getConnection();
            List<BE_DOCUMENTO> oDOCUMENTO = null;
            try
            {
                using (SqlCommand objCmd = new SqlCommand()
                {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_DOCUMENTO_SELECCIONAR_POR_SOLICITUD"
                })
                {
                    objCmd.Parameters.Add("@SOLICITUD_ID", SqlDbType.UniqueIdentifier).Value = solicitudId;

                    cnx.Open();
                    dr = objCmd.ExecuteReader();

                    // Se crea una variable tipo int por cada posicion de cada campo
                    int DOCUMENTO_ID = dr.GetOrdinal("DOCUMENTO_ID");
                    int DOCUMENTO_NOMBRE = dr.GetOrdinal("DOCUMENTO_NOMBRE");
                    int DOCUMENTO_DESCRIPCION = dr.GetOrdinal("DOCUMENTO_DESCRIPCION");
                    int DOCUMENTO_URL = dr.GetOrdinal("DOCUMENTO_URL");
                    int DOCUMENTO_FECHA = dr.GetOrdinal("DOCUMENTO_FECHA");

                    // creamos un objeto del tamaño de la tupla en el array de objeto Valores
                    object[] Valores = new object[dr.FieldCount];

                    // Preguntamos si el DbDatGERENCIAder tiene registros
                    if (dr.HasRows)
                    {

                        // Instancionamos la lista para empezar a setearla
                        oDOCUMENTO = new List<BE_DOCUMENTO>();
                        while (dr.Read())
                        {
                            // Obetemos los valores para la tupla
                            dr.GetValues(Valores);
                            BE_DOCUMENTO oBE_DOCUMENTO = new BE_DOCUMENTO();

                            oBE_DOCUMENTO.ID = (Guid)Valores.GetValue(DOCUMENTO_ID);
                            oBE_DOCUMENTO.NOMBRE = Valores.GetValue(DOCUMENTO_NOMBRE).ToString();
                            oBE_DOCUMENTO.DESCRIPCION = Valores.GetValue(DOCUMENTO_DESCRIPCION).ToString();
                            oBE_DOCUMENTO.URL = Valores.GetValue(DOCUMENTO_URL).ToString();
                            oBE_DOCUMENTO.FECHA_REGISTRO = Valores.GetValue(DOCUMENTO_FECHA).ToString();
                            oDOCUMENTO.Add(oBE_DOCUMENTO);

                        }
                    }


                }

                return oDOCUMENTO;
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
        /// Ingresa un nuevo Documento
        /// </summary>
        /// <param name="oBE_DOCUMENTO">Objeto BE_DOCUMENTO con todos sus campos llenos</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean InsertarDocumento(BE_DOCUMENTO oBE_DOCUMENTO)
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
                        CommandText = "USP_DOCUMENTO_INSERTAR"
                    }
                    )
                {
                    //Se crea el objeto Parameters por cada parametro
                                     
                    objCmd.Parameters.Add("@DOCUMENTO_NOMBRE", SqlDbType.VarChar).Value = oBE_DOCUMENTO.NOMBRE;
                    objCmd.Parameters.Add("@DOCUMENTO_DESCRIPCION", SqlDbType.VarChar).Value = oBE_DOCUMENTO.DESCRIPCION;
                    objCmd.Parameters.Add("@DOCUMENTO_URL", SqlDbType.VarChar).Value = oBE_DOCUMENTO.URL;
                    objCmd.Parameters.Add("@DOCUMENTO_FECHA", SqlDbType.Date).Value = Convert.ToDateTime(oBE_DOCUMENTO.FECHA_REGISTRO).Date;
                    objCmd.Parameters.Add("@SOLICITUD_ID", SqlDbType.UniqueIdentifier).Value = oBE_DOCUMENTO.SOLICITUD_ID;   
                    objCmd.Parameters.Add("@USUARIO", SqlDbType.UniqueIdentifier).Value = oBE_DOCUMENTO.USUARIO_CREACION;

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
        /// Actualizar un nuevo Documento
        /// </summary>
        /// <param name="oBE_DOCUMENTO">Objeto BE_DOCUMENTO con todos sus campos llenos</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean ActualizarDocumento(BE_DOCUMENTO oBE_DOCUMENTO)
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
                        CommandText = "USP_DOCUMENTO_ACTUALIZAR"
                    }
                    )
                {
                    //Se crea el objeto Parameters por cada parametro
                    objCmd.Parameters.Add("@SOLICITUD_ID", SqlDbType.UniqueIdentifier).Value = oBE_DOCUMENTO.SOLICITUD_ID;
                    objCmd.Parameters.Add("@DOCUMENTO_ID", SqlDbType.Int).Value = oBE_DOCUMENTO.ID;
                    objCmd.Parameters.Add("@DOCUMENTO_NOMBRE", SqlDbType.Int).Value = oBE_DOCUMENTO.NOMBRE;
                    objCmd.Parameters.Add("@DOCUMENTO_DESCRIPCION", SqlDbType.Int).Value = oBE_DOCUMENTO.DESCRIPCION;
                    objCmd.Parameters.Add("@DOCUMENTO_URL", SqlDbType.Int).Value = oBE_DOCUMENTO.URL;
                    objCmd.Parameters.Add("@DOCUMENTO_FECHA", SqlDbType.Int).Value = oBE_DOCUMENTO.FECHA_REGISTRO;
                    objCmd.Parameters.Add("@USUARIO", SqlDbType.UniqueIdentifier).Value = oBE_DOCUMENTO.USUARIO_CREACION;

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
        /// Eliminar un nuevo Documento
        /// </summary>
        /// <param name="documentoId">Identificador del documento a eliminar</param>        
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean EliminarDocumento(Guid documentoId)
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
                        CommandText = "USP_DOCUMENTO_ELIMINAR"
                    }
                    )
                {
                    objCmd.Parameters.Add("@DOCUMENTO_ID", SqlDbType.UniqueIdentifier).Value = documentoId;                   

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
