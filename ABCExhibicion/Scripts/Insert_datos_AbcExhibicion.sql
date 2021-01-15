use ComprasMuebles
go

insert into ComprasMuebles.dbo.zabcconfiguracion(idu_configuracion,num_tasafinanciamiento,num_enganche,num_plazomaximo)  
values (1,2.8,20,12)
go

insert into ComprasMuebles.dbo.zabccat_locaciones(idu_locacion,des_municipio,des_locacion)  
SELECT 001,'Culiacan','Villas del Rio' union all
SELECT 002,'Culiacan','La Conquista' union all
SELECT 003,'Culiacan','Las Quintas' union all
SELECT 101,'Mazatlan','Santa Virginia' union all
SELECT 102,'Mazatlan','Villa verde' union all
SELECT 103,'Mazatlan','Puertas del Sol' union all
SELECT 201,'Navolato','Bachimeto' union all
SELECT 202,'Navolato','Altata' union all
SELECT 203,'Navolato','Bariometo' union all
SELECT 301,'Badiraguato','Surutato' union all
SELECT 302,'Badiraguato','Soyatita' union all
SELECT 304,'Badiraguato' ,'Bacuribito' 
go


--Insert de Prueba
