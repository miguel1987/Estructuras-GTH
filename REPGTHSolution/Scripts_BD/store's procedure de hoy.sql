USE [BDREP_GTH]
GO
/****** Object:  Table [dbo].[COMPETENCIAS_TRANSVERSALES]    Script Date: 06/06/2016 11:23:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[COMPETENCIAS_TRANSVERSALES](
	[COMPETENCIA_TRANSVERSAL_ID] [uniqueidentifier] NOT NULL,
	[COMPETENCIA_TRANSVERSAL_CODIGO] [varchar](50) NULL,
	[COMPETENCIA_TRANSVERSAL_DESCRIPCION] [varchar](100) NULL,
	[COMPETENCIA_TRANSVERSAL_ESTADO] [int] NULL,
	[USUARIO_CREACION] [uniqueidentifier] NULL,
	[FECHA_CREACION] [datetime] NULL,
	[USUARIO_ACTUALIZACION] [uniqueidentifier] NULL,
	[FECHA_ACTUALIZACION] [datetime] NULL,
 CONSTRAINT [PK_COMPETENCIAS_TRANSVERSALES] PRIMARY KEY CLUSTERED 
(
	[COMPETENCIA_TRANSVERSAL_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UQ_COMPENTENCIAS_TRANSVERSALES_COMPETENCIA_TRANSVERSAL_ID] UNIQUE NONCLUSTERED 
(
	[COMPETENCIA_TRANSVERSAL_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'COMPETENCIAS_TRANSVERSALES', @level2type=N'COLUMN',@level2name=N'COMPETENCIA_TRANSVERSAL_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Codigo de usuario asignado a la competencia transversal.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'COMPETENCIAS_TRANSVERSALES', @level2type=N'COLUMN',@level2name=N'COMPETENCIA_TRANSVERSAL_CODIGO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Descripcion de la competencia transversal.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'COMPETENCIAS_TRANSVERSALES', @level2type=N'COLUMN',@level2name=N'COMPETENCIA_TRANSVERSAL_DESCRIPCION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estado de la competencia transversal. Activa - 1, Inactiva - 0.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'COMPETENCIAS_TRANSVERSALES', @level2type=N'COLUMN',@level2name=N'COMPETENCIA_TRANSVERSAL_ESTADO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del usuario que registra la competencia transversal.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'COMPETENCIAS_TRANSVERSALES', @level2type=N'COLUMN',@level2name=N'USUARIO_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de creacion de la competencia transversal.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'COMPETENCIAS_TRANSVERSALES', @level2type=N'COLUMN',@level2name=N'FECHA_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del usuario que actualizo por ultima vez la competencia transversal.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'COMPETENCIAS_TRANSVERSALES', @level2type=N'COLUMN',@level2name=N'USUARIO_ACTUALIZACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de ultima actualizacion de la competencia transversal.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'COMPETENCIAS_TRANSVERSALES', @level2type=N'COLUMN',@level2name=N'FECHA_ACTUALIZACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla que almacenara la definicion de las competencias transversales.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'COMPETENCIAS_TRANSVERSALES'
GO
/****** Object:  Table [dbo].[COMPETENCIAS_TIPOS]    Script Date: 06/06/2016 11:23:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[COMPETENCIAS_TIPOS](
	[COMPETENCIA_TIPO_ID] [uniqueidentifier] NOT NULL,
	[COMPETENCIA_TIPO_CODIGO] [varchar](50) NULL,
	[COMPETENCIA_TIPO_DESCRIPCION] [varchar](100) NULL,
	[USUARIOS_CREACION] [uniqueidentifier] NULL,
	[FECHA_CREACION] [datetime] NULL,
	[USUARIO_ACTUALIZACION] [uniqueidentifier] NULL,
	[FECHA_ACTUALIZACION] [datetime] NULL,
	[COMPETENCIA_TIPO_ESTADO] [int] NULL,
 CONSTRAINT [PK_COMPETENCIAS_TIPOS] PRIMARY KEY CLUSTERED 
(
	[COMPETENCIA_TIPO_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UQ_COMPETENCIAS_TIPOS_COMPETENCIA_TIPO_ID] UNIQUE NONCLUSTERED 
(
	[COMPETENCIA_TIPO_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'COMPETENCIAS_TIPOS', @level2type=N'COLUMN',@level2name=N'COMPETENCIA_TIPO_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Codigo del tipo de competencia definido por los usuarios.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'COMPETENCIAS_TIPOS', @level2type=N'COLUMN',@level2name=N'COMPETENCIA_TIPO_CODIGO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Descripcion del tipo de competencia.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'COMPETENCIAS_TIPOS', @level2type=N'COLUMN',@level2name=N'COMPETENCIA_TIPO_DESCRIPCION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del usuario que creo el registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'COMPETENCIAS_TIPOS', @level2type=N'COLUMN',@level2name=N'USUARIOS_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de creacion del registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'COMPETENCIAS_TIPOS', @level2type=N'COLUMN',@level2name=N'FECHA_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del usuario que actualizo por ultima vez el tipo de competencia.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'COMPETENCIAS_TIPOS', @level2type=N'COLUMN',@level2name=N'USUARIO_ACTUALIZACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ultima fecha de actualizacion del tipo de competencia.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'COMPETENCIAS_TIPOS', @level2type=N'COLUMN',@level2name=N'FECHA_ACTUALIZACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla que almacenara los tipos de competencias.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'COMPETENCIAS_TIPOS'
GO
/****** Object:  Table [dbo].[EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL]    Script Date: 06/06/2016 11:23:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL](
	[EVALUACION_COMPETENCIA_PUESTO_PERSONAL_ID] [uniqueidentifier] NOT NULL,
	[PERSONAL_ID] [uniqueidentifier] NULL,
	[PUESTO_ID] [uniqueidentifier] NULL,
	[COMPETENCIA_ID] [uniqueidentifier] NULL,
	[EVALUACION_COMPETENCIA_VALOR_REAL] [int] NULL,
	[EVALUACION_COMPETENCIA_COMENTARIO] [text] NULL,
	[EVALUACION_COMPETENCIA_BRECHA] [int] NULL,
	[EVALUACION_COMPETENCIA_ESTADO] [int] NULL,
	[EVALUACION_COMPETENCIA_ANIO] [int] NULL,
	[USUARIO_CREACION] [uniqueidentifier] NULL,
	[FECHA_CREACION] [datetime] NULL,
	[USUARIO_ACTUALIZACION] [uniqueidentifier] NULL,
	[FECHA_ACTUALIZACION] [datetime] NULL,
 CONSTRAINT [PK_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL] PRIMARY KEY CLUSTERED 
(
	[EVALUACION_COMPETENCIA_PUESTO_PERSONAL_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL', @level2type=N'COLUMN',@level2name=N'EVALUACION_COMPETENCIA_PUESTO_PERSONAL_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del colaborador al que se esta evaluando.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL', @level2type=N'COLUMN',@level2name=N'PERSONAL_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del puesto al que pertenece el colaboarador que esta siendo evaluado.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL', @level2type=N'COLUMN',@level2name=N'PUESTO_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador de la competencia evaluada.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL', @level2type=N'COLUMN',@level2name=N'COMPETENCIA_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Calificacion real obtenido en la evaluacion .' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL', @level2type=N'COLUMN',@level2name=N'EVALUACION_COMPETENCIA_VALOR_REAL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Comentario detallado durante la evaluacion.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL', @level2type=N'COLUMN',@level2name=N'EVALUACION_COMPETENCIA_COMENTARIO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Valor Real menos Valor Requerido.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL', @level2type=N'COLUMN',@level2name=N'EVALUACION_COMPETENCIA_BRECHA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estado de la evaluacion. 0 Pendiente, 1- En Evaluacion, 2 - Evaluacion Final.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL', @level2type=N'COLUMN',@level2name=N'EVALUACION_COMPETENCIA_ESTADO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Año en que se esta realizando la evaluacion.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL', @level2type=N'COLUMN',@level2name=N'EVALUACION_COMPETENCIA_ANIO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del usuario que registro la evaluacion.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL', @level2type=N'COLUMN',@level2name=N'USUARIO_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de creacion de la evaluacion.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL', @level2type=N'COLUMN',@level2name=N'FECHA_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del ultimo usuario que actualizo el registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL', @level2type=N'COLUMN',@level2name=N'USUARIO_ACTUALIZACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de ultima actualizacion del registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL', @level2type=N'COLUMN',@level2name=N'FECHA_ACTUALIZACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla que almacenará los resultados de las evaluaciones de las competencias por puesto y colaborador.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL'
GO
/****** Object:  Table [dbo].[USUARIOS]    Script Date: 06/06/2016 11:23:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USUARIOS](
	[USUARIO_ID] [uniqueidentifier] NOT NULL,
	[PERSONAL_ID] [uniqueidentifier] NULL,
	[PERFIL_ID] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PERFILES]    Script Date: 06/06/2016 11:23:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PERFILES](
	[PERFIL_ID] [int] NOT NULL,
	[PERFIL_DESCRIPCION] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PARAMETROS_SISTEMA]    Script Date: 06/06/2016 11:23:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PARAMETROS_SISTEMA](
	[PARAMETRO_ID] [uniqueidentifier] NOT NULL,
	[PARAMETRO_DESCRIPCION] [varchar](50) NULL,
	[PARAMETRO_VALOR] [varchar](50) NULL,
	[USUARIO_CREACION] [uniqueidentifier] NULL,
	[FECHA_CREACION] [datetime] NULL,
	[USUARIO_ACTUALIZACION] [uniqueidentifier] NULL,
	[FECHA_ACTUALIZACION] [datetime] NULL,
	[CODIGO] [varchar](50) NULL,
 CONSTRAINT [PK_PARAMETROS_SISTEMA] PRIMARY KEY CLUSTERED 
(
	[PARAMETRO_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UQ_PARAMETROS_SISTEMA_PARAMETRO_ID] UNIQUE NONCLUSTERED 
(
	[PARAMETRO_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PARAMETROS_SISTEMA', @level2type=N'COLUMN',@level2name=N'PARAMETRO_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Descripcion del parametro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PARAMETROS_SISTEMA', @level2type=N'COLUMN',@level2name=N'PARAMETRO_DESCRIPCION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N' Valor del parametro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PARAMETROS_SISTEMA', @level2type=N'COLUMN',@level2name=N'PARAMETRO_VALOR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del usuario que registro el parametro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PARAMETROS_SISTEMA', @level2type=N'COLUMN',@level2name=N'USUARIO_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de creacion del parametro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PARAMETROS_SISTEMA', @level2type=N'COLUMN',@level2name=N'FECHA_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del usuario que actualizo por ultima vez el parametro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PARAMETROS_SISTEMA', @level2type=N'COLUMN',@level2name=N'USUARIO_ACTUALIZACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de ultima actualizacion del parametro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PARAMETROS_SISTEMA', @level2type=N'COLUMN',@level2name=N'FECHA_ACTUALIZACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla que almacenará los parámetros del sistema.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PARAMETROS_SISTEMA'
GO
/****** Object:  StoredProcedure [dbo].[USP_COMPETENCIA_TIPO_SELECCIONAR]    Script Date: 06/06/2016 11:23:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[USP_COMPETENCIA_TIPO_SELECCIONAR]
/**************************************************************** 
* Nombre SP: USP_COMPETENCIAS_TIPOS
* Propósito: Devuelve todas las competencias por tipos.
* Input:
* Output: Lista de todas las competencias por tipo
* Creado por: Miguel Vasquez
* Fecha. Creación: 27/04/2016
* Fecha. Actualización: Fecha de Actualización
****************************************************************/
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
		
