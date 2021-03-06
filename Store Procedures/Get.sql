USE [if076_db]
GO
/****** Object:  StoredProcedure [dbo].[NodesGet]    Script Date: 7/12/2017 1:20:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[NodesGet]
(
	@Id	INT
)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT 
		n.Id, 
		n.Name 
	FROM Nodes AS n
	WHERE n.Id = @Id
END
