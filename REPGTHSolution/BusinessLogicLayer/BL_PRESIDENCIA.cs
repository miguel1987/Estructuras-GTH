using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessEntities;

namespace BusinessLogicLayer
{
    /// <summary>
    /// En esta clase se encuentran todos los metodos para las consultas de la entidad PRESIDENCIAS
    /// </summary>
    public class BL_PRESIDENCIA
    {
        //Inicializamos web service para consulta y actualización de maestros genéricos.  
        //wsMaestros.mantenimientoMaestros wsMantenimientoMaestros = new wsMaestros.mantenimientoMaestros();
        wsMaestros.mantenimientoEstructuras wsMantenimientoEstructuras = new wsMaestros.mantenimientoEstructuras();

        /// <summary>
        ///  Devuelve los datos de todas las PRESIDENCIAS de una EMPRESA.
        /// </summary>
        /// <param name="empresa_id">Codigo del la Empresa de la cual se desea consultar sus gerencias</param>
        /// <returns> List de BE_GERENCIA con los objetos de la entidad, que a su vez representan la tabla GERENCIAS de la base de datos.En caso no haiga datos devuelve nothing </returns>
        public List<BE_PRESIDENCIA> SeleccionarPresidenciaPorEmpresa(Guid empresa_id)
        {

            wsMaestros.BE_PRESIDENCIA[] oLista = wsMantenimientoEstructuras.SeleccionarPresidenciaPorEmpresa(empresa_id);
            List<BE_PRESIDENCIA> oListaPresidencia = new List<BE_PRESIDENCIA>();

            if (oLista != null)
            {

                foreach (var item in oLista)
                {
                    BE_PRESIDENCIA oPresidencia = new BE_PRESIDENCIA();
                    oPresidencia.ID = item.ID;
                    oPresidencia.DESCRIPCION = item.DESCRIPCION;
                    oPresidencia.USUARIO_CREACION = item.USUARIO_CREACION;
                    oPresidencia.FECHA_CREACION = item.FECHA_CREACION;
                    oPresidencia.USUARIO_ACTUALIZACION = item.USUARIO_ACTUALIZACION;
                    oPresidencia.ESTADO = item.ESTADO;

                    oListaPresidencia.Add(oPresidencia);

                }
            }

            return oListaPresidencia;
        }
    }
}
