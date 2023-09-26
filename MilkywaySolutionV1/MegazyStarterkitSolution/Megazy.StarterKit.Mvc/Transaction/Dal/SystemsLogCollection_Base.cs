using Microsoft.Security.Application;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.Data;
using System.Collections;
using Megazy.StarterKit.Mvc.Transaction.Structure;
namespace Megazy.StarterKit.Mvc.Transaction.Dal
{
	[Serializable]
	public partial class SystemsLogCollection_Base : MarshalByRefObject
	{
		public const string SystemsLogIDColumnName = "SystemsLogID";
		public const string ProcessIDColumnName = "ProcessID";
		public const string LogTypeColumnName = "LogType";
		public const string PageURLColumnName = "PageURL";
		public const string RawUrlColumnName = "RawUrl";
		public const string ErrorColumnName = "Error";
		public const string StampTimeColumnName = "StampTime";
		public const string IsIgnoreColumnName = "IsIgnore";
		public const string CommentColumnName = "Comment";
		private int _processID;
		public SqlCommand cmd = null;
		public SystemsLogCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual SystemsLogRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}
		public virtual SystemsLogPaging GetPagingRelyOnSystemsLogIDdesc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			SystemsLogPaging systemsLogPaging = new SystemsLogPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(SystemsLogID) as TotalRow from [dbo].[SystemsLog]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			systemsLogPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			systemsLogPaging.totalPage = (int)Math.Ceiling((double) systemsLogPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnSystemsLogID(whereSql, "SystemsLogID Desc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			systemsLogPaging.systemsLogRow = MapRecords(command);
			return systemsLogPaging;
		}
		public virtual SystemsLogPaging GetPagingRelyOnSystemsLogIDasc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			SystemsLogPaging systemsLogPaging = new SystemsLogPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(SystemsLogID) as TotalRow from [dbo].[SystemsLog]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			systemsLogPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			systemsLogPaging.totalPage = (int)Math.Ceiling((double)systemsLogPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnSystemsLogID(whereSql, "SystemsLogID asc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			systemsLogPaging.systemsLogRow = MapRecords(command);
			return systemsLogPaging;
		}
		public virtual SystemsLogRow[] GetPagingRelyOnSystemsLogIDdescNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minSystemsLogID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And SystemsLogID < " + minSystemsLogID.ToString();
			}
			else
			{
				whereSql = "SystemsLogID < " + minSystemsLogID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnSystemsLogID(whereSql, "SystemsLogID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual SystemsLogRow[] GetPagingRelyOnSystemsLogIDascNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minSystemsLogID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And SystemsLogID > " + minSystemsLogID.ToString();
			}
			else
			{
				whereSql = "SystemsLogID > " + minSystemsLogID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnSystemsLogID(whereSql, "SystemsLogID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual SystemsLogRow[] GetPagingRelyOnSystemsLogIDascPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxSystemsLogID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And SystemsLogID < " + maxSystemsLogID.ToString();
			}
			else
			{
				whereSql = "SystemsLogID < " + maxSystemsLogID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnSystemsLogID(whereSql, "SystemsLogID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual SystemsLogRow[] GetPagingRelyOnSystemsLogIDdescPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxSystemsLogID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And SystemsLogID > " + maxSystemsLogID.ToString();
			}
			else
			{
				whereSql = "SystemsLogID > " + maxSystemsLogID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnSystemsLogID(whereSql, "SystemsLogID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual SystemsLogRow[] GetPagingRelyOnSystemsLogIDdescByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber ,string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "SystemsLogID Desc";
			}
			else
			{
				orderByColumn = orderByColumn + " Desc";
			}
			SystemsLogRow[] systemsLogRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnSystemsLogID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				systemsLogRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnSystemsLogIDdescByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				systemsLogRow = MapRecords(command);
			}
			return systemsLogRow;
		}
		public virtual SystemsLogRow[] GetPagingRelyOnSystemsLogIDascByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber, string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "SystemsLogID Asc";
			}
			else
			{
				orderByColumn = orderByColumn + " Asc";
			}
			SystemsLogRow[] systemsLogRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnSystemsLogID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				systemsLogRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnSystemsLogIDascByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				systemsLogRow = MapRecords(command);
			}
			return systemsLogRow;
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
			"[SystemsLogID],"+
			"[ProcessID],"+
			"[LogType],"+
			"[PageURL],"+
			"[RawUrl],"+
			"[Error],"+
			"[StampTime],"+
			"[IsIgnore],"+
			"[Comment]"+
			" FROM [dbo].[SystemsLog]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnSystemsLogID(string whereSql, string orderBySql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[SystemsLog]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnSystemsLogIDdescByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "SystemsLogID Desc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[SystemsLog] where SystemsLogID < (select min(minSystemsLogID) from(select top " + (rowPerPage * pageNumber).ToString() + " SystemsLogID as minSystemsLogID from [dbo].[SystemsLog]" + subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[SystemsLog]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnSystemsLogIDascByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "SystemsLogID Asc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[SystemsLog] where SystemsLogID > (select max(maxSystemsLogID) from(select top " + (rowPerPage * pageNumber).ToString() + " SystemsLogID as maxSystemsLogID from [dbo].[SystemsLog]" +  subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[SystemsLog]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[SystemsLog]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "SystemsLog"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("SystemsLogID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ProcessID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("LogType",Type.GetType("System.String"));
			dataColumn.MaxLength = 2147483647;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PageURL",Type.GetType("System.String"));
			dataColumn.MaxLength = 2147483647;
			dataColumn = dataTable.Columns.Add("RawUrl",Type.GetType("System.String"));
			dataColumn.MaxLength = 2147483647;
			dataColumn = dataTable.Columns.Add("Error",Type.GetType("System.String"));
			dataColumn.MaxLength = 2147483647;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("StampTime",Type.GetType("System.DateTime"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("IsIgnore",Type.GetType("System.Boolean"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("Comment",Type.GetType("System.String"));
			dataColumn.MaxLength = 2000;
			return dataTable;
		}
		public SystemsLogRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual SystemsLogRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="SystemsLogRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="SystemsLogRow"/> objects.</returns>
		public virtual SystemsLogRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[SystemsLog]", top);
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
		public SystemsLogRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			SystemsLogRow[] rows = null;
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
		public DataTable GetSystemsLogPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "SystemsLogID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "SystemsLogID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(SystemsLogID) AS TotalRow FROM [dbo].[SystemsLog] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,SystemsLogID,ProcessID,LogType,PageURL,RawUrl,Error,StampTime,IsIgnore,Comment," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT [SystemsLog].*, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[SystemsLog] " + whereSql +
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
		public SystemsLogItemsPaging GetSystemsLogPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "SystemsLogID")
		{
		SystemsLogItemsPaging obj = new SystemsLogItemsPaging();
		DataTable dt = GetSystemsLogPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		SystemsLogItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new SystemsLogItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.SystemsLogID = Convert.ToInt32(dt.Rows[i]["SystemsLogID"]);
			record.ProcessID = Convert.ToInt32(dt.Rows[i]["ProcessID"]);
			record.LogType = dt.Rows[i]["LogType"].ToString();
			record.PageURL = dt.Rows[i]["PageURL"].ToString();
			record.RawUrl = dt.Rows[i]["RawUrl"].ToString();
			record.Error = dt.Rows[i]["Error"].ToString();
			record.StampTime = Convert.ToDateTime(dt.Rows[i]["StampTime"]);
			record.IsIgnore = Convert.ToBoolean(dt.Rows[i]["IsIgnore"]);
			record.Comment = dt.Rows[i]["Comment"].ToString();
			recordList.Add(record);
		}
		obj.systemsLogItems = (SystemsLogItems[])(recordList.ToArray(typeof(SystemsLogItems)));
		return obj;
		}
		public SystemsLogRow GetByPrimaryKey(int systemsLogID)
		{
			string whereSql = "[SystemsLogID]=" + CreateSqlParameterName("SystemsLogID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "SystemsLogID", systemsLogID);
			SystemsLogRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public int Insert(SystemsLogRow value)		{
			string sqlStr = "INSERT INTO [dbo].[SystemsLog] (" +
			"[ProcessID], " + 
			"[LogType], " + 
			"[PageURL], " + 
			"[RawUrl], " + 
			"[Error], " + 
			"[StampTime], " + 
			"[IsIgnore], " + 
			"[Comment]			" + 
			") VALUES (" +
			CreateSqlParameterName("ProcessID") + ", " +
			CreateSqlParameterName("LogType") + ", " +
			CreateSqlParameterName("PageURL") + ", " +
			CreateSqlParameterName("RawUrl") + ", " +
			CreateSqlParameterName("Error") + ", " +
			CreateSqlParameterName("StampTime") + ", " +
			CreateSqlParameterName("IsIgnore") + ", " +
			CreateSqlParameterName("Comment") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "ProcessID", value.ProcessID);
			AddParameter(cmd, "LogType",value.LogType);
			AddParameter(cmd, "PageURL", value.PageURL);
			AddParameter(cmd, "RawUrl", value.RawUrl);
			AddParameter(cmd, "Error",value.Error);
			AddParameter(cmd, "StampTime", value.IsStampTimeNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.StampTime);
			AddParameter(cmd, "IsIgnore", value.IsIgnore);
			AddParameter(cmd, "Comment", value.Comment);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public int InsertOnlyPlainText(SystemsLogRow value)		{
			string sqlStr = "INSERT INTO [dbo].[SystemsLog] (" +
			"[ProcessID], " + 
			"[LogType], " + 
			"[PageURL], " + 
			"[RawUrl], " + 
			"[Error], " + 
			"[StampTime], " + 
			"[IsIgnore], " + 
			"[Comment]			" + 
			") VALUES (" +
			CreateSqlParameterName("ProcessID") + ", " +
			CreateSqlParameterName("LogType") + ", " +
			CreateSqlParameterName("PageURL") + ", " +
			CreateSqlParameterName("RawUrl") + ", " +
			CreateSqlParameterName("Error") + ", " +
			CreateSqlParameterName("StampTime") + ", " +
			CreateSqlParameterName("IsIgnore") + ", " +
			CreateSqlParameterName("Comment") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "ProcessID", value.ProcessID);
			AddParameter(cmd, "LogType", Sanitizer.GetSafeHtmlFragment(value.LogType));
			AddParameter(cmd, "PageURL", Sanitizer.GetSafeHtmlFragment(value.PageURL));
			AddParameter(cmd, "RawUrl", Sanitizer.GetSafeHtmlFragment(value.RawUrl));
			AddParameter(cmd, "Error", Sanitizer.GetSafeHtmlFragment(value.Error));
			AddParameter(cmd, "StampTime", value.IsStampTimeNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.StampTime);
			AddParameter(cmd, "IsIgnore", value.IsIgnore);
			AddParameter(cmd, "Comment", Sanitizer.GetSafeHtmlFragment(value.Comment));
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public bool Update(SystemsLogRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetSystemsLogID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetProcessID)
				{
					strUpdate += "[ProcessID]=" + CreateSqlParameterName("ProcessID") + ",";
				}
				if (value._IsSetLogType)
				{
					strUpdate += "[LogType]=" + CreateSqlParameterName("LogType") + ",";
				}
				if (value._IsSetPageURL)
				{
					strUpdate += "[PageURL]=" + CreateSqlParameterName("PageURL") + ",";
				}
				if (value._IsSetRawUrl)
				{
					strUpdate += "[RawUrl]=" + CreateSqlParameterName("RawUrl") + ",";
				}
				if (value._IsSetError)
				{
					strUpdate += "[Error]=" + CreateSqlParameterName("Error") + ",";
				}
				if (value._IsSetStampTime)
				{
					strUpdate += "[StampTime]=" + CreateSqlParameterName("StampTime") + ",";
				}
				if (value._IsSetIsIgnore)
				{
					strUpdate += "[IsIgnore]=" + CreateSqlParameterName("IsIgnore") + ",";
				}
				if (value._IsSetComment)
				{
					strUpdate += "[Comment]=" + CreateSqlParameterName("Comment") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[SystemsLog] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[SystemsLogID]=" + CreateSqlParameterName("SystemsLogID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "SystemsLogID", value.SystemsLogID);
					AddParameter(cmd, "ProcessID", value.ProcessID);
					AddParameter(cmd, "LogType",value.LogType);
					AddParameter(cmd, "PageURL", value.PageURL);
					AddParameter(cmd, "RawUrl", value.RawUrl);
					AddParameter(cmd, "Error",value.Error);
					AddParameter(cmd, "StampTime", value.IsStampTimeNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.StampTime);
					AddParameter(cmd, "IsIgnore", value.IsIgnore);
					AddParameter(cmd, "Comment", value.Comment);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(SystemsLogID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(SystemsLogRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetSystemsLogID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetProcessID)
				{
					strUpdate += "[ProcessID]=" + CreateSqlParameterName("ProcessID") + ",";
				}
				if (value._IsSetLogType)
				{
					strUpdate += "[LogType]=" + CreateSqlParameterName("LogType") + ",";
				}
				if (value._IsSetPageURL)
				{
					strUpdate += "[PageURL]=" + CreateSqlParameterName("PageURL") + ",";
				}
				if (value._IsSetRawUrl)
				{
					strUpdate += "[RawUrl]=" + CreateSqlParameterName("RawUrl") + ",";
				}
				if (value._IsSetError)
				{
					strUpdate += "[Error]=" + CreateSqlParameterName("Error") + ",";
				}
				if (value._IsSetStampTime)
				{
					strUpdate += "[StampTime]=" + CreateSqlParameterName("StampTime") + ",";
				}
				if (value._IsSetIsIgnore)
				{
					strUpdate += "[IsIgnore]=" + CreateSqlParameterName("IsIgnore") + ",";
				}
				if (value._IsSetComment)
				{
					strUpdate += "[Comment]=" + CreateSqlParameterName("Comment") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[SystemsLog] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[SystemsLogID]=" + CreateSqlParameterName("SystemsLogID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "SystemsLogID", value.SystemsLogID);
					AddParameter(cmd, "ProcessID", value.ProcessID);
					AddParameter(cmd, "LogType", Sanitizer.GetSafeHtmlFragment(value.LogType));
					AddParameter(cmd, "PageURL", Sanitizer.GetSafeHtmlFragment(value.PageURL));
					AddParameter(cmd, "RawUrl", Sanitizer.GetSafeHtmlFragment(value.RawUrl));
					AddParameter(cmd, "Error", Sanitizer.GetSafeHtmlFragment(value.Error));
					AddParameter(cmd, "StampTime", value.IsStampTimeNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.StampTime);
					AddParameter(cmd, "IsIgnore", value.IsIgnore);
					AddParameter(cmd, "Comment", Sanitizer.GetSafeHtmlFragment(value.Comment));
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(SystemsLogID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int systemsLogID)
		{
			string whereSql = "[SystemsLogID]=" + CreateSqlParameterName("SystemsLogID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "SystemsLogID", systemsLogID);
			return 0 < cmd.ExecuteNonQuery();
		}
		protected SystemsLogRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected SystemsLogRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected SystemsLogRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int systemsLogIDColumnIndex = reader.GetOrdinal("SystemsLogID");
			int processIDColumnIndex = reader.GetOrdinal("ProcessID");
			int logTypeColumnIndex = reader.GetOrdinal("LogType");
			int pageURLColumnIndex = reader.GetOrdinal("PageURL");
			int rawUrlColumnIndex = reader.GetOrdinal("RawUrl");
			int errorColumnIndex = reader.GetOrdinal("Error");
			int stampTimeColumnIndex = reader.GetOrdinal("StampTime");
			int isignoreColumnIndex = reader.GetOrdinal("IsIgnore");
			int commentColumnIndex = reader.GetOrdinal("Comment");
			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			int countRecordRow = 0;
			while (reader.Read())
			{
				countRecordRow++;
				ri++;
				if (ri > 0 && ri <= length)
				{
					SystemsLogRow record = new SystemsLogRow();
					recordList.Add(record);
					record.SystemsLogID =  Convert.ToInt32(reader.GetValue(systemsLogIDColumnIndex));
					record.ProcessID =  Convert.ToInt32(reader.GetValue(processIDColumnIndex));
					record.LogType =  Convert.ToString(reader.GetValue(logTypeColumnIndex));
					if (!reader.IsDBNull(pageURLColumnIndex)) record.PageURL =  Convert.ToString(reader.GetValue(pageURLColumnIndex));

					if (!reader.IsDBNull(rawUrlColumnIndex)) record.RawUrl =  Convert.ToString(reader.GetValue(rawUrlColumnIndex));

					record.Error =  Convert.ToString(reader.GetValue(errorColumnIndex));
					record.StampTime =  Convert.ToDateTime(reader.GetValue(stampTimeColumnIndex));
					record.IsIgnore =  Convert.ToBoolean(reader.GetValue(isignoreColumnIndex));
					if (!reader.IsDBNull(commentColumnIndex)) record.Comment =  Convert.ToString(reader.GetValue(commentColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (SystemsLogRow[])(recordList.ToArray(typeof(SystemsLogRow)));
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
				case "SystemsLogID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "ProcessID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "LogType":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "PageURL":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "RawUrl":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "Error":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "StampTime":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "IsIgnore":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "Comment":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
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

