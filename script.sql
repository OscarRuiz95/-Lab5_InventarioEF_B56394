-- Script para crear la base de datos y la tabla Productos
IF DB_ID(N'InventarioDb') IS NULL
BEGIN
    CREATE DATABASE InventarioDb;
END
GO

USE InventarioDb;
GO

IF OBJECT_ID(N'dbo.Productos', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Productos (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Nombre NVARCHAR(100) NOT NULL,
        Categoria NVARCHAR(200) NOT NULL,
        Precio FLOAT NOT NULL,
        Activo BIT NOT NULL,
        FechaIngreso DATETIME2 NOT NULL
    );
END
GO
