USE [Starts]
GO
/****** Object:  StoredProcedure [dbo].[proc_Building_Search]    Script Date: 29/06/2015 11:17:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[proc_Building_Search]
	@Building_Name nvarchar(200)
AS

DECLARE @str_condition nvarchar(200)
DECLARE @query NVARCHAR(MAX);

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	set @str_condition = '';

	if @Building_Name <> 'ALL' 
		set @str_condition = @str_condition + ' AND UPPER(b.Building_Code) LIKE N'+ '''%' + @Building_Name + '%''';
	
	SET @query ='select b.* from Building b
	where 1 = 1 ' + @str_condition;

    EXECUTE(@query)

	--print @query;
END