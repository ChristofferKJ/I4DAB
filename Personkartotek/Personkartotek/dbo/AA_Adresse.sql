﻿CREATE TABLE AA_Adresse (
  PersonID  BIGINT NOT NULL,
  AdresseID BIGINT NOT NULL,
  AA_AdresseID BIGINT IDENTITY(1,1) NOT NULL,
  Type      NVARCHAR(MAX) NOT NULL,
CONSTRAINT pk_AA_Adresse PRIMARY KEY CLUSTERED (PersonID,AdresseID,AA_AdresseID),
CONSTRAINT fk_AA_Adresse FOREIGN KEY (PersonID)
    REFERENCES Person (PersonID)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
CONSTRAINT fk_AA_Adresse2 FOREIGN KEY (AdresseID)
    REFERENCES Adresse (AdresseID)
    ON DELETE CASCADE
    ON UPDATE CASCADE)