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
SELECT Año, Mes, 'Industrial' AS [Tipo de Servicio], CAST( ROUND(SUM(Cantidad_Pagada),2)AS MONEY) AS [Total Pagado], 
CAST(ROUND(SUM(Pendiente_Pago),2)AS MONEY)AS[Total Pendiente de Pago] FROM vReporteGeneralIndustrial
WHERE Año= @Anio AND Mes = @Mes GROUP BY Año, Mes;

END

IF @Opc = 'IndustrialTodos'
BEGIN
SELECT Año, Mes, 'Industrial' AS [Tipo de Servicio], CAST( ROUND(SUM(Cantidad_Pagada),2)AS MONEY) AS [Total Pagado], 
CAST(ROUND(SUM(Pendiente_Pago),2)AS MONEY)AS[Total Pendiente de Pago] FROM vReporteGeneralIndustrial
WHERE Año= @Anio GROUP BY Año, Mes;

END

IF @Opc = 'Domestico'
BEGIN
SELECT Año, Mes, 'Domestico' AS [Tipo de Servicio], CAST( ROUND(SUM(Cantidad_Pagada),2)AS MONEY) AS [Total Pagado], 
CAST(ROUND(SUM(Pendiente_Pago),2)AS MONEY)AS[Total Pendiente de Pago] FROM vReporteGeneralDomestico 
WHERE Año= @Anio AND Mes = @Mes GROUP BY Año, Mes;

END

IF @Opc = 'DomesticoTodos'
BEGIN
SELECT Año, Mes, 'Domestico' AS [Tipo de Servicio], CAST( ROUND(SUM(Cantidad_Pagada),2)AS MONEY) AS [Total Pagado], 
CAST(ROUND(SUM(Pendiente_Pago),2)AS MONEY)AS[Total Pendiente de Pago] FROM vReporteGeneralDomestico 
WHERE Año= @Anio GROUP BY Año, Mes;

END

IF @Opc = 'Ambos'
BEGIN

SELECT Año, Mes,Tipo_Servicio AS [Tipo de Servicio], CAST( ROUND(SUM(Cantidad_Pagada),2)AS MONEY) AS [Total Pagado], 
CAST(ROUND(SUM(Pendiente_Pago),2)AS MONEY)AS[Total Pendiente de Pago] FROM vReporteGeneralAmbos
WHERE Año = @Anio AND Mes=@Mes GROUP BY Año, Mes, Tipo_Servicio;

END

IF @Opc = 'AmbosTodos'
BEGIN

SELECT Año, Mes,Tipo_Servicio AS [Tipo de Servicio], CAST( ROUND(SUM(Cantidad_Pagada),2)AS MONEY) AS [Total Pagado], 
CAST(ROUND(SUM(Pendiente_Pago),2)AS MONEY)AS[Total Pendiente de Pago] FROM vReporteGeneralAmbos
WHERE Año = @Anio GROUP BY Año, Mes, Tipo_Servicio;

END

END
