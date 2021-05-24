USE PIA_MAD;

GO
CREATE PROCEDURE sp_Tarifas(
@opc VARCHAR(30),
@id_Tarifa INT = NULL,
@Anio INT = NULL,
@Mes INT = NULL,
@Tipo_Servicio VARCHAR(10) = NULL,
@Basico MONEY = NULL,
@Intermedio MONEY = NULL,
@Excedente MONEY = NULL,
@Id_Empleado INT = NULL
)

AS
BEGIN

IF @Opc = 'Insert'
BEGIN
INSERT INTO Tarifas(Anio, Mes, Tipo_Servicio, Basico, Intermedio, Excedente,Id_Empleado)
VALUES(@Anio, @Mes, @Tipo_Servicio, @Basico, @Intermedio, @Excedente,@Id_Empleado)
END

END


