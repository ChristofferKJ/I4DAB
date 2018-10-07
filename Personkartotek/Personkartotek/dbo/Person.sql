CREATE TABLE Person (
  PersonID   int IDENTITY NOT NULL, 
  Navn varchar(255) NULL, 
  Type varchar(255) NULL, 
  AdresseID INT NULL, 
    PRIMARY KEY (PersonID));

GO
ALTER TABLE Person ADD CONSTRAINT FRA123 FOREIGN KEY (AdresseID) REFERENCES Adresse (AdresseID);