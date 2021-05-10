USE PIA_MAD;

GO
CREATE PROCEDURE sp_GetDataTable
(
@Opc VARCHAR(30)
)
AS
BEGIN

IF @Opc = 'SelectEmpleados'
BEGIN
SELECT id_Empleado, Nombre, Apellido_Paterno, Apellido_Materno, Nombre_Usuario, Contrasenia, RFC,CURP, 
						Fecha_Nacimiento,Usuario_Administrador FROM Empleados;
END

END
GO

SELECT * FROM Empleados;