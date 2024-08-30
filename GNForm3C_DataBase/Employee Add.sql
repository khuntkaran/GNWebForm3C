
------------------------------------new add--------------------
CREATE TABLE EMP_EmployeeType (
    EmployeeTypeID INT PRIMARY KEY IDENTITY(1,1),
    EmployeeTypeName VARCHAR(255) NOT NULL,
    Remarks TEXT,
    UserID INT FOREIGN KEY  REFERENCES SEC_User(UserID) NOT NULL,
    Created DATETIME DEFAULT GETDATE() NOT NULL,
    Modified DATETIME DEFAULT GETDATE() NOT NULL
);
GO

CREATE TABLE EMP_EmployeeDetail (
    EmployeeID INT PRIMARY KEY IDENTITY(1,1),
    EmployeeName VARCHAR(100) NOT NULL,
    EmployeeTypeID INT FOREIGN KEY REFERENCES EMP_EmployeeType(EmployeeTypeID) NOT NULL ,
    Remarks TEXT,
    UserID INT FOREIGN KEY  REFERENCES SEC_User(UserID) NOT NULL,
    Created DATETIME DEFAULT GETDATE() NOT NULL,
    Modified DATETIME DEFAULT GETDATE() NOT NULL
    
);
GO



insert into EMP_EmployeeType (EmployeeTypeName,UserID) values('Doctor',4)
insert into EMP_EmployeeType (EmployeeTypeName,UserID) values('Pune',4)
insert into EMP_EmployeeType (EmployeeTypeName,UserID) values('Nurse',4)
insert into EMP_EmployeeType (EmployeeTypeName,UserID) values('Watchman',4)

select * from EMP_EmployeeType
select * from EMP_EmployeeDetail

Create PROCEDURE [dbo].[PR_EMP_EmployeeDetail_SelectPage]

		@PageOffset   		int,
		@PageSize     		int,
		@TotalRecords 		int OUTPUT,
		@EmployeeName		nvarchar(250) null,
		@EmployeeTypeID		int null
AS

SET NOCOUNT ON;

DECLARE	@StartTime	datetime
DECLARE	@EndTime	datetime
SET		@StartTime = [dbo].[GetServerDateTime]();

BEGIN TRY

		SELECT @TotalRecords= COUNT(1) FROM [dbo].[EMP_EmployeeDetail]
		WHERE (@EmployeeName IS NULL OR [dbo].[EMP_EmployeeDetail].[EmployeeName] LIKE '%'+CAST(@EmployeeName as varchar(50)) +'%')
		AND (@EmployeeTypeID IS NULL OR [dbo].[EMP_EmployeeDetail].[EmployeeTypeID] = @EmployeeTypeID)

		SELECT  
				 
				[dbo].[EMP_EmployeeDetail].[EmployeeID],
				[dbo].[EMP_EmployeeDetail].[EmployeeName],
				[dbo].[EMP_EmployeeType].[EmployeeTypeName],
				[dbo].[EMP_EmployeeDetail].[Remarks],
				[dbo].[SEC_User].[UserName],
				[dbo].[EMP_EmployeeDetail].[Created],
				[dbo].[EMP_EmployeeDetail].[Modified],
				[dbo].[EMP_EmployeeDetail].[EmployeeTypeID],
				[dbo].[EMP_EmployeeDetail].[UserID]
		FROM  [dbo].[EMP_EmployeeDetail]
		INNER JOIN [dbo].[EMP_EmployeeType]
		ON [dbo].[EMP_EmployeeDetail].[EmployeeTypeID] = [dbo].[EMP_EmployeeType].[EmployeeTypeID]
		INNER JOIN [dbo].[SEC_User]
		ON [dbo].[EMP_EmployeeDetail].[UserID] = [dbo].[SEC_User].[UserID]

	WHERE (@EmployeeName IS NULL OR [dbo].[EMP_EmployeeDetail].[EmployeeName] LIKE '%'+CAST(@EmployeeName as varchar(50)) +'%')
		AND (@EmployeeTypeID IS NULL OR [dbo].[EMP_EmployeeDetail].[EmployeeTypeID] = @EmployeeTypeID)
		
		ORDER BY [dbo].[EMP_EmployeeDetail].[EmployeeName]
		OFFSET @PageOffset ROWS
		FETCH NEXT @PageSize ROWS ONLY


