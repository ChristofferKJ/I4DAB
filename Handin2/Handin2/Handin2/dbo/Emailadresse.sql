--
-- Create Table    : 'Emailadresse'   
-- EMAILID         :  
-- PersonID        :  (references Person.PersonID)
--
CREATE TABLE Emailadresse (
    EMAILID        BIGINT IDENTITY(1,1) NOT NULL,
    PersonID       BIGINT NOT NULL,
CONSTRAINT pk_Emailadresse PRIMARY KEY CLUSTERED (EMAILID),
CONSTRAINT fk_Emailadresse FOREIGN KEY (PersonID)
    REFERENCES Person (PersonID)
    ON DELETE NO ACTION
    ON UPDATE CASCADE)