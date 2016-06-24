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
    /// En esta clase se encuentran todos los metodos para las consultas de la tabla PARAMETROS_SISTEMA
    /// </summary>
    public class DA_PARAMETRO
    {
        /// <summary>
        ///  Devuelve los datos de todos los parámetros del sistema
        /// </summary>
        /// <returns> List de BE_PARAMETRO con los objetos de la entidad, que a su vez representan la tabla PARAMETROS_SISTEMA e la base de datos.En caso no existan datos devuelve nothing </returns>
        public List<BE_PARAMETRO> SeleccionarParametros()
        {

            SqlConnection cnx = new SqlConnection();
            DbDataReader dr;
            cnx = DC_Connection.getConnection();
            List<BE_PARAMETRO> oPARAMETRO = null;
            try
            {
                using (SqlCommand objCmd = new SqlCommand()
                {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_PARAMETRO_SELECCIONAR"
                })
                {
                    cnx.Open();
                    dr = objCmd.ExecuteReader();

                    // Se crea una variable tipo int por cada posicion de cada campo
                    int PARAMETRO_ID = dr.GetOrdinal("PARAMETRO_ID");
                    int PARAMETRO_CODIGO = dr.GetOrdinal("CODIGO");
                    int PARAMETRO_DESCRIPCION = dr.GetOrdinal("PARAMETRO_DESCRIPCION");
                    int PARAMETRO_VALOR= dr.GetOrdinal("PARAMETRO_VALOR");    
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
                        oPARAMETRO = new List<BE_PARAMETRO>();
                        while (dr.Read())
                        {
                            // Obetemos los valores para la tupla
                            dr.GetValues(Valores);
                            BE_PARAMETRO oBE_PARAMETRO = new BE_PARAMETRO();
                            oBE_PARAMETRO.ID = (Guid)Valores.GetValue(PARAMETRO_ID);
                            oBE_PARAMETRO.CODIGO = Valores.GetValue(PARAMETRO_CODIGO).ToString();
                            oBE_PARAMETRO.DESCRIPCION = Valores.GetValue(PARAMETRO_DESCRIPCION).ToString();
                            oBE_PARAMETRO.VALOR = Valores.GetValue(PARAMETRO_VALOR).ToString();
                            oBE_PARAMETRO.USUARIO_CREACION = (Guid)Valores.GetValue(USUARIO_CREACION);
                            oBE_PARAMETRO.FECHA_CREACION = Convert.ToDateTime(Valores.GetValue(FECHA_CREACION));
                            oBE_PARAMETRO.USUARIO_ACTUALIZACION = (Guid)Valores.GetValue(USUARIO_ACTUALIZACION);
                            oBE_PARAMETRO.FECHA_ACTUALIZACION = Convert.ToDateTime(Valores.GetValue(FECHA_ACTUALIZACION));


                            oPARAMETRO.Add(oBE_PARAMETRO);

                        }
                    }


                }

                return oPARAMETRO;
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
        /// Actualizar un Parámetro del Sistema
        /// </summary>
        /// <param name="oBE_PARAMETRO">Objeto BE_PARAMETRO con todos sus campos llenos</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean ActualizarParametro(BE_PARAMETRO oBE_PARAMETRO)
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
                        CommandText = "USP_PARAMETRO_ACTUALIZAR"
                    }
                    )
                {
                    //Se crea el objeto Parameters por cada parametro
                    objCmd.Parameters.Add("@PARAMETRO_ID", SqlDbType.UniqueIdentifier).Value = oBE_PARAMETRO.ID;
                    objCmd.Parameters.Add("@PARAMETRO_CODIGO", SqlDbType.VarChar).Value = oBE_PARAMETRO.CODIGO;
                    objCmd.Parameters.Add("@PARAMETRO_DESCRIPCION", SqlDbType.VarChar).Value = oBE_PARAMETRO.DESCRIPCION;
                    objCmd.Parameters.Add("@PARAMETRO_VALOR", SqlDbType.VarChar).Value = oBE_PARAMETRO.VALOR;
                    objCmd.Parameters.Add("@USUARIO", SqlDbType.UniqueIdentifier).Value = oBE_PARAMETRO.USUARIO_CREACION;

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
        /// Eliminar un Parámetro del Sistema
        /// </summary>
        /// <param name="parametro_id">Identificador del parámetro a eliminar</param>        
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean EliminarParametro(Guid parametro_id)
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
                        CommandText = "USP_PARAMETRO_ELIMINAR"
                    }
                    )
                {
                    objCmd.Parameters.Add("@PARAMETRO_ID", SqlDbType.UniqueIdentifier).Value = parametro_id;


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
