
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/29/2021 18:09:18
-- Generated from EDMX file: C:\Users\Nikola Lukic\Desktop\BazePodatakaProjekat\BazePodataka2\Baze\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [HospitalDBN];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ZaposleniBolnica_Zaposleni]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ZaposleniBolnica] DROP CONSTRAINT [FK_ZaposleniBolnica_Zaposleni];
GO
IF OBJECT_ID(N'[dbo].[FK_ZaposleniBolnica_Bolnica]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ZaposleniBolnica] DROP CONSTRAINT [FK_ZaposleniBolnica_Bolnica];
GO
IF OBJECT_ID(N'[dbo].[FK_GradBolnica]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Bolnicas] DROP CONSTRAINT [FK_GradBolnica];
GO
IF OBJECT_ID(N'[dbo].[FK_PacijentPregleda]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pregledas] DROP CONSTRAINT [FK_PacijentPregleda];
GO
IF OBJECT_ID(N'[dbo].[FK_SpecijalistaPregleda]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pregledas] DROP CONSTRAINT [FK_SpecijalistaPregleda];
GO
IF OBJECT_ID(N'[dbo].[FK_GradPacijent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pacijents] DROP CONSTRAINT [FK_GradPacijent];
GO
IF OBJECT_ID(N'[dbo].[FK_BolnicaPacijent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pacijents] DROP CONSTRAINT [FK_BolnicaPacijent];
GO
IF OBJECT_ID(N'[dbo].[FK_HospitalizovaniPacijent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Hospitalizovanis] DROP CONSTRAINT [FK_HospitalizovaniPacijent];
GO
IF OBJECT_ID(N'[dbo].[FK_HospitalizovaniSestra]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Hospitalizovanis] DROP CONSTRAINT [FK_HospitalizovaniSestra];
GO
IF OBJECT_ID(N'[dbo].[FK_DoktorPacijent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pacijents] DROP CONSTRAINT [FK_DoktorPacijent];
GO
IF OBJECT_ID(N'[dbo].[FK_DirektorBolnica]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Direktors] DROP CONSTRAINT [FK_DirektorBolnica];
GO
IF OBJECT_ID(N'[dbo].[FK_Specijalista_inherits_Zaposleni]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Zaposlenis_Specijalista] DROP CONSTRAINT [FK_Specijalista_inherits_Zaposleni];
GO
IF OBJECT_ID(N'[dbo].[FK_Sestra_inherits_Zaposleni]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Zaposlenis_Sestra] DROP CONSTRAINT [FK_Sestra_inherits_Zaposleni];
GO
IF OBJECT_ID(N'[dbo].[FK_Doktor_inherits_Zaposleni]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Zaposlenis_Doktor] DROP CONSTRAINT [FK_Doktor_inherits_Zaposleni];
GO
IF OBJECT_ID(N'[dbo].[FK_Spremacica_inherits_Zaposleni]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Zaposlenis_Spremacica] DROP CONSTRAINT [FK_Spremacica_inherits_Zaposleni];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Grads]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Grads];
GO
IF OBJECT_ID(N'[dbo].[Pacijents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pacijents];
GO
IF OBJECT_ID(N'[dbo].[Zaposlenis]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Zaposlenis];
GO
IF OBJECT_ID(N'[dbo].[Bolnicas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Bolnicas];
GO
IF OBJECT_ID(N'[dbo].[Direktors]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Direktors];
GO
IF OBJECT_ID(N'[dbo].[Hospitalizovanis]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Hospitalizovanis];
GO
IF OBJECT_ID(N'[dbo].[Pregledas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pregledas];
GO
IF OBJECT_ID(N'[dbo].[Zaposlenis_Specijalista]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Zaposlenis_Specijalista];
GO
IF OBJECT_ID(N'[dbo].[Zaposlenis_Sestra]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Zaposlenis_Sestra];
GO
IF OBJECT_ID(N'[dbo].[Zaposlenis_Doktor]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Zaposlenis_Doktor];
GO
IF OBJECT_ID(N'[dbo].[Zaposlenis_Spremacica]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Zaposlenis_Spremacica];
GO
IF OBJECT_ID(N'[dbo].[ZaposleniBolnica]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ZaposleniBolnica];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Grads'
CREATE TABLE [dbo].[Grads] (
    [PostanskiBr] decimal(18,0)  NOT NULL,
    [Naziv] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Pacijents'
CREATE TABLE [dbo].[Pacijents] (
    [JmbgPac] decimal(18,0)  NOT NULL,
    [ImePac] nvarchar(max)  NOT NULL,
    [PrezPac] nvarchar(max)  NOT NULL,
    [PregledaId] int  NOT NULL,
    [GradPostanskiBr] decimal(18,0)  NOT NULL,
    [BolnicaBolnicaId] decimal(18,0)  NOT NULL,
    [DoktorJmbgZap] decimal(18,0)  NOT NULL
);
GO

-- Creating table 'Zaposlenis'
CREATE TABLE [dbo].[Zaposlenis] (
    [JmbgZap] decimal(18,0)  NOT NULL,
    [ImeZap] nvarchar(max)  NOT NULL,
    [PrezZap] nvarchar(max)  NOT NULL,
    [PlataZap] nvarchar(max)  NOT NULL,
    [GodineZap] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Bolnicas'
CREATE TABLE [dbo].[Bolnicas] (
    [BolnicaId] decimal(18,0)  NOT NULL,
    [NazivBolnice] nvarchar(max)  NOT NULL,
    [GradPostanskiBr] decimal(18,0)  NOT NULL
);
GO

-- Creating table 'Direktors'
CREATE TABLE [dbo].[Direktors] (
    [JmbgDir] decimal(18,0)  NOT NULL,
    [ImeDir] nvarchar(max)  NOT NULL,
    [PrezDir] nvarchar(max)  NOT NULL,
    [BolnicaBolnicaId] decimal(18,0)  NOT NULL
);
GO

-- Creating table 'Hospitalizovanis'
CREATE TABLE [dbo].[Hospitalizovanis] (
    [Id] decimal(18,0)  NOT NULL,
    [Dijagnoza] nvarchar(max)  NOT NULL,
    [PacijentJmbgPac] decimal(18,0)  NOT NULL,
    [SestraJmbgZap] decimal(18,0)  NOT NULL
);
GO

-- Creating table 'Pregledas'
CREATE TABLE [dbo].[Pregledas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PacijentJmbgPac] decimal(18,0)  NOT NULL,
    [SpecijalistaJmbgZap] decimal(18,0)  NOT NULL,
    [Anamneza] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Zaposlenis_Specijalista'
CREATE TABLE [dbo].[Zaposlenis_Specijalista] (
    [Oblast_Spec] nvarchar(max)  NOT NULL,
    [PregledaId] int  NOT NULL,
    [JmbgZap] decimal(18,0)  NOT NULL
);
GO

-- Creating table 'Zaposlenis_Doktor'
CREATE TABLE [dbo].[Zaposlenis_Doktor] (
    [JmbgZap] decimal(18,0)  NOT NULL
);
GO

-- Creating table 'Zaposlenis_Sestra'
CREATE TABLE [dbo].[Zaposlenis_Sestra] (
    [brojDezurstava] nvarchar(max)  NOT NULL,
    [HospitalizovaniId] int  NOT NULL,
    [JmbgZap] decimal(18,0)  NOT NULL
);
GO

-- Creating table 'Zaposlenis_Spremacica'
CREATE TABLE [dbo].[Zaposlenis_Spremacica] (
    [brojCiscenja] nvarchar(max)  NOT NULL,
    [JmbgZap] decimal(18,0)  NOT NULL
);
GO

-- Creating table 'ZaposleniBolnica'
CREATE TABLE [dbo].[ZaposleniBolnica] (
    [Zaposlenis_JmbgZap] decimal(18,0)  NOT NULL,
    [Bolnicas_BolnicaId] decimal(18,0)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [PostanskiBr] in table 'Grads'
ALTER TABLE [dbo].[Grads]
ADD CONSTRAINT [PK_Grads]
    PRIMARY KEY CLUSTERED ([PostanskiBr] ASC);
GO

-- Creating primary key on [JmbgPac] in table 'Pacijents'
ALTER TABLE [dbo].[Pacijents]
ADD CONSTRAINT [PK_Pacijents]
    PRIMARY KEY CLUSTERED ([JmbgPac] ASC);
GO

-- Creating primary key on [JmbgZap] in table 'Zaposlenis'
ALTER TABLE [dbo].[Zaposlenis]
ADD CONSTRAINT [PK_Zaposlenis]
    PRIMARY KEY CLUSTERED ([JmbgZap] ASC);
GO

-- Creating primary key on [BolnicaId] in table 'Bolnicas'
ALTER TABLE [dbo].[Bolnicas]
ADD CONSTRAINT [PK_Bolnicas]
    PRIMARY KEY CLUSTERED ([BolnicaId] ASC);
GO

-- Creating primary key on [JmbgDir] in table 'Direktors'
ALTER TABLE [dbo].[Direktors]
ADD CONSTRAINT [PK_Direktors]
    PRIMARY KEY CLUSTERED ([JmbgDir] ASC);
GO

-- Creating primary key on [Id] in table 'Hospitalizovanis'
ALTER TABLE [dbo].[Hospitalizovanis]
ADD CONSTRAINT [PK_Hospitalizovanis]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Pregledas'
ALTER TABLE [dbo].[Pregledas]
ADD CONSTRAINT [PK_Pregledas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [JmbgZap] in table 'Zaposlenis_Specijalista'
ALTER TABLE [dbo].[Zaposlenis_Specijalista]
ADD CONSTRAINT [PK_Zaposlenis_Specijalista]
    PRIMARY KEY CLUSTERED ([JmbgZap] ASC);
GO

-- Creating primary key on [JmbgZap] in table 'Zaposlenis_Doktor'
ALTER TABLE [dbo].[Zaposlenis_Doktor]
ADD CONSTRAINT [PK_Zaposlenis_Doktor]
    PRIMARY KEY CLUSTERED ([JmbgZap] ASC);
GO

-- Creating primary key on [JmbgZap] in table 'Zaposlenis_Sestra'
ALTER TABLE [dbo].[Zaposlenis_Sestra]
ADD CONSTRAINT [PK_Zaposlenis_Sestra]
    PRIMARY KEY CLUSTERED ([JmbgZap] ASC);
GO

-- Creating primary key on [JmbgZap] in table 'Zaposlenis_Spremacica'
ALTER TABLE [dbo].[Zaposlenis_Spremacica]
ADD CONSTRAINT [PK_Zaposlenis_Spremacica]
    PRIMARY KEY CLUSTERED ([JmbgZap] ASC);
GO

-- Creating primary key on [Zaposlenis_JmbgZap], [Bolnicas_BolnicaId] in table 'ZaposleniBolnica'
ALTER TABLE [dbo].[ZaposleniBolnica]
ADD CONSTRAINT [PK_ZaposleniBolnica]
    PRIMARY KEY CLUSTERED ([Zaposlenis_JmbgZap], [Bolnicas_BolnicaId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Zaposlenis_JmbgZap] in table 'ZaposleniBolnica'
ALTER TABLE [dbo].[ZaposleniBolnica]
ADD CONSTRAINT [FK_ZaposleniBolnica_Zaposleni]
    FOREIGN KEY ([Zaposlenis_JmbgZap])
    REFERENCES [dbo].[Zaposlenis]
        ([JmbgZap])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Bolnicas_BolnicaId] in table 'ZaposleniBolnica'
ALTER TABLE [dbo].[ZaposleniBolnica]
ADD CONSTRAINT [FK_ZaposleniBolnica_Bolnica]
    FOREIGN KEY ([Bolnicas_BolnicaId])
    REFERENCES [dbo].[Bolnicas]
        ([BolnicaId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ZaposleniBolnica_Bolnica'
CREATE INDEX [IX_FK_ZaposleniBolnica_Bolnica]
ON [dbo].[ZaposleniBolnica]
    ([Bolnicas_BolnicaId]);
GO

-- Creating foreign key on [GradPostanskiBr] in table 'Bolnicas'
ALTER TABLE [dbo].[Bolnicas]
ADD CONSTRAINT [FK_GradBolnica]
    FOREIGN KEY ([GradPostanskiBr])
    REFERENCES [dbo].[Grads]
        ([PostanskiBr])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GradBolnica'
CREATE INDEX [IX_FK_GradBolnica]
ON [dbo].[Bolnicas]
    ([GradPostanskiBr]);
GO

-- Creating foreign key on [PacijentJmbgPac] in table 'Pregledas'
ALTER TABLE [dbo].[Pregledas]
ADD CONSTRAINT [FK_PacijentPregleda]
    FOREIGN KEY ([PacijentJmbgPac])
    REFERENCES [dbo].[Pacijents]
        ([JmbgPac])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PacijentPregleda'
CREATE INDEX [IX_FK_PacijentPregleda]
ON [dbo].[Pregledas]
    ([PacijentJmbgPac]);
GO

-- Creating foreign key on [SpecijalistaJmbgZap] in table 'Pregledas'
ALTER TABLE [dbo].[Pregledas]
ADD CONSTRAINT [FK_SpecijalistaPregleda]
    FOREIGN KEY ([SpecijalistaJmbgZap])
    REFERENCES [dbo].[Zaposlenis_Specijalista]
        ([JmbgZap])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SpecijalistaPregleda'
CREATE INDEX [IX_FK_SpecijalistaPregleda]
ON [dbo].[Pregledas]
    ([SpecijalistaJmbgZap]);
GO

-- Creating foreign key on [GradPostanskiBr] in table 'Pacijents'
ALTER TABLE [dbo].[Pacijents]
ADD CONSTRAINT [FK_GradPacijent]
    FOREIGN KEY ([GradPostanskiBr])
    REFERENCES [dbo].[Grads]
        ([PostanskiBr])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GradPacijent'
CREATE INDEX [IX_FK_GradPacijent]
ON [dbo].[Pacijents]
    ([GradPostanskiBr]);
GO

-- Creating foreign key on [BolnicaBolnicaId] in table 'Pacijents'
ALTER TABLE [dbo].[Pacijents]
ADD CONSTRAINT [FK_BolnicaPacijent]
    FOREIGN KEY ([BolnicaBolnicaId])
    REFERENCES [dbo].[Bolnicas]
        ([BolnicaId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BolnicaPacijent'
CREATE INDEX [IX_FK_BolnicaPacijent]
ON [dbo].[Pacijents]
    ([BolnicaBolnicaId]);
GO

-- Creating foreign key on [DoktorJmbgZap] in table 'Pacijents'
ALTER TABLE [dbo].[Pacijents]
ADD CONSTRAINT [FK_DoktorPacijent]
    FOREIGN KEY ([DoktorJmbgZap])
    REFERENCES [dbo].[Zaposlenis_Doktor]
        ([JmbgZap])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DoktorPacijent'
CREATE INDEX [IX_FK_DoktorPacijent]
ON [dbo].[Pacijents]
    ([DoktorJmbgZap]);
GO

-- Creating foreign key on [BolnicaBolnicaId] in table 'Direktors'
ALTER TABLE [dbo].[Direktors]
ADD CONSTRAINT [FK_DirektorBolnica]
    FOREIGN KEY ([BolnicaBolnicaId])
    REFERENCES [dbo].[Bolnicas]
        ([BolnicaId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DirektorBolnica'
CREATE INDEX [IX_FK_DirektorBolnica]
ON [dbo].[Direktors]
    ([BolnicaBolnicaId]);
GO

-- Creating foreign key on [PacijentJmbgPac] in table 'Hospitalizovanis'
ALTER TABLE [dbo].[Hospitalizovanis]
ADD CONSTRAINT [FK_HospitalizovaniPacijent]
    FOREIGN KEY ([PacijentJmbgPac])
    REFERENCES [dbo].[Pacijents]
        ([JmbgPac])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HospitalizovaniPacijent'
CREATE INDEX [IX_FK_HospitalizovaniPacijent]
ON [dbo].[Hospitalizovanis]
    ([PacijentJmbgPac]);
GO

-- Creating foreign key on [SestraJmbgZap] in table 'Hospitalizovanis'
ALTER TABLE [dbo].[Hospitalizovanis]
ADD CONSTRAINT [FK_HospitalizovaniSestra]
    FOREIGN KEY ([SestraJmbgZap])
    REFERENCES [dbo].[Zaposlenis_Sestra]
        ([JmbgZap])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HospitalizovaniSestra'
CREATE INDEX [IX_FK_HospitalizovaniSestra]
ON [dbo].[Hospitalizovanis]
    ([SestraJmbgZap]);
GO

-- Creating foreign key on [JmbgZap] in table 'Zaposlenis_Specijalista'
ALTER TABLE [dbo].[Zaposlenis_Specijalista]
ADD CONSTRAINT [FK_Specijalista_inherits_Zaposleni]
    FOREIGN KEY ([JmbgZap])
    REFERENCES [dbo].[Zaposlenis]
        ([JmbgZap])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [JmbgZap] in table 'Zaposlenis_Doktor'
ALTER TABLE [dbo].[Zaposlenis_Doktor]
ADD CONSTRAINT [FK_Doktor_inherits_Zaposleni]
    FOREIGN KEY ([JmbgZap])
    REFERENCES [dbo].[Zaposlenis]
        ([JmbgZap])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [JmbgZap] in table 'Zaposlenis_Sestra'
ALTER TABLE [dbo].[Zaposlenis_Sestra]
ADD CONSTRAINT [FK_Sestra_inherits_Zaposleni]
    FOREIGN KEY ([JmbgZap])
    REFERENCES [dbo].[Zaposlenis]
        ([JmbgZap])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [JmbgZap] in table 'Zaposlenis_Spremacica'
ALTER TABLE [dbo].[Zaposlenis_Spremacica]
ADD CONSTRAINT [FK_Spremacica_inherits_Zaposleni]
    FOREIGN KEY ([JmbgZap])
    REFERENCES [dbo].[Zaposlenis]
        ([JmbgZap])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------