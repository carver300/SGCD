/****** Object:  StoredProcedure [dbo].[SP_AgregaPaciente]    Script Date: 5/22/2019 11:49:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_AgregaServicios]
-- =============================================
-- Author: Santiago Penunuri
-- Create date: 20/05/2019
-- Description:    Procedimiento para Insertar Servicios.
-- =============================================
	
	@nombre as VARCHAR(50),
	@descripcion as VARCHAR(200),
	@precio as NUMERIC(7,2),
	@tiempoestimado VARCHAR(50)




AS
BEGIN

	INSERT INTO Servicio (nombre,descripcion,precio,tiempoestimado)
	VALUES (@nombre,@descripcion,@precio,@tiempoestimado)

	RETURN 1

				
END