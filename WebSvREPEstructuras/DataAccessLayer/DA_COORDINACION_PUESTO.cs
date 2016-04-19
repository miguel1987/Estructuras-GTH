using System;
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
    /// En esta clase se encuentran todos los metodos para las consultas de la tabla COORDINACIONES_PUESTOS
    /// </summary>
    public class DA_COORDINACION_PUESTO
    {
        /// <summary>
        /// Devuelve los datos de gerencias, áreas y coordinaciones asociadas a un puesto determinado.
        /// </summary>
        /// <param name="puesto_id">Codigo del puesto que se desea consultar</param>
        /// <returns>List_BE_PUESTO, entidad que representa la tabla COORDINACIONES_PUESTOS, con todas sus atributos. En caso no haiga datos devuelve nothing</returns>
        public List<BE_COORDINACION_PUESTO> SeleccionarCoordinacionPuestoPorPuesto(Guid puesto_id)
        {

            SqlConnection cnx = new SqlConnection();
            DbDataReader dr;
            cnx = DC_Connection.getConnection();
            List<BE_COORDINACION_PUESTO> oCOORDINACION_PUESTO = null;
            try
            {
                using (SqlCommand objCmd = new SqlCommand()
                {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_COORDINACION_PUESTO_SELECCIONAR_POR_PUESTO"
                })
                {

                    objCmd.Parameters.Add("@PUESTO_ID", SqlDbType.UniqueIdentifier).Value = puesto_id;

                    cnx.Open();
                    dr = objCmd.ExecuteReader();

                    // Se crea una variable tipo int por cada posicion de cada campo


                    // Campos de l tabla AREA
                    int COORDINACION_PUESTO_ID = dr.GetOrdinal("COORDINACION_PUESTO_ID");
                    int PUESTO_ID = dr.GetOrdinal("PUESTO_ID");
                    int EMPRESA_ID = dr.GetOrdinal("EMPRESA_ID");
                    int GERENCIA_ID = dr.GetOrdinal("GERENCIA_ID");
                    int AREA_ID = dr.GetOrdinal("AREA_ID");
                    int COORDINACION_ID = dr.GetOrdinal("COORDINACION_ID");
                    int PRESIDENCIA_ID = dr.GetOrdinal("PRESIDENCIA_ID");                    

                    // creamos un objeto del tamaño de la tupla en el array de objeto Valores
                    object[] Valores = new object[dr.FieldCount];

                    // Preguntamos si el DbDataReader tiene registros
                    if (dr.HasRows)
                    {

                        // instanciamos la entidad de COORDINACION_PUESTO para relacionar el objeto con PUESTO
                        oCOORDINACION_PUESTO = new List<BE_COORDINACION_PUESTO>();
                        while (dr.Read())
                        {
                            // Obetemos los valores para la tupla
                            dr.GetValues(Valores);


                            BE_COORDINACION_PUESTO oBE_COORDINACION_PUESTO = new BE_COORDINACION_PUESTO();

                            // Seteamos los valores del Area
                            oBE_COORDINACION_PUESTO.ID = (Guid)Valores.GetValue(PUESTO_ID);
                            oBE_COORDINACION_PUESTO.PUESTO_ID = DBNull.Value == Valores.GetValue(PUESTO_ID) ? Guid.Empty : (Guid)Valores.GetValue(PUESTO_ID);
                            oBE_COORDINACION_PUESTO.EMPRESA_ID = DBNull.Value == Valores.GetValue(EMPRESA_ID) ? Guid.Empty : (Guid)Valores.GetValue(EMPRESA_ID);                            
                            oBE_COORDINACION_PUESTO.GERENCIA_ID = DBNull.Value == Valores.GetValue(GERENCIA_ID) ? Guid.Empty : (Guid)Valores.GetValue(GERENCIA_ID);                            
                            oBE_COORDINACION_PUESTO.AREA_ID = DBNull.Value == Valores.GetValue(AREA_ID) ? Guid.Empty : (Guid)Valores.GetValue(AREA_ID);
                            oBE_COORDINACION_PUESTO.COORDINACION_ID = DBNull.Value == Valores.GetValue(COORDINACION_ID) ? Guid.Empty : (Guid)Valores.GetValue(COORDINACION_ID);
                            oBE_COORDINACION_PUESTO.PRESIDENCIA_ID = DBNull.Value == Valores.GetValue(PRESIDENCIA_ID) ? Guid.Empty : (Guid)Valores.GetValue(PRESIDENCIA_ID);

                            oCOORDINACION_PUESTO.Add(oBE_COORDINACION_PUESTO);
                        }
                    }


                }

                return oCOORDINACION_PUESTO;
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
