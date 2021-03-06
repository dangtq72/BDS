USE [Starts]
GO
/****** Object:  StoredProcedure [dbo].[proc_Fees_Revenue_Insert]    Script Date: 20/07/2015 9:53:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[proc_Fees_Revenue_Insert]
	@Contract_Id int,
	@Object_Id int,
	@Object_Type int,
	@Currency	int,
	@Number_Payment int,
	@Pay_Date_Expected date,
	@Pay_Date date,
	@Fee_Expected numeric(18,0),
	@Fee numeric(18,0),
	@Pay_Status int,
	@Date_Of_Bill date,
	@Debit_Amount numeric(18,0),
	@Is_Extend int,
	@Fee_Vnd numeric(18,0)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	insert into Fees_Revenue(Contract_Id,Object_Id,Object_Type ,Currency,Number_Payment,Pay_Date_Expected,
		Pay_Date,Fee_Expected,Fee,Pay_Status,Date_Of_Bill,Debit_Amount,Is_Extend,Fee_Vnd)
	values (@Contract_Id,@Object_Id ,@Object_Type ,@Currency,@Number_Payment,@Pay_Date_Expected,
		@Pay_Date,@Fee_Expected,@Fee,@Pay_Status,@Date_Of_Bill,@Debit_Amount,@Is_Extend,@Fee_Vnd);
END
