USE PIA_MAD;

GO

CREATE VIEW vReporteGeneralAmbos
AS
SELECT R.Numero_Servicio,DATEPART(YEAR,R.Fecha)AS A�o, DATEPART(MONTH, R.Fecha) AS Mes,C.Tipo_Servicio, R.Cantidad_Pagada, 
R.Pendiente_Pago FROM Recibos R INNER JOIN Contrato_Servicio C
ON R.Numero_Servicio = C.Numero_Servicio;

GO

SELECT * FROM vReporteGeneralAmbos;

SELECT A�o, Mes,Tipo_Servicio, CAST( ROUND(SUM(Cantidad_Pagada),2)AS MONEY) AS [Total Pagado], 
CAST(ROUND(SUM(Pendiente_Pago),2)AS MONEY)AS[Total Pendiente de Pago] FROM vReporteGeneralAmbos
WHERE A�o = 2020 GROUP BY A�o, Mes, Tipo_Servicio;