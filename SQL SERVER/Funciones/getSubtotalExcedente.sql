USE PIA_MAD;
GO

CREATE FUNCTION getSubtotalExcedente(
@id_Consumo INT,
@id_Tarifa INT
)
RETURNS MONEY
AS
BEGIN
DECLARE @cExcedente INT
DECLARE @tExcedente MONEY
DECLARE @sExcedente MONEY

SET @cExcedente = (SELECT Excedente FROM Consumos WHERE id_Consumo = @id_Consumo)
SET @tExcedente = (SELECT Excedente FROM Tarifas WHERE id_Tarifa = @id_Tarifa)
SET @sExcedente = @cExcedente*@tExcedente;

RETURN @sExcedente

END

GO
