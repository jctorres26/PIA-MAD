

CREATE TABLE Administrador(
Nombre_Usuario			VARCHAR(20) NOT NULL, 
Contrasenia				VARCHAR (20) NOT NULL,
PRIMARY KEY (Nombre_Usuario)
 );

CREATE TABLE Empleados(
id_Empleado				INT IDENTITY (10000,1) NOT NULL, 
Nombre					VARCHAR (50) NOT NULL, 
Apellido_Paterno			VARCHAR (25) NOT NULL, 
Apellido_Materno			VARCHAR (25) NOT NULL, 
Nombre_Usuario			VARCHAR (20) NOT NULL UNIQUE, 
Contrasenia				VARCHAR (20) NOT NULL,
RFC					VARCHAR (13) UNIQUE, 
CURP					VARCHAR (18) UNIQUE, 
Fecha_Nacimiento			DATE, 
Activo					BIT DEFAULT 1, 
Eliminado				BIT DEFAULT 0,
Usuario_Administrador		VARCHAR (20) NOT NULL
PRIMARY KEY (id_Empleado)
);

SELECT * FROM Empleados;

Restricciones: En el nombre y apellidos no se permitirá el ingreso de números

CREATE TABLE Clientes(
id_Cliente				INT IDENTITY (10000,1) NOT NULL, 
Nombre					VARCHAR (50) NOT NULL, 
Apellido_Paterno			VARCHAR (25) NOT NULL, 
Apellido_Materno			VARCHAR (25) NOT NULL, 
Nombre_Usuario			VARCHAR (20) NOT NULL UNIQUE, 
Contrasenia				VARCHAR (20) NOT NULL,  
Email					VARCHAR (50) UNIQUE, 
Genero					VARCHAR (10) NOT NULL, 
CURP					VARCHAR (18) NOT NULL UNIQUE, 
Fecha_Nacimiento			DATE,	 
Activo					BIT DEFAULT 1,
Eliminado				BIT DEFAULT 0,
PRIMARY KEY (id_Cliente)
);
Restricciones: En el nombre y apellidos no se permitirá el ingreso de números


CREATE TABLE Gestion_Clientes(
id_Empleado				INT NOT NULL, 
id_Cliente				INT NOT NULL, 
Fecha_alta				DATETIME , 
Fecha_modificacion			DATETIME ,
PRIMARY KEY (id_Empleado, id_Cliente, Fecha_alta, Fecha_modificacion)
);



CREATE TABLE Contrato_Servicio(
Numero_Servicio			INT IDENTITY (1000,1) NOT NULL, 
Numero_Medidor         		INT NOT NULL UNIQUE, 
Tipo_Servicio         		VARCHAR (10) NOT NULL, 
id_Cliente				INT NOT NULL, 
id_Empleado				INT NOT NULL, 
CP					INT NOT NULL,
Estado					VARCHAR (30) NOT NULL, 
Ciudad					VARCHAR (50) NOT NULL, 
Colonia				VARCHAR (50) NOT NULL, 
Calle					VARCHAR (40) NOT NULL, 
Numero_Exterior			INT NOT NULL,
PRIMARY KEY (Numero_Servicio)
);

Restricciones: En el numero de medidor, numero exterior y CP solo se permitirá el ingreso de números enteros. En estado, ciudad, colonia y calle no se permitirán números.


CREATE TABLE Tarifas (
id_Tarifa				INT IDENTITY (1,1) NOT NULL, 
Anio INT NOT NULL,
Mes INT NOT NULL,
Tipo_Servicio				VARCHAR (10) NOT NULL,  
Basico					MONEY, 
Intermedio				MONEY, 
Excedente				MONEY, 
Id_Empleado				INT NOT NULL,
PRIMARY KEY (id_Tarifa)
);

Restricciones: En básico, intermedio y excedente pueden existir números con decimal pero no negativos.
DROP TABLE Tarifas;

