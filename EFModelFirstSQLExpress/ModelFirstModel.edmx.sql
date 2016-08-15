
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/14/2016 16:42:07
-- Generated from EDMX file: D:\Project\GitHub\WPFTutorial2015\EFModelFirstSQLExpress\ModelFirstModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ModelFirstDb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_StudentCourse_Student]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StudentCourse] DROP CONSTRAINT [FK_StudentCourse_Student];
GO
IF OBJECT_ID(N'[dbo].[FK_StudentCourse_Course]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StudentCourse] DROP CONSTRAINT [FK_StudentCourse_Course];
GO
IF OBJECT_ID(N'[dbo].[FK_TeacherCourse_Teacher]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TeacherCourse] DROP CONSTRAINT [FK_TeacherCourse_Teacher];
GO
IF OBJECT_ID(N'[dbo].[FK_TeacherCourse_Course]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TeacherCourse] DROP CONSTRAINT [FK_TeacherCourse_Course];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Students]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Students];
GO
IF OBJECT_ID(N'[dbo].[Courses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Courses];
GO
IF OBJECT_ID(N'[dbo].[Teachers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Teachers];
GO
IF OBJECT_ID(N'[dbo].[StudentCourse]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StudentCourse];
GO
IF OBJECT_ID(N'[dbo].[TeacherCourse]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TeacherCourse];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Student'
CREATE TABLE [dbo].[Student] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Course'
CREATE TABLE [dbo].[Course] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Teacher'
CREATE TABLE [dbo].[Teacher] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'StudentCourse'
CREATE TABLE [dbo].[StudentCourse] (
    [Students_Id] int  NOT NULL,
    [Courses_Id] int  NOT NULL
);
GO

-- Creating table 'TeacherCourse'
CREATE TABLE [dbo].[TeacherCourse] (
    [Teachers_Id] int  NOT NULL,
    [Courses_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Student'
ALTER TABLE [dbo].[Student]
ADD CONSTRAINT [PK_Student]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Course'
ALTER TABLE [dbo].[Course]
ADD CONSTRAINT [PK_Course]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Teacher'
ALTER TABLE [dbo].[Teacher]
ADD CONSTRAINT [PK_Teacher]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Students_Id], [Courses_Id] in table 'StudentCourse'
ALTER TABLE [dbo].[StudentCourse]
ADD CONSTRAINT [PK_StudentCourse]
    PRIMARY KEY CLUSTERED ([Students_Id], [Courses_Id] ASC);
GO

-- Creating primary key on [Teachers_Id], [Courses_Id] in table 'TeacherCourse'
ALTER TABLE [dbo].[TeacherCourse]
ADD CONSTRAINT [PK_TeacherCourse]
    PRIMARY KEY CLUSTERED ([Teachers_Id], [Courses_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Students_Id] in table 'StudentCourse'
ALTER TABLE [dbo].[StudentCourse]
ADD CONSTRAINT [FK_StudentCourse_Student]
    FOREIGN KEY ([Students_Id])
    REFERENCES [dbo].[Student]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Courses_Id] in table 'StudentCourse'
ALTER TABLE [dbo].[StudentCourse]
ADD CONSTRAINT [FK_StudentCourse_Course]
    FOREIGN KEY ([Courses_Id])
    REFERENCES [dbo].[Course]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StudentCourse_Course'
CREATE INDEX [IX_FK_StudentCourse_Course]
ON [dbo].[StudentCourse]
    ([Courses_Id]);
GO

-- Creating foreign key on [Teachers_Id] in table 'TeacherCourse'
ALTER TABLE [dbo].[TeacherCourse]
ADD CONSTRAINT [FK_TeacherCourse_Teacher]
    FOREIGN KEY ([Teachers_Id])
    REFERENCES [dbo].[Teacher]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Courses_Id] in table 'TeacherCourse'
ALTER TABLE [dbo].[TeacherCourse]
ADD CONSTRAINT [FK_TeacherCourse_Course]
    FOREIGN KEY ([Courses_Id])
    REFERENCES [dbo].[Course]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TeacherCourse_Course'
CREATE INDEX [IX_FK_TeacherCourse_Course]
ON [dbo].[TeacherCourse]
    ([Courses_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------