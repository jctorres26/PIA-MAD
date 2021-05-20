USE PIA_MAD;

GO

CREATE TRIGGER tr_DeleteCliente
ON Clientes
INSTEAD OF DELETE
AS
BEGIN

DECLARE  @Id INT
	SELECT @Id = id_Cliente FROM deleted

	UPDATE Clientes SET Eliminado = 1 WHERE id_Cliente = @Id

END

	

GO