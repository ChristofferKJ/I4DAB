﻿CREATE TABLE Operatoer (
  OperatoerID   BIGINT IDENTITY(1,1) NOT NULL,
  Navn			NVARCHAR(MAX) NOT NULL,
CONSTRAINT pk_Operatoer PRIMARY KEY CLUSTERED (OperatoerID))