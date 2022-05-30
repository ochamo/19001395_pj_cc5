DROP DATABASE IF EXISTS VentaCelulares_19001395_DB_CC5;

CREATE DATABASE VentaCelulares_19001395_DB_CC5;

USE VentaCelulares_19001395_DB_CC5;

CREATE TABLE Departamento(
    IdDep INT AUTO_INCREMENT,
    NombreDep VARCHAR(255) NOT NULL,
    PRIMARY KEY (IdDep)
);

CREATE PROCEDURE SP_GetDepartmento()
    BEGIN
        SELECT d.IdDep, d.NombreDep FROM Departamento d;
    END;

CREATE PROCEDURE SP_InsertDepartamento(
 IN DepId INT,
 IN DepName VARCHAR(255)
)
    BEGIN
        INSERT INTO Departamento(IdDep, NombreDep)
            VALUES(DepId, DepName);
    END;

CALL SP_InsertDepartamento(1, 'Guatemala');
CALL SP_InsertDepartamento(2, 'Antigua Guatemala');
CALL SP_InsertDepartamento(3, 'Alta verapaz');
CALL SP_InsertDepartamento(4, 'Baja verapaz');

CREATE TABLE Municipio(
    IdMuni INT AUTO_INCREMENT,
    IdDep INT NOT NULL,
    NombreMuni VARCHAR(255) NOT NULL,
    PRIMARY KEY(IdMuni),
    FOREIGN KEY (IdDep)
        REFERENCES Departamento(IdDep)
);

DROP PROCEDURE IF EXISTS SP_GetMunicipio;
CREATE PROCEDURE SP_GetMunicipio(IN IdDepartamento INT)
    BEGIN
        SELECT d.IdDep, d.IdMuni, d.NombreMuni FROM Municipio d
        WHERE IdDep = IdDepartamento;
    END;

CREATE PROCEDURE SP_InsertMuni(
 IN DepId INT,
 IN MuniName VARCHAR(255)
)
    BEGIN
        INSERT INTO Municipio(IdDep, NombreMuni)
            VALUES(DepId, MuniName);
    END;

CALL SP_InsertMuni(1, 'Ciudad de Guatemala');
CALL SP_InsertMuni(1, 'Mixco');
CALL SP_InsertMuni(1, 'Chuarrancho');
CALL SP_InsertMuni(2, 'Sacatepequez');
CALL SP_InsertMuni(2, 'San lucas');
CALL SP_InsertMuni(3, 'Cobán');
CALL SP_InsertMuni(4, 'Salama');

CREATE TABLE Roles(
    IdRol INT AUTO_INCREMENT,
    Nombre VARCHAR(100) NOT NULL,
    PRIMARY KEY (IdRol)
);

CREATE PROCEDURE SP_GetRoles()
BEGIN
    SELECT IdRol, Nombre FROM Roles;
END;

CREATE PROCEDURE SP_InsertRole(IN Nom VARCHAR(100))
BEGIN
    INSERT INTO Roles(Nombre) VALUES (Nom);
END;

CALL SP_InsertRole('Admin');
CALL SP_InsertRole('Client');

CREATE TABLE Usuario(
    IdUsuario INT AUTO_INCREMENT,
    IdRol INT NOT NULL,
    Correo VARCHAR(200) NOT NULL,
    Nombres VARCHAR(200) NOT NULL,
    Apellidos VARCHAR(200) NOT NULL,
    FechaNacimiento DATE NOT NULL,
    FechaCreacion DATETIME NOT NULL,
    Dpi VARCHAR(20) NOT NULL,
    Pass VARCHAR(255) NOT NULL,
    PRIMARY KEY(IdUsuario),
    UNIQUE(Correo),
    UNIQUE(Dpi),
    FOREIGN KEY (IdRol) REFERENCES Roles(IdRol)
);

DROP TABLE IF EXISTS Direccion;
CREATE TABLE Direccion(
    IdDireccion INT AUTO_INCREMENT,
    IdUsuario INT NOT NULL,
    IdMunicipio INT NOT NULL,
    Zona INT,
    Avenida VARCHAR(255) NOT NULL,
    Calle VARCHAR(255) NOT NULL,
    PRIMARY KEY(IdDireccion),
    FOREIGN KEY (IdUsuario) REFERENCES Usuario(IdUsuario),
    FOREIGN KEY (IdMunicipio) REFERENCES Municipio(IdMuni)
);

