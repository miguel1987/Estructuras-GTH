using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataConnectionComponent;
using BusinessEntities;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace DataAccessLayer
{
    /// <summary>
    /// En esta clase se encuentran todos los metodos para la tabla PERFILES
    /// </summary>
    public class DA_PERFILES
    {
        /// <summary>
        /// Devuelve los datos de todos los Perfiles
        /// </summary>
        /// <returns>List de BE_PERFILES con los objetos de la entidad, que a su vez representan la tabla PERFILES de la base de datos. En caso no haiga datos devuelve nothing.</returns>
        public List<BE_PERFILES> SeleccionarPerfiles()
        {
            SqlConnection cnx = new SqlConnection();
            DbDataReader dr;
            cnx = DC_Connection.getConnection();
            List<BE_PERFILES> oPERFILES = null;
            try
            {
                using (SqlCommand objCmd = new SqlCommand()
                {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_PERFILES_SELECCIONAR"
                })
                {
                    cnx.Open();
                    dr = objCmd.ExecuteReader();

                    // Se crea una variable tipo int por cada posicion de cada campo
                    int PERFIL_ID = dr.GetOrdinal("PERFIL_ID");
                    int PERFIL_DESCRIPCION = dr.GetOrdinal("PERFIL_DESCRIPCION");


                    // creamos un objeto del tamaño de la tupla en el array de objeto Valores
                    object[] Valores = new object[dr.FieldCount];

                    // Preguntamos si el DbDataReader tiene registros
                    if (dr.HasRows)
                    {

                        // Instancionamos la lista para empezar a setearla
                        oPERFILES = new List<BE_PERFILES>();
                        while (dr.Read())
                        {
                            // Obetemos los valores para la tupla
                            dr.GetValues(Valores);
                            BE_PERFILES oBE_PERFILES = new BE_PERFILES();
                            oBE_PERFILES.ID = Int32.Parse(Valores.GetValue(PERFIL_ID).ToString());
                            oBE_PERFILES.DESCRIPCION = Valores.GetValue(PERFIL_DESCRIPCION).ToString();
                            oPERFILES.Add(oBE_PERFILES);
                        }
                    }
                }

                return oPERFILES;
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
        /// Devuelve los datos un Perfil en especifico
        /// </summary>
        /// <returns>BE_PERFILES con los objetos de la entidad, que a su vez representan la tabla PERFILES de la base de datos. En caso no haiga datos devuelve nothing.</returns>
        public BE_PERFILES SeleccionarPerfilesPorID(Int32 ID)
        {
            SqlConnection cnx = new SqlConnection();
            DbDataReader dr;
            cnx = DC_Connection.getConnection();
            BE_PERFILES oBE_PERFILES = null;
            try
            {
                using (SqlCommand objCmd = new SqlCommand()
                {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_PERFILES_SELECCIONAR_POR_ID"
                })
                {

                    objCmd.Parameters.Add("@PERFIL_ID", SqlDbType.Int).Value = ID;


                    cnx.Open();
                    dr = objCmd.ExecuteReader();

                    // Se crea una variable tipo int por cada posicion de cada campo
                    int PERFIL_ID = dr.GetOrdinal("PERFIL_ID");
                    int PERFIL_DESCRIPCION = dr.GetOrdinal("PERFIL_DESCRIPCION");


                    // creamos un objeto del tamaño de la tupla en el array de objeto Valores
                    object[] Valores = new object[dr.FieldCount];

                    // Preguntamos si el DbDataReader tiene registros
                    if (dr.HasRows)
                    {

                        // Instancionamos la lista para empezar a setearla
                        oBE_PERFILES = new BE_PERFILES();
                        if (dr.Read())
                        {
                            // Obetemos los valores para la tupla
                            dr.GetValues(Valores);
                            //BE_PERFILES oBE_PERFILES = new BE_PERFILES();
                            oBE_PERFILES.ID = Int32.Parse(Valores.GetValue(PERFIL_ID).ToString());
                            oBE_PERFILES.DESCRIPCION = Valores.GetValue(PERFIL_DESCRIPCION).ToString();

                        }
                    }
                }

                return oBE_PERFILES;
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
    }
}
