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
SELECT CONCAT(id_Empleado, ' ', Nombre, ' ',Apellido_Paterno , ' ' ,Apellido_Materno) AS Nombre_Completo, id_Empleado, Nombre, Apellido_Paterno, Apellido_Materno, Nombre_Usuario, Contrasenia, RFC,CURP, 
						Fecha_Nacimiento,Usuario_Administrador FROM Empleados WHERE Eliminado = 0;
END

IF @Opc = 'SelectClientes'
BEGIN

SELECT CONCAT(id_Cliente, ' ', Nombre, ' ',Apellido_Paterno , ' ' ,Apellido_Materno) AS Nombre_Completo, id_Cliente, Nombre, Apellido_Paterno, Apellido_Materno, Nombre_Usuario, Contrasenia, Email,
Genero, CURP, Fecha_Nacimiento FROM Clientes WHERE Eliminado = 0;

END


IF @Opc = 'SelectUsuariosEmpleados'
BEGIN

SELECT id_Empleado, Nombre_Usuario, Contrasenia FROM Empleados WHERE Eliminado = 0 AND Activo = 1;

END

IF @Opc = 'SelectUsuariosClientes'
BEGIN

SELECT id_Cliente, Nombre_Usuario, Contrasenia FROM Clientes WHERE Eliminado = 0 AND Activo = 1;

END

IF @Opc = 'SelectTarifas'
BEGIN

SELECT id_Tarifa, Anio, Mes, Tipo_Servicio FROM Tarifas;

END


IF @Opc = 'SelectContrato'
BEGIN

SELECT Numero_Medidor, id_Cliente, Tipo_Servicio, Numero_Servicio FROM Contrato_Servicio;

END

IF @Opc = 'SelectConsumos'
BEGIN

SELECT Numero_Medidor, DatePart(Year,Fecha) AS [Anio], DATEPART(Month,Fecha) AS [Mes] FROM Consumos;

END


END
GO

SELECT * FROM Empleados;
DELETE FROM Empleados;