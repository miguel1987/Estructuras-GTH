﻿using System;
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
    /// En esta clase se encuentran todos los metodos para las consultas de la tabla PUESTOS
    /// </summary>
    public class DA_PUESTO
    {
        /// <summary>
        ///  Devuelve los datos de todas las áreas.
        /// </summary>
        /// <returns> List de BE_PUESTO con los objetos de la entidad, que a su vez representan la tabla PUESTOS de la base de datos.En caso no haiga datos devuelve nothing </returns>
        public List<BE_PUESTO> SeleccionarPuestos()
        {

            SqlConnection cnx = new SqlConnection();
            DbDataReader dr;
            cnx = DC_Connection.getConnection();
            List<BE_PUESTO> oPUESTO = null;
            try
            {
                using (SqlCommand objCmd = new SqlCommand()
                {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_PUESTO_SELECCIONAR"
                })
                {
                    cnx.Open();
                    dr = objCmd.ExecuteReader();

                    // Se crea una variable tipo int por cada posicion de cada campo
                    int PUESTO_ID = dr.GetOrdinal("PUESTO_ID");
                    int PUESTO_CODIGO = dr.GetOrdinal("PUESTO_CODIGO");
                    int PUESTO_DESCRIPCION = dr.GetOrdinal("PUESTO_DESCRIPCION");
                    int PUESTO_NIVEL = dr.GetOrdinal("PUESTO_NIVEL");
                    int PUESTO_ESTADO = dr.GetOrdinal("PUESTO_ESTADO");                   
                    int USUARIO_CREACION = dr.GetOrdinal("USUARIO_CREACION");
                    int FECHA_CREACION = dr.GetOrdinal("FECHA_CREACION");
                    int USUARIO_ACTUALIZACION = dr.GetOrdinal("USUARIO_ACTUALIZACION");
                    int FECHA_ACTUALIZACION = dr.GetOrdinal("FECHA_ACTUALIZACION");
                    int EMPRESA_ID = dr.GetOrdinal("EMPRESA_ID");


                    // creamos un objeto del tamaño de la tupla en el array de objeto Valores
                    object[] Valores = new object[dr.FieldCount];

                    // Preguntamos si el DbDataReader tiene registros
                    if (dr.HasRows)
                    {

                        // Instancionamos la lista para empezar a setearla
                        oPUESTO = new List<BE_PUESTO>();
                        while (dr.Read())
                        {
                            // Obetemos los valores para la tupla
                            dr.GetValues(Valores);
                            BE_PUESTO oBE_PUESTO = new BE_PUESTO();

                            oBE_PUESTO.ID = (Guid)Valores.GetValue(PUESTO_ID);
                            oBE_PUESTO.CODIGO = Valores.GetValue(PUESTO_CODIGO).ToString();
                            oBE_PUESTO.DESCRIPCION = Valores.GetValue(PUESTO_DESCRIPCION).ToString();
                            oBE_PUESTO.NIVEL = Convert.ToInt32(Valores.GetValue(PUESTO_NIVEL));
                            oBE_PUESTO.ESTADO = Convert.ToInt32(Valores.GetValue(PUESTO_ESTADO));
                            oBE_PUESTO.USUARIO_CREACION = (Guid)Valores.GetValue(USUARIO_CREACION);
                            oBE_PUESTO.FECHA_CREACION = Convert.ToDateTime(Valores.GetValue(FECHA_CREACION));
                            oBE_PUESTO.USUARIO_ACTUALIZACION = (Guid)Valores.GetValue(USUARIO_ACTUALIZACION);
                            oBE_PUESTO.FECHA_ACTUALIZACION = Convert.ToDateTime(Valores.GetValue(FECHA_ACTUALIZACION));
                            oBE_PUESTO.EMPRESA_ID = (Guid)Valores.GetValue(EMPRESA_ID);

                            oPUESTO.Add(oBE_PUESTO);
                        }
                    }


                }

                return oPUESTO;
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
        /// Devuelve los datos de un puesto específica.
        /// </summary>
        /// <param name="puesto_id">Codigo del area al cual se desea consultar</param>
        /// <returns>BE_PUESTO, entidad que representa la tabla PUESTO, con todas sus atributos. En caso no haiga datos devuelve nothing</returns>
        public BE_PUESTO SeleccionarPuestoPorId(Guid puesto_id)
        {

            SqlConnection cnx = new SqlConnection();
            DbDataReader dr;
            cnx = DC_Connection.getConnection();
            BE_PUESTO oBE_PUESTO = null;
            try
            {
                using (SqlCommand objCmd = new SqlCommand()
                {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_PUESTO_SELECCIONAR_POR_ID"
                })
                {
                    objCmd.Parameters.Add("@PUESTO_ID", SqlDbType.UniqueIdentifier).Value = puesto_id;

                    cnx.Open();
                    dr = objCmd.ExecuteReader();

                    // Se crea una variable tipo int por cada posicion de cada campo
                    int PUESTO_ID = dr.GetOrdinal("PUESTO_ID");
                    int PUESTO_CODIGO = dr.GetOrdinal("PUESTO_CODIGO");
                    int PUESTO_DESCRIPCION = dr.GetOrdinal("PUESTO_DESCRIPCION");
                    int PUESTO_NIVEL = dr.GetOrdinal("PUESTO_NIVEL");
                    int PUESTO_ESTADO = dr.GetOrdinal("PUESTO_ESTADO");
                    int USUARIO_CREACION = dr.GetOrdinal("USUARIO_CREACION");
                    int FECHA_CREACION = dr.GetOrdinal("FECHA_CREACION");
                    int USUARIO_ACTUALIZACION = dr.GetOrdinal("USUARIO_ACTUALIZACION");
                    int FECHA_ACTUALIZACION = dr.GetOrdinal("FECHA_ACTUALIZACION");
                    int EMPRESA_ID = dr.GetOrdinal("EMPRESA_ID");
                    int GERENCIA_ID = dr.GetOrdinal("GERENCIA_ID");
                    int AREA_ID = dr.GetOrdinal("AREA_ID");
                    int COORDINACION_ID = dr.GetOrdinal("COORDINACION_ID");

                    // creamos un objeto del tamaño de la tupla en el array de objeto Valores
                    object[] Valores = new object[dr.FieldCount];

                    // Preguntamos si el DbDataReader tiene registros
                    if (dr.HasRows)
                    {

                        // Instancionamos la lista para empezar a setearla
                        oBE_PUESTO = new BE_PUESTO();
                        if (dr.Read())
                        {
                            // Obetemos los valores para la tupla
                            dr.GetValues(Valores);

                            oBE_PUESTO.ID = (Guid)Valores.GetValue(PUESTO_ID);
                            oBE_PUESTO.CODIGO = Valores.GetValue(PUESTO_CODIGO).ToString();
                            oBE_PUESTO.DESCRIPCION = Valores.GetValue(PUESTO_DESCRIPCION).ToString();
                            oBE_PUESTO.NIVEL = Convert.ToInt32(Valores.GetValue(PUESTO_NIVEL));
                            oBE_PUESTO.ESTADO = Convert.ToInt32(Valores.GetValue(PUESTO_ESTADO));
                            oBE_PUESTO.USUARIO_CREACION = (Guid)Valores.GetValue(USUARIO_CREACION);
                            oBE_PUESTO.FECHA_CREACION = Convert.ToDateTime(Valores.GetValue(FECHA_CREACION));
                            oBE_PUESTO.USUARIO_ACTUALIZACION = (Guid)Valores.GetValue(USUARIO_ACTUALIZACION);
                            oBE_PUESTO.FECHA_ACTUALIZACION = Convert.ToDateTime(Valores.GetValue(FECHA_ACTUALIZACION));
                            oBE_PUESTO.EMPRESA_ID = (Guid)Valores.GetValue(EMPRESA_ID);
                            oBE_PUESTO.GERENCIA_ID = DBNull.Value == Valores.GetValue(GERENCIA_ID) ? Guid.Empty : (Guid)Valores.GetValue(GERENCIA_ID);
                            oBE_PUESTO.AREA_ID = DBNull.Value == Valores.GetValue(AREA_ID) ? Guid.Empty : (Guid)Valores.GetValue(AREA_ID);
                            oBE_PUESTO.COORDINACION_ID = DBNull.Value == Valores.GetValue(COORDINACION_ID) ? Guid.Empty : (Guid)Valores.GetValue(COORDINACION_ID);

                        }
                    }


                }

                return oBE_PUESTO;
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
        /// Devuelve los datos de puestos por empresa específica
        /// </summary>
        /// <param name="empresa_id">Codigo de la gerencia que se desea consultar</param>
        /// <returns>BE_PUESTO, entidad que representa la tabla PUESTOS y COORDINACIONES_PUESTOS, con todas sus atributos. En caso no haiga datos devuelve nothing</returns>
        public List<BE_PUESTO> SeleccionarPuestoPorEmpresa(Guid empresa_id)
        {

            SqlConnection cnx = new SqlConnection();
            DbDataReader dr;
            cnx = DC_Connection.getConnection();
            List<BE_PUESTO> oPUESTO = null;
            try
            {
                using (SqlCommand objCmd = new SqlCommand()
                {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_PUESTO_SELECCIONAR_POR_EMPRESA"
                })
                {

                    objCmd.Parameters.Add("@EMPRESA_ID", SqlDbType.UniqueIdentifier).Value = empresa_id;

                    cnx.Open();
                    dr = objCmd.ExecuteReader();

                    // Se crea una variable tipo int por cada posicion de cada campo


                    // Campos de l tabla AREA
                    int PUESTO_ID = dr.GetOrdinal("PUESTO_ID");
                    int PUESTO_CODIGO = dr.GetOrdinal("PUESTO_CODIGO");
                    int PUESTO_DESCRIPCION = dr.GetOrdinal("PUESTO_DESCRIPCION");
                    int PUESTO_NIVEL = dr.GetOrdinal("PUESTO_NIVEL");
                    int PUESTO_ESTADO = dr.GetOrdinal("PUESTO_ESTADO");
                    int USUARIO_CREACION = dr.GetOrdinal("USUARIO_CREACION");
                    int FECHA_CREACION = dr.GetOrdinal("FECHA_CREACION");
                    int USUARIO_ACTUALIZACION = dr.GetOrdinal("USUARIO_ACTUALIZACION");
                    int FECHA_ACTUALIZACION = dr.GetOrdinal("FECHA_ACTUALIZACION");
                    int EMPRESA_ID = dr.GetOrdinal("EMPRESA_ID");

                    // creamos un objeto del tamaño de la tupla en el array de objeto Valores
                    object[] Valores = new object[dr.FieldCount];

                    // Preguntamos si el DbDataReader tiene registros
                    if (dr.HasRows)
                    {

                        // instanciamos la entidad de Area para relacionar el objeto con gerencia
                        oPUESTO = new List<BE_PUESTO>();
                        while (dr.Read())
                        {
                            // Obetemos los valores para la tupla
                            dr.GetValues(Valores);


                            BE_PUESTO oBE_PUESTO = new BE_PUESTO();

                            // Seteamos los valores del Area
                            oBE_PUESTO.ID = (Guid)Valores.GetValue(PUESTO_ID);
                            oBE_PUESTO.CODIGO = Valores.GetValue(PUESTO_CODIGO).ToString();
                            oBE_PUESTO.DESCRIPCION = Valores.GetValue(PUESTO_DESCRIPCION).ToString();
                            oBE_PUESTO.NIVEL = Convert.ToSByte(Valores.GetValue(PUESTO_NIVEL));
                            oBE_PUESTO.ESTADO = Convert.ToSByte(Valores.GetValue(PUESTO_ESTADO));
                            oBE_PUESTO.USUARIO_CREACION = (Guid)Valores.GetValue(USUARIO_CREACION);
                            oBE_PUESTO.FECHA_CREACION = Convert.ToDateTime(Valores.GetValue(FECHA_CREACION));
                            oBE_PUESTO.USUARIO_ACTUALIZACION = (Guid)Valores.GetValue(USUARIO_ACTUALIZACION);
                            oBE_PUESTO.FECHA_ACTUALIZACION = Convert.ToDateTime(Valores.GetValue(FECHA_ACTUALIZACION));
                            oBE_PUESTO.EMPRESA_ID = (Guid)Valores.GetValue(EMPRESA_ID);

                            oPUESTO.Add(oBE_PUESTO);
                        }
                    }


                }

                return oPUESTO;
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
        /// Devuelve los datos de puestos por presidencia específica
        /// </summary>
        /// <param name="presidencia_id">Codigo de la gerencia que se desea consultar</param>
        /// <returns>BE_PUESTO, entidad que representa la tabla PUESTOS y COORDINACIONES_PUESTOS, con todas sus atributos. En caso no haiga datos devuelve nothing</returns>
        public List<BE_PUESTO> SeleccionarPuestoPorPresidencia(Guid presidencia_id)
        {

            SqlConnection cnx = new SqlConnection();
            DbDataReader dr;
            cnx = DC_Connection.getConnection();
            List<BE_PUESTO> oPUESTO = null;
            try
            {
                using (SqlCommand objCmd = new SqlCommand()
                {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_PUESTO_SELECCIONAR_POR_PRESIDENCIA"
                })
                {

                    objCmd.Parameters.Add("@PRESIDENCIA_ID", SqlDbType.UniqueIdentifier).Value = presidencia_id;

                    cnx.Open();
                    dr = objCmd.ExecuteReader();

                    // Se crea una variable tipo int por cada posicion de cada campo


                    // Campos de l tabla AREA
                    int PUESTO_ID = dr.GetOrdinal("PUESTO_ID");
                    int PUESTO_CODIGO = dr.GetOrdinal("PUESTO_CODIGO");
                    int PUESTO_DESCRIPCION = dr.GetOrdinal("PUESTO_DESCRIPCION");
                    int PUESTO_NIVEL = dr.GetOrdinal("PUESTO_NIVEL");
                    int PUESTO_ESTADO = dr.GetOrdinal("PUESTO_ESTADO");
                    int USUARIO_CREACION = dr.GetOrdinal("USUARIO_CREACION");
                    int FECHA_CREACION = dr.GetOrdinal("FECHA_CREACION");
                    int USUARIO_ACTUALIZACION = dr.GetOrdinal("USUARIO_ACTUALIZACION");
                    int FECHA_ACTUALIZACION = dr.GetOrdinal("FECHA_ACTUALIZACION");
                    int EMPRESA_ID = dr.GetOrdinal("EMPRESA_ID");

                    // creamos un objeto del tamaño de la tupla en el array de objeto Valores
                    object[] Valores = new object[dr.FieldCount];

                    // Preguntamos si el DbDataReader tiene registros
                    if (dr.HasRows)
                    {

                        // instanciamos la entidad de Area para relacionar el objeto con gerencia
                        oPUESTO = new List<BE_PUESTO>();
                        while (dr.Read())
                        {
                            // Obetemos los valores para la tupla
                            dr.GetValues(Valores);


                            BE_PUESTO oBE_PUESTO = new BE_PUESTO();

                            // Seteamos los valores del Area
                            oBE_PUESTO.ID = (Guid)Valores.GetValue(PUESTO_ID);
                            oBE_PUESTO.CODIGO = Valores.GetValue(PUESTO_CODIGO).ToString();
                            oBE_PUESTO.DESCRIPCION = Valores.GetValue(PUESTO_DESCRIPCION).ToString();
                            oBE_PUESTO.NIVEL = Convert.ToSByte(Valores.GetValue(PUESTO_NIVEL));
                            oBE_PUESTO.ESTADO = Convert.ToSByte(Valores.GetValue(PUESTO_ESTADO));
                            oBE_PUESTO.USUARIO_CREACION = (Guid)Valores.GetValue(USUARIO_CREACION);
                            oBE_PUESTO.FECHA_CREACION = Convert.ToDateTime(Valores.GetValue(FECHA_CREACION));
                            oBE_PUESTO.USUARIO_ACTUALIZACION = (Guid)Valores.GetValue(USUARIO_ACTUALIZACION);
                            oBE_PUESTO.FECHA_ACTUALIZACION = Convert.ToDateTime(Valores.GetValue(FECHA_ACTUALIZACION));
                            oBE_PUESTO.EMPRESA_ID = (Guid)Valores.GetValue(EMPRESA_ID);

                            oPUESTO.Add(oBE_PUESTO);
                        }
                    }


                }

                return oPUESTO;
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
        /// Devuelve los datos de puestos por gerencia específica
        /// </summary>
        /// <param name="gerencia_id">Codigo de la gerencia que se desea consultar</param>
        /// <returns>BE_PUESTO, entidad que representa la tabla PUESTOS y COORDINACIONES_PUESTOS, con todas sus atributos. En caso no haiga datos devuelve nothing</returns>
        public List<BE_PUESTO> SeleccionarPuestoPorGerencia(Guid gerencia_id)
        {

            SqlConnection cnx = new SqlConnection();
            DbDataReader dr;
            cnx = DC_Connection.getConnection();
            List<BE_PUESTO> oPUESTO = null;
            try
            {
                using (SqlCommand objCmd = new SqlCommand()
                {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_PUESTO_SELECCIONAR_POR_GERENCIA"
                })
                {

                    objCmd.Parameters.Add("@GERENCIA_ID", SqlDbType.UniqueIdentifier).Value = gerencia_id;

                    cnx.Open();
                    dr = objCmd.ExecuteReader();

                    // Se crea una variable tipo int por cada posicion de cada campo


                    // Campos de l tabla AREA
                    int PUESTO_ID = dr.GetOrdinal("PUESTO_ID");
                    int PUESTO_CODIGO = dr.GetOrdinal("PUESTO_CODIGO");
                    int PUESTO_DESCRIPCION = dr.GetOrdinal("PUESTO_DESCRIPCION");
                    int PUESTO_NIVEL = dr.GetOrdinal("PUESTO_NIVEL");
                    int PUESTO_ESTADO = dr.GetOrdinal("PUESTO_ESTADO");
                    int USUARIO_CREACION = dr.GetOrdinal("USUARIO_CREACION");
                    int FECHA_CREACION = dr.GetOrdinal("FECHA_CREACION");
                    int USUARIO_ACTUALIZACION = dr.GetOrdinal("USUARIO_ACTUALIZACION");
                    int FECHA_ACTUALIZACION = dr.GetOrdinal("FECHA_ACTUALIZACION");
                    int EMPRESA_ID = dr.GetOrdinal("EMPRESA_ID");

                    // creamos un objeto del tamaño de la tupla en el array de objeto Valores
                    object[] Valores = new object[dr.FieldCount];

                    // Preguntamos si el DbDataReader tiene registros
                    if (dr.HasRows)
                    {                        

                        // instanciamos la entidad de Area para relacionar el objeto con gerencia
                        oPUESTO= new List<BE_PUESTO>();
                        while (dr.Read())
                        {
                            // Obetemos los valores para la tupla
                            dr.GetValues(Valores);


                            BE_PUESTO oBE_PUESTO = new BE_PUESTO();

                            // Seteamos los valores del Area
                            oBE_PUESTO.ID = (Guid)Valores.GetValue(PUESTO_ID);
                            oBE_PUESTO.CODIGO = Valores.GetValue(PUESTO_CODIGO).ToString();
                            oBE_PUESTO.DESCRIPCION = Valores.GetValue(PUESTO_DESCRIPCION).ToString();
                            oBE_PUESTO.NIVEL = Convert.ToSByte(Valores.GetValue(PUESTO_NIVEL));
                            oBE_PUESTO.ESTADO = Convert.ToSByte(Valores.GetValue(PUESTO_ESTADO));
                            oBE_PUESTO.USUARIO_CREACION = (Guid)Valores.GetValue(USUARIO_CREACION);
                            oBE_PUESTO.FECHA_CREACION = Convert.ToDateTime(Valores.GetValue(FECHA_CREACION));
                            oBE_PUESTO.USUARIO_ACTUALIZACION = (Guid)Valores.GetValue(USUARIO_ACTUALIZACION);
                            oBE_PUESTO.FECHA_ACTUALIZACION = Convert.ToDateTime(Valores.GetValue(FECHA_ACTUALIZACION));
                            oBE_PUESTO.EMPRESA_ID = (Guid)Valores.GetValue(EMPRESA_ID);

                            oPUESTO.Add(oBE_PUESTO);
                        }
                    }


                }

                return oPUESTO;
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
        /// Devuelve los datos de puestos por area específica
        /// </summary>
        /// <param name="area_id">Codigo de la gerencia que se desea consultar</param>
        /// <returns>BE_PUESTO, entidad que representa la tabla PUESTOS y COORDINACIONES_PUESTOS, con todas sus atributos. En caso no haiga datos devuelve nothing</returns>
        public List<BE_PUESTO> SeleccionarPuestoPorArea(Guid area_id)
        {

            SqlConnection cnx = new SqlConnection();
            DbDataReader dr;
            cnx = DC_Connection.getConnection();
            List<BE_PUESTO> oPUESTO = null;
            try
            {
                using (SqlCommand objCmd = new SqlCommand()
                {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_PUESTO_SELECCIONAR_POR_AREA"
                })
                {

                    objCmd.Parameters.Add("@AREA_ID", SqlDbType.UniqueIdentifier).Value = area_id;

                    cnx.Open();
                    dr = objCmd.ExecuteReader();

                    // Se crea una variable tipo int por cada posicion de cada campo


                    // Campos de l tabla AREA
                    int PUESTO_ID = dr.GetOrdinal("PUESTO_ID");
                    int PUESTO_CODIGO = dr.GetOrdinal("PUESTO_CODIGO");
                    int PUESTO_DESCRIPCION = dr.GetOrdinal("PUESTO_DESCRIPCION");
                    int PUESTO_NIVEL = dr.GetOrdinal("PUESTO_NIVEL");
                    int PUESTO_ESTADO = dr.GetOrdinal("PUESTO_ESTADO");
                    int USUARIO_CREACION = dr.GetOrdinal("USUARIO_CREACION");
                    int FECHA_CREACION = dr.GetOrdinal("FECHA_CREACION");
                    int USUARIO_ACTUALIZACION = dr.GetOrdinal("USUARIO_ACTUALIZACION");
                    int FECHA_ACTUALIZACION = dr.GetOrdinal("FECHA_ACTUALIZACION");
                    int EMPRESA_ID = dr.GetOrdinal("EMPRESA_ID");
                    // creamos un objeto del tamaño de la tupla en el array de objeto Valores
                    object[] Valores = new object[dr.FieldCount];

                    // Preguntamos si el DbDataReader tiene registros
                    if (dr.HasRows)
                    {

                        // instanciamos la entidad de Area para relacionar el objeto con gerencia
                        oPUESTO = new List<BE_PUESTO>();
                        while (dr.Read())
                        {
                            // Obetemos los valores para la tupla
                            dr.GetValues(Valores);


                            BE_PUESTO oBE_PUESTO = new BE_PUESTO();

                            // Seteamos los valores del Area
                            oBE_PUESTO.ID = (Guid)Valores.GetValue(PUESTO_ID);
                            oBE_PUESTO.CODIGO = Valores.GetValue(PUESTO_CODIGO).ToString();
                            oBE_PUESTO.DESCRIPCION = Valores.GetValue(PUESTO_DESCRIPCION).ToString();
                            oBE_PUESTO.NIVEL = Convert.ToSByte(Valores.GetValue(PUESTO_NIVEL));
                            oBE_PUESTO.ESTADO = Convert.ToSByte(Valores.GetValue(PUESTO_ESTADO));
                            oBE_PUESTO.USUARIO_CREACION = (Guid)Valores.GetValue(USUARIO_CREACION);
                            oBE_PUESTO.FECHA_CREACION = Convert.ToDateTime(Valores.GetValue(FECHA_CREACION));
                            oBE_PUESTO.USUARIO_ACTUALIZACION = (Guid)Valores.GetValue(USUARIO_ACTUALIZACION);
                            oBE_PUESTO.FECHA_ACTUALIZACION = Convert.ToDateTime(Valores.GetValue(FECHA_ACTUALIZACION));
                            oBE_PUESTO.EMPRESA_ID = (Guid)Valores.GetValue(EMPRESA_ID);

                            oPUESTO.Add(oBE_PUESTO);
                        }
                    }


                }

                return oPUESTO;
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
        /// Devuelve los datos de puestos por coordinación específica
        /// </summary>
        /// <param name="coordinacion_id">Codigo de la gerencia que se desea consultar</param>
        /// <returns>BE_PUESTO, entidad que representa la tabla PUESTOS y COORDINACIONES_PUESTOS, con todas sus atributos. En caso no haiga datos devuelve nothing</returns>
        public List<BE_PUESTO> SeleccionarPuestoPorCoordinacion(Guid coordinacion_id)
        {

            SqlConnection cnx = new SqlConnection();
            DbDataReader dr;
            cnx = DC_Connection.getConnection();
            List<BE_PUESTO> oPUESTO = null;
            try
            {
                using (SqlCommand objCmd = new SqlCommand()
                {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_PUESTO_SELECCIONAR_POR_COORDINACION"
                })
                {

                    objCmd.Parameters.Add("@COORDINACION_ID", SqlDbType.UniqueIdentifier).Value = coordinacion_id;

                    cnx.Open();
                    dr = objCmd.ExecuteReader();

                    // Se crea una variable tipo int por cada posicion de cada campo


                    // Campos de l tabla AREA
                    int PUESTO_ID = dr.GetOrdinal("PUESTO_ID");
                    int PUESTO_CODIGO = dr.GetOrdinal("PUESTO_CODIGO");
                    int PUESTO_DESCRIPCION = dr.GetOrdinal("PUESTO_DESCRIPCION");
                    int PUESTO_NIVEL = dr.GetOrdinal("PUESTO_NIVEL");
                    int PUESTO_ESTADO = dr.GetOrdinal("PUESTO_ESTADO");
                    int USUARIO_CREACION = dr.GetOrdinal("USUARIO_CREACION");
                    int FECHA_CREACION = dr.GetOrdinal("FECHA_CREACION");
                    int USUARIO_ACTUALIZACION = dr.GetOrdinal("USUARIO_ACTUALIZACION");
                    int FECHA_ACTUALIZACION = dr.GetOrdinal("FECHA_ACTUALIZACION");
                    int EMPRESA_ID = dr.GetOrdinal("EMPRESA_ID");
                    // creamos un objeto del tamaño de la tupla en el array de objeto Valores
                    object[] Valores = new object[dr.FieldCount];

                    // Preguntamos si el DbDataReader tiene registros
                    if (dr.HasRows)
                    {

                        // instanciamos la entidad de Area para relacionar el objeto con gerencia
                        oPUESTO = new List<BE_PUESTO>();
                        while (dr.Read())
                        {
                            // Obetemos los valores para la tupla
                            dr.GetValues(Valores);


                            BE_PUESTO oBE_PUESTO = new BE_PUESTO();

                            // Seteamos los valores del Area
                            oBE_PUESTO.ID = (Guid)Valores.GetValue(PUESTO_ID);
                            oBE_PUESTO.CODIGO = Valores.GetValue(PUESTO_CODIGO).ToString();
                            oBE_PUESTO.DESCRIPCION = Valores.GetValue(PUESTO_DESCRIPCION).ToString();
                            oBE_PUESTO.NIVEL = Convert.ToSByte(Valores.GetValue(PUESTO_NIVEL));
                            oBE_PUESTO.ESTADO = Convert.ToSByte(Valores.GetValue(PUESTO_ESTADO));
                            oBE_PUESTO.USUARIO_CREACION = (Guid)Valores.GetValue(USUARIO_CREACION);
                            oBE_PUESTO.FECHA_CREACION = Convert.ToDateTime(Valores.GetValue(FECHA_CREACION));
                            oBE_PUESTO.USUARIO_ACTUALIZACION = (Guid)Valores.GetValue(USUARIO_ACTUALIZACION);
                            oBE_PUESTO.FECHA_ACTUALIZACION = Convert.ToDateTime(Valores.GetValue(FECHA_ACTUALIZACION));
                            oBE_PUESTO.EMPRESA_ID = (Guid)Valores.GetValue(EMPRESA_ID);

                            oPUESTO.Add(oBE_PUESTO);
                        }
                    }


                }

                return oPUESTO;
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
        /// Inserta los datos de una Sede
        /// </summary>
        /// <param name="oBE_PUESTO">Entidad BE_PUESTO, que representa la tabla PUESTOS, con todos sus atributos </param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean InsertarPuesto(BE_PUESTO oBE_PUESTO)
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
                        CommandText = "USP_PUESTO_INSERTAR"
                    }
                    )
                {
                    //Se crea el objeto Parameters por cada parametro
                    objCmd.Parameters.Add("@PUESTO_CODIGO", SqlDbType.VarChar).Value = oBE_PUESTO.CODIGO;
                    objCmd.Parameters.Add("@PUESTO_DESCRIPCION", SqlDbType.VarChar).Value = oBE_PUESTO.DESCRIPCION;
                    objCmd.Parameters.Add("@PUESTO_NIVEL", SqlDbType.Int).Value = oBE_PUESTO.NIVEL;
                    objCmd.Parameters.Add("@PUESTO_ESTADO", SqlDbType.Int).Value = oBE_PUESTO.ESTADO;
                    objCmd.Parameters.Add("@USUARIO", SqlDbType.UniqueIdentifier).Value = oBE_PUESTO.USUARIO_CREACION;
                    objCmd.Parameters.Add("@EMPRESA_ID", SqlDbType.UniqueIdentifier).Value = oBE_PUESTO.EMPRESA_ID;

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
        /// Actualiza los datos de un Puesto
        /// </summary>
        /// <param name="oBE_PUESTO">Entidad BE_PUESTO, que representa la tabla PUESTOS, con todos sus atributos </param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean ActualizarPuesto(BE_PUESTO oBE_PUESTO)
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
                        CommandText = "USP_PUESTO_ACTUALIZAR"
                    }
                    )
                {
                    //Se crea el objeto Parameters por cada parametro

                    objCmd.Parameters.Add("@PUESTO_ID", SqlDbType.UniqueIdentifier).Value = oBE_PUESTO.ID;
                    objCmd.Parameters.Add("@PUESTO_CODIGO", SqlDbType.VarChar).Value = oBE_PUESTO.CODIGO;
                    objCmd.Parameters.Add("@PUESTO_DESCRIPCION", SqlDbType.VarChar).Value = oBE_PUESTO.DESCRIPCION;
                    objCmd.Parameters.Add("@PUESTO_NIVEL", SqlDbType.Int).Value = oBE_PUESTO.NIVEL;
                    objCmd.Parameters.Add("@PUESTO_ESTADO", SqlDbType.Int).Value = oBE_PUESTO.ESTADO;
                    objCmd.Parameters.Add("@USUARIO", SqlDbType.UniqueIdentifier).Value = oBE_PUESTO.USUARIO_CREACION;
                    objCmd.Parameters.Add("@EMPRESA_ID", SqlDbType.UniqueIdentifier).Value = oBE_PUESTO.EMPRESA_ID;

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
        /// Elimina los dato de un puesto
        /// </summary>
        /// <param name="puesto_id">Id del puesto que se desea eliminar</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean EliminarPuesto(Guid puesto_id)
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
                        CommandText = "USP_PUESTO_ELIMINAR"
                    }
                    )
                {
                    //Se crea el objeto Parameters por cada parametro

                    objCmd.Parameters.Add("@PUESTO_ID", SqlDbType.UniqueIdentifier).Value = puesto_id;


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
