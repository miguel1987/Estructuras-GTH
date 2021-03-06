USE [BDREP_ESTRUCTURAS]
GO
Create procedure [dbo].[USP_COORDINACION_INSERTAR]
/**************************************************************** 
* Nombre SP: USP_COORDINACION_INSERTAR
* Propósito: Inserta los datos de una Coordinacion
* Input: 
		@AREA_ID,
		@COORDINACION_CODIGO,
		@COORDINACION_DESCRIPCION,
		@USUARIO,
		@COORDINACION_ESTADO
* Output: Numero de registros afectados
* Creado por: Silvia Benites
* Fecha. Creación: 19/11/2015
* Fecha. Actualización: Fecha de Actualización
****************************************************************/
@AREA_ID					uniqueidentifier,
@COORDINACION_CODIGO		varchar(50),
@COORDINACION_DESCRIPCION	varchar(100),
@USUARIO					uniqueidentifier,
@COORDINACION_ESTADO		int
AS

DECLARE @ID uniqueidentifier = NEWID();
Insert Into 
			COORDINACIONES(
					COORDINACION_ID,					
					COORDINACION_CODIGO,
					COORDINACION_DESCRIPCION,
					COORDINACION_ESTADO,
					USUARIO_CREACION,
					FECHA_CREACION,
					USUARIO_ACTUALIZACION,
					FECHA_ACTUALIZACION,					
					AREA_ID
				)
values			(
					@ID,
					@COORDINACION_CODIGO,
					@COORDINACION_DESCRIPCION,
					@COORDINACION_ESTADO,
					@USUARIO,
					getdate(),
					@USUARIO,
					getdate(),
					@AREA_ID					
				)
				
GO
CREATE procedure [dbo].[USP_COORDINACION_ACTUALIZAR]
/**************************************************************** 
* Nombre SP: USP_COORDINACION_ACTUALIZAR
* Propósito: Actualiza los datos de una Coordinación
* Input:
		@COORDINACION_ID,
		@AREA_ID,
		@COORDINACION_CODIGO,
		@COORDINACION_DESCRIPCION,
		@USUARIO,
		@COORDINACION_ESTADO
* Output: Numero de registros afectados
* Creado por: Silvia Benites
* Fecha. Creación: 20/11/2015
* Fecha. Actualización: Fecha de Actualización
****************************************************************/
@COORDINACION_ID			uniqueidentifier,
@AREA_ID					uniqueidentifier,
@COORDINACION_CODIGO		varchar(50),
@COORDINACION_DESCRIPCION	varchar(100),
@USUARIO					uniqueidentifier,
@COORDINACION_ESTADO		int
AS
Update 
			COORDINACIONES set	
						AREA_ID					=@AREA_ID,
						COORDINACION_CODIGO		=@COORDINACION_CODIGO,
						COORDINACION_DESCRIPCION=@COORDINACION_DESCRIPCION,
						USUARIO_ACTUALIZACION	=@USUARIO,
						FECHA_ACTUALIZACION		=GETDATE(),
						COORDINACION_ESTADO		=@COORDINACION_ESTADO
where		COORDINACION_ID=@COORDINACION_ID
GO
CREATE procedure [dbo].[USP_COORDINACION_ELIMINAR]
/**************************************************************** 
* Nombre SP: USP_COORDINACION_ELIMINAR
* Propósito: Actualiza el campo Estado a Inactivo para un registro de la tabla COORDINACION
* Input:
		@COORDINACION_ID,
* Output: Numero de registros afectados
* Creado por: Silvia Benites
* Fecha. Creación: 20/11/2015
* Actualizado por: 
* Fecha. Actualización: 
****************************************************************/
@COORDINACION_ID	uniqueidentifier
AS
Update COORDINACIONES 
Set COORDINACION_ESTADO=0
where COORDINACION_ID=@COORDINACION_ID
GO
