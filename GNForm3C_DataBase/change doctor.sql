select * from SEC_User

Create PROCEDURE PR_DSB_Count
AS
BEGIN
    -- Declare variables to hold counts
    DECLARE @IncomeCount INT,
            @ExpenseCount INT,
            @HospitalCount INT,
            @FinyearCount INT;

    -- Get counts for each category
    SELECT @IncomeCount = COUNT(*) FROM ACC_Income;
    SELECT @ExpenseCount = COUNT(*) FROM ACC_Expense;
    SELECT @HospitalCount = COUNT(*) FROM MST_Hospital;
    SELECT @FinyearCount = COUNT(*) FROM MST_FinYear;

    -- Select results
    SELECT @IncomeCount AS IncomeCount,
           @ExpenseCount AS ExpenseCount,
           @HospitalCount AS HospitalCount,
           @FinyearCount AS FinyearCount;
END
GO
Create PROCEDURE [dbo].[PR_DSB_IncomeList]
AS
BEGIN
    -- Your SQL statements here
    SELECT TOP 10 
	[ACC_Income].IncomeID,
	[MST_IncomeType].IncomeType,
	[ACC_Income].Amount,
	[ACC_Income].IncomeDate,
	[ACC_Income].Note,
	[MST_Hospital].Hospital,
	[ACC_Income].FinYearID,
	--[ACC_Income].Remarks,
	[SEC_User].USERNAME,
	[ACC_Income].Created,
	[ACC_Income].Modified
    FROM ACC_Income AS [ACC_Income]
	INNER JOIN [dbo].[MST_IncomeType] as[MST_IncomeType]
	ON [ACC_Income].IncomeTypeID=[MST_IncomeType].IncomeTypeID
	INNER JOIN [dbo].[MST_Hospital] AS [MST_Hospital]
	ON [ACC_Income].HospitalID=[MST_Hospital].HospitalID
	INNER JOIN [dbo].[SEC_User] AS [SEC_User]
	ON [ACC_Income].UserID=[SEC_User].UserID
    ORDER BY IncomeDate DESC; -- Assuming IncomeDate is a column by which you want to order the records
END
GO
Create PROCEDURE [dbo].[PR_DSB_ExpenseList]
AS
BEGIN
    -- Your SQL statements here
    SELECT TOP 10 
	[ACC_Expense].ExpenseID,
	[ACC_Income].ExpenseType,
	[ACC_Expense].Amount,
	[ACC_Expense].ExpenseDate,
	[ACC_Expense].Note,
	[MST_Hospital].Hospital,
	[ACC_Expense].FinYearID,
	[ACC_Expense].Remarks,
	[SEC_User].UserName,
	[ACC_Expense].Created,
	[ACC_Expense].Modified
    FROM ACC_Expense AS [ACC_Expense]
	INNER JOIN [dbo].[ACC_Income] AS [ACC_Income]
	ON [ACC_Expense].ExpenseTypeID=[ACC_Income].ExpenseTypeID
	INNER JOIN [dbo].[MST_Hospital] AS [MST_Hospital]
	ON [ACC_Expense].HospitalID=[MST_Hospital].HospitalID
	INNER JOIN [dbo].[SEC_User] AS [SEC_User]
	ON [ACC_Expense].UserID=[SEC_User].UserID
    ORDER BY ExpenseDate DESC; -- Assuming ExpenseDate is a column by which you want to order the records
END
GO




--Traning Task #1

--#1.1
alter table Acc_income 
DROP COLUMN Remarks;

--#1.2
ALTER TABLE ACC_Expense
ADD TagName varchar(100);

