USE [Starts]
GO
/****** Object:  StoredProcedure [dbo].[proc_Customer_Search]    Script Date: 18/08/2015 1:10:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[proc_Customer_Search]
	@Customer_Name nvarchar(200),
	@Phone nvarchar(200)
AS

DECLARE @str_condition nvarchar(200)
DECLARE @query NVARCHAR(MAX);

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	set @str_condition = '';

	if @Customer_Name <> 'ALL' 
		set @str_condition = @str_condition + ' AND UPPER(c.Customer_Name) LIKE N'+ '''%' + @Customer_Name + '%''';

	if @Phone <> 'ALL' 
		set @str_condition = @str_condition + ' AND UPPER(c.Phone) LIKE N'+ '''%' + @Phone + '%''';
	
	SET @query ='select c.*,al.Content as Customer_Type_Name from Customer c 
	left join AllCode al on al.CdName = ' + '''CUSTOMER' + ''' and al.CdType = ' + '''TYPE' + '''  and al.CdValue = c.Customer_Type
	where 1 = 1 ' + @str_condition;

    EXECUTE(@query)
	--print @query;
END
