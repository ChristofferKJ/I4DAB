CREATE TABLE Emailadresse (
  EmailID       int IDENTITY NOT NULL, 
  PersonID int NOT NULL, 
  Email    varchar(255) NULL, 
  PRIMARY KEY (EmailID));
GO
ALTER TABLE Emailadresse ADD CONSTRAINT FKEmailadres218851 FOREIGN KEY (PersonID) REFERENCES Person (PersonID);