create database T_Ekips;

use T_Ekips;

create table Permissoes
(
IdPermissao   int primary key identity
,Nome         varchar (200) not null unique
);

insert into Permissoes (Nome) values ('Administrador');
insert into Permissoes (Nome) values ('Comum');

select * from Permissoes;

-------------------------------

create table Departamento 
(
IdDepartamento     int primary key identity 
,Nome              varchar (200) not null unique 
);

insert into  Departamento (Nome) values ('Juridico');
insert into  Departamento (Nome) values ('Tecnologia');
insert into  Departamento (Nome) values ('´Saude');

select * from Departamento;

-----------------------------------------

create table Cargos 
(
IdCargo         int primary key identity 
,Nome            varchar (200) not null unique 
,Ativo           varchar (200) not null  
);

insert into Cargos (Nome,Ativo) values ('advogado','sim');
insert into Cargos (Nome,Ativo) values ('Product Owner','sim');
insert into Cargos (Nome,Ativo) values ('Médico','sim');

select * from Cargos;

---------------------------

create Table Usuarios
(
IdUsuario     int primary key identity 
,Email        varchar (250) not null unique 
,Senha        varchar (200) not null unique 
,IdPermissao   int Foreign key references Permissoes (IdPermissao)
);

insert into Usuarios (Email,Senha,IdPermissao) values ('Lari@.com','111',1);
insert into Usuarios (Email,Senha,IdPermissao) values ('Gabi@.com','222',1);
insert into Usuarios (Email,Senha,IdPermissao) values ('Henri@.com','333',2);
DROP TABLE Usuarios;

select * from Usuarios;

-----------------------

create table Funcionarios 
(
IdFuncionario    int primary key identity 
,Nome            varchar (250) not null 
,cpf             int
,dataNascimento   date
,Salario          int
,IdDepartamento   int foreign key references Departamento (IdDepartamento)
,IdCargo          int foreign key references Cargos (IdCargo)
,IdUsuario        int foreign key references Usuarios (IdUsuario)
);
drop table Funcionarios

insert into Funcionarios (Nome,cpf,dataNascimento,Salario,IdDepartamento,IdCargo,IdUsuario) values ('Lari', 123,'20/07/1999',1000,3,3,1);
insert into Funcionarios (Nome,cpf,dataNascimento,Salario,IdDepartamento,IdCargo,IdUsuario) values ('Gabi', 456,'14/05/2002',600,1,1,2);
insert into Funcionarios (Nome,cpf,dataNascimento,Salario,IdDepartamento,IdCargo,IdUsuario) values ('Henri', 789,'22/12/1999',500,2,2,3);

select * from Funcionarios;