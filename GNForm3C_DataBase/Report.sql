select MST_Hospital.HospitalID,MST_FinYear.FinYearID, Hospital,FinYearName,count( ACC_Income.IncomeID),sum( ACC_Income.Amount) as Income ,count( ACC_Expense.ExpenseID), sum( ACC_Expense.Amount) as Expense, Count(distinct ACC_GNTransaction.patientID) as Patient
from MST_Hospital cross join MST_FinYear
left outer join ACC_Expense
on   MST_Hospital.HospitalID= ACC_Expense.HospitalID and   MST_FinYear.FinYearID=ACC_Expense.FinYearID 
left outer join ACC_Income
on MST_Hospital.HospitalID = ACC_Income.HospitalID  and  MST_FinYear.FinYearID =ACC_Income.FinYearID 
left outer join ACC_GNTransaction
on ACC_GNTransaction.HospitalID=MST_Hospital.HospitalID and ACC_GNTransaction.FinYearID = MST_FinYear.FinYearID
group by MST_Hospital.HospitalID,MST_FinYear.FinYearID,Hospital, FinYearName

select *
from ACC_Expense
where  HospitalID=1 and FinYearID = 5
select *
from ACC_Income
where  HospitalID=1 and FinYearID = 5



CREATE OR ALTER PROCEDURE [dbo].[PP_HospitalWise_FinYearWise_IncomeExpenseList]
  
AS
BEGIN
    SET NOCOUNT ON;

    -- Subquery for Income
    WITH IncomeData AS (
        SELECT 
            [dbo].[ACC_Income].[FinYearID],
            [dbo].[ACC_Income].[HospitalID],
            SUM([dbo].[ACC_Income].[Amount]) AS TotalIncome
        FROM 
            [dbo].[ACC_Income]
      GROUP BY 
            [dbo].[ACC_Income].[FinYearID],
            [dbo].[ACC_Income].[HospitalID]
    ),

    -- Subquery for Expense
    ExpenseData AS (
        SELECT 
            [dbo].[ACC_Expense].[FinYearID],
            [dbo].[ACC_Expense].[HospitalID],
            SUM([dbo].[ACC_Expense].[Amount]) AS TotalExpense
        FROM 
            [dbo].[ACC_Expense]
       GROUP BY 
            [dbo].[ACC_Expense].[FinYearID],
            [dbo].[ACC_Expense].[HospitalID]
    ),

    -- Subquery for Patient Count
    PatientData AS (
        SELECT 
            [dbo].[ACC_GNTransaction].[FinYearID],
            [dbo].[ACC_GNTransaction].[HospitalID],
            COUNT(DISTINCT [dbo].[ACC_GNTransaction].[PatientID]) AS TotalPatients
        FROM 
            [dbo].[ACC_GNTransaction]
        GROUP BY 
            [dbo].[ACC_GNTransaction].[FinYearID],
            [dbo].[ACC_GNTransaction].[HospitalID]
    )

    -- Final Select with LEFT JOINs
    SELECT 
		[dbo].[MST_FinYear].[FinYearID],
		[dbo].[MST_Hospital].[HospitalID],
        [dbo].[MST_FinYear].[FinYearName],
        [dbo].[MST_Hospital].[Hospital],
        ISNULL(IncomeData.TotalIncome, 0) AS TotalIncome,
        ISNULL(ExpenseData.TotalExpense, 0) AS TotalExpense,
        ISNULL(PatientData.TotalPatients, 0) AS TotalPatients
    FROM 
        [dbo].[MST_Hospital]
        CROSS JOIN [dbo].[MST_FinYear]
        LEFT JOIN IncomeData
            ON [dbo].[MST_Hospital].[HospitalID] = IncomeData.HospitalID
            AND [dbo].[MST_FinYear].[FinYearID] = IncomeData.FinYearID
        LEFT JOIN ExpenseData
            ON [dbo].[MST_Hospital].[HospitalID] = ExpenseData.HospitalID
            AND [dbo].[MST_FinYear].[FinYearID] = ExpenseData.FinYearID
        LEFT JOIN PatientData
            ON [dbo].[MST_Hospital].[HospitalID] = PatientData.HospitalID
            AND [dbo].[MST_FinYear].[FinYearID] = PatientData.FinYearID
    ORDER BY 
        [dbo].[MST_FinYear].[FinYearName], 
        [dbo].[MST_Hospital].[Hospital];
END;
GO


