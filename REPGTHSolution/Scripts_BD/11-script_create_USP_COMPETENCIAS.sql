USE [BDREP_GTH]
GO
/****** Object:  StoredProcedure [dbo].[USP_COMPETENCIA_SELECCIONAR]    Script Date: 06/07/2016 11:37:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[USP_COMPETENCIA_SELECCIONAR]
/**************************************************************** 
* Nombre SP: USP_COMPETENCIA_SELECCIONAR
* Propósito: Devuelve todas las competencias.
* Input:
* Output: Lista de todas las competencias 
* Creado por: Miguel Vasquez
* Fecha. Creación: 27/04/2016
* Fecha. Actualización: Fecha de Actualización
****************************************************************/
as
Select 
		COMPETENCIA_ID,
		COMPETENCIA_CODIGO,
		COMPETENCIA_DESCRIPCION,
		COMPETENCIA_TIPO_ID, 
		COMPETENCIA_ESTADO,
		USUARIO_CREACION,
		FECHA_CREACION,
		USUARIO_ACTUALIZACION,
		FECHA_ACTUALIZACION
from 
		COMPETENCIAS
		
where COMPETENCIA_ESTADO=1
order by COMPETENCIA_TIPO_ID, COMPETENCIA_DESCRIPCION ASC

GO

CREATE procedure [dbo].[USP_COMPETENCIA_INSERTAR]  
/****************************************************************   
* Nombre SP: USP_COMPETENCIA_INSERTAR 
* Propósito: Inserta un registro en la tabla COMPETENCIAS  
* Input:   
   
* Output: Una tupla de la tabla de COMPETENCIAS   
* Creado por: Silvia Benites 
* Fecha. Creación: 05/04/2015  
* Fecha. Actualización: Fecha de Actualización  
****************************************************************/  
@COMPETENCIA_CODIGO varchar(50),
@COMPETENCIA_DESCRIPCION varchar(100),  
@COMPETENCIA_TIPO_ID uniqueidentifier,
@COMPETENCIA_ESTADO int,  
@USUARIO uniqueidentifier  
  
AS  
  
DECLARE @ID uniqueidentifier = NEWID();  
  
Insert into   
   COMPETENCIAS( COMPETENCIA_ID,
	  COMPETENCIA_CODIGO,
      COMPETENCIA_DESCRIPCION, 
      COMPETENCIA_TIPO_ID, 
      COMPETENCIA_ESTADO, 
      USUARIO_CREACION,   
      FECHA_CREACION,   
      USUARIO_ACTUALIZACION,   
      FECHA_ACTUALIZACION)  
Values     ( @ID, 
      @COMPETENCIA_CODIGO,  
      @COMPETENCIA_DESCRIPCION,  
      @COMPETENCIA_TIPO_ID,
      @COMPETENCIA_ESTADO, 
      @USUARIO,   
      GETDATE(),   
      @USUARIO,   
      GETDATE())
      
 GO

CREATE procedure [dbo].[USP_COMPETENCIA_ACTUALIZAR]  
/****************************************************************   
* Nombre SP: USP_COMPETENCIA_ACTUALIZAR  
* Propósito: Actualiza un registro en la tabla COMPETENCIAS  
* Input:   
  
* Output: La cantidad de registros actualizados  
* Creado por: Silvia Benites 
* Fecha. Creación: 05/04/2014  
* Fecha. Actualización: Fecha de Actualización  
****************************************************************/  
@COMPETENCIA_ID uniqueidentifier,  
@COMPETENCIA_CODIGO varchar(50),
@COMPETENCIA_DESCRIPCION varchar(100),  
@COMPETENCIA_TIPO_ID uniqueidentifier,
@COMPETENCIA_ESTADO int,  
@USUARIO uniqueidentifier
  
AS  
  
Update   
	  COMPETENCIAS set  
	  COMPETENCIA_CODIGO=@COMPETENCIA_CODIGO,
      COMPETENCIA_DESCRIPCION=@COMPETENCIA_DESCRIPCION,   
      COMPETENCIA_TIPO_ID=@COMPETENCIA_TIPO_ID,
      COMPETENCIA_ESTADO=@COMPETENCIA_ESTADO,
      USUARIO_ACTUALIZACION=@USUARIO,   
      FECHA_ACTUALIZACION=GetDate()   
        
where COMPETENCIA_ID=@COMPETENCIA_ID

GO

CREATE procedure [dbo].[USP_COMPETENCIA_ELIMINAR]  
/****************************************************************   
* Nombre SP: USP_COMPETENCIA_ELIMINAR  
* Propósito: Actualiza el campo Estado a Inactivo para un registro de la tabla Competencias 
* Input:   
  @COMPETENCIA_ID  
* Output: La cantidad de registros actualizados  
* Creado por: Silvia Benites
* Fecha. Creación: 05/04/2015  
* Actualizado por: Silvia Benites  
* Fecha. Actualización: 
****************************************************************/  
@COMPETENCIA_ID uniqueidentifier  
AS  
Update COMPETENCIAS
Set COMPETENCIA_ESTADO=0  
where COMPETENCIA_ID=@COMPETENCIA_ID

GO

CREATE procedure [dbo].[USP_COMPETENCIA_TIPO_SELECCIONAR_POR_ID]
/**************************************************************** 
* Nombre SP: USP_COMPETENCIA_TIPO_SELECCIONAR_POR_ID
* Propósito: Devuelve todas las competencias por tipos.
* Input: @COMPETENCIA_TIPO_ID
* Output: Lista de todas las competencias por tipo
* Creado por: Miguel Vasquez
* Fecha. Creación: 27/04/2016
* Fecha. Actualización: Fecha de Actualización
****************************************************************/
@COMPETENCIA_TIPO_ID UNIQUEIDENTIFIER  
as
Select 
		COMPETENCIA_TIPO_ID,
		COMPETENCIA_TIPO_CODIGO,
		COMPETENCIA_TIPO_DESCRIPCION,
		USUARIOS_CREACION,
		FECHA_CREACION,
		USUARIO_ACTUALIZACION,
		FECHA_ACTUALIZACION,
		COMPETENCIA_TIPO_ESTADO
from 
		COMPETENCIAS_TIPOS
		
where COMPETENCIA_TIPO_ID = @COMPETENCIA_TIPO_ID
AND COMPETENCIA_TIPO_ESTADO=1
GO

