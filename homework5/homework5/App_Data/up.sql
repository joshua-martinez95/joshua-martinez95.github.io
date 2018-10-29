CREATE TABLE [dbo].[Users]
(
    [ID]        INT IDENTITY (1,1)    NOT NULL,
    [FirstName]    NVARCHAR(64)        NOT NULL,
    [LastName]    NVARCHAR(128)        NOT NULL,
    [PhoneNum]        NVARCHAR(12)            NOT NULL,
	[AptNumber]		INT				NOT NULL,
	[AptName]		NVARCHAR(20)		NOT NULL,
	[Comment]		NVARCHAR(1000)		NOT NULL,
	[CheckBox]				BIT		NOT NULL,
	[TimeRequest]		DATETIME		NOT NULL,

    CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED ([ID] ASC)
);

INSERT INTO [dbo].[Users] (FirstName, LastName, PhoneNum, AptNumber, AptName, Comment, CheckBox, TimeRequest) VALUES
    ('Jim','Johnson', '503-666-0012', 12, 'Blue Hedgehog', 'fridge is leaking water', 1, '2018-10-22 09:00:00'),
    ('Sue','Suzanne','971-218-0940', 24, 'Two-tailed Fox', 'fridge is not cooling', 1, '2018-10-14 01:00:00'),
    ('Mira','Kuzak','503-780-1262', 5, 'Robotnik', 'a/c is not working', 1, '2018-10-12 09:09:00'),
	('Ken', 'Boone', '503-489-2378', 4, 'Chaos', 'Water is not running', 1, '2018-10-02 10:00:00'),
	('Tyson', 'Smith', '541-650-8989', 5, 'Mobius', 'Stairs do not work', 1, '2018-10-12 09:00:00')
GO
