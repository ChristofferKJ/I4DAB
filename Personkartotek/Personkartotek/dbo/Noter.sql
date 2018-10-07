CREATE TABLE Noter (
  NoterID       int IDENTITY NOT NULL, 
  Note     varchar(255) NULL, 
  PersonID int NULL, 
  PRIMARY KEY (NoterID));
GO
ALTER TABLE Noter ADD CONSTRAINT FKNoter584620 FOREIGN KEY (PersonID) REFERENCES Person (PersonID);