USE [Starts]
GO
/****** Object:  StoredProcedure [dbo].[proc_Report_Fee]    Script Date: 20/07/2015 10:57:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[proc_Report_Fee] 
	@FromDate nvarchar(100),
	@ToDate nvarchar(100),
	@Created_By nvarchar(50),
	@Estate_Code nvarchar(50),
	@Users nvarchar(200),
	@Customer_Name nvarchar(200)
AS

DECLARE @str_condition nvarchar(200)
DECLARE @query NVARCHAR(MAX);

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	set @str_condition = '';
	set @str_condition = @str_condition + ' AND f.Pay_Date_Expected >= ' + ' convert(date, ' + '''' + @FromDate + ''',103)' ;
	set @str_condition = @str_condition + ' AND f.Pay_Date_Expected <= ' + ' convert(date, ' + '''' + @ToDate + ''',103)' ;

	if @Created_By <> 'ALL' 
		set @str_condition = @str_condition + ' AND UPPER(c.Created_By) LIKE N'+ '''%' + @Created_By + '%''';
	
	if @Estate_Code <> 'ALL' 
		set @str_condition = @str_condition + ' AND UPPER(eb.Estate_Code) LIKE N'+ '''%' + @Estate_Code + '%''';

	if @Customer_Name <> 'ALL' 
		set @str_condition = @str_condition + ' AND UPPER(cm.Customer_Name) LIKE N'+ '''%' + @Customer_Name + '%''';

	if @Users <> 'ALL' 
		set @str_condition = @str_condition + ' AND UPPER(c.Users) LIKE N'+ '''%' + @Users + '%''';

    SET @query ='select distinct eb.Estate_Name,eb.Estate_Code,c.Contract_FromDate,c.Contract_ToDate_Ex as Contract_ToDate,c.Currency,c.Fee as PhiMoiGio, f.Pay_Date_Expected as HanChuyenTien, 
	f.Fee as TienDaVe,f.Debit_Amount as TienChuaVe, 
	c.Users  as Users,cm.Customer_Name as Customer_Name,
	c.Contract_Id,c.Estate_Id,c.Object_Id,c.Representive,
	c.Contract_FromDate,c.Contract_ToDate_Ex,c.Price,c.Contract_Type,f.Fee_Expected,f.Number_Payment,c.term,f.Fee_Vnd  
	from Fees_Revenue f 
	join Contract c on f.Contract_Id = c.Contract_Id 
	join Estate_Object eb on eb.Estate_Id = c.Estate_Id 
	join Customer cm on cm.Customer_Id = c.Object_Id  
	where 1 = 1 ' + @str_condition;

    EXECUTE(@query)

	print @query;
END
