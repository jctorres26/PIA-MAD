USE PIA_MAD;

GO
CREATE PROCEDURE sp_GetNumeros
(
@Opc VARCHAR(30),
@id_Cliente INT = NULL
)
AS
BEGIN

IF @Opc = 'NumeroMedidor'
BEGIN
SELECT Numero_Medidor FROM Contrato_Servicio;
 
END

IF @Opc = 'NumeroServicio'
BEGIN
SELECT Numero_Servicio FROM Contrato_Servicio;
 
END

IF @Opc = 'NumeroMedidorCliente'
BEGIN
SELECT Numero_Medidor FROM Contrato_Servicio WHERE id_Cliente = @id_Cliente;
 
END

IF @Opc = 'NumeroServicioCliente'
BEGIN
SELECT Numero_Servicio FROM Contrato_Servicio WHERE id_Cliente = @id_Cliente;
 
END

END