DROP PROCEDURE IF EXISTS SP_GetDireccions;
CREATE PROCEDURE SP_GetDireccions(IN UserId INT)
BEGIN
    SELECT d.IdDireccion,
           d.IdUsuario,
           d.IdMunicipio,
           m.NombreMuni,
           D2.NombreDep,
           d.Zona,
           d.Avenida,
           d.Calle
    FROM Direccion d
    INNER JOIN Municipio m ON d.IdMunicipio = m.IdMuni
    INNER JOIN Departamento D2 on m.IdDep = D2.IdDep
        WHERE IdUsuario = UserId;
END;

DROP PROCEDURE IF EXISTS SP_GetDireccion;
CREATE PROCEDURE SP_GetDireccion(IN DireccionId INT)
BEGIN
    SELECT d.IdDireccion,
           d.IdUsuario,
           d.IdMunicipio,
           m.NombreMuni,
           D2.NombreDep,
           d.Zona,
           d.Avenida,
           d.Calle
    FROM Direccion d
    INNER JOIN Municipio m ON d.IdMunicipio = m.IdMuni
    INNER JOIN Departamento D2 on m.IdDep = D2.IdDep
        WHERE IdDireccion = DireccionId;
END;


CALL SP_GetDireccion(2);

CREATE PROCEDURE SP_InsertDireccion(
IN UsuarioId INT,
IN Muni INT,
IN Zon INT,
IN Ave VARCHAR(255),
IN Cal VARCHAR(255)
)
BEGIN
    INSERT INTO Direccion (IdUsuario, IdMunicipio, Zona, Avenida, Calle)
        VALUES(UsuarioId, Muni, Zon, Ave, Cal);
END;

CALL SP_InsertDireccion(1, 3, 12, '7 avenida', '6ta calle');

CREATE PROCEDURE SP_InsertUsuario(
IN Rol INT,
IN Corr VARCHAR(200),
IN Noms VARCHAR(200),
IN Apells VARCHAR(200),
IN FechaNaci DATE,
IN Dni VARCHAR(20),
in Passs VARCHAR(255)
)
BEGIN
    INSERT INTO Usuario(IdRol, Correo, Nombres, Apellidos, FechaCreacion, Dpi, Pass, FechaNacimiento)
            VALUES(Rol, Corr, Noms, Apells, NOW(), Dni, MD5(Passs), FechaNaci);
END;

DROP PROCEDURE IF EXISTS SP_Get_Login;
CREATE PROCEDURE SP_Get_Login(IN UserName VARCHAR(200), IN Pass VARCHAR(255))
    BEGIN
        SELECT * FROM Usuario U WHERE
            U.Correo = UserName AND U.Pass = MD5(Pass);
    END;

DROP PROCEDURE IF EXISTS SP_UpdatePassword;
CREATE PROCEDURE SP_UpdatePassword(
    IN Passs VARCHAR(255),
    IN UsuarioId INT
)
BEGIN
    UPDATE Usuario SET Pass = Passs
    WHERE IdUsuario = UsuarioId;
END;


CREATE TABLE Nit(
    IdNit INT NOT NULL AUTO_INCREMENT,
    IdUsuario INT NOT NULL,
    NombreNIT VARCHAR(200) NOT NULL,
    Nit VARCHAR(20) NOT NULL,
    PRIMARY KEY(IdNit),
    FOREIGN KEY (IdUsuario) REFERENCES Usuario(IdUsuario)
);

CREATE PROCEDURE SP_InsertNit(
    IN UsuarioId INT,
    IN NitName VARCHAR(200),
    IN NitN VARCHAR(20)
)
BEGIN
    INSERT INTO Nit(IdUsuario, NombreNIT, Nit)
        VALUES(UsuarioId, NitName, NitN);
END;

CREATE PROCEDURE SP_GetNit(IN UsuarioId INT)
BEGIN
    SELECT IdNit, NombreNit, Nit FROM Nit WHERE IdUsuario = UsuarioId;
END;


