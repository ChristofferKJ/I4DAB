create table FRA (
  ID        int identity not null, 
  Vej       varchar(255) not null, 
  [By]      varchar(255) not null, 
  ByListeID int not null, 
  primary key (ID));
GO
alter table FRA add constraint FKFRA730475 foreign key (ByListeID) references ByListe (ID);