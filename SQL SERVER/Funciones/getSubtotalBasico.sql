USE PIA_MAD;
GO

CREATE FUNCTION getSubtotalBasico(
@id_Consumo INT,
@id_Tarifa INT
)
RETURNS MONEY
AS
BEGIN
DECLARE @cBasico INT
DECLARE @tBasico MONEY
DECLARE @sBasico MONEY

SET @cBasico = (SELECT Basico FROM Consumos WHERE id_Consumo = @id_Consumo)
SET @tBasico = (SELECT Basico FROM Tarifas WHERE id_Tarifa = @id_Tarifa)
SET @sBasico = @cBasico*@tBasico;

RETURN @sBasico

END

GO

