USE [BDREP_ESTRUCTURAS]
GO
/****** Object:  StoredProcedure [dbo].[USP_PUESTO_SELECCIONAR_POR_EMPRESA]    Script Date: 06/05/2016 10:23:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

GO
ALTER procedure [dbo].[USP_PUESTO_SELECCIONAR_POR_EMPRESA]
/**************************************************************** 
* Nombre SP: USP_PUESTO_SELECCIONAR_POR_EMPRESA
* Propósito: devolver los datos de todos los puestos por EMPRESA
* Input: 
	@EMPRESA_ID
* Output: Una tupla de la tabla de puesto 
* Creado por: Silvia Benites
* Fecha. Creación: 17/04/2015
* Fecha. Actualización: Fecha de Actualización
****************************************************************/
@EMPRESA_ID uniqueidentifier
AS
Select 
		P.PUESTO_ID,
		ISNULL(P.PUESTO_CODIGO, '') AS PUESTO_CODIGO,
		P.PUESTO_DESCRIPCION,
		P.PUESTO_NIVEL,
		P.PUESTO_ESTADO,
		P.USUARIO_CREACION,
		P.FECHA_CREACION,
		P.USUARIO_ACTUALIZACION,
		P.FECHA_ACTUALIZACION,
		P.EMPRESA_ID		
from 
		PUESTOS P		
where	P.EMPRESA_ID=@EMPRESA_ID
AND		P.PUESTO_ESTADO = 1

GO
ALTER procedure [dbo].[USP_PUESTO_SELECCIONAR_POR_GERENCIA]
/**************************************************************** 
* Nombre SP: USP_PUESTO_SELECCIONAR_POR_GERENCIA
* Propósito: devolver los datos de todos los puestos por GERENCIA
* Input: 
	@GERENCIA_ID
* Output: Una tupla de la tabla de puesto 
* Creado por: Silvia Benites
* Fecha. Creación: 17/04/2015
* Fecha. Actualización: Fecha de Actualización
****************************************************************/
@GERENCIA_ID uniqueidentifier
AS
Select 
		P.PUESTO_ID,
		ISNULL(P.PUESTO_CODIGO, '') AS PUESTO_CODIGO,
		P.PUESTO_DESCRIPCION,
		P.PUESTO_NIVEL,
		P.PUESTO_ESTADO,
		P.USUARIO_CREACION,
		P.FECHA_CREACION,
		P.USUARIO_ACTUALIZACION,
		P.FECHA_ACTUALIZACION,
		P.EMPRESA_ID
from 
		PERSONAL CP INNER JOIN PUESTOS P
		ON CP.PERSONAL_PUESTO = P.PUESTO_ID
where	CP.PERSONAL_GERENCIA=@GERENCIA_ID
AND P.PUESTO_ESTADO = 1
GROUP BY P.PUESTO_ID, P.PUESTO_CODIGO, P.PUESTO_DESCRIPCION, P.PUESTO_NIVEL, P.PUESTO_ESTADO,
P.USUARIO_CREACION, P.FECHA_CREACION, P.USUARIO_ACTUALIZACION, P.FECHA_ACTUALIZACION, P.EMPRESA_ID
GO

ALTER procedure [dbo].[USP_PUESTO_SELECCIONAR_POR_AREA]
/**************************************************************** 
* Nombre SP: USP_PUESTO_SELECCIONAR_POR_AREA
* Propósito: devolver los datos de todos los puestos por AREA
* Input: 
	@AREA_ID
* Output: Una tupla de la tabla de puesto 
* Creado por: Silvia Benites
* Fecha. Creación: 17/04/2015
* Fecha. Actualización: Fecha de Actualización
****************************************************************/
@AREA_ID uniqueidentifier
AS
Select 
		P.PUESTO_ID,
		ISNULL(P.PUESTO_CODIGO, '') AS PUESTO_CODIGO,
		P.PUESTO_DESCRIPCION,
		P.PUESTO_NIVEL,
		P.PUESTO_ESTADO,
		P.USUARIO_CREACION,
		P.FECHA_CREACION,
		P.USUARIO_ACTUALIZACION,
		P.FECHA_ACTUALIZACION,
		P.EMPRESA_ID
from 
		PERSONAL CP INNER JOIN PUESTOS P
		ON CP.PERSONAL_PUESTO = P.PUESTO_ID
where	CP.PERSONAL_AREA=@AREA_ID
AND P.PUESTO_ESTADO = 1
GROUP BY P.PUESTO_ID, P.PUESTO_CODIGO, P.PUESTO_DESCRIPCION, P.PUESTO_NIVEL, P.PUESTO_ESTADO,
P.USUARIO_CREACION, P.FECHA_CREACION, P.USUARIO_ACTUALIZACION, P.FECHA_ACTUALIZACION, P.EMPRESA_ID

