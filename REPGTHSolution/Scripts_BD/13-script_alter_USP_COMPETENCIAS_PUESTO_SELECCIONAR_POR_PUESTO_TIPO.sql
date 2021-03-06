USE [BDREP_GTH]
GO
/****** Object:  StoredProcedure [dbo].[USP_COMPETENCIA_PUESTO_SELECCIONAR_POR_PUESTO_Y_TIPO]    Script Date: 06/07/2016 23:01:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[USP_COMPETENCIA_PUESTO_SELECCIONAR_POR_PUESTO_Y_TIPO]          
/****************************************************************           
* Nombre SP: USP_COMPETENCIAS_POR_PUESTOS         
* Propósito: Devolver la lista de competencias por puesto         
* Input: @PUESTO_ID,@COMPETENCIA_TIPO_ID          
* Output: Tabla de competencias        
* Creado por: Miguel Vasquez          
* Fecha. Creación: 27/04/2016         
  
****************************************************************/          
@PUESTO_ID uniqueidentifier,   
@COMPETENCIA_TIPO_ID uniqueidentifier, 
@PERSONAL_ID uniqueidentifier        
as    

select DISTINCT C.COMPETENCIA_ID,   
C.COMPETENCIA_DESCRIPCION,   
CP.COMPETENCIA_PUESTO_VALOR_REQUERIDO,  
ISNULL([dbo].[F_EVALUACIONA_COMPETENCIAS_PUESTOS_SELECCIONAR_VALOR_REAL_POR_PERSONAL_COMPETENCIA] (@PERSONAL_ID, @PUESTO_ID, C.COMPETENCIA_ID), 0) AS EVALUACION_COMPETENCIA_VALOR_REAL,  
ISNULL([dbo].[F_EVALUACIONA_COMPETENCIAS_PUESTOS_SELECCIONAR_BRECHA_POR_PERSONAL_COMPETENCIA] (@PERSONAL_ID, @PUESTO_ID, C.COMPETENCIA_ID), 0) AS EVALUACION_COMPETENCIA_BRECHA,  
ISNULL([dbo].[F_EVALUACIONA_COMPETENCIAS_PUESTOS_SELECCIONAR_COMENTARIO_POR_PERSONAL_COMPETENCIA] (@PERSONAL_ID, @PUESTO_ID, C.COMPETENCIA_ID), '') AS EVALUACION_COMPETENCIA_COMENTARIO,  
ISNULL(D.EVALUACION_COMPETENCIA_ESTADO, 0) AS EVALUACION_COMPETENCIA_ESTADO  
from COMPETENCIAS_PUESTOS CP inner join COMPETENCIAS C ON  
CP.COMPETENCIA_ID = C.COMPETENCIA_ID  
left join EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL D ON  
CP.COMPETENCIA_ID=D.COMPETENCIA_ID  
where CP.PUESTO_ID =@PUESTO_ID  
and C.COMPETENCIA_TIPO_ID =@COMPETENCIA_TIPO_ID  

GO 

/**************************************************************** 
* Nombre F: F_EVALUACIONA_COMPETENCIAS_PUESTOS_SELECCIONAR_BRECHA_POR_PERSONAL_COMPETENCIA
* Propósito: Devolver el cumplimiento planeado por proyecto y mes
* Input:
* Output: Cumplimiento acumulado de una etapa de un proyecto
* Creado por: Silvia Benites
* Fecha. Creación: 09/01/2014
* Fecha. Actualización: Fecha de Actualización
****************************************************************/

CREATE FUNCTION [dbo].[F_EVALUACIONA_COMPETENCIAS_PUESTOS_SELECCIONAR_BRECHA_POR_PERSONAL_COMPETENCIA]

(@PERSONAL_ID UniqueIdentifier, @PUESTO_ID UniqueIdentifier, @COMPETENCIA_ID UniqueIdentifier)

RETURNS INT

AS

BEGIN

declare @strtd INT

declare @VALOR_REAL INT


SELECT @strtd = EVALUACION_COMPETENCIA_BRECHA
      FROM EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL ECP 
	  Where ECP.PERSONAL_ID = @PERSONAL_ID AND ECP.PUESTO_ID = @PUESTO_ID
	  AND ECP.COMPETENCIA_ID = @COMPETENCIA_ID	  

RETURN @strtd

END

GO

/**************************************************************** 
* Nombre F: F_EVALUACIONA_COMPETENCIAS_PUESTOS_SELECCIONAR_COMENTARIO_POR_PERSONAL_COMPETENCIA
* Propósito: Devolver el cumplimiento planeado por proyecto y mes
* Input:
* Output: Cumplimiento acumulado de una etapa de un proyecto
* Creado por: Silvia Benites
* Fecha. Creación: 09/01/2014
* Fecha. Actualización: Fecha de Actualización
****************************************************************/

CREATE FUNCTION [dbo].[F_EVALUACIONA_COMPETENCIAS_PUESTOS_SELECCIONAR_COMENTARIO_POR_PERSONAL_COMPETENCIA]

(@PERSONAL_ID UniqueIdentifier, @PUESTO_ID UniqueIdentifier, @COMPETENCIA_ID UniqueIdentifier)

RETURNS VARCHAR(1000)

AS

BEGIN

declare @strtd VARCHAR(1000)




SELECT @strtd = EVALUACION_COMPETENCIA_COMENTARIO
      FROM EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL ECP 
	  Where ECP.PERSONAL_ID = @PERSONAL_ID AND ECP.PUESTO_ID = @PUESTO_ID
	  AND ECP.COMPETENCIA_ID = @COMPETENCIA_ID	  

RETURN @strtd

END
GO

/**************************************************************** 
* Nombre F: F_EVALUACIONA_COMPETENCIAS_PUESTOS_SELECCIONAR_VALOR_REAL_POR_PERSONAL_COMPETENCIA
* Propósito: Devolver el cumplimiento planeado por proyecto y mes
* Input:
* Output: Cumplimiento acumulado de una etapa de un proyecto
* Creado por: Silvia Benites
* Fecha. Creación: 09/01/2014
* Fecha. Actualización: Fecha de Actualización
****************************************************************/

CREATE FUNCTION [dbo].[F_EVALUACIONA_COMPETENCIAS_PUESTOS_SELECCIONAR_VALOR_REAL_POR_PERSONAL_COMPETENCIA]

(@PERSONAL_ID UniqueIdentifier, @PUESTO_ID UniqueIdentifier, @COMPETENCIA_ID UniqueIdentifier)

RETURNS INT

AS

BEGIN

declare @strtd INT

declare @VALOR_REAL INT


SELECT @strtd = EVALUACION_COMPETENCIA_VALOR_REAL
      FROM EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL ECP 
	  Where ECP.PERSONAL_ID = @PERSONAL_ID AND ECP.PUESTO_ID = @PUESTO_ID
	  AND ECP.COMPETENCIA_ID = @COMPETENCIA_ID	  

RETURN @strtd

END
GO



