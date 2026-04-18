-- BD - Caso de Estudio II

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'CasoEstudioKN')
BEGIN
    CREATE DATABASE CasoEstudioKN;
END
GO


USE CasoEstudioKN;
GO


CREATE TABLE CasasSistema (
    IdCasa BIGINT IDENTITY(1,1) NOT NULL,
    DescripcionCasa VARCHAR(30) NOT NULL,
    PrecioCasa DECIMAL(10,2) NOT NULL,
    UsuarioAlquiler VARCHAR(30) NULL,
    FechaAlquiler DATETIME NULL,
    CONSTRAINT PK_CasasSistema PRIMARY KEY (IdCasa)
);