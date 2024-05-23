/* ============================== */
-- SELECCION DE BASE DE DATOS
/* ============================== */

use cine;
go

/* ============================== */
-- PROCEDIMIENTOS ALMACENADOS
/* ============================== */

-- sp_contar_peliculas

create or alter procedure sp_contar_peliculas
as
begin
	select 
		count(*) cantidad
	from 
		pelicula pel
end;

go

-- sp_obtener_peliculas

create or alter procedure sp_obtener_peliculas( 
	@pagina int,
	@cant_regs int
)
as
begin
	declare @regs_ignorados int = (@pagina - 1) * @cant_regs;
	select 
		* 
	from 
		pelicula pel
	order by 
		pel.id_pelicula
	offset 
		@regs_ignorados rows
	fetch next 
		@cant_regs rows only
end;

go

-- sp_obtener_pelicula

create or alter procedure sp_obtener_pelicula( 
	@id int
)
as
begin
	select 
		* 
	from 
		pelicula pel
	where 
		id_pelicula = @id
end;

go

-- sp_modificar_pelicula

create or alter procedure sp_modificar_pelicula( 
	@id int,
	@titulo varchar(100),
	@sinopsis varchar(500),
	@director varchar(100),
	@genero varchar(100),
	@ranking decimal(5,1),
	@poster varchar(max)
)
as
begin
	update 
		pelicula 
	set 
		titulo = @titulo,
		sinopsis = @sinopsis,
		director = @director,
		genero = @genero,
		ranking = @ranking,
		poster = @poster
	where 
		id_pelicula = @id
end;

go







