ALTER procedure [dbo].[USP_GERENCIA_SELECCIONAR_POR_ID]  
/****************************************************************   
* Nombre SP: USP_GERENCIA_SELECCIONAR_POR_ID  
* Propósito: devolver los datos de una GERENCIAS  
* Input:   
   
* Output: Una tupla de la tabla de gerencia   
* Creado por: Silvia Benites  
* Fecha. Creación: 20/11/2015  
* Fecha. Actualización: Fecha de Actualización  
****************************************************************/  
@GERENCIA_ID uniqueidentifier  
AS  
Select   
  GERENCIA_ID,  
  ISNULL(GERENCIA_CODIGO, '') AS GERENCIA_CODIGO,  
  GERENCIA_DESCRIPCION,  
  USUARIO_CREACION,  
  FECHA_CREACION,  
  USUARIO_ACTUALIZACION,  
  FECHA_ACTUALIZACION,  
  GERENCIA_ESTADO,  
  EMPRESA_ID
from   
  GERENCIAS  
where GERENCIA_ID=@GERENCIA_ID  