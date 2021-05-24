USE PIA_MAD;

GO

CREATE VIEW vReporteGeneralDomestico
AS
SELECT R.Numero_Servicio,DATEPART(YEAR,R.Fecha)AS Año, DATEPART(MONTH, R.Fecha) AS Mes, R.Cantidad_Pagada, R.Pendiente_Pago FROM Recibos R INNER JOIN Contrato_Servicio C
ON R.Numero_Servicio = C.Numero_Servicio WHERE C.Tipo_Servicio = 'Domestico';

GO

SELECT * FROM Recibos;
DROP VIEW vReporteGeneralDomestico;

SELECT * FROM vReporteGeneralDomestico;


SELECT Año, Mes, 'Domestico' AS [Tipo de Servicio], CAST( ROUND(SUM(Cantidad_Pagada),2)AS MONEY) AS [Total Pagado], 
CAST(ROUND(SUM(Pendiente_Pago),2)AS MONEY)AS[Total Pendiente de Pago] FROM vReporteGeneralDomestico GROUP BY Año, Mes;