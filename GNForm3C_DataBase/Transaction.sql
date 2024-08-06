CREATE TABLE MST_Patient (
    PatientID INT IDENTITY(1,1) PRIMARY KEY  NOT NULL,         -- Primary Key
    PatientName VARCHAR(100) NOT NULL, -- Patient's Name
    Age INT NOT NULL,                  -- Patient's Age
    DOB DATE NOT NULL,                 -- Date of Birth
    MobileNo VARCHAR(15) NOT NULL,     -- Mobile Number
    PrimaryDesc VARCHAR(255) NOT NULL,  -- Primary Description
	UserID INT NOT NULL,
	 Created DATETIME DEFAULT GETDATE() NOT NULL,
    Modified DATETIME DEFAULT GETDATE() NOT NULL

		 CONSTRAINT FK_MST_SEC_User_UserID FOREIGN KEY ([UserID]) REFERENCES SEC_User([UserID]),

);



INSERT INTO MST_Patient (PatientName, Age, DOB, MobileNo, PrimaryDesc,UserID) VALUES
('Rohan Sharma', 28, '1996-05-12', '+91-9876543210', 'Chronic Migraine',4),
('Anjali Mehta', 34, '1990-11-23', '+91-9123456789', 'Type 2 Diabetes',4),
('Siddharth Patel', 42, '1982-03-17', '+91-8899776655', 'Hypertension',4),
('Priya Nair', 26, '1998-09-05', '+91-9988776655', 'Asthma',4),
('Vikram Singh', 30, '1994-07-15', '+91-7788995544', 'Seasonal Allergies',4);
select  * from MST_Patient



CREATE TABLE dbo.ACC_GNTransaction (
    TransactionID INT IDENTITY(1,1) NOT NULL primary key,
    FinYearID INT NOT NULL, -- (Current & Disable)
    HospitalID INT NOT NULL,
    ReceiptTypeID INT NULL, -- (Cash Memo, Challan)
    ReceiptNo INT NULL,
    [Date] DATETIME NOT NULL,
    PatientID INT NOT NULL, -- (FK Not Null)
    Amount DECIMAL(12, 2) NULL,
    ReferenceDoctor NVARCHAR(250) NULL,
    DateOfAdmission DATETIME NULL,
    DateOfDischarge DATETIME NULL,
    NoOfDays INT NULL,
    Deposite DECIMAL(12, 2) NULL,
    NetAmount DECIMAL(12, 2) NULL, -- (Tran no total aama update karvano)
    Remarks NVARCHAR(500) NULL,
    [Count] INT NULL,
    UserID INT NOT NULL,
    Created DATETIME NOT NULL,
    Modified DATETIME NOT NULL

	 CONSTRAINT FK_ACC_GNTransaction_FinYearID FOREIGN KEY ([FinYearID]) REFERENCES MST_FinYear([FinYearID]),
	 CONSTRAINT FK_ACC_GNTransaction_HospitalID FOREIGN KEY ([HospitalID]) REFERENCES MST_Hospital([HospitalID]),
	 CONSTRAINT FK_ACC_GNTransaction_ReceiptTypeID FOREIGN KEY ([ReceiptTypeID]) REFERENCES MST_ReceiptType([ReceiptTypeID]),
	 CONSTRAINT FK_ACC_GNTransaction_PatientID FOREIGN KEY ([PatientID]) REFERENCES MST_Patient([PatientID]),
	 CONSTRAINT FK_ACC_GNTransaction_UserID FOREIGN KEY ([UserID]) REFERENCES SEC_User([UserID]),
);

-- Ensure ReceiptNo is incremented automatically (Max+1) with a trigger or in application logic


CREATE TRIGGER trg_SetFormattedReceiptNo
ON dbo.ACC_GNTransaction
AFTER INSERT
AS
BEGIN
    UPDATE dbo.ACC_GNTransaction
    SET ReceiptNo = RIGHT('000' + CAST(TransactionID AS VARCHAR(3)), 3)
    WHERE TransactionID IN (SELECT TransactionID FROM inserted);
END;


