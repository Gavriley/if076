USE [if076_db]
GO
/****** Object:  StoredProcedure [dbo].[NodesDelete]    Script Date: 7/12/2017 1:20:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[NodesDelete]
(
	@Id		INT
)
AS
BEGIN
	DELETE FROM Nodes
	WHERE Id = @Id
END
