USE [Starts]
GO
/****** Object:  StoredProcedure [dbo].[proc_Estate_Object_Search]    Script Date: 07/07/2015 9:24:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[proc_Estate_Object_Search]
	@Estate_Name nvarchar(200),
	@Estate_Type varchar(3),
	@Status varchar(3)
AS

DECLARE @str_condition nvarchar(200)
DECLARE @query NVARCHAR(MAX);

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	set @str_condition = '';

	if @Estate_Name <> 'ALL' 
		set @str_condition = @str_condition + ' AND UPPER(eb.Estate_Code) LIKE N'+ '''%' + @Estate_Name + '%''';

	if @Estate_Type <> 'ALL'
		set @str_condition = @str_condition + ' AND eb.Estate_Type = ' + @Estate_Type;

	if @Status <> 'ALL'
		set @str_condition = @str_condition + ' AND eb.Status = ' + @Status;

	SET @query  = 'SELECT eb.*,al.Content as Status_Name,al1.Content as Estate_Type_Name 
	from Estate_Object eb
	join AllCode al on al.CdValue =  eb.Status and al.CdName = ' + '''ESTATE' + ''' and al.CdType = ' + '''STATUS' + ''' 
	join AllCode al1 on al1.CdValue =  eb.Estate_Type and al1.CdName = ' + '''ESTATE' + ''' and al1.CdType = ' + '''TYPE' + ''' 
	where 1 = 1 ' + @str_condition;
    EXECUTE(@query)

	print @query;
END
