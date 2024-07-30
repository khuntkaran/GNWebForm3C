CREATE TABLE STU_Students (
    StudentID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    StudentName VARCHAR(250) NOT NULL,
    EnrollmentNo VARCHAR(12) NOT NULL,
    RollNo INT NULL,
    CurrentSem INT NOT NULL,
    EmailInstitute VARCHAR(250) NULL,
    EmailPersonal VARCHAR(250) NOT NULL,
    BirthDate DATETIME NOT NULL,
    ContactNo VARCHAR(50) NOT NULL,
    Gender VARCHAR(20) NOT NULL,
    UserID INT FOREIGN KEY  REFERENCES SEC_User(UserID) NOT NULL,
    Created DATETIME DEFAULT GETDATE(),
    Modified DATETIME DEFAULT GETDATE()
);


CREATE PROCEDURE [dbo].[PR_STU_Students_SelectPage]
    @PageOffset       INT,
    @PageSize         INT,
    @TotalRecords     INT OUTPUT,
    @StudentName      NVARCHAR(250) = NULL,
    @EnrollmentNo     VARCHAR(12) = NULL,
    @CurrentSem       INT = NULL,
    @EmailInstitute   NVARCHAR(250) = NULL,
    @EmailPersonal    NVARCHAR(250) = NULL,
    @Gender           NVARCHAR(20) = NULL,
    @RollNo           INT = NULL,
    @ContactNo        NVARCHAR(50) = NULL
AS
BEGIN
    DECLARE	@StartTime	datetime
DECLARE	@EndTime	datetime
SET		@StartTime = [dbo].[GetServerDateTime]();

BEGIN TRY


    -- Calculate total records
    SELECT @TotalRecords = COUNT(1)
    FROM [dbo].[STU_Students]
    WHERE (ISNULL(@StudentName, '') = '' OR StudentName LIKE '%' + @StudentName + '%')
      AND (ISNULL(@EnrollmentNo, '') = '' OR EnrollmentNo LIKE '%' + @EnrollmentNo + '%')
      AND (ISNULL(@CurrentSem, -1) = -1 OR CurrentSem = @CurrentSem)
      AND (ISNULL(@EmailInstitute, '') = '' OR EmailInstitute LIKE '%' + @EmailInstitute + '%')
      AND (ISNULL(@EmailPersonal, '') = '' OR EmailPersonal LIKE '%' + @EmailPersonal + '%')
      AND (ISNULL(@Gender, '') = '' OR Gender = @Gender)
      AND (ISNULL(@RollNo, -1) = -1 OR RollNo = @RollNo)
      AND (ISNULL(@ContactNo, '') = '' OR ContactNo LIKE '%' + @ContactNo + '%');

    -- Select records with pagination
    SELECT 
        [dbo].[STU_Students].[StudentID],
        [dbo].[STU_Students].[StudentName],
        [dbo].[STU_Students].[EnrollmentNo],
        [dbo].[STU_Students].[RollNo],
        [dbo].[STU_Students].[CurrentSem],
        [dbo].[STU_Students].[EmailInstitute],
        [dbo].[STU_Students].[EmailPersonal],
        [dbo].[STU_Students].[BirthDate],
        [dbo].[STU_Students].[ContactNo],
        [dbo].[STU_Students].[Gender],
        [dbo].[STU_Students].[UserID],
        [dbo].[STU_Students].[Created],
        [dbo].[STU_Students].[Modified],
		[dbo].[SEC_User].[UserName]
    FROM [dbo].[STU_Students]
	INNER JOIN [dbo].[SEC_User]
	ON [dbo].[STU_Students].[UserID] = [dbo].[SEC_User].[UserID]
    WHERE (ISNULL(@StudentName, '') = '' OR StudentName LIKE '%' + @StudentName + '%')
      AND (ISNULL(@EnrollmentNo, '') = '' OR EnrollmentNo LIKE '%' + @EnrollmentNo + '%')
      AND (ISNULL(@CurrentSem, -1) = -1 OR CurrentSem = @CurrentSem)
      AND (ISNULL(@EmailInstitute, '') = '' OR EmailInstitute LIKE '%' + @EmailInstitute + '%')
      AND (ISNULL(@EmailPersonal, '') = '' OR EmailPersonal LIKE '%' + @EmailPersonal + '%')
      AND (ISNULL(@Gender, '') = '' OR Gender = @Gender)
      AND (ISNULL(@RollNo, -1) = -1 OR RollNo = @RollNo)
      AND (ISNULL(@ContactNo, '') = '' OR ContactNo LIKE '%' + @ContactNo + '%')
    ORDER BY StudentName
    OFFSET @PageOffset ROWS
    FETCH NEXT @PageSize ROWS ONLY;

	END TRY

BEGIN CATCH
;THROW

END CATCH

SET		@EndTime = [dbo].[GetServerDateTime]()
END
GO

CREATE PROCEDURE [dbo].[PR_STU_Students_SelectPK]
    @StudentID INT
AS
BEGIN
    DECLARE	@StartTime	datetime
DECLARE	@EndTime	datetime
SET		@StartTime = [dbo].[GetServerDateTime]();

