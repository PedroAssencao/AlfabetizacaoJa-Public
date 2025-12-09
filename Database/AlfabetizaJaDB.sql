use master
go
create database AlfabetizaDB
go
use AlfabetizaDB
go
create table Historia(
hist_id int identity (1,1) primary key,
hist_Autor varchar(300),
hist_Titulo varchar(500),
Hist_trecho varchar(max),
hist_img varchar(max)
)



go

create table Login(
log_id int identity (1,1) primary key,
log_user varchar(999),
log_email varchar(999),
log_senha varchar(999),
log_numeroW varchar(300)
)

CREATE TABLE Salas (
    sala_id int identity(1,1) primary key,
    log_id int,
    sala_url varchar(max),
    sala_aberta bit
	FOREIGN KEY (log_id) REFERENCES Login(log_id)
);


CREATE TABLE Alunos (
    aluno_id int identity(1,1) primary key,
    log_id int, 
    nome_aluno varchar(255),
    nota float,
    FOREIGN KEY (log_id) REFERENCES Login(log_id)
 
);


go
insert Login (log_user, log_email, log_senha) values ('Master','Master2023@gmail.com', 'c2VuYWkuMTIz')
insert Login (log_user, log_email, log_senha) values ('Pedro','Pedro2023@gmail.com', 'c2VuYWkuMTIz')
insert Historia(hist_Autor, hist_Titulo, Hist_trecho) values('Machado de Assis', 'Dom Cassmurro','Bento gostava de trair')
select * from Alunos
select * from Historia
select * from Login
select * from Salas
