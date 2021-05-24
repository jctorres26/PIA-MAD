USE PIA_MAD;

GO
CREATE PROCEDURE sp_ReporteGeneral
(
@Opc VARCHAR(30),
@Anio INT = NULL,
@Mes INT = NULL
)
AS
BEGIN

IF @Opc = 'Industrial'
BEGIN
SELECT A�o, Mes, 'Industrial' AS [Tipo de Servicio], CAST( ROUND(SUM(Cantidad_Pagada),2)AS MONEY) AS [Total Pagado], 
CAST(ROUND(SUM(Pendiente_Pago),2)AS MONEY)AS[Total Pendiente de Pago] FROM vReporteGeneralIndustrial
WHERE A�o= @Anio AND Mes = @Mes GROUP BY A�o, Mes;

END

IF @Opc = 'IndustrialTodos'
BEGIN
SELECT A�o, Mes, 'Industrial' AS [Tipo de Servicio], CAST( ROUND(SUM(Cantidad_Pagada),2)AS MONEY) AS [Total Pagado], 
CAST(ROUND(SUM(Pendiente_Pago),2)AS MONEY)AS[Total Pendiente de Pago] FROM vReporteGeneralIndustrial
WHERE A�o= @Anio GROUP BY A�o, Mes;

END

IF @Opc = 'Domestico'
BEGIN
SELECT A�o, Mes, 'Domestico' AS [Tipo de Servicio], CAST( ROUND(SUM(Cantidad_Pagada),2)AS MONEY) AS [Total Pagado], 
CAST(ROUND(SUM(Pendiente_Pago),2)AS MONEY)AS[Total Pendiente de Pago] FROM vReporteGeneralDomestico 
WHERE A�o= @Anio AND Mes = @Mes GROUP BY A�o, Mes;

END

IF @Opc = 'DomesticoTodos'
BEGIN
SELECT A�o, Mes, 'Domestico' AS [Tipo de Servicio], CAST( ROUND(SUM(Cantidad_Pagada),2)AS MONEY) AS [Total Pagado], 
CAST(ROUND(SUM(Pendiente_Pago),2)AS MONEY)AS[Total Pendiente de Pago] FROM vReporteGeneralDomestico 
WHERE A�o= @Anio GROUP BY A�o, Mes;

END

IF @Opc = 'Ambos'
BEGIN

SELECT A�o, Mes,Tipo_Servicio AS [Tipo de Servicio], CAST( ROUND(SUM(Cantidad_Pagada),2)AS MONEY) AS [Total Pagado], 
CAST(ROUND(SUM(Pendiente_Pago),2)AS MONEY)AS[Total Pendiente de Pago] FROM vReporteGeneralAmbos
WHERE A�o = @Anio AND Mes=@Mes GROUP BY A�o, Mes, Tipo_Servicio;

END

IF @Opc = 'AmbosTodos'
BEGIN

SELECT A�o, Mes,Tipo_Servicio AS [Tipo de Servicio], CAST( ROUND(SUM(Cantidad_Pagada),2)AS MONEY) AS [Total Pagado], 
CAST(ROUND(SUM(Pendiente_Pago),2)AS MONEY)AS[Total Pendiente de Pago] FROM vReporteGeneralAmbos
WHERE A�o = @Anio GROUP BY A�o, Mes, Tipo_Servicio;

END

END