END TRY

BEGIN CATCH
;THROW

END CATCH

SET		@EndTime = [dbo].[GetServerDateTime]()
GO
-- [dbo].[PR_EMP_EmployeeDetail_SelectPage] @PageOffset = 1, @PageSize = 1, @TotalRecords = 1,@EmployeeName =null,@EmployeeTypeID=null

Create PROCEDURE [dbo].[PR_EMP_EmployeeDetail_SelectPK]

		@EmployeeID		int

AS

SET NOCOUNT ON;

DECLARE	@StartTime	datetime
DECLARE	@EndTime	datetime
SET		@StartTime = [dbo].[GetServerDateTime]();

BEGIN TRY

SELECT  
		[dbo].[EMP_EmployeeDetail].[EmployeeID],
		[dbo].[EMP_EmployeeDetail].[EmployeeName],
		[dbo].[EMP_EmployeeDetail].[EmployeeTypeID],
		[dbo].[EMP_EmployeeType].[EmployeeTypeName],
		[dbo].[EMP_EmployeeDetail].[Remarks],
		[dbo].[EMP_EmployeeDetail].[UserID],
		[dbo].[EMP_EmployeeDetail].[Created],
		[dbo].[EMP_EmployeeDetail].[Modified]
FROM  [dbo].[EMP_EmployeeDetail]
INNER JOIN			[dbo].[EMP_EmployeeType]
ON  [dbo].[EMP_EmployeeDetail].[EmployeeTypeID] = [dbo].[EMP_EmployeeType].[EmployeeTypeID]

WHERE [dbo].[EMP_EmployeeDetail].[EmployeeID] = @EmployeeID


END TRY

BEGIN CATCH
;THROW

END CATCH

SET		@EndTime = [dbo].[GetServerDateTime]()
GO
--   [dbo].[PR_EMP_EmployeeDetail_SelectPK] @EmployeeID = 3


CREATE PROCEDURE [dbo].[PR_EMP_EmployeeDetail_Delete]

		@EmployeeID 		int

AS

SET NOCOUNT ON;

DECLARE	@StartTime	datetime
DECLARE	@EndTime	datetime
SET		@StartTime = [dbo].[GetServerDateTime]();

BEGIN TRY
BEGIN TRAN

DELETE FROM [dbo].[EMP_EmployeeDetail]
WHERE [dbo].[EMP_EmployeeDetail].[EmployeeID] = @EmployeeID


COMMIT TRAN
END TRY

BEGIN CATCH
IF @@TRANCOUNT > 0
BEGIN
		ROLLBACK TRAN
		END
;THROW

END CATCH

SET		@EndTime = [dbo].[GetServerDateTime]()
GO
--   [dbo].[PR_EMP_EmployeeDetail_Delete] @EmployeeID = 2


CREATE PROCEDURE [dbo].[PR_EMP_EmployeeDetail_Insert]

		@EmployeeID 		int OUTPUT,
		@EmployeeName   	nvarchar (250),
		@EmployeeTypeID    	int,
		@Remarks       		nvarchar (500),
		@UserID        		int,
		@Created       		datetime,
		@Modified      		datetime

AS

SET NOCOUNT ON;

DECLARE	@StartTime	datetime
DECLARE	@EndTime	datetime
SET		@StartTime = [dbo].[GetServerDateTime]();

BEGIN TRY
BEGIN TRAN

INSERT [dbo].[EMP_EmployeeDetail]
(
		[EmployeeName],
		[EmployeeTypeID],
		[Remarks],
		[UserID],
		[Created],
		[Modified]
)
VALUES
(
		@EmployeeName,
		@EmployeeTypeID,
		@Remarks,
		@UserID,
		@Created,
		@Modified
)

