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

alter PROCEDURE PR_MasterDashboard_IncomeList 
@HospitalID INT
AS
BEGIN
    DECLARE @cols NVARCHAR(MAX), @query NVARCHAR(MAX), @currentYear INT;

    -- Get the current year
    SET @currentYear = YEAR(GETDATE());

    -- Generate the list of month columns
    SET @cols = QUOTENAME('January') + ', ' +
                 QUOTENAME('February') + ', ' +
                 QUOTENAME('March') + ', ' +
                 QUOTENAME('April') + ', ' +
                 QUOTENAME('May') + ', ' +
                 QUOTENAME('June') + ', ' +
                 QUOTENAME('July') + ', ' +
                 QUOTENAME('August') + ', ' +
                 QUOTENAME('September') + ', ' +
                 QUOTENAME('October') + ', ' +
                 QUOTENAME('November') + ', ' +
                 QUOTENAME('December');

    -- Construct the dynamic SQL query
    SET @query = '
        ;WITH IncomeData AS (
            SELECT DAY(i.IncomeDate) AS [Day],
                   DATENAME(MONTH, i.IncomeDate) AS [Month],
                   SUM(i.Amount) AS Amount
            FROM ACC_Income i
            WHERE HospitalID='+CAST(@HospitalID AS VARCHAR(4))+' and YEAR(i.IncomeDate) = ' + CAST(@currentYear AS VARCHAR(4)) + '
            GROUP BY DAY(i.IncomeDate), DATENAME(MONTH, i.IncomeDate)
        ),
        Days AS (
            SELECT 1 AS [Day] UNION ALL
            SELECT 2 UNION ALL
            SELECT 3 UNION ALL
            SELECT 4 UNION ALL
            SELECT 5 UNION ALL
            SELECT 6 UNION ALL
            SELECT 7 UNION ALL
            SELECT 8 UNION ALL
            SELECT 9 UNION ALL
            SELECT 10 UNION ALL
            SELECT 11 UNION ALL
            SELECT 12 UNION ALL
            SELECT 13 UNION ALL
            SELECT 14 UNION ALL
            SELECT 15 UNION ALL
            SELECT 16 UNION ALL
            SELECT 17 UNION ALL
            SELECT 18 UNION ALL
            SELECT 19 UNION ALL
            SELECT 20 UNION ALL
            SELECT 21 UNION ALL
            SELECT 22 UNION ALL
            SELECT 23 UNION ALL
            SELECT 24 UNION ALL
            SELECT 25 UNION ALL
            SELECT 26 UNION ALL
            SELECT 27 UNION ALL
            SELECT 28 UNION ALL
            SELECT 29 UNION ALL
            SELECT 30 UNION ALL
            SELECT 31
        ),
        FullData AS (
            SELECT d.[Day],
                   m.[Month],
                   ISNULL(i.Amount, 0) AS Amount
            FROM Days d
            CROSS JOIN (SELECT ''January'' AS [Month]
                        UNION ALL SELECT ''February''
                        UNION ALL SELECT ''March''
                        UNION ALL SELECT ''April''
                        UNION ALL SELECT ''May''
                        UNION ALL SELECT ''June''
                        UNION ALL SELECT ''July''
                        UNION ALL SELECT ''August''
                        UNION ALL SELECT ''September''
                        UNION ALL SELECT ''October''
                        UNION ALL SELECT ''November''
                        UNION ALL SELECT ''December'') m
            LEFT JOIN IncomeData i
                   ON d.[Day] = i.[Day] AND m.[Month] = i.[Month]
        )
        SELECT [Day], ' + @cols + '
        FROM (
            SELECT [Day], [Month], Amount
            FROM FullData
        ) AS SourceTable
        PIVOT
        (
            SUM(Amount)
            FOR [Month] IN (' + @cols + ')
        ) AS PivotTable
        ORDER BY [Day];
    ';

    -- Execute the dynamic SQL
    EXEC sp_executesql @query;
END
GO

