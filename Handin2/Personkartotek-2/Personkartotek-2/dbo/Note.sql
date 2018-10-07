create table Note (
  ID       int not null, 
  Indhold  varchar(255) not null, 
  PersonID int not null, 
  primary key (ID, 
  PersonID));
GO
alter table Note add constraint FKNote606787 foreign key (PersonID) references Person (ID);