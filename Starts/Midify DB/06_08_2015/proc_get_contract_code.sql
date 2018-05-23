 
CREATE PROCEDURE proc_get_contract_code
	 @Contract_Code varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select * from Contract where Contract_Code = @Contract_Code
END
GO
