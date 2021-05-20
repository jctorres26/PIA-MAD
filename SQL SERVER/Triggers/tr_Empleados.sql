USE PIA_MAD;

GO

CREATE TRIGGER tr_DeleteEmpleado
ON Empleados
INSTEAD OF DELETE
AS
BEGIN

DECLARE  @Id INT
	SELECT @Id = id_Empleado FROM deleted

	UPDATE Empleados SET Eliminado = 1 WHERE id_Empleado = @Id

END

	

GO