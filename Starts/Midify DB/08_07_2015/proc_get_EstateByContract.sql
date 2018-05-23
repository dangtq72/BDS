CREATE PROCEDURE proc_get_EstateByContract 
	@Estate_Id int,
	@Contract_Type int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    Select * from Contract where Estate_Id = @Estate_Id and Contract_Type = @Contract_Type;
END
GO