--#1.3
Create PROCEDURE [dbo].[PR_ACC_IncomeExpense_SelectPage]
AS
BEGIN
    SET NOCOUNT ON;
	
    DECLARE @StartTime datetime
    DECLARE @EndTime datetime
    DECLARE @FirstDateOfMonth datetime
    DECLARE @LastDateOfMonth datetime

    SET @StartTime = GETDATE();
    
    -- Calculate the first and last date of the current month
    SET @FirstDateOfMonth =  DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0)
    SET @LastDateOfMonth =  EOMONTH(GETDATE())

    -- Use default values if FromDate and ToDate are not provided
    SET @FromDate = ISNULL(@FromDate, @FirstDateOfMonth)
    SET @ToDate = ISNULL(@ToDate, @LastDateOfMonth)

    BEGIN TRY
        -- Calculate total records
        SELECT @TotalRecords = COUNT(1)
        FROM (
            SELECT ExpenseID AS LedgerID, 'Expense' AS LedgerType, Amount as LedgerAmount, ExpenseDate AS LedgerDate, Note as LedgerNote 
            FROM [dbo].[ACC_Expense]
            WHERE ExpenseDate >= @FromDate AND ExpenseDate <= @ToDate
            AND (@Type IS NULL OR @Type = 'Expense')
            
            UNION ALL
            
            SELECT IncomeID AS LedgerID, 'Income' AS LedgerType, Amount as LedgerAmount, IncomeDate AS LedgerDate, Note As LedgerNote 
            FROM [dbo].[ACC_Income]
            WHERE IncomeDate >= @FromDate AND IncomeDate <= @ToDate
            AND (@Type IS NULL OR @Type = 'Income')
        ) AS Combined

        -- Fetch paginated results
        SELECT 
            LedgerID, 
            LedgerType, 
            LedgerAmount, 
            LedgerDate, 
            LedgerNote
            
        FROM (
            SELECT ExpenseID AS LedgerID, 'Expense' AS LedgerType, Amount as LedgerAmount, ExpenseDate AS LedgerDate, Note as LedgerNote 
            FROM [dbo].[ACC_Expense]
            WHERE ExpenseDate >= @FromDate AND ExpenseDate <= @ToDate
            AND (@Type IS NULL OR @Type = 'Expense')
            
            UNION ALL
            
            SELECT IncomeID AS LedgerID, 'Income' AS LedgerType, Amount as LedgerAmount, IncomeDate AS LedgerDate, Note as LedgerNote
            FROM [dbo].[ACC_Income]
            WHERE IncomeDate >= @FromDate AND IncomeDate <= @ToDate
            AND (@Type IS NULL OR @Type = 'Income')
        ) AS Combined
        ORDER BY LedgerDate, LedgerID
        OFFSET @PageOffset ROWS
        FETCH NEXT @PageSize ROWS ONLY

    END TRY
    BEGIN CATCH
        ;THROW
    END CATCH

    SET @EndTime = GETDATE();
    --EXEC [dbo].[PR_MST_SPExecution_Insert] '[dbo].[PR_ACC_IncomeExpense_SelectPage]', @StartTime, @EndTime
END;
GO

--#1.5
CREATE PROCEDURE [dbo].[PR_ACC_Income_SelectShow]

		@HospitalID 		int,
		@IncomeTypeID		int,
		@FinYearID			int

AS

SET NOCOUNT ON;

DECLARE	@StartTime	datetime
DECLARE	@EndTime	datetime
SET		@StartTime = [dbo].[GetServerDateTime]();

BEGIN TRY

SELECT  
		[dbo].[ACC_Income].[HospitalID],
		[dbo].[ACC_Income].[FinYearID],
		[dbo].[ACC_Income].[IncomeTypeID],
		[dbo].[ACC_Income].[IncomeID],
		[dbo].[ACC_Income].[IncomeDate],
		[dbo].[ACC_Income].[Amount],
		[dbo].[ACC_Income].[Note],
		[dbo].[ACC_Income].[UserID],
		[dbo].[ACC_Income].[Created],
		[dbo].[ACC_Income].[Modified]	
FROM  [dbo].[ACC_Income]
WHERE [dbo].[ACC_Income].[HospitalID] = @HospitalID and
	[dbo].[ACC_Income].[FinYearID] = @FinYearID	and
		[dbo].[ACC_Income].[IncomeTypeID] = @IncomeTypeID



END TRY

BEGIN CATCH
;THROW

END CATCH

