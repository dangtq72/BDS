USE [Starts]
GO
/****** Object:  StoredProcedure [dbo].[proc_check_exis_customer_in_Contract]    Script Date: 18/08/2015 12:57:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[proc_check_exis_customer_in_Contract] 
	@Customer_Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    select count(*) as count_c from Contract where Object_Id = @Customer_Id
END
