CREATE TABLE [horses]
(
	[HorseID] INT NOT NULL PRIMARY KEY, 
    [Name] NCHAR(10) NULL, 
    [FatherID] INT NULL, 
    [MotherID] INT NULL, 
    [Sex] INT NULL , 
    [BirthDate] DATE NULL
)
