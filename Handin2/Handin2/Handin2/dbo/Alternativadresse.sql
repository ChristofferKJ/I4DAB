--
-- Create Table    : 'Alternativadresse'   
-- PersonID        :  (references Person.PersonID)
-- AdresseID       :  (references Adresse.AdresseID)
-- Type            :  
--
CREATE TABLE Alternativadresse (
    PersonID       BIGINT NOT NULL,
    AdresseID      BIGINT NOT NULL,
    Type           NVARCHAR(300) NOT NULL,
CONSTRAINT pk_Alternativadresse PRIMARY KEY CLUSTERED (PersonID,AdresseID),
CONSTRAINT fk_Alternativadresse FOREIGN KEY (PersonID)
    REFERENCES Person (PersonID)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
CONSTRAINT fk_Alternativadresse2 FOREIGN KEY (AdresseID)
    REFERENCES Adresse (AdresseID)
    ON DELETE CASCADE
    ON UPDATE CASCADE)