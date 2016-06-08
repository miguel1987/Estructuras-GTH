GO
CREATE PROCEDURE [dbo].[USP_USUARIO_SELECCIONAR]  
/****************************************************************   
* Nombre SP: USP_USUARIO_SELECCIONAR  
* Propósito: Devolver los datos de un Usuario  
* Input:  
* Output: Un perfil en especifico  
* Creado por: Silvia Benites
* Fecha. Creación: 05/04/2015  
* Fecha. Actualización: Fecha de Actualización  
****************************************************************/  
AS  
SELECT  USUARIO_ID,  
        PERSONAL_ID,
        PERFIL_ID,
        USUARIO_CREACION,
        FECHA_CREACION,
        USUARIO_ACTUALIZACION,
        FECHA_ACTUALIZACION
    
FROM USUARIOS
GO
CREATE procedure [dbo].[USP_USUARIO_INSERTAR]  
/****************************************************************   
* Nombre SP: USP_USUARIO_INSERTAR  
* Propósito: Inserta un registro en la tabla Usuarios  
* Input:   
   
* Output: Una tupla de la tabla de gerencia   
* Creado por: Silvia Benites  
* Fecha. Creación: 05/04/2015  
* Fecha. Actualización: Fecha de Actualización  
****************************************************************/  
@PERSONAL_ID uniqueidentifier, 
@PERFIL_ID int, 
@USUARIO uniqueidentifier  
  
AS  
  
DECLARE @ID uniqueidentifier = NEWID();  
  
Insert into   
   USUARIOS( USUARIO_ID,   
      PERSONAL_ID,   
      PERFIL_ID,
      USUARIO_CREACION,   
      FECHA_CREACION,   
      USUARIO_ACTUALIZACION,   
      FECHA_ACTUALIZACION)  
Values     ( @ID,   
      @PERSONAL_ID,   
      @PERFIL_ID,
      @USUARIO,   
      GETDATE(),   
      @USUARIO,   
      GETDATE())
GO
CREATE procedure [dbo].[USP_USUARIO_ELIMINAR_POR_PERSONAL]    
/****************************************************************     
* Nombre SP: USP_USUARIO_ELIMINAR_POR_PERSONAL    
* Propósito: Eliminar un registro en la tabla Usuario    
* Input:     
  @PERSONAL_ID   
* Output: La cantidad de registros actualizados    
* Creado por: Silvia Benites    
* Fecha. Creación: 25/05/2015    
* Fecha. Actualización: Fecha de Actualización    
****************************************************************/    
@PERSONAL_ID uniqueidentifier  
AS     
    
Delete     
      USUARIOS   
Where  PERSONAL_ID=@PERSONAL_ID
GO
CREATE procedure [dbo].[USP_USUARIO_ELIMINAR]  
/****************************************************************   
* Nombre SP: USP_USUARIO_ELIMINAR  
* Propósito: Eliminar un registro en la tabla Usuario  
* Input:   
  @USUARIO_ID 
* Output: La cantidad de registros actualizados  
* Creado por: Silvia Benites  
* Fecha. Creación: 05/04/2015  
* Fecha. Actualización: Fecha de Actualización  
****************************************************************/  
@USUARIO_ID uniqueidentifier
AS   
  
Delete   
      USUARIOS 
Where  USUARIO_ID=@USUARIO_ID
GO
CREATE procedure [dbo].[USP_USUARIO_ACTUALIZAR]  
/****************************************************************   
* Nombre SP: USP_USUARIO_ACTUALIZAR  
* Propósito: Actualiza un registro en la tabla Usuario  
* Input:   
  @USUARIO_ID, @PERSONAL_ID, @PERFIL_ID,@USUARIO  
* Output: La cantidad de registros actualizados  
* Creado por: Silvia Benites  
* Fecha. Creación: 05/04/2015  
* Fecha. Actualización: Fecha de Actualización  
****************************************************************/  
@USUARIO_ID uniqueidentifier,  
@PERSONAL_ID uniqueidentifier,    
@PERFIL_ID int,
@USUARIO uniqueidentifier  
  
AS  
  
  
  
Update   
      USUARIOS 
set  
      PERSONAL_ID=@PERSONAL_ID,   
      PERFIL_ID=@PERFIL_ID,
      USUARIO_ACTUALIZACION=@USUARIO,   
      FECHA_ACTUALIZACION=GetDate()  
where  USUARIO_ID=@USUARIO_ID
GO