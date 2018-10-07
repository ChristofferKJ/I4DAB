create table AA (
  ID        int identity not null, 
  Vej       varchar(255) not null, 
  [By]      varchar(255) not null, 
  ByListeID int not null, 
  primary key (ID));
GO
alter table AA add constraint FKAA662678 foreign key (ByListeID) references ByListe (ID);