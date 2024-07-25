using System;
using System.Data.SqlTypes;

namespace GNForm3C.ENT
{
	public abstract class ACC_TransactionENTBase
	{
		#region Properties


		protected SqlInt32 _TransactionID;
		public SqlInt32 TransactionID
		{
			get
			{
				return _TransactionID;
			}
			set
			{
				_TransactionID = value;
			}
		}

		protected SqlString _Patient;
		public SqlString Patient
		{
			get
			{
				return _Patient;
			}
			set
			{
				_Patient = value;
			}
		}

		protected SqlInt32 _TreatmentID;
		public SqlInt32 TreatmentID
		{
			get
			{
				return _TreatmentID;
			}
			set
			{
				_TreatmentID = value;
			}
		}

		protected SqlDecimal _Amount;
		public SqlDecimal Amount
		{
			get
			{
				return _Amount;
			}
			set
			{
				_Amount = value;
			}
		}

		protected SqlInt32 _SerialNo;
		public SqlInt32 SerialNo
		{
			get
			{
				return _SerialNo;
			}
			set
			{
				_SerialNo = value;
			}
		}

		protected SqlString _ReferenceDoctor;
		public SqlString ReferenceDoctor
		{
			get
			{
				return _ReferenceDoctor;
			}
			set
			{
				_ReferenceDoctor = value;
			}
		}

		protected SqlInt32 _Count;
		public SqlInt32 Count
		{
			get
			{
				return _Count;
			}
			set
			{
				_Count = value;
			}
		}

		protected SqlInt32 _ReceiptNo;
		public SqlInt32 ReceiptNo
		{
			get
			{
				return _ReceiptNo;
			}
			set
			{
				_ReceiptNo = value;
			}
		}

		protected SqlDateTime _Date;
		public SqlDateTime Date
		{
			get
			{
				return _Date;
			}
			set
			{
				_Date = value;
			}
		}

		protected SqlDateTime _DateOfAdmission;
		public SqlDateTime DateOfAdmission
		{
			get
			{
				return _DateOfAdmission;
			}
			set
			{
				_DateOfAdmission = value;
			}
		}

		protected SqlDateTime _DateOfDischarge;
		public SqlDateTime DateOfDischarge
		{
			get
			{
				return _DateOfDischarge;
			}
			set
			{
				_DateOfDischarge = value;
			}
		}

		protected SqlDecimal _Deposite;
		public SqlDecimal Deposite
		{
			get
			{
				return _Deposite;
			}
			set
			{
				_Deposite = value;
			}
		}

		protected SqlDecimal _NetAmount;
		public SqlDecimal NetAmount
		{
			get
			{
				return _NetAmount;
			}
			set
			{
				_NetAmount = value;
			}
		}

		protected SqlInt32 _NoOfDays;
		public SqlInt32 NoOfDays
		{
			get
			{
				return _NoOfDays;
			}
			set
			{
				_NoOfDays = value;
			}
		}

		protected SqlString _Remarks;
		public SqlString Remarks
		{
			get
			{
				return _Remarks;
			}
			set
			{
				_Remarks = value;
			}
		}

		protected SqlInt32 _HospitalID;
		public SqlInt32 HospitalID
		{
			get
			{
				return _HospitalID;
			}
			set
			{
				_HospitalID = value;
			}
		}

		protected SqlInt32 _FinYearID;
		public SqlInt32 FinYearID
		{
			get
			{
				return _FinYearID;
			}
			set
			{
				_FinYearID = value;
			}
		}

		protected SqlInt32 _ReceiptTypeID;
		public SqlInt32 ReceiptTypeID
		{
			get
			{
				return _ReceiptTypeID;
			}
			set
			{
				_ReceiptTypeID = value;
			}
		}

		protected SqlInt32 _UserID;
		public SqlInt32 UserID
		{
			get
			{
				return _UserID;
			}
			set
			{
				_UserID = value;
			}
		}

		protected SqlDateTime _Created;
		public SqlDateTime Created
		{
			get
			{
				return _Created;
			}
			set
			{
				_Created = value;
			}
		}

		protected SqlDateTime _Modified;
		public SqlDateTime Modified
		{
			get
			{
				return _Modified;
			}
			set
			{
				_Modified = value;
			}
		}

		#endregion Properties

		#region Constructor

		public ACC_TransactionENTBase()
		{

		}

		#endregion Constructor

		#region ToString

		public override String ToString()
		{
			String ACC_TransactionENT_String = String.Empty;

			if(!TransactionID.IsNull)
				ACC_TransactionENT_String += " TransactionID = " + TransactionID.Value.ToString();

			if(!Patient.IsNull)
				ACC_TransactionENT_String += "| Patient = " + Patient.Value;

			if(!TreatmentID.IsNull)
				ACC_TransactionENT_String += "| TreatmentID = " + TreatmentID.Value.ToString();

			if(!Amount.IsNull)
				ACC_TransactionENT_String += "| Amount = " + Amount.Value.ToString();

			if(!SerialNo.IsNull)
				ACC_TransactionENT_String += "| SerialNo = " + SerialNo.Value.ToString();

			if(!ReferenceDoctor.IsNull)
				ACC_TransactionENT_String += "| ReferenceDoctor = " + ReferenceDoctor.Value;

			if(!Count.IsNull)
				ACC_TransactionENT_String += "| Count = " + Count.Value.ToString();

			if(!ReceiptNo.IsNull)
				ACC_TransactionENT_String += "| ReceiptNo = " + ReceiptNo.Value.ToString();

			if(!Date.IsNull)
				ACC_TransactionENT_String += "| Date = " + Date.Value.ToString("dd-MM-yyyy");

			if(!DateOfAdmission.IsNull)
				ACC_TransactionENT_String += "| DateOfAdmission = " + DateOfAdmission.Value.ToString("dd-MM-yyyy");

			if(!DateOfDischarge.IsNull)
				ACC_TransactionENT_String += "| DateOfDischarge = " + DateOfDischarge.Value.ToString("dd-MM-yyyy");

			if(!Deposite.IsNull)
				ACC_TransactionENT_String += "| Deposite = " + Deposite.Value.ToString();

			if(!NetAmount.IsNull)
				ACC_TransactionENT_String += "| NetAmount = " + NetAmount.Value.ToString();

			if(!NoOfDays.IsNull)
				ACC_TransactionENT_String += "| NoOfDays = " + NoOfDays.Value.ToString();

			if(!Remarks.IsNull)
				ACC_TransactionENT_String += "| Remarks = " + Remarks.Value;

			if(!HospitalID.IsNull)
				ACC_TransactionENT_String += "| HospitalID = " + HospitalID.Value.ToString();

			if(!FinYearID.IsNull)
				ACC_TransactionENT_String += "| FinYearID = " + FinYearID.Value.ToString();

			if(!ReceiptTypeID.IsNull)
				ACC_TransactionENT_String += "| ReceiptTypeID = " + ReceiptTypeID.Value.ToString();

			if(!UserID.IsNull)
				ACC_TransactionENT_String += "| UserID = " + UserID.Value.ToString();

			if(!Created.IsNull)
				ACC_TransactionENT_String += "| Created = " + Created.Value.ToString("dd-MM-yyyy");

			if(!Modified.IsNull)
				ACC_TransactionENT_String += "| Modified = " + Modified.Value.ToString("dd-MM-yyyy");


			ACC_TransactionENT_String = ACC_TransactionENT_String.Trim();

			return ACC_TransactionENT_String;
		}

		#endregion ToString

	}

}