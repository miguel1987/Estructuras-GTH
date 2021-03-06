
GO
CREATE procedure [dbo].[USP_PERSONAL_ELIMINAR]
/**************************************************************** 
* Nombre SP: USP_PERSONAL_ELIMINAR
* Propósito: Actualiza el campo Estado a Inactivo para un registro en la tabla PERSONAL
* Input:
			@PERSONAL_ID
* Output: Numero de filas afectadas
* Creado por: Silvia Benites
* Actualizado por: Silvia Benites
* Fecha. Actualización: 07/05/2016
****************************************************************/
@PERSONAL_ID uniqueidentifier
as
Update PERSONAL
Set PERSONAL_ESTADO=0
Where PERSONAL_ID=@PERSONAL_ID

GO
