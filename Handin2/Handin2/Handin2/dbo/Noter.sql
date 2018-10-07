--
-- Create Table    : 'Noter'   
-- NoterID         :  
-- PersonID        :  (references Person.PersonID)
--
CREATE TABLE Noter (
    NoterID        BIGINT NOT NULL,
    PersonID       BIGINT NOT NULL,
CONSTRAINT pk_Noter PRIMARY KEY CLUSTERED (NoterID),
CONSTRAINT fk_Noter FOREIGN KEY (PersonID)
    REFERENCES Person (PersonID)
    ON DELETE NO ACTION
    ON UPDATE CASCADE)