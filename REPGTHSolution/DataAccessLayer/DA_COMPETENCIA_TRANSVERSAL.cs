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
    /// En esta clase se encuentran todos los metodos para las consultas de la tabla COMPETENCIAS TRANSVERSALES
    /// </summary>
    public class DA_COMPETENCIA_TRANSVERSAL
    {
        /// <summary>
        ///  Devuelve los datos de todas las Competencias Transversales
        /// </summary>
        /// <returns> List de BE_COMPETENCIA_TRANSVERSAL con los objetos de la entidad, que a su vez representan la tabla COMPETENCIAS TRANSVERSALES de la base de datos.En caso no existan datos devuelve nothing </returns>
        public List<BE_COMPETENCIA_TRANSVERSAL> SeleccionarCompetenciasTranversales()
        {

            SqlConnection cnx = new SqlConnection();
            DbDataReader dr;
            cnx = DC_Connection.getConnection();
            List<BE_COMPETENCIA_TRANSVERSAL> oCOMPETENCIA_TRANSVERSAL = null;
            try
            {
                using (SqlCommand objCmd = new SqlCommand()
                {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_COMPETENCIA_TRANSVERSAL_SELECCIONAR"
                })
                {
                    cnx.Open();
                    dr = objCmd.ExecuteReader();

                    // Se crea una variable tipo int por cada posicion de cada campo
                    int COMPETENCIA_TRANSVERSAL_ID = dr.GetOrdinal("COMPETENCIA_TRANSVERSAL_ID");
                    int COMPETENCIA_TRANSVERSAL_CODIGO = dr.GetOrdinal("COMPETENCIA_TRANSVERSAL_CODIGO");
                    int COMPETENCIA_TRANSVERSAL_DESCRIPCION = dr.GetOrdinal("COMPETENCIA_TRANSVERSAL_DESCRIPCION");
                    int COMPETENCIA_TRANSVERSAL_ESTADO = dr.GetOrdinal("COMPETENCIA_TRANSVERSAL_ESTADO");
                    int USUARIO_CREACION = dr.GetOrdinal("USUARIO_CREACION");
                    int FECHA_CREACION = dr.GetOrdinal("FECHA_CREACION");
                    int USUARIO_ACTUALIZACION = dr.GetOrdinal("USUARIO_ACTUALIZACION");
                    int FECHA_ACTUALIZACION = dr.GetOrdinal("FECHA_ACTUALIZACION");       

                    // creamos un objeto del tamaño de la tupla en el array de objeto Valores
                    object[] Valores = new object[dr.FieldCount];

                    // Preguntamos si el DbDatGERENCIAder tiene registros
                    if (dr.HasRows)
                    {

                        // Instancionamos la lista para empezar a setearla
                        oCOMPETENCIA_TRANSVERSAL = new List<BE_COMPETENCIA_TRANSVERSAL>();
                        while (dr.Read())
                        {
                            // Obetemos los valores para la tupla
                            dr.GetValues(Valores);
                            BE_COMPETENCIA_TRANSVERSAL oBE_COMPETENCIA_TRANSVERSAL = new BE_COMPETENCIA_TRANSVERSAL();
                            oBE_COMPETENCIA_TRANSVERSAL.ID = (Guid)Valores.GetValue(COMPETENCIA_TRANSVERSAL_ID);
                            oBE_COMPETENCIA_TRANSVERSAL.CODIGO = Valores.GetValue(COMPETENCIA_TRANSVERSAL_CODIGO).ToString();
                            oBE_COMPETENCIA_TRANSVERSAL.DESCRIPCION = Valores.GetValue(COMPETENCIA_TRANSVERSAL_DESCRIPCION).ToString();
                            oBE_COMPETENCIA_TRANSVERSAL.ESTADO = Convert.ToInt32(Valores.GetValue(COMPETENCIA_TRANSVERSAL_ESTADO));
                            oBE_COMPETENCIA_TRANSVERSAL.USUARIO_CREACION = (Guid)Valores.GetValue(USUARIO_CREACION);
                            oBE_COMPETENCIA_TRANSVERSAL.FECHA_CREACION = Convert.ToDateTime(Valores.GetValue(FECHA_CREACION));
                            oBE_COMPETENCIA_TRANSVERSAL.USUARIO_ACTUALIZACION = (Guid)Valores.GetValue(USUARIO_ACTUALIZACION);
                            oBE_COMPETENCIA_TRANSVERSAL.FECHA_ACTUALIZACION = Convert.ToDateTime(Valores.GetValue(FECHA_ACTUALIZACION));

                            oCOMPETENCIA_TRANSVERSAL.Add(oBE_COMPETENCIA_TRANSVERSAL);

                        }
                    }
                }

                return oCOMPETENCIA_TRANSVERSAL;
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
        /// Ingresa una nueva Competencia Transversal
        /// </summary>
        /// <param name="oBE_COMPETENCIA_TRANSVERSAL">Objeto BE_COMPETENCIA_TRANSVERSAL con todos sus campos llenos</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean InsertarCompetenciaTransversal(BE_COMPETENCIA_TRANSVERSAL oBE_COMPETENCIA_TRANSVERSAL)
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
                        CommandText = "USP_COMPETENCIA_TRANSVERSAL_INSERTAR"
                    }
                    )
                {
                    //Se crea el objeto Parameters por cada parametro

                    objCmd.Parameters.Add("@COMPETENCIA_TRANSVERSAL_CODIGO", SqlDbType.VarChar).Value = oBE_COMPETENCIA_TRANSVERSAL.CODIGO;
                    objCmd.Parameters.Add("@COMPETENCIA_TRANSVERSAL_DESCRIPCION", SqlDbType.VarChar).Value = oBE_COMPETENCIA_TRANSVERSAL.DESCRIPCION;
                    objCmd.Parameters.Add("@COMPETENCIA_TRANSVERSAL_ESTADO", SqlDbType.Int).Value = oBE_COMPETENCIA_TRANSVERSAL.ESTADO;
                    objCmd.Parameters.Add("@USUARIO", SqlDbType.UniqueIdentifier).Value = oBE_COMPETENCIA_TRANSVERSAL.USUARIO_CREACION;

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
        /// Actualizar una Competencia Transversal
        /// </summary>
        /// <param name="oBE_COMPETENCIA_TRANSVERSAL">Objeto BE_COMPETENCIA_TRANSVERSAL con todos sus campos llenos</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean ActualizarCompetenciaTransversal(BE_COMPETENCIA_TRANSVERSAL oBE_COMPETENCIA_TRANSVERSAL)
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
                        CommandText = "USP_COMPETENCIA_TRANSVERSAL_ACTUALIZAR"
                    }
                    )
                {
                    //Se crea el objeto Parameters por cada parametro
                    objCmd.Parameters.Add("@COMPETENCIA_TRANSVERSAL_ID", SqlDbType.UniqueIdentifier).Value = oBE_COMPETENCIA_TRANSVERSAL.ID;
                    objCmd.Parameters.Add("@COMPETENCIA_TRANSVERSAL_CODIGO", SqlDbType.VarChar).Value = oBE_COMPETENCIA_TRANSVERSAL.CODIGO;
                    objCmd.Parameters.Add("@COMPETENCIA_TRANSVERSAL_DESCRIPCION", SqlDbType.VarChar).Value = oBE_COMPETENCIA_TRANSVERSAL.DESCRIPCION;
                    objCmd.Parameters.Add("@COMPETENCIA_TRANSVERSAL_ESTADO", SqlDbType.Int).Value = oBE_COMPETENCIA_TRANSVERSAL.ESTADO;
                    objCmd.Parameters.Add("@USUARIO", SqlDbType.UniqueIdentifier).Value = oBE_COMPETENCIA_TRANSVERSAL.USUARIO_CREACION;

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
        /// Eliminar una Competencia Transversal
        /// </summary>
        /// <param name="competencia_transversal_id">Identificador de la competencia transversal a eliminar</param>        
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean EliminarCompetenciaTransversal(Guid competencia_transversal_id)
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
                        CommandText = "USP_COMPETENCIA_TRANSVERSAL_ELIMINAR"
                    }
                    )
                {
                    objCmd.Parameters.Add("@COMPETENCIA_TRANSVERSAL_ID", SqlDbType.UniqueIdentifier).Value = competencia_transversal_id;


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
