USE PIA_MAD;

GO
CREATE PROCEDURE sp_Admin(
@opc VARCHAR(30))
AS
BEGIN

IF @Opc = 'Select'
BEGIN
SELECT Nombre_Usuario, Contrasenia FROM Administrador;

END

END

GO


SELECT* FROM Administrador;

EXEC sp_Admin 'Select';