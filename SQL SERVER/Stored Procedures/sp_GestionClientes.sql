USE PIA_MAD;

GO
CREATE PROCEDURE sp_GestionClientes(
@opc VARCHAR(30),
@id_Empleado INT = NULL,
@id_Cliente INT = NULL
)
AS
BEGIN

IF @Opc = 'Alta'
BEGIN
INSERT INTO Gestion_Clientes(id_Empleado,id_Cliente,Fecha_alta, Fecha_modificacion) 
VALUES (@id_Empleado,@id_Cliente,CURRENT_TIMESTAMP, 0);

END

IF @Opc = 'Cambio'
BEGIN
INSERT INTO Gestion_Clientes(id_Empleado,id_Cliente,Fecha_alta, Fecha_modificacion) 
VALUES (@id_Empleado,@id_Cliente,0, CURRENT_TIMESTAMP);

END


END


GO

SELECT * FROM Gestion_Clientes;

INSERT INTO Gestion_Clientes(id_Empleado,id_Cliente) VALUES(10020,10001);
DELETE FROM Gestion_Clientes;

EXEC sp_GestionClientes 'Alta',10020,10001;