CREATE TABLE EstatusEnvio(
    IdEstatusEnvio INT NOT NULL AUTO_INCREMENT,
    Descripcion VARCHAR(100) NOT NULL,
    PRIMARY KEY(IdEstatusEnvio)
);

CREATE PROCEDURE SP_InsertEstatusEnvio(IN Descr VARCHAR(100))
BEGIN
    INSERT INTO EstatusEnvio(Descripcion) VALUES (Descr);
END;

CALL SP_InsertEstatusEnvio('Pendiente envio');
CALL SP_InsertEstatusEnvio('Enviado');
CALL SP_InsertEstatusEnvio('Entregado');

CREATE PROCEDURE SP_GetEstatusEnvio()
BEGIN
    SELECT * FROM EstatusEnvio;
END;

CREATE TABLE Pedido(
    IdPedido INT NOT NULL AUTO_INCREMENT,
    IdDireccion INT NOT NULL,
    IdEstatus INT NOT NULL,
    FechaCreacion DATETIME NOT NULL,
    PRIMARY KEY (IdPedido),
    FOREIGN KEY (IdEstatus) REFERENCES EstatusEnvio(IdEstatusEnvio)
);

CREATE PROCEDURE SP_InsertPedido(
    IN IdDirecc INT,
    IN IdEstatu INT
)
BEGIN
    INSERT INTO Pedido(IdDireccion, IdEstatus, FechaCreacion)
        VALUES(IdDirecc, IdEstatu, NOW());
END;

CREATE TABLE Celular(
    IdCelular INT AUTO_INCREMENT,
    Cantidad MEDIUMINT NOT NULL,
    Imagen LONGTEXT NOT NULL,
    Descripcion VARCHAR(200) NOT NULL,
    Caracteristicas TEXT NOT NULL,
    Modelo VARCHAR(100) NOT NULL,
    Precio DECIMAL(10,2) NOT NULL,
    NumSerie VARCHAR(50) NOT NULL,
    PRIMARY KEY(IdCelular)
);

DROP PROCEDURE IF EXISTS SP_InsertCelular;

CREATE PROCEDURE SP_InsertCelular(
IN Cant INT,
IN Img LONGTEXT,
In Descr VARCHAR(200),
IN Caract TEXT,
IN Model VARCHAR(100),
IN Preci DECIMAL(10,2),
IN NumSeri VARCHAR(50)
)
BEGIN
    INSERT INTO Celular(Cantidad, Imagen, Descripcion, Caracteristicas, Modelo, Precio, NumSerie)
        VALUES(Cant, Img, Descr, Caract, Model, Preci, NumSeri);
END;

CREATE PROCEDURE SP_UpdateStockCelular(IN Cant INT, IN IdCel INT)
BEGIN
    UPDATE Celular SET Cantidad = Cant WHERE IdCelular = IdCel;
END;

CREATE PROCEDURE SP_GetCelularDet(IN IdCel INT)
BEGIN
    SELECT * FROM Celular WHERE IdCelular = IdCel;
END;

CREATE TABLE CarritoUsuario(
    IdUsuario INT NOT NULL,
    IdCelular INT NOT NULL,
    Cantidad MEDIUMINT,
    PRIMARY KEY(IdUsuario, IdCelular),
    FOREIGN KEY(IdUsuario)
        REFERENCES Usuario(IdUsuario),
    FOREIGN KEY(IdCelular) REFERENCES Celular(IdCelular)
);

CREATE PROCEDURE SP_InsertCarritoUsuario(
IN IdCelu INT,
IN Cant INT,
IN UsuarioId INT
)
BEGIN
    INSERT INTO CarritoUsuario(IdCelular, Cantidad, IdUsuario)
        VALUES(IdCelu, Cant, UsuarioId);
END;

DROP PROCEDURE IF EXISTS SP_DeleteItemCarrito;

CREATE PROCEDURE SP_DeleteItemCarrito(
    IN IdCel INT,
    IN UsuarioId INT
)
BEGIN
    DELETE FROM CarritoUsuario WHERE IdCelular = IdCel AND IdUsuario = UsuarioId;
END;

DROP PROCEDURE IF EXISTS SP_DeleteCarritoUsuario;