SET		@EndTime = [dbo].[GetServerDateTime]()
GO




----Traning Task #2

--#2.1
ALTER TABLE MST_IncomeType
ADD CONSTRAINT UQ_IncomeDetails_IncomeType_HospitalID UNIQUE (IncomeType, HospitalID);


--#2.4
alter PROCEDURE PR_MasterDashboard_Count 
    @HospitalID INT
AS
BEGIN
    -- Declare variables to hold the total amounts
    DECLARE @TotalIncome DECIMAL(18, 2);
    DECLARE @TotalExpense DECIMAL(18, 2);
	DECLARE @TotalPatientAmount DECIMAL(18,2);
	DECLARE @currentYear INT;
    
    -- Initialize variables with default values
    SET @TotalIncome = 0.00;
    SET @TotalExpense = 0.00;
	SET @TotalPatientAmount =0.00;
	SET @currentYear = YEAR(GETDATE());

    -- Calculate total income for the specified hospital
    SELECT @TotalIncome = ISNULL(SUM(Amount), 0.00)
    FROM ACC_Income
    WHERE HospitalID = @HospitalID and YEAR(IncomeDate)=@currentYear;

    -- Calculate total expense for the specified hospital
    SELECT @TotalExpense = ISNULL(SUM(Amount), 0.00)
    FROM ACC_Expense
    WHERE HospitalID = @HospitalID and YEAR(ExpenseDate)=@currentYear;

	SELECT @TotalPatientAmount = ISNULL(sum(Amount), 0.00)
	FROM ACC_Transaction
	where HospitalID = @HospitalID and YEAR(Date)=@currentYear;

    -- Return results
    SELECT 
        @TotalIncome AS TotalIncome,
        @TotalExpense AS TotalExpense,
		@TotalPatientAmount AS TotalPatientAmount;
END;
GO

