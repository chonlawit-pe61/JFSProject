using Microsoft.Security.Application;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.Data;
using System.Collections;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;
namespace JFS.Megazy.MilkyWaySolution.Engine.Dal
{
	[Serializable]
	public partial class CaseChangeWorkStepHistoryCollection_Base : MarshalByRefObject
	{
		public const string CaseIDColumnName = "CaseID";
		public const string WorkStepIDColumnName = "WorkStepID";
		public const string UserIDColumnName = "UserID";
		public const string DepartmentIDColumnName = "DepartmentID";
		public const string ChangeDateColumnName = "ChangeDate";
		public const string CommentColumnName = "Comment";
		public const string RowIDColumnName = "RowID";
		public const string ModifiedDateColumnName = "ModifiedDate";
		private int _processID;
		public SqlCommand cmd = null;
		public CaseChangeWorkStepHistoryCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual CaseChangeWorkStepHistoryRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}
		public int Delete(string whereSql)
		{
			return CreateDeleteCommand(whereSql).ExecuteNonQuery();
		}
		protected virtual SqlCommand CreateGetCommand(string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "SELECT "+
			"[CaseID],"+
			"[WorkStepID],"+
			"[UserID],"+
			"[DepartmentID],"+
			"[ChangeDate],"+
			"[Comment],"+
			"[RowID],"+
			"[ModifiedDate]"+
			" FROM [dbo].[CaseChangeWorkStepHistory]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[CaseChangeWorkStepHistory]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "CaseChangeWorkStepHistory"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("CaseID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("WorkStepID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("UserID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DepartmentID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ChangeDate",Type.GetType("System.DateTime"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("Comment",Type.GetType("System.String"));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("RowID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			return dataTable;
		}
		public virtual CaseChangeWorkStepHistoryRow[] GetByCaseID(int caseID)
		{
			return MapRecords(CreateGetByCaseIDCommand(caseID));
		}
		public virtual DataTable GetByCaseIDAsDataTable(int caseID)
		{
			return MapRecordsToDataTable(CreateGetByCaseIDCommand(caseID));
		}
		protected virtual IDbCommand CreateGetByCaseIDCommand(int caseID)
		{
			string whereSql = "";
			whereSql += "[CaseID]=" + CreateSqlParameterName("CaseID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CaseID", caseID);
			return cmd;
		}
		public virtual CaseChangeWorkStepHistoryRow[] GetByWorkStepID(int workStepID)
		{
			return MapRecords(CreateGetByWorkStepIDCommand(workStepID));
		}
		public virtual DataTable GetByWorkStepIDAsDataTable(int workStepID)
		{
			return MapRecordsToDataTable(CreateGetByWorkStepIDCommand(workStepID));
		}
		protected virtual IDbCommand CreateGetByWorkStepIDCommand(int workStepID)
		{
			string whereSql = "";
			whereSql += "[WorkStepID]=" + CreateSqlParameterName("WorkStepID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "WorkStepID", workStepID);
			return cmd;
		}
		public virtual CaseChangeWorkStepHistoryRow[] GetByUserID(int userID)
		{
			return MapRecords(CreateGetByUserIDCommand(userID));
		}
		public virtual DataTable GetByUserIDAsDataTable(int userID)
		{
			return MapRecordsToDataTable(CreateGetByUserIDCommand(userID));
		}
		protected virtual IDbCommand CreateGetByUserIDCommand(int userID)
		{
			string whereSql = "";
			whereSql += "[UserID]=" + CreateSqlParameterName("UserID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "UserID", userID);
			return cmd;
		}
		public CaseChangeWorkStepHistoryRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual CaseChangeWorkStepHistoryRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="CaseChangeWorkStepHistoryRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CaseChangeWorkStepHistoryRow"/> objects.</returns>
		public virtual CaseChangeWorkStepHistoryRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[CaseChangeWorkStepHistory]", top);
			if (null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, 0, top, ref totalRecordCount);
			}
		}
		public CaseChangeWorkStepHistoryRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			CaseChangeWorkStepHistoryRow[] rows = null;
			SqlCommand command = CreateGetCommand(whereSql, "");
			command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				rows = MapRecords(reader, 0, 1, ref totalRecordCount);
			}
			return 0 == rows.Length ? null : rows[0];
		}
		public DataTable GetAsDataTable(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsDataTable(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public DataTable GetAsDataTable(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecordsToDataTable(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// เรียกข้อมูลในตารางมีคอลัมน์ทั้งหมดและเพิ่มเติมมี RowRank,totalRow,totalPage 
		/// </summary>
		/// <param name="whereSql"></param>
		/// <param name="startRowIndex"></param>
		/// <param name="rowPerPage"></param>
		/// <param name="orderBySql"></param>
		/// <returns></returns>
		public DataTable GetCaseChangeWorkStepHistoryPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "CaseID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "CaseID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(1) AS TotalRow FROM [dbo].[CaseChangeWorkStepHistory] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,CaseID,WorkStepID,UserID,DepartmentID,ChangeDate,Comment,RowID,ModifiedDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT [CaseChangeWorkStepHistory].*, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[CaseChangeWorkStepHistory] " + whereSql +
		" ) AS AllWithRowRank " +
		"  WHERE RowRank >" + startRowIndex + "  AND RowRank  <= " + (startRowIndex + rowPerPage) + wherePaging;
		 command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		dt = CreateDataTable(command);
		return dt;
		}
		/// <summary>
		/// เรียกข้อมูลในตารางมีคอลัมน์ทั้งหมดและเพิ่มเติมมี RowRank,totalRow,totalPage 
		/// </summary>
		/// <param name="whereSql"></param>
		/// <param name="startRowIndex"></param>
		/// <param name="rowPerPage"></param>
		/// <param name="orderBySql"></param>
		/// <returns></returns>
		public CaseChangeWorkStepHistoryItemsPaging GetCaseChangeWorkStepHistoryPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "CaseID")
		{
		CaseChangeWorkStepHistoryItemsPaging obj = new CaseChangeWorkStepHistoryItemsPaging();
		DataTable dt = GetCaseChangeWorkStepHistoryPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		CaseChangeWorkStepHistoryItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new CaseChangeWorkStepHistoryItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.CaseID = Convert.ToInt32(dt.Rows[i]["CaseID"]);
			record.WorkStepID = Convert.ToInt32(dt.Rows[i]["WorkStepID"]);
			record.UserID = Convert.ToInt32(dt.Rows[i]["UserID"]);
			record.DepartmentID = Convert.ToInt32(dt.Rows[i]["DepartmentID"]);
			record.ChangeDate = Convert.ToDateTime(dt.Rows[i]["ChangeDate"]);
			record.Comment = dt.Rows[i]["Comment"].ToString();
			record.RowID = Convert.ToInt32(dt.Rows[i]["RowID"]);
			if (dt.Rows[i]["ModifiedDate"] != DBNull.Value)
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			recordList.Add(record);
		}
		obj.casechangeWorkStepHistoryItems = (CaseChangeWorkStepHistoryItems[])(recordList.ToArray(typeof(CaseChangeWorkStepHistoryItems)));
		return obj;
		}
		public CaseChangeWorkStepHistoryRow GetByPrimaryKey(int caseID, int workStepID, int userID, int departmentId, DateTime changeDate)
		{
			string whereSql = "[CaseID]=" + CreateSqlParameterName("CaseID") + " AND [WorkStepID]=" + CreateSqlParameterName("WorkStepID") + " AND [UserID]=" + CreateSqlParameterName("UserID") + " AND [DepartmentID]=" + CreateSqlParameterName("DepartmentID") + " AND [ChangeDate]=" + CreateSqlParameterName("ChangeDate");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CaseID", caseID);
			AddParameter(cmd, "WorkStepID", workStepID);
			AddParameter(cmd, "UserID", userID);
			AddParameter(cmd, "DepartmentID", departmentId);
			AddParameter(cmd, "ChangeDate", changeDate);
			CaseChangeWorkStepHistoryRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public void Insert(CaseChangeWorkStepHistoryRow value)		{
			string sqlStr = "INSERT INTO [dbo].[CaseChangeWorkStepHistory] (" +
			"[CaseID], " + 
			"[WorkStepID], " + 
			"[UserID], " + 
			"[DepartmentID], " + 
			"[ChangeDate], " + 
			"[Comment], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("CaseID") + ", " +
			CreateSqlParameterName("WorkStepID") + ", " +
			CreateSqlParameterName("UserID") + ", " +
			CreateSqlParameterName("DepartmentID") + ", " +
			CreateSqlParameterName("ChangeDate") + ", " +
			CreateSqlParameterName("Comment") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "CaseID", value.CaseID);
			AddParameter(cmd, "WorkStepID", value.WorkStepID);
			AddParameter(cmd, "UserID", value.UserID);
			AddParameter(cmd, "DepartmentID", value.DepartmentID);
			AddParameter(cmd, "ChangeDate", value.IsChangeDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.ChangeDate);
			AddParameter(cmd, "Comment", value.Comment);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public void InsertOnlyPlainText(CaseChangeWorkStepHistoryRow value)		{
			string sqlStr = "INSERT INTO [dbo].[CaseChangeWorkStepHistory] (" +
			"[CaseID], " + 
			"[WorkStepID], " + 
			"[UserID], " + 
			"[DepartmentID], " + 
			"[ChangeDate], " + 
			"[Comment], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("CaseID") + ", " +
			CreateSqlParameterName("WorkStepID") + ", " +
			CreateSqlParameterName("UserID") + ", " +
			CreateSqlParameterName("DepartmentID") + ", " +
			CreateSqlParameterName("ChangeDate") + ", " +
			CreateSqlParameterName("Comment") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "CaseID", value.CaseID);
			AddParameter(cmd, "WorkStepID", value.WorkStepID);
			AddParameter(cmd, "UserID", value.UserID);
			AddParameter(cmd, "DepartmentID", value.DepartmentID);
			AddParameter(cmd, "ChangeDate", value.IsChangeDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.ChangeDate);
			AddParameter(cmd, "Comment", Sanitizer.GetSafeHtmlFragment(value.Comment));
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public bool Update(CaseChangeWorkStepHistoryRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetCaseID == true && value._IsSetWorkStepID == true && value._IsSetUserID == true && value._IsSetDepartmentID == true && value._IsSetChangeDate == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetComment)
				{
					strUpdate += "[Comment]=" + CreateSqlParameterName("Comment") + ",";
				}
				if (value._IsSetRowID)
				{
					strUpdate += "[RowID]=" + CreateSqlParameterName("RowID") + ",";
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
					strUpdate += "[CaseID]=" + CreateSqlParameterName("CaseID")+ " AND [WorkStepID]=" + CreateSqlParameterName("WorkStepID")+ " AND [UserID]=" + CreateSqlParameterName("UserID")+ " AND [DepartmentID]=" + CreateSqlParameterName("DepartmentID")+ " AND [ChangeDate]=" + CreateSqlParameterName("ChangeDate");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "CaseID", value.CaseID);
					AddParameter(cmd, "WorkStepID", value.WorkStepID);
					AddParameter(cmd, "UserID", value.UserID);
					AddParameter(cmd, "DepartmentID", value.DepartmentID);
					AddParameter(cmd, "ChangeDate", value.IsChangeDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.ChangeDate);
					AddParameter(cmd, "Comment", value.Comment);
					AddParameter(cmd, "RowID", value.RowID);
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
		public bool UpdateOnlyPlainText(CaseChangeWorkStepHistoryRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetCaseID == true && value._IsSetWorkStepID == true && value._IsSetUserID == true && value._IsSetDepartmentID == true && value._IsSetChangeDate == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetComment)
				{
					strUpdate += "[Comment]=" + CreateSqlParameterName("Comment") + ",";
				}
				if (value._IsSetRowID)
				{
					strUpdate += "[RowID]=" + CreateSqlParameterName("RowID") + ",";
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
					strUpdate += "[CaseID]=" + CreateSqlParameterName("CaseID")+ " AND [WorkStepID]=" + CreateSqlParameterName("WorkStepID")+ " AND [UserID]=" + CreateSqlParameterName("UserID")+ " AND [DepartmentID]=" + CreateSqlParameterName("DepartmentID")+ " AND [ChangeDate]=" + CreateSqlParameterName("ChangeDate");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "CaseID", value.CaseID);
					AddParameter(cmd, "WorkStepID", value.WorkStepID);
					AddParameter(cmd, "UserID", value.UserID);
					AddParameter(cmd, "DepartmentID", value.DepartmentID);
					AddParameter(cmd, "ChangeDate", value.IsChangeDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.ChangeDate);
					AddParameter(cmd, "Comment", Sanitizer.GetSafeHtmlFragment(value.Comment));
					AddParameter(cmd, "RowID", value.RowID);
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
		public bool DeleteByPrimaryKey(int caseID, int workStepID, int userID, int departmentId, DateTime changeDate)
		{
			string whereSql = "[CaseID]=" + CreateSqlParameterName("CaseID") + " AND [WorkStepID]=" + CreateSqlParameterName("WorkStepID") + " AND [UserID]=" + CreateSqlParameterName("UserID") + " AND [DepartmentID]=" + CreateSqlParameterName("DepartmentID") + " AND [ChangeDate]=" + CreateSqlParameterName("ChangeDate");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CaseID", caseID);
			AddParameter(cmd, "WorkStepID", workStepID);
			AddParameter(cmd, "UserID", userID);
			AddParameter(cmd, "DepartmentID", departmentId);
			AddParameter(cmd, "ChangeDate", changeDate);
			return 0 < cmd.ExecuteNonQuery();
		}
		public int DeleteByCaseID(int caseID)
		{
			return CreateDeleteByCaseIDCommand(caseID).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByCaseIDCommand(int caseID)
		{
			string whereSql = "";
			whereSql += "[CaseID]=" + CreateSqlParameterName("CaseID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CaseID", caseID);
			return cmd;
		}
		public int DeleteByWorkStepID(int workStepID)
		{
			return CreateDeleteByWorkStepIDCommand(workStepID).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByWorkStepIDCommand(int workStepID)
		{
			string whereSql = "";
			whereSql += "[WorkStepID]=" + CreateSqlParameterName("WorkStepID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "WorkStepID", workStepID);
			return cmd;
		}
		public int DeleteByUserID(int userID)
		{
			return CreateDeleteByUserIDCommand(userID).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByUserIDCommand(int userID)
		{
			string whereSql = "";
			whereSql += "[UserID]=" + CreateSqlParameterName("UserID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "UserID", userID);
			return cmd;
		}
		protected CaseChangeWorkStepHistoryRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected CaseChangeWorkStepHistoryRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected CaseChangeWorkStepHistoryRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int caseIDColumnIndex = reader.GetOrdinal("CaseID");
			int workStepIDColumnIndex = reader.GetOrdinal("WorkStepID");
			int userIDColumnIndex = reader.GetOrdinal("UserID");
			int departmentIdColumnIndex = reader.GetOrdinal("DepartmentID");
			int changeDateColumnIndex = reader.GetOrdinal("ChangeDate");
			int commentColumnIndex = reader.GetOrdinal("Comment");
			int rowIDColumnIndex = reader.GetOrdinal("RowID");
			int modifiedDateColumnIndex = reader.GetOrdinal("ModifiedDate");
			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			int countRecordRow = 0;
			while (reader.Read())
			{
				countRecordRow++;
				ri++;
				if (ri > 0 && ri <= length)
				{
					CaseChangeWorkStepHistoryRow record = new CaseChangeWorkStepHistoryRow();
					recordList.Add(record);
					record.CaseID =  Convert.ToInt32(reader.GetValue(caseIDColumnIndex));
					record.WorkStepID =  Convert.ToInt32(reader.GetValue(workStepIDColumnIndex));
					record.UserID =  Convert.ToInt32(reader.GetValue(userIDColumnIndex));
					record.DepartmentID =  Convert.ToInt32(reader.GetValue(departmentIdColumnIndex));
					record.ChangeDate =  Convert.ToDateTime(reader.GetValue(changeDateColumnIndex));
					if (!reader.IsDBNull(commentColumnIndex)) record.Comment =  Convert.ToString(reader.GetValue(commentColumnIndex));

					record.RowID =  Convert.ToInt32(reader.GetValue(rowIDColumnIndex));
					if (!reader.IsDBNull(modifiedDateColumnIndex)) record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CaseChangeWorkStepHistoryRow[])(recordList.ToArray(typeof(CaseChangeWorkStepHistoryRow)));
		}
		protected DataTable MapRecordsToDataTable(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecordsToDataTable(reader);
			}
		}
		protected DataTable MapRecordsToDataTable(IDataReader reader)
		{
			int totalRecordCount = 0;
			return MapRecordsToDataTable(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected virtual DataTable MapRecordsToDataTable(IDataReader reader, int startIndex, int length, ref int totalRecordCount)
		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int columnCount = reader.FieldCount;
			int ri = -startIndex;
			DataTable dataTable = CreateDataTable();
			dataTable.BeginLoadData();
			object[] values = new object[columnCount];
			while (reader.Read())
			{
				ri++;
				if (ri > 0 && ri <= length)
				{
					reader.GetValues(values);
					dataTable.LoadDataRow(values, true);
					if (ri == length && 0 != totalRecordCount)
					break;
				}
			}
			dataTable.EndLoadData();
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return dataTable;
		}
		protected virtual IDbDataParameter AddParameter(IDbCommand cmd, string paramName, object value)
		{
			IDbDataParameter parameter;
			switch (paramName)
			{
				case "CaseID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "WorkStepID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "UserID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "DepartmentID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ChangeDate":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "Comment":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "RowID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ModifiedDate":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
		public IDataReader ExecuteReader(IDbCommand command)
		{
			return command.ExecuteReader();
		}
		public SqlCommand CreateCommand(string sqlText)
		{
			return CreateCommand(sqlText, false);
		}
		private SqlCommand CreateCommand(string sqlText, bool procedure)
		{
			DalBase dal = new DalBase();
			cmd = new System.Data.SqlClient.SqlCommand();
			cmd.CommandType = CommandType.Text;
			cmd.CommandText = sqlText;
			if (_processID != 0)
			{
				dal.InitCommand(_processID, cmd);
			}
			else
			{
				_processID = CSystems.ProcessID;
				dal.InitCommand(_processID, cmd);
			}
			if (procedure)
			{
				cmd.CommandType = CommandType.StoredProcedure;
			}
			return cmd;
		}
		private void Close()
		{
			DalBase dal = new DalBase();
			if (_processID != 0)
			{
				dal.Close(_processID, cmd);
				}
			else
			{
				dal.Close(cmd);
			}
		}
		public DataTable CreateDataTable(IDbCommand command)
		{
			DataTable dataTable = new DataTable();
			new System.Data.SqlClient.SqlDataAdapter((System.Data.SqlClient.SqlCommand)command).Fill(dataTable);
			return dataTable;
		}
		private string CreateSqlParameterName(string paramName)
		{
			return "@" + paramName;
		}
		private string CreateCollectionParameterName(string baseParamName)
		{
			return "@" + baseParamName;
		}
		private string CreateGEOMETRYSqlParameterName(string paramName, string gemetry = "geometry::STGeomFromText({0},4326)")
		{
			return string.Format(gemetry, "@" + paramName);
		}
		private IDbDataParameter AddParameter(IDbCommand cmd, string paramName, DbType dbType, object value)
		{
			IDbDataParameter parameter = cmd.CreateParameter();
			parameter.ParameterName = CreateCollectionParameterName(paramName);
			parameter.DbType = dbType;
			parameter.Value = null == value ? DBNull.Value : value;
			cmd.Parameters.Add(parameter);
			return parameter;
		}
		private IDbDataParameter AddParameters(IDbCommand cmd, string paramName, SqlDbType dbType, object value)
		{
			SqlParameter parameter = new SqlParameter();
			parameter.ParameterName = CreateCollectionParameterName(paramName);
			parameter.SqlDbType = dbType;
			parameter.Value = null == value ? DBNull.Value : value;
			cmd.Parameters.Add(parameter);
			return parameter;
		}
	}
}

