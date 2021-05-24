USE PIA_MAD;

GO
CREATE PROCEDURE sp_SeleccionarRecibo(
@opc VARCHAR(30),
@Numero_Medidor INT = NULL,
@Numero_Servicio INT = NULL,
@Anio INT = NULL,
@Mes INT =NULL
)

AS
BEGIN

IF @Opc = 'NumeroMedidor'
BEGIN
SELECT Nombre_Cliente,Calle,Numero_Exterior,Colonia,CP,Ciudad,Estado,Numero_Medidor,Numero_Servicio,Fecha_Inicio,Fecha,Consumo,
	Consumo_Basico,Consumo_Intermedio,Consumo_Excedente,Tarifa_Basico,Tarifa_Intermedio,Tarifa_Excedente,Subtotal_Basico,
	Subtotal_Intermedio,Subtotal_Excedente,Total,IVA,Importe
FROM vReciboCompleto WHERE Numero_Medidor = @Numero_Medidor AND DATEPART(YEAR,Fecha) = @Anio AND DATEPART(MONTH,Fecha) = @Mes;
END

IF @Opc = 'NumeroServicio'
BEGIN
SELECT Nombre_Cliente,Calle,Numero_Exterior,Colonia,CP,Ciudad,Estado,Numero_Medidor,Numero_Servicio,Fecha_Inicio,Fecha,Consumo,
	Consumo_Basico,Consumo_Intermedio,Consumo_Excedente,Tarifa_Basico,Tarifa_Intermedio,Tarifa_Excedente,Subtotal_Basico,
	Subtotal_Intermedio,Subtotal_Excedente,Total,IVA,Importe
FROM vReciboCompleto WHERE Numero_Servicio = @Numero_Servicio AND DATEPART(YEAR,Fecha) = @Anio AND DATEPART(MONTH,Fecha) = @Mes;
END

END

GO

SELECT * FROM vReciboCompleto;