CREATE TABLE [dbo].[ACC_GNTransactionTran] (
    [TransactionTranID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [TransactionID] INT NOT NULL,
    [TreatmentID] INT NULL,
    [Quantity] INT NULL,
    [Unit] NVARCHAR(250) NULL,
    [Rate] DECIMAL(12, 2) NULL,
    [Amount] DECIMAL(12, 2) NULL,
    [Remarks] NVARCHAR(250) NULL,
    [UserID] INT NOT NULL,
    [Created] DATETIME NOT NULL DEFAULT GETDATE(),
    [Modified] DATETIME NOT NULL DEFAULT GETDATE()
    
    -- Add foreign key constraints
    CONSTRAINT FK_ACC_GNTransactionTran_Transaction_ACC_GNTransaction_TransactionID FOREIGN KEY ([TransactionID]) REFERENCES [ACC_GNTransaction]([TransactionID]),
    CONSTRAINT FK_ACC_GNTransactionTran_MST_Treatment_TreatmentID FOREIGN KEY ([TreatmentID]) REFERENCES [MST_Treatment]([TreatmentID]),
	CONSTRAINT FK_ACC_GNTransactionTran_SEC_User_UserID FOREIGN KEY ([UserID]) REFERENCES [SEC_User]([UserID])
);


---------------------------------------------------------------------------
Create    PROCEDURE [dbo].[PR_MST_Patient_SelectComboBox] 
AS

SELECT  
		[dbo].[MST_Patient].[PatientID],
		([dbo].[MST_Patient].[PatientName] + ' - '+  [dbo].[MST_Patient].[MobileNo]) AS [PatientName]
	FROM[dbo].[MST_Patient] 
	ORDER BY [dbo].[MST_Patient].[PatientName],[dbo].[MST_Patient].[MobileNo]
GO


Create PROCEDURE [dbo].[PR_ACC_GNTransaction_SelectPage]
    @PageOffset        INT,
    @PageSize          INT,
    @TotalRecords      INT OUTPUT,
    @PatientID           int,
    @Amount            DECIMAL(14,2),
    @ReferenceDoctor   VARCHAR(250),
    @Count             INT,
    @ReceiptNo         INT,
    @Date              DATETIME,
    @DateOfAdmission   DATETIME,
    @DateOfDischarge   DATETIME,
    @Deposite          DECIMAL(12,2),
    @NetAmount         DECIMAL(12,2),
    @NoOfDays          INT,
    @HospitalID        INT,
    @FinYearID         INT,
    @ReceiptTypeID     INT
AS
SET NOCOUNT ON;

DECLARE @StartTime DATETIME;
DECLARE @EndTime DATETIME;
SET @StartTime = [dbo].[GetServerDateTime]();

BEGIN TRY
    SELECT @TotalRecords = COUNT(1)
    FROM [dbo].[ACC_GNTransaction]
    WHERE (@PatientID IS NULL OR [dbo].[ACC_GNTransaction].[PatientID] = @PatientID)
    AND (@Amount IS NULL OR [dbo].[ACC_GNTransaction].[Amount] = @Amount)
    AND (@ReferenceDoctor IS NULL OR [dbo].[ACC_GNTransaction].[ReferenceDoctor] LIKE '%' + @ReferenceDoctor + '%')
    AND (@Count IS NULL OR [dbo].[ACC_GNTransaction].[Count] = @Count)
    AND (@ReceiptNo IS NULL OR [dbo].[ACC_GNTransaction].[ReceiptNo] = @ReceiptNo)
    AND (@Date IS NULL OR [dbo].[ACC_GNTransaction].[Date] = @Date)
    AND (@DateOfAdmission IS NULL OR [dbo].[ACC_GNTransaction].[DateOfAdmission] = @DateOfAdmission)
    AND (@DateOfDischarge IS NULL OR [dbo].[ACC_GNTransaction].[DateOfDischarge] = @DateOfDischarge)
    AND (@Deposite IS NULL OR [dbo].[ACC_GNTransaction].[Deposite] = @Deposite)
    AND (@NetAmount IS NULL OR [dbo].[ACC_GNTransaction].[NetAmount] = @NetAmount)
    AND (@NoOfDays IS NULL OR [dbo].[ACC_GNTransaction].[NoOfDays] = @NoOfDays)
    AND (@HospitalID IS NULL OR [dbo].[ACC_GNTransaction].[HospitalID] = @HospitalID)
    AND (@FinYearID IS NULL OR [dbo].[ACC_GNTransaction].[FinYearID] = @FinYearID)
    AND (@ReceiptTypeID IS NULL OR [dbo].[ACC_GNTransaction].[ReceiptTypeID] = @ReceiptTypeID);

    SELECT  
        [dbo].[ACC_GNTransaction].[TransactionID],
        [dbo].[ACC_GNTransaction].[PatientID],
        [dbo].[ACC_GNTransaction].[Amount],
        [dbo].[ACC_GNTransaction].[ReferenceDoctor],
        [dbo].[ACC_GNTransaction].[Count],
        [dbo].[ACC_GNTransaction].[ReceiptNo],
        [dbo].[ACC_GNTransaction].[Date],
        [dbo].[ACC_GNTransaction].[DateOfAdmission],
        [dbo].[ACC_GNTransaction].[DateOfDischarge],
        [dbo].[ACC_GNTransaction].[Deposite],
        [dbo].[ACC_GNTransaction].[NetAmount],
        [dbo].[ACC_GNTransaction].[NoOfDays],
        [dbo].[ACC_GNTransaction].[Remarks],
		[dbo].[MST_Patient].[PatientName],
        [dbo].[MST_Hospital].[Hospital] AS [Hospital],
        [dbo].[MST_FinYear].[FinYearName] AS [FinYearName],
        [dbo].[MST_ReceiptType].[ReceiptTypeName] AS [ReceiptTypeName],
        [dbo].[SEC_User].[UserName] AS [UserName],
        [dbo].[ACC_GNTransaction].[Created],
        [dbo].[ACC_GNTransaction].[Modified],
        [dbo].[ACC_GNTransaction].[HospitalID],
        [dbo].[ACC_GNTransaction].[FinYearID],
        [dbo].[ACC_GNTransaction].[ReceiptTypeID],
        [dbo].[ACC_GNTransaction].[UserID]
    FROM [dbo].[ACC_GNTransaction]
    INNER JOIN [dbo].[MST_FinYear]
        ON [dbo].[ACC_GNTransaction].[FinYearID] = [dbo].[MST_FinYear].[FinYearID]
    INNER JOIN [dbo].[MST_Hospital]
        ON [dbo].[ACC_GNTransaction].[HospitalID] = [dbo].[MST_Hospital].[HospitalID]
    LEFT OUTER JOIN [dbo].[MST_ReceiptType]
        ON [dbo].[ACC_GNTransaction].[ReceiptTypeID] = [dbo].[MST_ReceiptType].[ReceiptTypeID]
		INNER JOIN [dbo].[MST_Patient]
        ON [dbo].[ACC_GNTransaction].[PatientID] = [dbo].[MST_Patient].[PatientID]
    INNER JOIN [dbo].[SEC_User]
        ON [dbo].[ACC_GNTransaction].[UserID] = [dbo].[SEC_User].[UserID]
    WHERE (@PatientID IS NULL OR [dbo].[ACC_GNTransaction].[PatientID] = @PatientID)
    AND (@Amount IS NULL OR [dbo].[ACC_GNTransaction].[Amount] = @Amount)
    AND (@ReferenceDoctor IS NULL OR [dbo].[ACC_GNTransaction].[ReferenceDoctor] LIKE '%' + @ReferenceDoctor + '%')
    AND (@Count IS NULL OR [dbo].[ACC_GNTransaction].[Count] = @Count)
    AND (@ReceiptNo IS NULL OR [dbo].[ACC_GNTransaction].[ReceiptNo] = @ReceiptNo)
    AND (@Date IS NULL OR [dbo].[ACC_GNTransaction].[Date] = @Date)
    AND (@DateOfAdmission IS NULL OR [dbo].[ACC_GNTransaction].[DateOfAdmission] = @DateOfAdmission)
    AND (@DateOfDischarge IS NULL OR [dbo].[ACC_GNTransaction].[DateOfDischarge] = @DateOfDischarge)
    AND (@Deposite IS NULL OR [dbo].[ACC_GNTransaction].[Deposite] = @Deposite)
    AND (@NetAmount IS NULL OR [dbo].[ACC_GNTransaction].[NetAmount] = @NetAmount)
    AND (@NoOfDays IS NULL OR [dbo].[ACC_GNTransaction].[NoOfDays] = @NoOfDays)
    AND (@HospitalID IS NULL OR [dbo].[ACC_GNTransaction].[HospitalID] = @HospitalID)
    AND (@FinYearID IS NULL OR [dbo].[ACC_GNTransaction].[FinYearID] = @FinYearID)
    AND (@ReceiptTypeID IS NULL OR [dbo].[ACC_GNTransaction].[ReceiptTypeID] = @ReceiptTypeID)
    ORDER BY [dbo].[ACC_GNTransaction].[TransactionID]
    OFFSET @PageOffset ROWS
    FETCH NEXT @PageSize ROWS ONLY;

END TRY
BEGIN CATCH
    THROW;
END CATCH;

SET @EndTime = [dbo].[GetServerDateTime]();
-- EXEC [dbo].[PR_MST_SPExecution_Insert] '[dbo].[PR_ACC_Transaction_SelectPage]', @StartTime, @EndTime;
GO

INSERT INTO [dbo].[ACC_GNTransaction] (
    [FinYearID],
    [HospitalID],
    [ReceiptTypeID],
    [Date],
    [PatientID],
    [Amount],
    [ReferenceDoctor],
    [DateOfAdmission],
    [DateOfDischarge],
    [NoOfDays],
    [Deposite],
    [NetAmount],
    [Remarks],
    [Count],
    [UserID],
    [Created],
    [Modified]
)
VALUES
    (5, 1, 2, '2024-08-02', 2, 2500.00, 'Dr. Lee', '2024-07-20', '2024-08-02', 14, 800.00, 1700.00, 'Consultation', 2, 4, GETDATE(), GETDATE()),
    (5, 1, 2, '2024-08-03', 3, 1800.00, 'Dr. Brown', '2024-07-15', '2024-08-03', 19, 600.00, 1200.00, 'Checkup', 1, 4, GETDATE(), GETDATE()),
    (5, 1, 2, '2024-08-04', 4, 2200.00, 'Dr. Wilson', '2024-07-10', '2024-08-04', 25, 750.00, 1450.00, 'Treatment', 3, 4, GETDATE(), GETDATE()),
    (5, 1, 2, '2024-08-05', 5, 2700.00, 'Dr. Taylor', '2024-07-05', '2024-08-05', 30, 900.00, 1800.00, 'Emergency', 2, 4, GETDATE(), GETDATE()),
    (5, 1, 2, '2024-08-06', 6, 1600.00, 'Dr. Green', '2024-07-01', '2024-08-06', 35, 550.00, 1050.00, 'Follow-up', 1, 4, GETDATE(), GETDATE())
    


Create   PROCEDURE [dbo].[PR_ACC_GNTransaction_SelectView]

		@TransactionID 		int

AS

SET NOCOUNT ON;

DECLARE	@StartTime	datetime
DECLARE	@EndTime	datetime
SET		@StartTime = [dbo].[GetServerDateTime]();

BEGIN TRY


SELECT  
		[dbo].[ACC_GNTransaction].[TransactionID],
		[dbo].[ACC_GNTransaction].[PatientID],
		[dbo].[MST_Patient].[PatientName] AS [Patient],
		[dbo].[ACC_GNTransaction].[Amount],
		--[dbo].[ACC_Transaction].[SerialNo],
		[dbo].[ACC_GNTransaction].[ReferenceDoctor],
		[dbo].[ACC_GNTransaction].[Count],
		[dbo].[ACC_GNTransaction].[ReceiptNo],
		[dbo].[ACC_GNTransaction].[Date],
		[dbo].[ACC_GNTransaction].[DateOfAdmission],
		[dbo].[ACC_GNTransaction].[DateOfDischarge],
		[dbo].[ACC_GNTransaction].[Deposite],
		[dbo].[ACC_GNTransaction].[NetAmount],
		[dbo].[ACC_GNTransaction].[NoOfDays],
		[dbo].[ACC_GNTransaction].[Remarks],
		[dbo].[MST_Hospital].[Hospital] AS [Hospital],
		[dbo].[MST_FinYear].[FinYearName] AS [FinYearName],
		[dbo].[MST_ReceiptType].[ReceiptTypeName] AS [ReceiptTypeName],
		[dbo].[SEC_User].[UserName] AS [UserName],
		[dbo].[ACC_GNTransaction].[Created],
		[dbo].[ACC_GNTransaction].[Modified]--,
		--[dbo].[ACC_Transaction].[TreatmentID],
		--[dbo].[ACC_Transaction].[HospitalID],
		--[dbo].[ACC_Transaction].[FinYearID],
		--[dbo].[ACC_Transaction].[ReceiptTypeID],
		--[dbo].[ACC_Transaction].[UserID]
FROM  [dbo].[ACC_GNTransaction]
INNER JOIN [dbo].[MST_FinYear]
ON [dbo].[ACC_GNTransaction].[FinYearID] = [dbo].[MST_FinYear].[FinYearID]
INNER JOIN [dbo].[MST_Hospital]
ON [dbo].[ACC_GNTransaction].[HospitalID] = [dbo].[MST_Hospital].[HospitalID]
LEFT OUTER JOIN [dbo].[MST_ReceiptType]
ON [dbo].[ACC_GNTransaction].[ReceiptTypeID] = [dbo].[MST_ReceiptType].[ReceiptTypeID]
    INNER JOIN [dbo].[MST_Patient]
        ON [dbo].[ACC_GNTransaction].[PatientID] = [dbo].[MST_Patient].[PatientID]
--INNER JOIN [dbo].[MST_Treatment]
--ON [dbo].[ACC_Transaction].[TreatmentID] = [dbo].[MST_Treatment].[TreatmentID]
INNER JOIN [dbo].[SEC_User]
ON [dbo].[ACC_GNTransaction].[UserID] = [dbo].[SEC_User].[UserID]

WHERE [dbo].[ACC_GNTransaction].[TransactionID] = @TransactionID


END TRY

BEGIN CATCH
;THROW

END CATCH

SET		@EndTime = [dbo].[GetServerDateTime]()
GO
EXEC PR_ACC_GNTransaction_SelectView  @TransactionID=6

ALTER PROCEDURE [dbo].[PR_ACC_GNTransaction_Insert]
    @TransactionID       INT OUTPUT,
    @PatientID           INT,
    @TreatmentID         INT,
    @Amount              DECIMAL(14, 2),
    @Quantity            INT,
    @ReferenceDoctor     NVARCHAR(250),
    @Count               INT,
    @ReceiptNo           INT,
    @Date                DATETIME,
    @Deposite            DECIMAL(12, 2),
    @NoOfDays            INT,
    @Remarks             NVARCHAR(500),
    @HospitalID          INT,
    @FinYearID           INT,
    @ReceiptTypeID       INT,
    @UserID              INT,
    @Created             DATETIME,
    @Modified            DATETIME
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @StartTime DATETIME;
    DECLARE @EndTime DATETIME;
    SET @StartTime = [dbo].[GetServerDateTime]();

    BEGIN TRY
        BEGIN TRAN

        DECLARE @ExistingTransactionID INT;
        DECLARE @NewTransactionID INT;
        DECLARE @CurrentNetAmount DECIMAL(14, 2);
        DECLARE @DateOfDis DATETIME;
		Declare @tranAmount  int;

        -- Calculate the amount based on quantity and rate
         set @tranAmount = @Quantity * @Amount;

        -- Check for existing transactions
        SELECT @ExistingTransactionID = TransactionID, @CurrentNetAmount = NetAmount, @DateOfDis = DateOfDischarge
        FROM [dbo].[ACC_GNTransaction]
        WHERE PatientID = @PatientID AND HospitalID = @HospitalID;

        IF @ExistingTransactionID IS NULL
        BEGIN
            -- Condition 1: No matching record, insert new record in both tables
            INSERT INTO [dbo].[ACC_GNTransaction]
            (
                [PatientID], [Amount], [ReferenceDoctor], [Count], [ReceiptNo], [Date],
                [Deposite], [NetAmount], [NoOfDays], [Remarks],
                [HospitalID], [FinYearID], [ReceiptTypeID], [UserID], [Created], [Modified],[DateOfAdmission]
            )
            VALUES
            (
                @PatientID, @Amount, @ReferenceDoctor, @Count, @ReceiptNo, @Date,
                @Deposite, @Amount, @NoOfDays, @Remarks,
                @HospitalID, @FinYearID, @ReceiptTypeID, @UserID, @Created, @Modified,GETDATE()
            );

            SET @TransactionID = SCOPE_IDENTITY();
            SET @NewTransactionID = @TransactionID;

            INSERT INTO [dbo].[ACC_GNTransactionTran]
            (
                [TransactionID], [TreatmentID], [Quantity], [Unit], [Rate], [Amount], [Remarks], [Created], [Modified], [UserID]
            )
            VALUES
            (
                @TransactionID, @TreatmentID, @Quantity, 'Unit', @Deposite, @tranAmount, NULL, @Created, @Modified, @UserID
            );

            -- Update the net amount in ACC_GNTransaction
            UPDATE [dbo].[ACC_GNTransaction]
            SET [NetAmount] = (SELECT SUM([Amount]) FROM [dbo].[ACC_GNTransactionTran] WHERE [TransactionID] = @TransactionID)
            WHERE [TransactionID] = @TransactionID;
        END
        ELSE
        BEGIN
            IF @DateOfDis IS NULL
            BEGIN
                -- Condition 2: Matching record with null discharge date, insert new record in ACC_GNTransactionTran
                INSERT INTO [dbo].[ACC_GNTransactionTran]
                (
                    [TransactionID], [TreatmentID], [Quantity], [Unit], [Rate], [Amount], [Remarks], [Created], [Modified], [UserID]
                )
                VALUES
                (
                    @ExistingTransactionID, @TreatmentID, @Quantity, 'Unit', @Deposite, @tranAmount, NULL, @Created, @Modified, @UserID
                );

                -- Update the net amount in ACC_GNTransaction
                UPDATE [dbo].[ACC_GNTransaction]
                SET [NetAmount] = (SELECT SUM([Amount]) FROM [dbo].[ACC_GNTransactionTran] WHERE [TransactionID] = @ExistingTransactionID)
                WHERE [TransactionID] = @ExistingTransactionID;

                SET @TransactionID = @ExistingTransactionID;
            END
            ELSE
            BEGIN
                -- Condition 3: Matching record with non-null discharge date, insert new record in both tables
                INSERT INTO [dbo].[ACC_GNTransaction]
                (
                    [PatientID], [Amount], [ReferenceDoctor], [Count], [ReceiptNo], [Date],
                    [Deposite], [NetAmount], [NoOfDays], [Remarks],
                    [HospitalID], [FinYearID], [ReceiptTypeID], [UserID], [Created], [Modified],[DateOfAdmission]
                )
                VALUES
                (
                    @PatientID, @Amount, @ReferenceDoctor, @Count, @ReceiptNo, @Date,
                    @Deposite, @Amount, @NoOfDays, @Remarks,
                    @HospitalID, @FinYearID, @ReceiptTypeID, @UserID, @Created, @Modified,GETDATE()
                );

                SET @TransactionID = SCOPE_IDENTITY();
                SET @NewTransactionID = @TransactionID;

                INSERT INTO [dbo].[ACC_GNTransactionTran]
                (
                    [TransactionID], [TreatmentID], [Quantity], [Unit], [Rate], [Amount], [Remarks], [Created], [Modified], [UserID]
                )
                VALUES
                (
                    @TransactionID, @TreatmentID, @Quantity, 'Unit', @Deposite, @tranAmount, NULL, @Created, @Modified, @UserID
                );

                -- Update the net amount in ACC_GNTransaction
                UPDATE [dbo].[ACC_GNTransaction]
                SET [NetAmount] = (SELECT SUM([Amount]) FROM [dbo].[ACC_GNTransactionTran] WHERE [TransactionID] = @TransactionID)
                WHERE [TransactionID] = @TransactionID;
            END
        END

        COMMIT TRAN
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
        BEGIN
            ROLLBACK TRAN
        END;
        THROW;
    END CATCH

    SET @EndTime = [dbo].[GetServerDateTime]();
    -- EXEC [dbo].[PR_MST_SPExecution_Insert] '[dbo].[PR_ACC_GNTransaction_Insert]', @StartTime, @EndTime;
END
GO


select * from ACC_GNTransaction
select * from ACC_GNTransactionTran

select * from MST_Patient

CREATE PROCEDURE PR_ACC_GNTransaction_Discharge
    @TransactionID INT
AS
BEGIN
    -- Begin transaction to ensure atomicity
    BEGIN TRANSACTION;

    BEGIN TRY
        -- Update the discharge date and calculate the number of days
        UPDATE ACC_GNTransaction
        SET 
            DateOfDischarge = GETDATE(),
            NoOfDays = DATEDIFF(DAY, dbo.ACC_GNTransaction.DateOfAdmission, Getdate())
        WHERE 
            TransactionID = @TransactionID;

        -- Commit the transaction if everything is successful
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        -- Rollback the transaction if an error occurs
        ROLLBACK TRANSACTION;

        -- Capture and raise the error message
        DECLARE @ErrorMessage NVARCHAR(4000);
        SET @ErrorMessage = ERROR_MESSAGE();
        RAISERROR (@ErrorMessage, 16, 1);
    END CATCH;
END;
GO
