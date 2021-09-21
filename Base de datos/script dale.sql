create database PruebaDale
go
use PruebaDale
go 
create table P_Producto
(
	IdProducto uniqueidentifier primary key,
	CodProducto int identity(1,1) not null,
	Nombre varchar(200) not null,
	VlrProducto decimal(18,0) not null,
	IndicaEliminado bit not null default 0
)
go
create table P_Cliente 
(
	IdCliente uniqueidentifier primary key,
	Cedula varchar(100) not null,
	Nombre varchar (200) not null,
	NumeroTelefono varchar(10) not null,
	IndicaEliminado bit not null default 0
)
go 
create table N_Factura 
(
	IdFactura uniqueidentifier primary key,
	IdCliente uniqueidentifier not null,
	ValorTotal decimal(18,2) not null,
	FechaFactura datetime not null
)
go 
create table N_DetalleFactura
(
	IdDetalleFactura uniqueidentifier primary key,
	IdProducto uniqueidentifier not null,
	Cantidad int not null,
	ValorParcial decimal(18,2),
	IdFactura uniqueidentifier
)
go 
If OBJECT_ID('PruebaDale..PA_Producto_insertar') is not null
drop procedure PA_Producto_insertar
go 
create procedure PA_Producto_insertar
	@Nombre varchar (200)
	,@VlrProducto decimal(18,0)
	,@IdProducto uniqueidentifier out
as begin
	declare @id uniqueidentifier 
	set @id = NEWID()
	insert into P_Producto (
	IdProducto
	,Nombre
	,VlrProducto
	) values 
	(
	@id
	,@Nombre
	,@VlrProducto
	)
	set @IdProducto = @id
end
go
If OBJECT_ID('PruebaDale..PA_Producto_consultar') is not null
drop procedure PA_Producto_consultar
go 
create procedure PA_Producto_consultar
as begin
	select 
		IdProducto
		,CodProducto
		,Nombre
		,VlrProducto
	from P_Producto (nolock)
end
go
If OBJECT_ID('PruebaDale..PA_Producto_Actualizar') is not null
drop procedure PA_Producto_Actualizar
go 
create procedure PA_Producto_Actualizar
@IdProducto uniqueidentifier 
,@Nombre varchar(200)
,@VlrProducto decimal(18,0)
,@IndicaEliminado bit 
,@Resultado int out
as begin
	 update a set
	 a.Nombre =  @Nombre,
	 a.VlrProducto = @VlrProducto,
	 a.IndicaEliminado = @IndicaEliminado
	 from P_Producto a 
	 where a.IdProducto = @IdProducto

	 set @Resultado = @@rowcount
end

go 
If OBJECT_ID('PruebaDale..PA_Cliente_insertar') is not null
drop procedure PA_Cliente_insertar
go 
create procedure PA_Cliente_insertar
	@Cedula varchar(100) 
	,@Nombre varchar (200)
	,@NumeroTelefono varchar(10)
	,@IdCliente uniqueidentifier out
as begin
	declare @id uniqueidentifier 
	set @id = NEWID()
	insert into P_Cliente (
	IdCliente 
	,Cedula 
	,Nombre 
	,NumeroTelefono 
	,IndicaEliminado 
	) values 
	(
	@id
	,@Cedula 
	,@Nombre 
	,@NumeroTelefono 
	,0 
	)
	select @IdCliente = @id
end
go
If OBJECT_ID('PruebaDale..PA_Cliente_consultar') is not null
drop procedure PA_Cliente_consultar
go 
create procedure PA_Cliente_consultar
as begin
	select 
		IdCliente 
		,Cedula 
		,Nombre 
		,NumeroTelefono 
		,IndicaEliminado 
	from P_Cliente (nolock)
end
go
If OBJECT_ID('PruebaDale..PA_Cliente_Actualizar') is not null
drop procedure PA_Cliente_Actualizar
go 
create procedure PA_Cliente_Actualizar

@IdCliente uniqueidentifier  
,@Cedula varchar(10)
,@Nombre varchar(50)
,@NumeroTelefono varchar(10)
,@IndicaEliminado bit
,@Resultado int out
as begin
	 update a set
		Cedula = @cedula
		,Nombre = @Nombre
		,NumeroTelefono = @NumeroTelefono
		,IndicaEliminado = @IndicaEliminado
	 from P_Cliente a 
	 where a.IdCliente = @IdCliente
	 set @Resultado = @@ROWCOUNT
