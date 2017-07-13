USE [if076_db]
GO
/****** Object:  StoredProcedure [dbo].[NodesList]    Script Date: 7/12/2017 1:20:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[NodesList]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT 
		n.Id, 
		n.Name 
	FROM Nodes AS n
	ORDER BY n.Id DESC
END
