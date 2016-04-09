using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using BusinessEntities;
using DataConnectionComponent;
using System.Data;
using System.Data.Common;

namespace DataAccessLayer
{
    /// <summary>
    /// En esta clase se encuentran todos los metodos para las consultas de la tabla CORRESPONDENCIA
    /// </summary>
    public class DA_CORRESPONDENCIA
    {

        /// <summary>
        /// Devuelve los datos de una correspondencia
        /// </summary>
        /// <param name="solicitudId">Id de la Solicitud cuya correspondencia se desea consultar</param>
        /// <returns>Objeto BE_CORRESPONDENCIA con los datos de una correspondencia, que a su vez representan la tabla CORRESPONDENCIA de la base de datos. En caso no existan datos devuelve nothing.</returns>
        public BE_CORRESPONDENCIA SeleccionarCorrespondenciaPorSolicitud(Guid solicitudId)
        {

            SqlConnection cnx = new SqlConnection();
            DbDataReader dr;
            cnx = DC_Connection.getConnection();
            BE_CORRESPONDENCIA oBE_CORRESPONDENCIA = null;
           
            try
            {
                using (SqlCommand objCmd = new SqlCommand()
                {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_CORRESPONDENCIA_SELECCIONAR_POR_SOLICITUD"
                })
                {

                    objCmd.Parameters.Add("@SOLICITUD_ID", SqlDbType.UniqueIdentifier).Value = solicitudId;

                    cnx.Open();
                    dr = objCmd.ExecuteReader();

                    // Se crea una variable tipo int por cada posicion de cada campo
                    int CORRESPONDENCIA_ID = dr.GetOrdinal("CORRESPONDENCIA_ID");
                    int SOLICITUD_ID = dr.GetOrdinal("SOLICITUD_ID");
                    int CORRESPONDENCIA_TIPO_ENVIO = dr.GetOrdinal("CORRESPONDENCIA_TIPO_ENVIO");
                    int CORRESPONDENCIA_TIPO = dr.GetOrdinal("CORRESPONDENCIA_TIPO");
                    int CORRESPONDENCIA_CARACTERISTICA = dr.GetOrdinal("CORRESPONDENCIA_CARACTERISTICA");
                    int CORRESPONDENCIA_PROVEEDOR = dr.GetOrdinal("CORRESPONDENCIA_PROVEEDOR");
                    int CORRESPONDENCIA_ORDEN_PROVEEDOR = dr.GetOrdinal("CORRESPONDENCIA_ORDEN_PROVEEDOR");
                    int CORRESPONDENCIA_FECHA_ENVIO = dr.GetOrdinal("CORRESPONDENCIA_FECHA_ENVIO");
                    int CORRESPONDENCIA_REMITENTE = dr.GetOrdinal("CORRRESPONDENCIA_REMITENTE");
                    int CORRESPONDENCIA_DIRECCION_REMITENTE = dr.GetOrdinal("CORRESPONDENCIA_DIRECCION_REMITENTE");
                    int CORRESPONDENCIA_CANTIDAD = dr.GetOrdinal("CORRESPONDENCIA_CANTIDAD");
                    int CORRESPONDENCIA_PESO = dr.GetOrdinal("CORRESPONDENCIA_PESO");                   
                    int CORRESPONDENCIA_COSTO = dr.GetOrdinal("CORRESPONDENCIA_COSTO");
                    int CORRESPONDENCIA_CONTENIDO = dr.GetOrdinal("CORRESPONDENCIA_CONTENIDO");
                    int CORRESPONDENCIA_GUIA = dr.GetOrdinal("CORRESPONDENCIA_GUIA");
                    int CORRESPONDENCIA_DESTINATARIO = dr.GetOrdinal("CORRESPONDENCIA_DESTINATARIO");
                    int CORRESPONDENCIA_DESTINATARIO_DIRECCION = dr.GetOrdinal("CORRESPONDENCIA_DESTINATARIO_DIRECCION");
                    int CORRESPONDENCIA_ATENCION = dr.GetOrdinal("CORRESPONDENCIA_ATENCION");
                    int CORRESPONDENCIA_MEDIDA = dr.GetOrdinal("CORRESPONDENCIA_MEDIDA");
                    int CORRESPONDENCIA_COSTO_DECLARAR = dr.GetOrdinal("CORRESPONDENCIA_COSTO_DECLARAR");
                    int CORRESPONDENCIA_DESTINATARIO_TELEFONO = dr.GetOrdinal("CORRESPONDENCIA_DESTINATARIO_TELEFONO");
                    int CORRESPONDENCIA_DESTINATARIO_PAIS = dr.GetOrdinal("CORRESPONDENCIA_DESTINATARIO_PAIS");
                    int CORRESPONDENCIA_DESTINATARIO_ESTADO_PROVINCIA = dr.GetOrdinal("CORRESPONDENCIA_DESTINATARIO_ESTADO_PROVINCIA");
                    int CORRESPONDENCIA_DESTINATARIO_CIUDAD = dr.GetOrdinal("CORRESPONDENCIA_DESTINATARIO_CIUDAD");
                    int CORRESPONDENCIA_DESTINATARIO_CODIGO_POSTAL = dr.GetOrdinal("CORRESPONDENCIA_DESTINATARIO_CODIGO_POSTAL");
                    int USUARIO_CREACION = dr.GetOrdinal("USUARIO_CREACION");
                    int CORRESPONDENCIA_ESTADO = dr.GetOrdinal("CORRESPONDENCIA_ESTADO");
                    int CORRESPONDENCIA_ATENCION_ID = dr.GetOrdinal("CORRESPONDENCIA_ATENCION_ID");

                    // creamos un objeto del tamaño de la tupla en el array de objeto Valores
                    object[] Valores = new object[dr.FieldCount];

                    // Preguntamos si el DbDataReader tiene registros
                    if (dr.HasRows)
                    {

                        if (dr.Read())
                        {
                            // Obetemos los valores para la tupla
                            dr.GetValues(Valores);
                            oBE_CORRESPONDENCIA = new BE_CORRESPONDENCIA();
                            oBE_CORRESPONDENCIA.ID = (Guid)Valores.GetValue(CORRESPONDENCIA_ID);
                            oBE_CORRESPONDENCIA.SOLICITUD_ID = (Guid)Valores.GetValue(SOLICITUD_ID);
                            oBE_CORRESPONDENCIA.TIPO_ENVIO = (int)Valores.GetValue(CORRESPONDENCIA_TIPO_ENVIO);
                            oBE_CORRESPONDENCIA.TIPO = (int)Valores.GetValue(CORRESPONDENCIA_TIPO);
                            oBE_CORRESPONDENCIA.CARACTERISTICA = (int)Valores.GetValue(CORRESPONDENCIA_CARACTERISTICA);
                            oBE_CORRESPONDENCIA.PROVEEDOR_ID = (Guid)Valores.GetValue(CORRESPONDENCIA_PROVEEDOR);
                            oBE_CORRESPONDENCIA.ORDEN_PROVEEDOR = DBNull.Value == Valores.GetValue(CORRESPONDENCIA_ORDEN_PROVEEDOR) ? String.Empty : Valores.GetValue(CORRESPONDENCIA_ORDEN_PROVEEDOR).ToString();
                            oBE_CORRESPONDENCIA.FECHA_ENVIO = Valores.GetValue(CORRESPONDENCIA_FECHA_ENVIO).ToString();
                            oBE_CORRESPONDENCIA.REMITENTE = Valores.GetValue(CORRESPONDENCIA_REMITENTE).ToString();
                            oBE_CORRESPONDENCIA.DIRECCION_REMITENTE_ID = (Guid)Valores.GetValue(CORRESPONDENCIA_DIRECCION_REMITENTE);
                            oBE_CORRESPONDENCIA.CANTIDAD = Convert.ToDecimal(Valores.GetValue(CORRESPONDENCIA_CANTIDAD));
                            oBE_CORRESPONDENCIA.PESO = Convert.ToDecimal(Valores.GetValue(CORRESPONDENCIA_PESO));
                            oBE_CORRESPONDENCIA.COSTO = Convert.ToDecimal(Valores.GetValue(CORRESPONDENCIA_COSTO));
                            oBE_CORRESPONDENCIA.CONTENIDO = Valores.GetValue(CORRESPONDENCIA_CONTENIDO).ToString();
                            oBE_CORRESPONDENCIA.GUIA = DBNull.Value == Valores.GetValue(CORRESPONDENCIA_GUIA) ? String.Empty : Valores.GetValue(CORRESPONDENCIA_GUIA).ToString();
                            oBE_CORRESPONDENCIA.DESTINATARIO = DBNull.Value == Valores.GetValue(CORRESPONDENCIA_DESTINATARIO) ? String.Empty : Valores.GetValue(CORRESPONDENCIA_DESTINATARIO).ToString();
                            oBE_CORRESPONDENCIA.DIRECCION_DESTINATARIO_ID = (Guid)Valores.GetValue(CORRESPONDENCIA_DESTINATARIO_DIRECCION);
                            oBE_CORRESPONDENCIA.ATENCION = DBNull.Value == Valores.GetValue(CORRESPONDENCIA_ATENCION) ? String.Empty : Valores.GetValue(CORRESPONDENCIA_ATENCION).ToString();
                            oBE_CORRESPONDENCIA.MEDIDAS = DBNull.Value == Valores.GetValue(CORRESPONDENCIA_MEDIDA) ? String.Empty : Valores.GetValue(CORRESPONDENCIA_MEDIDA).ToString();
                            oBE_CORRESPONDENCIA.COSTO_DECLARAR = DBNull.Value == Valores.GetValue(CORRESPONDENCIA_COSTO_DECLARAR) ? String.Empty : Valores.GetValue(CORRESPONDENCIA_COSTO_DECLARAR).ToString();
                            oBE_CORRESPONDENCIA.TELEFONO = DBNull.Value == Valores.GetValue(CORRESPONDENCIA_DESTINATARIO_TELEFONO) ? String.Empty : Valores.GetValue(CORRESPONDENCIA_DESTINATARIO_TELEFONO).ToString();
                            oBE_CORRESPONDENCIA.PAIS = DBNull.Value == Valores.GetValue(CORRESPONDENCIA_DESTINATARIO_PAIS) ? String.Empty : Valores.GetValue(CORRESPONDENCIA_DESTINATARIO_PAIS).ToString();
                            oBE_CORRESPONDENCIA.ESTADO_PROVINCIA = DBNull.Value == Valores.GetValue(CORRESPONDENCIA_DESTINATARIO_ESTADO_PROVINCIA) ? String.Empty : Valores.GetValue(CORRESPONDENCIA_DESTINATARIO_ESTADO_PROVINCIA).ToString();
                            oBE_CORRESPONDENCIA.CIUDAD = DBNull.Value == Valores.GetValue(CORRESPONDENCIA_DESTINATARIO_CIUDAD) ? String.Empty : Valores.GetValue(CORRESPONDENCIA_DESTINATARIO_CIUDAD).ToString();
                            oBE_CORRESPONDENCIA.CODIGO_POSTAL = DBNull.Value == Valores.GetValue(CORRESPONDENCIA_DESTINATARIO_CODIGO_POSTAL) ? String.Empty : Valores.GetValue(CORRESPONDENCIA_DESTINATARIO_CODIGO_POSTAL).ToString();
                            oBE_CORRESPONDENCIA.ESTADO = DBNull.Value == Valores.GetValue(CORRESPONDENCIA_ESTADO) ? 1 : (int)Valores.GetValue(CORRESPONDENCIA_ESTADO);
                            oBE_CORRESPONDENCIA.USUARIO_CREACION = (Guid)Valores.GetValue(USUARIO_CREACION);
                            oBE_CORRESPONDENCIA.ATENCION_ID = (Guid)Valores.GetValue(CORRESPONDENCIA_ATENCION_ID);
                            
                            
                        }
                    }


                }

                return oBE_CORRESPONDENCIA;
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
        /// Inserta los datos de  CORRESPONDENCIA
        /// </summary>
        /// <param name="oBE_CORRESPONDENCIA">Objeto de tipo BE_CORRESPONDENCIA, que representa la tabla CORRESPONDENCIA, con todos sus atributos </param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean InsertarCorrespondencia(BE_CORRESPONDENCIA oBE_CORRESPONDENCIA, Guid solicitud_id, SqlTransaction otransaction, SqlCommand objCmd)
        {
            bool bIndicador = false;           

            try
            {

                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "USP_CORRESPONDENCIA_INSERTAR";
                objCmd.Transaction = otransaction;
                                
                objCmd.Parameters.Clear();
                objCmd.Parameters.Add("@SOLICITUD_ID", SqlDbType.UniqueIdentifier).Value = solicitud_id;
                objCmd.Parameters.Add("@CORRESPONDENCIA_TIPO_ENVIO", SqlDbType.Int).Value = oBE_CORRESPONDENCIA.TIPO_ENVIO;
                objCmd.Parameters.Add("@CORRESPONDENCIA_TIPO", SqlDbType.Int).Value = oBE_CORRESPONDENCIA.TIPO;
                objCmd.Parameters.Add("@CORRESPONDENCIA_CARACTERISTICA", SqlDbType.Int).Value = oBE_CORRESPONDENCIA.CARACTERISTICA;
                objCmd.Parameters.Add("@CORRESPONDENCIA_PROVEEDOR", SqlDbType.UniqueIdentifier).Value = oBE_CORRESPONDENCIA.PROVEEDOR_ID;
                objCmd.Parameters.Add("@CORRESPONDENCIA_ORDEN_PROVEEDOR", SqlDbType.VarChar).Value = oBE_CORRESPONDENCIA.ORDEN_PROVEEDOR;
                objCmd.Parameters.Add("@CORRESPONDENCIA_FECHA_ENVIO", SqlDbType.Date).Value = Convert.ToDateTime(oBE_CORRESPONDENCIA.FECHA_ENVIO).Date;
                objCmd.Parameters.Add("@CORRESPONDENCIA_REMITENTE", SqlDbType.VarChar).Value = oBE_CORRESPONDENCIA.REMITENTE;
                objCmd.Parameters.Add("@CORRESPONDENCIA_DIRECCION_REMINTENTE", SqlDbType.UniqueIdentifier).Value = oBE_CORRESPONDENCIA.DIRECCION_REMITENTE_ID;
                objCmd.Parameters.Add("@CORRESPONDENCIA_CANTIDAD", SqlDbType.Decimal).Value = oBE_CORRESPONDENCIA.CANTIDAD;
                objCmd.Parameters.Add("@CORRESPONDENCIA_PESO", SqlDbType.Decimal).Value = oBE_CORRESPONDENCIA.PESO;
                objCmd.Parameters.Add("@CORRESPONDENCIA_COSTO", SqlDbType.Decimal).Value = oBE_CORRESPONDENCIA.COSTO;                
                objCmd.Parameters.Add("@CORRESPONDENCIA_CONTENIDO", SqlDbType.VarChar).Value = oBE_CORRESPONDENCIA.CONTENIDO;
                objCmd.Parameters.Add("@CORRESPONDENCIA_GUIA", SqlDbType.VarChar).Value = oBE_CORRESPONDENCIA.GUIA;
                objCmd.Parameters.Add("@CORRESPONDENCIA_DESTINATARIO", SqlDbType.VarChar).Value = oBE_CORRESPONDENCIA.DESTINATARIO;
                objCmd.Parameters.Add("@CORRESPONDENCIA_DIRECCION_DESTINATARIO", SqlDbType.UniqueIdentifier).Value = oBE_CORRESPONDENCIA.DIRECCION_DESTINATARIO_ID;
                objCmd.Parameters.Add("@CORRESPONDENCIA_ATENCION", SqlDbType.VarChar).Value = oBE_CORRESPONDENCIA.ATENCION;
                objCmd.Parameters.Add("@CORRESPONDENCIA_MEDIDA", SqlDbType.VarChar).Value = oBE_CORRESPONDENCIA.MEDIDAS;
                objCmd.Parameters.Add("@CORRESPONDENCIA_COSTO_DECLARAR", SqlDbType.Decimal).Value = Convert.ToDecimal(oBE_CORRESPONDENCIA.COSTO_DECLARAR);
                objCmd.Parameters.Add("@CORRESPONDENCIA_TELEFONO", SqlDbType.VarChar).Value = oBE_CORRESPONDENCIA.TELEFONO;
                objCmd.Parameters.Add("@CORRESPONDENCIA_PAIS", SqlDbType.VarChar).Value = oBE_CORRESPONDENCIA.PAIS;
                objCmd.Parameters.Add("@CORRESPONDENCIA_ESTADO_PROVINCIA", SqlDbType.VarChar).Value = oBE_CORRESPONDENCIA.ESTADO_PROVINCIA;
                objCmd.Parameters.Add("@CORRESPONDENCIA_CIUDAD", SqlDbType.VarChar).Value = oBE_CORRESPONDENCIA.CIUDAD;
                objCmd.Parameters.Add("@CORRESPONDENCIA_CODIGO_POSTAL", SqlDbType.VarChar).Value = oBE_CORRESPONDENCIA.CODIGO_POSTAL;
                objCmd.Parameters.Add("@ESTADO", SqlDbType.Int).Value = oBE_CORRESPONDENCIA.ESTADO;
                objCmd.Parameters.Add("@USUARIO", SqlDbType.UniqueIdentifier).Value = oBE_CORRESPONDENCIA.USUARIO_CREACION;
                objCmd.Parameters.Add("@CORRESPONDENCIA_ATENCION_ID", SqlDbType.UniqueIdentifier).Value = oBE_CORRESPONDENCIA.ATENCION_ID;


                bIndicador = objCmd.ExecuteNonQuery() > 0;

                return bIndicador;

              }            
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);                
            }

            
        }

