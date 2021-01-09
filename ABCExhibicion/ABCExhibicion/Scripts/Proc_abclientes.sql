USE ComprasMuebles
go
CREATE PROCEDURE dbo.proc_abclientes (@iClienteid INT,
									@cCentroNum INT, 
									@cClienteNom VARCHAR(40),
									@cClienteApell VARCHAR(40),
									@cClienteRfc VARCHAR(40),
									@iOpcion SMALLINT)
--Descripcion: Se agregan las opciones para insertar, actualizar, eliminar y obtener datos "CRUD"
	-- Variable "iOpcion"
		-- 1) Insertar Cliente
		-- 2) Actualizar Cliente
		-- 3) Elimnar Cliente
		-- 4) Obtener Cliente ID
		-- 5) Obtener todos los Cliente
		-- 6) Obtener Centros
		-- 7) Total Centros

AS
BEGIN
declare @iConsulta int, @iMessage int
		

set @iMessage = 0
set @iConsulta = 0



	 if @iOpcion = 1 
	 BEGIN
		IF NOT EXISTS (SELECT idu_empleado FROM zabccat_empleados WHERE idu_empleado = @iClienteid)
			BEGIN
				INSERT INTO zabccat_empleados Values (@iClienteid,@cCentroNum,@cClienteNom,@cClienteApell,@cClienteRfc)
			END
		ELSE
			set @iMessage  = 1	
		select @iMessage as Error
	 END
	 ELSE IF @iOpcion = 2
	 BEGIN
		UPDATE zabccat_empleados SET idu_centro = @cCentroNum, nom_empleado = @cClienteNom, nom_apellido = @cClienteApell, rfc_empleado = @cClienteRfc  where idu_empleado = @iClienteid
	 END
	 ELSE IF @iOpcion = 3
	 BEGIN
		DELETE FROM zabccat_empleados where idu_empleado = @iClienteid
	 END
	 ELSE IF @iOpcion = 4
	 BEGIN 

		Select *  FROM zabccat_empleados where idu_empleado = @iClienteid
			
	 END
	 ELSE IF @iOpcion = 5
	 BEGIN
		Select * From zabccat_empleados
	 END
	 ELSE IF @iOpcion = 6
	 BEGIN
		select idu_centro from zabccat_centros
	 END
	 ELSE IF @iOpcion = 7
	 BEGIN
		Select Count(*) As total From zabccat_empleados
	 END
END


--DROP PROCEDURE dbo.proc_abclientes
