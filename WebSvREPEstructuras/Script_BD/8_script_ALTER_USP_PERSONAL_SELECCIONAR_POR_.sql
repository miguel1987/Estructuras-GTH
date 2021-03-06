USE [BDREP_ESTRUCTURAS]
GO
/****** Object:  StoredProcedure [dbo].[USP_PERSONAL_SELECCIONAR_GERENTES_POR_PRESIDENCIA]    Script Date: 06/14/2016 19:37:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[USP_PERSONAL_SELECCIONAR_GERENTES_POR_PRESIDENCIA]      
/****************************************************************       
* Nombre SP: USP_PERSONAL_SELECCIONAR_GERENTES_POR_PRESIDENCIA     
* Propósito: Retorna los datos todos gerentes de una empresa  
* Input: @PRESIDENCIA_ID     
* Output: Numero de filas afectadas      
* Creado por: Silvia Benites   
* Fecha. Creación: 17/04/2015      
* Fecha. Actualización: Fecha de Actualización      
****************************************************************/      
@PRESIDENCIA_ID uniqueidentifier      
AS    
  
DECLARE @EMPRESA_ID uniqueidentifier = (SELECT EMPRESA_ID FROM PRESIDENCIAS WHERE PRESIDENCIA_ID = @PRESIDENCIA_ID);
DECLARE @GRUPO_ORGANIZACIONAL uniqueidentifier = '7B3C5BB8-F7F2-4240-9B08-60B1EB3EA39D';

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
where PERSONAL_EMPRESA=@EMPRESA_ID      
and PERSONAL_GRUPO_ORGANIZACIONAL='5EBA5079-A82B-4296-B75F-12E48AF04802'  
and PERSONAL_ESTADO = 1  
and PERSONAL_GRUPO_ORGANIZACIONAL != @GRUPO_ORGANIZACIONAL
GO
ALTER PROCEDURE [dbo].[USP_PERSONAL_SELECCIONAR_POR_EMPRESA]      
/****************************************************************       
* Nombre SP: USP_PERSONAL_SELECCIONAR_GERENTES_POR_EMPRESA      
* Propósito: Retorna los datos todos gerentes de una empresa  
* Input: @EMPRESA_ID     
* Output: Numero de filas afectadas      
* Creado por: Silvia Benites   
* Fecha. Creación: 17/04/2015      
* Fecha. Actualización: Fecha de Actualización      
****************************************************************/      
@EMPRESA_ID uniqueidentifier      
AS      
DECLARE @GRUPO_ORGANIZACIONAL uniqueidentifier = '7B3C5BB8-F7F2-4240-9B08-60B1EB3EA39D';

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
where PERSONAL_EMPRESA=@EMPRESA_ID      
and PERSONAL_ESTADO = 1  
and PERSONAL_GRUPO_ORGANIZACIONAL != @GRUPO_ORGANIZACIONAL
GO

ALTER PROCEDURE [dbo].[USP_PERSONAL_SELECCIONAR_POR_GERENCIA]    
/****************************************************************     
* Nombre SP: USP_PERSONAL_SELECCIONAR_POR_GERENCIA  
* Propósito: Retorna los datos todos los colaboradores de una gerencia
* Input: @GERENCIA_ID   
* Output: Numero de filas afectadas    
* Creado por: Silvia Benites 
* Fecha. Creación: 17/04/2015    
* Fecha. Actualización: Fecha de Actualización    
****************************************************************/    
@GERENCIA_ID uniqueidentifier    
AS   
DECLARE @GRUPO_ORGANIZACIONAL uniqueidentifier = '7B3C5BB8-F7F2-4240-9B08-60B1EB3EA39D'; 
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
where PERSONAL_GERENCIA=@GERENCIA_ID    
and PERSONAL_ESTADO = 1
and PERSONAL_GRUPO_ORGANIZACIONAL != @GRUPO_ORGANIZACIONAL
GO

ALTER PROCEDURE [dbo].[USP_PERSONAL_SELECCIONAR_POR_AREA]    
/****************************************************************     
* Nombre SP: USP_PERSONAL_SELECCIONAR_POR_AREA  
* Propósito: Retorna los datos todos los colaboradores de una gerencia
* Input: @AREA_ID   
* Output: Numero de filas afectadas    
* Creado por: Silvia Benites 
* Fecha. Creación: 17/04/2015    
* Fecha. Actualización: Fecha de Actualización    
****************************************************************/    
@AREA_ID uniqueidentifier    
AS    
DECLARE @GRUPO_ORGANIZACIONAL uniqueidentifier = '7B3C5BB8-F7F2-4240-9B08-60B1EB3EA39D';
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
where PERSONAL_AREA=@AREA_ID    
and PERSONAL_ESTADO = 1
and PERSONAL_GRUPO_ORGANIZACIONAL != @GRUPO_ORGANIZACIONAL
GO

ALTER PROCEDURE [dbo].[USP_PERSONAL_SELECCIONAR_POR_COORDINACION]    
/****************************************************************     
* Nombre SP: USP_PERSONAL_SELECCIONAR_POR_COORDINACION 
* Propósito: Retorna los datos todos los colaboradores de una coordinación
* Input: @COORDINACION_ID   
* Output: Numero de filas afectadas    
* Creado por: Silvia Benites 
* Fecha. Creación: 17/04/2015    
* Fecha. Actualización: Fecha de Actualización    
****************************************************************/    
@COORDINACION_ID uniqueidentifier    
AS    
DECLARE @GRUPO_ORGANIZACIONAL uniqueidentifier = '7B3C5BB8-F7F2-4240-9B08-60B1EB3EA39D';
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
where PERSONAL_COORDINACION=@COORDINACION_ID    
and PERSONAL_ESTADO = 1
and PERSONAL_GRUPO_ORGANIZACIONAL != @GRUPO_ORGANIZACIONAL
GO