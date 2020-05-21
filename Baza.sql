create database LagerLista

use lagerlista

create table DimensionLenght
(
	Id bigint primary key not null identity(1,1),
	LLength int not null
)

create table DimensionWidth
(
	Id bigint primary key not null identity(1,1),
	Width int not null
)

create table DimensionThickness
(
	Id bigint primary key not null identity(1,1),
	Thickness int not null
)

create table Ttype
(
	Id bigint primary key not null identity(1,1),
	Name nvarchar(50) not null
)

create table Panel
(
	Id bigint primary key not null identity (1,1),
	Name nvarchar(50) not null,
	TypeId bigint references Ttype(Id),
	LengthId bigint references DimensionLenght(Id),
	WidthId bigint references DimensionWidth(Id),
	ThicknessId bigint references DimensionThickness(Id),
	Quantity int not null,
	PanelSurface float not null,
	SurfaceInTotal float not null,
	InsertTime datetime not null,
	UpdateTime datetime not null
)


