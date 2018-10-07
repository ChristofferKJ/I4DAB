CREATE TABLE Telefon (
  TeleID            int IDENTITY NOT NULL, 
  OperatoerID    int NOT NULL, 
  PersonID      int NOT NULL, 
  Telefonnummer varchar(255) NULL, 
  PRIMARY KEY (TeleID));
GO
ALTER TABLE Telefon ADD CONSTRAINT FKTelefon747761 FOREIGN KEY (PersonID) REFERENCES Person (PersonID);
GO
ALTER TABLE Telefon ADD CONSTRAINT FKTelefon302512 FOREIGN KEY (OperatoerID) REFERENCES Operatoer (OperatoerID);