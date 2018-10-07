create table Telefon (
  ID         int identity not null, 
  OperatÃ¸r   varchar(255) not null, 
  Nummer     int not null, 
  Type       varchar(255) not null, 
  OperatÃ¸rID int not null, 
  primary key (ID));
GO
alter table Telefon add constraint FKTelefon302512 foreign key (OperatÃ¸rID) references OperatÃ¸r (ID);