/* ============================== */
-- CREACION DE BASE DE DATOS
/* ============================== */

drop database if exists cine;
create database cine;
go

use cine;
go

/* ============================== */
-- CREACION DE TABLAS
/* ============================== */

/* --------------------------------
Tabla: pelicula
-------------------------------- */

drop table if exists pelicula;
create table pelicula (
	id_pelicula int primary key identity(1,1),
    titulo varchar(100) not null,
	sinopsis varchar(500) not null,
	director varchar(100) not null,
	genero varchar(100) not null,
	ranking decimal(5,1) not null,
	poster varchar(max)
);
