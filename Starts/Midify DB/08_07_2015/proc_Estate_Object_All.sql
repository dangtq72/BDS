USE [Starts]
GO
/****** Object:  StoredProcedure [dbo].[proc_Estate_Object_All]    Script Date: 29/06/2015 11:07:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[proc_Estate_Object_All]
	 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	--SELECT eb.*,al.Content as Status_Name,al1.Content as Estate_Type_Name ,
	--(
	--	CASE Coalesce(c.Contract_Type,c.Contract_Type,'0') 
	--	WHEN 1 THEN r.Renter_Name 
	--	when 2 then t.Tenant_Name
	--	ELSE '' end
	--) as Object_Name,
 --   Coalesce(c.Contract_Type,c.Contract_Type,'0')  as Contract_Type

	--from Estate_Object eb
	--join AllCode al on al.CdValue =  eb.Status and al.CdName = 'ESTATE' and al.CdType = 'STATUS'
	--join AllCode al1 on al1.CdValue =  eb.Estate_Type and al1.CdName = 'ESTATE' and al1.CdType = 'TYPE'
	--left join Contract c on c.Estate_Id = eb.Estate_Id
	--left join Renter r on r.Renter_Id = c.Object_Id and c.Contract_Type = 1
	--left join Tenant t on t.Tenant_Id = c.Object_Id and c.Contract_Type = 2;

	SELECT eb.*,al.Content as Status_Name,al1.Content as Estate_Type_Name, b.Building_Code as Building_Name
	from Estate_Object eb
	join AllCode al on al.CdValue =  eb.Status and al.CdName = 'ESTATE' and al.CdType = 'STATUS'
	join AllCode al1 on al1.CdValue =  eb.Estate_Type and al1.CdName = 'ESTATE' and al1.CdType = 'TYPE'
	join Building b on b.Building_Id = eb.Building_Id;
END
