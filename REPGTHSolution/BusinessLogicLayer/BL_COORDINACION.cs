using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessEntities;
using DataAccessLayer;

namespace BusinessLogicLayer
{
  public  class BL_COORDINACION
    {
        //Inicializamos web service para consulta y actualización de maestros genéricos.  
        //wsMaestros.mantenimientoMaestros wsMantenimientoMaestros = new wsMaestros.mantenimientoMaestros();
        wsMaestros.mantenimientoEstructuras wsMantenimientoEstructuras = new wsMaestros.mantenimientoEstructuras();

        /// <summary>
        ///  Devuelve los datos de todas las PRESIDENCIAS de una EMPRESA.
        /// </summary>
        /// <param name="empresa_id">Codigo del la Empresa de la cual se desea consultar sus gerencias</param>
        /// <returns> List de BE_GERENCIA con los objetos de la entidad, que a su vez representan la tabla GERENCIAS de la base de datos.En caso no haiga datos devuelve nothing </returns>
        public List<BE_COORDINACION> SeleccionarCoordinacionPorArea(Guid empresa_id)
        {

            wsMaestros.BE_COORDINACION[] oLista = wsMantenimientoEstructuras.SeleccionarCoordinacionesPorArea(empresa_id);
            List<BE_COORDINACION> oListaCoordinacion = new List<BE_COORDINACION>();

            if (oLista != null)
            {

                foreach (var item in oLista)
                {
                    BE_COORDINACION oCoordinacion = new BE_COORDINACION();
                    oCoordinacion.ID = item.ID;
                    oCoordinacion.DESCRIPCION = item.DESCRIPCION;
                    oCoordinacion.USUARIO_CREACION = item.USUARIO_CREACION;
                    oCoordinacion.FECHA_CREACION = item.FECHA_CREACION;
                    oCoordinacion.USUARIO_ACTUALIZACION = item.USUARIO_ACTUALIZACION;
                    oCoordinacion.ESTADO = item.ESTADO;

                    oListaCoordinacion.Add(oCoordinacion);

                }
            }

            return oListaCoordinacion;

        }
    }
}
