USE PIA_MAD;

GO

CREATE VIEW vReporteGeneralAmbos
AS
SELECT R.Numero_Servicio,DATEPART(YEAR,R.Fecha)AS Año, DATEPART(MONTH, R.Fecha) AS Mes,C.Tipo_Servicio, R.Cantidad_Pagada, 
R.Pendiente_Pago FROM Recibos R INNER JOIN Contrato_Servicio C
ON R.Numero_Servicio = C.Numero_Servicio;

GO

SELECT * FROM vReporteGeneralAmbos;

