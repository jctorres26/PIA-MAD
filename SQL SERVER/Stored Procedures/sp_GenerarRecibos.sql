USE PIA_MAD;

GO
CREATE PROCEDURE sp_GenerarRecibos(
@opc VARCHAR(30),
@Anio INT = NULL,
@Mes VARCHAR(50) = NULL,
@Tipo_Servicio VARCHAR(10) = NULL,
@id_Empleado INT = NULL
)
AS
BEGIN
IF @Opc = 'Generar'
BEGIN
UPDATE Recibos  SET Generado = 1, id_Empleado = @id_Empleado FROM Recibos R INNER JOIN Contrato_Servicio C ON
R.Numero_Servicio = C.Numero_Servicio WHERE DATEPART(YEAR,Fecha) = @Anio AND DATEPART(MONTH,Fecha) = @Mes
AND C.Tipo_Servicio = @Tipo_Servicio
END

END