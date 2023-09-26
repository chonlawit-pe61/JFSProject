using Microsoft.Security.Application;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.Data;
using System.Collections;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;
namespace JFS.Megazy.MilkyWaySolution.Engine.Dal
{
	
	public partial class ScoreTopicCollection_Base
	{

        public int GetMaxID()
        {
            string sql = "Select ISNULL(MAX(TopicID),0) AS ID From ScoreTopic";
            SqlCommand command = CreateCommand(sql);
            DataTable dt = CreateDataTable(command);
            return Convert.ToInt32(dt.Rows[0][0]);
        }
    }
}

