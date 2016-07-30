CREATE PROCEDURE [ADD_HORSE]
    /*Type of this variables should be their column types*/
    @name nvarchar(MAX),
    @fatherid int,
    @motherid int,
	@sex int,
	@birthdate date,
	@description nvarchar(MAX)
AS
BEGIN
    INSERT INTO [Horses] ([Name], [FatherID], [MotherID], [Sex], [BirthDate], [Description])
           VALUES (@name, @fatherid, @motherid, @sex, @birthdate, @description)
END