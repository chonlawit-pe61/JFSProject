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
	public partial class CurrentCaseStatusCollection_Base : MarshalByRefObject
	{
		public const string CurrentStatusCaseIDColumnName = "CurrentStatusCaseID";
		public const string CaseIDColumnName = "CaseID";
		public const string ApplicantIDColumnName = "ApplicantID";
		public const string CourIDColumnName = "CourID";
		public const string HelpCaseLevelIDColumnName = "HelpCaseLevelID";
		public const string CaseTypeIDColumnName = "CaseTypeID";
		public const string HelpCaseLevelOtherColumnName = "HelpCaseLevelOther";
		public const string CaseTypeOtherColumnName = "CaseTypeOther";
		public const string CaseRedNoColumnName = "CaseRedNo";
		public const string CaseBlackNoColumnName = "CaseBlackNo";
		public const string LitigantTitleColumnName = "LitigantTitle";
		public const string LitigantNameColumnName = "LitigantName";
		public const string JudgementColumnName = "Judgement";
		public const string ApplicantStatusColumnName = "ApplicantStatus";
		public const string ChargeColumnName = "Charge";
		public const string ModifiedDateColumnName = "ModifiedDate";
		private int _processID;
		public SqlCommand cmd = null;
		public CurrentCaseStatusCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual CurrentCaseStatusRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}
		public virtual CurrentCaseStatusPaging GetPagingRelyOnCurrentStatusCaseIDdesc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			CurrentCaseStatusPaging currentcaseStatusPaging = new CurrentCaseStatusPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(CurrentStatusCaseID) as TotalRow from [dbo].[CurrentCaseStatus]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			currentcaseStatusPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			currentcaseStatusPaging.totalPage = (int)Math.Ceiling((double) currentcaseStatusPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnCurrentStatusCaseID(whereSql, "CurrentStatusCaseID Desc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			currentcaseStatusPaging.currentcaseStatusRow = MapRecords(command);
			return currentcaseStatusPaging;
		}
		public virtual CurrentCaseStatusPaging GetPagingRelyOnCurrentStatusCaseIDasc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			CurrentCaseStatusPaging currentcaseStatusPaging = new CurrentCaseStatusPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(CurrentStatusCaseID) as TotalRow from [dbo].[CurrentCaseStatus]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			currentcaseStatusPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			currentcaseStatusPaging.totalPage = (int)Math.Ceiling((double)currentcaseStatusPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnCurrentStatusCaseID(whereSql, "CurrentStatusCaseID asc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			currentcaseStatusPaging.currentcaseStatusRow = MapRecords(command);
			return currentcaseStatusPaging;
		}
		public virtual CurrentCaseStatusRow[] GetPagingRelyOnCurrentStatusCaseIDdescNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minCurrentStatusCaseID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And CurrentStatusCaseID < " + minCurrentStatusCaseID.ToString();
			}
			else
			{
				whereSql = "CurrentStatusCaseID < " + minCurrentStatusCaseID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnCurrentStatusCaseID(whereSql, "CurrentStatusCaseID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual CurrentCaseStatusRow[] GetPagingRelyOnCurrentStatusCaseIDascNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minCurrentStatusCaseID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And CurrentStatusCaseID > " + minCurrentStatusCaseID.ToString();
			}
			else
			{
				whereSql = "CurrentStatusCaseID > " + minCurrentStatusCaseID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnCurrentStatusCaseID(whereSql, "CurrentStatusCaseID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual CurrentCaseStatusRow[] GetPagingRelyOnCurrentStatusCaseIDascPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxCurrentStatusCaseID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And CurrentStatusCaseID < " + maxCurrentStatusCaseID.ToString();
			}
			else
			{
				whereSql = "CurrentStatusCaseID < " + maxCurrentStatusCaseID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnCurrentStatusCaseID(whereSql, "CurrentStatusCaseID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual CurrentCaseStatusRow[] GetPagingRelyOnCurrentStatusCaseIDdescPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxCurrentStatusCaseID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And CurrentStatusCaseID > " + maxCurrentStatusCaseID.ToString();
			}
			else
			{
				whereSql = "CurrentStatusCaseID > " + maxCurrentStatusCaseID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnCurrentStatusCaseID(whereSql, "CurrentStatusCaseID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual CurrentCaseStatusRow[] GetPagingRelyOnCurrentStatusCaseIDdescByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber ,string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "CurrentStatusCaseID Desc";
			}
			else
			{
				orderByColumn = orderByColumn + " Desc";
			}
			CurrentCaseStatusRow[] currentcaseStatusRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnCurrentStatusCaseID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				currentcaseStatusRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnCurrentStatusCaseIDdescByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				currentcaseStatusRow = MapRecords(command);
			}
			return currentcaseStatusRow;
		}
		public virtual CurrentCaseStatusRow[] GetPagingRelyOnCurrentStatusCaseIDascByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber, string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "CurrentStatusCaseID Asc";
			}
			else
			{
				orderByColumn = orderByColumn + " Asc";
			}
			CurrentCaseStatusRow[] currentcaseStatusRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnCurrentStatusCaseID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				currentcaseStatusRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnCurrentStatusCaseIDascByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				currentcaseStatusRow = MapRecords(command);
			}
			return currentcaseStatusRow;
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
			"[CurrentStatusCaseID],"+
			"[CaseID],"+
			"[ApplicantID],"+
			"[CourID],"+
			"[HelpCaseLevelID],"+
			"[CaseTypeID],"+
			"[HelpCaseLevelOther],"+
			"[CaseTypeOther],"+
			"[CaseRedNo],"+
			"[CaseBlackNo],"+
			"[LitigantTitle],"+
			"[LitigantName],"+
			"[Judgement],"+
			"[ApplicantStatus],"+
			"[Charge],"+
			"[ModifiedDate]"+
			" FROM [dbo].[CurrentCaseStatus]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnCurrentStatusCaseID(string whereSql, string orderBySql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[CurrentCaseStatus]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnCurrentStatusCaseIDdescByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "CurrentStatusCaseID Desc")
			{
				string subWhereSql = string.Empty;
				if (null != whereSql && 0 < whereSql.Length)
				{
					subWhereSql += " WHERE " + whereSql;
				}
				else
				{
					subWhereSql += "";
				}
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[CurrentCaseStatus] where CurrentStatusCaseID < (select min(minCurrentStatusCaseID) from(select top " + (rowPerPage * pageNumber).ToString() + " CurrentStatusCaseID as minCurrentStatusCaseID from [dbo].[CurrentCaseStatus]" + subWhereSql + " order by " + orderBySql + ")T1";
				if (null != whereSql && 0 < whereSql.Length)
				{
					sql += " WHERE " + whereSql + ")";
				}
				else
				{
					sql += ")";
				}
				if (null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			}
			else
			{
				if (null != whereSql && 0 < whereSql.Length)
				{
					whereSql = " AND " + whereSql;
				}
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[CurrentCaseStatus]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnCurrentStatusCaseIDascByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "CurrentStatusCaseID Asc")
			{
				string subWhereSql = string.Empty;
				if (null != whereSql && 0 < whereSql.Length)
				{
					subWhereSql += " WHERE " + whereSql;
				}
				else
				{
					subWhereSql += "";
				}
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[CurrentCaseStatus] where CurrentStatusCaseID > (select max(maxCurrentStatusCaseID) from(select top " + (rowPerPage * pageNumber).ToString() + " CurrentStatusCaseID as maxCurrentStatusCaseID from [dbo].[CurrentCaseStatus]" +  subWhereSql + " order by " + orderBySql + ")T1";
				if (null != whereSql && 0 < whereSql.Length)
				{
					sql += " WHERE " + whereSql + ")";
				}
				else
				{
					sql += ")";
				}
				if (null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			}
			else
			{
				if (null != whereSql && 0 < whereSql.Length)
				{
					whereSql = " AND " + whereSql;
				}
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[CurrentCaseStatus]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[CurrentCaseStatus]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "CurrentCaseStatus"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("CurrentStatusCaseID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CaseID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ApplicantID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CourID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("HelpCaseLevelID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("CaseTypeID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("HelpCaseLevelOther",Type.GetType("System.String"));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("CaseTypeOther",Type.GetType("System.String"));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("CaseRedNo",Type.GetType("System.String"));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("CaseBlackNo",Type.GetType("System.String"));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("LitigantTitle",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("LitigantName",Type.GetType("System.String"));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("Judgement",Type.GetType("System.String"));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("ApplicantStatus",Type.GetType("System.String"));
			dataColumn.MaxLength = 2;
			dataColumn = dataTable.Columns.Add("Charge",Type.GetType("System.String"));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			return dataTable;
		}
		public virtual CurrentCaseStatusRow[] GetByCaseID(int caseID)
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
		public virtual CurrentCaseStatusRow[] GetByApplicantID(int applicantID)
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
		public virtual CurrentCaseStatusRow[] GetByCourID(int courID)
		{
			return MapRecords(CreateGetByCourIDCommand(courID));
		}
		public virtual DataTable GetByCourIDAsDataTable(int courID)
		{
			return MapRecordsToDataTable(CreateGetByCourIDCommand(courID));
		}
		protected virtual IDbCommand CreateGetByCourIDCommand(int courID)
		{
			string whereSql = "";
			whereSql += "[CourID]=" + CreateSqlParameterName("CourID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CourID", courID);
			return cmd;
		}
		public virtual CurrentCaseStatusRow[] GetByHelpCaseLevelID(int helpCaseLevelID)
		{
			return MapRecords(CreateGetByHelpCaseLevelIDCommand(helpCaseLevelID));
		}
		public virtual DataTable GetByHelpCaseLevelIDAsDataTable(int helpCaseLevelID)
		{
			return MapRecordsToDataTable(CreateGetByHelpCaseLevelIDCommand(helpCaseLevelID));
		}
		protected virtual IDbCommand CreateGetByHelpCaseLevelIDCommand(int helpCaseLevelID)
		{
			string whereSql = "";
			whereSql += "[HelpCaseLevelID]=" + CreateSqlParameterName("HelpCaseLevelID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "HelpCaseLevelID", helpCaseLevelID);
			return cmd;
		}
		public virtual CurrentCaseStatusRow[] GetByCaseTypeID(int caseTypeID)
		{
			return MapRecords(CreateGetByCaseTypeIDCommand(caseTypeID));
		}
		public virtual DataTable GetByCaseTypeIDAsDataTable(int caseTypeID)
		{
			return MapRecordsToDataTable(CreateGetByCaseTypeIDCommand(caseTypeID));
		}
		protected virtual IDbCommand CreateGetByCaseTypeIDCommand(int caseTypeID)
		{
			string whereSql = "";
			whereSql += "[CaseTypeID]=" + CreateSqlParameterName("CaseTypeID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CaseTypeID", caseTypeID);
			return cmd;
		}
		public CurrentCaseStatusRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual CurrentCaseStatusRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="CurrentCaseStatusRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CurrentCaseStatusRow"/> objects.</returns>
		public virtual CurrentCaseStatusRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[CurrentCaseStatus]", top);
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
		public CurrentCaseStatusRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			CurrentCaseStatusRow[] rows = null;
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
		public DataTable GetCurrentCaseStatusPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "CurrentStatusCaseID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "CurrentStatusCaseID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(CurrentStatusCaseID) AS TotalRow FROM [dbo].[CurrentCaseStatus] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,CurrentStatusCaseID,CaseID,ApplicantID,CourID,HelpCaseLevelID,CaseTypeID,HelpCaseLevelOther,CaseTypeOther,CaseRedNo,CaseBlackNo,LitigantTitle,LitigantName,Judgement,ApplicantStatus,Charge,ModifiedDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT [CurrentCaseStatus].*, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[CurrentCaseStatus] " + whereSql +
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
		public CurrentCaseStatusItemsPaging GetCurrentCaseStatusPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "CurrentStatusCaseID")
		{
		CurrentCaseStatusItemsPaging obj = new CurrentCaseStatusItemsPaging();
		DataTable dt = GetCurrentCaseStatusPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		CurrentCaseStatusItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new CurrentCaseStatusItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.CurrentStatusCaseID = Convert.ToInt32(dt.Rows[i]["CurrentStatusCaseID"]);
			record.CaseID = Convert.ToInt32(dt.Rows[i]["CaseID"]);
			record.ApplicantID = Convert.ToInt32(dt.Rows[i]["ApplicantID"]);
			if (dt.Rows[i]["CourID"] != DBNull.Value)
			record.CourID = Convert.ToInt32(dt.Rows[i]["CourID"]);
			if (dt.Rows[i]["HelpCaseLevelID"] != DBNull.Value)
			record.HelpCaseLevelID = Convert.ToInt32(dt.Rows[i]["HelpCaseLevelID"]);
			if (dt.Rows[i]["CaseTypeID"] != DBNull.Value)
			record.CaseTypeID = Convert.ToInt32(dt.Rows[i]["CaseTypeID"]);
			record.HelpCaseLevelOther = dt.Rows[i]["HelpCaseLevelOther"].ToString();
			record.CaseTypeOther = dt.Rows[i]["CaseTypeOther"].ToString();
			record.CaseRedNo = dt.Rows[i]["CaseRedNo"].ToString();
			record.CaseBlackNo = dt.Rows[i]["CaseBlackNo"].ToString();
			record.LitigantTitle = dt.Rows[i]["LitigantTitle"].ToString();
			record.LitigantName = dt.Rows[i]["LitigantName"].ToString();
			record.Judgement = dt.Rows[i]["Judgement"].ToString();
			record.ApplicantStatus = dt.Rows[i]["ApplicantStatus"].ToString();
			record.Charge = dt.Rows[i]["Charge"].ToString();
			if (dt.Rows[i]["ModifiedDate"] != DBNull.Value)
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			recordList.Add(record);
		}
		obj.currentcaseStatusItems = (CurrentCaseStatusItems[])(recordList.ToArray(typeof(CurrentCaseStatusItems)));
		return obj;
		}
		public CurrentCaseStatusRow GetByPrimaryKey(int currentStatuscaseID)
		{
			string whereSql = "[CurrentStatusCaseID]=" + CreateSqlParameterName("CurrentStatusCaseID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CurrentStatusCaseID", currentStatuscaseID);
			CurrentCaseStatusRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public int Insert(CurrentCaseStatusRow value)		{
			string sqlStr = "INSERT INTO [dbo].[CurrentCaseStatus] (" +
			"[CaseID], " + 
			"[ApplicantID], " + 
			"[CourID], " + 
			"[HelpCaseLevelID], " + 
			"[CaseTypeID], " + 
			"[HelpCaseLevelOther], " + 
			"[CaseTypeOther], " + 
			"[CaseRedNo], " + 
			"[CaseBlackNo], " + 
			"[LitigantTitle], " + 
			"[LitigantName], " + 
			"[Judgement], " + 
			"[ApplicantStatus], " + 
			"[Charge], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("CaseID") + ", " +
			CreateSqlParameterName("ApplicantID") + ", " +
			CreateSqlParameterName("CourID") + ", " +
			CreateSqlParameterName("HelpCaseLevelID") + ", " +
			CreateSqlParameterName("CaseTypeID") + ", " +
			CreateSqlParameterName("HelpCaseLevelOther") + ", " +
			CreateSqlParameterName("CaseTypeOther") + ", " +
			CreateSqlParameterName("CaseRedNo") + ", " +
			CreateSqlParameterName("CaseBlackNo") + ", " +
			CreateSqlParameterName("LitigantTitle") + ", " +
			CreateSqlParameterName("LitigantName") + ", " +
			CreateSqlParameterName("Judgement") + ", " +
			CreateSqlParameterName("ApplicantStatus") + ", " +
			CreateSqlParameterName("Charge") + ", " +
			CreateSqlParameterName("ModifiedDate") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "CaseID", value.CaseID);
			AddParameter(cmd, "ApplicantID", value.ApplicantID);
			AddParameter(cmd, "CourID", value.IsCourIDNull ? DBNull.Value : (object)value.CourID);
			AddParameter(cmd, "HelpCaseLevelID", value.IsHelpCaseLevelIDNull ? DBNull.Value : (object)value.HelpCaseLevelID);
			AddParameter(cmd, "CaseTypeID", value.IsCaseTypeIDNull ? DBNull.Value : (object)value.CaseTypeID);
			AddParameter(cmd, "HelpCaseLevelOther", value.HelpCaseLevelOther);
			AddParameter(cmd, "CaseTypeOther", value.CaseTypeOther);
			AddParameter(cmd, "CaseRedNo", value.CaseRedNo);
			AddParameter(cmd, "CaseBlackNo", value.CaseBlackNo);
			AddParameter(cmd, "LitigantTitle", value.LitigantTitle);
			AddParameter(cmd, "LitigantName", value.LitigantName);
			AddParameter(cmd, "Judgement", value.Judgement);
			AddParameter(cmd, "ApplicantStatus", value.ApplicantStatus);
			AddParameter(cmd, "Charge", value.Charge);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public int InsertOnlyPlainText(CurrentCaseStatusRow value)		{
			string sqlStr = "INSERT INTO [dbo].[CurrentCaseStatus] (" +
			"[CaseID], " + 
			"[ApplicantID], " + 
			"[CourID], " + 
			"[HelpCaseLevelID], " + 
			"[CaseTypeID], " + 
			"[HelpCaseLevelOther], " + 
			"[CaseTypeOther], " + 
			"[CaseRedNo], " + 
			"[CaseBlackNo], " + 
			"[LitigantTitle], " + 
			"[LitigantName], " + 
			"[Judgement], " + 
			"[ApplicantStatus], " + 
			"[Charge], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("CaseID") + ", " +
			CreateSqlParameterName("ApplicantID") + ", " +
			CreateSqlParameterName("CourID") + ", " +
			CreateSqlParameterName("HelpCaseLevelID") + ", " +
			CreateSqlParameterName("CaseTypeID") + ", " +
			CreateSqlParameterName("HelpCaseLevelOther") + ", " +
			CreateSqlParameterName("CaseTypeOther") + ", " +
			CreateSqlParameterName("CaseRedNo") + ", " +
			CreateSqlParameterName("CaseBlackNo") + ", " +
			CreateSqlParameterName("LitigantTitle") + ", " +
			CreateSqlParameterName("LitigantName") + ", " +
			CreateSqlParameterName("Judgement") + ", " +
			CreateSqlParameterName("ApplicantStatus") + ", " +
			CreateSqlParameterName("Charge") + ", " +
			CreateSqlParameterName("ModifiedDate") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "CaseID", value.CaseID);
			AddParameter(cmd, "ApplicantID", value.ApplicantID);
			AddParameter(cmd, "CourID", value.IsCourIDNull ? DBNull.Value : (object)value.CourID);
			AddParameter(cmd, "HelpCaseLevelID", value.IsHelpCaseLevelIDNull ? DBNull.Value : (object)value.HelpCaseLevelID);
			AddParameter(cmd, "CaseTypeID", value.IsCaseTypeIDNull ? DBNull.Value : (object)value.CaseTypeID);
			AddParameter(cmd, "HelpCaseLevelOther", Sanitizer.GetSafeHtmlFragment(value.HelpCaseLevelOther));
			AddParameter(cmd, "CaseTypeOther", Sanitizer.GetSafeHtmlFragment(value.CaseTypeOther));
			AddParameter(cmd, "CaseRedNo", Sanitizer.GetSafeHtmlFragment(value.CaseRedNo));
			AddParameter(cmd, "CaseBlackNo", Sanitizer.GetSafeHtmlFragment(value.CaseBlackNo));
			AddParameter(cmd, "LitigantTitle", Sanitizer.GetSafeHtmlFragment(value.LitigantTitle));
			AddParameter(cmd, "LitigantName", Sanitizer.GetSafeHtmlFragment(value.LitigantName));
			AddParameter(cmd, "Judgement", Sanitizer.GetSafeHtmlFragment(value.Judgement));
			AddParameter(cmd, "ApplicantStatus", Sanitizer.GetSafeHtmlFragment(value.ApplicantStatus));
			AddParameter(cmd, "Charge", Sanitizer.GetSafeHtmlFragment(value.Charge));
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public bool Update(CurrentCaseStatusRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetCurrentStatusCaseID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetCaseID)
				{
					strUpdate += "[CaseID]=" + CreateSqlParameterName("CaseID") + ",";
				}
				if (value._IsSetApplicantID)
				{
					strUpdate += "[ApplicantID]=" + CreateSqlParameterName("ApplicantID") + ",";
				}
				if (value._IsSetCourID)
				{
					strUpdate += "[CourID]=" + CreateSqlParameterName("CourID") + ",";
				}
				if (value._IsSetHelpCaseLevelID)
				{
					strUpdate += "[HelpCaseLevelID]=" + CreateSqlParameterName("HelpCaseLevelID") + ",";
				}
				if (value._IsSetCaseTypeID)
				{
					strUpdate += "[CaseTypeID]=" + CreateSqlParameterName("CaseTypeID") + ",";
				}
				if (value._IsSetHelpCaseLevelOther)
				{
					strUpdate += "[HelpCaseLevelOther]=" + CreateSqlParameterName("HelpCaseLevelOther") + ",";
				}
				if (value._IsSetCaseTypeOther)
				{
					strUpdate += "[CaseTypeOther]=" + CreateSqlParameterName("CaseTypeOther") + ",";
				}
				if (value._IsSetCaseRedNo)
				{
					strUpdate += "[CaseRedNo]=" + CreateSqlParameterName("CaseRedNo") + ",";
				}
				if (value._IsSetCaseBlackNo)
				{
					strUpdate += "[CaseBlackNo]=" + CreateSqlParameterName("CaseBlackNo") + ",";
				}
				if (value._IsSetLitigantTitle)
				{
					strUpdate += "[LitigantTitle]=" + CreateSqlParameterName("LitigantTitle") + ",";
				}
				if (value._IsSetLitigantName)
				{
					strUpdate += "[LitigantName]=" + CreateSqlParameterName("LitigantName") + ",";
				}
				if (value._IsSetJudgement)
				{
					strUpdate += "[Judgement]=" + CreateSqlParameterName("Judgement") + ",";
				}
				if (value._IsSetApplicantStatus)
				{
					strUpdate += "[ApplicantStatus]=" + CreateSqlParameterName("ApplicantStatus") + ",";
				}
				if (value._IsSetCharge)
				{
					strUpdate += "[Charge]=" + CreateSqlParameterName("Charge") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[CurrentCaseStatus] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[CurrentStatusCaseID]=" + CreateSqlParameterName("CurrentStatusCaseID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "CurrentStatusCaseID", value.CurrentStatusCaseID);
					AddParameter(cmd, "CaseID", value.CaseID);
					AddParameter(cmd, "ApplicantID", value.ApplicantID);
					AddParameter(cmd, "CourID", value.IsCourIDNull ? DBNull.Value : (object)value.CourID);
					AddParameter(cmd, "HelpCaseLevelID", value.IsHelpCaseLevelIDNull ? DBNull.Value : (object)value.HelpCaseLevelID);
					AddParameter(cmd, "CaseTypeID", value.IsCaseTypeIDNull ? DBNull.Value : (object)value.CaseTypeID);
					AddParameter(cmd, "HelpCaseLevelOther", value.HelpCaseLevelOther);
					AddParameter(cmd, "CaseTypeOther", value.CaseTypeOther);
					AddParameter(cmd, "CaseRedNo", value.CaseRedNo);
					AddParameter(cmd, "CaseBlackNo", value.CaseBlackNo);
					AddParameter(cmd, "LitigantTitle", value.LitigantTitle);
					AddParameter(cmd, "LitigantName", value.LitigantName);
					AddParameter(cmd, "Judgement", value.Judgement);
					AddParameter(cmd, "ApplicantStatus", value.ApplicantStatus);
					AddParameter(cmd, "Charge", value.Charge);
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
				Exception ex = new Exception("Set incorrect primarykey PK(CurrentStatusCaseID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(CurrentCaseStatusRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetCurrentStatusCaseID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetCaseID)
				{
					strUpdate += "[CaseID]=" + CreateSqlParameterName("CaseID") + ",";
				}
				if (value._IsSetApplicantID)
				{
					strUpdate += "[ApplicantID]=" + CreateSqlParameterName("ApplicantID") + ",";
				}
				if (value._IsSetCourID)
				{
					strUpdate += "[CourID]=" + CreateSqlParameterName("CourID") + ",";
				}
				if (value._IsSetHelpCaseLevelID)
				{
					strUpdate += "[HelpCaseLevelID]=" + CreateSqlParameterName("HelpCaseLevelID") + ",";
				}
				if (value._IsSetCaseTypeID)
				{
					strUpdate += "[CaseTypeID]=" + CreateSqlParameterName("CaseTypeID") + ",";
				}
				if (value._IsSetHelpCaseLevelOther)
				{
					strUpdate += "[HelpCaseLevelOther]=" + CreateSqlParameterName("HelpCaseLevelOther") + ",";
				}
				if (value._IsSetCaseTypeOther)
				{
					strUpdate += "[CaseTypeOther]=" + CreateSqlParameterName("CaseTypeOther") + ",";
				}
				if (value._IsSetCaseRedNo)
				{
					strUpdate += "[CaseRedNo]=" + CreateSqlParameterName("CaseRedNo") + ",";
				}
				if (value._IsSetCaseBlackNo)
				{
					strUpdate += "[CaseBlackNo]=" + CreateSqlParameterName("CaseBlackNo") + ",";
				}
				if (value._IsSetLitigantTitle)
				{
					strUpdate += "[LitigantTitle]=" + CreateSqlParameterName("LitigantTitle") + ",";
				}
				if (value._IsSetLitigantName)
				{
					strUpdate += "[LitigantName]=" + CreateSqlParameterName("LitigantName") + ",";
				}
				if (value._IsSetJudgement)
				{
					strUpdate += "[Judgement]=" + CreateSqlParameterName("Judgement") + ",";
				}
				if (value._IsSetApplicantStatus)
				{
					strUpdate += "[ApplicantStatus]=" + CreateSqlParameterName("ApplicantStatus") + ",";
				}
				if (value._IsSetCharge)
				{
					strUpdate += "[Charge]=" + CreateSqlParameterName("Charge") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[CurrentCaseStatus] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[CurrentStatusCaseID]=" + CreateSqlParameterName("CurrentStatusCaseID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "CurrentStatusCaseID", value.CurrentStatusCaseID);
					AddParameter(cmd, "CaseID", value.CaseID);
					AddParameter(cmd, "ApplicantID", value.ApplicantID);
					AddParameter(cmd, "CourID", value.IsCourIDNull ? DBNull.Value : (object)value.CourID);
					AddParameter(cmd, "HelpCaseLevelID", value.IsHelpCaseLevelIDNull ? DBNull.Value : (object)value.HelpCaseLevelID);
					AddParameter(cmd, "CaseTypeID", value.IsCaseTypeIDNull ? DBNull.Value : (object)value.CaseTypeID);
					AddParameter(cmd, "HelpCaseLevelOther", Sanitizer.GetSafeHtmlFragment(value.HelpCaseLevelOther));
					AddParameter(cmd, "CaseTypeOther", Sanitizer.GetSafeHtmlFragment(value.CaseTypeOther));
					AddParameter(cmd, "CaseRedNo", Sanitizer.GetSafeHtmlFragment(value.CaseRedNo));
					AddParameter(cmd, "CaseBlackNo", Sanitizer.GetSafeHtmlFragment(value.CaseBlackNo));
					AddParameter(cmd, "LitigantTitle", Sanitizer.GetSafeHtmlFragment(value.LitigantTitle));
					AddParameter(cmd, "LitigantName", Sanitizer.GetSafeHtmlFragment(value.LitigantName));
					AddParameter(cmd, "Judgement", Sanitizer.GetSafeHtmlFragment(value.Judgement));
					AddParameter(cmd, "ApplicantStatus", Sanitizer.GetSafeHtmlFragment(value.ApplicantStatus));
					AddParameter(cmd, "Charge", Sanitizer.GetSafeHtmlFragment(value.Charge));
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
				Exception ex = new Exception("Set incorrect primarykey PK(CurrentStatusCaseID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int currentStatuscaseID)
		{
			string whereSql = "[CurrentStatusCaseID]=" + CreateSqlParameterName("CurrentStatusCaseID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CurrentStatusCaseID", currentStatuscaseID);
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
		public int DeleteByCourID(int courID)
		{
			return DeleteByCourID(courID, false);
		}
		public int DeleteByCourID(int courID, bool courIDNull)
		{
			return CreateDeleteByCourIDCommand(courID, courIDNull).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByCourIDCommand(int courID, bool courIDNull)
		{
			string whereSql = "";
			if (courIDNull)
				whereSql += "[CourID] IS NULL";
			else
				whereSql += "[CourID]=" + CreateSqlParameterName("CourID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if (!courIDNull)
				AddParameter(cmd, "CourID", courID);
			return cmd;
		}
		public int DeleteByHelpCaseLevelID(int helpCaseLevelID)
		{
			return DeleteByHelpCaseLevelID(helpCaseLevelID, false);
		}
		public int DeleteByHelpCaseLevelID(int helpCaseLevelID, bool helpCaseLevelIDNull)
		{
			return CreateDeleteByHelpCaseLevelIDCommand(helpCaseLevelID, helpCaseLevelIDNull).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByHelpCaseLevelIDCommand(int helpCaseLevelID, bool helpCaseLevelIDNull)
		{
			string whereSql = "";
			if (helpCaseLevelIDNull)
				whereSql += "[HelpCaseLevelID] IS NULL";
			else
				whereSql += "[HelpCaseLevelID]=" + CreateSqlParameterName("HelpCaseLevelID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if (!helpCaseLevelIDNull)
				AddParameter(cmd, "HelpCaseLevelID", helpCaseLevelID);
			return cmd;
		}
		public int DeleteByCaseTypeID(int caseTypeID)
		{
			return DeleteByCaseTypeID(caseTypeID, false);
		}
		public int DeleteByCaseTypeID(int caseTypeID, bool caseTypeIDNull)
		{
			return CreateDeleteByCaseTypeIDCommand(caseTypeID, caseTypeIDNull).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByCaseTypeIDCommand(int caseTypeID, bool caseTypeIDNull)
		{
			string whereSql = "";
			if (caseTypeIDNull)
				whereSql += "[CaseTypeID] IS NULL";
			else
				whereSql += "[CaseTypeID]=" + CreateSqlParameterName("CaseTypeID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if (!caseTypeIDNull)
				AddParameter(cmd, "CaseTypeID", caseTypeID);
			return cmd;
		}
		protected CurrentCaseStatusRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected CurrentCaseStatusRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected CurrentCaseStatusRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int currentStatuscaseIDColumnIndex = reader.GetOrdinal("CurrentStatusCaseID");
			int caseIDColumnIndex = reader.GetOrdinal("CaseID");
			int applicantIDColumnIndex = reader.GetOrdinal("ApplicantID");
			int courIDColumnIndex = reader.GetOrdinal("CourID");
			int helpCaseLevelIDColumnIndex = reader.GetOrdinal("HelpCaseLevelID");
			int caseTypeIDColumnIndex = reader.GetOrdinal("CaseTypeID");
			int helpCaseLevelOtherColumnIndex = reader.GetOrdinal("HelpCaseLevelOther");
			int caseTypeOtherColumnIndex = reader.GetOrdinal("CaseTypeOther");
			int caseRedNoColumnIndex = reader.GetOrdinal("CaseRedNo");
			int caseBlackNoColumnIndex = reader.GetOrdinal("CaseBlackNo");
			int litigantTitleColumnIndex = reader.GetOrdinal("LitigantTitle");
			int litigantNameColumnIndex = reader.GetOrdinal("LitigantName");
			int judgementColumnIndex = reader.GetOrdinal("Judgement");
			int applicantStatusColumnIndex = reader.GetOrdinal("ApplicantStatus");
			int chargeColumnIndex = reader.GetOrdinal("Charge");
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
					CurrentCaseStatusRow record = new CurrentCaseStatusRow();
					recordList.Add(record);
					record.CurrentStatusCaseID =  Convert.ToInt32(reader.GetValue(currentStatuscaseIDColumnIndex));
					record.CaseID =  Convert.ToInt32(reader.GetValue(caseIDColumnIndex));
					record.ApplicantID =  Convert.ToInt32(reader.GetValue(applicantIDColumnIndex));
					if (!reader.IsDBNull(courIDColumnIndex)) record.CourID =  Convert.ToInt32(reader.GetValue(courIDColumnIndex));

					if (!reader.IsDBNull(helpCaseLevelIDColumnIndex)) record.HelpCaseLevelID =  Convert.ToInt32(reader.GetValue(helpCaseLevelIDColumnIndex));

					if (!reader.IsDBNull(caseTypeIDColumnIndex)) record.CaseTypeID =  Convert.ToInt32(reader.GetValue(caseTypeIDColumnIndex));

					if (!reader.IsDBNull(helpCaseLevelOtherColumnIndex)) record.HelpCaseLevelOther =  Convert.ToString(reader.GetValue(helpCaseLevelOtherColumnIndex));

					if (!reader.IsDBNull(caseTypeOtherColumnIndex)) record.CaseTypeOther =  Convert.ToString(reader.GetValue(caseTypeOtherColumnIndex));

					if (!reader.IsDBNull(caseRedNoColumnIndex)) record.CaseRedNo =  Convert.ToString(reader.GetValue(caseRedNoColumnIndex));

					if (!reader.IsDBNull(caseBlackNoColumnIndex)) record.CaseBlackNo =  Convert.ToString(reader.GetValue(caseBlackNoColumnIndex));

					if (!reader.IsDBNull(litigantTitleColumnIndex)) record.LitigantTitle =  Convert.ToString(reader.GetValue(litigantTitleColumnIndex));

					if (!reader.IsDBNull(litigantNameColumnIndex)) record.LitigantName =  Convert.ToString(reader.GetValue(litigantNameColumnIndex));

					if (!reader.IsDBNull(judgementColumnIndex)) record.Judgement =  Convert.ToString(reader.GetValue(judgementColumnIndex));

					if (!reader.IsDBNull(applicantStatusColumnIndex)) record.ApplicantStatus =  Convert.ToString(reader.GetValue(applicantStatusColumnIndex));

					if (!reader.IsDBNull(chargeColumnIndex)) record.Charge =  Convert.ToString(reader.GetValue(chargeColumnIndex));

					if (!reader.IsDBNull(modifiedDateColumnIndex)) record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CurrentCaseStatusRow[])(recordList.ToArray(typeof(CurrentCaseStatusRow)));
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
				case "CurrentStatusCaseID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "CaseID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ApplicantID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "CourID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "HelpCaseLevelID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "CaseTypeID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "HelpCaseLevelOther":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "CaseTypeOther":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "CaseRedNo":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "CaseBlackNo":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "LitigantTitle":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "LitigantName":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "Judgement":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "ApplicantStatus":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "Charge":
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

