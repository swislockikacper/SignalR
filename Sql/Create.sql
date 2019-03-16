DROP TABLE IF EXISTS [dbo].[Message]
GO

CREATE TABLE [dbo].[Message]
(
    [Id] INT IDENTITY PRIMARY KEY NONCLUSTERED NOT NULL,
    [UserName] NVARCHAR(200) NOT NULL,
    [Content] NVARCHAR(MAX) NOT NULL
)
GO