CREATE TABLE Person_Adresse (
  PersonID  int NOT NULL, 
  AdresseID int NOT NULL, 
  Type      varchar(255) NOT NULL);
GO
ALTER TABLE Person_Adresse ADD CONSTRAINT FKPerson_Adr321172 FOREIGN KEY (PersonID) REFERENCES Person (PersonID);
GO
ALTER TABLE Person_Adresse ADD CONSTRAINT FKPerson_Adr332690 FOREIGN KEY (AdresseID) REFERENCES Adresse (AdresseID);