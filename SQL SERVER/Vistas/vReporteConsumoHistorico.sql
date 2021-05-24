USE PIA_MAD;

GO

CREATE VIEW vReporteConsumoHistorico
AS
SELECT R.Numero_Servicio, R.Numero_Medidor,DATEPART(YEAR,R.Fecha) AS Año, DATEPART(MONTH, R.Fecha) AS Mes, C.Consumo,R.Importe,
R.Cantidad_Pagada, R.Pendiente_Pago FROM Recibos R INNER JOIN Consumos C
ON R.id_Consumo = C.id_Consumo;

GO


SELECT*FROM Recibos;
SELECT * FROM Consumos;

SELECT * FROM vReporteConsumoHistorico;