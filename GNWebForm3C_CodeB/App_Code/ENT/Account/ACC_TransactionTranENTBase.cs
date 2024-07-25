using System;
using System.Data.SqlTypes;

namespace GNForm3C.ENT
{
	public abstract class ACC_TransactionTranENTBase
	{
		#region Properties


		protected SqlInt32 _TransactionTranID;
		public SqlInt32 TransactionTranID
		{
			get
			{
				return _TransactionTranID;
			}
			set
			{
				_TransactionTranID = value;
			}
		}

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

		protected SqlInt32 _SubTreatmentID;
		public SqlInt32 SubTreatmentID
		{
			get
			{
				return _SubTreatmentID;
			}
			set
			{
				_SubTreatmentID = value;
			}
		}

		protected SqlInt32 _Quantity;
		public SqlInt32 Quantity
		{
			get
			{
				return _Quantity;
			}
			set
			{
				_Quantity = value;
			}
		}

		protected SqlString _Unit;
		public SqlString Unit
		{
			get
			{
				return _Unit;
			}
			set
			{
				_Unit = value;
			}
		}

		protected SqlDecimal _Rate;
		public SqlDecimal Rate
		{
			get
			{
				return _Rate;
			}
			set
			{
				_Rate = value;
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

		public ACC_TransactionTranENTBase()
		{

		}

		#endregion Constructor

		#region ToString

		public override String ToString()
		{
			String ACC_TransactionTranENT_String = String.Empty;

			if(!TransactionTranID.IsNull)
				ACC_TransactionTranENT_String += " TransactionTranID = " + TransactionTranID.Value.ToString();

			if(!TransactionID.IsNull)
				ACC_TransactionTranENT_String += "| TransactionID = " + TransactionID.Value.ToString();

			if(!SubTreatmentID.IsNull)
				ACC_TransactionTranENT_String += "| SubTreatmentID = " + SubTreatmentID.Value.ToString();

			if(!Quantity.IsNull)
				ACC_TransactionTranENT_String += "| Quantity = " + Quantity.Value.ToString();

			if(!Unit.IsNull)
				ACC_TransactionTranENT_String += "| Unit = " + Unit.Value;

			if(!Rate.IsNull)
				ACC_TransactionTranENT_String += "| Rate = " + Rate.Value.ToString();

			if(!Amount.IsNull)
				ACC_TransactionTranENT_String += "| Amount = " + Amount.Value.ToString();

			if(!Remarks.IsNull)
				ACC_TransactionTranENT_String += "| Remarks = " + Remarks.Value;

			if(!UserID.IsNull)
				ACC_TransactionTranENT_String += "| UserID = " + UserID.Value.ToString();

			if(!Created.IsNull)
				ACC_TransactionTranENT_String += "| Created = " + Created.Value.ToString("dd-MM-yyyy");

			if(!Modified.IsNull)
				ACC_TransactionTranENT_String += "| Modified = " + Modified.Value.ToString("dd-MM-yyyy");


			ACC_TransactionTranENT_String = ACC_TransactionTranENT_String.Trim();

			return ACC_TransactionTranENT_String;
		}

		#endregion ToString

	}

}