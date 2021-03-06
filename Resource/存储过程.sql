
---1
create procedure [dbo].[InsertKeUserTwo]
@UserID char(11)
as
insert KeUser
values(@UserID,null)
GO

---2
create procedure [dbo].[InsertKeUser]
@UserID char(11),
@Photo image
as
insert [dbo].[KeUser]
values(@UserID,@Photo)
GO


---3
create procedure [dbo].[GetKeUserByUserID]
@UserID char(11)
as
select * from KeUser
where UserId=@UserID
GO


---4
CREATE procedure [dbo].[UserLogin]
@UserID char(11),@PassWord varchar(20)
as
select COUNT(*) from TBL_User
where UserID=@UserID and Password=@PassWord
GO


---5
create procedure [dbo].[GetUserInfoByID]
@UserID char(11)
as
select * from TBL_User
where UserID=@UserID
GO



---6
CREATE procedure [dbo].[AdminLogin]
@AdminID char(10) ,
@Password binary(20)
as
select COUNT(*) as 总数 
from TBL_AdminInfo
where AdminID=@AdminID and PassWord=@Password
GO



---7
CREATE procedure [dbo].[ChangeAdminPassword]	
@AdminID char(10) ,
@Password binary(20)
as
update TBL_AdminInfo
set PassWord=@Password
where AdminID=@AdminID
GO


---8
CREATE procedure [dbo].[GetAdminInfoByID]
@AdminID char(10)
as
select AdminName 
from TBL_AdminInfo
where AdminID=@AdminID
GO


---9
create procedure [dbo].[GetAllBookClass]
as
select * from TBL_BookClass
GO


---10
CREATE procedure [dbo].[InsertNewAdmin]
@AdminID char(10),
@AdminName nvarchar(30),
@PassWord binary(20),
@Email nvarchar(40)
as
insert TBL_AdminInfo
values(@AdminID,@AdminName,@Password,@Email)
GO


---11
CREATE procedure [dbo].[InsertNewUser]
@UserID char(11),
@UserName nvarchar(20),
@Sex bit,
@Password varchar(20),
@Email varchar(50),
@Class nvarchar(40)
as
insert TBL_User
values(@UserID,@UserName,@Sex,@Password,@Email,@Class,null)
GO


---12
CREATE procedure [dbo].[InsertNewBook]
@BookID char(15),
@ISBN char(20),
@BookName nvarchar(100),
@Author nvarchar(50),
@PublishDate datetime,
@BookVersion nvarchar(40),
@WordCount int,
@PageCount smallint,
@Publisher nvarchar(40),
@ClassID char(10)
as
insert TBL_BookInfo
values(@BookID,@ISBN,@BookName,@Author,@PublishDate,@BookVersion,@WordCount,@PageCount,@PublishDate,@ClassID)
GO



---13
CREATE procedure [dbo].[GetBookStatisticInfo]
as
select ISBN,BookName,COUNT(*) as 总数,Publisher  
from TBL_BookInfo
group by ISBN,BookName,Publisher
GO


---14
CREATE procedure [dbo].[GetBookInfoByCondition]
@ISBN char(20),
@BookName nvarchar(100),
@Author nvarchar(50),
@ClassID char(10)
as
select a.*,b.ClassName from TBL_BookInfo as a inner join TBL_BookClass as b on a.ClassID=b.ClassID
where ISBN= case @ISBN when '' then ISBN else @ISBN end and a.BookName like '%'+@BookName+'%' 
      and Author= case @Author when '' then Author else @Author end
      and a.ClassID=case @ClassID when '' then a.ClassID else @ClassID end
GO


---15
create procedure [dbo].[GetBookInfoByBookID]	
@BookID char(15)
as
select a.*,b.ClassName from TBL_BookInfo as a inner join TBL_BookClass as b on a.ClassID=b.ClassID
where BookID=@BookID
GO


---16
create procedure [dbo].[GetAllBook]
as
select * from TBL_BookInfo
GO


---17
create procedure  [dbo].[DeleteBook]
@BookID char(15)
as
delete TBL_BookInfo
where BookID=@BookID
GO



---18
CREATE procedure [dbo].[HasThisBook]
@BookID char(15)
as
select count(*) as 总数 
from TBL_BookInfo
where BookID=@BookID
GO



---19
CREATE procedure [dbo].[GtBookInfoByClassIDAndBookName]
@ClassID char(10),
@BookName nvarchar(100)
as
select a.*,b.ClassName from TBL_BookInfo as a inner join TBL_BookClass as b on a.ClassID=b.ClassID
where a.ClassID= case @ClassID when '' then a.ClassID else @ClassID end  
      and a.BookName like '%'+@BookName+'%'
GO


---20
CREATE procedure [dbo].[UpdateBookInfo]
@BookID char(15),
@ISBN char(20),
@BookName nvarchar(100),
@Author nvarchar(50),
@PublishDate datetime,
@BookVersion nvarchar(40),
@WordCount int,
@PageCount smallint,
@Publisher nvarchar(40),
@ClassID char(10)
as
update TBL_BookInfo
set ISBN=@ISBN,
    BookName=@BookName,
    Author=@Author,
    PublishDate=@PublishDate,
    BookVersion=@BookVersion,
    WordCount=@WordCount,
    PageCount=@PageCount,
    Publisher=@PublishDate,
    ClassID=@ClassID
where BookID= @BookID
GO



---21
create procedure [dbo].[TheMostPopularBook]
as 
select * from TBL_BookInfo
where BookID in (select top 1 with ties BookID from TBL_BorrowInfo group by BookID order by COUNT(*) desc)
GO


---22
CREATE procedure [dbo].[GetBorrowInfoByUserID]
@UserID char(11)
as
select a.*,b.*,c.* from TBL_User as a inner join TBL_BorrowInfo as b on a.UserID=b.UserID
                                      inner join TBL_BookInfo as c on b.BookID=c.BookID
where a.UserID=@UserID and b.IsReturned=0
order  by IsReturned asc,ReturnDate desc
GO



---23
CREATE procedure [dbo].[GetBorrowInfoByBookID]
@BookID char(15)
as
select a.*,b.*,c.* from TBL_User as a inner join TBL_BorrowInfo as b on a.UserID=b.UserID
                                      inner join TBL_BookInfo as c on b.BookID=c.BookID
where c.BookID=@BookID
order  by IsReturned asc
GO



---24
CREATE procedure [dbo].[BorrowBook]
@BookID char(15),
@UserID char(11)
as
insert TBL_BorrowInfo
values(@BookID,@UserID,getdate(),NULL,0)
GO



---25
CREATE procedure [dbo].[ReadingStar]
as
select * from TBL_User
where UserID in (select  top 1 with ties UserID from TBL_BorrowInfo group by UserID order by COUNT(*) desc)
GO



---26
CREATE procedure [dbo].[IsBorrowed]
@BookID char(15)
as
select top 1 IsReturned
from TBL_BorrowInfo
where BookID=@BookID
order by BorrowwID desc
GO



---27
create procedure [dbo].[ReturnBook]
@BookID char(15)
as
update TBL_BorrowInfo
set IsReturned=1,ReturnDate=getdate()
where BookID=@BookID and IsReturned=0
GO



---28
CREATE procedure [dbo].[ReborrowBook]
@BookID char(15)
as
declare @userid char(11)
select @userid=UserID 
from TBL_BorrowInfo
where BookID=@BookID and IsReturned=0
if @userid is not null
begin
exec ReturnBook @BookID
exec BorrowBook @BookID,@userid
end
GO
