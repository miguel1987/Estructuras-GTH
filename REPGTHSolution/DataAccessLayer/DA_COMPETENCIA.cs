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
    /// En esta clase se encuentran todos los metodos para las consultas de la tabla COMPETENCIAS
    /// </summary>
    public class DA_COMPETENCIA
    {
        /// <summary>
        ///  Devuelve los datos de todas las Competencias Transversales
        /// </summary>
        /// <returns> List de BE_COMPETENCIA_TRANSVERSAL con los objetos de la entidad, que a su vez representan la tabla COMPETENCIAS TRANSVERSALES de la base de datos.En caso no existan datos devuelve nothing </returns>
        public List<BE_COMPETENCIA> SeleccionarCompetencias()
        {

            SqlConnection cnx = new SqlConnection();
            DbDataReader dr;
            cnx = DC_Connection.getConnection();
            List<BE_COMPETENCIA> oCOMPETENCIA = null;
            try
            {
                using (SqlCommand objCmd = new SqlCommand()
                {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_COMPETENCIA_SELECCIONAR"
                })
                {
                    cnx.Open();
                    dr = objCmd.ExecuteReader();

                    // Se crea una variable tipo int por cada posicion de cada campo
                    int COMPETENCIA_ID = dr.GetOrdinal("COMPETENCIA_ID");
                    int COMPETENCIA_CODIGO = dr.GetOrdinal("COMPETENCIA_CODIGO");
                    int COMPETENCIA_DESCRIPCION = dr.GetOrdinal("COMPETENCIA_DESCRIPCION");
                    int COMPETENCIA_TIPO_ID = dr.GetOrdinal("COMPETENCIA_TIPO_ID");
                    int COMPETENCIA_ESTADO = dr.GetOrdinal("COMPETENCIA_ESTADO");
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
                        oCOMPETENCIA = new List<BE_COMPETENCIA>();
                        while (dr.Read())
                        {
                            // Obetemos los valores para la tupla
                            dr.GetValues(Valores);
                            BE_COMPETENCIA oBE_COMPETENCIA = new BE_COMPETENCIA();
                            oBE_COMPETENCIA.ID = (Guid)Valores.GetValue(COMPETENCIA_ID);
                            oBE_COMPETENCIA.CODIGO = Valores.GetValue(COMPETENCIA_CODIGO).ToString();
                            oBE_COMPETENCIA.DESCRIPCION = Valores.GetValue(COMPETENCIA_DESCRIPCION).ToString();
                            oBE_COMPETENCIA.COMPETENCIA_TIPO_ID = (Guid)Valores.GetValue(COMPETENCIA_TIPO_ID);
                            oBE_COMPETENCIA.ESTADO = Convert.ToInt32(Valores.GetValue(COMPETENCIA_ESTADO));
                            oBE_COMPETENCIA.USUARIO_CREACION = (Guid)Valores.GetValue(USUARIO_CREACION);
                            oBE_COMPETENCIA.FECHA_CREACION = Convert.ToDateTime(Valores.GetValue(FECHA_CREACION));
                            oBE_COMPETENCIA.USUARIO_ACTUALIZACION = (Guid)Valores.GetValue(USUARIO_ACTUALIZACION);
                            oBE_COMPETENCIA.FECHA_ACTUALIZACION = Convert.ToDateTime(Valores.GetValue(FECHA_ACTUALIZACION));

                            BE_COMPETENCIAS_TIPOS oBE_COMPETENCIA_TIPO = new BE_COMPETENCIAS_TIPOS();
                            DA_COMPETENCIAS_TIPOS DA_COMPETENCIAS_TIPOS = new DA_COMPETENCIAS_TIPOS();

                            oBE_COMPETENCIA_TIPO = DA_COMPETENCIAS_TIPOS.SeleccionarCompetenciasTiposPorId(oBE_COMPETENCIA.COMPETENCIA_TIPO_ID)[0];

                            oBE_COMPETENCIA.oBE_COMPETENCIA_TIPO = oBE_COMPETENCIA_TIPO;

                            oCOMPETENCIA.Add(oBE_COMPETENCIA);

                        }
                    }


                }

                return oCOMPETENCIA;
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
        /// <param name="oBE_COMPETENCIA">Objeto BE_COMPETENCIA con todos sus campos llenos</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean InsertarCompetencia(BE_COMPETENCIA oBE_COMPETENCIA)
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
                        CommandText = "USP_COMPETENCIA_INSERTAR"
                    }
                    )
                {
                    //Se crea el objeto Parameters por cada parametro

                    objCmd.Parameters.Add("@COMPETENCIA_CODIGO", SqlDbType.VarChar).Value = oBE_COMPETENCIA.CODIGO;
                    objCmd.Parameters.Add("@COMPETENCIA_DESCRIPCION", SqlDbType.VarChar).Value = oBE_COMPETENCIA.DESCRIPCION;
                    objCmd.Parameters.Add("@COMPETENCIA_TIPO_ID", SqlDbType.UniqueIdentifier).Value = oBE_COMPETENCIA.COMPETENCIA_TIPO_ID;
                    objCmd.Parameters.Add("@COMPETENCIA_ESTADO", SqlDbType.Int).Value = oBE_COMPETENCIA.ESTADO;
                    objCmd.Parameters.Add("@USUARIO", SqlDbType.UniqueIdentifier).Value = oBE_COMPETENCIA.USUARIO_CREACION;

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
        /// <param name="oBE_COMPETENCIA">Objeto BE_COMPETENCIA con todos sus campos llenos</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean ActualizarCompetencia(BE_COMPETENCIA oBE_COMPETENCIA)
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
                        CommandText = "USP_COMPETENCIA_ACTUALIZAR"
                    }
                    )
                {
                    //Se crea el objeto Parameters por cada parametro
                    objCmd.Parameters.Add("@COMPETENCIA_ID", SqlDbType.UniqueIdentifier).Value = oBE_COMPETENCIA.ID;
                    objCmd.Parameters.Add("@COMPETENCIA_CODIGO", SqlDbType.VarChar).Value = oBE_COMPETENCIA.CODIGO;
                    objCmd.Parameters.Add("@COMPETENCIA_DESCRIPCION", SqlDbType.VarChar).Value = oBE_COMPETENCIA.DESCRIPCION;
                    objCmd.Parameters.Add("@COMPETENCIA_TIPO_ID", SqlDbType.UniqueIdentifier).Value = oBE_COMPETENCIA.COMPETENCIA_TIPO_ID;
                    objCmd.Parameters.Add("@COMPETENCIA_ESTADO", SqlDbType.Int).Value = oBE_COMPETENCIA.ESTADO;
                    objCmd.Parameters.Add("@USUARIO", SqlDbType.UniqueIdentifier).Value = oBE_COMPETENCIA.USUARIO_CREACION;

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
        public Boolean EliminarCompetencia(Guid competencia_id)
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
                        CommandText = "USP_COMPETENCIA_ELIMINAR"
                    }
                    )
                {
                    objCmd.Parameters.Add("@COMPETENCIA_ID", SqlDbType.UniqueIdentifier).Value = competencia_id;


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
