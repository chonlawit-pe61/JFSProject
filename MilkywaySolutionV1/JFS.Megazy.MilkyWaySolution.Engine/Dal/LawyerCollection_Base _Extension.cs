using Microsoft.Security.Application;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.Data;
using System.Collections;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;
namespace JFS.Megazy.MilkyWaySolution.Engine.Dal
{
	
	public partial class LawyerCollection_Base : MarshalByRefObject
	{
        public int GetMaxID()
        {
            string sql = "Select ISNULL(MAX(LawyerID),0) AS ID From Lawyer";
            SqlCommand command = CreateCommand(sql);
            DataTable dt = CreateDataTable(command);
            return Convert.ToInt32(dt.Rows[0][0]);
        }
    }
}

