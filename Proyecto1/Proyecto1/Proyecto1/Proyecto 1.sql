USE MASTER;
GO

CREATE DATABASE CalculadoraDB;
GO

USE CalculadoraDB;
GO

CREATE TABLE Calculos 
(
Id INT IDENTITY(1,1) PRIMARY KEY,
Operacion NVARCHAR(50),
Resultado DECIMAL(18,2),

);

ALTER TABLE Calculos ADD Fecha DATETIME DEFAULT(GETDATE());

select * from Calculos