Create procedure [dbo].[PP_Patient_ICard]
as
begin
	Select 
	[dbo].[MST_Patient].[PatientID],
	[dbo].[MST_Patient].[PatientName],
	[dbo].[MST_Patient].[DOB],
	[dbo].[MST_Patient].[Age],
	[dbo].[MST_Patient].[MobileNo],
	[dbo].[MST_Patient].[PrimaryDesc],
	[dbo].[ACC_GNTransaction].[HospitalID],
	[dbo].[ACC_GNTransaction].[FinYearID],
	[dbo].[MST_Hospital].[Hospital],
	[dbo].[MST_FinYear].[FinYearName]
	from MST_Patient
	inner join ACC_GNTransaction
	on MST_Patient.PatientID = ACC_GNTransaction.PatientID
	inner join [dbo].[MST_Hospital]
	on [dbo].[ACC_GNTransaction].[HospitalID] = [dbo].[MST_Hospital].[HospitalID]
	inner join [dbo].[MST_FinYear]
	on [dbo].[ACC_GNTransaction].[FinYearID] = [dbo].[MST_FinYear].[FinYearID]
end
GO


select * from MST_Hospital where HospitalID=2

[PP_ACC_IncomeExpense_Ledger] 
alter PROCEDURE [dbo].[PP_ACC_IncomeExpense_Ledger] 
	@HospitalID			int =null,
	@FinYearID			int = null
AS
BEGIN
    SET NOCOUNT ON;
	
    DECLARE @StartTime datetime
    DECLARE @EndTime datetime
   

    SET @StartTime = GETDATE();
    
   
	--for try porpush
	set @HospitalID=2;
	set @FinYearID=9;
    BEGIN TRY
        
        -- Fetch paginated results
        SELECT 
			HospitalID,
			Hospital,
			FinYearID,
			FinYearName,
			ParticularID,
			Particular,
            LedgerID, 
            LedgerType, 
            LedgerAmount, 
            LedgerDate, 
            LedgerNote
            
        FROM (
            SELECT ACC_Expense.HospitalID, MST_Hospital.Hospital, ACC_Expense.FinYearID, MST_FinYear.FinYearName,ACC_Expense.ExpenseTypeID AS ParticularID,MST_ExpenseType.ExpenseType as Particular,
					ExpenseID AS LedgerID, 'Expense' AS LedgerType, Amount as LedgerAmount, ExpenseDate AS LedgerDate, Note as LedgerNote 
            FROM [dbo].[ACC_Expense]
			inner join [dbo].[MST_Hospital]
			on [dbo].[MST_Hospital].[HospitalID] = [dbo].[ACC_Expense].[HospitalID]
			inner join [dbo].[MST_FinYear]
			on [dbo].[MST_FinYear].[FinYearID] = [dbo].[ACC_Expense].[FinYearID]
			inner join [dbo].[MST_ExpenseType]
			on [dbo].[MST_ExpenseType].[ExpenseTypeID] = [dbo].[ACC_Expense].[ExpenseTypeID]
            WHERE acc_Expense.HospitalID=@HospitalID and acc_Expense.FinYearID=@FinYearID
            
            
            UNION ALL
            
            SELECT ACC_Income.HospitalID, MST_Hospital.Hospital, ACC_Income.FinYearID, MST_FinYear.FinYearName, ACC_Income.IncomeTypeID AS ParticularID,MST_IncomeType.IncomeType as Particular,
					IncomeID AS LedgerID, 'Income' AS LedgerType, Amount as LedgerAmount, IncomeDate AS LedgerDate, Note as LedgerNote
            FROM [dbo].[ACC_Income]
			inner join [dbo].[MST_Hospital]
			on [dbo].[MST_Hospital].[HospitalID] = [dbo].[ACC_Income].[HospitalID]
			inner join [dbo].[MST_FinYear]
			on [dbo].[MST_FinYear].[FinYearID] = [dbo].[ACC_Income].[FinYearID]
			inner join [dbo].[MST_IncomeType]
			on [dbo].[MST_IncomeType].[IncomeTypeID] = [dbo].[ACC_Income].[IncomeTypeID]
            WHERE Acc_Income.HospitalID=@HospitalID and [ACC_Income].FinYearID=@FinYearID
            
        ) AS Combined
        ORDER BY LedgerDate, LedgerID
       

    END TRY
    BEGIN CATCH
        ;THROW
    END CATCH

    SET @EndTime = GETDATE()
    --EXEC [dbo].[PR_MST_SPExecution_Insert] '[dbo].[PR_ACC_IncomeExpense_SelectPage]', @StartTime, @EndTime
END
GO

update ACC_Expense set FinYearID=9

select * from MST_ExpenseType