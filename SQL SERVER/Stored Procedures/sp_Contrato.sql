USE PIA_MAD;

GO
CREATE PROCEDURE sp_Contrato(
@opc VARCHAR(30),
@Numero_Servicio INT = NULL,
@Numero_Medidor INT =NULL,
@Tipo_Servicio VARCHAR(10) = NULL,
@id_Cliente INT = NULL,
@id_Empleado INT = NULL,
@CP INT = NULL,
@Estado VARCHAR(30) = NULL,
@Ciudad VARCHAR(50) = NULL,
@Colonia VARCHAR(50) = NULL,
@Calle VARCHAR(40) = NULL,
@Numero_Exterior INT = NULL
)
AS
BEGIN

IF @Opc = 'Insert'
BEGIN
INSERT INTO Contrato_Servicio(Numero_Medidor, Tipo_Servicio, id_Cliente, id_Empleado, CP, Estado, Ciudad, Colonia,
			Calle, Numero_Exterior) 
			VALUES(@Numero_Medidor, @Tipo_Servicio, (SELECT TOP 1 id_Cliente FROM Clientes ORDER BY id_Cliente DESC), @id_Empleado, @CP, @Estado, @Ciudad, @Colonia,
			@Calle, @Numero_Exterior)

END 

IF @Opc = 'InsertNuevo'
BEGIN
INSERT INTO Contrato_Servicio(Numero_Medidor, Tipo_Servicio, id_Cliente, id_Empleado, CP, Estado, Ciudad, Colonia,
			Calle, Numero_Exterior) 
			VALUES(@Numero_Medidor, @Tipo_Servicio, @id_Cliente, @id_Empleado, @CP, @Estado, @Ciudad, @Colonia,
			@Calle, @Numero_Exterior)

END 

END

SELECT * FROM Contrato_Servicio;