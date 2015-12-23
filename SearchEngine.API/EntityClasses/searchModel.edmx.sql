
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 12/19/2015 10:30:49
-- Generated from EDMX file: E:\WorkingProjects\AngularJs\SearchEngine.API\EntityClasses\searchModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [myDb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[MostSearches]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MostSearches];
GO
IF OBJECT_ID(N'[dbo].[Searches]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Searches];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Searches'
CREATE TABLE [dbo].[Searches] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Sentence] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'MostSearches'
CREATE TABLE [dbo].[MostSearches] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Words] nvarchar(max)  NOT NULL,
    [OnDate] datetime  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Searches'
ALTER TABLE [dbo].[Searches]
ADD CONSTRAINT [PK_Searches]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MostSearches'
ALTER TABLE [dbo].[MostSearches]
ADD CONSTRAINT [PK_MostSearches]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------