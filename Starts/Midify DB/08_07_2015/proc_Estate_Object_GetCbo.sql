USE [Starts]
GO
/****** Object:  StoredProcedure [dbo].[proc_Estate_Object_GetCbo]    Script Date: 29/06/2015 11:09:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[proc_Estate_Object_GetCbo]
	@Contract_Type int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT distinct eb.*,al.Content as Status_Name,al1.Content as Estate_Type_Name,
	b.Building_Code as Building_Name, b.Address
	--(
	--	CASE Coalesce(c.Contract_Type,c.Contract_Type,'0') 
	--	WHEN 1 THEN r.Renter_Name 
	--	when 2 then t.Tenant_Name
	--	ELSE '' end
	--) as Object_Name,
 --   Coalesce(c.Contract_Type,c.Contract_Type,'0')  as Contract_Type

	from Estate_Object eb
	join AllCode al on al.CdValue =  eb.Status and al.CdName = 'ESTATE' and al.CdType = 'STATUS'
	join AllCode al1 on al1.CdValue =  eb.Estate_Type and al1.CdName = 'ESTATE' and al1.CdType = 'TYPE'
	join Building b on b.Building_Id = eb.Building_Id
	where eb.Status = 0
	and eb.Estate_Id not in (select Estate_Id from Contract where Contract_Type = @Contract_Type)
END
