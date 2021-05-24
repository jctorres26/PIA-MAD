USE PIA_MAD;

GO
CREATE PROCEDURE sp_ReporteConsumoHistorico
(
@Opc VARCHAR(30),
@Anio INT = NULL,
@Numero_Medidor INT = NULL,
@Numero_Servicio INT=NULL
)
AS
BEGIN

IF @Opc = 'NumeroMedidor'
BEGIN
SELECT Mes,Consumo AS[Consumo kWh], Importe, Cantidad_Pagada AS [Pagado], Pendiente_Pago AS[Pendiente de Pago] 
FROM vReporteConsumoHistorico WHERE Año = @Anio AND Numero_Medidor = @Numero_Medidor;
 
END

IF @Opc = 'NumeroServicio'
BEGIN
SELECT Mes,Consumo AS[Consumo kWh], Importe, Cantidad_Pagada AS [Pagado], Pendiente_Pago AS[Pendiente de Pago] 
FROM vReporteConsumoHistorico WHERE Año = @Anio AND Numero_Servicio = @Numero_Servicio;
 
END

END

GO
SELECT * FROM vReporteConsumoHistorico;
SELECT Mes FROM vReporteConsumoHistorico;

