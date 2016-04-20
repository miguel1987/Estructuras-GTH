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
    public class DA_EVALUACION_COMPETENCIA_PUESTO
    {

        public  int SeleccionarEvaluacionEstadoPorPersonal(Guid PERSONAL_ID)
        {

            SqlConnection cnx = new SqlConnection();
            
            cnx = DC_Connection.getConnection();
           
            try
            {
                using (SqlCommand objCmd = new SqlCommand()
                {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_SELECCIONAR_EVALUACIONES_ESTADO_POR_PERSONAL_ID"
                })
                {
                    objCmd.Parameters.Add("@PERSONAL_ID ", SqlDbType.UniqueIdentifier).Value = PERSONAL_ID;

                    cnx.Open();
                    Int32 estado = Convert.ToInt32(objCmd.ExecuteScalar());

                    //    // Se crea una variable tipo int por cada posicion de cada campo
                    //    int DESTINATARIO_NOMBRE = dr.GetOrdinal("DESTINATARIO_NOMBRE");
                    //    int DESTINATARIO_DIRECCION_ID = dr.GetOrdinal("DESTINATARIO_DIRECCION_ID");
                    //    int DESTINATARIO_DIRECCION = dr.GetOrdinal("DESTINATARIO_DIRECCION");

                    //    // creamos un objeto del tamaño de la tupla en el array de objeto Valores
                    //    object[] Valores = new object[dr.FieldCount];

                    //    // Preguntamos si el DbDatGERENCIAder tiene registros
                    //    if (dr.HasRows)
                    //    {

                    //        // Instancionamos la lista para empezar a setearla
                    //        oDESTINATARIO = new List<BE_DESTINATARIO>();
                    //        while (dr.Read())
                    //        {
                    //            // Obetemos los valores para la tupla
                    //            dr.GetValues(Valores);
                    //            BE_DESTINATARIO oBE_DESTINATARIO = new BE_DESTINATARIO();

                    //            oBE_DESTINATARIO.NOMBRE = Valores.GetValue(DESTINATARIO_NOMBRE).ToString();
                    //            oBE_DESTINATARIO.DIRECCION = Valores.GetValue(DESTINATARIO_DIRECCION).ToString();
                    //            oBE_DESTINATARIO.DIRECCION_ID = (Guid)Valores.GetValue(DESTINATARIO_DIRECCION_ID);
                    //            oDESTINATARIO.Add(oBE_DESTINATARIO);

                    //        }
                    //    }


                    //}

                    return estado;
                    
                }
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
