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
    /// En esta clase se encuentran todos los metodos para las consultas de los destinatarios de las solicitudes
    /// </summary>
    public class DA_DESTINATARIO
    {
        /// <summary>
        ///  Devuelve los datos de los Destinatarios  que pertenecen a un tipo de solicitud específico.
        /// </summary>
        /// <param name="tipo_solicitud">int Tipo de envío:Nacional o Internacional</param>        
        /// <returns> List de BE_DESTINATARIO con los objetos de la entidad, que a su vez representan los destinatarios de la base de datos.En caso no existan datos devuelve nothing </returns>
        public List<BE_DESTINATARIO> SeleccionarDestinatariosPorTipo(int tipo_solicitud)
        {

            SqlConnection cnx = new SqlConnection();
            DbDataReader dr;
            cnx = DC_Connection.getConnection();
            List<BE_DESTINATARIO> oDESTINATARIO = null;
            try
            {
                using (SqlCommand objCmd = new SqlCommand()
                {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_DESTINATARIOS_SELECCIONAR_POR_TIPO"
                })
                {
                    objCmd.Parameters.Add("@TIPO", SqlDbType.Int).Value = tipo_solicitud;

                    cnx.Open();
                    dr = objCmd.ExecuteReader();

                    // Se crea una variable tipo int por cada posicion de cada campo
                    int DESTINATARIO_NOMBRE = dr.GetOrdinal("DESTINATARIO_NOMBRE");
                    int DESTINATARIO_DIRECCION_ID = dr.GetOrdinal("DESTINATARIO_DIRECCION_ID");
                    int DESTINATARIO_DIRECCION = dr.GetOrdinal("DESTINATARIO_DIRECCION");  

                    // creamos un objeto del tamaño de la tupla en el array de objeto Valores
                    object[] Valores = new object[dr.FieldCount];

                    // Preguntamos si el DbDatGERENCIAder tiene registros
                    if (dr.HasRows)
                    {

                        // Instancionamos la lista para empezar a setearla
                        oDESTINATARIO = new List<BE_DESTINATARIO>();
                        while (dr.Read())
                        {
                            // Obetemos los valores para la tupla
                            dr.GetValues(Valores);
                            BE_DESTINATARIO oBE_DESTINATARIO = new BE_DESTINATARIO();
                            
                            oBE_DESTINATARIO.NOMBRE = Valores.GetValue(DESTINATARIO_NOMBRE).ToString();
                            oBE_DESTINATARIO.DIRECCION = Valores.GetValue(DESTINATARIO_DIRECCION).ToString();
                            oBE_DESTINATARIO.DIRECCION_ID = (Guid)Valores.GetValue(DESTINATARIO_DIRECCION_ID);
                            oDESTINATARIO.Add(oBE_DESTINATARIO);

                        }
                    }


                }

                return oDESTINATARIO;
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