CREATE PROCEDURE SP_DeleteCarritoUsuario(IN UsuarioId INT)
BEGIN
    DELETE FROM CarritoUsuario WHERE IdUsuario = UsuarioId;
END;

DROP PROCEDURE IF EXISTS SP_GetCarrito;
CREATE PROCEDURE SP_GetCarrito(
IN UsuarioId INT
)
BEGIN
    SELECT IdUsuario, CA.IdCelular, CA.Cantidad, C.Imagen, C.Modelo, C.Precio FROM
        CarritoUsuario CA
        INNER JOIN Celular C
        WHERE IdUsuario = UsuarioId;
END;


CREATE TABLE Pago(
    IdPago INT AUTO_INCREMENT,
    NumTarjeta VARCHAR(255) NOT NULL,
    FechaPago DATETIME DEFAULT NOW(),
    Total DECIMAL(10,2) NOT NULL,
    PRIMARY KEY (IdPago)
);

DROP PROCEDURE IF EXISTS SP_InsertPago;
CREATE PROCEDURE SP_InsertPago(IN NumTarj VARCHAR(255), IN Tot DECIMAL(10, 2))
BEGIN
    INSERT INTO Pago(NumTarjeta, Total) VALUES(NumTarj, Tot);
END;

CREATE PROCEDURE SP_GetPago(IN PagoId INT)
BEGIN
    SELECT * FROM Pago WHERE IdPago = PagoId;
END;

CREATE TABLE Factura(
    IdFactura INT AUTO_INCREMENT,
    IdUsuario INT NOT NULL,
    IdPago INT NOT NULL,
    IdPedido INT NOT NULL,
    Nit VARCHAR(20) NOT NULL,
    NombreCliente VARCHAR(200) NOT NULL,
    FechaEmision DATETIME DEFAULT NOW(),
    PRIMARY KEY (IdFactura),
    FOREIGN KEY (IdPago) REFERENCES Pago(IdPago),
    FOREIGN KEY (IdPedido) REFERENCES Pedido(IdPedido),
    FOREIGN KEY (IdUsuario) REFERENCES Usuario(IdUsuario)
);

CREATE PROCEDURE SP_InsertFactura(
IN UsuarioId INT,
IN PagoId INT,
IN PedidoId INT,
IN NitN VARCHAR(20),
IN NombreCli VARCHAR(200)
)
BEGIN
    INSERT INTO Factura(IdUsuario, IdPago, IdPedido, Nit, NombreCliente)
        VALUES(UsuarioId, PagoId, PedidoId, NitN, NombreCli);
END;


DROP PROCEDURE IF EXISTS SP_GetFacturas;
CREATE PROCEDURE SP_GetFacturas(IN UsuarioId INT)
BEGIN
    SELECT f.IdFactura, f.IdUsuario, p.total, f.IdPedido, f.Nit, f.NombreCliente, f.FechaEmision
    FROM Factura f
    INNER JOIN Pago p ON f.IdPago = p.IdPago
    WHERE IdUsuario = UsuarioId;

END;

CREATE TABLE FilaFactura(
    IdFilaFactura INT NOT NULL AUTO_INCREMENT,
    IdFactura INT NOT NULL,
    IdCelular INT NOT NULL,
    Cantidad INT NOT NULL,
    Precio DECIMAL(10, 2) NOT NULL,
    PRIMARY KEY (IdFilaFactura),
    FOREIGN KEY (IdFactura) REFERENCES Factura(IdFactura),
    FOREIGN KEY (IdCelular) REFERENCES Celular(IdCelular)
);

CREATE PROCEDURE SP_InsertFilaFactura(
IN FacturaId INT,
IN CelularId INT,
IN Cant INT,
IN Prec DECIMAL(10, 2)
)
BEGIN
    INSERT INTO FilaFactura(IdFactura, IdCelular, Cantidad, Precio)
        VALUES(FacturaId, CelularId, Cant, Prec);
END;

CREATE PROCEDURE SP_GetFilaFactura(IN FacturaId INT)
BEGIN
    SELECT F.IdFactura, C.Descripcion, C.NumSerie, C.Modelo FROM FilaFactura F
    INNER JOIN Celular C ON F.IdCelular = C.IdCelular
    WHERE F.IdFactura = FacturaId;
END;
