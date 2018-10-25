CREATE TABLE [dbo].[Users]
(
    [ID]        INT IDENTITY (1,1)    NOT NULL,
    [FirstName]    NVARCHAR(64)        NOT NULL,
    [LastName]    NVARCHAR(128)        NOT NULL,
    [PhoneNumber]        NVARCHAR(10)            NOT NULL,
	[AptNumber]		NVARCHAR(3)				NOT NULL,
	[AptName]		NVARCHAR(20)		NOT NULL,
	[checkBox]				BIT		NOT NULL,
    CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED ([ID] ASC)
);

INSERT INTO [dbo].[Users] (FirstName, LastName, DOB) VALUES
    ('Jim','Johnson', '503666012', 12, 'Blue Hedgehog', 1),
    ('Sue','Suzanne','9712180940', 24, 'Two-tailed Fox', 1),
    ('Mira','Kuzak','5037801262', 5, 'Robotnik', 1)
GO
