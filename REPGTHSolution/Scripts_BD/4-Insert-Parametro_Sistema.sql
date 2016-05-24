GO
INSERT INTO [BDREP_GTH].[dbo].[PARAMETROS_SISTEMA]
           ([PARAMETRO_ID]
           ,[PARAMETRO_DESCRIPCION]
           ,[PARAMETRO_VALOR]
           ,[USUARIO_CREACION]
           ,[FECHA_CREACION]
           ,[USUARIO_ACTUALIZACION]
           ,[FECHA_ACTUALIZACION])
     VALUES
           (NEWID()
           ,'FACTOR COMPETENCIAS DESARROLLADAS'
           ,80
           ,'00000000-0000-0000-0000-000000000000'
           ,GETDATE()
           ,'00000000-0000-0000-0000-000000000000'
           ,GETDATE())
GO