        /// <summary>
        /// Actualizar los datos de  CORRESPONDENCIA
        /// </summary>
        /// <param name="oBE_CORRESPONDENCIA">Objeto de tipo BE_CORRESPONDENCIA, que representa la tabla CORRESPONDENCIA, con todos sus atributos </param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean ActualizarCorrespondencia(BE_CORRESPONDENCIA oBE_CORRESPONDENCIA, SqlTransaction otransaction, SqlCommand objCmd)
        {
            bool bIndicador = false;

            try
            {

                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "USP_CORRESPONDENCIA_ACTUALIZAR";
                objCmd.Transaction = otransaction;
                
                objCmd.Parameters.Clear();
                
                objCmd.Parameters.Add("@SOLICITUD_ID", SqlDbType.UniqueIdentifier).Value = oBE_CORRESPONDENCIA.SOLICITUD_ID;
                objCmd.Parameters.Add("@CORRESPONDENCIA_TIPO_ENVIO", SqlDbType.Int).Value = oBE_CORRESPONDENCIA.TIPO_ENVIO;
                objCmd.Parameters.Add("@CORRESPONDENCIA_TIPO", SqlDbType.Int).Value = oBE_CORRESPONDENCIA.TIPO;
                objCmd.Parameters.Add("@CORRESPONDENCIA_CARACTERISTICA", SqlDbType.Int).Value = oBE_CORRESPONDENCIA.CARACTERISTICA;
                objCmd.Parameters.Add("@CORRESPONDENCIA_PROVEEDOR", SqlDbType.UniqueIdentifier).Value = oBE_CORRESPONDENCIA.PROVEEDOR_ID;
                objCmd.Parameters.Add("@CORRESPONDENCIA_ORDEN_PROVEEDOR", SqlDbType.VarChar).Value = oBE_CORRESPONDENCIA.ORDEN_PROVEEDOR;
                objCmd.Parameters.Add("@CORRESPONDENCIA_FECHA_ENVIO", SqlDbType.Date).Value = Convert.ToDateTime(oBE_CORRESPONDENCIA.FECHA_ENVIO).Date;
                objCmd.Parameters.Add("@CORRESPONDENCIA_REMITENTE", SqlDbType.VarChar).Value = oBE_CORRESPONDENCIA.REMITENTE;
                objCmd.Parameters.Add("@CORRESPONDENCIA_DIRECCION_REMINTENTE", SqlDbType.UniqueIdentifier).Value = oBE_CORRESPONDENCIA.DIRECCION_REMITENTE_ID;
                objCmd.Parameters.Add("@CORRESPONDENCIA_CANTIDAD", SqlDbType.Decimal).Value = oBE_CORRESPONDENCIA.CANTIDAD;
                objCmd.Parameters.Add("@CORRESPONDENCIA_PESO", SqlDbType.Decimal).Value = oBE_CORRESPONDENCIA.PESO;
                objCmd.Parameters.Add("@CORRESPONDENCIA_COSTO", SqlDbType.Decimal).Value = oBE_CORRESPONDENCIA.COSTO;
                objCmd.Parameters.Add("@CORRESPONDENCIA_CONTENIDO", SqlDbType.VarChar).Value = oBE_CORRESPONDENCIA.CONTENIDO;
                objCmd.Parameters.Add("@CORRESPONDENCIA_GUIA", SqlDbType.VarChar).Value = oBE_CORRESPONDENCIA.GUIA;
                objCmd.Parameters.Add("@CORRESPONDENCIA_DESTINATARIO", SqlDbType.VarChar).Value = oBE_CORRESPONDENCIA.DESTINATARIO;
                objCmd.Parameters.Add("@CORRESPONDENCIA_DIRECCION_DESTINATARIO", SqlDbType.UniqueIdentifier).Value = oBE_CORRESPONDENCIA.DIRECCION_DESTINATARIO_ID;
                objCmd.Parameters.Add("@CORRESPONDENCIA_ATENCION", SqlDbType.VarChar).Value = oBE_CORRESPONDENCIA.ATENCION;
                objCmd.Parameters.Add("@CORRESPONDENCIA_MEDIDA", SqlDbType.VarChar).Value = oBE_CORRESPONDENCIA.MEDIDAS;
                objCmd.Parameters.Add("@CORRESPONDENCIA_COSTO_DECLARAR", SqlDbType.Decimal).Value = Convert.ToDecimal(oBE_CORRESPONDENCIA.COSTO_DECLARAR);
                objCmd.Parameters.Add("@CORRESPONDENCIA_TELEFONO", SqlDbType.VarChar).Value = oBE_CORRESPONDENCIA.TELEFONO;
                objCmd.Parameters.Add("@CORRESPONDENCIA_PAIS", SqlDbType.VarChar).Value = oBE_CORRESPONDENCIA.PAIS;
                objCmd.Parameters.Add("@CORRESPONDENCIA_ESTADO_PROVINCIA", SqlDbType.VarChar).Value = oBE_CORRESPONDENCIA.ESTADO_PROVINCIA;
                objCmd.Parameters.Add("@CORRESPONDENCIA_CIUDAD", SqlDbType.VarChar).Value = oBE_CORRESPONDENCIA.CIUDAD;
                objCmd.Parameters.Add("@CORRESPONDENCIA_CODIGO_POSTAL", SqlDbType.VarChar).Value = oBE_CORRESPONDENCIA.CODIGO_POSTAL;
                objCmd.Parameters.Add("@ESTADO", SqlDbType.Int).Value = oBE_CORRESPONDENCIA.ESTADO;
                objCmd.Parameters.Add("@USUARIO", SqlDbType.UniqueIdentifier).Value = oBE_CORRESPONDENCIA.USUARIO_CREACION;
                objCmd.Parameters.Add("@CORRESPONDENCIA_ATENCION_ID", SqlDbType.UniqueIdentifier).Value = oBE_CORRESPONDENCIA.ATENCION_ID;


                bIndicador = objCmd.ExecuteNonQuery() > 0;

                return bIndicador;

            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }


        }

        /// <summary>
        /// Actualizar el estado de una CORRESPONDENCIA
        /// </summary>
        /// <param name="solicitudId">Identificador de la solicitud a actualizar</param>
        /// <param name="estado">Estado a actualizar</param>
        /// <param name="usuario">Usuario Id que desea actualizar la solicitud</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean ActualizarEstadoCorrespondencia(Guid solicitud_id, int estado, Guid usuario, SqlTransaction otransaction, SqlCommand objCmd)
        {
            bool bIndicador = false;

            try
            {

                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "USP_CORRESPONDENCIA_ACTUALIZAR_ESTADO_POR_SOLICITUD";
                objCmd.Transaction = otransaction;

                objCmd.Parameters.Clear();
                objCmd.Parameters.Add("@SOLICITUD_ID", SqlDbType.UniqueIdentifier).Value = solicitud_id;                
                objCmd.Parameters.Add("@ESTADO", SqlDbType.Int).Value = estado;
                objCmd.Parameters.Add("@USUARIO", SqlDbType.UniqueIdentifier).Value = usuario;


                bIndicador = objCmd.ExecuteNonQuery() > 0;

                return bIndicador;

            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }


        }
    }
}
