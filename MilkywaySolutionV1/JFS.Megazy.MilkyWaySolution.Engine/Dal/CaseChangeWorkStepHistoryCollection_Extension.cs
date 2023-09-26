using Microsoft.Security.Application;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.Data;
using System.Collections;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;
namespace JFS.Megazy.MilkyWaySolution.Engine.Dal
{

	public partial class CaseChangeWorkStepHistoryCollection_Base : MarshalByRefObject
	{
		public bool Update(CaseChangeWorkStepHistoryRow value, bool IsPrimarykeyIdentity)
		{
			IDbCommand cmd = null;
			if (value._IsSetCaseID == true && value._IsSetWorkStepID == true && value._IsSetUserID == true && value._IsSetDepartmentID == true && value._IsSetChangeDate == true)
			{
				string strUpdate = string.Empty;
				if (value._IsSetComment)
				{
					strUpdate += "[Comment]=" + CreateSqlParameterName("Comment") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[CaseChangeWorkStepHistory] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[CaseID]=" + CreateSqlParameterName("CaseID") + " AND [WorkStepID]=" + CreateSqlParameterName("WorkStepID") + " AND [UserID]=" + CreateSqlParameterName("UserID") + " AND [DepartmentID]=" + CreateSqlParameterName("DepartmentID") + " AND [ChangeDate]=" + CreateSqlParameterName("ChangeDate");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "CaseID", value.CaseID);
					AddParameter(cmd, "WorkStepID", value.WorkStepID);
					AddParameter(cmd, "UserID", value.UserID);
					AddParameter(cmd, "DepartmentID", value.DepartmentID);
					AddParameter(cmd, "ChangeDate", value.IsChangeDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.ChangeDate);
					AddParameter(cmd, "Comment", value.Comment);
					//AddParameter(cmd, "RowID", value.RowID);
					AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(CaseID,WorkStepID,UserID,DepartmentID,ChangeDate)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(CaseChangeWorkStepHistoryRow value, bool IsPrimarykeyIdentity)
		{
			IDbCommand cmd = null;
			if (value._IsSetCaseID == true && value._IsSetWorkStepID == true && value._IsSetUserID == true && value._IsSetDepartmentID == true && value._IsSetChangeDate == true)
			{
				string strUpdate = string.Empty;
				if (value._IsSetComment)
				{
					strUpdate += "[Comment]=" + CreateSqlParameterName("Comment") + ",";
				}
				//if (value._IsSetRowID)
				//{
				//	strUpdate += "[RowID]=" + CreateSqlParameterName("RowID") + ",";
				//}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[CaseChangeWorkStepHistory] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[CaseID]=" + CreateSqlParameterName("CaseID") + " AND [WorkStepID]=" + CreateSqlParameterName("WorkStepID") + " AND [UserID]=" + CreateSqlParameterName("UserID") + " AND [DepartmentID]=" + CreateSqlParameterName("DepartmentID") + " AND [ChangeDate]=" + CreateSqlParameterName("ChangeDate");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "CaseID", value.CaseID);
					AddParameter(cmd, "WorkStepID", value.WorkStepID);
					AddParameter(cmd, "UserID", value.UserID);
					AddParameter(cmd, "DepartmentID", value.DepartmentID);
					AddParameter(cmd, "ChangeDate", value.IsChangeDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.ChangeDate);
					AddParameter(cmd, "Comment", Sanitizer.GetSafeHtmlFragment(value.Comment));
					//AddParameter(cmd, "RowID", value.RowID);
					AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(CaseID,WorkStepID,UserID,DepartmentID,ChangeDate)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}

	}
}

