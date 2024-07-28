
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
WHERE i.HospitalID = 4 AND YEAR(i.ExpenseDate) = 2024
GROUP BY i.HospitalID

