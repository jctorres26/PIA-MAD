USE PIA_MAD;

GO
CREATE PROCEDURE sp_RecibosClientes(
@opc VARCHAR(30),
@id_Cliente INT = NULL,
@Numero_Servicio INT =NULL
)
AS
BEGIN
IF @Opc = 'SelectServicio'
BEGIN

SELECT Numero_Servicio  FROM Recibos WHERE id_Cliente = @id_Cliente GROUP BY Numero_Servicio;

END

IF @Opc = 'SelectFecha'
BEGIN

SELECT Fecha, Pendiente_Pago FROM Recibos WHERE Numero_Servicio = @Numero_Servicio AND Generado = 1;

END




END

GO