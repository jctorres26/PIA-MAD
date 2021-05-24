USE PIA_MAD;

GO

CREATE VIEW vReciboCompleto
AS
SELECT 
CONCAT(C.Nombre,' ',C.Apellido_Paterno,' ',C.Apellido_Materno) Nombre_Cliente,
Cont.Calle,
Cont.Numero_Exterior,
Cont.Colonia,
Cont.CP,
Cont.Ciudad,
Cont.Estado,
Cont.Numero_Medidor,
Cont.Numero_Servicio,
Cont.Tipo_Servicio,
R.Fecha_Inicio,
R.Fecha,
Cons.Consumo,
Cons.Basico AS Consumo_Basico,
Cons.Intermedio AS Consumo_Intermedio,
Cons.Excedente AS Consumo_Excedente,
T.Basico AS Tarifa_Basico,
T.Intermedio AS Tarifa_Intermedio,
T.Excedente AS Tarifa_Excedente,
R.Subtotal_Basico,
R.Subtotal_Intermedio,
R.Subtotal_Excedente,
R.Total,
R.IVA,
R.Importe,
R.Estatus,
R.Generado,
Cont.id_Cliente


FROM Clientes C
INNER JOIN Contrato_Servicio Cont ON C.id_Cliente = Cont.id_Cliente
INNER JOIN Consumos Cons ON Cons.Numero_Medidor = Cont.Numero_Medidor
INNER JOIN Recibos R ON R.id_Consumo = Cons.id_Consumo
INNER JOIN Tarifas T ON R.id_Tarifa = T.id_Tarifa

GO

SELECT * FROM vReciboCompleto;
