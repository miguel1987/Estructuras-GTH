GO  
CREATE PROCEDURE [dbo].[USP_PERSONAL_SELECCIONAR_POR_SEDE]      
/****************************************************************       
* Nombre SP: USP_PERSONAL_SELECCIONAR_POR_SEDE   
* Prop�sito: Retorna los datos todos los colaboradores de una sede
* Input: @SEDE_ID     
* Output: Numero de filas afectadas      
* Creado por: Silvia Benites   
* Fecha. Creaci�n: 17/04/2015      
* Fecha. Actualizaci�n: Fecha de Actualizaci�n      
****************************************************************/      
@SEDE_ID uniqueidentifier      
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
where PERSONAL_SEDE=@SEDE_ID      
and PERSONAL_ESTADO = 1  

GO

CREATE PROCEDURE [dbo].[USP_PERSONAL_SELECCIONAR_POR_GRUPO_ORGANIZACIONAL]      
/****************************************************************       
* Nombre SP: USP_PERSONAL_SELECCIONAR_POR_GRUPO_ORGANIZACIONAL   
* Prop�sito: Retorna los datos todos los colaboradores de una sede
* Input: @GRUPO_ORGANIZACIONAL_ID     
* Output: Numero de filas afectadas      
* Creado por: Silvia Benites   
* Fecha. Creaci�n: 17/04/2015      
* Fecha. Actualizaci�n: Fecha de Actualizaci�n      
****************************************************************/      
@GRUPO_ORGANIZACIONAL_ID uniqueidentifier      
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
where PERSONAL_GRUPO_ORGANIZACIONAL=@GRUPO_ORGANIZACIONAL_ID      
and PERSONAL_ESTADO = 1  
GO