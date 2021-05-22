USE PIA_MAD;
GO

CREATE FUNCTION getSubtotalIntermedio(
@id_Consumo INT,
@id_Tarifa INT
)
RETURNS MONEY
AS
BEGIN
DECLARE @cIntermedio INT
DECLARE @tIntermedio MONEY
DECLARE @sIntermedio MONEY

SET @cIntermedio = (SELECT Intermedio FROM Consumos WHERE id_Consumo = @id_Consumo)
SET @tIntermedio = (SELECT Intermedio FROM Tarifas WHERE id_Tarifa = @id_Tarifa)
SET @sIntermedio = @cIntermedio*@tIntermedio;

RETURN @sIntermedio

END

GO
