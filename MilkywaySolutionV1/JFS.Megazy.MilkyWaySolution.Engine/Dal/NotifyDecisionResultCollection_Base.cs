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
	public partial class NotifyDecisionResultCollection_Base : MarshalByRefObject
	{
		public const string NotifyIDColumnName = "NotifyID";
		public const string CaseIDColumnName = "CaseID";
		public const string ApplicantIDColumnName = "ApplicantID";
		public const string NotifyDateColumnName = "NotifyDate";
		public const string IsSendSMSColumnName = "IsSendSMS";
		public const string TelephoneNoColumnName = "TelephoneNo";
		public const string IsSendEmailColumnName = "IsSendEmail";
		public const string EmailColumnName = "Email";
		public const string NoteColumnName = "Note";
		public const string ModifiedDateColumnName = "ModifiedDate";
		private int _processID;
		public SqlCommand cmd = null;
		public NotifyDecisionResultCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual NotifyDecisionResultRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}
		public virtual NotifyDecisionResultPaging GetPagingRelyOnNotifyIDdesc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			NotifyDecisionResultPaging notifyDecisionResultPaging = new NotifyDecisionResultPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(NotifyID) as TotalRow from [dbo].[NotifyDecisionResult]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			notifyDecisionResultPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			notifyDecisionResultPaging.totalPage = (int)Math.Ceiling((double) notifyDecisionResultPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnNotifyID(whereSql, "NotifyID Desc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			notifyDecisionResultPaging.notifyDecisionResultRow = MapRecords(command);
			return notifyDecisionResultPaging;
		}
		public virtual NotifyDecisionResultPaging GetPagingRelyOnNotifyIDasc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			NotifyDecisionResultPaging notifyDecisionResultPaging = new NotifyDecisionResultPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(NotifyID) as TotalRow from [dbo].[NotifyDecisionResult]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			notifyDecisionResultPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			notifyDecisionResultPaging.totalPage = (int)Math.Ceiling((double)notifyDecisionResultPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnNotifyID(whereSql, "NotifyID asc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			notifyDecisionResultPaging.notifyDecisionResultRow = MapRecords(command);
			return notifyDecisionResultPaging;
		}
		public virtual NotifyDecisionResultRow[] GetPagingRelyOnNotifyIDdescNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minNotifyID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And NotifyID < " + minNotifyID.ToString();
			}
			else
			{
				whereSql = "NotifyID < " + minNotifyID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnNotifyID(whereSql, "NotifyID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual NotifyDecisionResultRow[] GetPagingRelyOnNotifyIDascNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minNotifyID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And NotifyID > " + minNotifyID.ToString();
			}
			else
			{
				whereSql = "NotifyID > " + minNotifyID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnNotifyID(whereSql, "NotifyID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual NotifyDecisionResultRow[] GetPagingRelyOnNotifyIDascPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxNotifyID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And NotifyID < " + maxNotifyID.ToString();
			}
			else
			{
				whereSql = "NotifyID < " + maxNotifyID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnNotifyID(whereSql, "NotifyID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual NotifyDecisionResultRow[] GetPagingRelyOnNotifyIDdescPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxNotifyID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And NotifyID > " + maxNotifyID.ToString();
			}
			else
			{
				whereSql = "NotifyID > " + maxNotifyID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnNotifyID(whereSql, "NotifyID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual NotifyDecisionResultRow[] GetPagingRelyOnNotifyIDdescByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber ,string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "NotifyID Desc";
			}
			else
			{
				orderByColumn = orderByColumn + " Desc";
			}
			NotifyDecisionResultRow[] notifyDecisionResultRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnNotifyID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				notifyDecisionResultRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnNotifyIDdescByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				notifyDecisionResultRow = MapRecords(command);
			}
			return notifyDecisionResultRow;
		}
		public virtual NotifyDecisionResultRow[] GetPagingRelyOnNotifyIDascByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber, string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "NotifyID Asc";
			}
			else
			{
				orderByColumn = orderByColumn + " Asc";
			}
			NotifyDecisionResultRow[] notifyDecisionResultRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnNotifyID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				notifyDecisionResultRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnNotifyIDascByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				notifyDecisionResultRow = MapRecords(command);
			}
			return notifyDecisionResultRow;
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
			"[NotifyID],"+
			"[CaseID],"+
			"[ApplicantID],"+
			"[NotifyDate],"+
			"[IsSendSMS],"+
			"[TelephoneNo],"+
			"[IsSendEmail],"+
			"[Email],"+
			"[Note],"+
			"[ModifiedDate]"+
			" FROM [dbo].[NotifyDecisionResult]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnNotifyID(string whereSql, string orderBySql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[NotifyDecisionResult]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnNotifyIDdescByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "NotifyID Desc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[NotifyDecisionResult] where NotifyID < (select min(minNotifyID) from(select top " + (rowPerPage * pageNumber).ToString() + " NotifyID as minNotifyID from [dbo].[NotifyDecisionResult]" + subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[NotifyDecisionResult]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnNotifyIDascByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "NotifyID Asc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[NotifyDecisionResult] where NotifyID > (select max(maxNotifyID) from(select top " + (rowPerPage * pageNumber).ToString() + " NotifyID as maxNotifyID from [dbo].[NotifyDecisionResult]" +  subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[NotifyDecisionResult]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[NotifyDecisionResult]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "NotifyDecisionResult"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("NotifyID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CaseID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ApplicantID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("NotifyDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("IsSendSMS",Type.GetType("System.Boolean"));
			dataColumn = dataTable.Columns.Add("TelephoneNo",Type.GetType("System.String"));
			dataColumn.MaxLength = 13;
			dataColumn = dataTable.Columns.Add("IsSendEmail",Type.GetType("System.Boolean"));
			dataColumn = dataTable.Columns.Add("Email",Type.GetType("System.String"));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("Note",Type.GetType("System.String"));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			return dataTable;
		}
		public virtual NotifyDecisionResultRow[] GetByCaseID(int caseID)
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
		public virtual NotifyDecisionResultRow[] GetByApplicantID(int applicantID)
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
		public NotifyDecisionResultRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual NotifyDecisionResultRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="NotifyDecisionResultRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="NotifyDecisionResultRow"/> objects.</returns>
		public virtual NotifyDecisionResultRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[NotifyDecisionResult]", top);
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
		public NotifyDecisionResultRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			NotifyDecisionResultRow[] rows = null;
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
		public DataTable GetNotifyDecisionResultPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "NotifyID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "NotifyID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(NotifyID) AS TotalRow FROM [dbo].[NotifyDecisionResult] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,NotifyID,CaseID,ApplicantID,NotifyDate,IsSendSMS,TelephoneNo,IsSendEmail,Email,Note,ModifiedDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[NotifyDecisionResult] " + whereSql +
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
		public NotifyDecisionResultItemsPaging GetNotifyDecisionResultPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "NotifyID")
		{
		NotifyDecisionResultItemsPaging obj = new NotifyDecisionResultItemsPaging();
		DataTable dt = GetNotifyDecisionResultPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		NotifyDecisionResultItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new NotifyDecisionResultItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.NotifyID = Convert.ToInt32(dt.Rows[i]["NotifyID"]);
			record.CaseID = Convert.ToInt32(dt.Rows[i]["CaseID"]);
			record.ApplicantID = Convert.ToInt32(dt.Rows[i]["ApplicantID"]);
			if (dt.Rows[i]["NotifyDate"] != DBNull.Value)
			record.NotifyDate = Convert.ToDateTime(dt.Rows[i]["NotifyDate"]);
			if (dt.Rows[i]["IsSendSMS"] != DBNull.Value)
			record.IsSendSMS = Convert.ToBoolean(dt.Rows[i]["IsSendSMS"]);
			record.TelephoneNo = dt.Rows[i]["TelephoneNo"].ToString();
			if (dt.Rows[i]["IsSendEmail"] != DBNull.Value)
			record.IsSendEmail = Convert.ToBoolean(dt.Rows[i]["IsSendEmail"]);
			record.Email = dt.Rows[i]["Email"].ToString();
			record.Note = dt.Rows[i]["Note"].ToString();
			if (dt.Rows[i]["ModifiedDate"] != DBNull.Value)
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			recordList.Add(record);
		}
		obj.notifyDecisionResultItems = (NotifyDecisionResultItems[])(recordList.ToArray(typeof(NotifyDecisionResultItems)));
		return obj;
		}
		public NotifyDecisionResultRow GetByPrimaryKey(int notifyID)
		{
			string whereSql = "[NotifyID]=" + CreateSqlParameterName("NotifyID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "NotifyID", notifyID);
			NotifyDecisionResultRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public int Insert(NotifyDecisionResultRow value)		{
			string sqlStr = "INSERT INTO [dbo].[NotifyDecisionResult] (" +
			"[CaseID], " + 
			"[ApplicantID], " + 
			"[NotifyDate], " + 
			"[IsSendSMS], " + 
			"[TelephoneNo], " + 
			"[IsSendEmail], " + 
			"[Email], " + 
			"[Note], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("CaseID") + ", " +
			CreateSqlParameterName("ApplicantID") + ", " +
			CreateSqlParameterName("NotifyDate") + ", " +
			CreateSqlParameterName("IsSendSMS") + ", " +
			CreateSqlParameterName("TelephoneNo") + ", " +
			CreateSqlParameterName("IsSendEmail") + ", " +
			CreateSqlParameterName("Email") + ", " +
			CreateSqlParameterName("Note") + ", " +
			CreateSqlParameterName("ModifiedDate") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "CaseID", value.CaseID);
			AddParameter(cmd, "ApplicantID", value.ApplicantID);
			AddParameter(cmd, "NotifyDate", value.IsNotifyDateNull ? DBNull.Value : (object)value.NotifyDate);
			AddParameter(cmd, "IsSendSMS", value.IsIsSendSMSNull ? DBNull.Value : (object)value.IsSendSMS);
			AddParameter(cmd, "TelephoneNo", value.TelephoneNo);
			AddParameter(cmd, "IsSendEmail", value.IsIsSendEmailNull ? DBNull.Value : (object)value.IsSendEmail);
			AddParameter(cmd, "Email", value.Email);
			AddParameter(cmd, "Note", value.Note);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public int InsertOnlyPlainText(NotifyDecisionResultRow value)		{
			string sqlStr = "INSERT INTO [dbo].[NotifyDecisionResult] (" +
			"[CaseID], " + 
			"[ApplicantID], " + 
			"[NotifyDate], " + 
			"[IsSendSMS], " + 
			"[TelephoneNo], " + 
			"[IsSendEmail], " + 
			"[Email], " + 
			"[Note], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("CaseID") + ", " +
			CreateSqlParameterName("ApplicantID") + ", " +
			CreateSqlParameterName("NotifyDate") + ", " +
			CreateSqlParameterName("IsSendSMS") + ", " +
			CreateSqlParameterName("TelephoneNo") + ", " +
			CreateSqlParameterName("IsSendEmail") + ", " +
			CreateSqlParameterName("Email") + ", " +
			CreateSqlParameterName("Note") + ", " +
			CreateSqlParameterName("ModifiedDate") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "CaseID", value.CaseID);
			AddParameter(cmd, "ApplicantID", value.ApplicantID);
			AddParameter(cmd, "NotifyDate", value.IsNotifyDateNull ? DBNull.Value : (object)value.NotifyDate);
			AddParameter(cmd, "IsSendSMS", value.IsIsSendSMSNull ? DBNull.Value : (object)value.IsSendSMS);
			AddParameter(cmd, "TelephoneNo", Sanitizer.GetSafeHtmlFragment(value.TelephoneNo));
			AddParameter(cmd, "IsSendEmail", value.IsIsSendEmailNull ? DBNull.Value : (object)value.IsSendEmail);
			AddParameter(cmd, "Email", Sanitizer.GetSafeHtmlFragment(value.Email));
			AddParameter(cmd, "Note", Sanitizer.GetSafeHtmlFragment(value.Note));
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public bool Update(NotifyDecisionResultRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetNotifyID == true )
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
				if (value._IsSetNotifyDate)
				{
					strUpdate += "[NotifyDate]=" + CreateSqlParameterName("NotifyDate") + ",";
				}
				if (value._IsSetIsSendSMS)
				{
					strUpdate += "[IsSendSMS]=" + CreateSqlParameterName("IsSendSMS") + ",";
				}
				if (value._IsSetTelephoneNo)
				{
					strUpdate += "[TelephoneNo]=" + CreateSqlParameterName("TelephoneNo") + ",";
				}
				if (value._IsSetIsSendEmail)
				{
					strUpdate += "[IsSendEmail]=" + CreateSqlParameterName("IsSendEmail") + ",";
				}
				if (value._IsSetEmail)
				{
					strUpdate += "[Email]=" + CreateSqlParameterName("Email") + ",";
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
					strUpdate = "UPDATE [dbo].[NotifyDecisionResult] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[NotifyID]=" + CreateSqlParameterName("NotifyID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "NotifyID", value.NotifyID);
					AddParameter(cmd, "CaseID", value.CaseID);
					AddParameter(cmd, "ApplicantID", value.ApplicantID);
					AddParameter(cmd, "NotifyDate", value.IsNotifyDateNull ? DBNull.Value : (object)value.NotifyDate);
					AddParameter(cmd, "IsSendSMS", value.IsIsSendSMSNull ? DBNull.Value : (object)value.IsSendSMS);
					AddParameter(cmd, "TelephoneNo", value.TelephoneNo);
					AddParameter(cmd, "IsSendEmail", value.IsIsSendEmailNull ? DBNull.Value : (object)value.IsSendEmail);
					AddParameter(cmd, "Email", value.Email);
					AddParameter(cmd, "Note", value.Note);
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
				Exception ex = new Exception("Set incorrect primarykey PK(NotifyID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(NotifyDecisionResultRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetNotifyID == true )
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
				if (value._IsSetNotifyDate)
				{
					strUpdate += "[NotifyDate]=" + CreateSqlParameterName("NotifyDate") + ",";
				}
				if (value._IsSetIsSendSMS)
				{
					strUpdate += "[IsSendSMS]=" + CreateSqlParameterName("IsSendSMS") + ",";
				}
				if (value._IsSetTelephoneNo)
				{
					strUpdate += "[TelephoneNo]=" + CreateSqlParameterName("TelephoneNo") + ",";
				}
				if (value._IsSetIsSendEmail)
				{
					strUpdate += "[IsSendEmail]=" + CreateSqlParameterName("IsSendEmail") + ",";
				}
				if (value._IsSetEmail)
				{
					strUpdate += "[Email]=" + CreateSqlParameterName("Email") + ",";
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
					strUpdate = "UPDATE [dbo].[NotifyDecisionResult] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[NotifyID]=" + CreateSqlParameterName("NotifyID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "NotifyID", value.NotifyID);
					AddParameter(cmd, "CaseID", value.CaseID);
					AddParameter(cmd, "ApplicantID", value.ApplicantID);
					AddParameter(cmd, "NotifyDate", value.IsNotifyDateNull ? DBNull.Value : (object)value.NotifyDate);
					AddParameter(cmd, "IsSendSMS", value.IsIsSendSMSNull ? DBNull.Value : (object)value.IsSendSMS);
					AddParameter(cmd, "TelephoneNo", Sanitizer.GetSafeHtmlFragment(value.TelephoneNo));
					AddParameter(cmd, "IsSendEmail", value.IsIsSendEmailNull ? DBNull.Value : (object)value.IsSendEmail);
					AddParameter(cmd, "Email", Sanitizer.GetSafeHtmlFragment(value.Email));
					AddParameter(cmd, "Note", Sanitizer.GetSafeHtmlFragment(value.Note));
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
				Exception ex = new Exception("Set incorrect primarykey PK(NotifyID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int notifyID)
		{
			string whereSql = "[NotifyID]=" + CreateSqlParameterName("NotifyID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "NotifyID", notifyID);
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
		protected NotifyDecisionResultRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected NotifyDecisionResultRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected NotifyDecisionResultRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int notifyIDColumnIndex = reader.GetOrdinal("NotifyID");
			int caseIDColumnIndex = reader.GetOrdinal("CaseID");
			int applicantIDColumnIndex = reader.GetOrdinal("ApplicantID");
			int notifyDateColumnIndex = reader.GetOrdinal("NotifyDate");
			int isSendSMSColumnIndex = reader.GetOrdinal("IsSendSMS");
			int telephoneNoColumnIndex = reader.GetOrdinal("TelephoneNo");
			int isSendEmailColumnIndex = reader.GetOrdinal("IsSendEmail");
			int emailColumnIndex = reader.GetOrdinal("Email");
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
					NotifyDecisionResultRow record = new NotifyDecisionResultRow();
					recordList.Add(record);
					record.NotifyID =  Convert.ToInt32(reader.GetValue(notifyIDColumnIndex));
					record.CaseID =  Convert.ToInt32(reader.GetValue(caseIDColumnIndex));
					record.ApplicantID =  Convert.ToInt32(reader.GetValue(applicantIDColumnIndex));
					if (!reader.IsDBNull(notifyDateColumnIndex)) record.NotifyDate =  Convert.ToDateTime(reader.GetValue(notifyDateColumnIndex));

					if (!reader.IsDBNull(isSendSMSColumnIndex)) record.IsSendSMS =  Convert.ToBoolean(reader.GetValue(isSendSMSColumnIndex));

					if (!reader.IsDBNull(telephoneNoColumnIndex)) record.TelephoneNo =  Convert.ToString(reader.GetValue(telephoneNoColumnIndex));

					if (!reader.IsDBNull(isSendEmailColumnIndex)) record.IsSendEmail =  Convert.ToBoolean(reader.GetValue(isSendEmailColumnIndex));

					if (!reader.IsDBNull(emailColumnIndex)) record.Email =  Convert.ToString(reader.GetValue(emailColumnIndex));

					if (!reader.IsDBNull(noteColumnIndex)) record.Note =  Convert.ToString(reader.GetValue(noteColumnIndex));

					if (!reader.IsDBNull(modifiedDateColumnIndex)) record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (NotifyDecisionResultRow[])(recordList.ToArray(typeof(NotifyDecisionResultRow)));
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
				case "NotifyID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "CaseID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ApplicantID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "NotifyDate":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "IsSendSMS":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "TelephoneNo":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "IsSendEmail":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "Email":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
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

