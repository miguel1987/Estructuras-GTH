USE [BDREP_GTH]
GO
CREATE procedure [dbo].[USP_PARAMETROS_SISTEMA_POR_VALOR_COLOR]    
/****************************************************************     
* Nombre SP: USP_PARAMETROS_SISTEMA_POR_VALOR_COLOR    
* Propósito: devolver el valor del parametro del sistema   
* Input:    
* @CODIGO           
* Creado por: Miguel Vasquez   
* Fecha. Creación: 25/05/2016    
* Fecha. Actualización: Fecha de Actualización    
****************************************************************/    
@CODIGO varchar(50)   
AS    
Select     
  PARAMETRO_VALOR
from     
  PARAMETROS_SISTEMA    
where CODIGO=@CODIGO
GO
/****** Object:  StoredProcedure [dbo].[USP_PARAMETROS_SISTEMA_POR_VALOR]    Script Date: 06/06/2016 11:23:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[USP_PARAMETROS_SISTEMA_POR_VALOR]    
/****************************************************************     
* Nombre SP: USP_PARAMETROS_SISTEMA_POR_VALOR    
* Propósito: devolver el valor del parametro del sistema   
* Input:    
* @PARAMETRO_DESCRIPCION           
* Creado por: Miguel Vasquez   
* Fecha. Creación: 25/05/2016    
* Fecha. Actualización: Fecha de Actualización    
****************************************************************/    
@CODIGO varchar(50)   
AS    
Select     
  PARAMETRO_VALOR
from     
  PARAMETROS_SISTEMA    
where CODIGO=@CODIGO
GO
/****** Object:  StoredProcedure [dbo].[USP_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL_SELECCIONAR_ESTADO_POR_PERSONAL_ID]    Script Date: 06/06/2016 11:23:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[USP_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL_SELECCIONAR_ESTADO_POR_PERSONAL_ID]    
/****************************************************************     
* Nombre SP: USP_SELECCIONAR_EVALUACIONES_ESTADO_POR_PERSONAL_ID    
* Propósito: devolver el estado de evaluaciones por personal id    
* Input:    
* @PERSONAL_ID           
* Creado por: Miguel Vasquez   
* Fecha. Creación: 19/04/2015    
* Fecha. Actualización: Fecha de Actualización    
****************************************************************/    
@PERSONAL_ID uniqueidentifier    
AS    
Select     
  ISNULL(EVALUACION_COMPETENCIA_ESTADO, 0) AS EVALUACION_COMPETENCIA_ESTADO
from     
  EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL    
where PERSONAL_ID=@PERSONAL_ID
GO
/****** Object:  StoredProcedure [dbo].[USP_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL_INSERTAR]    Script Date: 06/06/2016 11:23:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[USP_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL_INSERTAR]
/**************************************************************** 
* Nombre SP: USP_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL_INSERTAR
* Propósito: Inserta los datos de Evaluaciones por Competencias Puesto Personal.
* Input: 
		@PERSONAL_ID,
		@PUESTO_ID,
		@COMPETENCIA_ID,
		@EVALUACION_COMPETENCIA_VALOR_REAL,
		@EVALUACION_COMPETENCIA_COMENTARIO,
		@EVALUACION_COMPETENCIA_BRECHA,
		@EVALUACION_COMPETENCIA_ESTADO,
		@EVALUACION_COMPETENCIA_ANIO,
		@USUARIO
* Output: Numero de registros afectados
* Creado por: Silvia Benites
* Fecha. Creación: 19/11/2015
* Fecha. Actualización: Fecha de Actualización
****************************************************************/
@PERSONAL_ID		uniqueidentifier,
@PUESTO_ID		    uniqueidentifier,
@COMPETENCIA_ID	    uniqueidentifier,
@EVALUACION_COMPETENCIA_VALOR_REAL  int,
@EVALUACION_COMPETENCIA_COMENTARIO VARCHAR(100),
@EVALUACION_COMPETENCIA_BRECHA     int,
@EVALUACION_COMPETENCIA_ESTADO     int,
@EVALUACION_COMPETENCIA_ANIO       int,
@USUARIO                      uniqueidentifier


AS

