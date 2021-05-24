USE PIA_MAD;

GO
CREATE PROCEDURE sp_ReportesTC
(
@Opc VARCHAR(30),
@Anio INT
)
AS
BEGIN

IF @Opc = 'ReporteTarifas'
BEGIN
SELECT Anio AS Año, Mes, Tipo_Servicio AS Tipo, Basico, Intermedio, Excedente FROM Tarifas WHERE Anio = @Anio
END

IF @Opc = 'ReporteConsumos'
BEGIN
SELECT DATEPART(YEAR,Fecha) AS Año, DATEPART(MONTH,Fecha) AS Mes, Numero_Medidor AS [Numero de medidor],
 Basico AS [Kw Basico], Intermedio AS [Kw Intermedio], Excedente AS [Kw Excedente] FROM Consumos WHERE DATEPART(YEAR,Fecha) = @Anio;
END


END
GO

SELECT * FROM Consumos;
SELECT * FROM Tarifas;

EXEC sp_ReportesTC 'ReporteConsumos',2020;