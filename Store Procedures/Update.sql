USE [if076_db]
GO
/****** Object:  StoredProcedure [dbo].[NodesUpdate]    Script Date: 7/12/2017 1:20:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[NodesUpdate]
(
	@Id		INT,
	@Name	VARCHAR(150)
)
AS
BEGIN
	UPDATE Nodes
	SET
		Name = @Name
	WHERE Id = @Id
END
