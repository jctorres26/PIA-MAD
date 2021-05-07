USE PIA_MAD;

GO
CREATE PROCEDURE sp_Empleados(
@opc VARCHAR(20),
@id_Empleado INT = NULL,
@Nombre VARCHAR(50) = NULL,
@Apellido_Paterno VARCHAR(25) = NULL,
@Apellido_Materno VARCHAR(25)=NULL,
@Nombre_Usuario VARCHAR(20)=NULL,
@Contrasenia VARCHAR(20)=NULL,
@RFC VARCHAR(13)=NULL,
@CURP VARCHAR(18)=NULL,
@Fecha_Nacimiento DATE = NULL,
@Activo BIT = NULL,
@Usuario_Administrador VARCHAR(20)=NULL
)
AS
BEGIN

IF @Opc = 'Insert'
BEGIN
INSERT INTO Empleados(Nombre, Apellido_Paterno, Apellido_Materno, Nombre_Usuario, Contrasenia, RFC,CURP, 
						Fecha_Nacimiento,Usuario_Administrador)
VALUES(@Nombre, @Apellido_Paterno, @Apellido_Materno, @Nombre_Usuario, @Contrasenia, @RFC, 
						@CURP,@Fecha_Nacimiento,@Usuario_Administrador)
END

END
GO


SELECT * FROM Empleados;
DELETE FROM Empleados;
