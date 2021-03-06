USE [Starts]
GO
/****** Object:  StoredProcedure [dbo].[proc_Contract_GetBy_EstateObject]    Script Date: 20/07/2015 11:06:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[proc_Contract_GetBy_EstateObject]
	@Estate_Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select c.*,
	al.Content as STATUS_NAME,
	cm.Customer_Name as Object_Name,
	--(CASE c.Contract_Type WHEN 1 THEN r.Renter_Name ELSE t.Tenant_Name end) as Object_Name,
	al1.Content as Contract_Type_Name
	from 
	Contract c
	join allcode al on al.CdValue = c.Status and al.cdname ='CONTRACT' and al.CdType ='STATUS'
	join AllCode al1 on al1.CdValue = c.Contract_Type and al1.CdName ='CONTRACT' and al1.CdType ='TYPE'
	join Customer cm on c.Object_Id = cm.Customer_Id
	 where Estate_Id = @Estate_Id
	 order by c.Contract_Date desc;
END