where COMPETENCIA_TIPO_ESTADO=1
GO
/****** Object:  Table [dbo].[EVALUACIONES_COMPETENCIAS_TRANSVERSALES]    Script Date: 06/06/2016 11:23:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EVALUACIONES_COMPETENCIAS_TRANSVERSALES](
	[EVALUACION_COMPETENCIA_TRANSVERSAL_ID] [uniqueidentifier] NOT NULL,
	[PERSONAL_ID] [uniqueidentifier] NULL,
	[COMPETENCIA_TRANSVERSAL_ID] [uniqueidentifier] NULL,
	[EVALUACION_COMPETENCIA_TRANSVERSAL_PORCENTAJE] [decimal](10, 2) NULL,
	[PUESTO_ID] [uniqueidentifier] NULL,
	[EVALUACION_COMPETENCIA_TRANSVERSAL_ANIO] [int] NULL,
	[USUARIO_CREACION] [uniqueidentifier] NULL,
	[FECHA_CREACION] [datetime] NULL,
	[USUARIO_ACTUALIZACION] [uniqueidentifier] NULL,
	[FECHA_ACTUALIZACION] [datetime] NULL,
 CONSTRAINT [PK_EVALUACIONES_COMPETENCIAS_TRANSVERSALES] PRIMARY KEY CLUSTERED 
(
	[EVALUACION_COMPETENCIA_TRANSVERSAL_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UQ_EVALUACIONES_COMPETENCIAS_TRANSVERSALES_COMPETENCIA_TRANSVERSAL_ID] UNIQUE NONCLUSTERED 
(
	[EVALUACION_COMPETENCIA_TRANSVERSAL_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EVALUACIONES_COMPETENCIAS_TRANSVERSALES', @level2type=N'COLUMN',@level2name=N'EVALUACION_COMPETENCIA_TRANSVERSAL_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del personal evaluado.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EVALUACIONES_COMPETENCIAS_TRANSVERSALES', @level2type=N'COLUMN',@level2name=N'PERSONAL_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador de la competencia transversal evaluado.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EVALUACIONES_COMPETENCIAS_TRANSVERSALES', @level2type=N'COLUMN',@level2name=N'COMPETENCIA_TRANSVERSAL_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Porcentaje otorgado en la evaluacion del colaborador.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EVALUACIONES_COMPETENCIAS_TRANSVERSALES', @level2type=N'COLUMN',@level2name=N'EVALUACION_COMPETENCIA_TRANSVERSAL_PORCENTAJE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del puesto evaluado.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EVALUACIONES_COMPETENCIAS_TRANSVERSALES', @level2type=N'COLUMN',@level2name=N'PUESTO_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Año de evaluacion del colaborador.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EVALUACIONES_COMPETENCIAS_TRANSVERSALES', @level2type=N'COLUMN',@level2name=N'EVALUACION_COMPETENCIA_TRANSVERSAL_ANIO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del usuario que registro la evaluacion transversal.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EVALUACIONES_COMPETENCIAS_TRANSVERSALES', @level2type=N'COLUMN',@level2name=N'USUARIO_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de creacion de la evaluacion transversal.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EVALUACIONES_COMPETENCIAS_TRANSVERSALES', @level2type=N'COLUMN',@level2name=N'FECHA_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del usuario que actualizo por ultima vez el registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EVALUACIONES_COMPETENCIAS_TRANSVERSALES', @level2type=N'COLUMN',@level2name=N'USUARIO_ACTUALIZACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fec' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EVALUACIONES_COMPETENCIAS_TRANSVERSALES', @level2type=N'COLUMN',@level2name=N'FECHA_ACTUALIZACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla que almacenara las evaluaciones de competencias transversales y de liderazgo de los colaboradores.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EVALUACIONES_COMPETENCIAS_TRANSVERSALES'
GO
/****** Object:  Table [dbo].[COMPETENCIAS]    Script Date: 06/06/2016 11:23:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[COMPETENCIAS](
	[COMPETENCIA_ID] [uniqueidentifier] NOT NULL,
	[COMPETENCIA_CODIGO] [varchar](50) NULL,
	[COMPETENCIA_DESCRIPCION] [varchar](100) NULL,
	[COMPETENCIA_TIPO_ID] [uniqueidentifier] NULL,
	[COMPETENCIA_ESTADO] [int] NULL,
	[USUARIO_CREACION] [uniqueidentifier] NULL,
	[FECHA_CREACION] [datetime] NULL,
	[USUARIO_ACTUALIZACION] [uniqueidentifier] NULL,
	[FECHA_ACTUALIZACION] [datetime] NULL,
 CONSTRAINT [PK_COMPETENCIAS] PRIMARY KEY CLUSTERED 
(
	[COMPETENCIA_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UQ_COMPETENCIAS_COMPETENCIAS_ID] UNIQUE NONCLUSTERED 
(
	[COMPETENCIA_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del registro de competencia.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'COMPETENCIAS', @level2type=N'COLUMN',@level2name=N'COMPETENCIA_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Codigo de usuario de la competencia.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'COMPETENCIAS', @level2type=N'COLUMN',@level2name=N'COMPETENCIA_CODIGO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Descripcion de la competencia.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'COMPETENCIAS', @level2type=N'COLUMN',@level2name=N'COMPETENCIA_DESCRIPCION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador el tipo de competencia.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'COMPETENCIAS', @level2type=N'COLUMN',@level2name=N'COMPETENCIA_TIPO_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador el usuario que creo el registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'COMPETENCIAS', @level2type=N'COLUMN',@level2name=N'USUARIO_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de creacion del registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'COMPETENCIAS', @level2type=N'COLUMN',@level2name=N'FECHA_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del ultimo usuario que actualizo el registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'COMPETENCIAS', @level2type=N'COLUMN',@level2name=N'USUARIO_ACTUALIZACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de ultima actualizacion del registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'COMPETENCIAS', @level2type=N'COLUMN',@level2name=N'FECHA_ACTUALIZACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla que almacenara el catalogo de competencias.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'COMPETENCIAS'
GO
/****** Object:  StoredProcedure [dbo].[USP_USUARIO_SELECCIONAR_POR_PERSONAL_ID]    Script Date: 06/06/2016 11:23:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[USP_USUARIO_SELECCIONAR_POR_PERSONAL_ID]    
/****************************************************************     
* Nombre SP: USP_USUARIO_SELECCIONAR_POR_PERSONAL_ID    
* Propósito: devolver los datos de un usuario por personal id    
* Input:    
* @PERSONAL_ID      
* Output: Una tupla de la tabla de gerencia     
* Creado por: Silvia Benites   
* Fecha. Creación: 05/04/2015    
* Fecha. Actualización: Fecha de Actualización    
****************************************************************/    
@PERSONAL_ID uniqueidentifier    
AS    
Select     
  USUARIO_ID,    
  PERSONAL_ID,   
  PERFIL_ID
