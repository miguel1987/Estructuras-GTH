using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessEntities;

namespace BusinessLogicLayer
{
    /// <summary>
    /// En esta clase se encuentran todos los metodos para las consultas de la entidad SEDE
    /// </summary>
    public class BL_PUESTO
    {
        //Inicializamos web service para consulta y actualización de maestros genéricos.  
        //wsMaestros.mantenimientoMaestros wsMantenimientoMaestros = new wsMaestros.mantenimientoMaestros();  
        wsMaestros.mantenimientoEstructuras wsMantenimientoEstructuras = new wsMaestros.mantenimientoEstructuras();


        /// <summary>
        ///  Devuelve los datos de todas los PUESTOS.
        /// </summary>
        /// <returns> List de BE_PUESTO con los objetos de la entidad, que a su vez representan la tabla PUESTOS de la base de datos.En caso no haiga datos devuelve nothing </returns>
        public List<BE_PUESTO> SeleccionarPuesto()
        {

            wsMaestros.BE_PUESTO[] oLista = wsMantenimientoEstructuras.SeleccionarPuestos();
            List<BE_PUESTO> oListaPuesto = new List<BE_PUESTO>();
            if (oLista != null)
            {
                foreach (var item in oLista)
                {
                    BE_PUESTO oPuesto = new BE_PUESTO();
                    oPuesto.ID = item.ID;
                    oPuesto.CODIGO = item.CODIGO;
                    oPuesto.DESCRIPCION = item.DESCRIPCION;
                    oPuesto.NIVEL = item.NIVEL;
                    oPuesto.USUARIO_CREACION = item.USUARIO_CREACION;
                    oPuesto.FECHA_CREACION = item.FECHA_CREACION;
                    oPuesto.USUARIO_ACTUALIZACION = item.USUARIO_ACTUALIZACION;
                    oPuesto.ESTADO = item.ESTADO;
                    oPuesto.EMPRESA_ID = item.EMPRESA_ID;

                    BE_NIVEL_PUESTO oBE_NIVEL_PUESTO = new BE_NIVEL_PUESTO();
                    if (oPuesto.NIVEL == (int)BE_PUESTO.PUESTO_NIVEL.Presidencia)
                    {
                        oBE_NIVEL_PUESTO.CODIGO = (int)BE_PUESTO.PUESTO_NIVEL.Presidencia;
                        oBE_NIVEL_PUESTO.DESCRIPCION = BE_PUESTO.PUESTO_NIVEL.Presidencia.ToString();
                    }
                    else if (oPuesto.NIVEL == (int)BE_PUESTO.PUESTO_NIVEL.Gerencia)
                    {
                        oBE_NIVEL_PUESTO.CODIGO = (int)BE_PUESTO.PUESTO_NIVEL.Gerencia;
                        oBE_NIVEL_PUESTO.DESCRIPCION = BE_PUESTO.PUESTO_NIVEL.Gerencia.ToString();
                    }
                    else if (oPuesto.NIVEL == (int)BE_PUESTO.PUESTO_NIVEL.Area)
                    {
                        oBE_NIVEL_PUESTO.CODIGO = (int)BE_PUESTO.PUESTO_NIVEL.Area;
                        oBE_NIVEL_PUESTO.DESCRIPCION = BE_PUESTO.PUESTO_NIVEL.Area.ToString();
                    }
                    else if (oPuesto.NIVEL == (int)BE_PUESTO.PUESTO_NIVEL.Coordinacion)
                    {
                        oBE_NIVEL_PUESTO.CODIGO = (int)BE_PUESTO.PUESTO_NIVEL.Coordinacion;
                        oBE_NIVEL_PUESTO.DESCRIPCION = BE_PUESTO.PUESTO_NIVEL.Coordinacion.ToString();
                    }
                    else
                    {
                        oBE_NIVEL_PUESTO.CODIGO = 0;
                        oBE_NIVEL_PUESTO.DESCRIPCION = string.Empty;
                    }

                    oPuesto.oBE_NIVEL_PUESTO = oBE_NIVEL_PUESTO;                            

                    wsMaestros.BE_EMPRESA[] oEmpresa = wsMantenimientoEstructuras.SeleccionarEmpresa();
                   
                    if (oEmpresa != null)
                    {
                        foreach (var itemEmpresa in oEmpresa)
                        {
                            BE_EMPRESA oBE_EMPRESA = new BE_EMPRESA();

                            if (oPuesto.EMPRESA_ID == itemEmpresa.ID)
                            {
                                oBE_EMPRESA.ID = itemEmpresa.ID;
                                oBE_EMPRESA.CODIGO = itemEmpresa.CODIGO;
                                oBE_EMPRESA.DESCRIPCION = itemEmpresa.DESCRIPCION;
                                oPuesto.oBE_EMPRESA = oBE_EMPRESA;
                            }                           

                        }
                    }

                    oListaPuesto.Add(oPuesto);

               }
            }
            return oListaPuesto;
           
        }