DECLARE @ID uniqueidentifier = NEWID();
Insert Into 
			EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL(
					EVALUACION_COMPETENCIA_PUESTO_PERSONAL_ID,
					PERSONAL_ID,
					PUESTO_ID,
					COMPETENCIA_ID,
					EVALUACION_COMPETENCIA_VALOR_REAL,
					EVALUACION_COMPETENCIA_COMENTARIO,
					EVALUACION_COMPETENCIA_BRECHA,
					EVALUACION_COMPETENCIA_ESTADO,
					EVALUACION_COMPETENCIA_ANIO,
					USUARIO_CREACION,
					FECHA_CREACION,
					USUARIO_ACTUALIZACION,
					FECHA_ACTUALIZACION
					
				)
values			(
					@ID,
					@PERSONAL_ID,
					@PUESTO_ID,
					@COMPETENCIA_ID,
					@EVALUACION_COMPETENCIA_VALOR_REAL,
					@EVALUACION_COMPETENCIA_COMENTARIO,
					@EVALUACION_COMPETENCIA_BRECHA,
					@EVALUACION_COMPETENCIA_ESTADO,
					@EVALUACION_COMPETENCIA_ANIO,
					@USUARIO,
					getdate(),
					@USUARIO,
					getdate()
					
				)				

select @ID
GO
/****** Object:  StoredProcedure [dbo].[USP_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL_ACTUALIZAR_EVALUACION_FINAL]    Script Date: 06/06/2016 11:23:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[USP_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL_ACTUALIZAR_EVALUACION_FINAL]
/**************************************************************** 
* Nombre SP: USP_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL_ACTUALIZAR_EVALUACION_FINAL
* Propósito: Actualiza los datos de competencias puestos personal
* Input:
		@PUESTO_ID
		@COMPETENCIA_ID
* Output: Numero de registros afectados
* Creado por: Miguel Vasquez
* Fecha. Creación: 20/11/2015
* Fecha. Actualización: Fecha de Actualización
****************************************************************/
@PUESTO_ID		        uniqueidentifier,
@PERSONAL_ID		    uniqueidentifier



AS

Update 
			EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL set EVALUACION_COMPETENCIA_ESTADO=2					
where  PUESTO_ID=@PUESTO_ID	AND PERSONAL_ID=@PERSONAL_ID
GO
/****** Object:  StoredProcedure [dbo].[USP_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL_ACTUALIZAR]    Script Date: 06/06/2016 11:23:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[USP_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL_ACTUALIZAR]
/**************************************************************** 
* Nombre SP: USP_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL_ACTUALIZAR
* Propósito: Actualiza los datos de competencias puestos personal
* Input:
		@PERSONAL_ID
		@PUESTO_ID
		@COMPETENCIA_ID
		@EVALUACION_COMPETENCIA_VALOR_REAL
		@EVALUACION_COMPETENCIA_COMENTARIO
		@EVALUACION_COMPETENCIA_BRECHA
		@EVALUACION_COMPETENCIA_ESTADO
		
* Output: Numero de registros afectados
* Creado por: Miguel Vasquez
* Fecha. Creación: 20/11/2015
* Fecha. Actualización: Fecha de Actualización
****************************************************************/
@PERSONAL_ID			uniqueidentifier,
@PUESTO_ID		        uniqueidentifier,
@COMPETENCIA_ID		    uniqueidentifier,
@EVALUACION_COMPETENCIA_VALOR_REAL int,
@EVALUACION_COMPETENCIA_COMENTARIO varchar(100),
@EVALUACION_COMPETENCIA_BRECHA int,
@EVALUACION_COMPETENCIA_ESTADO int


AS

Update 
			EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL set	EVALUACION_COMPETENCIA_VALOR_REAL		=@EVALUACION_COMPETENCIA_VALOR_REAL,
						EVALUACION_COMPETENCIA_COMENTARIO		=@EVALUACION_COMPETENCIA_COMENTARIO,
						EVALUACION_COMPETENCIA_BRECHA			=@EVALUACION_COMPETENCIA_BRECHA,
						EVALUACION_COMPETENCIA_ESTADO		    =@EVALUACION_COMPETENCIA_ESTADO						
where PERSONAL_ID=@PERSONAL_ID	 AND PUESTO_ID=@PUESTO_ID	AND COMPETENCIA_ID=@COMPETENCIA_ID
GO
/****** Object:  Table [dbo].[EVALUACIONES_COMPETENCIAS_PERSONAL]    Script Date: 06/06/2016 11:23:58 ******/
SET ANSI_NULLS ON

