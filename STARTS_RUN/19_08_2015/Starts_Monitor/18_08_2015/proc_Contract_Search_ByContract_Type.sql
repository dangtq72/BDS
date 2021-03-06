USE [Starts]
GO
/****** Object:  StoredProcedure [dbo].[proc_Contract_Search_ByContract_Type]    Script Date: 18/08/2015 1:14:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[proc_Contract_Search_ByContract_Type]
	@Contract_Type varchar(3),
	@Contract_Code varchar(50),
	@Status varchar(3),
	@Payment_Status varchar(3),
	@Building varchar(3)
AS

DECLARE @str_condition nvarchar(200)
DECLARE @query NVARCHAR(MAX);

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	set @str_condition = '';

	if @Contract_Code <> 'ALL' 
		set @str_condition = @str_condition + ' AND UPPER(c.Contract_Code) LIKE N'+ '''%' + @Contract_Code + '%''';

	if @Status <> 'ALL'
		set @str_condition = @str_condition + ' AND c.Status = ' + @Status;

	if @Payment_Status <> 'ALL'
		set @str_condition = @str_condition + ' AND f.Pay_Status = ' + @Payment_Status;

	if @Contract_Type <> 'ALL'
		set @str_condition = @str_condition + ' AND c.Contract_Type = ' + @Contract_Type;
	
	if @Building <> '-1'
		set @str_condition = @str_condition + ' AND b.Building_Id = ' + @Building;

	SET @query ='select distinct c.*,al.Content as STATUS_NAME, 
	cm.Customer_Name as Object_Name, b.Building_Name,eb.Estate_Code,eb.Estate_Name  
	from  Contract c 
	left join Fees_Revenue f on f.Contract_Id = c.Contract_Id 
	left join Estate_Object eb on eb.Estate_Id = c.Estate_Id 
	left join Building b on b.Building_Id = eb.Building_Id 
	join allcode al on al.CdValue = c.Status and al.cdname = ' + '''CONTRACT' + ''' and al.CdType = ' + '''STATUS' + ''' 
	left join Customer cm on cm.Customer_Id = c.Object_Id  
	where 1 = 1 ' + @str_condition;

    EXECUTE(@query)

	print @query;
END