CREATE TABLE Consumos (
id_Consumo				INT IDENTITY (1,1) NOT NULL,
Numero_Medidor			INT NOT NULL, 
Fecha					DATE, 
Consumo				INT, 
Basico					INT, 
Intermedio				INT, 
Excedente				INT, 
id_Empleado				INT NOT NULL,
PRIMARY KEY (id_Consumo)
);

DROP TABLE Consumos;

Restricciones: En básico, intermedio y excedente solo se permitirán números enteros.


CREATE TABLE Recibos (
id_Recibo				INT IDENTITY(1,1) NOT NULL, 
Numero_Servicio 			INT NOT NULL, 
Numero_Medidor			INT NOT NULL, 
Fecha					DATE NOT NULL,
Fecha_Inicio            DATE NOT NULL, 
Estatus				VARCHAR(20) NOT NULL, 
id_Consumo				INT NOT NULL, 
id_Tarifa				INT NOT NULL, 
Subtotal_Basico			MONEY, 
Subtotal_Intermedio			MONEY, 
Subtotal_Excedente			MONEY, 
Total                     MONEY,
IVA                       MONEY,
Importe				MONEY, 
Cantidad_Pagada			MONEY, 
Pendiente_Pago			MONEY, 
id_Empleado 				INT, 
id_Cliente				INT NOT NULL,
Generado            BIT DEFAULT 0,
PRIMARY KEY (id_Recibo)
);

DROP TABLE Recibos;

-LLAVES FORANEAS

ALTER TABLE Empleados ADD CONSTRAINT FK_EMPLEADOS_ADMIN
FOREIGN KEY (Usuario_Administrador) REFERENCES Administrador(Nombre_Usuario);

ALTER TABLE Contrato_Servicio ADD CONSTRAINT FK_CONTRATO_CLIENTE
FOREIGN KEY (id_Cliente) REFERENCES Clientes(id_Cliente);

ALTER TABLE Contrato_Servicio ADD CONSTRAINT FK_CONTRATO_EMPLEADO
FOREIGN KEY (id_Empleado) REFERENCES Empleados(id_Empleado);

ALTER TABLE Tarifas ADD CONSTRAINT FK_TARIFA_EMPLEADO
FOREIGN KEY (id_Empleado) REFERENCES Empleados(id_Empleado);

ALTER TABLE Consumos ADD CONSTRAINT FK_CONSUMO_EMPLEADO
FOREIGN KEY (id_Empleado) REFERENCES Empleados(id_Empleado);

ALTER TABLE Recibos ADD CONSTRAINT FK_RECIBOS_EMPLEADO
FOREIGN KEY (id_Empleado) REFERENCES Empleados(id_Empleado);

ALTER TABLE Recibos ADD CONSTRAINT FK_RECIBOS_CLIENTE
FOREIGN KEY (id_Cliente) REFERENCES Clientes(id_Cliente);

ALTER TABLE Recibos ADD CONSTRAINT FK_RECIBOS_CSERVICIO
FOREIGN KEY (Numero_Servicio) REFERENCES Contrato_Servicio(Numero_Servicio);

ALTER TABLE Recibos ADD CONSTRAINT FK_RECIBOS_TARIFA
FOREIGN KEY (id_Tarifa) REFERENCES Tarifas(id_Tarifa);

ALTER TABLE Recibos ADD CONSTRAINT FK_RECIBOS_CONSUMO
FOREIGN KEY (id_Consumo) REFERENCES Consumos(id_Consumo);

ALTER TABLE Gestion_Clientes ADD CONSTRAINT FK_GESTION_EMPLEADO
FOREIGN KEY (id_Empleado) REFERENCES Empleados(id_Empleado);

ALTER TABLE Gestion_Clientes ADD CONSTRAINT FK_GESTION_CLIENTE
FOREIGN KEY (id_Cliente) REFERENCES Clientes(id_Cliente);


INSERT INTO Administrador (Nombre_Usuario,Contrasenia) VALUES ('admin','contra');
SELECT * FROM Administrador;