SET @EmployeeID = SCOPE_IDENTITY()

COMMIT TRAN
END TRY

BEGIN CATCH
IF @@TRANCOUNT > 0
BEGIN
		ROLLBACK TRAN
		END
;THROW

END CATCH

SET		@EndTime = [dbo].[GetServerDateTime]()
GO
-- exec [dbo].[PR_EMP_EmployeeDetail_Insert]  @EmployeeID=null, @EmployeeName = 'Employee', @EmployeeTypeID = 1, @Remarks = 'Remarks', @UserID = 4, @Created = '2020-03-19', @Modified = '2020-03-19'


CREATE PROCEDURE [dbo].[PR_EMP_EmployeeDetail_Update]

		@EmployeeID 		int ,
		@EmployeeName   	nvarchar (250),
		@EmployeeTypeID    	int,
		@Remarks       		nvarchar (500),
		@UserID        		int,
		@Created       		datetime,
		@Modified      		datetime

AS

SET NOCOUNT ON;

DECLARE	@StartTime	datetime
DECLARE	@EndTime	datetime
SET		@StartTime = [dbo].[GetServerDateTime]();

BEGIN TRY
BEGIN TRAN

UPDATE [dbo].[EMP_EmployeeDetail]
SET
		[EmployeeName] = @EmployeeName,
		[EmployeeTypeID] = @EmployeeTypeID,
		[Remarks] = @Remarks,
		[UserID] = @UserID,
		[Created] = @Created,
		[Modified] = @Modified
WHERE [dbo].[EMP_EmployeeDetail].[EmployeeID] = @EmployeeID 

COMMIT TRAN
END TRY

BEGIN CATCH
IF @@TRANCOUNT > 0
BEGIN
		ROLLBACK TRAN
		END
;THROW

END CATCH

SET		@EndTime = [dbo].[GetServerDateTime]()
GO
--   [dbo].[PR_EMP_EmployeeDetail_Update] @EmployeeID = 3, @EmployeeName = 'EmployeeName', @EmployeeTypeID = 2, @Remarks = 'Remarks2', @UserID = 4, @Created = '2020-03-20', @Modified = '2020-03-20'


CREATE PROCEDURE [dbo].[PR_EMP_EmployeeDetail_SelectView]

		@EmployeeID 		int

AS

SET NOCOUNT ON;

DECLARE	@StartTime	datetime
DECLARE	@EndTime	datetime
SET		@StartTime = [dbo].[GetServerDateTime]();

BEGIN TRY

SELECT  
		[dbo].[EMP_EmployeeDetail].[EmployeeID],
		[dbo].[EMP_EmployeeDetail].[EmployeeName],
		[dbo].[EMP_EmployeeType].[EmployeeTypeName],
		[dbo].[EMP_EmployeeDetail].[Remarks],
		[dbo].[SEC_User].[UserName],
		[dbo].[EMP_EmployeeDetail].[Created],
		[dbo].[EMP_EmployeeDetail].[Modified],
		[dbo].[EMP_EmployeeDetail].[EmployeeTypeID],
		[dbo].[EMP_EmployeeDetail].[UserID]
FROM  [dbo].[EMP_EmployeeDetail]
INNER JOIN [dbo].[EMP_EmployeeType]
ON [dbo].[EMP_EmployeeDetail].[EmployeeTypeID] = [dbo].[EMP_EmployeeType].[EmployeeTypeID]
INNER JOIN [dbo].[SEC_User]
ON [dbo].[EMP_EmployeeDetail].[UserID] = [dbo].[SEC_User].[UserID]

WHERE [dbo].[EMP_EmployeeDetail].[EmployeeID] = @EmployeeID


END TRY

BEGIN CATCH
;THROW

END CATCH

SET		@EndTime = [dbo].[GetServerDateTime]()
GO
--   [dbo].[PR_EMP_EmployeeDetail_SelectView] @EmployeeID = 3


CREATE PROCEDURE [dbo].[PR_EMP_EmployeeDetail_SelectShow]

		@EmployeeTypeID 		int