GO

ALTER procedure [dbo].[USP_PUESTO_SELECCIONAR_POR_COORDINACION]
/**************************************************************** 
* Nombre SP: USP_PUESTO_SELECCIONAR_POR_COORDINACION
* Propósito: devolver los datos de todos los puestos por COORDINACION
* Input: 
	@COORDINACION_ID
* Output: Una tupla de la tabla de puesto 
* Creado por: Silvia Benites
* Fecha. Creación: 17/04/2015
* Fecha. Actualización: Fecha de Actualización
****************************************************************/
@COORDINACION_ID uniqueidentifier
AS
Select 
		P.PUESTO_ID,
		ISNULL(P.PUESTO_CODIGO, '') AS PUESTO_CODIGO,
		P.PUESTO_DESCRIPCION,
		P.PUESTO_NIVEL,
		P.PUESTO_ESTADO,
		P.USUARIO_CREACION,
		P.FECHA_CREACION,
		P.USUARIO_ACTUALIZACION,
		P.FECHA_ACTUALIZACION,
		P.EMPRESA_ID
from 
		PERSONAL CP INNER JOIN PUESTOS P
		ON CP.PERSONAL_PUESTO = P.PUESTO_ID
where	CP.PERSONAL_COORDINACION=@COORDINACION_ID
AND P.PUESTO_ESTADO = 1
AND P.PUESTO_NIVEL = 4
GROUP BY P.PUESTO_ID, P.PUESTO_CODIGO, P.PUESTO_DESCRIPCION, P.PUESTO_NIVEL, P.PUESTO_ESTADO,
P.USUARIO_CREACION, P.FECHA_CREACION, P.USUARIO_ACTUALIZACION, P.FECHA_ACTUALIZACION, P.EMPRESA_ID
GO

ALTER procedure [dbo].[USP_PUESTO_SELECCIONAR_POR_PRESIDENCIA]
/**************************************************************** 
* Nombre SP: USP_PUESTO_SELECCIONAR_POR_PRESIDENCIA
* Propósito: devolver los datos de todos los puestos por PRESIDENCIA
* Input: 
	@PRESIDENCIA_ID
* Output: Una tupla de la tabla de puesto 
* Creado por: Silvia Benites
* Fecha. Creación: 17/04/2015
* Fecha. Actualización: Fecha de Actualización
****************************************************************/
@PRESIDENCIA_ID uniqueidentifier
AS
DECLARE @ID_GO_GERENTES uniqueidentifier = '5EBA5079-A82B-4296-B75F-12E48AF04802';  
DECLARE @EMPRESA_ID uniqueidentifier = (SELECT EMPRESA_ID FROM PRESIDENCIAS WHERE PRESIDENCIA_ID = @PRESIDENCIA_ID);
Select 
		P.PUESTO_ID,
		ISNULL(P.PUESTO_CODIGO, '') AS PUESTO_CODIGO,
		P.PUESTO_DESCRIPCION,
		P.PUESTO_NIVEL,
		P.PUESTO_ESTADO,
		P.USUARIO_CREACION,
		P.FECHA_CREACION,
		P.USUARIO_ACTUALIZACION,
		P.FECHA_ACTUALIZACION,
		P.EMPRESA_ID
from 
		PERSONAL CP INNER JOIN PUESTOS P
		ON CP.PERSONAL_PUESTO = P.PUESTO_ID
where	CP.PERSONAL_EMPRESA = @EMPRESA_ID 
AND CP.PERSONAL_GRUPO_ORGANIZACIONAL=@ID_GO_GERENTES
AND P.PUESTO_ESTADO = 1
GO
ALTER procedure [dbo].[USP_PUESTO_SELECCIONAR]
/**************************************************************** 
* Nombre SP: USP_PUESTO_SELECCIONAR
* Propósito: devolver los datos de todas los puestos
* Input: Ninguno
* Output: Tabla con la lista de todas los puestos
* Creado por: Silvia Benites
* Modificado por: 
* Fecha. Creación: 17/04/2016
* Fecha. Actualización: Fecha de Actualización
****************************************************************/
AS
Select 
		PUESTO_ID,
		PUESTO_CODIGO,		
		PUESTO_DESCRIPCION,
		PUESTO_NIVEL,
		PUESTO_ESTADO,
		USUARIO_CREACION,
		FECHA_CREACION,
		USUARIO_ACTUALIZACION,
		FECHA_ACTUALIZACION,
		EMPRESA_ID
