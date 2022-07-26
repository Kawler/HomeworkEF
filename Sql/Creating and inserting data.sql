use Todo

create table Todo(
	Id int identity(1,1) constraint PK_Todo primary key,
	Title nvarchar(500),
	IsDone bit)


insert into Todo
(Title,IsDone)
values
('Water plants',0),
('Laundry',0),
('Take pills',0)
