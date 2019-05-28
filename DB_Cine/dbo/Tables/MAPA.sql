﻿CREATE TABLE [dbo].[MAPA] (
    [ID]        NUMERIC (10)   IDENTITY (1, 1) NOT NULL,
    [NOMBRE]    NVARCHAR (200) NOT NULL,
    [TIPO_MAP]  CHAR (1)       NOT NULL,
    [SALA]      NUMERIC (10)   NOT NULL,
    [FUNCION]   NUMERIC (10)   NOT NULL,
    [PUBLICADO] CHAR (1)       CONSTRAINT [DF__MAPA__PUBLICADO__1367E606] DEFAULT ('N') NOT NULL,
    CONSTRAINT [PK_MAPA] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_MAPA_FUNCION] FOREIGN KEY ([FUNCION]) REFERENCES [dbo].[FUNCION] ([ID]),
    CONSTRAINT [FK_MAPA_SALA] FOREIGN KEY ([SALA]) REFERENCES [dbo].[SALA] ([ID])
);
