USE [Starts]
GO
/****** Object:  StoredProcedure [dbo].[proc_Estate_Object_GetId]    Script Date: 30/07/2015 14:22:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[proc_Estate_Object_GetId]
	@Estate_Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT eb.*,al.Content as Status_Name,al1.Content as Estate_Type_Name ,
	--(
	--	CASE Coalesce(c.Contract_Type,c.Contract_Type,'0') 
	--	WHEN 1 THEN r.Renter_Name 
	--	when 2 then t.Tenant_Name
	--	ELSE '' end
	--) as Object_Name,
	cm.Customer_Name as Object_Name,
    Coalesce(c.Contract_Type,c.Contract_Type,'0')  as Contract_Type,
	b.Building_Code as Building_Name, b.Address

	from Estate_Object eb
	join AllCode al on al.CdValue =  eb.Status and al.CdName = 'ESTATE' and al.CdType = 'STATUS'
	join AllCode al1 on al1.CdValue =  eb.Estate_Type and al1.CdName = 'ESTATE' and al1.CdType = 'TYPE'
	join Building b on b.Building_Id = eb.Building_Id
	left join Contract c on c.Estate_Id = eb.Estate_Id
	join Customer cm on c.Object_Id= cm.Customer_Id
	where eb.Estate_Id = @Estate_Id;
END