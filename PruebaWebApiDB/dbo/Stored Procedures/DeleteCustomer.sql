create procedure [dbo].[DeleteCustomer]    
(    
    @Id int     
)    
As    
BEGIN    
    DELETE FROM Tab_Customer WHERE Id=@Id    
END