using System;
using System.Data.SqlTypes;

namespace GNForm3C.ENT
{
    public abstract class MST_PatientENTBase
    {
        #region Properties

        protected SqlInt32 _PatientID;
        public SqlInt32 PatientID
        {
            get
            {
                return _PatientID;
            }
            set
            {
                _PatientID = value;
            }
        }

        protected SqlString _PatientName;
        public SqlString PatientName
        {
            get
            {
                return _PatientName;
            }
            set
            {
                _PatientName = value;
            }
        }

        protected SqlInt32 _Age;
        public SqlInt32 Age
        {
            get
            {
                return _Age;
            }
            set
            {
                _Age = value;
            }
        }

        protected SqlDateTime _DOB;
        public SqlDateTime DOB
        {
            get
            {
                return _DOB;
            }
            set
            {
                _DOB = value;
            }
        }

        protected SqlString _MobileNo;
        public SqlString MobileNo
        {
            get
            {
                return _MobileNo;
            }
            set
            {
                _MobileNo = value;
            }
        }

        protected SqlString _PrimaryDesc;
        public SqlString PrimaryDesc
        {
            get
            {
                return _PrimaryDesc;
            }
            set
            {
                _PrimaryDesc = value;
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

        public MST_PatientENTBase()
        {

        }

        #endregion Constructor

        #region ToString

        public override String ToString()
        {
            String MST_PatientENT_String = String.Empty;

            if (!PatientID.IsNull)
                MST_PatientENT_String += " PatientID = " + PatientID.Value.ToString();

            if (!PatientName.IsNull)
                MST_PatientENT_String += "| PatientName = " + PatientName.Value;

            if (!Age.IsNull)
                MST_PatientENT_String += "| Age = " + Age.Value.ToString();

            if (!DOB.IsNull)
                MST_PatientENT_String += "| DOB = " + DOB.Value.ToString("dd-MM-yyyy");

            if (!MobileNo.IsNull)
                MST_PatientENT_String += "| MobileNo = " + MobileNo.Value;

            if (!PrimaryDesc.IsNull)
                MST_PatientENT_String += "| PrimaryDesc = " + PrimaryDesc.Value;

            if (!UserID.IsNull)
                MST_PatientENT_String += "| UserID = " + UserID.Value.ToString();

            if (!Created.IsNull)
                MST_PatientENT_String += "| Created = " + Created.Value.ToString("dd-MM-yyyy");

            if (!Modified.IsNull)
                MST_PatientENT_String += "| Modified = " + Modified.Value.ToString("dd-MM-yyyy");

            MST_PatientENT_String = MST_PatientENT_String.Trim();

            return MST_PatientENT_String;
        }

        #endregion ToString
    }
}