ALTER PROCEDURE PR_MasterDashboard_IncomeList 4
@HospitalID INT
AS
BEGIN
    DECLARE @currentYear INT;

    -- Get the current year
    SET @currentYear = YEAR(GETDATE())
	

    -- Generate a list of days for the month (1 to 31)
      ;WITH Days AS (
        SELECT TOP (31) ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS [Day]
        FROM master.dbo.spt_values
    )
    -- Retrieve the data, including all days of the month
	SELECt * from (
    SELECT 
        CAST(d.[Day] AS NVARCHAR) AS [Day], -- Cast Day as NVARCHAR for consistent data type in UNION
        ISNULL(SUM(CASE WHEN DATENAME(MONTH, i.IncomeDate) = 'January' THEN i.Amount ELSE 0 END), 0) AS [January],
        ISNULL(SUM(CASE WHEN DATENAME(MONTH, i.IncomeDate) = 'February' THEN i.Amount ELSE 0 END), 0) AS [February],
        ISNULL(SUM(CASE WHEN DATENAME(MONTH, i.IncomeDate) = 'March' THEN i.Amount ELSE 0 END), 0) AS [March],
        ISNULL(SUM(CASE WHEN DATENAME(MONTH, i.IncomeDate) = 'April' THEN i.Amount ELSE 0 END), 0) AS [April],
        ISNULL(SUM(CASE WHEN DATENAME(MONTH, i.IncomeDate) = 'May' THEN i.Amount ELSE 0 END), 0) AS [May],
        ISNULL(SUM(CASE WHEN DATENAME(MONTH, i.IncomeDate) = 'June' THEN i.Amount ELSE 0 END), 0) AS [June],
        ISNULL(SUM(CASE WHEN DATENAME(MONTH, i.IncomeDate) = 'July' THEN i.Amount ELSE 0 END), 0) AS [July],
        ISNULL(SUM(CASE WHEN DATENAME(MONTH, i.IncomeDate) = 'August' THEN i.Amount ELSE 0 END), 0) AS [August],
        ISNULL(SUM(CASE WHEN DATENAME(MONTH, i.IncomeDate) = 'September' THEN i.Amount ELSE 0 END), 0) AS [September],
        ISNULL(SUM(CASE WHEN DATENAME(MONTH, i.IncomeDate) = 'October' THEN i.Amount ELSE 0 END), 0) AS [October],
        ISNULL(SUM(CASE WHEN DATENAME(MONTH, i.IncomeDate) = 'November' THEN i.Amount ELSE 0 END), 0) AS [November],
        ISNULL(SUM(CASE WHEN DATENAME(MONTH, i.IncomeDate) = 'December' THEN i.Amount ELSE 0 END), 0) AS [December]
    FROM Days d
    LEFT JOIN ACC_Income i
        ON DAY(i.IncomeDate) = d.[Day] AND i.HospitalID = @HospitalID AND YEAR(i.IncomeDate) = @currentYear
    GROUP BY d.[Day]

	 
    
    UNION ALL
    
    -- Summary row for totals
    SELECT 
        'Total' AS [Day],
        ISNULL(SUM(CASE WHEN DATENAME(MONTH, i.IncomeDate) = 'January' THEN i.Amount ELSE 0 END), 0) AS [January],
        ISNULL(SUM(CASE WHEN DATENAME(MONTH, i.IncomeDate) = 'February' THEN i.Amount ELSE 0 END), 0) AS [February],
        ISNULL(SUM(CASE WHEN DATENAME(MONTH, i.IncomeDate) = 'March' THEN i.Amount ELSE 0 END), 0) AS [March],
        ISNULL(SUM(CASE WHEN DATENAME(MONTH, i.IncomeDate) = 'April' THEN i.Amount ELSE 0 END), 0) AS [April],
        ISNULL(SUM(CASE WHEN DATENAME(MONTH, i.IncomeDate) = 'May' THEN i.Amount ELSE 0 END), 0) AS [May],
        ISNULL(SUM(CASE WHEN DATENAME(MONTH, i.IncomeDate) = 'June' THEN i.Amount ELSE 0 END), 0) AS [June],
        ISNULL(SUM(CASE WHEN DATENAME(MONTH, i.IncomeDate) = 'July' THEN i.Amount ELSE 0 END), 0) AS [July],
        ISNULL(SUM(CASE WHEN DATENAME(MONTH, i.IncomeDate) = 'August' THEN i.Amount ELSE 0 END), 0) AS [August],
        ISNULL(SUM(CASE WHEN DATENAME(MONTH, i.IncomeDate) = 'September' THEN i.Amount ELSE 0 END), 0) AS [September],
        ISNULL(SUM(CASE WHEN DATENAME(MONTH, i.IncomeDate) = 'October' THEN i.Amount ELSE 0 END), 0) AS [October],
        ISNULL(SUM(CASE WHEN DATENAME(MONTH, i.IncomeDate) = 'November' THEN i.Amount ELSE 0 END), 0) AS [November],
        ISNULL(SUM(CASE WHEN DATENAME(MONTH, i.IncomeDate) = 'December' THEN i.Amount ELSE 0 END), 0) AS [December]
    FROM ACC_Income i
    WHERE i.HospitalID = @HospitalID AND YEAR(i.IncomeDate) = @currentYear
    GROUP BY i.HospitalID
	)s
	ORDER BY CASE WHEN [Day] = 'Total' THEN 999 ELSE [Day] END;
	
    
    
END
GO

