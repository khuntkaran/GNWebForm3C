using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using GNForm3C.DAL;
using GNForm3C;

namespace GNForm3C.BAL
{
	public class SEC_UserBAL : SEC_UserBALBase
	{
        public DataTable SelectByUserNameAndPassword(SqlString UserName, SqlString Password)
        {
            SEC_UserDAL dalSEC_User = new SEC_UserDAL();
            return dalSEC_User.SelectByUserNameAndPassword(UserName, Password);
        }
	}

}