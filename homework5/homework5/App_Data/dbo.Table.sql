CREATE TABLE [dbo].[Table]
(
    [ID]        INT IDENTITY (1,1)    NOT NULL,
    [FirstName]    NVARCHAR(64)        NOT NULL,
    [LastName]    NVARCHAR(128)        NOT NULL,
    [DOB]        DateTime            NOT NULL,
    CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED ([ID] ASC)
);
