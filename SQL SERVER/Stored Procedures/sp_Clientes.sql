USE PIA_MAD;

GO
CREATE PROCEDURE sp_Clientes(
@opc VARCHAR(30),
@id_Cliente INT = NULL,
@Nombre VARCHAR(50) = NULL,
@Apellido_Paterno VARCHAR(25) = NULL,
@Apellido_Materno VARCHAR(25)=NULL,
@Nombre_Usuario VARCHAR(20)=NULL,
@Contrasenia VARCHAR(20)=NULL,
@Email VARCHAR(50)=NULL,
@Genero VARCHAR(10)=NULL,
@CURP VARCHAR(18)=NULL,
@Fecha_Nacimiento DATE = NULL,
@Activo BIT = NULL,
@Eliminado BIT=NULL
)
AS
BEGIN
IF @Opc = 'Insert'
BEGIN
INSERT INTO Clientes(Nombre, Apellido_Paterno, Apellido_Materno, Nombre_Usuario, Contrasenia,Email,Genero, CURP, 
						Fecha_Nacimiento)
VALUES(@Nombre, @Apellido_Paterno, @Apellido_Materno, @Nombre_Usuario, @Contrasenia, @Email, @Genero,
						@CURP,@Fecha_Nacimiento)
END


IF @Opc = 'Update'
BEGIN
UPDATE Clientes SET Nombre = @Nombre, Apellido_Paterno = @Apellido_Paterno, Apellido_Materno = @Apellido_Materno, 
Nombre_Usuario = @Nombre_Usuario, Contrasenia = @Contrasenia,Email = @Email ,Genero = @Genero, CURP = @CURP, 
Fecha_Nacimiento = @Fecha_Nacimiento WHERE id_Cliente = @id_Cliente;

END


IF @Opc = 'Delete'
BEGIN

DELETE FROM Clientes WHERE id_Cliente = @id_Cliente;

END

IF @Opc = 'Restablecer'
BEGIN

UPDATE Clientes SET Activo = 1 WHERE id_Cliente = @id_Cliente;

END


IF @Opc = 'Suspender'
BEGIN

UPDATE Clientes SET Activo = 0 WHERE Nombre_Usuario = @Nombre_Usuario;

END


END

SELECT * FROM Clientes;
SELECT TOP 1 id_Cliente FROM Clientes ORDER BY id_Cliente DESC;
UPDATE Clientes SET Activo =0;
UPDATE Clientes SET Eliminado =1 WHERE id_Cliente = 10001;

DELETE FROM Clientes WHERE id_Cliente = 10011;

DISABLE TRIGGER tr_DeleteCliente ON Clientes;
ENABLE TRIGGER tr_DeleteCliente ON Clientes;