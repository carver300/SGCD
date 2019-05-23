/****** Object:  StoredProcedure [dbo].[SP_ActualizarInformacionPaciente]    Script Date: 5/22/2019 11:49:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_ActualizarInformacionPaciente]
-- =============================================
-- Author: Santiago Penunuri Quintero
-- Create date: 20/05/2019
-- Description:    Procedimiento para actualizar informacion.
-- =============================================

	@id_paciente as INTEGER,
    @nombre AS VARCHAR(50),
    @apepaterno AS VARCHAR(30),
    @apematerno AS VARCHAR(30),
    @sexo AS VARCHAR(30),
	@edad AS VARCHAR(3),
	@calle AS VARCHAR(200),
	@colonia AS VARCHAR(200),
	@codigopostal AS VARCHAR(5),
	@telefono AS VARCHAR(10),
    @correo AS VARCHAR(100),
	@alergia AS VARCHAR(200) 
AS
BEGIN
		IF EXISTS(SELECT 'x' FROM Paciente WHERE id_paciente = @id_paciente)
			--El paciente existe por lo que se ejecuta el update
			UPDATE PACIENTE SET
			nombre = @nombre, apepaterno = @apepaterno, apematerno = @apematerno,
			sexo = @sexo, edad = @edad, calle = @calle, colonia = @colonia, codigopostal = @codigopostal, telefono = @telefono,
			correo = @correo, alergia = @alergia 
			WHERE id_paciente = @id_paciente

			RETURN 1

		RETURN 0
END