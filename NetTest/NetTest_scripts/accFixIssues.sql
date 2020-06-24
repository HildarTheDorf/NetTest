/*

    Please run this script after accInitialise.sql

*/

/*

if exists (select * from sys.procedures where name = 'spGetAccountAsUniqueId')
Drop PROCEDURE spGetAccountAsUniqueId
Go
Create procedure spGetAccountAsUniqueId
(
	@accusername nvarchar(50)
	,@accpwd nvarchar(50) 
)
as

declare @acaAccount uniqueidentifier
select @acaAccount = acc.accId
 from tblAccount acc
where acc.accUserName=@accusername and acc.accPwd=@accpwd
select @acaAccount as acaAccount
go


if exists (select * from sys.procedures where name = 'spAccountLoginOut')
Drop PROCEDURE spAccountLoginOut
Go
CREATE PROCEDURE spAccountLoginOut
	@accid uniqueidentifier
	,@dt datetime
	,@inout varchar(10)
AS
declare @audid uniqueidentifier

set @audid = (select autId from tblAuditType where autKey=@inout)

if not @accid is null and (@inout = 'Li' or @inout='Lo')
INSERT INTO [dbo].[tblAccountAudit]
           ([acaDT]
           ,[acaAccount]
           ,[acaAuditType])
     VALUES
           (@dt
           ,@accid
           ,@audid
		   )
else
set  @accid =  (SELECT CAST(CAST(0 AS BINARY) AS UNIQUEIDENTIFIER))
select @accid as acaAccount

GO
*/
