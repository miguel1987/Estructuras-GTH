USE [BDREP_GTH]
GO
/****** Object:  StoredProcedure [dbo].[USP_COMPETENCIA_PUESTO_SELECCIONAR]    Script Date: 06/07/2016 11:37:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[USP_COMPETENCIA_PUESTO_SELECCIONAR]
/**************************************************************** 
* Nombre SP: USP_COMPETENCIA_PUESTO_SELECCIONAR
* Propósito: Devuelve todas las competencias puesto.
* Input:
* Output: Lista de todas las competencias 
* Creado por: Miguel Vasquez
* Fecha. Creación: 27/04/2016
* Fecha. Actualización: Fecha de Actualización
****************************************************************/
as
Select 
		CP.COMPETENCIA_PUESTO_ID,
		CP.PUESTO_ID,
		CP.COMPETENCIA_ID,
		C.COMPETENCIA_DESCRIPCION,
		CP.COMPETENCIA_PUESTO_VALOR_REQUERIDO,
		CP.USUARIO_CREACION,
		CP.FECHA_CREACION,
		CP.USUARIO_ACTUALIZACION,
		CP.FECHA_ACTUALIZACION
from 
		COMPETENCIAS_PUESTOS CP INNER JOIN COMPETENCIAS C
		ON CP.COMPETENCIA_ID = C.COMPETENCIA_ID

order by PUESTO_ID ASC

GO

CREATE procedure [dbo].[USP_COMPETENCIA_PUESTO_INSERTAR]  
/****************************************************************   
* Nombre SP: USP_COMPETENCIA_PUESTO_INSERTAR 
* Propósito: Inserta un registro en la tabla COMPETENCIAS_PUESTOS  
* Input:   
   
* Output: Una tupla de la tabla de COMPETENCIAS_PUESTOS   
* Creado por: Silvia Benites 
* Fecha. Creación: 05/04/2015  
* Fecha. Actualización: Fecha de Actualización  
****************************************************************/  
@PUESTO_ID uniqueidentifier,
@COMPETENCIA_ID uniqueidentifier,
@COMPETENCIA_PUESTO_VALOR_REQUERIDO int,  
@USUARIO uniqueidentifier  
  
AS  
  
DECLARE @ID uniqueidentifier = NEWID();  
  
Insert into   
   COMPETENCIAS_PUESTOS(COMPETENCIA_PUESTO_ID,
	  PUESTO_ID,
      COMPETENCIA_ID, 
      COMPETENCIA_PUESTO_VALOR_REQUERIDO,       
      USUARIO_CREACION,   
      FECHA_CREACION,   
      USUARIO_ACTUALIZACION,   
      FECHA_ACTUALIZACION)  
Values     ( @ID, 
      @PUESTO_ID,  
      @COMPETENCIA_ID,  
      @COMPETENCIA_PUESTO_VALOR_REQUERIDO,
      @USUARIO,   
      GETDATE(),   
      @USUARIO,   
      GETDATE())
      
 GO

CREATE procedure [dbo].[USP_COMPETENCIA_PUESTO_ACTUALIZAR]  
/****************************************************************   
* Nombre SP: USP_COMPETENCIA_PUESTO_ACTUALIZAR  
* Propósito: Actualiza un registro en la tabla COMPETENCIAS_PUESTOS 
* Input:   
  
* Output: La cantidad de registros actualizados  
* Creado por: Silvia Benites 
* Fecha. Creación: 05/04/2014  
* Fecha. Actualización: Fecha de Actualización  
****************************************************************/  
@COMPETENCIA_PUESTO_ID uniqueidentifier,  
@PUESTO_ID uniqueidentifier, 
@COMPETENCIA_ID uniqueidentifier,
@COMPETENCIA_PUESTO_VALOR_REQUERIDO int,  
@USUARIO uniqueidentifier
  
AS  
  
Update   
	  COMPETENCIAS_PUESTOS set  
	  PUESTO_ID=@PUESTO_ID,
      COMPETENCIA_ID=@COMPETENCIA_ID,   
      COMPETENCIA_PUESTO_VALOR_REQUERIDO=@COMPETENCIA_PUESTO_VALOR_REQUERIDO,
      USUARIO_ACTUALIZACION=@USUARIO,   
      FECHA_ACTUALIZACION=GetDate()   
        
where COMPETENCIA_PUESTO_ID=@COMPETENCIA_PUESTO_ID

GO

CREATE procedure [dbo].[USP_COMPETENCIA_PUESTO_ELIMINAR]  
/****************************************************************   
* Nombre SP: USP_COMPETENCIA_PUESTO_ELIMINAR  
* Propósito: Elimina un registro de la tabla Competencias Puestos
* Input:   
  @COMPETENCIA_PUESTO_ID  
* Output: La cantidad de registros actualizados  
* Creado por: Silvia Benites
* Fecha. Creación: 05/04/2015  
* Actualizado por: Silvia Benites  
* Fecha. Actualización: 
****************************************************************/  
@COMPETENCIA_PUESTO_ID uniqueidentifier  
AS  
Delete COMPETENCIAS_PUESTOS
where COMPETENCIA_PUESTO_ID=@COMPETENCIA_PUESTO_ID

GO
