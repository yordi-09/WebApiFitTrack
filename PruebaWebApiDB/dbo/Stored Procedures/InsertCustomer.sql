Create procedure [dbo].[InsertCustomer]
(
    @Name varchar(50),    
    @Phone varchar(50),    
    @Email varchar(50),    
    @Notes varchar(50))
	AS    
BEGIN 
INSERT INTO [dbo].[Tab_Customer]
           ([Name]
           ,[Phone]
           ,[Email]
           ,[Notes])
     VALUES
           (@Name, @Phone,@Email,@Notes) 
END