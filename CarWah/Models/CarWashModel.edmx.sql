
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/17/2020 18:55:56
-- Generated from EDMX file: C:\Users\well-\source\repos\CarWash\CarWah\Models\CarWashModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [master];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Cliente_Vehiculo_Cliente]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cliente_Vehiculo] DROP CONSTRAINT [FK_Cliente_Vehiculo_Cliente];
GO
IF OBJECT_ID(N'[dbo].[FK_Cliente_Vehiculo_Vehiculo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cliente_Vehiculo] DROP CONSTRAINT [FK_Cliente_Vehiculo_Vehiculo];
GO
IF OBJECT_ID(N'[dbo].[FK_Empleado_Roles_Empleado]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Empleado_Roles] DROP CONSTRAINT [FK_Empleado_Roles_Empleado];
GO
IF OBJECT_ID(N'[dbo].[FK_Empleado_Roles_Role]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Empleado_Roles] DROP CONSTRAINT [FK_Empleado_Roles_Role];
GO
IF OBJECT_ID(N'[dbo].[FK_Factura_Cliente]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Factura] DROP CONSTRAINT [FK_Factura_Cliente];
GO
IF OBJECT_ID(N'[dbo].[FK_Factura_Empleado]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Factura] DROP CONSTRAINT [FK_Factura_Empleado];
GO
IF OBJECT_ID(N'[dbo].[FK_FacturaDetails_Factura]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FacturaDetails] DROP CONSTRAINT [FK_FacturaDetails_Factura];
GO
IF OBJECT_ID(N'[dbo].[FK_FacturaDetails_TipoLavado]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FacturaDetails] DROP CONSTRAINT [FK_FacturaDetails_TipoLavado];
GO
IF OBJECT_ID(N'[dbo].[FK_FacturaDetails_Vehiculo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FacturaDetails] DROP CONSTRAINT [FK_FacturaDetails_Vehiculo];
GO
IF OBJECT_ID(N'[dbo].[FK_Vehiculo_Marca]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Vehiculo] DROP CONSTRAINT [FK_Vehiculo_Marca];
GO
IF OBJECT_ID(N'[dbo].[FK_Vehiculo_Modelo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Vehiculo] DROP CONSTRAINT [FK_Vehiculo_Modelo];
GO
IF OBJECT_ID(N'[dbo].[FK_Vehiculo_TipoVehiculo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Vehiculo] DROP CONSTRAINT [FK_Vehiculo_TipoVehiculo];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Cliente]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cliente];
GO
IF OBJECT_ID(N'[dbo].[Cliente_Vehiculo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cliente_Vehiculo];
GO
IF OBJECT_ID(N'[dbo].[Empleado]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Empleado];
GO
IF OBJECT_ID(N'[dbo].[Empleado_Roles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Empleado_Roles];
GO
IF OBJECT_ID(N'[dbo].[Factura]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Factura];
GO
IF OBJECT_ID(N'[dbo].[FacturaDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FacturaDetails];
GO
IF OBJECT_ID(N'[dbo].[Marca]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Marca];
GO
IF OBJECT_ID(N'[dbo].[Modelo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Modelo];
GO
IF OBJECT_ID(N'[dbo].[Role]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Role];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[TipoLavado]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TipoLavado];
GO
IF OBJECT_ID(N'[dbo].[TipoVehiculo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TipoVehiculo];
GO
IF OBJECT_ID(N'[dbo].[Vehiculo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Vehiculo];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Cliente'
CREATE TABLE [dbo].[Cliente] (
    [Codigo] int IDENTITY(1,1) NOT NULL,
    [Nombre] varchar(30)  NULL,
    [Apellidos] varchar(30)  NULL,
    [Cedula] varchar(11)  NOT NULL,
    [Direccion] varchar(200)  NULL,
    [Contacto] varchar(10)  NULL
);
GO

-- Creating table 'Cliente_Vehiculo'
CREATE TABLE [dbo].[Cliente_Vehiculo] (
    [Codigo] int IDENTITY(1,1) NOT NULL,
    [ClienteId] int  NOT NULL,
    [VehiculoId] int  NOT NULL
);
GO

-- Creating table 'Empleado'
CREATE TABLE [dbo].[Empleado] (
    [Codigo] int IDENTITY(1,1) NOT NULL,
    [Nombre] varchar(30)  NULL,
    [Apellidos] varchar(30)  NULL,
    [Cedula] varchar(11)  NOT NULL,
    [Direccion] varchar(200)  NULL,
    [Contacto] varchar(10)  NULL,
    [Usuario] nchar(100)  NULL,
    [Contraseña] varchar(1000)  NOT NULL
);
GO

-- Creating table 'Empleado_Roles'
CREATE TABLE [dbo].[Empleado_Roles] (
    [Codigo] int IDENTITY(1,1) NOT NULL,
    [EmpleadoId] int  NOT NULL,
    [RoleId] int  NOT NULL
);
GO

-- Creating table 'Factura'
CREATE TABLE [dbo].[Factura] (
    [Codigo] int IDENTITY(1,1) NOT NULL,
    [ClienteId] int  NULL,
    [EmpleadoId] int  NULL
);
GO

-- Creating table 'FacturaDetails'
CREATE TABLE [dbo].[FacturaDetails] (
    [Codigo] int IDENTITY(1,1) NOT NULL,
    [VehiculoId] int  NULL,
    [Descuento] decimal(18,2)  NULL,
    [Lavado] int  NOT NULL,
    [Precio] decimal(18,2)  NULL,
    [Cantidad] int  NULL,
    [ITBIS] decimal(18,2)  NULL,
    [Total] decimal(18,2)  NULL
);
GO

-- Creating table 'Marca'
CREATE TABLE [dbo].[Marca] (
    [Codigo] int IDENTITY(1,1) NOT NULL,
    [Descripcion] varchar(20)  NULL
);
GO

-- Creating table 'Modelo'
CREATE TABLE [dbo].[Modelo] (
    [Codigo] int IDENTITY(1,1) NOT NULL,
    [Descripcion] varchar(20)  NULL
);
GO

-- Creating table 'Role'
CREATE TABLE [dbo].[Role] (
    [Codigo] int IDENTITY(1,1) NOT NULL,
    [Descripcion] varchar(25)  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'TipoLavado'
CREATE TABLE [dbo].[TipoLavado] (
    [Codigo] int IDENTITY(1,1) NOT NULL,
    [Descripcion_Lavado] varchar(15)  NULL,
    [Precio] decimal(18,2)  NULL
);
GO

-- Creating table 'TipoVehiculo'
CREATE TABLE [dbo].[TipoVehiculo] (
    [Codigo] int IDENTITY(1,1) NOT NULL,
    [Descripcion] varchar(20)  NULL
);
GO

-- Creating table 'Vehiculo'
CREATE TABLE [dbo].[Vehiculo] (
    [Codigo] int IDENTITY(1,1) NOT NULL,
    [ModeloId] int  NOT NULL,
    [MarcaId] int  NOT NULL,
    [Placa] varchar(7)  NULL,
    [Tipo_de_Vehiculo] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Codigo] in table 'Cliente'
ALTER TABLE [dbo].[Cliente]
ADD CONSTRAINT [PK_Cliente]
    PRIMARY KEY CLUSTERED ([Codigo] ASC);
GO

-- Creating primary key on [Codigo] in table 'Cliente_Vehiculo'
ALTER TABLE [dbo].[Cliente_Vehiculo]
ADD CONSTRAINT [PK_Cliente_Vehiculo]
    PRIMARY KEY CLUSTERED ([Codigo] ASC);
GO

-- Creating primary key on [Codigo] in table 'Empleado'
ALTER TABLE [dbo].[Empleado]
ADD CONSTRAINT [PK_Empleado]
    PRIMARY KEY CLUSTERED ([Codigo] ASC);
GO

-- Creating primary key on [Codigo] in table 'Empleado_Roles'
ALTER TABLE [dbo].[Empleado_Roles]
ADD CONSTRAINT [PK_Empleado_Roles]
    PRIMARY KEY CLUSTERED ([Codigo] ASC);
GO

-- Creating primary key on [Codigo] in table 'Factura'
ALTER TABLE [dbo].[Factura]
ADD CONSTRAINT [PK_Factura]
    PRIMARY KEY CLUSTERED ([Codigo] ASC);
GO

-- Creating primary key on [Codigo] in table 'FacturaDetails'
ALTER TABLE [dbo].[FacturaDetails]
ADD CONSTRAINT [PK_FacturaDetails]
    PRIMARY KEY CLUSTERED ([Codigo] ASC);
GO

-- Creating primary key on [Codigo] in table 'Marca'
ALTER TABLE [dbo].[Marca]
ADD CONSTRAINT [PK_Marca]
    PRIMARY KEY CLUSTERED ([Codigo] ASC);
GO

-- Creating primary key on [Codigo] in table 'Modelo'
ALTER TABLE [dbo].[Modelo]
ADD CONSTRAINT [PK_Modelo]
    PRIMARY KEY CLUSTERED ([Codigo] ASC);
GO

-- Creating primary key on [Codigo] in table 'Role'
ALTER TABLE [dbo].[Role]
ADD CONSTRAINT [PK_Role]
    PRIMARY KEY CLUSTERED ([Codigo] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [Codigo] in table 'TipoLavado'
ALTER TABLE [dbo].[TipoLavado]
ADD CONSTRAINT [PK_TipoLavado]
    PRIMARY KEY CLUSTERED ([Codigo] ASC);
GO

-- Creating primary key on [Codigo] in table 'TipoVehiculo'
ALTER TABLE [dbo].[TipoVehiculo]
ADD CONSTRAINT [PK_TipoVehiculo]
    PRIMARY KEY CLUSTERED ([Codigo] ASC);
GO

-- Creating primary key on [Codigo] in table 'Vehiculo'
ALTER TABLE [dbo].[Vehiculo]
ADD CONSTRAINT [PK_Vehiculo]
    PRIMARY KEY CLUSTERED ([Codigo] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ClienteId] in table 'Cliente_Vehiculo'
ALTER TABLE [dbo].[Cliente_Vehiculo]
ADD CONSTRAINT [FK_Cliente_Vehiculo_Cliente]
    FOREIGN KEY ([ClienteId])
    REFERENCES [dbo].[Cliente]
        ([Codigo])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Cliente_Vehiculo_Cliente'
CREATE INDEX [IX_FK_Cliente_Vehiculo_Cliente]
ON [dbo].[Cliente_Vehiculo]
    ([ClienteId]);
GO

-- Creating foreign key on [ClienteId] in table 'Factura'
ALTER TABLE [dbo].[Factura]
ADD CONSTRAINT [FK_Factura_Cliente]
    FOREIGN KEY ([ClienteId])
    REFERENCES [dbo].[Cliente]
        ([Codigo])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Factura_Cliente'
CREATE INDEX [IX_FK_Factura_Cliente]
ON [dbo].[Factura]
    ([ClienteId]);
GO

-- Creating foreign key on [VehiculoId] in table 'Cliente_Vehiculo'
ALTER TABLE [dbo].[Cliente_Vehiculo]
ADD CONSTRAINT [FK_Cliente_Vehiculo_Vehiculo]
    FOREIGN KEY ([VehiculoId])
    REFERENCES [dbo].[Vehiculo]
        ([Codigo])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Cliente_Vehiculo_Vehiculo'
CREATE INDEX [IX_FK_Cliente_Vehiculo_Vehiculo]
ON [dbo].[Cliente_Vehiculo]
    ([VehiculoId]);
GO

-- Creating foreign key on [EmpleadoId] in table 'Empleado_Roles'
ALTER TABLE [dbo].[Empleado_Roles]
ADD CONSTRAINT [FK_Empleado_Roles_Empleado]
    FOREIGN KEY ([EmpleadoId])
    REFERENCES [dbo].[Empleado]
        ([Codigo])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Empleado_Roles_Empleado'
CREATE INDEX [IX_FK_Empleado_Roles_Empleado]
ON [dbo].[Empleado_Roles]
    ([EmpleadoId]);
GO

-- Creating foreign key on [EmpleadoId] in table 'Factura'
ALTER TABLE [dbo].[Factura]
ADD CONSTRAINT [FK_Factura_Empleado]
    FOREIGN KEY ([EmpleadoId])
    REFERENCES [dbo].[Empleado]
        ([Codigo])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Factura_Empleado'
CREATE INDEX [IX_FK_Factura_Empleado]
ON [dbo].[Factura]
    ([EmpleadoId]);
GO

-- Creating foreign key on [RoleId] in table 'Empleado_Roles'
ALTER TABLE [dbo].[Empleado_Roles]
ADD CONSTRAINT [FK_Empleado_Roles_Role]
    FOREIGN KEY ([RoleId])
    REFERENCES [dbo].[Role]
        ([Codigo])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Empleado_Roles_Role'
CREATE INDEX [IX_FK_Empleado_Roles_Role]
ON [dbo].[Empleado_Roles]
    ([RoleId]);
GO

-- Creating foreign key on [Codigo] in table 'FacturaDetails'
ALTER TABLE [dbo].[FacturaDetails]
ADD CONSTRAINT [FK_FacturaDetails_Factura]
    FOREIGN KEY ([Codigo])
    REFERENCES [dbo].[Factura]
        ([Codigo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Lavado] in table 'FacturaDetails'
ALTER TABLE [dbo].[FacturaDetails]
ADD CONSTRAINT [FK_FacturaDetails_TipoLavado]
    FOREIGN KEY ([Lavado])
    REFERENCES [dbo].[TipoLavado]
        ([Codigo])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FacturaDetails_TipoLavado'
CREATE INDEX [IX_FK_FacturaDetails_TipoLavado]
ON [dbo].[FacturaDetails]
    ([Lavado]);
GO

-- Creating foreign key on [VehiculoId] in table 'FacturaDetails'
ALTER TABLE [dbo].[FacturaDetails]
ADD CONSTRAINT [FK_FacturaDetails_Vehiculo]
    FOREIGN KEY ([VehiculoId])
    REFERENCES [dbo].[Vehiculo]
        ([Codigo])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FacturaDetails_Vehiculo'
CREATE INDEX [IX_FK_FacturaDetails_Vehiculo]
ON [dbo].[FacturaDetails]
    ([VehiculoId]);
GO

-- Creating foreign key on [MarcaId] in table 'Vehiculo'
ALTER TABLE [dbo].[Vehiculo]
ADD CONSTRAINT [FK_Vehiculo_Marca]
    FOREIGN KEY ([MarcaId])
    REFERENCES [dbo].[Marca]
        ([Codigo])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Vehiculo_Marca'
CREATE INDEX [IX_FK_Vehiculo_Marca]
ON [dbo].[Vehiculo]
    ([MarcaId]);
GO

-- Creating foreign key on [ModeloId] in table 'Vehiculo'
ALTER TABLE [dbo].[Vehiculo]
ADD CONSTRAINT [FK_Vehiculo_Modelo]
    FOREIGN KEY ([ModeloId])
    REFERENCES [dbo].[Modelo]
        ([Codigo])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Vehiculo_Modelo'
CREATE INDEX [IX_FK_Vehiculo_Modelo]
ON [dbo].[Vehiculo]
    ([ModeloId]);
GO

-- Creating foreign key on [Tipo_de_Vehiculo] in table 'Vehiculo'
ALTER TABLE [dbo].[Vehiculo]
ADD CONSTRAINT [FK_Vehiculo_TipoVehiculo]
    FOREIGN KEY ([Tipo_de_Vehiculo])
    REFERENCES [dbo].[TipoVehiculo]
        ([Codigo])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Vehiculo_TipoVehiculo'
CREATE INDEX [IX_FK_Vehiculo_TipoVehiculo]
ON [dbo].[Vehiculo]
    ([Tipo_de_Vehiculo]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------