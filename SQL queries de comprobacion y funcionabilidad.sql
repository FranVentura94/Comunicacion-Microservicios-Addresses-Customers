SELECT TOP (1000) [Id]
      ,[Name]
      ,[InternalId]
      ,[CreatedDate]
      ,[UpdatedDate]
      ,[IsActive]
  FROM [MARKETING_ACTIVITIES].[dbo].[Addresses_Country]


USE MARKETING_ACTIVITIES;

SELECT c.Id AS CustomerId, c.Code, c.Name, c.LocationId,
       p.Id AS PositionId, p.Address, p.CustomerId AS Position_CustomerId,
       ci.Name AS City
FROM Business_Customer c
JOIN Addresses_Position p ON p.Id = c.LocationId
JOIN Addresses_City ci    ON ci.Id = p.CityId;


USE MARKETING_ACTIVITIES;
SELECT * FROM Addresses_Country;
SELECT * FROM Addresses_State;
SELECT * FROM Addresses_City;
SELECT * FROM Business_CustomerType;
SELECT * FROM Business_Company;


USE MARKETING_ACTIVITIES;
SET NOCOUNT ON;
DECLARE @now DATETIME2 = SYSUTCDATETIME();

-- ===== ADDRESSES =====
INSERT INTO Addresses_Country (Name, InternalId, CreatedDate, UpdatedDate, IsActive) VALUES
('El Salvador', NEWID(), @now, @now, 1),
('Guatemala',   NEWID(), @now, @now, 1),
('Honduras',    NEWID(), @now, @now, 1);

INSERT INTO Addresses_State (Name, CountryId, InternalId, CreatedDate, UpdatedDate, IsActive) VALUES
('San Salvador',      1, NEWID(), @now, @now, 1),
('La Libertad',       1, NEWID(), @now, @now, 1),
('Guatemala',         2, NEWID(), @now, @now, 1),
('Francisco Morazan', 3, NEWID(), @now, @now, 1);

INSERT INTO Addresses_City (Name, CountryId, StateId, InternalId, CreatedDate, UpdatedDate, IsActive) VALUES
('San Salvador',        1, 1, NEWID(), @now, @now, 1),
('Soyapango',           1, 1, NEWID(), @now, @now, 1),
('Santa Tecla',         1, 2, NEWID(), @now, @now, 1),
('Ciudad de Guatemala', 2, 3, NEWID(), @now, @now, 1),
('Mixco',               2, 3, NEWID(), @now, @now, 1),
('Tegucigalpa',         3, 4, NEWID(), @now, @now, 1);

-- ===== CUSTOMERS (tablas de apoyo) =====
INSERT INTO Business_CustomerType (Name, InternalId, CreatedDate, UpdatedDate, IsActive) VALUES
('Persona Natural',  NEWID(), @now, @now, 1),
('Persona Juridica', NEWID(), @now, @now, 1),
('Gobierno',         NEWID(), @now, @now, 1);

INSERT INTO Business_Company (Name, Sigla, MainEmail, InternalId, CreatedDate, UpdatedDate, IsActive) VALUES
('Distribuidora Centroamericana', 'DICA', 'contacto@dica.com',  NEWID(), @now, @now, 1),
('Servicios Tecnologicos SV',     'STSV', 'info@stsv.com',      NEWID(), @now, @now, 1),
('Comercial del Norte',           'CDN',  'ventas@cdnorte.com', NEWID(), @now, @now, 1);


