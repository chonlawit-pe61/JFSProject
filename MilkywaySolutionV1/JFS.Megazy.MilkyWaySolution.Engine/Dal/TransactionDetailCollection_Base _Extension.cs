using Microsoft.Security.Application;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.Data;
using System.Collections;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;
namespace JFS.Megazy.MilkyWaySolution.Engine.Dal
{
	
	public partial class TransactionDetailCollection_Base : MarshalByRefObject
	{
        public int GetMaxID()
        {
            string sql = "Select ISNULL(MAX(TransactionDetailID),0) AS ID From TransactionDetail";
            SqlCommand command = CreateCommand(sql);
            DataTable dt = CreateDataTable(command);
            return Convert.ToInt32(dt.Rows[0][0]);
        }
        public int GetMaxTransactionNo()
        {
            string sql = "SELECT COUNT(TransactionID) from [Transaction] Where TransactionNo IS NOT NULL AND TransactionNo != ''";
            SqlCommand command = CreateCommand(sql);
            DataTable dt = CreateDataTable(command);
            return Convert.ToInt32(dt.Rows[0][0]);
        }
    }
}