end

go 
If OBJECT_ID('PruebaDale..PA_Factura_insertar') is not null
drop procedure PA_Factura_insertar
go 
create procedure PA_Factura_insertar
	@IdCliente uniqueidentifier
	,@ValorTotal decimal(18,2)
	,@IdFactura uniqueidentifier out
as begin
	declare @id uniqueidentifier 
	set @id = NEWID()
	insert into N_Factura (
		IdFactura 
		,IdCliente 
		,ValorTotal 
		,FechaFactura
	) values 
	(
		@id
		,@IdCliente 
		,@ValorTotal 
		,getdate()
	)
	set @IdFactura = @id
end
go
If OBJECT_ID('PruebaDale..PA_Factura_consultar') is not null
drop procedure PA_Factura_consultar
go 
create procedure PA_Factura_consultar
as begin
	select 
		IdFactura 
		,IdCliente 
		,ValorTotal 
		,FechaFactura
	from N_Factura (nolock)
end
go
If OBJECT_ID('PruebaDale..PA_Factura_Actualizar') is not null
drop procedure PA_Factura_Actualizar
go 
create procedure PA_Factura_Actualizar
	@IdCliente uniqueidentifier 
	,@IdFactura uniqueidentifier 
	,@ValorTotal decimal(18,0)
	,@Resultado int out
as begin
	 update a set
		IdCliente = @IdCliente
		,ValorTotal =  @ValorTotal
		,FechaFactura = getdate()
	 from N_Factura a 
	 where a.IdFactura  = @IdFactura 
	 set @Resultado = @@ROWCOUNT
end
go 
If OBJECT_ID('PruebaDale..PA_DetalleFactura_insertar') is not null
drop procedure PA_DetalleFactura_insertar
go 
create procedure PA_DetalleFactura_insertar
	@IdProducto uniqueidentifier
	,@Cantidad int 
	,@ValorParcial decimal(18,2)
	,@IdFactura uniqueidentifier
	,@IdDetalleFactura uniqueidentifier out
as begin
	declare @id uniqueidentifier 
	set @id = NEWID()
	insert into N_DetalleFactura (
		IdDetalleFactura
		,IdProducto 
		,Cantidad 
		,ValorParcial 
		,IdFactura 
	) values 
	(
		@id
		,@IdProducto 
		,@Cantidad 
		,@ValorParcial 
		,@IdFactura
	)
	set @IdDetalleFactura = @id
end
go
If OBJECT_ID('PruebaDale..PA_DetalleFactura_consultar') is not null
drop procedure PA_DetalleFactura_consultar
go 
create procedure PA_DetalleFactura_consultar
as begin
	select 
		IdDetalleFactura
		,IdProducto 
		,Cantidad 
		,ValorParcial
		,IdFactura 
	from N_DetalleFactura (nolock)
end
go
If OBJECT_ID('PruebaDale..PA_DetalleFactura_Actualizar') is not null
drop procedure PA_DetalleFactura_Actualizar
go 
create procedure PA_DetalleFactura_Actualizar
	@IdDetalleFactura uniqueidentifier 
	,@IdProducto uniqueidentifier 
	,@Cantidad int 
	,@ValorParcial decimal(18,0)
	,@Resultado int out
as begin
	 update a set
		IdProducto = @IdProducto
		,Cantidad = @Cantidad
		,ValorParcial = ValorParcial
	 from N_DetalleFactura a 
	 where a.IdDetalleFactura   = @IdDetalleFactura 
	 select @@ROWCOUNT
end
go

alter table N_Factura add
constraint fk_N_Factura_P_Cliente 
foreign key (IdCliente)
references P_Cliente(IdCliente)
go
alter table N_DetalleFactura add
constraint fk_N_DetalleFactura_N_Factura 
foreign key (IdFactura)
references N_Factura(IdFactura)
go
alter table N_DetalleFactura add
constraint fk_N_DetalleFactura_P_Producto
foreign key (IdProducto)
references P_Producto(IdProducto)