create PROCEDURE PR_MasterDashboard_ExpenseList 4
@HospitalID INT
AS
BEGIN
    DECLARE @cols NVARCHAR(MAX), @query NVARCHAR(MAX), @currentYear INT;

    -- Get the current year
    SET @currentYear = YEAR(GETDATE());

    -- Generate the list of month columns
    SET @cols = QUOTENAME('January') + ', ' +
                 QUOTENAME('February') + ', ' +
                 QUOTENAME('March') + ', ' +
                 QUOTENAME('April') + ', ' +
                 QUOTENAME('May') + ', ' +
                 QUOTENAME('June') + ', ' +
                 QUOTENAME('July') + ', ' +
                 QUOTENAME('August') + ', ' +
                 QUOTENAME('September') + ', ' +
                 QUOTENAME('October') + ', ' +
                 QUOTENAME('November') + ', ' +
                 QUOTENAME('December');

    -- Construct the dynamic SQL query
    SET @query = '
        ;WITH IncomeData AS (
            SELECT DAY(i.ExpenseDate) AS [Day],
                   DATENAME(MONTH, i.ExpenseDate) AS [Month],
                   SUM(i.Amount) AS Amount
            FROM ACC_Expense i
            WHERE HospitalID='+CAST(@HospitalID AS VARCHAR(4))+' and YEAR(i.ExpenseDate) = ' + CAST(@currentYear AS VARCHAR(4)) + '
            GROUP BY DAY(i.ExpenseDate), DATENAME(MONTH, i.ExpenseDate)
        ),
        Days AS (
            SELECT 1 AS [Day] UNION ALL
            SELECT 2 UNION ALL
            SELECT 3 UNION ALL
            SELECT 4 UNION ALL
            SELECT 5 UNION ALL
            SELECT 6 UNION ALL
            SELECT 7 UNION ALL
            SELECT 8 UNION ALL
            SELECT 9 UNION ALL
            SELECT 10 UNION ALL
            SELECT 11 UNION ALL
            SELECT 12 UNION ALL
            SELECT 13 UNION ALL
            SELECT 14 UNION ALL
            SELECT 15 UNION ALL
            SELECT 16 UNION ALL
            SELECT 17 UNION ALL
            SELECT 18 UNION ALL
            SELECT 19 UNION ALL
            SELECT 20 UNION ALL
            SELECT 21 UNION ALL
            SELECT 22 UNION ALL
            SELECT 23 UNION ALL
            SELECT 24 UNION ALL
            SELECT 25 UNION ALL
            SELECT 26 UNION ALL
            SELECT 27 UNION ALL
            SELECT 28 UNION ALL
            SELECT 29 UNION ALL
            SELECT 30 UNION ALL
            SELECT 31
        ),
        FullData AS (
            SELECT d.[Day],
                   m.[Month],
                   ISNULL(i.Amount, 0) AS Amount
            FROM Days d
            CROSS JOIN (SELECT ''January'' AS [Month]
                        UNION ALL SELECT ''February''
                        UNION ALL SELECT ''March''
                        UNION ALL SELECT ''April''
                        UNION ALL SELECT ''May''
                        UNION ALL SELECT ''June''
                        UNION ALL SELECT ''July''
                        UNION ALL SELECT ''August''
                        UNION ALL SELECT ''September''
                        UNION ALL SELECT ''October''
                        UNION ALL SELECT ''November''
                        UNION ALL SELECT ''December'') m
            LEFT JOIN IncomeData i
                   ON d.[Day] = i.[Day] AND m.[Month] = i.[Month]
        )
        SELECT [Day], ' + @cols + '
        FROM (
            SELECT [Day], [Month], Amount
            FROM FullData
        ) AS SourceTable
        PIVOT
        (
            SUM(Amount)
            FOR [Month] IN (' + @cols + ')
        ) AS PivotTable
        ORDER BY [Day];
    ';

    -- Execute the dynamic SQL
    EXEC sp_executesql @query;
END
GO

alter PROCEDURE PR_MasterDashboard_TreatmentSummary
@HospitalID INT
AS
BEGIN
	DECLARE @currentYear INT;
	SET @currentYear = YEAR(GETDATE());
	Select Treatment AS TreatmentType,Count(TransactionID) as PatientCount,ISNULL(SUM(Amount), 0.00) as IncomeAmount
	from ACC_Transaction
	inner join MST_Treatment
	on ACC_Transaction.TreatmentID = MST_Treatment.TreatmentID
	where ACC_Transaction.HospitalID=@HospitalID and YEAR(Date)=@currentYear
	Group by Treatment
END
GO






