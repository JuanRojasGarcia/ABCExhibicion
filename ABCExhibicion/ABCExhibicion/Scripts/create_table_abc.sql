USE ComprasMuebles
GO
IF EXISTS(SELECT name FROM sysobjects (NOLOCK) WHERE name = 'zabccat_articulos' AND type = 'u' AND uid = 1)
	DROP TABLE ComprasMuebles.dbo.zabccat_articulos 
	--ALTER TABLE zabccat_articulos DROP constraint [pk_zabccat_articulos]
GO

CREATE TABLE ComprasMuebles.dbo.zabccat_articulos 
(
	idu_articulo int not null default 0,
	des_articulo varchar(20) not null default '',
	des_modelo varchar(20) not null default '',
	des_marca varchar(10) not null default '',
	num_preciounitario decimal(10,2) not null default(0),
	num_existencia smallint not null default 0,
	constraint [pk_zabccat_articulos] primary key (idu_articulo)

)

GO
PROC_DOCUMENTACION 'zabccat_articulos','','tabla de articulos'
GO
PROC_DOCUMENTACION 'zabccat_articulos','idu_articulo','identificador de articulo'
GO
PROC_DOCUMENTACION 'zabccat_articulos','des_articulo','nombre del articulo'
GO
PROC_DOCUMENTACION 'zabccat_articulos','des_modelo','nombre del modelo del articulo'
GO
PROC_DOCUMENTACION 'zabccat_articulos','des_marca','noombre de la marca del articulo'
GO
PROC_DOCUMENTACION 'zabccat_articulos','num_preciounitario','precio por unidad del articulo'
GO
PROC_DOCUMENTACION 'zabccat_articulos','num_existencia','piezas de articulos en stock'
GO

USE ComprasMuebles
GO
IF EXISTS(SELECT name FROM sysobjects (NOLOCK) WHERE name = 'zabccat_centros' AND type = 'u' AND uid = 1)
	DROP TABLE ComprasMuebles.dbo.zabccat_centros 
	--ALTER TABLE zabccat_centros DROP constraint [pk_zabccat_centros]
GO

CREATE TABLE ComprasMuebles.dbo.zabccat_centros 
(
	idu_centro int not null default 0,
	des_centro varchar(20) not null default '',
	constraint [pk_zabccat_centros] primary key (idu_centro)
)

GO
PROC_DOCUMENTACION 'zabccat_centros','','tabla de centros'
GO
PROC_DOCUMENTACION 'zabccat_centros','idu_centro','identificador de los centros'
GO
PROC_DOCUMENTACION 'zabccat_centros','des_centro','nombre del centro'
GO

USE ComprasMuebles
GO
IF EXISTS(SELECT name FROM sysobjects (NOLOCK) WHERE name = 'zabcconfiguracion' AND type = 'u' AND uid = 1)
	DROP TABLE ComprasMuebles.dbo.zabcconfiguracion 
	--ALTER TABLE zabcconfiguracion DROP constraint [pk_zabcconfiguracion]

GO

CREATE TABLE ComprasMuebles.dbo.zabcconfiguracion 
(
	idu_configuracion int not null default 0,
	num_tasafinanciamiento float not null default(0),
	num_enganche tinyint not null default 0,
	num_plazomaximo  tinyint not null default 0,
	constraint [pk_zabcconfiguracion] primary key (idu_configuracion)
)

GO
PROC_DOCUMENTACION 'zabcconfiguracion','','configuraciones proceso ventas'
GO
PROC_DOCUMENTACION 'zabcconfiguracion','idu_configuracion','identificador de la configuracion'
GO
PROC_DOCUMENTACION 'zabcconfiguracion','num_tasafinanciamiento','Interes'
GO
PROC_DOCUMENTACION 'zabcconfiguracion','num_enganche','Porcentaje de enganche'
GO
PROC_DOCUMENTACION 'zabcconfiguracion','num_plazomaximo','Numero de meses a pagar'
GO

USE ComprasMuebles
GO
IF EXISTS(SELECT name FROM sysobjects (NOLOCK) WHERE name = 'zabccat_empleados' AND type = 'u' AND uid = 1)
	DROP TABLE ComprasMuebles.dbo.zabccat_empleados 
	--ALTER TABLE zabccat_empleados DROP constraint [fk_zabccat_centros]
	--ALTER TABLE zabccat_empleados DROP constraint [pk_zabccat_empleados]

GO

CREATE TABLE ComprasMuebles.dbo.zabccat_empleados 
(
	idu_empleado int not null default 0,
	idu_centro int not null default 0,
	nom_empleado varchar(20) not null default '',
	nom_apellido  varchar(20) not null default '',
	rfc_empleado varchar(20) not null default '',
	constraint [pk_zabccat_empleados] primary key (idu_empleado),
    constraint [fk_zabccat_centros] FOREIGN KEY (idu_centro) REFERENCES zabccat_centros(idu_centro)
)

GO
PROC_DOCUMENTACION 'zabccat_empleados','','tabla empleados'
GO
PROC_DOCUMENTACION 'zabccat_empleados','idu_empleado','identificador empleado'
GO
PROC_DOCUMENTACION 'zabccat_empleados','idu_centro','identificador del centro'
GO
PROC_DOCUMENTACION 'zabccat_empleados','nom_empleado','nombre del empleado'
GO
PROC_DOCUMENTACION 'zabccat_empleados','nom_apellido','apellido del empleado'
GO
PROC_DOCUMENTACION 'zabccat_empleados','rfc_empleado','rfc del empleado'
GO

USE ComprasMuebles
GO
IF EXISTS(SELECT name FROM sysobjects (NOLOCK) WHERE name = 'zabccat_ventas' AND type = 'u' AND uid = 1)
	DROP TABLE ComprasMuebles.dbo.zabccat_ventas 
	--ALTER TABLE zabccat_ventas DROP constraint [fk_zabccat_empleados]
	--ALTER TABLE zabccat_ventas DROP constraint [pk_zabccat_ventas]
GO

CREATE TABLE ComprasMuebles.dbo.zabccat_ventas 
(
	idu_venta int  IDENTITY(1,1) not null,
	idu_empleado int not null default 0,
	num_totalventa decimal(18,2) not null default(0),
	fech_venta smalldatetime NOT NULL DEFAULT '1900-01-01',
	constraint [pk_zabccat_ventas] primary key (idu_venta),
    constraint [fk_zabccat_empleados] FOREIGN KEY (idu_empleado) REFERENCES zabccat_empleados(idu_empleado)
)

GO
PROC_DOCUMENTACION 'zabccat_ventas','','tabla ventas'
GO
PROC_DOCUMENTACION 'zabccat_ventas','idu_venta','identificador de la venta'
GO
PROC_DOCUMENTACION 'zabccat_ventas','idu_empleado','identificador del empleado'
GO
PROC_DOCUMENTACION 'zabccat_ventas','num_totalventa','costo toal de la venta'
GO
PROC_DOCUMENTACION 'zabccat_ventas','fech_venta','fecha en que se efectuo la venta'
GO

--drop table zabccat_ventas