USE PIA_MAD;

GO
CREATE PROCEDURE sp_Recibos(
@opc VARCHAR(30),
@id_Recibo INT = NULL,
@Numero_Servicio INT = NULL,
@Numero_Medidor INT = NULL,
@Fecha DATE = NULL,
@Fecha_Inicio DATE = NULL,
@Estatus VARCHAR(20) = NULL,
@id_Consumo INT = NULL,
@id_Tarifa INT = NULL,
@Subtotal_Basico MONEY = NULL,
@Subtotal_Intermedio MONEY = NULL,
@Subtotal_Excedente MONEY = NULL,
@Total MONEY = NULL,
@IVA MONEY = NULL,
@Importe MONEY = NULL,
@Cantidad_Pagada MONEY = NULL,
@Pendiente_Pago MONEY = NULL,
@id_Empleado INT = NULL,
@id_Cliente INT = NULL,
@Generado BIT = NULL
)
AS
BEGIN

DECLARE @idConsumo INT
SET @idConsumo = (SELECT TOP 1 id_Consumo FROM Consumos ORDER BY id_Consumo DESC)

IF @Opc = 'Insert'
BEGIN
INSERT INTO Recibos(Numero_Servicio, Numero_Medidor, Fecha, Fecha_Inicio, Estatus,id_Consumo, id_Tarifa,Cantidad_Pagada,id_Cliente)
VALUES(@Numero_Servicio, @Numero_Medidor, @Fecha, @Fecha_Inicio, @Estatus,@idConsumo, 
@id_Tarifa,@Cantidad_Pagada,@id_Cliente)
END

IF @Opc = 'CompletarRecibo'
BEGIN
UPDATE Recibos SET Subtotal_Basico = dbo.getSubtotalBasico(@idConsumo,@id_Tarifa), 
Subtotal_Intermedio= dbo.getSubtotalIntermedio(@idConsumo,@id_Tarifa),
Subtotal_Excedente=  dbo.getSubtotalExcedente(@idConsumo,@id_Tarifa),
Total = ( dbo.getSubtotalBasico(@idConsumo,@id_Tarifa) + dbo.getSubtotalIntermedio(@idConsumo,@id_Tarifa) + dbo.getSubtotalExcedente(@idConsumo,@id_Tarifa) ),
IVA = CAST(ROUND(( (dbo.getSubtotalBasico(@idConsumo,@id_Tarifa) + dbo.getSubtotalIntermedio(@idConsumo,@id_Tarifa) + dbo.getSubtotalExcedente(@idConsumo,@id_Tarifa) ) *0.16),2)AS MONEY),
Importe = CAST(ROUND(( dbo.getSubtotalBasico(@idConsumo,@id_Tarifa) + dbo.getSubtotalIntermedio(@idConsumo,@id_Tarifa) + dbo.getSubtotalExcedente(@idConsumo,@id_Tarifa) ) +
			( (dbo.getSubtotalBasico(@idConsumo,@id_Tarifa) + dbo.getSubtotalIntermedio(@idConsumo,@id_Tarifa) + dbo.getSubtotalExcedente(@idConsumo,@id_Tarifa) ) *0.16),2)AS MONEY),
Pendiente_Pago = CAST(ROUND(( dbo.getSubtotalBasico(@idConsumo,@id_Tarifa) + dbo.getSubtotalIntermedio(@idConsumo,@id_Tarifa) + dbo.getSubtotalExcedente(@idConsumo,@id_Tarifa) ) +
			( (dbo.getSubtotalBasico(@idConsumo,@id_Tarifa) + dbo.getSubtotalIntermedio(@idConsumo,@id_Tarifa) + dbo.getSubtotalExcedente(@idConsumo,@id_Tarifa) ) *0.16),2)AS MONEY)
			WHERE id_Recibo = (SELECT TOP 1 id_Recibo FROM Recibos ORDER BY id_Recibo DESC)
END

IF @Opc = 'Pagar'
BEGIN

IF @Cantidad_Pagada >= (SELECT Pendiente_Pago FROM Recibos WHERE Numero_Servicio = @Numero_Servicio AND Fecha = @Fecha)
UPDATE Recibos SET Pendiente_Pago = 0, Cantidad_Pagada = Importe WHERE Numero_Servicio = @Numero_Servicio AND Fecha = @Fecha;

IF @Cantidad_Pagada < (SELECT Pendiente_Pago FROM Recibos WHERE Numero_Servicio = @Numero_Servicio AND Fecha = @Fecha)
UPDATE Recibos SET Pendiente_Pago = (Pendiente_Pago - @Cantidad_Pagada), Cantidad_Pagada = (@Cantidad_Pagada + Cantidad_Pagada) 
 WHERE Numero_Servicio = @Numero_Servicio AND Fecha = @Fecha;

END

END

SELECT * FROM Recibos;
DELETE  FROM Recibos;
UPDATE Recibos SET Generado =0;

UPDATE Recibos SET Cantidad_Pagada = 0;

UPDATE Recibos SET Subtotal_Basico =  dbo.getSubtotalBasico(8,6) WHERE id_Recibo = 1;