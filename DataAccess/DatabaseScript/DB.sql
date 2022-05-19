DROP DATABASE IF EXISTS VentaCelulares_19001395_DB_CC5;

CREATE DATABASE VentaCelulares_19001395_DB_CC5;

USE VentaCelulares_19001395_DB_CC5;

CREATE TABLE Departamento(
    IdDep INT AUTO_INCREMENT,
    NombreDep VARCHAR(50) NOT NULL,
    PRIMARY KEY (IdDep)
);

CREATE TABLE Municipio(
    IdMuni INT AUTO_INCREMENT,
    IdDep INT NOT NULL,
    NombreMuni VARCHAR(50) NOT NULL,
    PRIMARY KEY(IdMuni),
    FOREIGN KEY (IdDep)
        REFERENCES Departamento(IdDep)
);

CREATE TABLE Direccion(
    IdDireccion INT,
    IdUsuario INT NOT NULL,
    IdMunicipio INT NOT NULL,
    zona TINYINT NOT NULL,
    avenida VARCHAR(50) NOT NULL,
    calle VARCHAR(50) NOT NULL,
    IsDeleted TINYINT NOT NULL,
    DeleteDate DATE NOT NULL,
    PRIMARY KEY(IdDireccion),
    FOREIGN KEY (IdUsuario) REFERENCES Usuario(IdUsuario),
    FOREIGN KEY (IdMunicipio) REFERENCES Municipio(IdMuni)
);

CREATE TABLE Usuario(
    IdUsuario INT AUTO_INCREMENT,
    Correo VARCHAR(50) NOT NULL,
    Nombres VARCHAR(50) NOT NULL,
    Apellidos VARCHAR(50) NOT NULL,
    FechaNacimiento DATE NOT NULL,
    FechaCreacion DATE NOT NULL,
    Dpi VARCHAR(15) NOT NULL,
    Password VARCHAR(10) NOT NULL,
    PRIMARY KEY(IdUsuario),
    UNIQUE(Correo),
    UNIQUE(Dpi)
);

CREATE TABLE Roles(
    IdRol INT AUTO_INCREMENT,
    Nombre VARCHAR(100) NOT NULL,
    PRIMARY KEY (IdRol)
);

CREATE TABLE Permiso(
    IdPermiso INT AUTO_INCREMENT,
    PadrePermiso INT,
    Nombre VARCHAR(100) NOT NULL,
    PRIMARY KEY (IdPermiso),
    FOREIGN KEY (PadrePermiso) REFERENCES Permiso(PadrePermiso)
);

CREATE TABLE RolesPermiso (
    IdRolPermiso INT AUTO_INCREMENT,
    IdPermiso INT,
    IdRol INT,
    PRIMARY KEY (IdRolPermiso),
    UNIQUE (IdPermiso, IdRol),
    FOREIGN KEY (IdPermiso) REFERENCES Permiso(IdPermiso),
    FOREIGN KEY (IdRol) REFERENCES Roles(IdRol)
);

CREATE TABLE CarritoUsuario(
    IdUsuario INT NOT NULL,
    IdCelular INT NOT NULL,
    Cantidad MEDIUMINT,
    PRIMARY KEY(IdUsuario, IdCelular),
    FOREIGN KEY(IdUsuario)
        REFERENCES Usuario(IdUsuario),
    FOREIGN KEY(IdCelular) REFERENCES Celular(IdCelular)
);


CREATE TABLE TarjetasDeCredito(
  NumeroTarjeta VARCHAR(16),
  IdUsuario INT NOT NULL,
  FechaVencimiento VARCHAR(5) NOT NULL,
  NombreDueno VARCHAR(50) NOT NULL,
  CVV VARCHAR(4) NOT NULL,
  PRIMARY KEY(NumeroTarjeta),
  FOREIGN KEY(IdUsuario)
        REFERENCES Usuario(IdUsuario)
);

CREATE TABLE Celular(
    IdCelular INT AUTO_INCREMENT,
    Cantidad MEDIUMINT NOT NULL,
    Descripcion VARCHAR(100) NOT NULL,
    Caracteristicas VARCHAR(255) NOT NULL,
    Modelo VARCHAR(50) NOT NULL,
    Precio DECIMAL(10,2) NOT NULL,
    NumSerie VARCHAR(50) NOT NULL,
    PRIMARY KEY(IdCelular)
);




