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
	public partial class CaseAppealCollection_Base : MarshalByRefObject
	{
		public const string CaseIDColumnName = "CaseID";
		public const string ApplicantIDColumnName = "ApplicantID";
		public const string DepartmentIDColumnName = "DepartmentID";
		public const string AppealNameColumnName = "AppealName";
		public const string AppealDateColumnName = "AppealDate";
		public const string AdditionalIssueColumnName = "AdditionalIssue";
		public const string AdditionalFactsInIssueColumnName = "AdditionalFactsInIssue";
		public const string AdditionalOfficerOpinionColumnName = "AdditionalOfficerOpinion";
		public const string ModifiedDateColumnName = "ModifiedDate";
		private int _processID;
		public SqlCommand cmd = null;
		public CaseAppealCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual CaseAppealRow[] GetAll()
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
			"[ApplicantID],"+
			"[DepartmentID],"+
			"[AppealName],"+
			"[AppealDate],"+
			"[AdditionalIssue],"+
			"[AdditionalFactsInIssue],"+
			"[AdditionalOfficerOpinion],"+
			"[ModifiedDate]"+
			" FROM [dbo].[CaseAppeal]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[CaseAppeal]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "CaseAppeal"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("CaseID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ApplicantID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DepartmentID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("AppealName",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("AppealDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("AdditionalIssue",Type.GetType("System.String"));
			dataColumn.MaxLength = 2147483647;
			dataColumn = dataTable.Columns.Add("AdditionalFactsInIssue",Type.GetType("System.String"));
			dataColumn.MaxLength = 2147483647;
			dataColumn = dataTable.Columns.Add("AdditionalOfficerOpinion",Type.GetType("System.String"));
			dataColumn.MaxLength = 2147483647;
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			return dataTable;
		}
		public virtual CaseAppealRow[] GetByCaseID(int caseID)
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
		public virtual CaseAppealRow[] GetByApplicantID(int applicantID)
		{
			return MapRecords(CreateGetByApplicantIDCommand(applicantID));
		}
		public virtual DataTable GetByApplicantIDAsDataTable(int applicantID)
		{
			return MapRecordsToDataTable(CreateGetByApplicantIDCommand(applicantID));
		}
		protected virtual IDbCommand CreateGetByApplicantIDCommand(int applicantID)
		{
			string whereSql = "";
			whereSql += "[ApplicantID]=" + CreateSqlParameterName("ApplicantID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ApplicantID", applicantID);
			return cmd;
		}
		public virtual CaseAppealRow[] GetByDepartmentID(int departmentId)
		{
			return MapRecords(CreateGetByDepartmentIDCommand(departmentId));
		}
		public virtual DataTable GetByDepartmentIDAsDataTable(int departmentId)
		{
			return MapRecordsToDataTable(CreateGetByDepartmentIDCommand(departmentId));
		}
		protected virtual IDbCommand CreateGetByDepartmentIDCommand(int departmentId)
		{
			string whereSql = "";
			whereSql += "[DepartmentID]=" + CreateSqlParameterName("DepartmentID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "DepartmentID", departmentId);
			return cmd;
		}
		public CaseAppealRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual CaseAppealRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="CaseAppealRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CaseAppealRow"/> objects.</returns>
		public virtual CaseAppealRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[CaseAppeal]", top);
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
		public CaseAppealRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			CaseAppealRow[] rows = null;
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
		public DataTable GetCaseAppealPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "CaseID")
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
		string sql = "SELECT COUNT(CaseID) AS TotalRow FROM [dbo].[CaseAppeal] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,CaseID,ApplicantID,DepartmentID,AppealName,AppealDate,AdditionalIssue,AdditionalFactsInIssue,AdditionalOfficerOpinion,ModifiedDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[CaseAppeal] " + whereSql +
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
		public CaseAppealItemsPaging GetCaseAppealPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "CaseID")
		{
		CaseAppealItemsPaging obj = new CaseAppealItemsPaging();
		DataTable dt = GetCaseAppealPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		CaseAppealItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new CaseAppealItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.CaseID = Convert.ToInt32(dt.Rows[i]["CaseID"]);
			record.ApplicantID = Convert.ToInt32(dt.Rows[i]["ApplicantID"]);
			record.DepartmentID = Convert.ToInt32(dt.Rows[i]["DepartmentID"]);
			record.AppealName = dt.Rows[i]["AppealName"].ToString();
			if (dt.Rows[i]["AppealDate"] != DBNull.Value)
			record.AppealDate = Convert.ToDateTime(dt.Rows[i]["AppealDate"]);
			record.AdditionalIssue = dt.Rows[i]["AdditionalIssue"].ToString();
			record.AdditionalFactsInIssue = dt.Rows[i]["AdditionalFactsInIssue"].ToString();
			record.AdditionalOfficerOpinion = dt.Rows[i]["AdditionalOfficerOpinion"].ToString();
			if (dt.Rows[i]["ModifiedDate"] != DBNull.Value)
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			recordList.Add(record);
		}
		obj.caseAppealItems = (CaseAppealItems[])(recordList.ToArray(typeof(CaseAppealItems)));
		return obj;
		}
		public CaseAppealRow GetByPrimaryKey(int caseID, int applicantID, int departmentId)
		{
			string whereSql = "[CaseID]=" + CreateSqlParameterName("CaseID") + " AND [ApplicantID]=" + CreateSqlParameterName("ApplicantID") + " AND [DepartmentID]=" + CreateSqlParameterName("DepartmentID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CaseID", caseID);
			AddParameter(cmd, "ApplicantID", applicantID);
			AddParameter(cmd, "DepartmentID", departmentId);
			CaseAppealRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public void Insert(CaseAppealRow value)		{
			string sqlStr = "INSERT INTO [dbo].[CaseAppeal] (" +
			"[CaseID], " + 
			"[ApplicantID], " + 
			"[DepartmentID], " + 
			"[AppealName], " + 
			"[AppealDate], " + 
			"[AdditionalIssue], " + 
			"[AdditionalFactsInIssue], " + 
			"[AdditionalOfficerOpinion], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("CaseID") + ", " +
			CreateSqlParameterName("ApplicantID") + ", " +
			CreateSqlParameterName("DepartmentID") + ", " +
			CreateSqlParameterName("AppealName") + ", " +
			CreateSqlParameterName("AppealDate") + ", " +
			CreateSqlParameterName("AdditionalIssue") + ", " +
			CreateSqlParameterName("AdditionalFactsInIssue") + ", " +
			CreateSqlParameterName("AdditionalOfficerOpinion") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "CaseID", value.CaseID);
			AddParameter(cmd, "ApplicantID", value.ApplicantID);
			AddParameter(cmd, "DepartmentID", value.DepartmentID);
			AddParameter(cmd, "AppealName", value.AppealName);
			AddParameter(cmd, "AppealDate", value.IsAppealDateNull ? DBNull.Value : (object)value.AppealDate);
			AddParameter(cmd, "AdditionalIssue", value.AdditionalIssue);
			AddParameter(cmd, "AdditionalFactsInIssue", value.AdditionalFactsInIssue);
			AddParameter(cmd, "AdditionalOfficerOpinion", value.AdditionalOfficerOpinion);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public void InsertOnlyPlainText(CaseAppealRow value)		{
			string sqlStr = "INSERT INTO [dbo].[CaseAppeal] (" +
			"[CaseID], " + 
			"[ApplicantID], " + 
			"[DepartmentID], " + 
			"[AppealName], " + 
			"[AppealDate], " + 
			"[AdditionalIssue], " + 
			"[AdditionalFactsInIssue], " + 
			"[AdditionalOfficerOpinion], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("CaseID") + ", " +
			CreateSqlParameterName("ApplicantID") + ", " +
			CreateSqlParameterName("DepartmentID") + ", " +
			CreateSqlParameterName("AppealName") + ", " +
			CreateSqlParameterName("AppealDate") + ", " +
			CreateSqlParameterName("AdditionalIssue") + ", " +
			CreateSqlParameterName("AdditionalFactsInIssue") + ", " +
			CreateSqlParameterName("AdditionalOfficerOpinion") + ", " +
			CreateSqlParameterName("ModifiedDate") + ")";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "CaseID", value.CaseID);
			AddParameter(cmd, "ApplicantID", value.ApplicantID);
			AddParameter(cmd, "DepartmentID", value.DepartmentID);
			AddParameter(cmd, "AppealName", Sanitizer.GetSafeHtmlFragment(value.AppealName));
			AddParameter(cmd, "AppealDate", value.IsAppealDateNull ? DBNull.Value : (object)value.AppealDate);
			AddParameter(cmd, "AdditionalIssue", Sanitizer.GetSafeHtmlFragment(value.AdditionalIssue));
			AddParameter(cmd, "AdditionalFactsInIssue", Sanitizer.GetSafeHtmlFragment(value.AdditionalFactsInIssue));
			AddParameter(cmd, "AdditionalOfficerOpinion", Sanitizer.GetSafeHtmlFragment(value.AdditionalOfficerOpinion));
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			cmd.ExecuteNonQuery();
		}
		public bool Update(CaseAppealRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetCaseID == true && value._IsSetApplicantID == true && value._IsSetDepartmentID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetAppealName)
				{
					strUpdate += "[AppealName]=" + CreateSqlParameterName("AppealName") + ",";
				}
				if (value._IsSetAppealDate)
				{
					strUpdate += "[AppealDate]=" + CreateSqlParameterName("AppealDate") + ",";
				}
				if (value._IsSetAdditionalIssue)
				{
					strUpdate += "[AdditionalIssue]=" + CreateSqlParameterName("AdditionalIssue") + ",";
				}
				if (value._IsSetAdditionalFactsInIssue)
				{
					strUpdate += "[AdditionalFactsInIssue]=" + CreateSqlParameterName("AdditionalFactsInIssue") + ",";
				}
				if (value._IsSetAdditionalOfficerOpinion)
				{
					strUpdate += "[AdditionalOfficerOpinion]=" + CreateSqlParameterName("AdditionalOfficerOpinion") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[CaseAppeal] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[CaseID]=" + CreateSqlParameterName("CaseID")+ " AND [ApplicantID]=" + CreateSqlParameterName("ApplicantID")+ " AND [DepartmentID]=" + CreateSqlParameterName("DepartmentID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "CaseID", value.CaseID);
					AddParameter(cmd, "ApplicantID", value.ApplicantID);
					AddParameter(cmd, "DepartmentID", value.DepartmentID);
					AddParameter(cmd, "AppealName", value.AppealName);
					AddParameter(cmd, "AppealDate", value.IsAppealDateNull ? DBNull.Value : (object)value.AppealDate);
					AddParameter(cmd, "AdditionalIssue", value.AdditionalIssue);
					AddParameter(cmd, "AdditionalFactsInIssue", value.AdditionalFactsInIssue);
					AddParameter(cmd, "AdditionalOfficerOpinion", value.AdditionalOfficerOpinion);
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
				Exception ex = new Exception("Set incorrect primarykey PK(CaseID,ApplicantID,DepartmentID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(CaseAppealRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetCaseID == true && value._IsSetApplicantID == true && value._IsSetDepartmentID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetAppealName)
				{
					strUpdate += "[AppealName]=" + CreateSqlParameterName("AppealName") + ",";
				}
				if (value._IsSetAppealDate)
				{
					strUpdate += "[AppealDate]=" + CreateSqlParameterName("AppealDate") + ",";
				}
				if (value._IsSetAdditionalIssue)
				{
					strUpdate += "[AdditionalIssue]=" + CreateSqlParameterName("AdditionalIssue") + ",";
				}
				if (value._IsSetAdditionalFactsInIssue)
				{
					strUpdate += "[AdditionalFactsInIssue]=" + CreateSqlParameterName("AdditionalFactsInIssue") + ",";
				}
				if (value._IsSetAdditionalOfficerOpinion)
				{
					strUpdate += "[AdditionalOfficerOpinion]=" + CreateSqlParameterName("AdditionalOfficerOpinion") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[CaseAppeal] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[CaseID]=" + CreateSqlParameterName("CaseID")+ " AND [ApplicantID]=" + CreateSqlParameterName("ApplicantID")+ " AND [DepartmentID]=" + CreateSqlParameterName("DepartmentID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "CaseID", value.CaseID);
					AddParameter(cmd, "ApplicantID", value.ApplicantID);
					AddParameter(cmd, "DepartmentID", value.DepartmentID);
					AddParameter(cmd, "AppealName", Sanitizer.GetSafeHtmlFragment(value.AppealName));
					AddParameter(cmd, "AppealDate", value.IsAppealDateNull ? DBNull.Value : (object)value.AppealDate);
					AddParameter(cmd, "AdditionalIssue", Sanitizer.GetSafeHtmlFragment(value.AdditionalIssue));
					AddParameter(cmd, "AdditionalFactsInIssue", Sanitizer.GetSafeHtmlFragment(value.AdditionalFactsInIssue));
					AddParameter(cmd, "AdditionalOfficerOpinion", Sanitizer.GetSafeHtmlFragment(value.AdditionalOfficerOpinion));
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
				Exception ex = new Exception("Set incorrect primarykey PK(CaseID,ApplicantID,DepartmentID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int caseID, int applicantID, int departmentId)
		{
			string whereSql = "[CaseID]=" + CreateSqlParameterName("CaseID") + " AND [ApplicantID]=" + CreateSqlParameterName("ApplicantID") + " AND [DepartmentID]=" + CreateSqlParameterName("DepartmentID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CaseID", caseID);
			AddParameter(cmd, "ApplicantID", applicantID);
			AddParameter(cmd, "DepartmentID", departmentId);
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
		public int DeleteByApplicantID(int applicantID)
		{
			return CreateDeleteByApplicantIDCommand(applicantID).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByApplicantIDCommand(int applicantID)
		{
			string whereSql = "";
			whereSql += "[ApplicantID]=" + CreateSqlParameterName("ApplicantID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ApplicantID", applicantID);
			return cmd;
		}
		public int DeleteByDepartmentID(int departmentId)
		{
			return CreateDeleteByDepartmentIDCommand(departmentId).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByDepartmentIDCommand(int departmentId)
		{
			string whereSql = "";
			whereSql += "[DepartmentID]=" + CreateSqlParameterName("DepartmentID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "DepartmentID", departmentId);
			return cmd;
		}
		protected CaseAppealRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected CaseAppealRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected CaseAppealRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int caseIDColumnIndex = reader.GetOrdinal("CaseID");
			int applicantIDColumnIndex = reader.GetOrdinal("ApplicantID");
			int departmentIdColumnIndex = reader.GetOrdinal("DepartmentID");
			int appealNameColumnIndex = reader.GetOrdinal("AppealName");
			int appealDateColumnIndex = reader.GetOrdinal("AppealDate");
			int additionalIssueColumnIndex = reader.GetOrdinal("AdditionalIssue");
			int additionalFactsInIssueColumnIndex = reader.GetOrdinal("AdditionalFactsInIssue");
			int additionalOfficerOpinionColumnIndex = reader.GetOrdinal("AdditionalOfficerOpinion");
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
					CaseAppealRow record = new CaseAppealRow();
					recordList.Add(record);
					record.CaseID =  Convert.ToInt32(reader.GetValue(caseIDColumnIndex));
					record.ApplicantID =  Convert.ToInt32(reader.GetValue(applicantIDColumnIndex));
					record.DepartmentID =  Convert.ToInt32(reader.GetValue(departmentIdColumnIndex));
					if (!reader.IsDBNull(appealNameColumnIndex)) record.AppealName =  Convert.ToString(reader.GetValue(appealNameColumnIndex));

					if (!reader.IsDBNull(appealDateColumnIndex)) record.AppealDate =  Convert.ToDateTime(reader.GetValue(appealDateColumnIndex));

					if (!reader.IsDBNull(additionalIssueColumnIndex)) record.AdditionalIssue =  Convert.ToString(reader.GetValue(additionalIssueColumnIndex));

					if (!reader.IsDBNull(additionalFactsInIssueColumnIndex)) record.AdditionalFactsInIssue =  Convert.ToString(reader.GetValue(additionalFactsInIssueColumnIndex));

					if (!reader.IsDBNull(additionalOfficerOpinionColumnIndex)) record.AdditionalOfficerOpinion =  Convert.ToString(reader.GetValue(additionalOfficerOpinionColumnIndex));

					if (!reader.IsDBNull(modifiedDateColumnIndex)) record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CaseAppealRow[])(recordList.ToArray(typeof(CaseAppealRow)));
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
				case "ApplicantID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "DepartmentID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "AppealName":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "AppealDate":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "AdditionalIssue":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "AdditionalFactsInIssue":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "AdditionalOfficerOpinion":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
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

