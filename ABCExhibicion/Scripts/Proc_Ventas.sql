USE ComprasMuebles
go
CREATE PROCEDURE dbo.proc_ventas (@iVentaid INT,
									@iClienteid INT,
									@cClienteNombre VARCHAR(40),
									@cArticuloNombre  VARCHAR(40),
									@iArticuloid INT,
									@iTotalVenta decimal(18,2),
									@iFechaVenta smalldatetime,
									@iOpcion SMALLINT)
--Descripcion: Se agregan las opciones para insertar, actualizar, eliminar y obtener datos "CRUD"
	-- Variable "iOpcion"
		-- 1) Insertar Venta
		-- 2) Actualizar Venta
		-- 3) Elimnar Venta
		-- 4) Obtener Venta ID
		-- 5) Obtener todas las Ventas
		-- 6) Obtener empleados
		-- 7) Obtener Articulos
		-- 8) Obtenr Clientes por Nombre
		-- 9) Obtener Articulos por Nombre 
		-- 10) Ventas Totales


AS
BEGIN
declare @iMessage int
		

set @iMessage = 0


	 if @iOpcion = 1 
	 BEGIN
		INSERT INTO zabccat_ventas Values (@iClienteid,@iTotalVenta,@iFechaVenta)
	 END
	 ELSE IF @iOpcion = 2
	 BEGIN
		UPDATE zabccat_ventas SET idu_cliente = @iClienteid, num_totalventa = @iTotalVenta, fech_venta = @iFechaVenta  where idu_venta = @iVentaid
	 END
	 ELSE IF @iOpcion = 3
	 BEGIN
		DELETE FROM zabccat_ventas where idu_venta = @iVentaid
	 END
	 ELSE IF @iOpcion = 4
	 BEGIN 
		Select *  FROM zabccat_ventas where idu_venta = @iVentaid
	 END
	 ELSE IF @iOpcion = 5
	 BEGIN
		Select * From zabccat_ventas
	 END
	 ELSE IF @iOpcion = 6
	 BEGIN
		select * from zabccat_cliente 
	 END
	 ELSE IF @iOpcion = 7
	 BEGIN
		select  des_articulo from zabccat_articulos 
	 END
	 ELSE IF @iOpcion = 8
	 BEGIN
		select nom_cliente from zabccat_cliente where idu_cliente = @iClienteid 
	 END
	 ELSE IF @iOpcion = 9
	 BEGIN
		select  des_articulo, des_modelo, num_preciounitario from zabccat_articulos where des_articulo = @cArticuloNombre
	 END
	 ELSE IF @iOpcion = 10
	 BEGIN
		select * from zabcconfiguracion
	 END
	 ELSE IF @iOpcion = 11
	 BEGIN
		select Count(*) As total from zabccat_ventas
	 END
END


--DROP PROCEDURE dbo.proc_ventas
