USE PIA_MAD;

GO
CREATE PROCEDURE sp_Consumos(
@opc VARCHAR(30),
@id_Consumo INT = NULL,
@Numero_Medidor INT = NULL,
@Fecha DATE = NULL,
@Consumo INT = NULL,
@Basico INT = NULL,
@Intermedio INT = NULL,
@Excedente INT = NULL,
@id_Empleado INT = NULL
)

AS
BEGIN

IF @Opc = 'Insert'
BEGIN
INSERT INTO Consumos(Numero_Medidor, Fecha, Consumo, Basico, Intermedio, Excedente,id_Empleado)
VALUES(@Numero_Medidor, @Fecha, @Consumo, @Basico, @Intermedio, @Excedente,@id_Empleado)
END

END


SELECT* FROM Consumos;
DELETE FROM Consumos WHERE id_Consumo = 6;