GO
ALTER PROCEDURE [dbo].[USP_EVALUACIONES_COMPETENCIA_TRANSVERSALES_SELECCIONAR_POR_PERSONAL]          
/****************************************************************           
* Nombre SP: USP_EVALUACIONES_COMPETENCIA_TRANSVERSALES_SELECCIONAR_POR_PERSONAL         
* Propósito: Devolver la lista de competencias por puesto         
* Input: @PERSONAL_ID,@COMPETENCIA_TRANSVERSAL_CODIGO          
* Output: Tabla de competencias Transversales       
* Creado por: Miguel Vasquez          
* Fecha. Creación: 12/05/2016         
  
****************************************************************/          
@PERSONAL_ID uniqueidentifier   
       
as          
  
select C.COMPETENCIA_TRANSVERSAL_ID, 
C.COMPETENCIA_TRANSVERSAL_CODIGO, 
C.COMPETENCIA_TRANSVERSAL_DESCRIPCION,
CP.EVALUACION_COMPETENCIA_TRANSVERSAL_PORCENTAJE   
from EVALUACIONES_COMPETENCIAS_TRANSVERSALES CP INNER JOIN COMPETENCIAS_TRANSVERSALES C   
ON CP.COMPETENCIA_TRANSVERSAL_ID=C.COMPETENCIA_TRANSVERSAL_ID   
where CP.PERSONAL_ID=@PERSONAL_ID
GO
/****** Object:  StoredProcedure [dbo].[USP_EVALUACIONES_COMPETENCIA_TRANSVERSALES_SELECCIONAR_POR_PERSONA_COMPETENCIA]    Script Date: 06/06/2016 11:23:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[USP_EVALUACIONES_COMPETENCIA_TRANSVERSALES_SELECCIONAR_POR_PERSONA_COMPETENCIA]        
/****************************************************************         
* Nombre SP: USP_EVALUACIONES_COMPETENCIA_TRANSVERSALES_SELECCIONAR_POR_PERSONA_COMPETENCIA       
* Propósito: Devolver la lista de competencias por puesto       
* Input: @PERSONAL_ID,@COMPETENCIA_TRANSVERSAL_CODIGO        
* Output: Tabla de competencias Transversales     
* Creado por: Miguel Vasquez        
* Fecha. Creación: 12/05/2016       

****************************************************************/        
@PERSONAL_ID uniqueidentifier, 
@COMPETENCIA_TRANSVERSAL_CODIGO VARCHAR(100)      
as        

select CP.EVALUACION_COMPETENCIA_TRANSVERSAL_PORCENTAJE 
from EVALUACIONES_COMPETENCIAS_TRANSVERSALES CP INNER JOIN COMPETENCIAS_TRANSVERSALES C 
ON CP.COMPETENCIA_TRANSVERSAL_ID=C.COMPETENCIA_TRANSVERSAL_ID 
where CP.PERSONAL_ID=@PERSONAL_ID and C.COMPETENCIA_TRANSVERSAL_CODIGO=@COMPETENCIA_TRANSVERSAL_CODIGO
GO
/****** Object:  StoredProcedure [dbo].[USP_COMPETENCIAS_PUESTOS_EVALUACION_FINAL_GRABAR]    Script Date: 06/06/2016 11:23:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[USP_COMPETENCIAS_PUESTOS_EVALUACION_FINAL_GRABAR]        
/****************************************************************         
* Nombre SP: USP_COMPETENCIAS_PUESTOS_EVALUACION_FINAL_GRABAR       
* Propósito: Devolver la lista de competencias por puesto       
* Input: @PUESTO_ID       
* Output: Tabla de competencias      
* Creado por: Miguel Vasquez        
* Fecha. Creación: 27/04/2016       

****************************************************************/        
@PUESTO_ID uniqueidentifier
     
