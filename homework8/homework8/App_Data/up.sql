CREATE TABLE [dbo].[Buyers] (
	[BuyerID] INT IDENTITY(1,1) NOT NULL,
	[Name] NVARCHAR(70) NOT NULL,

	CONSTRAINT[PK_dbo.Buyers] PRIMARY KEY CLUSTERED (BuyerID ASC)
);
CREATE TABLE [dbo].[Sellers] (
	[SellerID] INT IDENTITY(1,1) NOT NULL,
	[Name] NVARCHAR(70) NOT NULL,

	CONSTRAINT[PK_dbo.Sellers] PRIMARY KEY CLUSTERED (SellerID ASC)
);
CREATE TABLE [dbo].[Items] (
	[ItemID] INT IDENTITY(1001,1) NOT NULL,
	[Name] NVARCHAR(64) NOT NULL,
	[Description] NVARCHAR(500) NOT NULL,
	[SellerID] INT NOT NULL,

	CONSTRAINT[PK_dbo.Items] PRIMARY KEY CLUSTERED (ItemID ASC),
	CONSTRAINT[FK_dbo.Items] FOREIGN KEY (SellerID) REFERENCES Sellers(SellerID)
		ON DELETE CASCADE
		ON UPDATE CASCADE
);
CREATE TABLE [dbo].[Bids](
	[BidID] INT IDENTITY (1,1) NOT NULL,
	[ItemID] INT	NOT NULL,
	[BuyerID] INT NOT NULL,
	[Price] DECIMAL NOT NULL,
	[Timestamp] DATETIME NOT NULL,
	
	CONSTRAINT[PK_dbo.Bids] PRIMARY KEY CLUSTERED (BidID ASC),

	CONSTRAINT[FK1_dbo.Bids] FOREIGN KEY (ItemID) REFERENCES Items(ItemID)
		ON DELETE CASCADE
		ON UPDATE CASCADE,
	CONSTRAINT[FK2_dbo.Bids] FOREIGN KEY (BuyerID) REFERENCES Buyers(BuyerID)
		ON DELETE CASCADE
		ON UPDATE CASCADE
);

INSERT INTO [dbo].[Buyers] (Name) VALUES
	('Jane Stone'),
	('Tom McMasters'),
	('Otto Vanderwall')

INSERT INTO [dbo].[Sellers] (Name) VALUES
	('Gayle Hardy'),
	('Lyle Banks'),
	('Pearl Greene')

INSERT INTO [dbo].[Items] (Name, Description, SellerID) VALUES
	('Abraham Lincoln Hammer'    ,'A bench mallet fashioned from a broken rail-splitting maul in 1829 and owned by Abraham Lincoln', 3),
	('Albert Einsteins Telescope','A brass telescope owned by Albert Einstein in Germany, circa 1927', 1),
	('Bob Dylan Love Poems'      ,'Five versions of an original unpublished, handwritten, love poem by Bob Dylan', 2)

INSERT INTO [dbo].[Bids] (ItemID, BuyerID, Price, TimeStamp) VALUES
	(1001, 3, 250000, '12/04/2017 09:04:22'),
	(1003, 1, 95000, '12/04/2017 08:44:03')