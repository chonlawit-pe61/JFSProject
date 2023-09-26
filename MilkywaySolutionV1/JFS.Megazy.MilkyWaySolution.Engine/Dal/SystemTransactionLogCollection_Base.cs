using System.ServiceModel;
using Microsoft.Security.Application;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.Data;
using System.Collections;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;
namespace JFS.Megazy.MilkyWaySolution.Engine.Dal
{
	public partial class SystemTransactionLogCollection_Base
	{
		public const string TransactionLogIDColumnName = "TransactionLogID";
		public const string UserIDColumnName = "UserID";
		public const string UserFullNameColumnName = "UserFullName";
		public const string ReferenceKeyValueColumnName = "ReferenceKeyValue";
		public const string ReferenceKeyNameColumnName = "ReferenceKeyName";
		public const string TransactionTypeNameColumnName = "TransactionTypeName";
		public const string CommentColumnName = "Comment";
		public const string ModifiedDateColumnName = "ModifiedDate";
		private int _processID;
		public SqlCommand cmd = null;
		public SystemTransactionLogCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual SystemTransactionLogRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}
		public virtual SystemTransactionLogPaging GetPagingRelyOnTransactionLogIDdesc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			SystemTransactionLogPaging systemTransactionLogPaging = new SystemTransactionLogPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(TransactionLogID) as TotalRow from [dbo].[SystemTransactionLog]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			systemTransactionLogPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			systemTransactionLogPaging.totalPage = (int)Math.Ceiling((double) systemTransactionLogPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnTransactionLogID(whereSql, "TransactionLogID Desc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			systemTransactionLogPaging.systemTransactionLogRow = MapRecords(command);
			return systemTransactionLogPaging;
		}
		public virtual SystemTransactionLogPaging GetPagingRelyOnTransactionLogIDasc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			SystemTransactionLogPaging systemTransactionLogPaging = new SystemTransactionLogPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(TransactionLogID) as TotalRow from [dbo].[SystemTransactionLog]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			systemTransactionLogPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			systemTransactionLogPaging.totalPage = (int)Math.Ceiling((double)systemTransactionLogPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnTransactionLogID(whereSql, "TransactionLogID asc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			systemTransactionLogPaging.systemTransactionLogRow = MapRecords(command);
			return systemTransactionLogPaging;
		}
		public virtual SystemTransactionLogRow[] GetPagingRelyOnTransactionLogIDdescNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minTransactionLogID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And TransactionLogID < " + minTransactionLogID.ToString();
			}
			else
			{
				whereSql = "TransactionLogID < " + minTransactionLogID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnTransactionLogID(whereSql, "TransactionLogID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual SystemTransactionLogRow[] GetPagingRelyOnTransactionLogIDascNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minTransactionLogID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And TransactionLogID > " + minTransactionLogID.ToString();
			}
			else
			{
				whereSql = "TransactionLogID > " + minTransactionLogID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnTransactionLogID(whereSql, "TransactionLogID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual SystemTransactionLogRow[] GetPagingRelyOnTransactionLogIDascPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxTransactionLogID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And TransactionLogID < " + maxTransactionLogID.ToString();
			}
			else
			{
				whereSql = "TransactionLogID < " + maxTransactionLogID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnTransactionLogID(whereSql, "TransactionLogID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual SystemTransactionLogRow[] GetPagingRelyOnTransactionLogIDdescPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxTransactionLogID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And TransactionLogID > " + maxTransactionLogID.ToString();
			}
			else
			{
				whereSql = "TransactionLogID > " + maxTransactionLogID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnTransactionLogID(whereSql, "TransactionLogID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual SystemTransactionLogRow[] GetPagingRelyOnTransactionLogIDdescByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber ,string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "TransactionLogID Desc";
			}
			else
			{
				orderByColumn = orderByColumn + " Desc";
			}
			SystemTransactionLogRow[] systemTransactionLogRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnTransactionLogID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				systemTransactionLogRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnTransactionLogIDdescByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				systemTransactionLogRow = MapRecords(command);
			}
			return systemTransactionLogRow;
		}
		public virtual SystemTransactionLogRow[] GetPagingRelyOnTransactionLogIDascByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber, string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "TransactionLogID Asc";
			}
			else
			{
				orderByColumn = orderByColumn + " Asc";
			}
			SystemTransactionLogRow[] systemTransactionLogRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnTransactionLogID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				systemTransactionLogRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnTransactionLogIDascByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				systemTransactionLogRow = MapRecords(command);
			}
			return systemTransactionLogRow;
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
			"[TransactionLogID],"+
			"[UserID],"+
			"[UserFullName],"+
			"[ReferenceKeyValue],"+
			"[ReferenceKeyName],"+
			"[TransactionTypeName],"+
			"[Comment],"+
			"[ModifiedDate]"+
			" FROM [dbo].[SystemTransactionLog]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnTransactionLogID(string whereSql, string orderBySql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[SystemTransactionLog]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnTransactionLogIDdescByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "TransactionLogID Desc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[SystemTransactionLog] where TransactionLogID < (select min(minTransactionLogID) from(select top " + (rowPerPage * pageNumber).ToString() + " TransactionLogID as minTransactionLogID from [dbo].[SystemTransactionLog]" + subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM [dbo].[SystemTransactionLog]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnTransactionLogIDascByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "TransactionLogID Asc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[SystemTransactionLog] where TransactionLogID > (select max(maxTransactionLogID) from(select top " + (rowPerPage * pageNumber).ToString() + " TransactionLogID as maxTransactionLogID from [dbo].[SystemTransactionLog]" +  subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM [dbo].[SystemTransactionLog]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[SystemTransactionLog]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "SystemTransactionLog"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("TransactionLogID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("UserID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("UserFullName",Type.GetType("System.String"));
			dataColumn.MaxLength = 250;
			dataColumn = dataTable.Columns.Add("ReferenceKeyValue",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("ReferenceKeyName",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("TransactionTypeName",Type.GetType("System.String"));
			dataColumn.MaxLength = 225;
			dataColumn = dataTable.Columns.Add("Comment",Type.GetType("System.String"));
			dataColumn.MaxLength = 2000;
			dataColumn = dataTable.Columns.Add("ModifiedDate",Type.GetType("System.DateTime"));
			return dataTable;
		}
		public virtual SystemTransactionLogRow[] GetByUserID(int userID)
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
		public SystemTransactionLogRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual SystemTransactionLogRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="SystemTransactionLogRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="SystemTransactionLogRow"/> objects.</returns>
		public virtual SystemTransactionLogRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[SystemTransactionLog]", top);
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
		public SystemTransactionLogRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			SystemTransactionLogRow[] rows = null;
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
		public DataTable GetSystemTransactionLogPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "TransactionLogID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "TransactionLogID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(TransactionLogID) AS TotalRow FROM [dbo].[SystemTransactionLog] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,TransactionLogID,UserID,UserFullName,ReferenceKeyValue,ReferenceKeyName,TransactionTypeName,Comment,ModifiedDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT *, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[SystemTransactionLog] " + whereSql +
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
		public SystemTransactionLogItemsPaging GetSystemTransactionLogPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "TransactionLogID")
		{
		SystemTransactionLogItemsPaging obj = new SystemTransactionLogItemsPaging();
		DataTable dt = GetSystemTransactionLogPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		SystemTransactionLogItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new SystemTransactionLogItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.TransactionLogID = Convert.ToInt32(dt.Rows[i]["TransactionLogID"]);
			if (dt.Rows[i]["UserID"] != DBNull.Value)
			record.UserID = Convert.ToInt32(dt.Rows[i]["UserID"]);
			record.UserFullName = dt.Rows[i]["UserFullName"].ToString();
			record.ReferenceKeyValue = dt.Rows[i]["ReferenceKeyValue"].ToString();
			record.ReferenceKeyName = dt.Rows[i]["ReferenceKeyName"].ToString();
			record.TransactionTypeName = dt.Rows[i]["TransactionTypeName"].ToString();
			record.Comment = dt.Rows[i]["Comment"].ToString();
			if (dt.Rows[i]["ModifiedDate"] != DBNull.Value)
			record.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["ModifiedDate"]);
			recordList.Add(record);
		}
		obj.systemTransactionLogItems = (SystemTransactionLogItems[])(recordList.ToArray(typeof(SystemTransactionLogItems)));
		return obj;
		}
		public SystemTransactionLogRow GetByPrimaryKey(int transactionLogID)
		{
			string whereSql = "[TransactionLogID]=" + CreateSqlParameterName("TransactionLogID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "TransactionLogID", transactionLogID);
			SystemTransactionLogRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public int Insert(SystemTransactionLogRow value)		{
			string sqlStr = "INSERT INTO [dbo].[SystemTransactionLog] (" +
			"[UserID], " + 
			"[UserFullName], " + 
			"[ReferenceKeyValue], " + 
			"[ReferenceKeyName], " + 
			"[TransactionTypeName], " + 
			"[Comment], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("UserID") + ", " +
			CreateSqlParameterName("UserFullName") + ", " +
			CreateSqlParameterName("ReferenceKeyValue") + ", " +
			CreateSqlParameterName("ReferenceKeyName") + ", " +
			CreateSqlParameterName("TransactionTypeName") + ", " +
			CreateSqlParameterName("Comment") + ", " +
			CreateSqlParameterName("ModifiedDate") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "UserID", value.IsUserIDNull ? DBNull.Value : (object)value.UserID);
			AddParameter(cmd, "UserFullName", value.IsUserFullNameNull ? DBNull.Value : (object)value.UserFullName);
			AddParameter(cmd, "ReferenceKeyValue", value.IsReferenceKeyValueNull ? DBNull.Value : (object)value.ReferenceKeyValue);
			AddParameter(cmd, "ReferenceKeyName", value.IsReferenceKeyNameNull ? DBNull.Value : (object)value.ReferenceKeyName);
			AddParameter(cmd, "TransactionTypeName", value.IsTransactionTypeNameNull ? DBNull.Value : (object)value.TransactionTypeName);
			AddParameter(cmd, "Comment", value.IsCommentNull ? DBNull.Value : (object)value.Comment);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public int InsertOnlyPlainText(SystemTransactionLogRow value)		{
			string sqlStr = "INSERT INTO [dbo].[SystemTransactionLog] (" +
			"[UserID], " + 
			"[UserFullName], " + 
			"[ReferenceKeyValue], " + 
			"[ReferenceKeyName], " + 
			"[TransactionTypeName], " + 
			"[Comment], " + 
			"[ModifiedDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("UserID") + ", " +
			CreateSqlParameterName("UserFullName") + ", " +
			CreateSqlParameterName("ReferenceKeyValue") + ", " +
			CreateSqlParameterName("ReferenceKeyName") + ", " +
			CreateSqlParameterName("TransactionTypeName") + ", " +
			CreateSqlParameterName("Comment") + ", " +
			CreateSqlParameterName("ModifiedDate") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "UserID", value.IsUserIDNull ? DBNull.Value : (object)value.UserID);
			AddParameter(cmd, "UserFullName", value.IsUserFullNameNull ? DBNull.Value : (object)value.UserFullName);
			AddParameter(cmd, "ReferenceKeyValue", value.IsReferenceKeyValueNull ? DBNull.Value : (object)value.ReferenceKeyValue);
			AddParameter(cmd, "ReferenceKeyName", value.IsReferenceKeyNameNull ? DBNull.Value : (object)value.ReferenceKeyName);
			AddParameter(cmd, "TransactionTypeName", value.IsTransactionTypeNameNull ? DBNull.Value : (object)value.TransactionTypeName);
			AddParameter(cmd, "Comment", value.IsCommentNull ? DBNull.Value : (object)value.Comment);
			AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public bool Update(SystemTransactionLogRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetTransactionLogID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetUserID)
				{
					strUpdate += "[UserID]=" + CreateSqlParameterName("UserID") + ",";
				}
				if (value._IsSetUserFullName)
				{
					strUpdate += "[UserFullName]=" + CreateSqlParameterName("UserFullName") + ",";
				}
				if (value._IsSetReferenceKeyValue)
				{
					strUpdate += "[ReferenceKeyValue]=" + CreateSqlParameterName("ReferenceKeyValue") + ",";
				}
				if (value._IsSetReferenceKeyName)
				{
					strUpdate += "[ReferenceKeyName]=" + CreateSqlParameterName("ReferenceKeyName") + ",";
				}
				if (value._IsSetTransactionTypeName)
				{
					strUpdate += "[TransactionTypeName]=" + CreateSqlParameterName("TransactionTypeName") + ",";
				}
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
					strUpdate = "UPDATE [dbo].[SystemTransactionLog] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[TransactionLogID]=" + CreateSqlParameterName("TransactionLogID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "TransactionLogID", value.TransactionLogID);
				if (value._IsSetUserID)
				{
					AddParameter(cmd, "UserID", value.IsUserIDNull ? DBNull.Value : (object)value.UserID);
				}
					AddParameter(cmd, "UserFullName", value.UserFullName);
					AddParameter(cmd, "ReferenceKeyValue", value.ReferenceKeyValue);
					AddParameter(cmd, "ReferenceKeyName", value.ReferenceKeyName);
					AddParameter(cmd, "TransactionTypeName", value.TransactionTypeName);
					AddParameter(cmd, "Comment", value.Comment);
				if (value._IsSetModifiedDate)
				{
					AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
				}
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(TransactionLogID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			if (rt > 0)
			{
			}
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(SystemTransactionLogRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetTransactionLogID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetUserID)
				{
					strUpdate += "[UserID]=" + CreateSqlParameterName("UserID") + ",";
				}
				if (value._IsSetUserFullName)
				{
					strUpdate += "[UserFullName]=" + CreateSqlParameterName("UserFullName") + ",";
				}
				if (value._IsSetReferenceKeyValue)
				{
					strUpdate += "[ReferenceKeyValue]=" + CreateSqlParameterName("ReferenceKeyValue") + ",";
				}
				if (value._IsSetReferenceKeyName)
				{
					strUpdate += "[ReferenceKeyName]=" + CreateSqlParameterName("ReferenceKeyName") + ",";
				}
				if (value._IsSetTransactionTypeName)
				{
					strUpdate += "[TransactionTypeName]=" + CreateSqlParameterName("TransactionTypeName") + ",";
				}
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
					strUpdate = "UPDATE [dbo].[SystemTransactionLog] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[TransactionLogID]=" + CreateSqlParameterName("TransactionLogID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "TransactionLogID", value.TransactionLogID);
				if (value._IsSetUserID)
				{
					AddParameter(cmd, "UserID", value.IsUserIDNull ? DBNull.Value : (object)value.UserID);
				}
					AddParameter(cmd, "UserFullName", Sanitizer.GetSafeHtmlFragment(value.UserFullName));
					AddParameter(cmd, "ReferenceKeyValue", Sanitizer.GetSafeHtmlFragment(value.ReferenceKeyValue));
					AddParameter(cmd, "ReferenceKeyName", Sanitizer.GetSafeHtmlFragment(value.ReferenceKeyName));
					AddParameter(cmd, "TransactionTypeName", Sanitizer.GetSafeHtmlFragment(value.TransactionTypeName));
					AddParameter(cmd, "Comment", Sanitizer.GetSafeHtmlFragment(value.Comment));
				if (value._IsSetModifiedDate)
				{
					AddParameter(cmd, "ModifiedDate", value.IsModifiedDateNull ? DBNull.Value : (object)value.ModifiedDate);
				}
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(TransactionLogID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			if (rt > 0)
			{
			}
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int transactionLogID)
		{
			string whereSql = "[TransactionLogID]=" + CreateSqlParameterName("TransactionLogID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "TransactionLogID", transactionLogID);
			return 0 < cmd.ExecuteNonQuery();
		}
		public int DeleteByUserID(int userID)
		{
			return DeleteByUserID(userID, false);
		}
		public int DeleteByUserID(int userID, bool userIDNull)
		{
			return CreateDeleteByUserIDCommand(userID, userIDNull).ExecuteNonQuery();
		}
		protected virtual IDbCommand CreateDeleteByUserIDCommand(int userID, bool userIDNull)
		{
			string whereSql = "";
			if (userIDNull)
				whereSql += "[UserID] IS NULL";
			else
				whereSql += "[UserID]=" + CreateSqlParameterName("UserID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if (!userIDNull)
				AddParameter(cmd, "UserID", userID);
			return cmd;
		}
		protected SystemTransactionLogRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected SystemTransactionLogRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected SystemTransactionLogRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int transactionLogIDColumnIndex = reader.GetOrdinal("TransactionLogID");
			int userIDColumnIndex = reader.GetOrdinal("UserID");
			int userFullNameColumnIndex = reader.GetOrdinal("UserFullName");
			int referenceKeyValueColumnIndex = reader.GetOrdinal("ReferenceKeyValue");
			int referenceKeyNameColumnIndex = reader.GetOrdinal("ReferenceKeyName");
			int transactiontypeNameColumnIndex = reader.GetOrdinal("TransactionTypeName");
			int commentColumnIndex = reader.GetOrdinal("Comment");
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
					SystemTransactionLogRow record = new SystemTransactionLogRow();
					recordList.Add(record);
					record.TransactionLogID =  Convert.ToInt32(reader.GetValue(transactionLogIDColumnIndex));
					if (!reader.IsDBNull(userIDColumnIndex)) record.UserID =  Convert.ToInt32(reader.GetValue(userIDColumnIndex));

					if (!reader.IsDBNull(userFullNameColumnIndex)) record.UserFullName =  Convert.ToString(reader.GetValue(userFullNameColumnIndex));

					if (!reader.IsDBNull(referenceKeyValueColumnIndex)) record.ReferenceKeyValue =  Convert.ToString(reader.GetValue(referenceKeyValueColumnIndex));

					if (!reader.IsDBNull(referenceKeyNameColumnIndex)) record.ReferenceKeyName =  Convert.ToString(reader.GetValue(referenceKeyNameColumnIndex));

					if (!reader.IsDBNull(transactiontypeNameColumnIndex)) record.TransactionTypeName =  Convert.ToString(reader.GetValue(transactiontypeNameColumnIndex));

					if (!reader.IsDBNull(commentColumnIndex)) record.Comment =  Convert.ToString(reader.GetValue(commentColumnIndex));

					if (!reader.IsDBNull(modifiedDateColumnIndex)) record.ModifiedDate =  Convert.ToDateTime(reader.GetValue(modifiedDateColumnIndex));

					record.MapRecord = true;
					if (countRecordRow > 1) 
					{
						record.Many = true;
					}
					else
					{
						record.Many = false;
					}
					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (SystemTransactionLogRow[])(recordList.ToArray(typeof(SystemTransactionLogRow)));
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
				case "TransactionLogID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "UserID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "UserFullName":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
					break;
				case "ReferenceKeyValue":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "ReferenceKeyName":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "TransactionTypeName":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "Comment":
					parameter = AddParameter(cmd, paramName, DbType.String, value);
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
				throw new FaultException("Zero ProcessID");
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

