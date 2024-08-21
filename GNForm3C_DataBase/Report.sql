select ACC_Income.HospitalID, Hospital,ACC_Income.FinYearID,FinYearName, sum(Acc_Income.Amount) As Income,sum(ACC_Expense.Amount) as Expense,count(ACC_GNTransaction.patientID) as Patient
from MST_FinYear
inner join ACC_Income
on ACC_Income.FinYearID = MST_FinYear.FinYearID
inner join ACC_Expense
on ACC_Expense.HospitalID = MST_FinYear.FinYearID
left outer join MST_Hospital
on ACC_Income.HospitalID =MST_Hospital.HospitalID
left outer join ACC_GNTransaction
on ACC_GNTransaction.HospitalID=MST_Hospital.HospitalID and ACC_GNTransaction.FinYearID =MST_FinYear.FinYearID
group by Acc_Income.HospitalID,ACC_Income.FinYearID,Hospital,FinYearName

union all
select ACC_Expense.HospitalID,Hospital,ACC_Expense.FinYearID,FinYearName,Amount
from ACC_Expense
inner join MST_Hospital
on ACC_Expense.HospitalID = MST_Hospital.HospitalID
inner join MST_FinYear
on ACC_Expense.FinYearID=MST_FinYear.FinYearID

select * from MST_IncomeType



select 
from MS

select * from MST_FinYear
select * from MST_Hospital


select MST_Hospital.HospitalID, Hospital,ACC_Income.FinYearID,sum(Acc_Income.Amount) As Income,sum(ACC_Expense.Amount) as Expense,count( distinct ACC_GNTransaction.patientID) as Patient
from MST_Hospital 
cross join MST_FinYear
left outer join ACC_Expense
on ACC_Expense.HospitalID = MST_Hospital.HospitalID
left outer join ACC_Income
on ACC_Income.HospitalID = MST_Hospital.HospitalID
left outer join ACC_GNTransaction
on ACC_GNTransaction.HospitalID=MST_Hospital.HospitalID
group by MST_Hospital.HospitalID,ACC_Income.FinYearID,Hospital


select * from MST_Hospital
select * from MST_FinYear cross join MST_Hospital

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