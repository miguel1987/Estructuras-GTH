GO
create PROCEDURE [dbo].[USP_PERFILES_SELECCIONAR_POR_ID]  
/****************************************************************   
* Nombre SP: USP_PERFILES_SELECCIONAR_POR_ID  
* Propósito: Devolver los datos de un Perfil  
* Input:  
* Output: Un perfil en especifico  
* Creado por: Silvia Benites
* Fecha. Creación: 05/04/2015  
* Fecha. Actualización: Fecha de Actualización  
****************************************************************/  
@PERFIL_ID AS INT  
AS  
SELECT  PERFIL_ID ,  
        PERFIL_DESCRIPCION   
FROM PERFILES  
WHERE PERFIL_ID=@PERFIL_ID
GO
GO
CREATE PROCEDURE [dbo].[USP_PERFILES_SELECCIONAR]  
/****************************************************************   
* Nombre SP: USP_PERFILES_SELECCIONAR  
* Propósito: Devolver los datos de todos los Perfiles  
* Input:  
* Output: Tabla con la lista de todos los Perfiles  
* Creado por: Silvia Benites 
* Fecha. Creación: 05/04/2015  
* Fecha. Actualización: Fecha de Actualización  
****************************************************************/  
AS  
SELECT  PERFIL_ID ,  
        PERFIL_DESCRIPCION FROM PERFILES
GO
