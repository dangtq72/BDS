USE [Starts]
GO
/****** Object:  StoredProcedure [dbo].[proc_traces_log_search]    Script Date: 19/08/2015 12:03:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[proc_traces_log_search]
	@p_object nvarchar(100),
	@p_user nvarchar(100),
	@p_frmdate nvarchar(100),
	@p_todate nvarchar(100)
AS
	DECLARE @str_condition nvarchar(200)
	DECLARE @query NVARCHAR(MAX);

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    
		set @str_condition = '';

		if @p_object <> '--ALL--' 
			set @str_condition = @str_condition + '  AND UPPER(A.TRACE_OBJECT) LIKE N'+ '''%' + @p_object + '%''';


        IF @p_user <>'--ALL--' 
            set @str_condition = @str_condition + ' AND A.TRACE_USER = ''' + @p_user + '''';

 
		set @str_condition = @str_condition + ' AND A.TRACE_DATETIME >= ' + ' convert(date, ' + '''' + @p_frmdate + ''',103)' ;

		set @str_condition = @str_condition + ' AND A.TRACE_DATETIME <= ' + ' convert(date, ' + '''' + @p_todate + ''',103)' ;  

        SET @query = 'SELECT * FROM TRACES_LOG A WHERE 1=1 ' + @str_condition + ' ORDER BY TRACE_ID Desc';
        EXECUTE(@query)
END