AS

SET NOCOUNT ON;

DECLARE	@StartTime	datetime
DECLARE	@EndTime	datetime
SET		@StartTime = [dbo].[GetServerDateTime]();

BEGIN TRY

SELECT  
		[dbo].[EMP_EmployeeDetail].[EmployeeTypeID],
		[dbo].[EMP_EmployeeDetail].[EmployeeName],
		[dbo].[EMP_EmployeeDetail].[EmployeeID],
		[dbo].[EMP_EmployeeDetail].[Remarks],
		[dbo].[SEC_User].[UserName] ,
		[dbo].[EMP_EmployeeDetail].[Created],
		[dbo].[EMP_EmployeeDetail].[Modified]	
FROM  [dbo].[EMP_EmployeeDetail]
INNER JOIN [dbo].[EMP_EmployeeType]
ON [dbo].[EMP_EmployeeDetail].[EmployeeTypeID] = [dbo].[EMP_EmployeeType].[EmployeeTypeID]
INNER JOIN [dbo].[SEC_User]
ON [dbo].[EMP_EmployeeDetail].[UserID] = [dbo].[SEC_User].[UserID]
WHERE [dbo].[EMP_EmployeeType].[EmployeeTypeID] = @EmployeeTypeID
ORDER BY [dbo].[EMP_EmployeeDetail].[EmployeeName]


END TRY

BEGIN CATCH
;THROW

END CATCH

SET		@EndTime = [dbo].[GetServerDateTime]()
GO
--   [dbo].[PR_EMP_EmployeeDetail_SelectShow] @EmployeeTypeID = 3


CREATE PROCEDURE [dbo].[PR_EMP_EmployeeDetail_AddMore_SelectPK]

		@EmployeeID 		int

AS

SET NOCOUNT ON;

DECLARE	@StartTime	datetime
DECLARE	@EndTime	datetime
SET		@StartTime = [dbo].[GetServerDateTime]();

BEGIN TRY

SELECT  
		[dbo].[EMP_EmployeeDetail].[EmployeeID],
		[dbo].[EMP_EmployeeDetail].[EmployeeName],
		[dbo].[EMP_EmployeeDetail].[EmployeeTypeID],
		[dbo].[EMP_EmployeeType].[EmployeeTypeName],
		[dbo].[EMP_EmployeeDetail].[Remarks],
		[dbo].[EMP_EmployeeDetail].[UserID],
		[dbo].[EMP_EmployeeDetail].[Created],
		[dbo].[EMP_EmployeeDetail].[Modified]
FROM  [dbo].[EMP_EmployeeDetail]
INNER JOIN			[dbo].[EMP_EmployeeType]
ON  [dbo].[EMP_EmployeeDetail].[EmployeeTypeID] = [dbo].[EMP_EmployeeType].[EmployeeTypeID]

WHERE [dbo].[EMP_EmployeeDetail].[EmployeeID] = @EmployeeID


END TRY

BEGIN CATCH
;THROW

END CATCH

SET		@EndTime = [dbo].[GetServerDateTime]()
GO
-- [dbo].[PR_EMP_EmployeeDetail_AddMore_SelectPK] @EmployeeID =3


CREATE PROCEDURE [dbo].[PR_EMP_EmployeeType_SelectComboBox]

AS

SELECT [EmployeeTypeID]
      ,[EmployeeTypeName]      
  FROM [dbo].[EMP_EmployeeType]

GO

alter PROCEDURE [dbo].[PR_EMP_GetEmployeeNames]
    @PrefixText NVARCHAR(50),
    @EmployeeTypeID INT
AS
BEGIN
    SELECT EmployeeName
    FROM	EMP_EmployeeDetail
    WHERE EmployeeName LIKE '%'+ @PrefixText + '%'
      or EmployeeTypeID = @EmployeeTypeID
END
GO

-- [dbo].[PR_EMP_GetEmployeeNames] @PrefixText = 'haa' , @EmployeeTypeID =2