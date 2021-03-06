USE [BDREP_GTH]
GO
/****** Object:  StoredProcedure [dbo].[USP_COMPETENCIA_TRANSVERSAL_SELECCIONAR]    Script Date: 06/07/2016 11:37:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[USP_COMPETENCIA_TRANSVERSAL_SELECCIONAR]
/**************************************************************** 
* Nombre SP: USP_COMPETENCIA_TRANSVERSAL_SELECCIONAR
* Propósito: Devuelve todas las competencias transversales.
* Input:
* Output: Lista de todas las competencias por tipo
* Creado por: Miguel Vasquez
* Fecha. Creación: 27/04/2016
* Fecha. Actualización: Fecha de Actualización
****************************************************************/
as
Select 
		COMPETENCIA_TRANSVERSAL_ID,
		COMPETENCIA_TRANSVERSAL_CODIGO,
		COMPETENCIA_TRANSVERSAL_DESCRIPCION,
		COMPETENCIA_TRANSVERSAL_ESTADO,
		USUARIO_CREACION,
		FECHA_CREACION,
		USUARIO_ACTUALIZACION,
		FECHA_ACTUALIZACION
from 
		COMPETENCIAS_TRANSVERSALES
		
where COMPETENCIA_TRANSVERSAL_ESTADO=1

GO

CREATE procedure [dbo].[USP_COMPETENCIA_TRANSVERSAL_INSERTAR]  
/****************************************************************   
* Nombre SP: USP_COMPETENCIA_TRANSVERSAL_INSERTAR 
* Propósito: Inserta un registro en la tabla COMPETENCIAS_TRANSVERSALES  
* Input:   
   
* Output: Una tupla de la tabla de COMPETENCIA_TRANSVERSAL   
* Creado por: Silvia Benites 
* Fecha. Creación: 05/04/2015  
* Fecha. Actualización: Fecha de Actualización  
****************************************************************/  
@COMPETENCIA_TRANSVERSAL_CODIGO varchar(50),
@COMPETENCIA_TRANSVERSAL_DESCRIPCION varchar(100),  
@COMPETENCIA_TRANSVERSAL_ESTADO int,  
@USUARIO uniqueidentifier  
  
AS  
  
DECLARE @ID uniqueidentifier = NEWID();  
  
Insert into   
   COMPETENCIAS_TRANSVERSALES( COMPETENCIA_TRANSVERSAL_ID,
	  COMPETENCIA_TRANSVERSAL_CODIGO,
      COMPETENCIA_TRANSVERSAL_DESCRIPCION,  
      COMPETENCIA_TRANSVERSAL_ESTADO, 
      USUARIO_CREACION,   
      FECHA_CREACION,   
      USUARIO_ACTUALIZACION,   
      FECHA_ACTUALIZACION)  
Values     ( @ID, 
      @COMPETENCIA_TRANSVERSAL_CODIGO,  
      @COMPETENCIA_TRANSVERSAL_DESCRIPCION,  
      @COMPETENCIA_TRANSVERSAL_ESTADO, 
      @USUARIO,   
      GETDATE(),   
      @USUARIO,   
      GETDATE())
      
 GO

CREATE procedure [dbo].[USP_COMPETENCIA_TRANSVERSAL_ACTUALIZAR]  
/****************************************************************   
* Nombre SP: USP_COMPETENCIA_TRANSVERSAL_ACTUALIZAR  
* Propósito: Actualiza un registro en la tabla Empresas  
* Input:   
  
* Output: La cantidad de registros actualizados  
* Creado por: Silvia Benites 
* Fecha. Creación: 05/04/2014  
* Fecha. Actualización: Fecha de Actualización  
****************************************************************/  
@COMPETENCIA_TRANSVERSAL_ID uniqueidentifier,  
@COMPETENCIA_TRANSVERSAL_CODIGO varchar(50),
@COMPETENCIA_TRANSVERSAL_DESCRIPCION varchar(100),  
@COMPETENCIA_TRANSVERSAL_ESTADO int,  
@USUARIO uniqueidentifier
  
AS  
  
Update   
	  COMPETENCIAS_TRANSVERSALES set  
	  COMPETENCIA_TRANSVERSAL_CODIGO=@COMPETENCIA_TRANSVERSAL_CODIGO,
      COMPETENCIA_TRANSVERSAL_DESCRIPCION=@COMPETENCIA_TRANSVERSAL_DESCRIPCION,   
      USUARIO_ACTUALIZACION=@USUARIO,   
      FECHA_ACTUALIZACION=GetDate(),   
      COMPETENCIA_TRANSVERSAL_ESTADO=@COMPETENCIA_TRANSVERSAL_ESTADO  
where COMPETENCIA_TRANSVERSAL_ID=@COMPETENCIA_TRANSVERSAL_ID

GO

CREATE procedure [dbo].[USP_COMPETENCIA_TRANSVERSAL_ELIMINAR]  
/****************************************************************   
* Nombre SP: USP_COMPETENCIA_TRANSVERSAL_ELIMINAR  
* Propósito: Actualiza el campo Estado a Inactivo para un registro de la tabla Competencias Transversales  
* Input:   
  @COMPETENCIA_TRANSVERSAL_ID  
* Output: La cantidad de registros actualizados  
* Creado por: Silvia Benites
* Fecha. Creación: 05/04/2015  
* Actualizado por: Silvia Benites  
* Fecha. Actualización: 
****************************************************************/  
@COMPETENCIA_TRANSVERSAL_ID uniqueidentifier  
AS  
Update COMPETENCIAS_TRANSVERSALES  
Set COMPETENCIA_TRANSVERSAL_ESTADO=0  
where COMPETENCIA_TRANSVERSAL_ID=@COMPETENCIA_TRANSVERSAL_ID

GO
