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
    /// En esta clase se encuentran todos los metodos para las consultas de la tabla CUENTAS MAYORES
    /// </summary>
    public class DA_CUENTA_MAYOR
    {
        /// <summary>
        ///  Devuelve los datos de todos los Cuentas Mayores
        /// </summary>
        /// <returns> List de BE_CUENTA_MAYOR con los objetos de la entidad, que a su vez representan la tabla CUENTAS MAYORES de la base de datos.En caso no existan datos devuelve nothing </returns>
        public List<BE_CUENTA_MAYOR> SeleccionarCuentasMayores()
        {

            SqlConnection cnx = new SqlConnection();
            DbDataReader dr;
            cnx = DC_Connection.getConnection();
            List<BE_CUENTA_MAYOR> oCUENTA_MAYOR = null;
            try
            {
                using (SqlCommand objCmd = new SqlCommand()
                {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_CUENTA_MAYOR_SELECCIONAR"
                })
                {
                    cnx.Open();
                    dr = objCmd.ExecuteReader();

                    // Se crea una variable tipo int por cada posicion de cada campo
                    int CUENTA_MAYOR_ID = dr.GetOrdinal("CUENTA_MAYOR_ID");
                    int CUENTA_MAYOR_CODIGO = dr.GetOrdinal("CUENTA_MAYOR_CODIGO");
                    int CUENTA_MAYOR_DESCRIPCION = dr.GetOrdinal("CUENTA_MAYOR_DESCRIPCION");                    
                    int USUARIO_CREACION = dr.GetOrdinal("USUARIO_CREACION");
                    int FECHA_CREACION = dr.GetOrdinal("FECHA_CREACION");
                    int USUARIO_ACTUALIZACION = dr.GetOrdinal("USUARIO_ACTUALIZACION");
                    int FECHA_ACTUALIZACION = dr.GetOrdinal("FECHA_ACTUALIZACION");
                    int CUENTA_MAYOR_ESTADO = dr.GetOrdinal("CUENTA_MAYOR_ESTADO");


                    // creamos un objeto del tamaño de la tupla en el array de objeto Valores
                    object[] Valores = new object[dr.FieldCount];

                    // Preguntamos si el DbDatGERENCIAder tiene registros
                    if (dr.HasRows)
                    {

                        // Instancionamos la lista para empezar a setearla
                        oCUENTA_MAYOR = new List<BE_CUENTA_MAYOR>();
                        while (dr.Read())
                        {
                            // Obetemos los valores para la tupla
                            dr.GetValues(Valores);
                            BE_CUENTA_MAYOR oBE_CUENTA_MAYOR = new BE_CUENTA_MAYOR();
                            oBE_CUENTA_MAYOR.ID = (Guid)Valores.GetValue(CUENTA_MAYOR_ID);
                            oBE_CUENTA_MAYOR.CODIGO = Valores.GetValue(CUENTA_MAYOR_CODIGO).ToString();
                            oBE_CUENTA_MAYOR.DESCRIPCION = Valores.GetValue(CUENTA_MAYOR_DESCRIPCION).ToString();
                            oBE_CUENTA_MAYOR.CODIGO_DESCRIPCION = String.Format("{0} - {1}", oBE_CUENTA_MAYOR.CODIGO, oBE_CUENTA_MAYOR.DESCRIPCION);
                            oBE_CUENTA_MAYOR.USUARIO_CREACION = (Guid)Valores.GetValue(USUARIO_CREACION);
                            oBE_CUENTA_MAYOR.FECHA_CREACION = Convert.ToDateTime(Valores.GetValue(FECHA_CREACION));
                            oBE_CUENTA_MAYOR.USUARIO_ACTUALIZACION = (Guid)Valores.GetValue(USUARIO_ACTUALIZACION);
                            oBE_CUENTA_MAYOR.FECHA_ACTUALIZACION = Convert.ToDateTime(Valores.GetValue(FECHA_ACTUALIZACION));
                            oBE_CUENTA_MAYOR.ESTADO = Convert.ToInt32(Valores.GetValue(CUENTA_MAYOR_ESTADO));
                            oCUENTA_MAYOR.Add(oBE_CUENTA_MAYOR);

                        }
                    }


                }

                return oCUENTA_MAYOR;
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
        /// Ingresa una nueva Cuenta Mayor
        /// </summary>
        /// <param name="oBE_CUENTA_MAYOR">Objeto BE_CUENTA_MAYOR con todos sus campos llenos</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean InsertarCuentaMayor(BE_CUENTA_MAYOR oBE_CUENTA_MAYOR)
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
                        CommandText = "USP_CUENTA_MAYOR_INSERTAR"
                    }
                    )
                {
                    //Se crea el objeto Parameters por cada parametro

                    objCmd.Parameters.Add("@CUENTA_MAYOR_CODIGO", SqlDbType.VarChar).Value = oBE_CUENTA_MAYOR.CODIGO;
                    objCmd.Parameters.Add("@CUENTA_MAYOR_DESCRIPCION", SqlDbType.VarChar).Value = oBE_CUENTA_MAYOR.DESCRIPCION;                    
                    objCmd.Parameters.Add("@USUARIO", SqlDbType.UniqueIdentifier).Value = oBE_CUENTA_MAYOR.USUARIO_CREACION;

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
        /// Actualizar una Cuenta Mayor
        /// </summary>
        /// <param name="oBE_CUENTA_MAYOR">Objeto BE_CUENTA_MAYOR con todos sus campos llenos</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean ActualizarCuentaMayor(BE_CUENTA_MAYOR oBE_CUENTA_MAYOR)
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
                        CommandText = "USP_CUENTA_MAYOR_ACTUALIZAR"
                    }
                    )
                {
                    //Se crea el objeto Parameters por cada parametro
                    objCmd.Parameters.Add("@CUENTA_MAYOR_ID", SqlDbType.UniqueIdentifier).Value = oBE_CUENTA_MAYOR.ID;
                    objCmd.Parameters.Add("@CUENTA_MAYOR_CODIGO", SqlDbType.VarChar).Value = oBE_CUENTA_MAYOR.CODIGO;
                    objCmd.Parameters.Add("@CUENTA_MAYOR_DESCRIPCION", SqlDbType.VarChar).Value = oBE_CUENTA_MAYOR.DESCRIPCION;
                    objCmd.Parameters.Add("@USUARIO", SqlDbType.UniqueIdentifier).Value = oBE_CUENTA_MAYOR.USUARIO_CREACION;

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
        /// Eliminar una Cuenta Mayor
        /// </summary>
        /// <param name="cuentaMayorId">Identificador de la cuenta mayor a eliminar</param>        
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean EliminarCuentaMayor(Guid cuentaMayorId)
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
                        CommandText = "USP_CUENTA_MAYOR_ELIMINAR"
                    }
                    )
                {
                    objCmd.Parameters.Add("@CUENTA_MAYOR_ID", SqlDbType.UniqueIdentifier).Value = cuentaMayorId;


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
