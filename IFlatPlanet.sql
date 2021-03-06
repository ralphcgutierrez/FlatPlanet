USE [IFlatPlanet]
GO
/****** Object:  Table [dbo].[Counter]    Script Date: 6/8/2016 12:59:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Counter](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Click] [int] NULL,
	[Save_Date] [datetime] NULL
) ON [PRIMARY]

GO
/****** Object:  StoredProcedure [dbo].[spGetClickCount]    Script Date: 6/8/2016 12:59:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetClickCount]
AS
SELECT ISNULL(SUM(Click),0)Counts FROM dbo.Counter
GO
/****** Object:  StoredProcedure [dbo].[spInsertCount]    Script Date: 6/8/2016 12:59:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spInsertCount]
	@inClick int = NULL
AS
INSERT INTO dbo.[Counter] 
		(
		Click , 
		Save_Date
		) 
VALUES (
		@inClick,
		GETDATE()
		)
GO
