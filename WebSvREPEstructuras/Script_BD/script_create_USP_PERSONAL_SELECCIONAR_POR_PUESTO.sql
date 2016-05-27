  
CREATE PROCEDURE [dbo].[USP_PERSONAL_SELECCIONAR_POR_PUESTO]      
/****************************************************************       
* Nombre SP: USP_PERSONAL_SELECCIONAR_GERENTES_POR_PUESTO      
* Propósito: Retorna los datos todos personas que pertenecen aun puesto  
* Input: @PUESTO_ID     
* Output: Numero de filas afectadas      
* Creado por: Silvia Benites   
* Fecha. Creación: 17/04/2015      
* Fecha. Actualización: Fecha de Actualización      
****************************************************************/      
@PUESTO_ID uniqueidentifier      
AS      
Select       
    PERSONAL_ID,       
    PERSONAL_CODIGO_TRABAJO,       
    PERSONAL_APELLIDO_PATERNO,       
    PERSONAL_APELLIDO_MATERNO,       
    PERSONAL_NOMBRES,     
    PERSONAL_SEDE,    
    PERSONAL_EMPRESA,  
    PERSONAL_GERENCIA,       
    PERSONAL_AREA,       
    PERSONAL_COORDINACION,      
    PERSONAL_PUESTO,     
    PERSONAL_GRUPO_ORGANIZACIONAL,    
    PERSONAL_CORREO,       
    USUARIO_CREACION,       
    FECHA_CREACION,       
    USUARIO_ACTUALIZACION,       
    FECHA_ACTUALIZACION,       
    PERSONAL_ESTADO     
From   PERSONAL      
where PERSONAL_PUESTO=@PUESTO_ID      
and PERSONAL_ESTADO = 1  