BEGIN TRY


    SELECT  
        [dbo].[STU_Students].[StudentID],		
        [dbo].[STU_Students].[StudentName],
        [dbo].[STU_Students].[EnrollmentNo],
        [dbo].[STU_Students].[RollNo],
        [dbo].[STU_Students].[CurrentSem],
        [dbo].[STU_Students].[EmailInstitute],
        [dbo].[STU_Students].[EmailPersonal],
        [dbo].[STU_Students].[BirthDate],
        [dbo].[STU_Students].[ContactNo],
        [dbo].[STU_Students].[Gender],
        [dbo].[STU_Students].[UserID],
        [dbo].[STU_Students].[Created],
        [dbo].[STU_Students].[Modified]
    FROM [dbo].[STU_Students]
    WHERE StudentID = @StudentID;

	END TRY

BEGIN CATCH
;THROW

END CATCH

SET		@EndTime = [dbo].[GetServerDateTime]()
END
GO

CREATE PROCEDURE [dbo].[PR_STU_Students_Delete]
    @StudentID INT
AS
BEGIN
    DECLARE	@StartTime	datetime
DECLARE	@EndTime	datetime
SET		@StartTime = [dbo].[GetServerDateTime]();

BEGIN TRY


    

    DELETE FROM [dbo].[STU_Students]
    WHERE StudentID = @StudentID;

    
	END TRY

BEGIN CATCH
;THROW

END CATCH

SET		@EndTime = [dbo].[GetServerDateTime]()
END
GO

CREATE PROCEDURE [dbo].[PR_STU_Students_Insert]
	@StudentID		INT Output,
    @StudentName	 NVARCHAR(250),
    @EnrollmentNo	VARCHAR(12),
    @RollNo			INT ,
    @CurrentSem		INT,
    @EmailInstitute NVARCHAR(250) ,
    @EmailPersonal	NVARCHAR(250),
    @BirthDate		DATETIME,
    @ContactNo		NVARCHAR(50),
    @Gender			NVARCHAR(20),
    @UserID			INT,
    @Created		DATETIME,
    @Modified		DATETIME
AS
BEGIN
   DECLARE	@StartTime	datetime
DECLARE	@EndTime	datetime
SET		@StartTime = [dbo].[GetServerDateTime]();

BEGIN TRY


   

    INSERT INTO [dbo].[STU_Students]
    (
        StudentName,
        EnrollmentNo,
        RollNo,
        CurrentSem,
        EmailInstitute,
        EmailPersonal,
        BirthDate,
        ContactNo,
        Gender,
        UserID,
        Created,
        Modified
    )
    VALUES
    (
        @StudentName,
        @EnrollmentNo,
        @RollNo,
        @CurrentSem,
        @EmailInstitute,
        @EmailPersonal,
        @BirthDate,
        @ContactNo,
        @Gender,
        @UserID,
        @Created,
        @Modified
    );

    SET @StudentID = SCOPE_IDENTITY();

    END TRY

BEGIN CATCH
;THROW

END CATCH

SET		@EndTime = [dbo].[GetServerDateTime]()
END
GO

CREATE PROCEDURE [dbo].[PR_STU_Students_Update]
    @StudentID INT,
    @StudentName NVARCHAR(250),
    @EnrollmentNo VARCHAR(12),
    @RollNo INT,
    @CurrentSem INT,
    @EmailInstitute NVARCHAR(250),
    @EmailPersonal NVARCHAR(250),
    @BirthDate DATETIME,
    @ContactNo NVARCHAR(50),
    @Gender NVARCHAR(20),
    @UserID INT,
    @Created DATETIME,
    @Modified DATETIME
AS
BEGIN
    DECLARE	@StartTime	datetime
DECLARE	@EndTime	datetime
SET		@StartTime = [dbo].[GetServerDateTime]();

BEGIN TRY


    UPDATE [dbo].[STU_Students]
    SET
        StudentName = @StudentName,
        EnrollmentNo = @EnrollmentNo,
        RollNo = @RollNo,
        CurrentSem = @CurrentSem,
        EmailInstitute = @EmailInstitute,
        EmailPersonal = @EmailPersonal,
        BirthDate = @BirthDate,
        ContactNo = @ContactNo,
        Gender = @Gender,
        UserID = @UserID,
        Created = @Created,
        Modified = @Modified
    WHERE StudentID = @StudentID;

    END TRY

BEGIN CATCH
;THROW

END CATCH

SET		@EndTime = [dbo].[GetServerDateTime]()
END
GO

CREATE PROCEDURE [dbo].[PR_STU_Students_SelectView]
    @StudentID INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT  
        [dbo].[STU_Students].[StudentID],
        [dbo].[STU_Students].[StudentName],
        [dbo].[STU_Students].[EnrollmentNo],
        [dbo].[STU_Students].[RollNo],
        [dbo].[STU_Students].[CurrentSem],
        [dbo].[STU_Students].[EmailInstitute],
        [dbo].[STU_Students].[EmailPersonal],
        [dbo].[STU_Students].[BirthDate],
        [dbo].[STU_Students].[ContactNo],
        [dbo].[STU_Students].[Gender],
        [dbo].[STU_Students].UserID,
        [dbo].[STU_Students].Created,
        [dbo].[STU_Students].Modified,
		[dbo].[SEC_User].[UserName]
    FROM [dbo].[STU_Students]
	INNER JOIN [dbo].[SEC_User]
		ON [dbo].[STU_Students].[UserID] = [dbo].[SEC_User].[UserID]
    WHERE StudentID = @StudentID;
END
GO
