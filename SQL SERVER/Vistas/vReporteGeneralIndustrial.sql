USE PIA_MAD;

GO

CREATE VIEW vReporteGeneralIndustrial
AS
SELECT R.Numero_Servicio,DATEPART(YEAR,R.Fecha)AS Año, DATEPART(MONTH, R.Fecha) AS Mes, R.Cantidad_Pagada, R.Pendiente_Pago FROM Recibos R INNER JOIN Contrato_Servicio C
ON R.Numero_Servicio = C.Numero_Servicio WHERE C.Tipo_Servicio = 'Industrial';

GO

SELECT * FROM Recibos;
DROP VIEW vReporteGeneralIndustrial;

SELECT * FROM vReporteGeneralIndustrial;

SELECT Año, Mes, 'Industrial' AS [Tipo de Servicio], CAST( ROUND(SUM(Cantidad_Pagada),2)AS MONEY) AS [Total Pagado], 
CAST(ROUND(SUM(Pendiente_Pago),2)AS MONEY)AS[Total Pendiente de Pago] FROM vReporteGeneralIndustrial GROUP BY Año, Mes;

SELECT Año, Mes, 'Industrial' AS [Tipo de Servicio], CAST( ROUND(SUM(Cantidad_Pagada),2)AS MONEY) AS [Total Pagado], 
CAST(ROUND(SUM(Pendiente_Pago),2)AS MONEY)AS[Total Pendiente de Pago] FROM vReporteGeneralIndustrial
WHERE Año = 2020 GROUP BY Año, Mes;
