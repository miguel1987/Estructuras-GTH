USE [BDREP_GTH]
GO
/****** Object:  Table [dbo].[PARAMETROS_SISTEMA]    Script Date: 06/08/2016 12:29:53 ******/
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
INSERT [dbo].[PARAMETROS_SISTEMA] ([PARAMETRO_ID], [PARAMETRO_DESCRIPCION], [PARAMETRO_VALOR], [USUARIO_CREACION], [FECHA_CREACION], [USUARIO_ACTUALIZACION], [FECHA_ACTUALIZACION], [CODIGO]) VALUES (N'20f4ea86-2d5e-4130-88f3-3a8ded301253', N'COLOR COMPETENCIAS DESARROLLADAS', N'#FFFF00', N'00000000-0000-0000-0000-000000000000', CAST(0x0000A61E012321A8 AS DateTime), N'00000000-0000-0000-0000-000000000000', CAST(0x0000A61E012321A8 AS DateTime), N'AMARILLO')
INSERT [dbo].[PARAMETROS_SISTEMA] ([PARAMETRO_ID], [PARAMETRO_DESCRIPCION], [PARAMETRO_VALOR], [USUARIO_CREACION], [FECHA_CREACION], [USUARIO_ACTUALIZACION], [FECHA_ACTUALIZACION], [CODIGO]) VALUES (N'3908371b-630a-4b19-8c6b-4536e229beb0', N'FACTOR COMPETENCIAS DESARROLLADAS', N'80', N'00000000-0000-0000-0000-000000000000', CAST(0x0000A60B013E7960 AS DateTime), N'00000000-0000-0000-0000-000000000000', CAST(0x0000A60B013E7960 AS DateTime), N'DESARROLLADAS')
INSERT [dbo].[PARAMETROS_SISTEMA] ([PARAMETRO_ID], [PARAMETRO_DESCRIPCION], [PARAMETRO_VALOR], [USUARIO_CREACION], [FECHA_CREACION], [USUARIO_ACTUALIZACION], [FECHA_ACTUALIZACION], [CODIGO]) VALUES (N'818553e9-fe25-451a-80be-7161dbc2d355', N'COLOR COMPETENCIAS DESARROLLADAS', N'#81F781', N'00000000-0000-0000-0000-000000000000', CAST(0x0000A61600A92B06 AS DateTime), N'00000000-0000-0000-0000-000000000000', CAST(0x0000A61600A92B06 AS DateTime), N'VERDE')
