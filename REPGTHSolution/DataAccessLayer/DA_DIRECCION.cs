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
    /// En esta clase se encuentran todos los metodos para las consultas de la tabla DIRECCIONES
    /// </summary>
    public class DA_DIRECCION
    {
        /// <summary>
        ///  Devuelve los datos de todos los Direcciones.
        /// </summary>      
        /// <returns> List de BE_DIRECCION con los objetos de la entidad, que a su vez representan la tabla DIRECCIONES de la base de datos.En caso no existan datos devuelve nothing </returns>
        public List<BE_DIRECCION> SeleccionarDirecciones()
        {

            SqlConnection cnx = new SqlConnection();
            DbDataReader dr;
            cnx = DC_Connection.getConnection();
            List<BE_DIRECCION> oDIRECCION = null;
            try
            {
                using (SqlCommand objCmd = new SqlCommand()
                {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_DIRECCION_SELECCIONAR"
                })
                {
                    cnx.Open();
                    dr = objCmd.ExecuteReader();

                    // Se crea una variable tipo int por cada posicion de cada campo
                    int DIRECCION_ID = dr.GetOrdinal("DIRECCION_ID");
                    int DIRECCION_DESCRIPCION = dr.GetOrdinal("DIRECCION_DESCRIPCION");
                    int DIRECCION_TIPO_ENVIO = dr.GetOrdinal("DIRECCION_TIPO_ENVIO");
                    int DIRECCION_TIPO = dr.GetOrdinal("DIRECCION_TIPO");
                    int USUARIO_CREACION = dr.GetOrdinal("USUARIO_CREACION");
                    int FECHA_CREACION = dr.GetOrdinal("FECHA_CREACION");
                    int USUARIO_ACTUALIZACION = dr.GetOrdinal("USUARIO_ACTUALIZACION");
                    int FECHA_ACTUALIZACION = dr.GetOrdinal("FECHA_ACTUALIZACION");
                    int DIRECCION_ESTADO = dr.GetOrdinal("DIRECCION_ESTADO");
                    int DIRECCION_DESTINATARIO = dr.GetOrdinal("DIRECCION_DESTINATARIO");
                    int DIRECCION_ATENCION = dr.GetOrdinal("DIRECCION_ATENCION");


                    // creamos un objeto del tamaño de la tupla en el array de objeto Valores
                    object[] Valores = new object[dr.FieldCount];

                    // Preguntamos si el DbDatGERENCIAder tiene registros
                    if (dr.HasRows)
                    {

                        // Instancionamos la lista para empezar a setearla
                        oDIRECCION = new List<BE_DIRECCION>();
                        while (dr.Read())
                        {
                            // Obtemos los valores para la tupla
                            dr.GetValues(Valores);
                            BE_DIRECCION oBE_DIRECCION = new BE_DIRECCION();
                            oBE_DIRECCION.ID = (Guid)Valores.GetValue(DIRECCION_ID);
                            oBE_DIRECCION.DESCRIPCION = Valores.GetValue(DIRECCION_DESCRIPCION).ToString();
                            oBE_DIRECCION.TIPO_ENVIO = Convert.ToInt32(Valores.GetValue(DIRECCION_TIPO_ENVIO));
                            oBE_DIRECCION.TIPO = Convert.ToInt32(Valores.GetValue(DIRECCION_TIPO));
                            oBE_DIRECCION.USUARIO_CREACION = (Guid)Valores.GetValue(USUARIO_CREACION);
                            oBE_DIRECCION.FECHA_CREACION = Convert.ToDateTime(Valores.GetValue(FECHA_CREACION));
                            oBE_DIRECCION.USUARIO_ACTUALIZACION = (Guid)Valores.GetValue(USUARIO_ACTUALIZACION);
                            oBE_DIRECCION.FECHA_ACTUALIZACION = Convert.ToDateTime(Valores.GetValue(FECHA_ACTUALIZACION));
                            oBE_DIRECCION.ESTADO = Convert.ToInt32(Valores.GetValue(DIRECCION_ESTADO));
                            oBE_DIRECCION.DESTINATARIO = Valores.GetValue(DIRECCION_DESTINATARIO).ToString();
                            oBE_DIRECCION.ATENCION = Valores.GetValue(DIRECCION_ATENCION).ToString();

                            BE_TIPO_SOLICITUD oBE_TIPO_SOLICITUD = new BE_TIPO_SOLICITUD();
                            oBE_TIPO_SOLICITUD.CODIGO = oBE_DIRECCION.TIPO_ENVIO;
                            
                            if (oBE_DIRECCION.TIPO_ENVIO == 1)
                                oBE_TIPO_SOLICITUD.DESCRIPCION = BE_PROVEEDOR.TIPO_PROVEEDOR.Nacional.ToString();
                            else
                                oBE_TIPO_SOLICITUD.DESCRIPCION = BE_PROVEEDOR.TIPO_PROVEEDOR.International.ToString();

                            oBE_DIRECCION.oBE_TIPO_SOLICITUD = oBE_TIPO_SOLICITUD;

                            BE_TIPO_DIRECCION oBE_TIPO_DIRECCION = new BE_TIPO_DIRECCION();
                            oBE_TIPO_DIRECCION.CODIGO = oBE_DIRECCION.TIPO;

                            if (oBE_DIRECCION.TIPO == 1)
                                oBE_TIPO_DIRECCION.DESCRIPCION = BE_DIRECCION.DIRECCION_TIPO.Remitente.ToString();
                            else
                                oBE_TIPO_DIRECCION.DESCRIPCION = BE_DIRECCION.DIRECCION_TIPO.Destinatario.ToString();

                            oBE_DIRECCION.oBE_TIPO_DIRECCION = oBE_TIPO_DIRECCION;                            

                            oDIRECCION.Add(oBE_DIRECCION);

                        }
                    }


                }

                return oDIRECCION;
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
        ///  Devuelve los datos de todos los Direcciones.
        /// </summary>      
        /// <returns> List de BE_DIRECCION_ATENCION con los objetos de la entidad, que a su vez representan la tabla DIRECCIONES_ATENCION de la base de datos.En caso no existan datos devuelve nothing </returns>
        public List<BE_DIRECCION_ATENCION> SeleccionarDireccionesAtencion()
        {

            SqlConnection cnx = new SqlConnection();
            DbDataReader dr;
            cnx = DC_Connection.getConnection();
            List<BE_DIRECCION_ATENCION> oDIRECCION_ATENCION = null;
            try
            {
                using (SqlCommand objCmd = new SqlCommand()
                {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_DIRECCION_ATENCION_SELECCIONAR"
                })
                {
                    cnx.Open();
                    dr = objCmd.ExecuteReader();

                    // Se crea una variable tipo int por cada posicion de cada campo
                    int ID = dr.GetOrdinal("ID");
                    int DIRECCION_ID = dr.GetOrdinal("DIRECCION_ID");
                    int DIRECCION_DESTINATARIO = dr.GetOrdinal("DIRECCION_DESTINATARIO");
                    int DIRECCION_ATENCION = dr.GetOrdinal("DIRECCION_ATENCION");                   
                    int USUARIO_CREACION = dr.GetOrdinal("USUARIO_CREACION");
                    int FECHA_CREACION = dr.GetOrdinal("FECHA_CREACION");
                    int USUARIO_ACTUALIZACION = dr.GetOrdinal("USUARIO_ACTUALIZACION");
                    int FECHA_ACTUALIZACION = dr.GetOrdinal("FECHA_ACTUALIZACION");
                    int DIRECCION_ATENCION_ESTADO = dr.GetOrdinal("DIRECCION_ATENCION_ESTADO");

                    // creamos un objeto del tamaño de la tupla en el array de objeto Valores
                    object[] Valores = new object[dr.FieldCount];

                    // Preguntamos si el DbDatGERENCIAder tiene registros
                    if (dr.HasRows)
                    {

                        // Instancionamos la lista para empezar a setearla
                        oDIRECCION_ATENCION = new List<BE_DIRECCION_ATENCION>();
                        while (dr.Read())
                        {
                            // Obtemos los valores para la tupla
                            dr.GetValues(Valores);
                            BE_DIRECCION_ATENCION oBE_DIRECCION_ATENCION = new BE_DIRECCION_ATENCION();
                            oBE_DIRECCION_ATENCION.ID = (Guid)Valores.GetValue(ID);
                            oBE_DIRECCION_ATENCION.DIRECCION_ID = (Guid)Valores.GetValue(DIRECCION_ID);
                            oBE_DIRECCION_ATENCION.DESTINATARIO = Valores.GetValue(DIRECCION_DESTINATARIO).ToString();
                            oBE_DIRECCION_ATENCION.ATENCION = Valores.GetValue(DIRECCION_ATENCION).ToString();
                            oBE_DIRECCION_ATENCION.USUARIO_CREACION = (Guid)Valores.GetValue(USUARIO_CREACION);
                            oBE_DIRECCION_ATENCION.FECHA_CREACION = Convert.ToDateTime(Valores.GetValue(FECHA_CREACION));
                            oBE_DIRECCION_ATENCION.USUARIO_ACTUALIZACION = (Guid)Valores.GetValue(USUARIO_ACTUALIZACION);
                            oBE_DIRECCION_ATENCION.FECHA_ACTUALIZACION = Convert.ToDateTime(Valores.GetValue(FECHA_ACTUALIZACION));
                            oBE_DIRECCION_ATENCION.ESTADO = Convert.ToInt32(Valores.GetValue(DIRECCION_ATENCION_ESTADO));                           

                            BE_DIRECCION oBE_DIRECCION = new BE_DIRECCION();
                            oBE_DIRECCION.ID = oBE_DIRECCION_ATENCION.DIRECCION_ID;
                            oBE_DIRECCION.DESTINATARIO = oBE_DIRECCION_ATENCION.DESTINATARIO;

                            oBE_DIRECCION_ATENCION.oBE_DIRECCION = oBE_DIRECCION;

                            oDIRECCION_ATENCION.Add(oBE_DIRECCION_ATENCION);                            

                        }
                    }


                }

                return oDIRECCION_ATENCION;
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
        ///  Devuelve los datos de todos las atenciones de las Direcciones.
        /// </summary>      
        /// <returns> List de BE_DIRECCION_ATENCION con los objetos de la entidad, que a su vez representan la tabla DIRECCIONES_ATENCION de la base de datos.En caso no existan datos devuelve nothing </returns>
        public List<BE_DIRECCION_ATENCION> SeleccionarDireccionesAtencionPorDestinatario(Guid direccion_id)
        {
            SqlConnection cnx = new SqlConnection();
            DbDataReader dr;
            cnx = DC_Connection.getConnection();
            List<BE_DIRECCION_ATENCION> oDIRECCION_ATENCION = null;
            try
            {
                using (SqlCommand objCmd = new SqlCommand()
                {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_DIRECCION_ATENCION_SELECCIONAR_POR_DESTINATARIO"
                })
                {
                    objCmd.Parameters.Add("@DIRECCION_ID", SqlDbType.UniqueIdentifier).Value = direccion_id;
                    
                    cnx.Open();
                    dr = objCmd.ExecuteReader();

                    // Se crea una variable tipo int por cada posicion de cada campo
                    int ID = dr.GetOrdinal("ID");
                    int DIRECCION_ID = dr.GetOrdinal("DIRECCION_ID");
                    int DIRECCION_DESTINATARIO = dr.GetOrdinal("DIRECCION_DESTINATARIO");
                    int DIRECCION_ATENCION = dr.GetOrdinal("DIRECCION_ATENCION");
                    int USUARIO_CREACION = dr.GetOrdinal("USUARIO_CREACION");
                    int FECHA_CREACION = dr.GetOrdinal("FECHA_CREACION");
                    int USUARIO_ACTUALIZACION = dr.GetOrdinal("USUARIO_ACTUALIZACION");
                    int FECHA_ACTUALIZACION = dr.GetOrdinal("FECHA_ACTUALIZACION");
                    int DIRECCION_ATENCION_ESTADO = dr.GetOrdinal("DIRECCION_ATENCION_ESTADO");

                    // creamos un objeto del tamaño de la tupla en el array de objeto Valores
                    object[] Valores = new object[dr.FieldCount];

                    // Preguntamos si el DbDatGERENCIAder tiene registros
                    if (dr.HasRows)
                    {

                        // Instancionamos la lista para empezar a setearla
                        oDIRECCION_ATENCION = new List<BE_DIRECCION_ATENCION>();
                        while (dr.Read())
                        {
                            // Obtemos los valores para la tupla
                            dr.GetValues(Valores);
                            BE_DIRECCION_ATENCION oBE_DIRECCION_ATENCION = new BE_DIRECCION_ATENCION();
                            oBE_DIRECCION_ATENCION.ID = (Guid)Valores.GetValue(ID);
                            oBE_DIRECCION_ATENCION.DIRECCION_ID = (Guid)Valores.GetValue(DIRECCION_ID);
                            oBE_DIRECCION_ATENCION.DESTINATARIO = Valores.GetValue(DIRECCION_DESTINATARIO).ToString();
                            oBE_DIRECCION_ATENCION.ATENCION = Valores.GetValue(DIRECCION_ATENCION).ToString();
                            oBE_DIRECCION_ATENCION.USUARIO_CREACION = (Guid)Valores.GetValue(USUARIO_CREACION);
                            oBE_DIRECCION_ATENCION.FECHA_CREACION = Convert.ToDateTime(Valores.GetValue(FECHA_CREACION));
                            oBE_DIRECCION_ATENCION.USUARIO_ACTUALIZACION = (Guid)Valores.GetValue(USUARIO_ACTUALIZACION);
                            oBE_DIRECCION_ATENCION.FECHA_ACTUALIZACION = Convert.ToDateTime(Valores.GetValue(FECHA_ACTUALIZACION));
                            oBE_DIRECCION_ATENCION.ESTADO = Convert.ToInt32(Valores.GetValue(DIRECCION_ATENCION_ESTADO));

                            BE_DIRECCION oBE_DIRECCION = new BE_DIRECCION();
                            oBE_DIRECCION.ID = oBE_DIRECCION_ATENCION.DIRECCION_ID;
                            oBE_DIRECCION.DESTINATARIO = oBE_DIRECCION_ATENCION.DESTINATARIO;

                            oBE_DIRECCION_ATENCION.oBE_DIRECCION = oBE_DIRECCION;

                            oDIRECCION_ATENCION.Add(oBE_DIRECCION_ATENCION);

                        }
                    }


                }

                return oDIRECCION_ATENCION;
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
        ///  Devuelve los datos de las Direcciones que pertenecen aun tipo de envío y de un determinado tipo.
        /// </summary>
        /// <param name="tipo_envio">int Tipo de envío:Nacional o Internacional</param>
        /// <param name="tipo_direccion">int Tipo de Dirección:Remitente o Destinatario</param>
        /// <returns> List de BE_DIRECCION con los objetos de la entidad, que a su vez representan la tabla DIRECCIONES de la base de datos.En caso no existan datos devuelve nothing </returns>
        public List<BE_DIRECCION> SeleccionarDireccionesPorTipo(int tipo_envio, int tipo_direccion)
        {

            SqlConnection cnx = new SqlConnection();
            DbDataReader dr;
            cnx = DC_Connection.getConnection();
            List<BE_DIRECCION> oDIRECCION = null;
            try
            {
                using (SqlCommand objCmd = new SqlCommand()
                {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_DIRECCION_SELECCIONAR_POR_TIPO_Y_TIPOENVIO"
                })
                {
                    objCmd.Parameters.Add("@TIPO_ENVIO", SqlDbType.Int).Value = tipo_envio;
                    objCmd.Parameters.Add("@TIPO", SqlDbType.Int).Value = tipo_direccion;

                    cnx.Open();
                    dr = objCmd.ExecuteReader();

                    // Se crea una variable tipo int por cada posicion de cada campo
                    int DIRECCION_ID = dr.GetOrdinal("DIRECCION_ID");
                    int DIRECCION_DESTINATARIO = dr.GetOrdinal("DIRECCION_DESTINATARIO");
                    int DIRECCION_TIPO_ENVIO = dr.GetOrdinal("DIRECCION_TIPO_ENVIO");
                    int DIRECCION_TIPO = dr.GetOrdinal("DIRECCION_TIPO");
                    int USUARIO_CREACION = dr.GetOrdinal("USUARIO_CREACION");
                    int FECHA_CREACION = dr.GetOrdinal("FECHA_CREACION");
                    int USUARIO_ACTUALIZACION = dr.GetOrdinal("USUARIO_ACTUALIZACION");
                    int FECHA_ACTUALIZACION = dr.GetOrdinal("FECHA_ACTUALIZACION");
                    int DIRECCION_ESTADO = dr.GetOrdinal("DIRECCION_ESTADO");
                    int DIRECCION_DESCRIPCION = dr.GetOrdinal("DIRECCION_DESCRIPCION");


                    // creamos un objeto del tamaño de la tupla en el array de objeto Valores
                    object[] Valores = new object[dr.FieldCount];

                    // Preguntamos si el DbDatGERENCIAder tiene registros
                    if (dr.HasRows)
                    {

                        // Instancionamos la lista para empezar a setearla
                        oDIRECCION = new List<BE_DIRECCION>();
                        while (dr.Read())
                        {
                            // Obetemos los valores para la tupla
                            dr.GetValues(Valores);
                            BE_DIRECCION oBE_DIRECCION = new BE_DIRECCION();
                            oBE_DIRECCION.ID = (Guid)Valores.GetValue(DIRECCION_ID);
                            oBE_DIRECCION.DESTINATARIO = Valores.GetValue(DIRECCION_DESTINATARIO).ToString();
                            oBE_DIRECCION.DESCRIPCION = Valores.GetValue(DIRECCION_DESCRIPCION).ToString();
                            oBE_DIRECCION.TIPO_ENVIO = Convert.ToInt32(Valores.GetValue(DIRECCION_TIPO_ENVIO));
                            oBE_DIRECCION.TIPO = Convert.ToInt32(Valores.GetValue(DIRECCION_TIPO));
                            oBE_DIRECCION.USUARIO_CREACION = (Guid)Valores.GetValue(USUARIO_CREACION);
                            oBE_DIRECCION.FECHA_CREACION = Convert.ToDateTime(Valores.GetValue(FECHA_CREACION));
                            oBE_DIRECCION.USUARIO_ACTUALIZACION = (Guid)Valores.GetValue(USUARIO_ACTUALIZACION);
                            oBE_DIRECCION.FECHA_ACTUALIZACION = Convert.ToDateTime(Valores.GetValue(FECHA_ACTUALIZACION));
                            oBE_DIRECCION.ESTADO = Convert.ToInt32(Valores.GetValue(DIRECCION_ESTADO));
                            oDIRECCION.Add(oBE_DIRECCION);

                        }
                    }


                }

                return oDIRECCION;
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
        ///  Devuelve los datos de las Direcciones que pertenecen a un tipo de dirección = destinatario
        /// </summary>
        /// <returns> List de BE_DIRECCION con los objetos de la entidad, que a su vez representan la tabla DIRECCIONES de la base de datos.En caso no existan datos devuelve nothing </returns>
        public List<BE_DIRECCION> SeleccionarDireccionesDestinatario()
        {

            SqlConnection cnx = new SqlConnection();
            DbDataReader dr;
            cnx = DC_Connection.getConnection();
            List<BE_DIRECCION> oDIRECCION = null;
            try
            {
                using (SqlCommand objCmd = new SqlCommand()
                {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_DIRECCION_SELECCIONAR_DESTINATARIOS"
                })
                {                    

                    cnx.Open();
                    dr = objCmd.ExecuteReader();

                    // Se crea una variable tipo int por cada posicion de cada campo
                    int DIRECCION_ID = dr.GetOrdinal("DIRECCION_ID");
                    int DIRECCION_DESTINATARIO = dr.GetOrdinal("DIRECCION_DESTINATARIO");
                    int DIRECCION_TIPO_ENVIO = dr.GetOrdinal("DIRECCION_TIPO_ENVIO");
                    int DIRECCION_TIPO = dr.GetOrdinal("DIRECCION_TIPO");
                    int USUARIO_CREACION = dr.GetOrdinal("USUARIO_CREACION");
                    int FECHA_CREACION = dr.GetOrdinal("FECHA_CREACION");
                    int USUARIO_ACTUALIZACION = dr.GetOrdinal("USUARIO_ACTUALIZACION");
                    int FECHA_ACTUALIZACION = dr.GetOrdinal("FECHA_ACTUALIZACION");
                    int DIRECCION_ESTADO = dr.GetOrdinal("DIRECCION_ESTADO");
                    int DIRECCION_DESCRIPCION = dr.GetOrdinal("DIRECCION_DESCRIPCION");


                    // creamos un objeto del tamaño de la tupla en el array de objeto Valores
                    object[] Valores = new object[dr.FieldCount];

                    // Preguntamos si el DbDatGERENCIAder tiene registros
                    if (dr.HasRows)
                    {

                        // Instancionamos la lista para empezar a setearla
                        oDIRECCION = new List<BE_DIRECCION>();
                        while (dr.Read())
                        {
                            // Obetemos los valores para la tupla
                            dr.GetValues(Valores);
                            BE_DIRECCION oBE_DIRECCION = new BE_DIRECCION();
                            oBE_DIRECCION.ID = (Guid)Valores.GetValue(DIRECCION_ID);
                            oBE_DIRECCION.DESTINATARIO = Valores.GetValue(DIRECCION_DESTINATARIO).ToString();
                            oBE_DIRECCION.DESCRIPCION = Valores.GetValue(DIRECCION_DESCRIPCION).ToString();
                            oBE_DIRECCION.TIPO_ENVIO = Convert.ToInt32(Valores.GetValue(DIRECCION_TIPO_ENVIO));
                            oBE_DIRECCION.TIPO = Convert.ToInt32(Valores.GetValue(DIRECCION_TIPO));
                            oBE_DIRECCION.USUARIO_CREACION = (Guid)Valores.GetValue(USUARIO_CREACION);
                            oBE_DIRECCION.FECHA_CREACION = Convert.ToDateTime(Valores.GetValue(FECHA_CREACION));
                            oBE_DIRECCION.USUARIO_ACTUALIZACION = (Guid)Valores.GetValue(USUARIO_ACTUALIZACION);
                            oBE_DIRECCION.FECHA_ACTUALIZACION = Convert.ToDateTime(Valores.GetValue(FECHA_ACTUALIZACION));
                            oBE_DIRECCION.ESTADO = Convert.ToInt32(Valores.GetValue(DIRECCION_ESTADO));
                            oDIRECCION.Add(oBE_DIRECCION);

                        }
                    }


                }

                return oDIRECCION;
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
        /// Devuelve los datos de una solicitud
        /// </summary>
        /// <param name="direccionId">Id de la Dirección que se desea consultar</param>
        /// <returns>Objeto BE_DIRECCION con los datos de una dirección, que a su vez representan la tabla DIRECCIONES de la base de datos. En caso no existan datos devuelve nothing.</returns>
        public BE_DIRECCION SeleccionarDireccionPorId(Guid direccionId)
        {

            SqlConnection cnx = new SqlConnection();
            DbDataReader dr;
            cnx = DC_Connection.getConnection();
            BE_DIRECCION oBE_DIRECCION = new BE_DIRECCION();
            

            try
            {
                using (SqlCommand objCmd = new SqlCommand()
                {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_DIRECCION_SELECCIONAR_POR_ID"
                })
                {

                    objCmd.Parameters.Add("@DIRECCION_ID", SqlDbType.UniqueIdentifier).Value = direccionId;

                    cnx.Open();
                    dr = objCmd.ExecuteReader();

                    // Se crea una variable tipo int por cada posicion de cada campo    
                    int DIRECCION_ID = dr.GetOrdinal("DIRECCION_ID");
                    int DIRECCION_DESCRIPCION = dr.GetOrdinal("DIRECCION_DESCRIPCION");
                    int DIRECCION_TIPO_ENVIO = dr.GetOrdinal("DIRECCION_TIPO_ENVIO");
                    int DIRECCION_TIPO = dr.GetOrdinal("DIRECCION_TIPO");
                    int DIRECCION_DESTINATARIO = dr.GetOrdinal("DIRECCION_DESTINATARIO");
                    int DIRECCION_ATENCION = dr.GetOrdinal("DIRECCION_ATENCION");
                    int USUARIO_CREACION = dr.GetOrdinal("USUARIO_CREACION");
                    int FECHA_CREACION = dr.GetOrdinal("FECHA_CREACION");
                    int USUARIO_ACTUALIZACION = dr.GetOrdinal("USUARIO_ACTUALIZACION");
                    int FECHA_ACTUALIZACION = dr.GetOrdinal("FECHA_ACTUALIZACION");
                    int DIRECCION_ESTADO = dr.GetOrdinal("DIRECCION_ESTADO");
                    
                   

                    // creamos un objeto del tamaño de la tupla en el array de objeto Valores
                    object[] Valores = new object[dr.FieldCount];

                    // Preguntamos si el DbDataReader tiene registros
                    if (dr.HasRows)
                    {

                        if (dr.Read())
                        {
                            // Obetemos los valores para la tupla
                            dr.GetValues(Valores);
                            
                            oBE_DIRECCION.ID = (Guid)Valores.GetValue(DIRECCION_ID);
                            oBE_DIRECCION.DESCRIPCION = Valores.GetValue(DIRECCION_DESCRIPCION).ToString();
                            oBE_DIRECCION.TIPO_ENVIO = Convert.ToInt32(Valores.GetValue(DIRECCION_TIPO_ENVIO));
                            oBE_DIRECCION.TIPO = Convert.ToInt32(Valores.GetValue(DIRECCION_TIPO));
                            oBE_DIRECCION.USUARIO_CREACION = (Guid)Valores.GetValue(USUARIO_CREACION);
                            oBE_DIRECCION.FECHA_CREACION = Convert.ToDateTime(Valores.GetValue(FECHA_CREACION));
                            oBE_DIRECCION.USUARIO_ACTUALIZACION = (Guid)Valores.GetValue(USUARIO_ACTUALIZACION);
                            oBE_DIRECCION.FECHA_ACTUALIZACION = Convert.ToDateTime(Valores.GetValue(FECHA_ACTUALIZACION));
                            oBE_DIRECCION.ESTADO = Convert.ToInt32(Valores.GetValue(DIRECCION_ESTADO));
                            oBE_DIRECCION.DESTINATARIO = Valores.GetValue(DIRECCION_DESTINATARIO).ToString();
                            oBE_DIRECCION.ATENCION = Valores.GetValue(DIRECCION_ATENCION).ToString();                               

                        }
                    }

                }

                return oBE_DIRECCION;
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
        /// Ingresa una nueva Direccion
        /// </summary>
        /// <param name="oBE_DIRECCION">Objeto BE_DIRECCION con todos sus campos llenos</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Guid InsertarDireccion(BE_DIRECCION oBE_DIRECCION)
        {
            SqlConnection cnx = new SqlConnection();
            Guid direccion_id = Guid.Empty;

            cnx = DC_Connection.getConnection();

            try
            {

                using (
                    SqlCommand objCmd = new SqlCommand()
                    {
                        Connection = cnx,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "USP_DIRECCION_INSERTAR"
                    }
                    )
                {
                    //Se crea el objeto Parameters por cada parametro

                    objCmd.Parameters.Add("@DIRECCION_TIPO_ENVIO", SqlDbType.Int).Value = oBE_DIRECCION.TIPO_ENVIO;
                    objCmd.Parameters.Add("@DIRECCION_TIPO", SqlDbType.Int).Value = oBE_DIRECCION.TIPO;
                    objCmd.Parameters.Add("@DIRECCION_DESCRIPCION", SqlDbType.VarChar).Value = oBE_DIRECCION.DESCRIPCION;
                    objCmd.Parameters.Add("@DIRECCION_DESTINATARIO", SqlDbType.VarChar).Value = oBE_DIRECCION.DESTINATARIO;
                    objCmd.Parameters.Add("@DIRECCION_ATENCION", SqlDbType.VarChar).Value = oBE_DIRECCION.ATENCION;                   
                    objCmd.Parameters.Add("@USUARIO", SqlDbType.UniqueIdentifier).Value = oBE_DIRECCION.USUARIO_CREACION;

                    cnx.Open();

                    direccion_id = (Guid)objCmd.ExecuteScalar();
                    
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


            return direccion_id;
        }

        /// <summary>
        /// Actualizar una Dirección
        /// </summary>
        /// <param name="oBE_DIRECCION">Objeto BE_DIRECCION con todos sus campos llenos</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean ActualizarDireccion(BE_DIRECCION oBE_DIRECCION)
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
                        CommandText = "USP_DIRECCION_ACTUALIZAR"
                    }
                    )
                {
                    //Se crea el objeto Parameters por cada parametro
                    objCmd.Parameters.Add("@DIRECCION_ID", SqlDbType.UniqueIdentifier).Value = oBE_DIRECCION.ID;
                    objCmd.Parameters.Add("@DIRECCION_TIPO_ENVIO", SqlDbType.Int).Value = oBE_DIRECCION.TIPO_ENVIO;
                    objCmd.Parameters.Add("@DIRECCION_TIPO", SqlDbType.Int).Value = oBE_DIRECCION.TIPO;
                    objCmd.Parameters.Add("@DIRECCION_DESCRIPCION", SqlDbType.VarChar).Value = oBE_DIRECCION.DESCRIPCION;
                    objCmd.Parameters.Add("@DIRECCION_DESTINATARIO", SqlDbType.VarChar).Value = oBE_DIRECCION.DESTINATARIO;
                    objCmd.Parameters.Add("@DIRECCION_ATENCION", SqlDbType.VarChar).Value = oBE_DIRECCION.ATENCION; 
                    objCmd.Parameters.Add("@USUARIO", SqlDbType.UniqueIdentifier).Value = oBE_DIRECCION.USUARIO_CREACION;

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
        /// Ingresa una nueva Direccion
        /// </summary>
        /// <param name="oBE_DIRECCION_ATENCION">Objeto BE_DIRECCION_ATENCION con todos sus campos llenos</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Guid InsertarDireccionAtencion(BE_DIRECCION_ATENCION oBE_DIRECCION_ATENCION)
        {
            SqlConnection cnx = new SqlConnection();
            Guid direccion_id = Guid.Empty;

            cnx = DC_Connection.getConnection();

            try
            {

                using (
                    SqlCommand objCmd = new SqlCommand()
                    {
                        Connection = cnx,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "USP_DIRECCION_ATENCION_INSERTAR"
                    }
                    )
                {
                    //Se crea el objeto Parameters por cada parametro

                    objCmd.Parameters.Add("@DIRECCION_ID", SqlDbType.UniqueIdentifier).Value = oBE_DIRECCION_ATENCION.DIRECCION_ID;
                    objCmd.Parameters.Add("@DIRECCION_DESTINATARIO", SqlDbType.VarChar).Value = oBE_DIRECCION_ATENCION.DESTINATARIO;
                    objCmd.Parameters.Add("@DIRECCION_ATENCION", SqlDbType.VarChar).Value = oBE_DIRECCION_ATENCION.ATENCION;
                    objCmd.Parameters.Add("@USUARIO", SqlDbType.UniqueIdentifier).Value = oBE_DIRECCION_ATENCION.USUARIO_CREACION;

                    cnx.Open();

                    direccion_id = (Guid)objCmd.ExecuteScalar();

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


            return direccion_id;
        }


        /// <summary>
        /// Actualizar una Dirección Atención
        /// </summary>
        /// <param name="oBE_DIRECCION_ATENCION">Objeto BE_DIRECCION_ATENCION con todos sus campos llenos</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean ActualizarDireccionAtencion(BE_DIRECCION_ATENCION oBE_DIRECCION_ATENCION)
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
                        CommandText = "USP_DIRECCION_ATENCION_ACTUALIZAR"
                    }
                    )
                {
                    //Se crea el objeto Parameters por cada parametro
                    objCmd.Parameters.Add("@DIRECCION_ATENCION_ID", SqlDbType.UniqueIdentifier).Value = oBE_DIRECCION_ATENCION.ID;
                    objCmd.Parameters.Add("@DIRECCION_ID", SqlDbType.UniqueIdentifier).Value = oBE_DIRECCION_ATENCION.DIRECCION_ID;
                    objCmd.Parameters.Add("@DIRECCION_DESTINATARIO", SqlDbType.VarChar).Value = oBE_DIRECCION_ATENCION.DESTINATARIO;
                    objCmd.Parameters.Add("@DIRECCION_ATENCION", SqlDbType.VarChar).Value = oBE_DIRECCION_ATENCION.ATENCION;
                    objCmd.Parameters.Add("@USUARIO", SqlDbType.UniqueIdentifier).Value = oBE_DIRECCION_ATENCION.USUARIO_CREACION;

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
        /// Eliminar un Proveedor
        /// </summary>
        /// <param name="direccionId">Identificador de la dirección a eliminar</param>        
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean EliminarDireccion(Guid direccionId)
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
                        CommandText = "USP_DIRECCION_ELIMINAR"
                    }
                    )
                {
                    objCmd.Parameters.Add("@DIRECCION_ID", SqlDbType.UniqueIdentifier).Value = direccionId;


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
        /// Eliminar una Dirección Atención
        /// </summary>
        /// <param name="direccionId">Identificador de la dirección a eliminar</param>        
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean EliminarDireccionAtencion(Guid direccion_atencion_Id)
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
                        CommandText = "USP_DIRECCION_ATENCION_ELIMINAR"
                    }
                    )
                {
                    objCmd.Parameters.Add("@DIRECCION_ATENCION_ID", SqlDbType.UniqueIdentifier).Value = direccion_atencion_Id;


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
        /// Eliminar una Dirección Atención
        /// </summary>
        /// <param name="direccionId">Identificador de la dirección a eliminar</param>        
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean EliminarDireccionAtencionPorDestinatario(Guid direccion_Id)
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
                        CommandText = "USP_DIRECCION_ATENCION_ELIMINAR_POR_DESTINATARIO"
                    }
                    )
                {
                    objCmd.Parameters.Add("@DIRECCION_ID", SqlDbType.UniqueIdentifier).Value = direccion_Id;


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
