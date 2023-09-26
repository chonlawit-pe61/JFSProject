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
	public partial class OfficerApprovedExpenseCollection_Base : MarshalByRefObject
	{
		public const string ApprovedIDColumnName = "ApprovedID";
		public const string CaseIDColumnName = "CaseID";
		public const string ApplicantIDColumnName = "ApplicantID";
		public const string OfficerRoleIDColumnName = "OfficerRoleID";
		public const string TotalAmountColumnName = "TotalAmount";
		public const string ApproveDateColumnName = "ApproveDate";
		public const string IsFinalApprovedColumnName = "IsFinalApproved";
		public const string NoteColumnName = "Note";
		public const string ModifiedDateColumnName = "ModifiedDate";
		private int _processID;
		public SqlCommand cmd = null;
		public OfficerApprovedExpenseCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual OfficerApprovedExpenseRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}
		public virtual OfficerApprovedExpensePaging GetPagingRelyOnApprovedIDdesc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			OfficerApprovedExpensePaging officerApprovedExpensePaging = new OfficerApprovedExpensePaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(ApprovedID) as TotalRow from [dbo].[OfficerApprovedExpense]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			officerApprovedExpensePaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			officerApprovedExpensePaging.totalPage = (int)Math.Ceiling((double) officerApprovedExpensePaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnApprovedID(whereSql, "ApprovedID Desc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			officerApprovedExpensePaging.officerApprovedExpenseRow = MapRecords(command);
			return officerApprovedExpensePaging;
		}
		public virtual OfficerApprovedExpensePaging GetPagingRelyOnApprovedIDasc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			OfficerApprovedExpensePaging officerApprovedExpensePaging = new OfficerApprovedExpensePaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(ApprovedID) as TotalRow from [dbo].[OfficerApprovedExpense]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			officerApprovedExpensePaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			officerApprovedExpensePaging.totalPage = (int)Math.Ceiling((double)officerApprovedExpensePaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnApprovedID(whereSql, "ApprovedID asc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			officerApprovedExpensePaging.officerApprovedExpenseRow = MapRecords(command);
			return officerApprovedExpensePaging;
		}
		public virtual OfficerApprovedExpenseRow[] GetPagingRelyOnApprovedIDdescNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minApprovedID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And ApprovedID < " + minApprovedID.ToString();
			}
			else
			{
				whereSql = "ApprovedID < " + minApprovedID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnApprovedID(whereSql, "ApprovedID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual OfficerApprovedExpenseRow[] GetPagingRelyOnApprovedIDascNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minApprovedID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And ApprovedID > " + minApprovedID.ToString();
			}
			else
			{
				whereSql = "ApprovedID > " + minApprovedID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnApprovedID(whereSql, "ApprovedID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual OfficerApprovedExpenseRow[] GetPagingRelyOnApprovedIDascPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxApprovedID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And ApprovedID < " + maxApprovedID.ToString();
			}
			else
			{
				whereSql = "ApprovedID < " + maxApprovedID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnApprovedID(whereSql, "ApprovedID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual OfficerApprovedExpenseRow[] GetPagingRelyOnApprovedIDdescPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxApprovedID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And ApprovedID > " + maxApprovedID.ToString();
			}
			else
			{
				whereSql = "ApprovedID > " + maxApprovedID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnApprovedID(whereSql, "ApprovedID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual OfficerApprovedExpenseRow[] GetPagingRelyOnApprovedIDdescByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber ,string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "ApprovedID Desc";
			}
			else
			{
				orderByColumn = orderByColumn + " Desc";
			}
			OfficerApprovedExpenseRow[] officerApprovedExpenseRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnApprovedID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				officerApprovedExpenseRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnApprovedIDdescByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				officerApprovedExpenseRow = MapRecords(command);
			}
			return officerApprovedExpenseRow;
		}
		public virtual OfficerApprovedExpenseRow[] GetPagingRelyOnApprovedIDascByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber, string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "ApprovedID Asc";
			}
			else
			{
				orderByColumn = orderByColumn + " Asc";
			}
			OfficerApprovedExpenseRow[] officerApprovedExpenseRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnApprovedID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				officerApprovedExpenseRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnApprovedIDascByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				officerApprovedExpenseRow = MapRecords(command);
			}
			return officerApprovedExpenseRow;
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
			"[ApprovedID],"+
			"[CaseID],"+
			"[ApplicantID],"+
			"[OfficerRoleID],"+
			"[TotalAmount],"+
			"[ApproveDate],"+
			"[IsFinalApproved],"+
			"[Note],"+
			"[ModifiedDate]"+
			" FROM [dbo].[OfficerApprovedExpense]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnApprovedID(string whereSql, string orderBySql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[OfficerApprovedExpense]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnApprovedIDdescByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "ApprovedID Desc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[OfficerApprovedExpense] where ApprovedID < (select min(minApprovedID) from(select top " + (rowPerPage * pageNumber).ToString() + " ApprovedID as minApprovedID from [dbo].[OfficerApprovedExpense]" + subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[OfficerApprovedExpense]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnApprovedIDascByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "ApprovedID Asc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[OfficerApprovedExpense] where ApprovedID > (select max(maxApprovedID) from(select top " + (rowPerPage * pageNumber).ToString() + " ApprovedID as maxApprovedID from [dbo].[OfficerApprovedExpense]" +  subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[OfficerApprovedExpense]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[OfficerApprovedExpense]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "OfficerApprovedExpense"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ApprovedID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CaseID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ApplicantID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("OfficerRoleID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TotalAmount",Type.GetType("System.Double"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ApproveDate",Type.GetType("System.DateTime"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("IsFinalApproved",Type.GetType("System.Boolean"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("Note",Type.GetType("System.String"));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			dataColumn.AllowDBNull = false;
			return dataTable;
		}
		public virtual OfficerApprovedExpenseRow[] GetByCaseID(int caseID)
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
		public virtual OfficerApprovedExpenseRow[] GetByApplicantID(int applicantID)
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
		public virtual OfficerApprovedExpenseRow[] GetByOfficerRoleID(int officerRoleID)
		{
			return MapRecords(CreateGetByOfficerRoleIDCommand(officerRoleID));
		}
		public virtual DataTable GetByOfficerRoleIDAsDataTable(int officerRoleID)
		{
			return MapRecordsToDataTable(CreateGetByOfficerRoleIDCommand(officerRoleID));
		}
		protected virtual IDbCommand CreateGetByOfficerRoleIDCommand(int officerRoleID)
		{
			string whereSql = "";
			whereSql += "[OfficerRoleID]=" + CreateSqlParameterName("OfficerRoleID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "OfficerRoleID", officerRoleID);
			return cmd;
		}
		public OfficerApprovedExpenseRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual OfficerApprovedExpenseRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="OfficerApprovedExpenseRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="OfficerApprovedExpenseRow"/> objects.</returns>
		public virtual OfficerApprovedExpenseRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[OfficerApprovedExpense]", top);
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
		public OfficerApprovedExpenseRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			OfficerApprovedExpenseRow[] rows = null;
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
		public DataTable GetOfficerApprovedExpensePagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "ApprovedID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "ApprovedID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(ApprovedID) AS TotalRow FROM [dbo].[OfficerApprovedExpense] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,ApprovedID,CaseID,ApplicantID,OfficerRoleID,TotalAmount,ApproveDate,IsFinalApproved,Note,ModifiedDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT [OfficerApprovedExpense].*, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[OfficerApprovedExpense] " + whereSql +
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
		public OfficerApprovedExpenseItemsPaging GetOfficerApprovedExpensePagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "ApprovedID")
		{
		OfficerApprovedExpenseItemsPaging obj = new OfficerApprovedExpenseItemsPaging();
		DataTable dt = GetOfficerApprovedExpensePagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		OfficerApprovedExpenseItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new OfficerApprovedExpenseItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.ApprovedID = Convert.ToInt32(dt.Rows[i]["ApprovedID"]);
			record.CaseID = Convert.ToInt32(dt.Rows[i]["CaseID"]);
			record.ApplicantID = Convert.ToInt32(dt.Rows[i]["ApplicantID"]);
			record.OfficerRoleID = Convert.ToInt32(dt.Rows[i]["OfficerRoleID"]);
			record.TotalAmount = Convert.ToDouble(dt.Rows[i]["TotalAmount"]);
			record.ApproveDate = Convert.ToDateTime(dt.Rows[i]["ApproveDate"]);
			record.IsFinalApproved = Convert.ToBoolean(dt.Rows[i]["IsFinalApproved"]);
			record.Note = dt.Rows[i]["Note"].ToString();
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			recordList.Add(record);
		}
		obj.officerApprovedExpenseItems = (OfficerApprovedExpenseItems[])(recordList.ToArray(typeof(OfficerApprovedExpenseItems)));
		return obj;
		}
		public OfficerApprovedExpenseRow GetByPrimaryKey(int approvedID)
		{
			string whereSql = "[ApprovedID]=" + CreateSqlParameterName("ApprovedID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ApprovedID", approvedID);
			OfficerApprovedExpenseRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public int Insert(OfficerApprovedExpenseRow value)		{
			string sqlStr = "INSERT INTO [dbo].[OfficerApprovedExpense] (" +
			"[CaseID], " + 
			"[ApplicantID], " + 
			"[OfficerRoleID], " + 
			"[TotalAmount], " + 
			"[ApproveDate], " + 
			"[IsFinalApproved], " + 
			"[Note], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("CaseID") + ", " +
			CreateSqlParameterName("ApplicantID") + ", " +
			CreateSqlParameterName("OfficerRoleID") + ", " +
			CreateSqlParameterName("TotalAmount") + ", " +
			CreateSqlParameterName("ApproveDate") + ", " +
			CreateSqlParameterName("IsFinalApproved") + ", " +
			CreateSqlParameterName("Note") + ", " +
			CreateSqlParameterName("ModifiedDate") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "CaseID", value.CaseID);
			AddParameter(cmd, "ApplicantID", value.ApplicantID);
			AddParameter(cmd, "OfficerRoleID", value.OfficerRoleID);
			AddParameter(cmd, "TotalAmount", value.TotalAmount);
			AddParameter(cmd, "ApproveDate", value.IsApproveDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.ApproveDate);
			AddParameter(cmd, "IsFinalApproved", value.IsFinalApproved);
			AddParameter(cmd, "Note", value.Note);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.ModifiedDate);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public int InsertOnlyPlainText(OfficerApprovedExpenseRow value)		{
			string sqlStr = "INSERT INTO [dbo].[OfficerApprovedExpense] (" +
			"[CaseID], " + 
			"[ApplicantID], " + 
			"[OfficerRoleID], " + 
			"[TotalAmount], " + 
			"[ApproveDate], " + 
			"[IsFinalApproved], " + 
			"[Note], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("CaseID") + ", " +
			CreateSqlParameterName("ApplicantID") + ", " +
			CreateSqlParameterName("OfficerRoleID") + ", " +
			CreateSqlParameterName("TotalAmount") + ", " +
			CreateSqlParameterName("ApproveDate") + ", " +
			CreateSqlParameterName("IsFinalApproved") + ", " +
			CreateSqlParameterName("Note") + ", " +
			CreateSqlParameterName("ModifiedDate") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "CaseID", value.CaseID);
			AddParameter(cmd, "ApplicantID", value.ApplicantID);
			AddParameter(cmd, "OfficerRoleID", value.OfficerRoleID);
			AddParameter(cmd, "TotalAmount", value.TotalAmount);
			AddParameter(cmd, "ApproveDate", value.IsApproveDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.ApproveDate);
			AddParameter(cmd, "IsFinalApproved", value.IsFinalApproved);
			AddParameter(cmd, "Note", Sanitizer.GetSafeHtmlFragment(value.Note));
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.ModifiedDate);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public bool Update(OfficerApprovedExpenseRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetApprovedID == true )
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
				if (value._IsSetOfficerRoleID)
				{
					strUpdate += "[OfficerRoleID]=" + CreateSqlParameterName("OfficerRoleID") + ",";
				}
				if (value._IsSetTotalAmount)
				{
					strUpdate += "[TotalAmount]=" + CreateSqlParameterName("TotalAmount") + ",";
				}
				if (value._IsSetApproveDate)
				{
					strUpdate += "[ApproveDate]=" + CreateSqlParameterName("ApproveDate") + ",";
				}
				if (value._IsSetIsFinalApproved)
				{
					strUpdate += "[IsFinalApproved]=" + CreateSqlParameterName("IsFinalApproved") + ",";
				}
				if (value._IsSetNote)
				{
					strUpdate += "[Note]=" + CreateSqlParameterName("Note") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[OfficerApprovedExpense] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[ApprovedID]=" + CreateSqlParameterName("ApprovedID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "ApprovedID", value.ApprovedID);
					AddParameter(cmd, "CaseID", value.CaseID);
					AddParameter(cmd, "ApplicantID", value.ApplicantID);
					AddParameter(cmd, "OfficerRoleID", value.OfficerRoleID);
					AddParameter(cmd, "TotalAmount", value.TotalAmount);
					AddParameter(cmd, "ApproveDate", value.IsApproveDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.ApproveDate);
					AddParameter(cmd, "IsFinalApproved", value.IsFinalApproved);
					AddParameter(cmd, "Note", value.Note);
					AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.ModifiedDate);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(ApprovedID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(OfficerApprovedExpenseRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetApprovedID == true )
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
				if (value._IsSetOfficerRoleID)
				{
					strUpdate += "[OfficerRoleID]=" + CreateSqlParameterName("OfficerRoleID") + ",";
				}
				if (value._IsSetTotalAmount)
				{
					strUpdate += "[TotalAmount]=" + CreateSqlParameterName("TotalAmount") + ",";
				}
				if (value._IsSetApproveDate)
				{
					strUpdate += "[ApproveDate]=" + CreateSqlParameterName("ApproveDate") + ",";
				}
				if (value._IsSetIsFinalApproved)
				{
					strUpdate += "[IsFinalApproved]=" + CreateSqlParameterName("IsFinalApproved") + ",";
				}
				if (value._IsSetNote)
				{
					strUpdate += "[Note]=" + CreateSqlParameterName("Note") + ",";
				}
				if (value._IsSetModifiedDate)
				{
					strUpdate += "[ModifiedDate]=" + CreateSqlParameterName("ModifiedDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[OfficerApprovedExpense] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[ApprovedID]=" + CreateSqlParameterName("ApprovedID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "ApprovedID", value.ApprovedID);
					AddParameter(cmd, "CaseID", value.CaseID);
					AddParameter(cmd, "ApplicantID", value.ApplicantID);
					AddParameter(cmd, "OfficerRoleID", value.OfficerRoleID);
					AddParameter(cmd, "TotalAmount", value.TotalAmount);
					AddParameter(cmd, "ApproveDate", value.IsApproveDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.ApproveDate);
					AddParameter(cmd, "IsFinalApproved", value.IsFinalApproved);
					AddParameter(cmd, "Note", Sanitizer.GetSafeHtmlFragment(value.Note));
					AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.ModifiedDate);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(ApprovedID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int approvedID)
		{
			string whereSql = "[ApprovedID]=" + CreateSqlParameterName("ApprovedID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ApprovedID", approvedID);
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
		public int DeleteByOfficerRoleID(int officerRoleID)
		{
			return CreateDeleteByOfficerRoleIDCommand(officerRoleID).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByOfficerRoleIDCommand(int officerRoleID)
		{
			string whereSql = "";
			whereSql += "[OfficerRoleID]=" + CreateSqlParameterName("OfficerRoleID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "OfficerRoleID", officerRoleID);
			return cmd;
		}
		protected OfficerApprovedExpenseRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected OfficerApprovedExpenseRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected OfficerApprovedExpenseRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int approvedIDColumnIndex = reader.GetOrdinal("ApprovedID");
			int caseIDColumnIndex = reader.GetOrdinal("CaseID");
			int applicantIDColumnIndex = reader.GetOrdinal("ApplicantID");
			int officerRoleIDColumnIndex = reader.GetOrdinal("OfficerRoleID");
			int totalAmountColumnIndex = reader.GetOrdinal("TotalAmount");
			int approveDateColumnIndex = reader.GetOrdinal("ApproveDate");
			int isFinalApprovedColumnIndex = reader.GetOrdinal("IsFinalApproved");
			int noteColumnIndex = reader.GetOrdinal("Note");
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
					OfficerApprovedExpenseRow record = new OfficerApprovedExpenseRow();
					recordList.Add(record);
					record.ApprovedID =  Convert.ToInt32(reader.GetValue(approvedIDColumnIndex));
					record.CaseID =  Convert.ToInt32(reader.GetValue(caseIDColumnIndex));
					record.ApplicantID =  Convert.ToInt32(reader.GetValue(applicantIDColumnIndex));
					record.OfficerRoleID =  Convert.ToInt32(reader.GetValue(officerRoleIDColumnIndex));
					record.TotalAmount =  Convert.ToDouble(reader.GetValue(totalAmountColumnIndex));
					record.ApproveDate =  Convert.ToDateTime(reader.GetValue(approveDateColumnIndex));
					record.IsFinalApproved =  Convert.ToBoolean(reader.GetValue(isFinalApprovedColumnIndex));
					if (!reader.IsDBNull(noteColumnIndex)) record.Note =  Convert.ToString(reader.GetValue(noteColumnIndex));

					record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));
					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (OfficerApprovedExpenseRow[])(recordList.ToArray(typeof(OfficerApprovedExpenseRow)));
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
				case "ApprovedID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "CaseID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ApplicantID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "OfficerRoleID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "TotalAmount":
					parameter = AddParameter(cmd, paramName, DbType.Double, value);
					break;
				case "ApproveDate":
					parameter = AddParameter(cmd, paramName, DbType.Date, value);
					break;
				case "IsFinalApproved":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "Note":
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