        /// <summary>
        ///  Devuelve los datos de todas los PUESTOS de una EMPRESA.
        /// </summary>
        /// <param name="empresa_id">Codigo del la Empresa de la cual se desea consultar sus gerencias</param>
        /// <returns> List de BE_PUESTO con los objetos de la entidad, que a su vez representan la tabla PUESTOS de la base de datos.En caso no haiga datos devuelve nothing </returns>
        public List<BE_PUESTO> SeleccionarPuesto(Guid empresa_id)
        {

            wsMaestros.BE_PUESTO[] oLista = wsMantenimientoEstructuras.SeleccionarPuestosPorEmpresa(empresa_id);
            List<BE_PUESTO> oListaPuesto = new List<BE_PUESTO>();
            if (oLista != null)
            {
                foreach (var item in oLista)
                {
                    BE_PUESTO oPuesto = new BE_PUESTO();
                    oPuesto.ID = item.ID;
                    oPuesto.CODIGO = item.CODIGO;
                    oPuesto.DESCRIPCION = item.DESCRIPCION;
                    oPuesto.USUARIO_CREACION = item.USUARIO_CREACION;
                    oPuesto.FECHA_CREACION = item.FECHA_CREACION;
                    oPuesto.USUARIO_ACTUALIZACION = item.USUARIO_ACTUALIZACION;
                    oPuesto.ESTADO = item.ESTADO;
                    oPuesto.NIVEL = item.NIVEL;

                    oListaPuesto.Add(oPuesto);

                }
            }
            return oListaPuesto;
        }

        /// <summary>
        ///  Devuelve los niveles de puestos
        /// </summary>       
        /// <returns> List de BE_NIVEL_PUESTO con los objetos de la entidad, que a su vez representan los niveles de puestos de la base de datos.En caso no existan datos devuelve nothing </returns>
        public static List<BE_NIVEL_PUESTO> SeleccionarNivelPuesto()
        {
            List<BE_NIVEL_PUESTO> oListaNivelPuesto = new List<BE_NIVEL_PUESTO>();

            BE_NIVEL_PUESTO oNivelPuesto_1 = new BE_NIVEL_PUESTO();
            oNivelPuesto_1.CODIGO = (int)BE_PUESTO.PUESTO_NIVEL.Presidencia;
            oNivelPuesto_1.DESCRIPCION = BE_PUESTO.PUESTO_NIVEL.Presidencia.ToString();
            oListaNivelPuesto.Add(oNivelPuesto_1);

            BE_NIVEL_PUESTO oNivelPuesto_2 = new BE_NIVEL_PUESTO();
            oNivelPuesto_2.CODIGO = (int)BE_PUESTO.PUESTO_NIVEL.Gerencia;
            oNivelPuesto_2.DESCRIPCION = BE_PUESTO.PUESTO_NIVEL.Gerencia.ToString();
            oListaNivelPuesto.Add(oNivelPuesto_2);

            BE_NIVEL_PUESTO oNivelPuesto_3 = new BE_NIVEL_PUESTO();
            oNivelPuesto_3.CODIGO = (int)BE_PUESTO.PUESTO_NIVEL.Area;
            oNivelPuesto_3.DESCRIPCION = BE_PUESTO.PUESTO_NIVEL.Area.ToString();
            oListaNivelPuesto.Add(oNivelPuesto_3);

            BE_NIVEL_PUESTO oNivelPuesto_4 = new BE_NIVEL_PUESTO();
            oNivelPuesto_4.CODIGO = (int)BE_PUESTO.PUESTO_NIVEL.Coordinacion;
            oNivelPuesto_4.DESCRIPCION = BE_PUESTO.PUESTO_NIVEL.Coordinacion.ToString();
            oListaNivelPuesto.Add(oNivelPuesto_4);

            return oListaNivelPuesto;

        }



        /// <summary>
        /// Inserta los datos de un Puesto
        /// </summary>
        /// <param name="oBE_PUESTO">Entidad BE_PUESTO, que representa la tabla PUESTOS, con todos sus atributos </param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean InsertarPuesto(BE_PUESTO oBE_PUESTO)
        {
            wsMaestros.BE_PUESTO oPuesto = new wsMaestros.BE_PUESTO();
            oPuesto.ID = oBE_PUESTO.ID;
            oPuesto.CODIGO = oBE_PUESTO.CODIGO;
            oPuesto.DESCRIPCION = oBE_PUESTO.DESCRIPCION;
            oPuesto.USUARIO_CREACION = oBE_PUESTO.USUARIO_CREACION;
            oPuesto.ESTADO = oBE_PUESTO.ESTADO;
            oPuesto.NIVEL = oBE_PUESTO.NIVEL;
            oPuesto.EMPRESA_ID = oBE_PUESTO.EMPRESA_ID;

            return wsMantenimientoEstructuras.InsertarPuesto(oPuesto);
             
        }

        /// <summary>
        /// Actualiza los datos de un Puesto
        /// </summary>
        /// <param name="oBE_PUESTO">Entidad BE_PUESTO, que representa la tabla PUESTOS, con todos sus atributos </param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean ActualizarPuesto(BE_PUESTO oBE_PUESTO)
        {
            wsMaestros.BE_PUESTO oPuesto = new wsMaestros.BE_PUESTO();
            oPuesto.ID = oBE_PUESTO.ID;
            oPuesto.CODIGO = oBE_PUESTO.CODIGO;
            oPuesto.DESCRIPCION = oBE_PUESTO.DESCRIPCION;
            oPuesto.USUARIO_CREACION = oBE_PUESTO.USUARIO_CREACION;
            oPuesto.ESTADO = oBE_PUESTO.ESTADO;
            oPuesto.NIVEL = oBE_PUESTO.NIVEL;
            oPuesto.EMPRESA_ID = oBE_PUESTO.EMPRESA_ID;

            return wsMantenimientoEstructuras.ActualizarPuesto(oPuesto);
        }

        /// <summary>
        /// Elimina los dato de un puesto
        /// </summary>
        /// <param name="puesto_id">Id del puesto que se desea eliminar</param>
        /// <returns>True o False. True, si se ingreso con exito. False, si hubo un error al ingresar</returns>
        public Boolean EliminarPuesto(Guid puesto_id)
        {
            return wsMantenimientoEstructuras.EliminarPuesto(puesto_id);
        }

    }
}
