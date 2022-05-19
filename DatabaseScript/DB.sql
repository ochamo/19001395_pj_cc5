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

CREATE TABLE Municipio(
    IdMuni INT AUTO_INCREMENT,
    IdDep INT NOT NULL,
    NombreMuni VARCHAR(255) NOT NULL,
    PRIMARY KEY(IdMuni),
    FOREIGN KEY (IdDep)
        REFERENCES Departamento(IdDep)
);

CREATE PROCEDURE SP_GetMunicipio()
    BEGIN
        SELECT d.IdDep, d.IdMuni, d.NombreMuni FROM Municipio d;
    END;

CREATE PROCEDURE SP_InsertMuni(
 IN DepId INT,
 IN MuniName VARCHAR(255)
)
    BEGIN
        INSERT INTO Municipio(IdDep, NombreMuni)
            VALUES(DepId, MuniName);
    END;

CREATE TABLE Direccion(
    IdDireccion INT,
    IdUsuario INT NOT NULL,
    IdMunicipio INT NOT NULL,
    zona TINYINT,
    avenida VARCHAR(50) NOT NULL,
    calle VARCHAR(50) NOT NULL,
    PRIMARY KEY(IdDireccion),
    FOREIGN KEY (IdUsuario) REFERENCES Usuario(IdUsuario),
    FOREIGN KEY (IdMunicipio) REFERENCES Municipio(IdMuni)
);

CREATE PROCEDURE SP_GetDireccion(IN UserId INT)
BEGIN
    SELECT iddireccion, idusuario, idmunicipio,
           zona, avenida, calle  FROM Direccion d WHERE IdUsuario = UserId;
END;

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

CREATE TABLE Usuario(
    IdUsuario INT AUTO_INCREMENT,
    IdRol INT NOT NULL,
    Correo VARCHAR(200) NOT NULL,
    Nombres VARCHAR(200) NOT NULL,
    Apellidos VARCHAR(200) NOT NULL,
    FechaNacimiento DATE NOT NULL,
    FechaCreacion DATETIME NOT NULL,
    Dpi VARCHAR(20) NOT NULL,
    Pass VARCHAR(10) NOT NULL,
    PRIMARY KEY(IdUsuario),
    UNIQUE(Correo),
    UNIQUE(Dpi),
    FOREIGN KEY (IdRol) REFERENCES Roles(IdRol)
);

CREATE PROCEDURE SP_InsertUsuario(
IN Rol INT,
IN Corr VARCHAR(200),
IN Noms VARCHAR(200),
IN Apells VARCHAR(200),
IN FechaNaci DATE,
IN Dni VARCHAR(20),
in Passs VARCHAR(20)
)
BEGIN
    INSERT INTO Usuario(IdRol, Correo, Nombres, Apellidos, FechaCreacion, Dpi, Pass, FechaNacimiento)
            VALUES(Rol, Corr, Noms, Apells, NOW(), Dni, MD5(Passs), FechaNaci);
END;

CREATE PROCEDURE SP_Get_Login(IN UserName VARCHAR(200), IN Pass VARCHAR(20))
    BEGIN
        SELECT * FROM Usuario U WHERE
            U.Correo = UserName AND U.Pass = MD5(Pass);
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

CREATE TABLE CarritoUsuario(
    IdUsuario INT NOT NULL,
    IdCelular INT NOT NULL,
    Cantidad MEDIUMINT,
    PRIMARY KEY(IdUsuario, IdCelular),
    FOREIGN KEY(IdUsuario)
        REFERENCES Usuario(IdUsuario),
    FOREIGN KEY(IdCelular) REFERENCES Celular(IdCelular)
);

CREATE PROCEDURE SP_CarritoUsuario(
IN IdCelu INT,
IN Cant INT,
IN UsuarioId INT,
)
BEGIN
    INSERT INTO CarritoUsuario(IdCelular, Cantidad, IdUsuario)
        VALUES(IdCelu, Cant, UsuarioId);
END;

CREATE PROCEDURE SP_GetCarrito(
IN UsuarioId INT
)
BEGIN
    SELECT IdUsuario,IdCelular,Cantidad FROM
        CarritoUsuario WHERE IdUsuario = UsuarioId;
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
    IsDisponible VARCHAR(1) NOT NULL,
    PRIMARY KEY(IdCelular)
);

CREATE PROCEDURE SP_InsertCelular(
IN Cant INT,
IN Img LONGTEXT,
In Descr VARCHAR(200),
IN Caract TEXT,
IN Model VARCHAR(100),
IN Preci DECIMAL(10,2),
IN NumSeri VARCHAR(50),
IN IsDispo VARCHAR(1)
)
BEGIN
    INSERT INTO Celular(Cantidad, Imagen, Descripcion, Caracteristicas, Modelo, Precio, NumSerie, IsDisponible)
        VALUES(Cant, Img, Descr, Caract, Model, Preci, NumSeri, IsDispo);
END;

CREATE PROCEDURE SP_UpdateStockCelular(IN Cant INT, IN IdCel INT)
BEGIN
    UPDATE Celular SET Cantidad = Cant WHERE IdCelular = IdCel;
END;

CREATE TABLE Pago(
    IdPago INT AUTO_INCREMENT,
    NumTarjeta VARCHAR(255) NOT NULL,
    FechaPago DATETIME DEFAULT NOW(),
    Total DECIMAL(10,2) NOT NULL,
    PRIMARY KEY (IdPago)
);

CREATE PROCEDURE SP_InsertPago(IN NumTarj VARCHAR(255), IN Tot DECIMAL(10, 2))
BEGIN
    INSERT INTO Pago(NumTarjeta, Total) VALUES(MD5(NumTarj, Tot));
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
        VALUES(UsuarioId, PagoId, PedidoId, NitN, NombreCli)
END;

CREATE PROCEDURE SP_GetFacturas(IN UsuarioId INT)
BEGIN
    SELECT * FROM Factura WHERE UsuarioId;
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
    SELECT F.IdFactura, C.descripcion, C.NumSerie, C.Modelo FROM FilaFactura F
    INNER JOIN Celular C ON F.IdCelular = C.IdCelular
    WHERE F.IdFactura = FacturaId;
END;|
