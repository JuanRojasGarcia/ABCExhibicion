USE ComprasMuebles
go
CREATE PROCEDURE dbo.proc_abcentros (@iCentroid INT,
									@cCentroNom VARCHAR(20), 
									@iOpcion SMALLINT)
--Descripcion: Se agregan las opciones para insertar, actualizar, eliminar y obtener datos "CRUD"
	-- Variable "iOpcion"
		-- 1) Insertar Centro
		-- 2) Actualizar Centro
		-- 3) Elimnar Centro
		-- 4) Obtener Centro ID
		-- 5) Obtener todos los Centros
		-- 6) Total Centros

AS
BEGIN
declare @iConsulta int, @iError int
		

set @iError = 0
set @iConsulta = 0


	 if @iOpcion = 1 
	 BEGIN
		IF NOT EXISTS (SELECT idu_centro FROM zabccat_centros WHERE idu_centro = @iCentroid)
			BEGIN
				INSERT INTO zabccat_centros Values (@iCentroid,@cCentroNom)
			END
		ELSE
		set @iError  = 1
		select @iError as Error
	 END
	 ELSE IF @iOpcion = 2
	 BEGIN
		UPDATE zabccat_centros SET des_centro = @cCentroNom where idu_centro = @iCentroid
	 END
	 ELSE IF @iOpcion = 3
	 BEGIN
		DELETE FROM zabccat_centros where idu_centro = @iCentroid
	 END
	 ELSE IF @iOpcion = 4
	 BEGIN 
		Select *  FROM zabccat_centros where idu_centro = @iCentroid
	 END
	 ELSE IF @iOpcion = 5
	 BEGIN
		Select * From zabccat_centros
	 END
	 ELSE IF @iOpcion = 6
	 BEGIN
		Select Count(*) As total From zabccat_centros
	 END
END


--DROP PROCEDURE dbo.proc_abcentros
