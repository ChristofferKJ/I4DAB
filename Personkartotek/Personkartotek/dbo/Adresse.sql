CREATE TABLE Adresse (
  AdresseID         int IDENTITY NOT NULL, 
  PersonID   int NOT NULL, 
  Vej        varchar(255) NULL, 
  [By]       varchar(255) NULL, 
  Husnummer  varchar(255) NULL, 
  Postnummer varchar(255) NULL, 
  PRIMARY KEY (AdresseID));
GO
ALTER TABLE Adresse ADD CONSTRAINT FRA FOREIGN KEY (PersonID) REFERENCES Person (PersonID);