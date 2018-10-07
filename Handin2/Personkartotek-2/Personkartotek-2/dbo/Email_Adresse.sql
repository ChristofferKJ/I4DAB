create table Email_Adresse (
  ID      int identity not null, 
  Adresse varchar(255) not null, 
  Type    varchar(255) not null, 
  primary key (ID));