from     
  USUARIOS    
where PERSONAL_ID=@PERSONAL_ID
GO
/****** Object:  StoredProcedure [dbo].[USP_PARAMETROS_SISTEMA_POR_VALOR_COLOR]    Script Date: 06/06/2016 11:23:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
CREATE procedure [dbo].[USP_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL_SELECCIONAR_ESTADO_POR_PERSONAL_ID]    
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
CREATE procedure [dbo].[USP_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL_INSERTAR]
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
CREATE procedure [dbo].[USP_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL_ACTUALIZAR_EVALUACION_FINAL]
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
CREATE procedure [dbo].[USP_EVALUACIONES_COMPETENCIAS_PUESTOS_PERSONAL_ACTUALIZAR]
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
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EVALUACIONES_COMPETENCIAS_PERSONAL](
	[EVALUACION_COMPETENCIA_PERSONAL_ID] [uniqueidentifier] NOT NULL,
	[PERSONAL_ID] [uniqueidentifier] NULL,
	[COMPETENCIA_ID] [uniqueidentifier] NULL,
	[EVALUACION_COMPETENCIA_BRECHA] [int] NULL,
	[EVALUACION_COMPETENCIA_ANIO] [int] NULL,
 CONSTRAINT [PK_EVALUACIONES_COMPETENCIAS_PERSONAL] PRIMARY KEY CLUSTERED 
(
	[EVALUACION_COMPETENCIA_PERSONAL_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EVALUACIONES_COMPETENCIAS_PERSONAL', @level2type=N'COLUMN',@level2name=N'EVALUACION_COMPETENCIA_PERSONAL_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del personal evaluado.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EVALUACIONES_COMPETENCIAS_PERSONAL', @level2type=N'COLUMN',@level2name=N'PERSONAL_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador de la competencia evaluada.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EVALUACIONES_COMPETENCIAS_PERSONAL', @level2type=N'COLUMN',@level2name=N'COMPETENCIA_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Brecha obtenida de la evaluacion. Si es cero se considera competencia desarrollada, en caso contrario es competencia por desarrollar.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EVALUACIONES_COMPETENCIAS_PERSONAL', @level2type=N'COLUMN',@level2name=N'EVALUACION_COMPETENCIA_BRECHA'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Año en que se evalua la competencia del personal' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EVALUACIONES_COMPETENCIAS_PERSONAL', @level2type=N'COLUMN',@level2name=N'EVALUACION_COMPETENCIA_ANIO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla que almacenara las evaluaciones de las competencias por personal.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EVALUACIONES_COMPETENCIAS_PERSONAL'
GO
/****** Object:  Table [dbo].[COMPETENCIAS_PUESTOS]    Script Date: 06/06/2016 11:23:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[COMPETENCIAS_PUESTOS](
	[COMPETENCIA_PUESTO_ID] [uniqueidentifier] NOT NULL,
	[PUESTO_ID] [uniqueidentifier] NULL,
	[COMPETENCIA_ID] [uniqueidentifier] NULL,
	[COMPETENCIA_PUESTO_VALOR_REQUERIDO] [int] NULL,
	[USUARIO_CREACION] [uniqueidentifier] NULL,
	[FECHA_CREACION] [datetime] NULL,
	[USUARIO_ACTUALIZACION] [uniqueidentifier] NULL,
	[FECHA_ACTUALIZACION] [datetime] NULL,
 CONSTRAINT [PK_COMPETENCIAS_PUESTOS] PRIMARY KEY CLUSTERED 
(
	[COMPETENCIA_PUESTO_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del Registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'COMPETENCIAS_PUESTOS', @level2type=N'COLUMN',@level2name=N'COMPETENCIA_PUESTO_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del puesto asociado.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'COMPETENCIAS_PUESTOS', @level2type=N'COLUMN',@level2name=N'PUESTO_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador de la competencia.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'COMPETENCIAS_PUESTOS', @level2type=N'COLUMN',@level2name=N'COMPETENCIA_ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Valor requerido a la competencia para ese puesto.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'COMPETENCIAS_PUESTOS', @level2type=N'COLUMN',@level2name=N'COMPETENCIA_PUESTO_VALOR_REQUERIDO'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del usuario que crea el registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'COMPETENCIAS_PUESTOS', @level2type=N'COLUMN',@level2name=N'USUARIO_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de creacion del registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'COMPETENCIAS_PUESTOS', @level2type=N'COLUMN',@level2name=N'FECHA_CREACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del ultimo usuario en actualizar el registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'COMPETENCIAS_PUESTOS', @level2type=N'COLUMN',@level2name=N'USUARIO_ACTUALIZACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de ultima actualizacion del registro.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'COMPETENCIAS_PUESTOS', @level2type=N'COLUMN',@level2name=N'FECHA_ACTUALIZACION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabla que almacenara la matriz de competencias por cada puesto.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'COMPETENCIAS_PUESTOS'
GO
/****** Object:  StoredProcedure [dbo].[USP_EVALUACIONES_COMPETENCIA_TRANSVERSALES_SELECCIONAR_POR_PERSONAL]    Script Date: 06/06/2016 11:23:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_EVALUACIONES_COMPETENCIA_TRANSVERSALES_SELECCIONAR_POR_PERSONAL]          
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
CREATE PROCEDURE [dbo].[USP_EVALUACIONES_COMPETENCIA_TRANSVERSALES_SELECCIONAR_POR_PERSONA_COMPETENCIA]        
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
CREATE PROCEDURE [dbo].[USP_COMPETENCIAS_PUESTOS_EVALUACION_FINAL_GRABAR]        
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
CREATE PROCEDURE [dbo].[USP_COMPETENCIA_PUESTO_SELECCIONAR_POR_PUESTO_Y_TIPO]          
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
CREATE procedure [dbo].[USP_EVALUACIONES_COMPETENCIAS_PERSONAL_INSERTAR]
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
CREATE procedure [dbo].[USP_EVALUACIONES_COMPETENCIAS_PERSONAL_ACTUALIZAR]
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
/****** Object:  ForeignKey [FK_COMPETENCIAS_COMPETENCIAS_TIPOS_COMPETENCIA_TIPO_ID]    Script Date: 06/06/2016 11:23:58 ******/
ALTER TABLE [dbo].[COMPETENCIAS]  WITH CHECK ADD  CONSTRAINT [FK_COMPETENCIAS_COMPETENCIAS_TIPOS_COMPETENCIA_TIPO_ID] FOREIGN KEY([COMPETENCIA_TIPO_ID])
REFERENCES [dbo].[COMPETENCIAS_TIPOS] ([COMPETENCIA_TIPO_ID])
GO
ALTER TABLE [dbo].[COMPETENCIAS] CHECK CONSTRAINT [FK_COMPETENCIAS_COMPETENCIAS_TIPOS_COMPETENCIA_TIPO_ID]
GO
/****** Object:  ForeignKey [FK_COMPETENCIAS_PUESTOS_COMPETENCIAS_COMPETENCIA_ID]    Script Date: 06/06/2016 11:23:58 ******/
ALTER TABLE [dbo].[COMPETENCIAS_PUESTOS]  WITH CHECK ADD  CONSTRAINT [FK_COMPETENCIAS_PUESTOS_COMPETENCIAS_COMPETENCIA_ID] FOREIGN KEY([COMPETENCIA_ID])
REFERENCES [dbo].[COMPETENCIAS] ([COMPETENCIA_ID])
GO
ALTER TABLE [dbo].[COMPETENCIAS_PUESTOS] CHECK CONSTRAINT [FK_COMPETENCIAS_PUESTOS_COMPETENCIAS_COMPETENCIA_ID]
GO
/****** Object:  ForeignKey [FK_EVALUACIONES_COMPETENCIAS_PERSONAL_COMPETENCIAS_COMPETENCIA_ID]    Script Date: 06/06/2016 11:23:58 ******/
ALTER TABLE [dbo].[EVALUACIONES_COMPETENCIAS_PERSONAL]  WITH CHECK ADD  CONSTRAINT [FK_EVALUACIONES_COMPETENCIAS_PERSONAL_COMPETENCIAS_COMPETENCIA_ID] FOREIGN KEY([COMPETENCIA_ID])
REFERENCES [dbo].[COMPETENCIAS] ([COMPETENCIA_ID])
GO
ALTER TABLE [dbo].[EVALUACIONES_COMPETENCIAS_PERSONAL] CHECK CONSTRAINT [FK_EVALUACIONES_COMPETENCIAS_PERSONAL_COMPETENCIAS_COMPETENCIA_ID]
GO
/****** Object:  ForeignKey [FK_EVALUACIONES_COMPETENCIAS_TRANSVERSALES_COMPETENCIAS_TRANSVERSALES_ID]    Script Date: 06/06/2016 11:23:58 ******/
ALTER TABLE [dbo].[EVALUACIONES_COMPETENCIAS_TRANSVERSALES]  WITH CHECK ADD  CONSTRAINT [FK_EVALUACIONES_COMPETENCIAS_TRANSVERSALES_COMPETENCIAS_TRANSVERSALES_ID] FOREIGN KEY([COMPETENCIA_TRANSVERSAL_ID])
REFERENCES [dbo].[COMPETENCIAS_TRANSVERSALES] ([COMPETENCIA_TRANSVERSAL_ID])
GO
ALTER TABLE [dbo].[EVALUACIONES_COMPETENCIAS_TRANSVERSALES] CHECK CONSTRAINT [FK_EVALUACIONES_COMPETENCIAS_TRANSVERSALES_COMPETENCIAS_TRANSVERSALES_ID]
GO
