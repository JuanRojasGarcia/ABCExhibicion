use ComprasMuebles
go

insert into ComprasMuebles.dbo.zabccat_articulos(idu_articulo,des_articulo,des_modelo,des_marca,num_preciounitario,num_existencia)  
values (123456,'Comedor','V2','Bamboo',199.00,50)
go

insert into ComprasMuebles.dbo.zabcconfiguracion(idu_configuracion,num_tasafinanciamiento,num_enganche,num_plazomaximo)  
values (1,2.8,20,12)
go

insert into ComprasMuebles.dbo.zabccat_empleados(idu_empleado,idu_centro,nom_empleado,nom_apellido,rfc_empleado)  
values (1,230282,'Juan Carlos','Rojas Garcia','ROGKJSDFH54')
go

insert into ComprasMuebles.dbo.zabccat_empleados(idu_empleado,idu_centro,nom_empleado,nom_apellido,rfc_empleado)  
values (2,230444,'German','Velarde','GER3442343GE')
go