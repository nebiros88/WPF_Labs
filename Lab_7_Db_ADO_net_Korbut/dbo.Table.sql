CREATE TABLE [dbo].[Table]
(
	[Energy_provider_Id] INT NOT NULL PRIMARY KEY, 
    [Company_name] NVARCHAR(50) NOT NULL, 
    [Number_of_staff] INT NOT NULL, 
    [Payroll] DECIMAL(2) NOT NULL, 
    [Taxx_free_id] INT NULL
)