from 
		PUESTOS
		where PUESTO_ESTADO=1
Order by PUESTO_DESCRIPCION
GO
ALTER procedure [dbo].[USP_PUESTO_SELECCIONAR_POR_ID]
/**************************************************************** 
* Nombre SP: USP_PUESTO_SELECCIONAR_POR_ID
* Propósito: devolver los datos de todos los puestos por ID
* Input: 
	@PUESTO_ID
* Output: Una tupla de la tabla de puesto 
* Creado por: Silvia Benites
* Fecha. Creación: 17/04/2015
* Fecha. Actualización: Fecha de Actualización
****************************************************************/
@PUESTO_ID uniqueidentifier
AS
Select 
		P.PUESTO_ID,
		ISNULL(P.PUESTO_CODIGO, '') AS PUESTO_CODIGO,
		P.PUESTO_DESCRIPCION,
		P.PUESTO_NIVEL,
		P.PUESTO_ESTADO,
		P.USUARIO_CREACION,
		P.FECHA_CREACION,
		P.USUARIO_ACTUALIZACION,
		P.FECHA_ACTUALIZACION,
		P.EMPRESA_ID		
from 
		PUESTOS P		
where	P.PUESTO_ID=@PUESTO_ID
AND P.PUESTO_ESTADO = 1
GO
ALTER procedure [dbo].[USP_PUESTO_INSERTAR]  
/****************************************************************   
* Nombre SP: USP_PUESTO_INSERTAR
* Propósito: Inserta un registro en la tabla PUESTOS 
* Input:   
   @PUESTO_CODIGO,
   @PUESTO_DESCRIPCION,
   @PUESTO_NIVEL,
   @PUESTO_ESTADO
   @USUARIO   
   @EMPRESA_ID
* Output: Una tupla de la tabla de PUESTOS   
* Creado por: Silvia Benites 
* Fecha. Creación: 17/04/2016  
* Fecha. Actualización: Fecha de Actualización  
****************************************************************/  
@PUESTO_CODIGO varchar(50),
@PUESTO_DESCRIPCION varchar(100), 
@PUESTO_NIVEL int, 
@PUESTO_ESTADO int, 
@USUARIO uniqueidentifier,
@EMPRESA_ID uniqueidentifier
  
AS  
  
DECLARE @ID uniqueidentifier = NEWID();  

INSERT INTO PUESTOS(PUESTO_ID,
	PUESTO_CODIGO,
	PUESTO_DESCRIPCION,
	PUESTO_NIVEL,
	PUESTO_ESTADO,
	USUARIO_CREACION,
	FECHA_CREACION,
	USUARIO_ACTUALIZACION,
	FECHA_ACTUALIZACION,
	EMPRESA_ID)  
Values     ( @ID, 
      @PUESTO_CODIGO,  
      @PUESTO_DESCRIPCION, 
      @PUESTO_NIVEL,  
      @PUESTO_ESTADO,
      @USUARIO,   
      GETDATE(),   
      @USUARIO,   
      GETDATE(),
      @EMPRESA_ID)
GO

ALTER procedure [dbo].[USP_PUESTO_ACTUALIZAR]  
/****************************************************************   
* Nombre SP: USP_PUESTO_ACTUALIZAR  
* Propósito: Actualiza un registro en la tabla Puestos  
* Input:   
  @PUESTO_ID, @PUESTO_CODIGO, @PUESTO_DESCRIPCION,@PUESTO_NIVEL, @PUESTO_ESTADO, @USUARIO  
* Output: La cantidad de registros actualizados  
* Creado por: Silvia Benites 
* Fecha. Creación: 17/04/2015
* Fecha. Actualización: Fecha de Actualización  
****************************************************************/  
@PUESTO_ID uniqueidentifier,  
@PUESTO_CODIGO varchar(50),
@PUESTO_DESCRIPCION varchar(100),
@PUESTO_NIVEL int,  
@PUESTO_ESTADO int,
@USUARIO uniqueidentifier,
@EMPRESA_ID uniqueidentifier
  
AS  
  
Update   
   PUESTOS set  
	  PUESTO_CODIGO=@PUESTO_CODIGO,
      PUESTO_DESCRIPCION=@PUESTO_DESCRIPCION, 
      PUESTO_NIVEL = @PUESTO_NIVEL,
      PUESTO_ESTADO=@PUESTO_ESTADO,     
      USUARIO_ACTUALIZACION=@USUARIO,   
      FECHA_ACTUALIZACION=GetDate(),
      EMPRESA_ID=@EMPRESA_ID
      
where  PUESTO_ID=@PUESTO_ID

GO