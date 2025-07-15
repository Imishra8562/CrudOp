CREATE TABLE [dbo].[Course]
(
	[CourseId] INT IDENTITY(1,1) PRIMARY KEY,       
    [CourseName] NVARCHAR(100) NOT NULL,            
    [Description] NVARCHAR(500) NULL,               
    [Duration] NVARCHAR(50) NULL,                   
    [Fees] DECIMAL(10, 2) NULL,                     
    [CreatedDate] DATETIME NULL 
)

