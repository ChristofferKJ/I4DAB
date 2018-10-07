create table Person (
  ID         int identity not null, 
  Fornavn    varchar(255) not null, 
  Mellemnavn varchar(255) not null, 
  Efternavn  varchar(255) not null, 
  Telefon    varchar(255) not null, 
  FRAID      int not null, 
  primary key (ID));
GO
alter table Person add constraint FKPerson624859 foreign key (FRAID) references FRA (ID);