ALTER PROCEDURE PR_MasterDashboard_ExpenseList 3
@HospitalID INT
AS
BEGIN
    DECLARE @currentYear INT;

    -- Get the current year
    SET @currentYear = YEAR(GETDATE())
	

    -- Generate a list of days for the month (1 to 31)
      ;WITH Days AS (
        SELECT TOP (31) ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS [Day]
        FROM master.dbo.spt_values
    )
    -- Retrieve the data, including all days of the month
	SELECt * from (
    SELECT 
        CAST(d.[Day] AS NVARCHAR) AS [Day], -- Cast Day as NVARCHAR for consistent data type in UNION
        ISNULL(SUM(CASE WHEN DATENAME(MONTH, i.ExpenseDate) = 'January' THEN i.Amount ELSE 0 END), 0) AS [January],
        ISNULL(SUM(CASE WHEN DATENAME(MONTH, i.ExpenseDate) = 'February' THEN i.Amount ELSE 0 END), 0) AS [February],
        ISNULL(SUM(CASE WHEN DATENAME(MONTH, i.ExpenseDate) = 'March' THEN i.Amount ELSE 0 END), 0) AS [March],
        ISNULL(SUM(CASE WHEN DATENAME(MONTH, i.ExpenseDate) = 'April' THEN i.Amount ELSE 0 END), 0) AS [April],
        ISNULL(SUM(CASE WHEN DATENAME(MONTH, i.ExpenseDate) = 'May' THEN i.Amount ELSE 0 END), 0) AS [May],
        ISNULL(SUM(CASE WHEN DATENAME(MONTH, i.ExpenseDate) = 'June' THEN i.Amount ELSE 0 END), 0) AS [June],
        ISNULL(SUM(CASE WHEN DATENAME(MONTH, i.ExpenseDate) = 'July' THEN i.Amount ELSE 0 END), 0) AS [July],
        ISNULL(SUM(CASE WHEN DATENAME(MONTH, i.ExpenseDate) = 'August' THEN i.Amount ELSE 0 END), 0) AS [August],
        ISNULL(SUM(CASE WHEN DATENAME(MONTH, i.ExpenseDate) = 'September' THEN i.Amount ELSE 0 END), 0) AS [September],
        ISNULL(SUM(CASE WHEN DATENAME(MONTH, i.ExpenseDate) = 'October' THEN i.Amount ELSE 0 END), 0) AS [October],
        ISNULL(SUM(CASE WHEN DATENAME(MONTH, i.ExpenseDate) = 'November' THEN i.Amount ELSE 0 END), 0) AS [November],
        ISNULL(SUM(CASE WHEN DATENAME(MONTH, i.ExpenseDate) = 'December' THEN i.Amount ELSE 0 END), 0) AS [December]
    FROM Days d
    LEFT JOIN ACC_Expense i
        ON DAY(i.ExpenseDate) = d.[Day] AND i.HospitalID = @HospitalID AND YEAR(i.ExpenseDate) = @currentYear
    GROUP BY d.[Day]

	 
    
    UNION ALL
    
    -- Summary row for totals
    SELECT 
        'Total' AS [Day],
        ISNULL(SUM(CASE WHEN DATENAME(MONTH, i.ExpenseDate) = 'January' THEN i.Amount ELSE 0 END), 0) AS [January],
        ISNULL(SUM(CASE WHEN DATENAME(MONTH, i.ExpenseDate) = 'February' THEN i.Amount ELSE 0 END), 0) AS [February],
        ISNULL(SUM(CASE WHEN DATENAME(MONTH, i.ExpenseDate) = 'March' THEN i.Amount ELSE 0 END), 0) AS [March],
        ISNULL(SUM(CASE WHEN DATENAME(MONTH, i.ExpenseDate) = 'April' THEN i.Amount ELSE 0 END), 0) AS [April],
        ISNULL(SUM(CASE WHEN DATENAME(MONTH, i.ExpenseDate) = 'May' THEN i.Amount ELSE 0 END), 0) AS [May],
        ISNULL(SUM(CASE WHEN DATENAME(MONTH, i.ExpenseDate) = 'June' THEN i.Amount ELSE 0 END), 0) AS [June],
        ISNULL(SUM(CASE WHEN DATENAME(MONTH, i.ExpenseDate) = 'July' THEN i.Amount ELSE 0 END), 0) AS [July],
        ISNULL(SUM(CASE WHEN DATENAME(MONTH, i.ExpenseDate) = 'August' THEN i.Amount ELSE 0 END), 0) AS [August],
        ISNULL(SUM(CASE WHEN DATENAME(MONTH, i.ExpenseDate) = 'September' THEN i.Amount ELSE 0 END), 0) AS [September],
        ISNULL(SUM(CASE WHEN DATENAME(MONTH, i.ExpenseDate) = 'October' THEN i.Amount ELSE 0 END), 0) AS [October],
        ISNULL(SUM(CASE WHEN DATENAME(MONTH, i.ExpenseDate) = 'November' THEN i.Amount ELSE 0 END), 0) AS [November],
        ISNULL(SUM(CASE WHEN DATENAME(MONTH, i.ExpenseDate) = 'December' THEN i.Amount ELSE 0 END), 0) AS [December]
    FROM ACC_Expense i
    WHERE i.HospitalID = @HospitalID AND YEAR(i.ExpenseDate) = @currentYear
    GROUP BY i.HospitalID
	)s
	ORDER BY CASE WHEN [Day] = 'Total' THEN 999 ELSE [Day] END;
	
    
    
