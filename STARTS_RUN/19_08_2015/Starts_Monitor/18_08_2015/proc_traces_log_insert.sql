USE [Starts]
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE proc_traces_log_insert 
	@TRACE_OBJECT nvarchar(100),
	@TRACE_PROCEDURE nvarchar(100),
	@TRACE_VALUE nvarchar(max),
	@TRACE_USER nvarchar(50),
	@TRACE_DATETIME date
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	insert into Traces_Log(TRACE_OBJECT,TRACE_PROCEDURE,TRACE_VALUE,TRACE_USER,TRACE_DATETIME)
	values (@TRACE_OBJECT,@TRACE_PROCEDURE,@TRACE_VALUE,@TRACE_USER,@TRACE_DATETIME)
END
GO
