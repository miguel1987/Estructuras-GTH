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
    /// En esta clase se encuentran todos los metodos para las consultas de la tabla SOLICITUDES
    /// </summary>
    public class DA_SOLICITUD
    {
        /// <summary>
        /// Devuelve un listado de solicitudes
        /// </summary>
        /// <param name="empresaId">Id de la Empresa cuyas solicitudes se desea consultar</param>
        /// <param name="gerenciaId">Id de la Gerencia cuyas solicitudes se desea consultar</param>
        /// <param name="areaId">Id del área cuyas solicitudes se desea consultar</param>
        /// <param name="tipo">Tipo de solicitudes que se desea consultar</param>
        /// <param name="destinatario">Destinatario que se desea consultar</param>
        /// <param name="fechaDesde">Rango de fecha inicial desde el que se desea consultar</param>
        /// <param name="fechaHasta">Rango de fecha final hasta la que se desea consultar</param>
        /// <returns>Listado de BE_SOLICITUD con los datos de una solicitud, que a su vez representan la tabla SOLICITUDES de la base de datos. En caso no existan datos devuelve nothing.</returns>
        public List<BE_SOLICITUD> SeleccionarSolicitudesPorFechas(Guid empresaId, Guid gerenciaId, Guid areaId, int tipo, string destinatario, string fechaDesde, string fechaHasta)
        {

            SqlConnection cnx = new SqlConnection();
            DbDataReader dr;
            cnx = DC_Connection.getConnection();
            List<BE_SOLICITUD> oSOLICITUD = null;

            try
            {
                using (SqlCommand objCmd = new SqlCommand()
                {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_SOLICITUD_SELECCIONAR_POR_FECHAS"
                })
                {
                    objCmd.Parameters.Add("@EMPRESA_ID", SqlDbType.UniqueIdentifier).Value = empresaId;
                    objCmd.Parameters.Add("@GERENCIA_ID", SqlDbType.UniqueIdentifier).Value = gerenciaId;
                    objCmd.Parameters.Add("@AREA_ID", SqlDbType.UniqueIdentifier).Value = areaId;
                    objCmd.Parameters.Add("@TIPO", SqlDbType.Int).Value = tipo;
                    objCmd.Parameters.Add("@DESTINATARIO", SqlDbType.VarChar).Value = destinatario;
                    objCmd.Parameters.Add("@FECHA_DESDE", SqlDbType.Date).Value = Convert.ToDateTime(fechaDesde).Date;
                    objCmd.Parameters.Add("@FECHA_HASTA", SqlDbType.Date).Value = Convert.ToDateTime(fechaHasta).Date;

                    cnx.Open();
                    dr = objCmd.ExecuteReader();

                    // Se crea una variable tipo int por cada posicion de cada campo                    
                    int SOLICITUD_ID = dr.GetOrdinal("SOLICITUD_ID");
                    int SOLICITUD_CODIGO = dr.GetOrdinal("SOLICITUD_CODIGO");
                    int SOLICITUD_FECHA_REGISTRO = dr.GetOrdinal("SOLICITUD_FECHA_REGISTRO");
                    int SOLICITUD_EMPRESA = dr.GetOrdinal("SOLICITUD_EMPRESA");
                    int SOLICITUD_GERENCIA = dr.GetOrdinal("SOLICITUD_GERENCIA");
                    int SOLICITUD_AREA = dr.GetOrdinal("SOLICITUD_AREA");                    
                    int SOLICITUD_TIPO = dr.GetOrdinal("SOLICITUD_TIPO");                    
                    int SOLICITUD_SOLICITANTE = dr.GetOrdinal("SOLICITUD_SOLICITANTE");
                    int USUARIO_CREACION = dr.GetOrdinal("USUARIO_CREACION");
                    int SOLICITUD_ESTADO = dr.GetOrdinal("SOLICITUD_ESTADO");
                    int SOLICITUD_CORRESPONDENCIA_DESTINATARIO = dr.GetOrdinal("SOLICITUD_CORRESPONDENCIA_DESTINATARIO");
                    int SOLICITUD_CORRESPONDENCIA_ORDEN_PROVEEDOR = dr.GetOrdinal("SOLICITUD_CORRESPONDENCIA_ORDEN_PROVEEDOR");

                    // creamos un objeto del tamaño de la tupla en el array de objeto Valores
                    object[] Valores = new object[dr.FieldCount];

                    // Preguntamos si el DbDataReader tiene registros
                    if (dr.HasRows)
                    {
                        // Instancionamos la lista para empezar a setearla
                        oSOLICITUD = new List<BE_SOLICITUD>();
                        while (dr.Read())
                        {
                            // Obetemos los valores para la tupla
                            dr.GetValues(Valores);
                            BE_SOLICITUD oBE_SOLICITUD = new BE_SOLICITUD();
                            
                            oBE_SOLICITUD.ID = (Guid)Valores.GetValue(SOLICITUD_ID);
                            oBE_SOLICITUD.CODIGO = (int)Valores.GetValue(SOLICITUD_CODIGO);
                            oBE_SOLICITUD.FECHA_REGISTRO = Valores.GetValue(SOLICITUD_FECHA_REGISTRO).ToString();
                            oBE_SOLICITUD.EMPRESA_ID = (Guid)Valores.GetValue(SOLICITUD_EMPRESA);
                            oBE_SOLICITUD.GERENCIA_ID = (Guid)Valores.GetValue(SOLICITUD_GERENCIA);
                            oBE_SOLICITUD.AREA_ID = (Guid)Valores.GetValue(SOLICITUD_AREA);                            
                            oBE_SOLICITUD.TIPO = (int)Valores.GetValue(SOLICITUD_TIPO);                            
                            oBE_SOLICITUD.SOLICITANTE = DBNull.Value == Valores.GetValue(SOLICITUD_SOLICITANTE) ? String.Empty : Valores.GetValue(SOLICITUD_SOLICITANTE).ToString();
                            oBE_SOLICITUD.ESTADO = DBNull.Value == Valores.GetValue(SOLICITUD_ESTADO) ? 1 : (int)Valores.GetValue(SOLICITUD_ESTADO);

                            switch (oBE_SOLICITUD.ESTADO)
                            {
                                case 1:
                                    oBE_SOLICITUD.ESTADO_DESCRIPCION = "Pendiente Aprobación";
                                    break;
                                case 2:
                                    oBE_SOLICITUD.ESTADO_DESCRIPCION = BE_SOLICITUD.SOLICITUD_ESTADO.Aprobada.ToString();
                                    break;
                                case 3:
                                    oBE_SOLICITUD.ESTADO_DESCRIPCION = BE_SOLICITUD.SOLICITUD_ESTADO.Rechazada.ToString();
                                    break;
                                case 4:
                                    oBE_SOLICITUD.ESTADO_DESCRIPCION = BE_SOLICITUD.SOLICITUD_ESTADO.Cerrada.ToString();
                                    break;
                            }


                            oBE_SOLICITUD.USUARIO_CREACION = (Guid)Valores.GetValue(USUARIO_CREACION);
                            
                            oBE_SOLICITUD.DESTINATARIO = DBNull.Value == Valores.GetValue(SOLICITUD_CORRESPONDENCIA_DESTINATARIO) ? String.Empty : Valores.GetValue(SOLICITUD_CORRESPONDENCIA_DESTINATARIO).ToString();
                            oBE_SOLICITUD.ORDEN_PROVEEDOR = DBNull.Value == Valores.GetValue(SOLICITUD_CORRESPONDENCIA_ORDEN_PROVEEDOR) ? String.Empty : Valores.GetValue(SOLICITUD_CORRESPONDENCIA_ORDEN_PROVEEDOR).ToString();
                            oSOLICITUD.Add(oBE_SOLICITUD);
                        }
                    }


                }

                return oSOLICITUD;
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
        /// Devuelve un listado de solicitudes
        /// </summary>
        /// <param name="empresaId">Id de la Empresa cuyas solicitudes se desea consultar</param>
        /// <param name="gerenciaId">Id de la Gerencia cuyas solicitudes se desea consultar</param>
        /// <param name="areaId">Id del área cuyas solicitudes se desea consultar</param>
        /// <param name="tipo">Tipo de solicitudes que se desea consultar</param>
        /// <param name="destinatario">Destinatario que se desea consultar</param>
        /// <param name="fechaDesde">Rango de fecha inicial desde el que se desea consultar</param>
        /// <param name="fechaHasta">Rango de fecha final hasta la que se desea consultar</param>
        /// <param name="estadp">Estado de las solicitudes que se desea consultar</param>
        /// <returns>Listado de BE_SOLICITUD con los datos de una solicitud, que a su vez representan la tabla SOLICITUDES de la base de datos. En caso no existan datos devuelve nothing.</returns>
        public List<BE_SOLICITUD> SeleccionarSolicitudesPorFechas(Guid empresaId, Guid gerenciaId, Guid areaId, int tipo, string destinatario, string fechaDesde, string fechaHasta, int estado)
        {

            SqlConnection cnx = new SqlConnection();
            DbDataReader dr;
            cnx = DC_Connection.getConnection();
            List<BE_SOLICITUD> oSOLICITUD = null;

            try
            {
                using (SqlCommand objCmd = new SqlCommand()
                {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_SOLICITUD_SELECCIONAR_POR_FECHAS_ESTADO"
                })
                {
                    objCmd.Parameters.Add("@EMPRESA_ID", SqlDbType.UniqueIdentifier).Value = empresaId;
                    objCmd.Parameters.Add("@GERENCIA_ID", SqlDbType.UniqueIdentifier).Value = gerenciaId;
                    objCmd.Parameters.Add("@AREA_ID", SqlDbType.UniqueIdentifier).Value = areaId;
                    objCmd.Parameters.Add("@TIPO", SqlDbType.Int).Value = tipo;
                    objCmd.Parameters.Add("@DESTINATARIO", SqlDbType.VarChar).Value = destinatario;
                    objCmd.Parameters.Add("@FECHA_DESDE", SqlDbType.Date).Value = Convert.ToDateTime(fechaDesde).Date;
                    objCmd.Parameters.Add("@FECHA_HASTA", SqlDbType.Date).Value = Convert.ToDateTime(fechaHasta).Date;
                    objCmd.Parameters.Add("@ESTADO", SqlDbType.Int).Value = estado;

                    cnx.Open();
                    dr = objCmd.ExecuteReader();

                    // Se crea una variable tipo int por cada posicion de cada campo                    
                    int SOLICITUD_ID = dr.GetOrdinal("SOLICITUD_ID");
                    int SOLICITUD_CODIGO = dr.GetOrdinal("SOLICITUD_CODIGO");
                    int SOLICITUD_FECHA_REGISTRO = dr.GetOrdinal("SOLICITUD_FECHA_REGISTRO");
                    int SOLICITUD_EMPRESA = dr.GetOrdinal("SOLICITUD_EMPRESA");
                    int SOLICITUD_GERENCIA = dr.GetOrdinal("SOLICITUD_GERENCIA");
                    int SOLICITUD_AREA = dr.GetOrdinal("SOLICITUD_AREA");
                    int SOLICITUD_TIPO = dr.GetOrdinal("SOLICITUD_TIPO");
                    int SOLICITUD_SOLICITANTE = dr.GetOrdinal("SOLICITUD_SOLICITANTE");
                    int USUARIO_CREACION = dr.GetOrdinal("USUARIO_CREACION");
                    int SOLICITUD_ESTADO = dr.GetOrdinal("SOLICITUD_ESTADO");
                    int SOLICITUD_CORRESPONDENCIA_DESTINATARIO = dr.GetOrdinal("SOLICITUD_CORRESPONDENCIA_DESTINATARIO");
                    int SOLICITUD_CORRESPONDENCIA_ORDEN_PROVEEDOR = dr.GetOrdinal("SOLICITUD_CORRESPONDENCIA_ORDEN_PROVEEDOR");
                    int SOLICITUD_SOLICITANTE_CORREO = dr.GetOrdinal("SOLICITUD_SOLICITANTE_CORREO");

                    // creamos un objeto del tamaño de la tupla en el array de objeto Valores
                    object[] Valores = new object[dr.FieldCount];

                    // Preguntamos si el DbDataReader tiene registros
                    if (dr.HasRows)
                    {
                        // Instancionamos la lista para empezar a setearla
                        oSOLICITUD = new List<BE_SOLICITUD>();
                        while (dr.Read())
                        {
                            // Obetemos los valores para la tupla
                            dr.GetValues(Valores);
                            BE_SOLICITUD oBE_SOLICITUD = new BE_SOLICITUD();

                            oBE_SOLICITUD.ID = (Guid)Valores.GetValue(SOLICITUD_ID);
                            oBE_SOLICITUD.CODIGO = (int)Valores.GetValue(SOLICITUD_CODIGO);
                            oBE_SOLICITUD.FECHA_REGISTRO = Valores.GetValue(SOLICITUD_FECHA_REGISTRO).ToString();
                            oBE_SOLICITUD.EMPRESA_ID = (Guid)Valores.GetValue(SOLICITUD_EMPRESA);
                            oBE_SOLICITUD.GERENCIA_ID = (Guid)Valores.GetValue(SOLICITUD_GERENCIA);
                            oBE_SOLICITUD.AREA_ID = (Guid)Valores.GetValue(SOLICITUD_AREA);
                            oBE_SOLICITUD.TIPO = (int)Valores.GetValue(SOLICITUD_TIPO);
                            oBE_SOLICITUD.SOLICITANTE = DBNull.Value == Valores.GetValue(SOLICITUD_SOLICITANTE) ? String.Empty : Valores.GetValue(SOLICITUD_SOLICITANTE).ToString();
                            oBE_SOLICITUD.ESTADO = DBNull.Value == Valores.GetValue(SOLICITUD_ESTADO) ? 1 : (int)Valores.GetValue(SOLICITUD_ESTADO);

                            switch (oBE_SOLICITUD.ESTADO)
                            {
                                case 1:
                                    oBE_SOLICITUD.ESTADO_DESCRIPCION = "Pendiente Aprobación";
                                    break;
                                case 2:
                                    oBE_SOLICITUD.ESTADO_DESCRIPCION = BE_SOLICITUD.SOLICITUD_ESTADO.Aprobada.ToString();
                                    break;
                                case 3:
                                    oBE_SOLICITUD.ESTADO_DESCRIPCION = BE_SOLICITUD.SOLICITUD_ESTADO.Rechazada.ToString();
                                    break;
                                case 4:
                                    oBE_SOLICITUD.ESTADO_DESCRIPCION = BE_SOLICITUD.SOLICITUD_ESTADO.Cerrada.ToString();
                                    break;
                            }


                            oBE_SOLICITUD.USUARIO_CREACION = (Guid)Valores.GetValue(USUARIO_CREACION);

                            oBE_SOLICITUD.DESTINATARIO = DBNull.Value == Valores.GetValue(SOLICITUD_CORRESPONDENCIA_DESTINATARIO) ? String.Empty : Valores.GetValue(SOLICITUD_CORRESPONDENCIA_DESTINATARIO).ToString();
                            oBE_SOLICITUD.ORDEN_PROVEEDOR = DBNull.Value == Valores.GetValue(SOLICITUD_CORRESPONDENCIA_ORDEN_PROVEEDOR) ? String.Empty : Valores.GetValue(SOLICITUD_CORRESPONDENCIA_ORDEN_PROVEEDOR).ToString();
                            oBE_SOLICITUD.SOLICITANTE_CORREO = DBNull.Value == Valores.GetValue(SOLICITUD_SOLICITANTE_CORREO) ? String.Empty : Valores.GetValue(SOLICITUD_SOLICITANTE_CORREO).ToString();
                            oSOLICITUD.Add(oBE_SOLICITUD);
                        }
                    }


                }

                return oSOLICITUD;
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
        /// Devuelve un listado de todas solicitudes
        /// </summary>        
        /// <returns>Listado de BE_SOLICITUD con los datos de una solicitud, que a su vez representan la tabla SOLICITUDES de la base de datos. En caso no existan datos devuelve nothing.</returns>
        public List<BE_SOLICITUD> SeleccionarSolicitudes()
        {

            SqlConnection cnx = new SqlConnection();
            DbDataReader dr;
            cnx = DC_Connection.getConnection();
            List<BE_SOLICITUD> oSOLICITUD = null;

            try
            {
                using (SqlCommand objCmd = new SqlCommand()
                {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_SOLICITUD_SELECCIONAR"
                })
                {                    

                    cnx.Open();
                    dr = objCmd.ExecuteReader();

                    // Se crea una variable tipo int por cada posicion de cada campo                    
                    int SOLICITUD_ID = dr.GetOrdinal("SOLICITUD_ID");
                    int SOLICITUD_CODIGO = dr.GetOrdinal("SOLICITUD_CODIGO");
                    int SOLICITUD_FECHA_REGISTRO = dr.GetOrdinal("SOLICITUD_FECHA_REGISTRO");
                    int SOLICITUD_EMPRESA = dr.GetOrdinal("SOLICITUD_EMPRESA");
                    int SOLICITUD_GERENCIA = dr.GetOrdinal("SOLICITUD_GERENCIA");
                    int SOLICITUD_AREA = dr.GetOrdinal("SOLICITUD_AREA");
                    int SOLICITUD_TIPO = dr.GetOrdinal("SOLICITUD_TIPO");
                    int SOLICITUD_SOLICITANTE = dr.GetOrdinal("SOLICITUD_SOLICITANTE");
                    int USUARIO_CREACION = dr.GetOrdinal("USUARIO_CREACION");
                    int SOLICITUD_ESTADO = dr.GetOrdinal("SOLICITUD_ESTADO");
                    int SOLICITUD_CORRESPONDENCIA_DESTINATARIO = dr.GetOrdinal("SOLICITUD_CORRESPONDENCIA_DESTINATARIO");
                    int SOLICITUD_CORRESPONDENCIA_ORDEN_PROVEEDOR = dr.GetOrdinal("SOLICITUD_CORRESPONDENCIA_ORDEN_PROVEEDOR");

                    // creamos un objeto del tamaño de la tupla en el array de objeto Valores
                    object[] Valores = new object[dr.FieldCount];

                    // Preguntamos si el DbDataReader tiene registros
                    if (dr.HasRows)
                    {
                        // Instancionamos la lista para empezar a setearla
                        oSOLICITUD = new List<BE_SOLICITUD>();
                        while (dr.Read())
                        {
                            // Obetemos los valores para la tupla
                            dr.GetValues(Valores);
                            BE_SOLICITUD oBE_SOLICITUD = new BE_SOLICITUD();                            
                            oBE_SOLICITUD.ID = (Guid)Valores.GetValue(SOLICITUD_ID);
                            oBE_SOLICITUD.CODIGO = (int)Valores.GetValue(SOLICITUD_CODIGO);
                            oBE_SOLICITUD.FECHA_REGISTRO = Valores.GetValue(SOLICITUD_FECHA_REGISTRO).ToString();
                            oBE_SOLICITUD.EMPRESA_ID = (Guid)Valores.GetValue(SOLICITUD_EMPRESA);
                            oBE_SOLICITUD.GERENCIA_ID = (Guid)Valores.GetValue(SOLICITUD_GERENCIA);
                            oBE_SOLICITUD.AREA_ID = (Guid)Valores.GetValue(SOLICITUD_AREA);
                            oBE_SOLICITUD.TIPO = (int)Valores.GetValue(SOLICITUD_TIPO);
                            oBE_SOLICITUD.SOLICITANTE = DBNull.Value == Valores.GetValue(SOLICITUD_SOLICITANTE) ? String.Empty : Valores.GetValue(SOLICITUD_SOLICITANTE).ToString();
                            oBE_SOLICITUD.USUARIO_CREACION = (Guid)Valores.GetValue(USUARIO_CREACION);
                            oBE_SOLICITUD.ESTADO = DBNull.Value == Valores.GetValue(SOLICITUD_ESTADO) ? 1 : (int)Valores.GetValue(SOLICITUD_ESTADO);
                            
                            switch (oBE_SOLICITUD.ESTADO)
                            {
                                case 1:
                                    oBE_SOLICITUD.ESTADO_DESCRIPCION = "Pendiente Aprobación";
                                    break;
                                case 2:
                                    oBE_SOLICITUD.ESTADO_DESCRIPCION = BE_SOLICITUD.SOLICITUD_ESTADO.Aprobada.ToString();
                                    break;
                                case 3:
                                    oBE_SOLICITUD.ESTADO_DESCRIPCION = BE_SOLICITUD.SOLICITUD_ESTADO.Rechazada.ToString();
                                    break;
                                case 4:
                                    oBE_SOLICITUD.ESTADO_DESCRIPCION = BE_SOLICITUD.SOLICITUD_ESTADO.Cerrada.ToString();
                                    break;
                            }

                            oBE_SOLICITUD.DESTINATARIO = DBNull.Value == Valores.GetValue(SOLICITUD_CORRESPONDENCIA_DESTINATARIO) ? String.Empty : Valores.GetValue(SOLICITUD_CORRESPONDENCIA_DESTINATARIO).ToString();
                            oBE_SOLICITUD.ORDEN_PROVEEDOR = DBNull.Value == Valores.GetValue(SOLICITUD_CORRESPONDENCIA_ORDEN_PROVEEDOR) ? String.Empty : Valores.GetValue(SOLICITUD_CORRESPONDENCIA_ORDEN_PROVEEDOR).ToString();
                            oSOLICITUD.Add(oBE_SOLICITUD);
                        }
                    }


                }

                return oSOLICITUD;
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
        /// Devuelve un listado de solicitudes
        /// </summary>
        /// <param name="empresaId">Id de la Empresa cuyas solicitudes se desea consultar</param>
        /// <param name="gerenciaId">Id de la Gerencia cuyas solicitudes se desea consultar</param>
        /// <param name="areaId">Id del área cuyas solicitudes se desea consultar</param>
        /// <param name="tipo">Tipo de solicitudes que se desea consultar</param>
        /// <param name="destinatario">Destinatario que se desea consultar</param>
        /// <param name="fechaDesde">Rango de fecha inicial desde el que se desea consultar</param>
        /// <param name="fechaHasta">Rango de fecha final hasta la que se desea consultar</param>
        /// <param name="usuarioId">Id del usuario cuyas solicitudes se desea consultar</param>
        /// <returns>Listado de BE_SOLICITUD con los datos de una solicitud, que a su vez representan la tabla SOLICITUDES de la base de datos. En caso no existan datos devuelve nothing.</returns>
        public List<BE_SOLICITUD> SeleccionarSolicitudesPorFechas(Guid empresaId, Guid gerenciaId, Guid areaId, int tipo, string destinatario, string fechaDesde, string fechaHasta, Guid usuarioId)
        {

            SqlConnection cnx = new SqlConnection();
            DbDataReader dr;
            cnx = DC_Connection.getConnection();
            List<BE_SOLICITUD> oSOLICITUD = null;

            try
            {
                using (SqlCommand objCmd = new SqlCommand()
                {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_SOLICITUD_SELECCIONAR_POR_FECHAS_USUARIO"
                })
                {
                    objCmd.Parameters.Add("@EMPRESA_ID", SqlDbType.UniqueIdentifier).Value = empresaId;
                    objCmd.Parameters.Add("@GERENCIA_ID", SqlDbType.UniqueIdentifier).Value = gerenciaId;
                    objCmd.Parameters.Add("@AREA_ID", SqlDbType.UniqueIdentifier).Value = areaId;
                    objCmd.Parameters.Add("@TIPO", SqlDbType.Int).Value = tipo;
                    objCmd.Parameters.Add("@DESTINATARIO", SqlDbType.VarChar).Value = destinatario;
                    objCmd.Parameters.Add("@FECHA_DESDE", SqlDbType.Date).Value = Convert.ToDateTime(fechaDesde).Date;
                    objCmd.Parameters.Add("@FECHA_HASTA", SqlDbType.Date).Value = Convert.ToDateTime(fechaHasta).Date;
                    objCmd.Parameters.Add("@USUARIO_ID", SqlDbType.UniqueIdentifier).Value = usuarioId;

                    cnx.Open();
                    dr = objCmd.ExecuteReader();

                    // Se crea una variable tipo int por cada posicion de cada campo                    
                    int SOLICITUD_ID = dr.GetOrdinal("SOLICITUD_ID");
                    int SOLICITUD_CODIGO = dr.GetOrdinal("SOLICITUD_CODIGO");
                    int SOLICITUD_FECHA_REGISTRO = dr.GetOrdinal("SOLICITUD_FECHA_REGISTRO");
                    int SOLICITUD_EMPRESA = dr.GetOrdinal("SOLICITUD_EMPRESA");
                    int SOLICITUD_GERENCIA = dr.GetOrdinal("SOLICITUD_GERENCIA");
                    int SOLICITUD_AREA = dr.GetOrdinal("SOLICITUD_AREA");
                    int SOLICITUD_TIPO = dr.GetOrdinal("SOLICITUD_TIPO");
                    int SOLICITUD_SOLICITANTE = dr.GetOrdinal("SOLICITUD_SOLICITANTE");
                    int USUARIO_CREACION = dr.GetOrdinal("USUARIO_CREACION");
                    int SOLICITUD_ESTADO = dr.GetOrdinal("SOLICITUD_ESTADO");
                    int SOLICITUD_CORRESPONDENCIA_DESTINATARIO = dr.GetOrdinal("SOLICITUD_CORRESPONDENCIA_DESTINATARIO");
                    int SOLICITUD_CORRESPONDENCIA_ORDEN_PROVEEDOR = dr.GetOrdinal("SOLICITUD_CORRESPONDENCIA_ORDEN_PROVEEDOR");

                    // creamos un objeto del tamaño de la tupla en el array de objeto Valores
                    object[] Valores = new object[dr.FieldCount];

                    // Preguntamos si el DbDataReader tiene registros
                    if (dr.HasRows)
                    {
                        // Instancionamos la lista para empezar a setearla
                        oSOLICITUD = new List<BE_SOLICITUD>();
                        while (dr.Read())
                        {
                            // Obetemos los valores para la tupla
                            dr.GetValues(Valores);
                            BE_SOLICITUD oBE_SOLICITUD = new BE_SOLICITUD();                            
                            oBE_SOLICITUD.ID = (Guid)Valores.GetValue(SOLICITUD_ID);
                            oBE_SOLICITUD.CODIGO = (int)Valores.GetValue(SOLICITUD_CODIGO);
                            oBE_SOLICITUD.FECHA_REGISTRO = Valores.GetValue(SOLICITUD_FECHA_REGISTRO).ToString();
                            oBE_SOLICITUD.EMPRESA_ID = (Guid)Valores.GetValue(SOLICITUD_EMPRESA);
                            oBE_SOLICITUD.GERENCIA_ID = (Guid)Valores.GetValue(SOLICITUD_GERENCIA);
                            oBE_SOLICITUD.AREA_ID = (Guid)Valores.GetValue(SOLICITUD_AREA);
                            oBE_SOLICITUD.TIPO = (int)Valores.GetValue(SOLICITUD_TIPO);
                            oBE_SOLICITUD.SOLICITANTE = DBNull.Value == Valores.GetValue(SOLICITUD_SOLICITANTE) ? String.Empty : Valores.GetValue(SOLICITUD_SOLICITANTE).ToString();
                            oBE_SOLICITUD.ESTADO = DBNull.Value == Valores.GetValue(SOLICITUD_ESTADO) ? 1 : (int)Valores.GetValue(SOLICITUD_ESTADO);
                            
                            switch (oBE_SOLICITUD.ESTADO)
                            {
                                case 1:
                                    oBE_SOLICITUD.ESTADO_DESCRIPCION = "Pendiente Aprobación";
                                    break;
                                case 2:
                                    oBE_SOLICITUD.ESTADO_DESCRIPCION = BE_SOLICITUD.SOLICITUD_ESTADO.Aprobada.ToString();
                                    break;
                                case 3:
                                    oBE_SOLICITUD.ESTADO_DESCRIPCION = BE_SOLICITUD.SOLICITUD_ESTADO.Rechazada.ToString();
                                    break;
                                case 4:
                                    oBE_SOLICITUD.ESTADO_DESCRIPCION = BE_SOLICITUD.SOLICITUD_ESTADO.Cerrada.ToString();
                                    break;
                            }

                            oBE_SOLICITUD.USUARIO_CREACION = (Guid)Valores.GetValue(USUARIO_CREACION);                            
                            oBE_SOLICITUD.DESTINATARIO = DBNull.Value == Valores.GetValue(SOLICITUD_CORRESPONDENCIA_DESTINATARIO) ? String.Empty : Valores.GetValue(SOLICITUD_CORRESPONDENCIA_DESTINATARIO).ToString();
                            oBE_SOLICITUD.ORDEN_PROVEEDOR = DBNull.Value == Valores.GetValue(SOLICITUD_CORRESPONDENCIA_ORDEN_PROVEEDOR) ? String.Empty : Valores.GetValue(SOLICITUD_CORRESPONDENCIA_ORDEN_PROVEEDOR).ToString();
                            oSOLICITUD.Add(oBE_SOLICITUD);
                        }
                    }


                }

                return oSOLICITUD;
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
        /// Devuelve un listado de solicitudes
        /// </summary>
        /// <param name="empresaId">Id de la Empresa cuyas solicitudes se desea consultar</param>
        /// <param name="gerenciaId">Id de la Gerencia cuyas solicitudes se desea consultar</param>
        /// <param name="areaId">Id del área cuyas solicitudes se desea consultar</param>
        /// <param name="tipo">Tipo de solicitudes que se desea consultar</param>
        /// <param name="destinatario">Destinatario que se desea consultar</param>
        /// <param name="fechaDesde">Rango de fecha inicial desde el que se desea consultar</param>
        /// <param name="fechaHasta">Rango de fecha final hasta la que se desea consultar</param>
        /// <param name="estado">Estado de las solicitudes que se desea consultar</param>
        /// <param name="usuarioId">Id del usuario cuyas solicitudes se desea consultar</param>
        /// <returns>Listado de BE_SOLICITUD con los datos de una solicitud, que a su vez representan la tabla SOLICITUDES de la base de datos. En caso no existan datos devuelve nothing.</returns>
        public List<BE_SOLICITUD> SeleccionarSolicitudesPorFechas(Guid empresaId, Guid gerenciaId, Guid areaId, int tipo, string destinatario, string fechaDesde, string fechaHasta, int estado, Guid usuarioId)
        {

            SqlConnection cnx = new SqlConnection();
            DbDataReader dr;
            cnx = DC_Connection.getConnection();
            List<BE_SOLICITUD> oSOLICITUD = null;

            try
            {
                using (SqlCommand objCmd = new SqlCommand()
                {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_SOLICITUD_SELECCIONAR_POR_FECHAS_ESTADO_USUARIO"
                })
                {
                    objCmd.Parameters.Add("@EMPRESA_ID", SqlDbType.UniqueIdentifier).Value = empresaId;
                    objCmd.Parameters.Add("@GERENCIA_ID", SqlDbType.UniqueIdentifier).Value = gerenciaId;
                    objCmd.Parameters.Add("@AREA_ID", SqlDbType.UniqueIdentifier).Value = areaId;
                    objCmd.Parameters.Add("@TIPO", SqlDbType.Int).Value = tipo;
                    objCmd.Parameters.Add("@DESTINATARIO", SqlDbType.VarChar).Value = destinatario;
                    objCmd.Parameters.Add("@FECHA_DESDE", SqlDbType.Date).Value = Convert.ToDateTime(fechaDesde).Date;
                    objCmd.Parameters.Add("@FECHA_HASTA", SqlDbType.Date).Value = Convert.ToDateTime(fechaHasta).Date;
                    objCmd.Parameters.Add("@ESTADO", SqlDbType.Int).Value = estado;
                    objCmd.Parameters.Add("@USUARIO_ID", SqlDbType.UniqueIdentifier).Value = usuarioId;

                    cnx.Open();
                    dr = objCmd.ExecuteReader();

                    // Se crea una variable tipo int por cada posicion de cada campo                    
                    int SOLICITUD_ID = dr.GetOrdinal("SOLICITUD_ID");
                    int SOLICITUD_CODIGO = dr.GetOrdinal("SOLICITUD_CODIGO");
                    int SOLICITUD_FECHA_REGISTRO = dr.GetOrdinal("SOLICITUD_FECHA_REGISTRO");
                    int SOLICITUD_EMPRESA = dr.GetOrdinal("SOLICITUD_EMPRESA");
                    int SOLICITUD_GERENCIA = dr.GetOrdinal("SOLICITUD_GERENCIA");
                    int SOLICITUD_AREA = dr.GetOrdinal("SOLICITUD_AREA");
                    int SOLICITUD_TIPO = dr.GetOrdinal("SOLICITUD_TIPO");
                    int SOLICITUD_SOLICITANTE = dr.GetOrdinal("SOLICITUD_SOLICITANTE");
                    int USUARIO_CREACION = dr.GetOrdinal("USUARIO_CREACION");
                    int SOLICITUD_ESTADO = dr.GetOrdinal("SOLICITUD_ESTADO");
                    int SOLICITUD_CORRESPONDENCIA_DESTINATARIO = dr.GetOrdinal("SOLICITUD_CORRESPONDENCIA_DESTINATARIO");
                    int SOLICITUD_CORRESPONDENCIA_ORDEN_PROVEEDOR = dr.GetOrdinal("SOLICITUD_CORRESPONDENCIA_ORDEN_PROVEEDOR");

                    // creamos un objeto del tamaño de la tupla en el array de objeto Valores
                    object[] Valores = new object[dr.FieldCount];

                    // Preguntamos si el DbDataReader tiene registros
                    if (dr.HasRows)
                    {
                        // Instancionamos la lista para empezar a setearla
                        oSOLICITUD = new List<BE_SOLICITUD>();
                        while (dr.Read())
                        {
                            // Obetemos los valores para la tupla
                            dr.GetValues(Valores);
                            BE_SOLICITUD oBE_SOLICITUD = new BE_SOLICITUD();
                            oBE_SOLICITUD.ID = (Guid)Valores.GetValue(SOLICITUD_ID);
                            oBE_SOLICITUD.CODIGO = (int)Valores.GetValue(SOLICITUD_CODIGO);
                            oBE_SOLICITUD.FECHA_REGISTRO = Valores.GetValue(SOLICITUD_FECHA_REGISTRO).ToString();
                            oBE_SOLICITUD.EMPRESA_ID = (Guid)Valores.GetValue(SOLICITUD_EMPRESA);
                            oBE_SOLICITUD.GERENCIA_ID = (Guid)Valores.GetValue(SOLICITUD_GERENCIA);
                            oBE_SOLICITUD.AREA_ID = (Guid)Valores.GetValue(SOLICITUD_AREA);
                            oBE_SOLICITUD.TIPO = (int)Valores.GetValue(SOLICITUD_TIPO);
                            oBE_SOLICITUD.SOLICITANTE = DBNull.Value == Valores.GetValue(SOLICITUD_SOLICITANTE) ? String.Empty : Valores.GetValue(SOLICITUD_SOLICITANTE).ToString();
                            oBE_SOLICITUD.ESTADO = DBNull.Value == Valores.GetValue(SOLICITUD_ESTADO) ? 1 : (int)Valores.GetValue(SOLICITUD_ESTADO);

                            switch (oBE_SOLICITUD.ESTADO)
                            {
                                case 1:
                                    oBE_SOLICITUD.ESTADO_DESCRIPCION = "Pendiente Aprobación";
                                    break;
                                case 2:
                                    oBE_SOLICITUD.ESTADO_DESCRIPCION = BE_SOLICITUD.SOLICITUD_ESTADO.Aprobada.ToString();
                                    break;
                                case 3:
                                    oBE_SOLICITUD.ESTADO_DESCRIPCION = BE_SOLICITUD.SOLICITUD_ESTADO.Rechazada.ToString();
                                    break;
                                case 4:
                                    oBE_SOLICITUD.ESTADO_DESCRIPCION = BE_SOLICITUD.SOLICITUD_ESTADO.Cerrada.ToString();
                                    break;
                            }

                            oBE_SOLICITUD.USUARIO_CREACION = (Guid)Valores.GetValue(USUARIO_CREACION);
                            oBE_SOLICITUD.DESTINATARIO = DBNull.Value == Valores.GetValue(SOLICITUD_CORRESPONDENCIA_DESTINATARIO) ? String.Empty : Valores.GetValue(SOLICITUD_CORRESPONDENCIA_DESTINATARIO).ToString();
                            oBE_SOLICITUD.ORDEN_PROVEEDOR = DBNull.Value == Valores.GetValue(SOLICITUD_CORRESPONDENCIA_ORDEN_PROVEEDOR) ? String.Empty : Valores.GetValue(SOLICITUD_CORRESPONDENCIA_ORDEN_PROVEEDOR).ToString();
                            oSOLICITUD.Add(oBE_SOLICITUD);
                        }
                    }


                }

                return oSOLICITUD;
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
        /// <param name="solicitudId">Id de la Solicitud que se desea consultar</param>
        /// <returns>Objeto BE_SOLICITUD con los datos de una solicitud, que a su vez representan la tabla SOLICITUDES de la base de datos. En caso no existan datos devuelve nothing.</returns>
        public BE_SOLICITUD SeleccionarSolicitudPorId(Guid solicitudId)
        {

            SqlConnection cnx = new SqlConnection();
            DbDataReader dr;
            cnx = DC_Connection.getConnection();
            BE_SOLICITUD oBE_SOLICITUD = null;

            try
            {
                using (SqlCommand objCmd = new SqlCommand()
                {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_SOLICITUD_SELECCIONAR_POR_ID"
                })
                {

                    objCmd.Parameters.Add("@SOLICITUD_ID", SqlDbType.UniqueIdentifier).Value = solicitudId;

                    cnx.Open();
                    dr = objCmd.ExecuteReader();

                    // Se crea una variable tipo int por cada posicion de cada campo                    
                    int SOLICITUD_ID = dr.GetOrdinal("SOLICITUD_ID");
                    int SOLICITUD_CODIGO = dr.GetOrdinal("SOLICITUD_CODIGO");
                    int SOLICITUD_FECHA_REGISTRO = dr.GetOrdinal("SOLICITUD_FECHA_REGISTRO");
                    int SOLICITUD_EMPRESA = dr.GetOrdinal("SOLICITUD_EMPRESA");
                    int SOLICITUD_GERENCIA = dr.GetOrdinal("SOLICITUD_GERENCIA");
                    int SOLICITUD_AREA = dr.GetOrdinal("SOLICITUD_AREA");
                    int SOLICITUD_PRIORIDAD = dr.GetOrdinal("SOLICITUD_PRIORIDAD");
                    int SOLICITUD_TIPO = dr.GetOrdinal("SOLICITUD_TIPO");
                    int SOLICITUD_CENTRO_COSTO = dr.GetOrdinal("SOLICITUD_CENTRO_COSTO");
                    int SOLICITUD_ORDEN = dr.GetOrdinal("SOLICITUD_ORDEN");
                    int SOLICITUD_CENTRO_GESTOR = dr.GetOrdinal("SOLICITUD_CENTRO_GESTOR");
                    int SOLICITUD_CUENTA_MAYOR = dr.GetOrdinal("SOLICITUD_CUENTA_MAYOR");
                    int SOLICITUD_AUTORIZADOR = dr.GetOrdinal("SOLICITUD_AUTORIZADOR");
                    int SOLICITUD_REQUIERE_APROBACION = dr.GetOrdinal("SOLICITUD_REQUIERE_APROBACION");
                    int SOLICITUD_SOLICITANTE = dr.GetOrdinal("SOLICITUD_SOLICITANTE");                   
                    int USUARIO_CREACION = dr.GetOrdinal("USUARIO_CREACION");
                    int SOLICITUD_ESTADO = dr.GetOrdinal("SOLICITUD_ESTADO");

                    // creamos un objeto del tamaño de la tupla en el array de objeto Valores
                    object[] Valores = new object[dr.FieldCount];

                    // Preguntamos si el DbDataReader tiene registros
                    if (dr.HasRows)
                    {

                        if (dr.Read())
                        {
                            // Obetemos los valores para la tupla
                            dr.GetValues(Valores);
                            oBE_SOLICITUD = new BE_SOLICITUD();
                            oBE_SOLICITUD.ID = (Guid)Valores.GetValue(SOLICITUD_ID);
                            oBE_SOLICITUD.CODIGO = (int)Valores.GetValue(SOLICITUD_CODIGO);
                            oBE_SOLICITUD.FECHA_REGISTRO = Valores.GetValue(SOLICITUD_FECHA_REGISTRO).ToString();
                            oBE_SOLICITUD.EMPRESA_ID = (Guid)Valores.GetValue(SOLICITUD_EMPRESA);
                            oBE_SOLICITUD.GERENCIA_ID = (Guid)Valores.GetValue(SOLICITUD_GERENCIA);
                            oBE_SOLICITUD.AREA_ID = (Guid)Valores.GetValue(SOLICITUD_AREA);
                            oBE_SOLICITUD.PRIORIDAD = (int)Valores.GetValue(SOLICITUD_PRIORIDAD);
                            oBE_SOLICITUD.TIPO = (int)Valores.GetValue(SOLICITUD_TIPO);
                            oBE_SOLICITUD.CENTRO_COSTO_ID = DBNull.Value == Valores.GetValue(SOLICITUD_CENTRO_COSTO) ? Guid.Empty : (Guid)Valores.GetValue(SOLICITUD_CENTRO_COSTO);
                            oBE_SOLICITUD.ORDEN_ID = DBNull.Value == Valores.GetValue(SOLICITUD_ORDEN) ? Guid.Empty : (Guid)Valores.GetValue(SOLICITUD_ORDEN);
                            oBE_SOLICITUD.CENTRO_GESTOR_ID = (Guid)Valores.GetValue(SOLICITUD_CENTRO_GESTOR);
                            oBE_SOLICITUD.CUENTA_MAYOR_ID = (Guid)Valores.GetValue(SOLICITUD_CUENTA_MAYOR);
                            oBE_SOLICITUD.AUTORIZADOR = (Guid)Valores.GetValue(SOLICITUD_AUTORIZADOR);
                            oBE_SOLICITUD.REQUIERE_APROBACION = DBNull.Value == Valores.GetValue(SOLICITUD_REQUIERE_APROBACION) ? 1 : (int)Valores.GetValue(SOLICITUD_REQUIERE_APROBACION);
                            oBE_SOLICITUD.SOLICITANTE = DBNull.Value == Valores.GetValue(SOLICITUD_SOLICITANTE) ? String.Empty : Valores.GetValue(SOLICITUD_SOLICITANTE).ToString();
                            oBE_SOLICITUD.ESTADO = DBNull.Value == Valores.GetValue(SOLICITUD_ESTADO) ? 1 : (int)Valores.GetValue(SOLICITUD_ESTADO);
                            oBE_SOLICITUD.USUARIO_CREACION = (Guid)Valores.GetValue(USUARIO_CREACION);

                        }
                    }


                }

                oBE_SOLICITUD.oBE_CORRESPONDENCIA = new DA_CORRESPONDENCIA().SeleccionarCorrespondenciaPorSolicitud(solicitudId);

                return oBE_SOLICITUD;
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
        /// Inserta los datos de la solicitud
        /// </summary>
        /// <param name="oBE_SOLICITUD">Entidad BE_SOLICITUD, que representa la tabla SOLICITUDES, con todos sus atributos </param>
        /// <returns>Guid. Guid, si se ingreso con exito. Null, si hubo un error al ingresar</returns>
        public Guid InsertarSolicitud(BE_SOLICITUD oBE_SOLICITUD)
        {
            SqlConnection cnx = new SqlConnection();
            int FilasAfectadas = 0;
            SqlTransaction oTransaction = null;
            cnx = DC_Connection.getConnection();
            Guid solicitud_id = Guid.Empty;

            try
            {

                using (
                    SqlCommand objCmd = new SqlCommand()
                    {
                        Connection = cnx,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "USP_SOLICITUD_INSERTAR"
                    }
                    )
                {
                    //Se crea el objeto Parameters por cada parametro                   
                    
                    objCmd.Parameters.Add("@SOLICITUD_FECHA_REGISTRO", SqlDbType.Date).Value = Convert.ToDateTime(oBE_SOLICITUD.FECHA_REGISTRO).Date;
                    objCmd.Parameters.Add("@EMPRESA_ID", SqlDbType.UniqueIdentifier).Value = oBE_SOLICITUD.EMPRESA_ID;
                    objCmd.Parameters.Add("@GERENCIA_ID", SqlDbType.UniqueIdentifier).Value = oBE_SOLICITUD.GERENCIA_ID;
                    objCmd.Parameters.Add("@AREA_ID", SqlDbType.UniqueIdentifier).Value = oBE_SOLICITUD.AREA_ID;
                    objCmd.Parameters.Add("@SOLICITUD_PRIORIDAD", SqlDbType.Int).Value = oBE_SOLICITUD.PRIORIDAD;
                    objCmd.Parameters.Add("@SOLICITUD_TIPO", SqlDbType.Int).Value = oBE_SOLICITUD.TIPO;
                    objCmd.Parameters.Add("@CENTRO_COSTO_ID", SqlDbType.UniqueIdentifier).Value = oBE_SOLICITUD.CENTRO_COSTO_ID;
                    objCmd.Parameters.Add("@ORDEN_ID", SqlDbType.UniqueIdentifier).Value = oBE_SOLICITUD.ORDEN_ID;
                    objCmd.Parameters.Add("@CENTRO_GESTOR_ID", SqlDbType.UniqueIdentifier).Value = oBE_SOLICITUD.CENTRO_GESTOR_ID;
                    objCmd.Parameters.Add("@CUENTA_MAYOR_ID", SqlDbType.UniqueIdentifier).Value = oBE_SOLICITUD.CUENTA_MAYOR_ID;
                    objCmd.Parameters.Add("@SOLICITUD_AUTORIZADOR", SqlDbType.UniqueIdentifier).Value = oBE_SOLICITUD.AUTORIZADOR;
                    objCmd.Parameters.Add("@SOLICITUD_REQUIERE_APROBACION", SqlDbType.Int).Value = oBE_SOLICITUD.REQUIERE_APROBACION;
                    objCmd.Parameters.Add("@SOLICITUD_SOLICITANTE", SqlDbType.VarChar).Value = oBE_SOLICITUD.SOLICITANTE;
                    objCmd.Parameters.Add("@ESTADO", SqlDbType.Int).Value = oBE_SOLICITUD.ESTADO;
                    objCmd.Parameters.Add("@USUARIO", SqlDbType.UniqueIdentifier).Value = oBE_SOLICITUD.USUARIO_CREACION;
                    

                    cnx.Open();

                    oTransaction = cnx.BeginTransaction();
                    objCmd.Transaction = oTransaction;

                    solicitud_id = (Guid)objCmd.ExecuteScalar();

                    DA_CORRESPONDENCIA oDA_CORRESPONDENCIA = new DA_CORRESPONDENCIA();
                    if (oDA_CORRESPONDENCIA.InsertarCorrespondencia(oBE_SOLICITUD.oBE_CORRESPONDENCIA, solicitud_id, oTransaction, objCmd))
                        FilasAfectadas += 1;                    

                    if (FilasAfectadas > 0)
                    {
                        oTransaction.Commit();                       

                    }
                    else
                    {
                        oTransaction.Rollback();
                        solicitud_id = Guid.Empty;
                    }


                }                

            }
            catch (Exception ex)
            {
                solicitud_id = Guid.Empty;
                oTransaction.Rollback();
                
                throw new Exception("Error: " + ex.Message);                

            }
            finally
            {
                cnx.Close();
            }
            return solicitud_id;
        }

        /// <summary>
        /// Actualizar los datos de la solicitud
        /// </summary>
        /// <param name="oBE_SOLICITUD">Entidad BE_SOLICITUD, que representa la tabla SOLICITUDES, con todos sus atributos </param>
        /// <returns>Guid. Guid, si se ingreso con exito. Null, si hubo un error al ingresar</returns>
        public bool ActualizarSolicitud(BE_SOLICITUD oBE_SOLICITUD)
        {
            SqlConnection cnx = new SqlConnection();
            int FilasAfectadas = 0;
            SqlTransaction oTransaction = null;
            cnx = DC_Connection.getConnection();
            Guid solicitud_id = Guid.Empty;
            bool bSolicitud = false;

            try
            {

                using (
                    SqlCommand objCmd = new SqlCommand()
                    {
                        Connection = cnx,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "USP_SOLICITUD_ACTUALIZAR"
                    }
                    )
                {
                    //Se crea el objeto Parameters por cada parametro

                    objCmd.Parameters.Add("@SOLICITUD_ID", SqlDbType.UniqueIdentifier).Value = oBE_SOLICITUD.ID;                    
                    objCmd.Parameters.Add("@SOLICITUD_FECHA_REGISTRO", SqlDbType.Date).Value = Convert.ToDateTime(oBE_SOLICITUD.FECHA_REGISTRO).Date;
                    objCmd.Parameters.Add("@EMPRESA_ID", SqlDbType.UniqueIdentifier).Value = oBE_SOLICITUD.EMPRESA_ID;
                    objCmd.Parameters.Add("@GERENCIA_ID", SqlDbType.UniqueIdentifier).Value = oBE_SOLICITUD.GERENCIA_ID;
                    objCmd.Parameters.Add("@AREA_ID", SqlDbType.UniqueIdentifier).Value = oBE_SOLICITUD.AREA_ID;
                    objCmd.Parameters.Add("@SOLICITUD_PRIORIDAD", SqlDbType.Int).Value = oBE_SOLICITUD.PRIORIDAD;
                    objCmd.Parameters.Add("@SOLICITUD_TIPO", SqlDbType.Int).Value = oBE_SOLICITUD.TIPO;
                    objCmd.Parameters.Add("@CENTRO_COSTO_ID", SqlDbType.UniqueIdentifier).Value = oBE_SOLICITUD.CENTRO_COSTO_ID;
                    objCmd.Parameters.Add("@ORDEN_ID", SqlDbType.UniqueIdentifier).Value = oBE_SOLICITUD.ORDEN_ID;
                    objCmd.Parameters.Add("@CENTRO_GESTOR_ID", SqlDbType.UniqueIdentifier).Value = oBE_SOLICITUD.CENTRO_GESTOR_ID;
                    objCmd.Parameters.Add("@CUENTA_MAYOR_ID", SqlDbType.UniqueIdentifier).Value = oBE_SOLICITUD.CUENTA_MAYOR_ID;
                    objCmd.Parameters.Add("@SOLICITUD_AUTORIZADOR", SqlDbType.UniqueIdentifier).Value = oBE_SOLICITUD.AUTORIZADOR;
                    objCmd.Parameters.Add("@SOLICITUD_REQUIERE_APROBACION", SqlDbType.Int).Value = oBE_SOLICITUD.REQUIERE_APROBACION;
                    objCmd.Parameters.Add("@SOLICITUD_SOLICITANTE", SqlDbType.VarChar).Value = oBE_SOLICITUD.SOLICITANTE;
                    objCmd.Parameters.Add("@ESTADO", SqlDbType.Int).Value = oBE_SOLICITUD.ESTADO;
                    objCmd.Parameters.Add("@USUARIO", SqlDbType.UniqueIdentifier).Value = oBE_SOLICITUD.USUARIO_CREACION;


                    cnx.Open();

                    oTransaction = cnx.BeginTransaction();
                    objCmd.Transaction = oTransaction;

                    if (objCmd.ExecuteNonQuery() > 0)
                        FilasAfectadas += 1;

                    DA_CORRESPONDENCIA oDA_CORRESPONDENCIA = new DA_CORRESPONDENCIA();
                    if (oDA_CORRESPONDENCIA.ActualizarCorrespondencia(oBE_SOLICITUD.oBE_CORRESPONDENCIA, oTransaction, objCmd))
                        FilasAfectadas += 1;
                   

                    if (FilasAfectadas > 1)
                    {
                        bSolicitud = true;
                        oTransaction.Commit();                        
                    }
                    else
                    {
                        oTransaction.Rollback();                       
                    }


                }

            }
            catch (Exception ex)
            {
               
                oTransaction.Rollback();
                throw new Exception("Error: " + ex.Message);

            }
            finally
            {
                cnx.Close();
            }
            return bSolicitud;
        }

        /// <summary>
        /// Actualizar estado de la solicitud
        /// </summary>
        /// <param name="solicitudId">Identificador de la solicitud a actualizar</param>
        /// <param name="estado">Estado a actualizar</param>
        /// <param name="usuario">Usuario Id que desea actualizar la solicitud</param>
        /// <param name="solicitanteCorreo">Correo del usuario que solicitó la aprobación de la solicitud</param>
        /// <returns>Bool. True, si se actualizó con exito. False, si hubo un error al actualizar</returns>
        public bool ActualizarEstadoSolicitud(Guid solicitudId, int estado, Guid usuario, String solicitanteCorreo)
        {
            SqlConnection cnx = new SqlConnection();
            int FilasAfectadas = 0;
            SqlTransaction oTransaction = null;
            cnx = DC_Connection.getConnection();
            Guid solicitud_id = Guid.Empty;
            bool bSolicitud = false;

            try
            {

                using (
                    SqlCommand objCmd = new SqlCommand()
                    {
                        Connection = cnx,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "USP_SOLICITUD_ACTUALIZAR_ESTADO"
                    }
                    )
                {
                    //Se crea el objeto Parameters por cada parametro

                    objCmd.Parameters.Add("@SOLICITUD_ID", SqlDbType.UniqueIdentifier).Value = solicitudId;
                    objCmd.Parameters.Add("@ESTADO", SqlDbType.Int).Value = estado;
                    objCmd.Parameters.Add("@USUARIO", SqlDbType.UniqueIdentifier).Value = usuario;


                    cnx.Open();

                    oTransaction = cnx.BeginTransaction();
                    objCmd.Transaction = oTransaction;

                    if (objCmd.ExecuteNonQuery() > 0)
                        FilasAfectadas += 1;                    

                    DA_CORRESPONDENCIA oDA_CORRESPONDENCIA = new DA_CORRESPONDENCIA();
                    if (oDA_CORRESPONDENCIA.ActualizarEstadoCorrespondencia(solicitudId, estado, usuario, oTransaction, objCmd))
                        FilasAfectadas += 1;

                    if (FilasAfectadas > 0)
                    {
                        bSolicitud = true;
                        oTransaction.Commit();
                        if (estado == 2) // Aprobada
                            NotificarAprobacionSolicitud(solicitudId, solicitanteCorreo);
                    }
                    else
                    {
                        oTransaction.Rollback();
                    }


                }

            }
            catch (Exception ex)
            {

                oTransaction.Rollback();
                throw new Exception("Error: " + ex.Message);

            }
            finally
            {
                cnx.Close();
            }
            return bSolicitud;
        }

        /// <summary>
        /// Envía un correo notificando la aprobación de la solicitud
        /// </summary>
        /// <param name="solicitudId">Id de la Solicitud que se desea consultar</param>
        /// <param name="correo">Correo del autorizador</param>
        /// <returns>bool true or false en caso de error.</returns>
        public bool NotificarAprobacionSolicitud(Guid solicitudId, string correo)
        {

            SqlConnection cnx = new SqlConnection();
            cnx = DC_Connection.getConnection();
            bool bSolicitud = false;

            try
            {
                using (SqlCommand objCmd = new SqlCommand()
                {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_NOTIFICAR_APROBACION_SOLICITUD"
                })
                {

                    objCmd.Parameters.Add("@SOLICITUD_ID", SqlDbType.UniqueIdentifier).Value = solicitudId;
                    objCmd.Parameters.Add("@CORREO", SqlDbType.VarChar).Value = correo;

                    cnx.Open();
                    if (objCmd.ExecuteNonQuery() < 0)
                        bSolicitud = true;
                }
                return bSolicitud;

            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
            finally
            {
                cnx.Close();
            }
        }

        /// <summary>
        /// Envía un correo solicitando la aprobación de la solicitud
        /// </summary>
        /// <param name="solicitudId">Id de la Solicitud que se desea consultar</param>
        /// <param name="correo">Correo del autorizador</param>
        /// <returns>bool true or false en caso de error.</returns>
        public bool SolicitarAprobacionSolicitud(Guid solicitudId, string correo)
        {

            SqlConnection cnx = new SqlConnection();            
            cnx = DC_Connection.getConnection();
            bool bSolicitud = false;

            try
            {
                using (SqlCommand objCmd = new SqlCommand()
                {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_SOLICITAR_AUTORIZACION"
                })
                {

                    objCmd.Parameters.Add("@SOLICITUD_ID", SqlDbType.UniqueIdentifier).Value = solicitudId;
                    objCmd.Parameters.Add("@CORREO", SqlDbType.VarChar).Value = correo;

                    cnx.Open();
                    if (objCmd.ExecuteNonQuery() < 0)
                        bSolicitud = true;
                }
                return bSolicitud;

            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
            finally
            {
                cnx.Close();
            }
        }
    }
}
