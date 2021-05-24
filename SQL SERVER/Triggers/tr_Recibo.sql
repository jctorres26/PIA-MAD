USE PIA_MAD;

GO

CREATE TRIGGER tr_Recibo
ON Recibos
AFTER UPDATE
AS
BEGIN

DECLARE  @Id INT
	SELECT @Id = id_Recibo FROM deleted
	
	UPDATE Recibos SET Estatus = 'Pagado' WHERE id_Recibo = @Id AND Pendiente_Pago = 0;
	
END

	

GO

