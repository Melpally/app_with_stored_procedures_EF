------------ Get All ----------------

create or alter procedure udpGetAllCouriers
as
begin
  select Id, City, FirstName, LastName, BirthDate, PhoneNumber, TGUserName, ProfilePicture
  from Courier
end
-----
go
exec udpGetAllCouriers
go

------------Get by Id ---------------

create or alter procedure udpGetById @Id int
as
begin
	select Id, City, FirstName, LastName, BirthDate, PhoneNumber, TGUserName, ProfilePicture	    
	from Courier 
	where [Id] = @Id
end
-----
go
exec udpGetById 2
go

------------Insert-------------------

create or alter procedure udpInsertCourier(
  @FirstName nvarchar(200),
  @LastName nvarchar(200),
  @City nvarchar(200),
  @BirthDate date,
  @ProfilePicture varbinary(MAX),
  @TGUserName nvarchar(200),
  @PhoneNumber nvarchar(200),
  @Errors nvarchar(1000) OUT
)
as
begin
 begin try
   insert into Courier(FirstName, LastName, City, BirthDate, PhoneNumber, TGUserName, ProfilePicture)
   output inserted.Id
   values(@FirstName, @LastName, @City, @BirthDate, @PhoneNumber, @TGUserName, @ProfilePicture)

   return (0)
 end try
 begin catch
   set @Errors = ERROR_MESSAGE()
   return (1)
 end catch
end
go
------------------------------
declare @err nvarchar(1000)
declare @code int
exec @code = udpInsertCourier
  @FirstName ='test',
  @LastName  ='test',
  @City  ='test',
  @BirthDate  ='2011-05-05',
  @PhoneNumber = 'test',
  @ProfilePicture = null,
  @TGUserName = 'test',
  @Errors = @err OUT
print concat('code=', @code,', errors=', @err) 


-------update
go
create or alter procedure dbo.udpUpdateCourier(
	 @Id int
	,@LastName nvarchar(200) 
    ,@FirstName nvarchar(200)                          
    ,@City nvarchar(200)
	,@PhoneNumber nvarchar(200)
    ,@BirthDate datetime
	,@Errors varchar(1000) OUT)
as
begin
  begin try
	update courier set
		[LastName]  = @LastName
		,[FirstName] = @FirstName
		,[City] = @City
		,[BirthDate] = @BirthDate 
		,[PhoneNumber] = @PhoneNumber
	where Id = @Id

	set @Errors = null
  end try
  begin catch
    set @Errors = ERROR_MESSAGE()
    return (1)
  end catch

  return(0)
end
go
------delete-----

create or alter procedure udpDelete @Id int
as
begin 
	delete from Courier
	where Id = @Id

end
go 
------
exec udpDelete 7


--------------- Filter ---------------------------------
go
create or alter procedure udpFilterData(
  @Street nvarchar(200),
  @CreationDate datetime,
  @Price real,
  @SortField nvarchar(200) = 'Price',
  @SortDesc bit = 0,
  @Page int = 1,
  @PageSize int = 4
)
as
begin
  set nocount on 
  declare @SortDir nvarchar(10) = ' ASC '
  if @SortDesc = 1
    set @SortDir = ' DESC '

  declare @paramsDef nvarchar(2000) = '@Street nvarchar(200), @Price real,
										@CreationDate datetime, @PageSize int, @Page int '
  declare @sql nvarchar(2000) = 'select courier.FirstName, courier.PhoneNumber, address.Street, address.HomeNumber, orders.CreationDate, orders.Price
					 ,count(*) over () TotalRows
					from Courier as courier
					join [Order] as orders on courier.Id = orders.CourierId
					join Client as client on orders.ClientId = client.Id
					join ClientAddress as address on client.Id = address.ClientId
					where address.Street like concat(@Street, ''%'')
					  and orders.Price >= @Price
					  and orders.CreationDate >= coalesce(@CreationDate, ''1900-01-01'')
					order by '+ @SortField + @SortDir +'
					offset @PageSize * (@Page-1)  rows
					fetch next @PageSize rows only'

   exec sp_executesql @sql, @paramsDef
						, @Street = @Street
						, @CreationDate = @CreationDate
						, @Price = @Price
						, @PageSize = @PageSize
						, @Page = @Page
end

--test
 exec udpFilterData
  @Street = null,
  @CreationDate = null,
  @Price = 0,
  @SortField = 'Price',
  @SortDesc = 0,
  @Page = 1,
  @PageSize = 2

-------export_Json--------------------

go
create or alter procedure udpExportToJson(
  @Street nvarchar(200) = null,
  @Price real = 0.0, 
  @CreationDate datetime = null
) as
begin
	declare @tab as table (
	  FirstName nvarchar(200),
	  PhoneNumber nvarchar(200),
	  Street nvarchar(200), 
	  HomeNumber nvarchar(200),
	  CreationDate datetime,
	  Price real, 	  
	  TotalRows int
	)

	insert into @tab
	 exec udpFilterData
	  @Street = @Street,
	  @CreationDate = @CreationDate,
	  @Price = @Price,
	  @SortField = 'FirstName',
	  @SortDesc = 0,
	  @Page = 1,
	  @PageSize = 2000000

	select * from @tab
	for json path
end

--test
exec udpExportToJson

----------export_xml--------
go
create or alter procedure udpExportToXml(
   @Street nvarchar(200) = null,
   @Price real = 0.0, 
   @CreationDate datetime = null,
   @Results nvarchar(2000) OUT
) as
begin
	declare @tab as table (
	   FirstName nvarchar(200),
	   PhoneNumber nvarchar(200),
	   Street nvarchar(200), 
	   HomeNumber nvarchar(200),
	   CreationDate datetime,
	   Price real, 	  
	   TotalRows int
	)

	insert into @tab
	 exec udpFilterData
	  @Street = @Street,
	  @Price = @Price,
	  @CreationDate = @CreationDate,
	  @SortField = 'FirstName',
	  @SortDesc = 0,
	  @Page = 1,
	  @PageSize = 2000000

	set @Results = (select * from @tab
	                for xml path('DataRow'), root('FilterData'))
end
--test
declare @r nvarchar(2000)
exec udpExportToXml @Results = @r OUT
print @r

-------import--------

