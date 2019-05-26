create database Clinica
go
use Clinica
create table Paciente(
id_paciente int IDENTITY(1,1) primary key,
nombre varchar (50) not null,
apepaterno varchar (30) not null,
apematerno varchar (30) not null,
sexo varchar (30) not null,
edad varchar (3) not null,
calle varchar (200) not null,
colonia varchar (200) not null,
codigopostal varchar (5) not null,
telefono varchar (10) not null,
correo varchar (100) not null,
alergia varchar (200)
)
go
create table Servicio(
id_servicio int IDENTITY(1,1) primary key,
nombre varchar (50) not null,
descripcion varchar (200) not null,
precio numeric(7,2) not null,
tiempoestimado varchar(50) not null,
estatus int not null
)
go
create table Cita(
keyx int IDENTITY(10000,1) primary key,
foliocita int not null,
id_paciente int not null,
id_servicio int not null,
fecha date not null,
hora varchar (5) not null,
estatus int not null,
observaciones varchar(500) not null
)
go
create table usuario(
id_usuario int IDENTITY(1,1) primary key,
usuario varchar(100) unique not null,
contra varchar (30) not null,
tipo_usuario int not null
)
go
CREATE TABLE tb_listadeespera
(
	keyx int IDENTITY(1,1) primary key,
	fechacita DATE,
	horacita varchar(20),
	nombreservicio VARCHAR(30),
	id_paciente INT,
	nombre VARCHAR(30),
	apepaterno VARCHAR (30),
	apematerno VARCHAR (30)
)
go
CREATE TABLE Foliador
(
	folio INT,
	tipo char(1)
)
go
insert into Foliador VALUES (1000,'A')
go
alter table Cita
add constraint FK_PacienteCita
Foreign Key(id_paciente) references Paciente(id_paciente)
go
alter table Cita
add constraint FK_ServicioCita
Foreign Key(id_servicio) references Servicio(id_servicio) 