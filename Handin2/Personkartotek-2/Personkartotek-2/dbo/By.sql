create table [By] (
  ID         int identity not null, 
  Land       varchar(255) not null, 
  [By]       varchar(255) not null, 
  Postnummer varchar(255) not null, 
  ByListeID  int not null, 
  primary key (ID));
GO
alter table [By] add constraint FKBy662765 foreign key (ByListeID) references ByListe (ID);