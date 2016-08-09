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
    /// En esta clase se encuentran todos los metodos para las consultas de la tabla EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL
    /// </summary>
    public class DA_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL
    {

        /// <summary>
        /// Inserta los datos de la tabla EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL
        /// </summary>
        /// <param name="oBE_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL">Entidad BE_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL, que representa la tabla SOLICITUDES, con todos sus atributos </param>
        /// <returns>Guid. Guid, si se ingreso con exito. Null, si hubo un error al ingresar</returns>
        public Guid InsertarEvaluacionCompetenciaPuestoPersonal(BE_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL oBE_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL)
        {
            SqlConnection cnx = new SqlConnection();
            int FilasAfectadas = 0;
            SqlTransaction oTransaction = null;
            cnx = DC_Connection.getConnection();
            Guid evluacion_competencia_puesto_personal_id = Guid.Empty;

            try
            {

                using (
                    SqlCommand objCmd = new SqlCommand()
                    {
                        Connection = cnx,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "USP_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL_INSERTAR"
                    }
                    )
                {
                    //Se crea el objeto Parameters por cada parametro                   

                    objCmd.Parameters.Add("@PERSONAL_ID", SqlDbType.UniqueIdentifier).Value =oBE_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL.PERSONAL_ID;
                    objCmd.Parameters.Add("@PUESTO_ID", SqlDbType.UniqueIdentifier).Value = oBE_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL.PUESTO_ID;
                    objCmd.Parameters.Add("@COMPETENCIA_ID", SqlDbType.UniqueIdentifier).Value = oBE_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL.COMPETENCIA_ID;
                    objCmd.Parameters.Add("@EVALUACION_COMPETENCIA_VALOR_REAL", SqlDbType.Int).Value = oBE_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL.REAL;
                    objCmd.Parameters.Add("@EVALUACION_COMPETENCIA_COMENTARIO", SqlDbType.VarChar).Value = oBE_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL.COMENTARIO;
                    objCmd.Parameters.Add("@EVALUACION_COMPETENCIA_BRECHA", SqlDbType.Int).Value = oBE_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL.BRECHA;
                    objCmd.Parameters.Add("@EVALUACION_COMPETENCIA_ESTADO", SqlDbType.Int).Value = oBE_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL.ESTADO_EVALUACION;
                    objCmd.Parameters.Add("@EVALUACION_COMPETENCIA_ANIO", SqlDbType.Int).Value = oBE_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL.ANIO_EVALUACION;
                    objCmd.Parameters.Add("@USUARIO", SqlDbType.UniqueIdentifier).Value = oBE_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL.USUARIO_CREACION;

                    cnx.Open();

                    oTransaction = cnx.BeginTransaction();
                    objCmd.Transaction = oTransaction;

                    evluacion_competencia_puesto_personal_id = (Guid)objCmd.ExecuteScalar();

                    DA_EVALUACIONES_COMPETENCIAS_PERSONAL oDA_EVALUACIONES_COMPETENCIAS_PERSONAL = new DA_EVALUACIONES_COMPETENCIAS_PERSONAL();
                    if (oDA_EVALUACIONES_COMPETENCIAS_PERSONAL.InsertarEvalucionCompetenciaPersonal(oBE_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL, oTransaction, objCmd))
                        FilasAfectadas += 1;

                    if (FilasAfectadas > 0)
                    {
                        oTransaction.Commit();

                    }
                    else
                    {
                        oTransaction.Rollback();
                        evluacion_competencia_puesto_personal_id = Guid.Empty;
                    }


                }

            }
            catch (Exception ex)
            {
                evluacion_competencia_puesto_personal_id = Guid.Empty;
                oTransaction.Rollback();

                throw new Exception("Error: " + ex.Message);

            }
            finally
            {
                cnx.Close();
            }
            return evluacion_competencia_puesto_personal_id;
        }

        public bool ActualizarEvaluacionCompetenciaPuestoPersonal(BE_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL oBE_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL)
        {
            SqlConnection cnx = new SqlConnection();
            int FilasAfectadas = 0;
            SqlTransaction oTransaction = null;
            bool bSolicitud = false;
            cnx = DC_Connection.getConnection();            

            try
            {

                using (
                    SqlCommand objCmd = new SqlCommand()
                    {
                        Connection = cnx,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "USP_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL_ACTUALIZAR"
                    }
                    )
                {
                    //Se crea el objeto Parameters por cada parametro                   

                    objCmd.Parameters.Add("@PERSONAL_ID", SqlDbType.UniqueIdentifier).Value = oBE_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL.PERSONAL_ID;
                    objCmd.Parameters.Add("@PUESTO_ID", SqlDbType.UniqueIdentifier).Value = oBE_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL.PUESTO_ID;
                    objCmd.Parameters.Add("@COMPETENCIA_ID", SqlDbType.UniqueIdentifier).Value = oBE_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL.COMPETENCIA_ID;
                    objCmd.Parameters.Add("@EVALUACION_COMPETENCIA_VALOR_REAL", SqlDbType.Int).Value = oBE_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL.REAL;
                    objCmd.Parameters.Add("@EVALUACION_COMPETENCIA_COMENTARIO", SqlDbType.VarChar).Value = oBE_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL.COMENTARIO;
                    objCmd.Parameters.Add("@EVALUACION_COMPETENCIA_BRECHA", SqlDbType.Int).Value = oBE_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL.BRECHA;
                    objCmd.Parameters.Add("@EVALUACION_COMPETENCIA_ESTADO", SqlDbType.Int).Value = oBE_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL.ESTADO_EVALUACION;
                    
                    cnx.Open();

                    oTransaction = cnx.BeginTransaction();
                    objCmd.Transaction = oTransaction;
                    
                    objCmd.ExecuteNonQuery();

                    DA_EVALUACIONES_COMPETENCIAS_PERSONAL oDA_EVALUACIONES_COMPETENCIAS_PERSONAL = new DA_EVALUACIONES_COMPETENCIAS_PERSONAL();
                    if (oDA_EVALUACIONES_COMPETENCIAS_PERSONAL.ActalizarEvalucionCompetenciaPersonal(oBE_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL, oTransaction, objCmd))
                        FilasAfectadas += 1;

                    if (FilasAfectadas > 0)
                    {
                        bSolicitud = true;
                        oTransaction.Commit();

                    }
                    else
                    {
                        oTransaction.Rollback();
                        //evluacion_competencia_puesto_personal_id = Guid.Empty;
                    }


                }

            }
            catch (Exception ex)
            {
                //evluacion_competencia_puesto_personal_id = Guid.Empty;
                oTransaction.Rollback();

                throw new Exception("Error: " + ex.Message);

            }
            finally
            {
                cnx.Close();
            }
            return bSolicitud;
        }

        public bool ActualizarEvaluacionFinal(BE_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL oBE_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL)
        {
            SqlConnection cnx = new SqlConnection();
            SqlTransaction oTransaction = null;
            bool bSolicitud = false;
            cnx = DC_Connection.getConnection();

            try
            {

                using (
                    SqlCommand objCmd = new SqlCommand()
                    {
                        Connection = cnx,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "USP_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL_ACTUALIZAR_EVALUACION_FINAL"
                    }
                    )
                {
                    //Se crea el objeto Parameters por cada parametro                                      
                    objCmd.Parameters.Add("@PUESTO_ID", SqlDbType.UniqueIdentifier).Value = oBE_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL.PUESTO_ID;
                    objCmd.Parameters.Add("@PERSONAL_ID", SqlDbType.UniqueIdentifier).Value = oBE_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL.PERSONAL_ID;
                    cnx.Open();

                    oTransaction = cnx.BeginTransaction();
                    objCmd.Transaction = oTransaction;

                    objCmd.ExecuteNonQuery();
                    bSolicitud = true;
                    oTransaction.Commit();
                }
            }
            catch (Exception ex)
            {
                //evluacion_competencia_puesto_personal_id = Guid.Empty;
                oTransaction.Rollback();

                throw new Exception("Error: " + ex.Message);

            }
            finally
            {
                cnx.Close();
            }
            return bSolicitud;
        }

        public static bool ExisteRegistrosCompetenciasPuestoPersonal(BE_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL OBE_COMPE_PUESTO_PERSONAL)
        {

            SqlConnection cnx = new SqlConnection();

            cnx = DC_Connection.getConnection();

            try
            {
                using (SqlCommand objCmd = new SqlCommand()
                {
                    Connection = cnx,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL_EXISTE_REGISTROS_COMPETENCIAS_PUESTO_PERSONAL"
                })
                {
                    objCmd.Parameters.Add("@PERSONAL_ID", SqlDbType.UniqueIdentifier).Value = OBE_COMPE_PUESTO_PERSONAL.PERSONAL_ID;
                    objCmd.Parameters.Add("@COMPETENCIA_ID", SqlDbType.UniqueIdentifier).Value =OBE_COMPE_PUESTO_PERSONAL.COMPETENCIA_ID;

                    cnx.Open();
                    bool valor = Convert.ToBoolean(objCmd.ExecuteScalar());

                    return valor;

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