END
GO

alter PROCEDURE PR_MasterDashboard_TreatmentSummary 2
@HospitalID INT
AS
BEGIN
	DECLARE @currentYear INT;
	SET @currentYear = YEAR(GETDATE());
	Select MST_Treatment.TreatmentID as TreatmentID, Treatment AS TreatmentType,Count(TransactionID) as PatientCount,ISNULL(SUM(Amount), 0.00) as IncomeAmount
	from ACC_Transaction
	inner join MST_Treatment
	on ACC_Transaction.TreatmentID = MST_Treatment.TreatmentID
	where ACC_Transaction.HospitalID=@HospitalID and YEAR(Date)=@currentYear
	Group by Treatment,MST_Treatment.TreatmentID
END
GO




--------------   Traning Task #4

CREATE TABLE STU_BranchIntake (
    Branch NVARCHAR(100) ,
    AdmissionYear INT ,
    Intake INT 
);
select * from STU_BranchIntake


CREATE PROCEDURE PR_STU_Student_GetBranchIntakeMatrix
AS
BEGIN
    -- Declare variables for dynamic SQL
    DECLARE @columns NVARCHAR(MAX), @sql NVARCHAR(MAX);
    
    -- Dynamically create column headers based on distinct AdmissionYear values
    SELECT @columns = ISNULL(@columns + ', ', '') + QUOTENAME(AdmissionYear)
    FROM (SELECT DISTINCT AdmissionYear FROM STU_BranchIntake) AS Years
    ORDER BY AdmissionYear;
    
    -- Build the dynamic SQL for the pivot
    SET @sql = '
        SELECT Branch, ' + @columns + '
        FROM
        (
            SELECT Branch, AdmissionYear, Intake
            FROM STU_BranchIntake
        ) AS SourceTable
        PIVOT
        (
            SUM(Intake)
            FOR AdmissionYear IN (' + @columns + ')
        ) AS PivotTable
        ORDER BY Branch;
    ';
    
    -- Execute the dynamic SQL
    EXEC sp_executesql @sql;
END;
GO



CREATE Procedure PR_STU_Student_UpdateBranchIntakeMatrix
 @Branch NVARCHAR(100) ,
  @AdmissionYear INT ,
  @Intake INT 
  as
  begin
  update STU_BranchIntake
  set Intake = @Intake
  where Branch=@Branch and AdmissionYear = @AdmissionYear
  end
GO

CREATE TYPE dbo.BranchIntakeType AS TABLE
(
    Branch NVARCHAR(50),
    AdmissionYear NVARCHAR(4),
    Intake INT
)
GO

Create PROCEDURE [dbo].[PR_STU_Student_InsertUpdateBranchIntakeMatrix]
    @BranchIntakeData dbo.BranchIntakeType READONLY
AS
BEGIN
    SET NOCOUNT ON;

    MERGE INTO STU_BranchIntake AS target
    USING @BranchIntakeData AS source
    ON target.Branch = source.Branch AND target.AdmissionYear = source.AdmissionYear
    WHEN MATCHED THEN
        UPDATE SET Intake = source.Intake
    WHEN NOT MATCHED THEN
        INSERT (Branch, AdmissionYear, Intake)
        VALUES (source.Branch, source.AdmissionYear, source.Intake);
END
GO


---------------- 


 