as        
select COUNT(*) AS POR_EVALUAR
from COMPETENCIAS_PUESTOS CP inner join COMPETENCIAS C ON
CP.COMPETENCIA_ID = C.COMPETENCIA_ID
left join EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL D ON
CP.COMPETENCIA_ID=D.COMPETENCIA_ID
where CP.PUESTO_ID =@PUESTO_ID
AND D.EVALUACION_COMPETENCIA_ESTADO IS NULL
GO
/****** Object:  StoredProcedure [dbo].[USP_COMPETENCIA_PUESTO_SELECCIONAR_POR_PUESTO_Y_TIPO]    Script Date: 06/06/2016 11:23:56 ******/
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
select C.COMPETENCIA_ID,   
C.COMPETENCIA_DESCRIPCION,   
CP.COMPETENCIA_PUESTO_VALOR_REQUERIDO,  
ISNULL(D.EVALUACION_COMPETENCIA_VALOR_REAL, 0) AS EVALUACION_COMPETENCIA_VALOR_REAL,  
ISNULL(D.EVALUACION_COMPETENCIA_BRECHA, 0) AS EVALUACION_COMPETENCIA_BRECHA,  
ISNULL(D.EVALUACION_COMPETENCIA_COMENTARIO, '') AS EVALUACION_COMPETENCIA_COMENTARIO,  
ISNULL(D.EVALUACION_COMPETENCIA_ESTADO, 0) AS EVALUACION_COMPETENCIA_ESTADO  
from COMPETENCIAS_PUESTOS CP inner join COMPETENCIAS C ON  
CP.COMPETENCIA_ID = C.COMPETENCIA_ID  
left join EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL D ON  
CP.COMPETENCIA_ID=D.COMPETENCIA_ID  
where CP.PUESTO_ID =@PUESTO_ID  
and C.COMPETENCIA_TIPO_ID =@COMPETENCIA_TIPO_ID  
and D.PERSONAL_ID=@PERSONAL_ID
GO
/****** Object:  StoredProcedure [dbo].[USP_EVALUACIONES_COMPETENCIAS_PERSONAL_INSERTAR]    Script Date: 06/06/2016 11:23:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[USP_EVALUACIONES_COMPETENCIAS_PERSONAL_INSERTAR]
/**************************************************************** 
* Nombre SP: USP_EVALUACIONES_COMPETENCIAS_PERSONAL_INSERTAR
* Propósito: Inserta los datos de Evaluaciones Competencias Personal
* Input: 
		@PERSONAL_ID,
		@COMPETENCIA_ID,
		@EVALUACION_COMPETENCIA_BRECHA
* Output: Numero de registros afectados
* Creado por:Miguel Vasquez
* Fecha. Creación: 03/05/2016
* Fecha. Actualización: Fecha de Actualización
****************************************************************/
@PERSONAL_ID		uniqueidentifier,
@COMPETENCIA_ID		uniqueidentifier,
@EVALUACION_COMPETENCIA_BRECHA	int
AS

DECLARE @ID uniqueidentifier = NEWID();
Insert Into 
			EVALUACIONES_COMPETENCIAS_PERSONAL(
					EVALUACION_COMPETENCIA_PERSONAL_ID,
					PERSONAL_ID,
					COMPETENCIA_ID,
					EVALUACION_COMPETENCIA_BRECHA
				)
values			(
					@ID,
					@PERSONAL_ID,
					@COMPETENCIA_ID,
					@EVALUACION_COMPETENCIA_BRECHA
				
				)
GO
/****** Object:  StoredProcedure [dbo].[USP_EVALUACIONES_COMPETENCIAS_PERSONAL_ACTUALIZAR]    Script Date: 06/06/2016 11:23:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[USP_EVALUACIONES_COMPETENCIAS_PERSONAL_ACTUALIZAR]
/**************************************************************** 
* Nombre SP: USP_EVALUACIONES_COMPETENCIAS_PERSONAL_ACTUALIZAR
* Propósito: Actualizar los datos de evaluaciones competencias personal
* Input:
		@PERSONAL_ID
		@COMPETENCIA_ID
		@EVALUACION_COMPETENCIA_BRECHA
		
* Output: Numero de registros afectados
* Creado por: Miguel Vasquez
* Fecha. Creación: 04/05/2016
* Fecha. Actualización: Fecha de Actualización
****************************************************************/
@PERSONAL_ID			uniqueidentifier,
@COMPETENCIA_ID		    uniqueidentifier,
@EVALUACION_COMPETENCIA_BRECHA	int


AS

Update 
			EVALUACIONES_COMPETENCIAS_PERSONAL set	EVALUACION_COMPETENCIA_BRECHA	=@EVALUACION_COMPETENCIA_BRECHA
						
where		PERSONAL_ID=@PERSONAL_ID AND COMPETENCIA_ID	=@COMPETENCIA_ID
GO

