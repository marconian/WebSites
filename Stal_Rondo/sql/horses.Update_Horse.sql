CREATE PROCEDURE [dbo].[UPDATE_HORSE]
    /*Type of this variables should be their column types*/
    @id int,
	@name nvarchar(MAX),
    @fatherid int,
    @motherid int,
	@sex int,
	@birthdate date,
	@description nvarchar(MAX)
AS
BEGIN
    UPDATE [horses] 
	SET [Name]=@name,[FatherID]=@fatherid,[MotherID]=@motherid,[Sex]=@sex,[BirthDate]=@birthdate,[Description]=@description 
	WHERE [HorseID]=@id
END