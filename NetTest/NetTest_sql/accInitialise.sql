
/*
use master
go

if exists (select * from master.dbo.sysdatabases where name='nettest_db')
drop database nettest_db
go
*/
use master
go

if not exists (select * from master.dbo.sysdatabases where name='nettest_db')
create database nettest_db ON (
NAME='nettest_db', 
  FILENAME='C:\Dev\NetTest\NetTest\NetTest\NetTest\NetTest_sql\nettest_db.mdf' -- Please adjust this to suit your environment
  )
go


use nettest_db
go
declare @db_name nvarchar(100) 
declare @physical_name nvarchar(200)
set @db_name = (select db_name())
set @physical_name=(select physical_name from sys.master_files where physical_name like '%'+@db_name+'.mdf%')
print N'Database mdf:' + @physical_name
go

begin transaction

-----------------------------------------------------------------------------------------
-- Schema


if exists (select * from sys.tables where name='tblSettings')
DROP TABLE [dbo].[tblSettings]
GO

CREATE TABLE [dbo].[tblSettings](
	[setKey] [nvarchar](50) NOT NULL,
	[setValue] [nvarchar](50) NOT NULL,
	[setDescription] [nvarchar](200) NULL,
 CONSTRAINT [PK_tblSettings] PRIMARY KEY CLUSTERED 
(
	[setKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO



if exists (select * from sys.tables where name='tblAccount')
Drop TABLE [dbo].[tblAccount]
Go

if not exists (select * from sys.tables where name='tblAccount')
CREATE TABLE [dbo].[tblAccount](
	[accId] [uniqueidentifier] Not NULL,
	[accFirstName] [nvarchar](50) Not NULL,
	[accLastName] [nvarchar](50) Not NULL,
	[accUserName] [nvarchar](50) Not NULL,
	[accPwd] [nvarchar](50) Not NULL
) ON [PRIMARY]
GO

if  exists (select * from sys.tables where name='tblAccountRole')
Drop TABLE [dbo].[tblAccountRole]
Go

if not exists (select * from sys.tables where name='tblAccountRole')
CREATE TABLE [dbo].[tblAccountRole](
	[roleId] [uniqueidentifier] NOT NULL,
	[roleName] [nvarchar](50) NOT NULL,
	[roleKey] [varchar](20) NOT NULL,
 CONSTRAINT [PK_tblAccountRole] PRIMARY KEY CLUSTERED 
(
	[roleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

if  exists (select * from sys.tables where name='tblAccountRoleIndex')
Drop TABLE [dbo].[tblAccountRoleIndex]
Go

if not exists (select * from sys.tables where name='tblAccountRoleIndex')
CREATE TABLE [dbo].[tblAccountRoleIndex](
	[atiId] [int] identity (1,1) NOT NULL,
	[atiAccount] [uniqueidentifier] NOT NULL,
	[atiAccountRole] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_tblAccountRoleIndex] PRIMARY KEY CLUSTERED 
(
	[atiId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

if exists (select * from sys.objects where name='tblAccountAudit')
Drop TABLE [dbo].[tblAccountAudit]
Go

if not exists (select * from sys.objects where name='tblAccountAudit')
CREATE TABLE [dbo].[tblAccountAudit](
	[autId] [uniqueidentifier] NOT NULL,
	[autName] [nvarchar](50) NOT NULL,
	[autKey] [varchar](20) NOT NULL
) ON [PRIMARY]
GO


if exists (select * from sys.objects where name='tblAccountAuditIndex')
Drop TABLE [dbo].[tblAccountAuditIndex]
Go

if not exists (select * from sys.objects where name='tblAccountAuditIndex')
CREATE TABLE [dbo].[tblAccountAuditIndex](
	[acaId] [int] identity (1,1) NOT NULL,
	[acaDT] [datetime] NOT NULL,
	[acaAccount] [uniqueidentifier] NOT NULL,
	[acaAuditType] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_tblAccountAudit] PRIMARY KEY CLUSTERED 
(
	[acaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


if exists (select * from sys.objects where name='tblCashCategory')
Drop TABLE [dbo].[tblCashCategory]
Go

if not exists (select * from sys.objects where name='tblCashCategory')
CREATE TABLE [dbo].[tblCashCategory](
	[pccId] [uniqueidentifier] NOT NULL,
	[pccName] [nvarchar](50) NOT NULL,
	[pccKey] [varchar](20) NOT NULL,
 CONSTRAINT [PK_tblCashCategory] PRIMARY KEY CLUSTERED 
(
	[pccId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

if exists (select * from sys.tables where name='tblCashAudit')
Drop TABLE [dbo].[tblCashAudit]
Go

if not exists (select * from sys.tables where name='tblCashAudit')
CREATE TABLE [dbo].[tblCashAudit](
	[pcaId] [int] IDENTITY(1,1) NOT NULL,
	[pcaDT] [datetime] NOT NULL,
	[pcaAccount] [uniqueidentifier] NOT NULL,
	[pcaAuditType] [uniqueidentifier] NOT NULL,
	[pcaCategory] [uniqueidentifier] NOT NULL,
	[pcaAmount] [float] NOT NULL
 CONSTRAINT [PK_tblCashAudit] PRIMARY KEY CLUSTERED 
(
	[pcaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
-----------------------------------------------------------------------------------------
-- Stored Procedures

if exists (select * from sys.procedures where name = 'spAccountLogInOut')
Drop PROCEDURE spAccountLogInOut
Go
Create Procedure spAccountLogInOut
(
	@accUserName nvarchar(50)
	,@accPwd nvarchar(50)
	,@autKeyValue varchar(20)
)
as
declare @autKey varchar(20)
declare @autId uniqueidentifier
declare @accId uniqueidentifier
declare @acaId int
declare @accPwdThis nvarchar(50)
declare @accUserNameThis nvarchar(50)
select top(1) @accUserNameThis=acc.accUserName, @accPwdThis=acc.accPwd, @acaId=aai.acaId, @accId=acc.accId, @autKey=autKey, @autId=autId from tblAccount acc
 left join tblAccountAuditIndex aai on acc.accId=aai.acaAccount left join tblAccountAudit aa on aai.acaAuditType=aa.autId
 order by aai.acaDT desc
 if @accUserName=@accUserNameThis and len(''+@accUserNameThis)>0 and @autKey=@autKeyValue and (@accPwd=@accPwdThis or @autKeyValue <> 'AAT_Login')
 update tblAccountAuditIndex set acaDT=getdate() where acaId=@acaId
 else
 begin
 set @autId = (select autId from tblAccountAudit where autKey=@autKeyValue)
 insert tblAccountAuditIndex (acaDT, acaAuditType, acaAccount) values (getdate(), @autId, @accId)
 set @acaId = SCOPE_IDENTITY()
 end
 select top (1) acc.accId, acc.accFirstName,acc.accLastName, acc.accUserName, '' as accPwd, aa.acaDT, aut.autKey from tblAccount acc
  left join tblAccountAuditIndex aa on aa.acaAccount=acc.accId
  left join tblAccountAudit aut on aa.acaAccount=acc.accId
  where aa.acaId=@acaId
 Go

 if exists (select * from sys.procedures where name = 'spAccountLogin')
Drop PROCEDURE spAccountLogin
Go
Create Procedure spAccountLogin
(
	@accUserName nvarchar(50)
	,@accPwd nvarchar(50)
)
as
	exec spAccountLogInOut @accUserName, @accPwd, 'AAT_Login'
 Go

if exists (select * from sys.procedures where name = 'spAccountLogout')
Drop PROCEDURE spAccountLogout
Go
Create Procedure spAccountLogout
(
	@accUserName nvarchar(50)
)
as
	exec spAccountLogInOut @accUserName, '', 'AAT_Logout'
GO

if exists (select * from sys.procedures where name = 'spAccountReadListByUserName')
drop procedure spAccountReadListByUserName
go
create procedure spAccountReadListByUserName
(
	@accUserName nvarchar(50)
)
as
 select acc.accId, acc.accFirstName,acc.accLastName, acc.accUserName, '' as accPwd, aa.acaDT, aut.autKey from tblAccount acc
  left join tblAccountAuditIndex aa on aa.acaAccount=acc.accId
  left join tblAccountAudit aut on aa.acaAccount=acc.accId
  where acc.accUserName=@accUserName
  order by aa.acaDT desc
 Go

if exists (select * from sys.procedures where name = 'spAccountRead')
drop procedure spAccountRead
go
create procedure spAccountRead
as
declare @accUserName nvarchar(50)
declare @accPwd nvarchar(50)
declare @acaAccount uniqueidentifier
declare @autKey varchar(20)
declare @acaDT datetime
declare @logintime int
set @logintime = 5
select @logintime = convert(int,s.setValue) from tblSettings s where s.setKey='LoginTime'
set @acaDT = GETDATE()
select top (1) @accuserName=acc.accUserName, @accPwd=acc.accPwd, @acaAccount=aa.acaAccount, @autkey=aut.autkey,@acaDT=aa.acaDT from tblAccount acc
 inner join tblAccountAuditIndex aa on acc.accId=aa.acaAccount
 inner join tblAccountAudit aut on aa.acaAuditType=aut.autId
 order by aa.acaDT desc
if @autkey = 'AAT_Login'
begin
if datediff(minute,  @acaDT, getDate()) >= @logintime
exec spAccountLogout @accUserName
else
exec  spAccountLogin @accUserName, @accPwd
end
 select top(1) acc.accId, acc.accFirstName,acc.accLastName, acc.accUserName, '' as accPwd, aa.acaDT, aut.autKey from tblAccount acc
  left join tblAccountAuditIndex aa on aa.acaAccount=acc.accId
  left join tblAccountAudit aut on aa.acaAuditType=aut.autId
  where acc.accUserName=@accUserName and @autKey='AAT_Login'
  order by aa.acaDT desc 
go



if exists (select * from sys.procedures where name = 'spAccountAndRoleListByUserName')
Drop PROCEDURE [dbo].[spAccountAndRoleListByUserName]
Go
CREATE PROCEDURE spAccountAndRoleListByUserName 
	@accUserName nvarchar(50)
AS
	select acc.accFirstName, acc.accLastName, acc.accUserName, '' as accPwd, r.roleKey, r.roleName
	 from tblAccount acc
	 inner join tblAccountRoleIndex ri on acc.accId=ri.atiAccount
	 inner join tblAccountRole r on r.roleId=ri.atiAccountRole

	where acc.accUserName = @accUserName
GO

if exists (select * from sys.procedures where name = 'spCashCategoryList')
Drop PROCEDURE [dbo].[spCashCategoryList]
Go
CREATE PROCEDURE spCashCategoryList 
AS
select pcc.pccKey, pcc.pccName from tblCashCategory pcc where pcc.pccKey != 'PCC_Nothing' order by pccName asc
GO


if exists (select * from sys.procedures where name = 'spCashReadList')
Drop PROCEDURE [dbo].[spCashReadList]
Go
Create PROCEDURE [dbo].[spCashReadList] 
AS
select
 pcaTotal
,pcaDT
,pcaAmount
,pccKey
,case when pccKey='AAT_CashSpent' then 'what was spent'
when pccKey='AAT_CashAdded' then 'cash added'
else 'unknown transaction' end as pccName
,'who ' as accFirstName
,'spent/added cash' as accLastName
,'who spent/added cash' as accUserName
,pcaId
from tblAccount acc
inner join
(
select top(100) sum(ca.pcaAmount) as pcaTotal,cdt.pcaId, cdt.pcaAmount,cdt.pcaDT,cdt.pcaAccount,cdt.pcaCategory from tblCashAudit ca
inner join
(select pcaDT,pcaAmount,pcaId,pcaAccount,pcaCategory from tblCashAudit) cdt
on ca.pcaDT<=cdt.pcaDT
group by cdt.pcaDT,cdt.pcaAmount,cdt.pcaId,cdt.pcaAccount,cdt.pcaCategory
order by cdt.pcaDT desc
) sub
on sub.pcaAccount=acc.accId
inner join tblCashCategory pcc
on pcc.pccId=sub.pcaCategory
Go


if exists (select * from sys.procedures where name = 'spCashUpdate')
Drop PROCEDURE [dbo].[spCashUpdate]
Go
Create PROCEDURE [dbo].[spCashUpdate] 
	@username nvarchar(50)
	,@key varchar (20)
	,@cash float
	,@addspend varchar(20)
	,@dt datetime
AS
declare @accId uniqueidentifier
declare @audId uniqueidentifier
declare @catId uniqueidentifier

declare @pcaId int
declare @cashAmount float
set @accId = (select top(1) acc.accId from tblAccount acc where acc.accUserName=@username)
set @audId = (select top (1) autId from tblAccountAudit where autKey=@addspend)
set @catId = (select pcc.pccId from tblCashCategory pcc where pcc.pccKey = @key)

set @cashAmount = @cash
if @addspend = 'AAT_CashAdded'
set @cashAmount = @cash
if @addspend = 'AAT_CashSpent'
set @cashAmount = -@cash

if  (@addspend='AAT_CashAdded' or @addspend='AAT_CashSpent') and not @accId is null
INSERT INTO [dbo].[tblCashAudit]
           ([pcaDT]
           ,[pcaAccount]
           ,[pcaAuditType]
           ,[pcaCategory]
           ,[pcaAmount]
           )
     VALUES
           (@dt
           ,@accId
           ,@audId
		   ,@catid
		  ,@cashAmount
		  )
set @pcaId = scope_identity()
select
 pcaTotal
,pcaDT
,pcaAmount
,pccKey
,case when pccKey='AAT_CashSpent' then 'what was spent'
when pccKey='AAT_CashAdded' then 'cash added'
else 'unknown transaction' end as pccName
,'who ' as accFirstName
,'spent/added cash' as accLastName
,'who spent/added cash' as accUserName
,pcaId
from tblAccount acc
inner join
(
select top(100) sum(ca.pcaAmount) as pcaTotal,cdt.pcaId, cdt.pcaAmount,cdt.pcaDT,cdt.pcaAccount,cdt.pcaCategory from tblCashAudit ca
inner join
(select pcaDT,pcaAmount,pcaId,pcaAccount,pcaCategory from tblCashAudit) cdt
on ca.pcaDT<=cdt.pcaDT
group by cdt.pcaDT,cdt.pcaAmount,cdt.pcaId,cdt.pcaAccount,cdt.pcaCategory
order by cdt.pcaDT desc
) sub
on sub.pcaAccount=acc.accId
inner join tblCashCategory pcc
on pcc.pccId=sub.pcaCategory
where sub.pcaId = @pcaId

go


if exists (select * from sys.procedures where name = 'spAuditTypeReadByKey')
Drop PROCEDURE [dbo].[spAuditTypeReadByKey]
Go
Create PROCEDURE [dbo].[spAuditTypeReadByKey] 
   @autkey as nvarchar(20)
AS
select autId,autKey,autName from tblAccountAudit aut where aut.autKey = @autkey
Go


if exists (select * from sys.procedures where name = 'spAccountCreate')
Drop PROCEDURE [dbo].[spAccountCreate]
Go
Create PROCEDURE [dbo].[spAccountCreate]
(
     @accFirstName nvarchar(50)
    ,@accLastName nvarchar(50)
	,@accUserName nvarchar(50)
	,@accPwd  nvarchar(50)

)
as
declare @accId as uniqueidentifier
set @accId = NEWID()
if not exists (select * from tblAccount where accId=@accId and accUserName=@accUserName)
INSERT INTO [dbo].[tblAccount]
           ([accId]
           ,[accFirstName]
           ,[accLastName]
		   ,[accUserName]
		   ,[accPwd]
		   )
     VALUES
           (@accId
           ,@accFirstName
           ,@accLastName
		   ,@accUserName
		   ,@accPwd
		   )
select acc.accFirstName,accLastName, acc.accUserName from tblAccount acc where accUserName=@accUserName
go

if exists (select * from sys.procedures where name = 'spAccountRoleAdd')
Drop PROCEDURE [dbo].[spAccountRoleAdd]
Go
Create PROCEDURE [dbo].[spAccountRoleAdd]
(
	@accUserName nvarchar(50)
	,@accTypeKey varchar(20)
)
as
declare @accTypeId uniqueidentifier
declare @accId uniqueidentifier

set @accTypeId = (select r.roleId from tblAccountRole r where r.roleKey= @accTypeKey)
set @accId = (select acc.accId from tblAccount acc where acc.accUserName = @accUserName)
if not @accTypeId is null and not @accid is null and not exists (select * from tblAccountRoleIndex ri inner join tblAccountRole r on ri.atiAccountRole=r.roleId where atiAccount=@accId and r.roleKey=@accTypeKey)
	insert into tblAccountRoleIndex (atiAccount, atiAccountRole) values (@accId, @accTypeid)
select acc.accUserName, r.roleKey, r.roleName from tblAccount acc inner join tblAccountRoleIndex ri on ri.atiAccount=acc.accId inner join tblAccountRole r on ri.atiAccountRole=r.roleId where atiAccount=@accId and r.roleKey=@accTypeKey
go


if exists (select * from sys.procedures where name = 'spAccountRoleCreate')
Drop PROCEDURE [dbo].[spAccountRoleCreate]
Go
Create PROCEDURE [dbo].[spAccountRoleCreate]
(
	@roleKey varchar(20)
	,@roleName nvarchar(50)
)
as
if not exists (select * from tblAccountRole where roleKey=@roleKey)
INSERT INTO [dbo].[tblAccountRole]
           ([roleId]
           ,[roleName]
           ,[roleKey])
     VALUES
           (NEWID(), @roleName, @roleKey)
go

if exists (select * from sys.procedures where name = 'spAccountAuditTypeCreate')
Drop PROCEDURE [dbo].[spAccountAuditTypeCreate]
Go
Create PROCEDURE [dbo].[spAccountAuditTypeCreate]
(
	@accAuditTypeName nvarchar(50)
	,@accAuditTypeKey varchar(20)
)
as
declare @accAuditTypeId uniqueidentifier
if not exists (select * from tblAccountAudit aa where aa.autKey=@accAuditTypeKey)
begin
set @accAuditTypeId = newid()
 if not exists (select * from tblAccountAudit where autId=@accAuditTypeId)
 insert into tblAccountAudit (autId, autName, autKey) values (@accAuditTypeId, @accAuditTypeName, @accAuditTypeKey)
 end
 select aa.autKey, aa.autName from tblAccountAudit aa where autKey=@accAuditTypeKey
 go


if exists (select * from sys.procedures where name = 'spCashCategoryCreate')
Drop PROCEDURE [dbo].[spCashCategoryCreate]
Go
Create PROCEDURE [dbo].[spCashCategoryCreate]
(
	@catName nvarchar(50)
	,@catKey varchar(30)
)
as
declare @catId as uniqueidentifier
set @catId = newid()
if not exists (select * from tblCashCategory where pccId=@catId)
 INSERT INTO [dbo].[tblCashCategory]
           ([pccId],[pccName],[pccKey]) VALUES (@catId,@catName,@catKey)

select pcc.pccKey, pcc.pccName from tblCashCategory pcc where pccKey=@catKey
go

if exists (select * from sys.procedures where name = 'spSettingsUpdate')
Drop PROCEDURE [dbo].[spSettingsUpdate]
Go
Create Procedure [dbo].[spSettingsUpdate]
(
	@key nvarchar(50)
	,@value nvarchar(50)
	,@description nvarchar(200)
)
as
if not exists (select * from tblSettings where setKey=@key)
INSERT INTO [dbo].[tblSettings]
           ([setKey]
           ,[setValue]
           ,[setDescription])
     VALUES
           (
		   @key
           ,@value
           ,@description
		   )
else
begin
if (len(''+@description)>0)
update tblSettings
	set setValue = @value,
	setDescription = @description
else
update tblSettings
	set setValue = @value
end
select * from tblSettings where setKey=@key
go


-----------------------------------------------------------------------------------------
-- Data

-- Set the default login time
exec spSettingsUpdate 'LoginTime', '5', 'The login time (in minutes)'

-- Add some account roles
exec spAccountRoleCreate 'Role_Emp', 'Employee'
exec spAccountRoleCreate 'Role_Adm', 'Admin'
exec spAccountRoleCreate 'Role_Dir', 'Director'
exec spAccountRoleCreate 'Role_Man', 'Manager'
exec spAccountRoleCreate 'Role_Risk', 'High Risk'

-- Add some accounts and attach roles
exec spAccountCreate 'John', 'Kirkstone' ,'jkirkstone' ,'apple'
exec spAccountRoleAdd 'jkirkstone', 'Role_Emp'

exec spAccountCreate 'Janet', 'Sherwood' ,'jsherwood' ,'pear'
exec spAccountRoleAdd 'jsherwood', 'Role_Emp'
exec spAccountRoleAdd 'jsherwood', 'Role_Dir'

exec spAccountCreate 'Graham', 'Norcross', 'gnorcross', 'banana'
exec spAccountRoleAdd 'gnorcross', 'Role_Emp'
exec spAccountRoleAdd 'gnorcross', 'Role_Man'

exec spAccountCreate 'Jennifer','Green','jgreen', 'orange'
exec spAccountRoleAdd 'jgreen', 'Role_Emp'
exec spAccountRoleAdd 'jgreen', 'Role_Adm'

exec spAccountCreate 'Karen' ,'Hide','khide','lemon'
exec spAccountRoleAdd 'khide', 'Role_Emp'
exec spAccountRoleAdd 'khide', 'Role_Dir'

exec spAccountCreate 'Nick' ,'Leeson','nleeson','melon'
exec spAccountRoleAdd 'nleeson', 'Role_Emp'
exec spAccountRoleAdd 'nleeson', 'Role_Risk'

-- Add some account audit types
exec spAccountAuditTypeCreate 'AAT_Login', 'AAT_Login'
exec spAccountAuditTypeCreate 'AAT_Logout', 'AAT_Logout'
exec spAccountAuditTypeCreate 'Petty Cash Added', 'AAT_CashAdded'
exec spAccountAuditTypeCreate 'Petty Cash Spent', 'AAT_CashSpent'

-- Add some cash categories
exec spCashCategoryCreate 'Tea/Coffee/Sugar/Milk','PCC_Tea'
exec spCashCategoryCreate 'Stationary','PCC_Stat'
exec spCashCategoryCreate 'Travel Expenses','PCC_Travel'
exec spCashCategoryCreate 'Cleaning','PCC_Clean'
exec spCashCategoryCreate 'Cash Added','PCC_CashAdd'

exec spCashCategoryCreate 'Nothing','PCC_Nothing'

-- Add some cash
declare @dt datetime
set @dt = dateadd(day,-7, getdate())
exec spCashUpdate 'khide', 'PCC_CashAdd', 300, 'AAT_CashAdded', @dt

set @dt = dateadd(day,-1, getdate())
exec spCashUpdate 'khide', 'PCC_CashAdd', 500, 'AAT_CashAdded', @dt

-- Spend some cash
set @dt = dateadd(day,-4, getdate())
exec spCashUpdate 'jgreen', 'PCC_Stat', 48.30, 'AAT_CashSpent', @dt
set @dt = dateadd(day,-3, getdate())
exec spCashUpdate 'gnorcross', 'PCC_Travel', 70.16, 'AAT_CashSpent', @dt
set @dt = dateadd(day,-2, getdate())
exec spCashUpdate 'nleeson', 'PCC_Clean', 96.67, 'AAT_CashSpent', @dt

-- What's the cash looking like now?
exec spCashReadList

Go

if exists (select * from master.dbo.sysdatabases where name='nettest_db')
begin
commit transaction
print 'Successful'
end
else
begin
rollback transaction
print 'Not successful - Rollback performed'
end




