﻿
CREATE PROCEDURE [dbo].[SP_D_ITEM]
(
	@ID INT
)
AS
BEGIN
	
	DELETE FROM 
		ITEM	
	WHERE 
		ID = @ID
END