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
	public partial class UserLoginHistoryCollection_Base : MarshalByRefObject
	{
		public const string LogIDColumnName = "LogID";
		public const string UserIDColumnName = "UserID";
		public const string IPColumnName = "IP";
		public const string DeviceTypeColumnName = "DeviceType";
		public const string LoginDateColumnName = "LoginDate";
		private int _processID;
		public SqlCommand cmd = null;
		public UserLoginHistoryCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual UserLoginHistoryRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}
		public virtual UserLoginHistoryPaging GetPagingRelyOnLogIDdesc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			UserLoginHistoryPaging userLoginHistoryPaging = new UserLoginHistoryPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(LogID) as TotalRow from [dbo].[UserLoginHistory]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			userLoginHistoryPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			userLoginHistoryPaging.totalPage = (int)Math.Ceiling((double) userLoginHistoryPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnLogID(whereSql, "LogID Desc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			userLoginHistoryPaging.userLoginHistoryRow = MapRecords(command);
			return userLoginHistoryPaging;
		}
		public virtual UserLoginHistoryPaging GetPagingRelyOnLogIDasc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			UserLoginHistoryPaging userLoginHistoryPaging = new UserLoginHistoryPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(LogID) as TotalRow from [dbo].[UserLoginHistory]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			userLoginHistoryPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			userLoginHistoryPaging.totalPage = (int)Math.Ceiling((double)userLoginHistoryPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnLogID(whereSql, "LogID asc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			userLoginHistoryPaging.userLoginHistoryRow = MapRecords(command);
			return userLoginHistoryPaging;
		}
		public virtual UserLoginHistoryRow[] GetPagingRelyOnLogIDdescNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minLogID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And LogID < " + minLogID.ToString();
			}
			else
			{
				whereSql = "LogID < " + minLogID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnLogID(whereSql, "LogID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual UserLoginHistoryRow[] GetPagingRelyOnLogIDascNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minLogID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And LogID > " + minLogID.ToString();
			}
			else
			{
				whereSql = "LogID > " + minLogID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnLogID(whereSql, "LogID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual UserLoginHistoryRow[] GetPagingRelyOnLogIDascPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxLogID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And LogID < " + maxLogID.ToString();
			}
			else
			{
				whereSql = "LogID < " + maxLogID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnLogID(whereSql, "LogID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual UserLoginHistoryRow[] GetPagingRelyOnLogIDdescPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxLogID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And LogID > " + maxLogID.ToString();
			}
			else
			{
				whereSql = "LogID > " + maxLogID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnLogID(whereSql, "LogID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual UserLoginHistoryRow[] GetPagingRelyOnLogIDdescByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber ,string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "LogID Desc";
			}
			else
			{
				orderByColumn = orderByColumn + " Desc";
			}
			UserLoginHistoryRow[] userLoginHistoryRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnLogID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				userLoginHistoryRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnLogIDdescByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				userLoginHistoryRow = MapRecords(command);
			}
			return userLoginHistoryRow;
		}
		public virtual UserLoginHistoryRow[] GetPagingRelyOnLogIDascByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber, string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "LogID Asc";
			}
			else
			{
				orderByColumn = orderByColumn + " Asc";
			}
			UserLoginHistoryRow[] userLoginHistoryRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnLogID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				userLoginHistoryRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnLogIDascByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				userLoginHistoryRow = MapRecords(command);
			}
			return userLoginHistoryRow;
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
			"[LogID],"+
			"[UserID],"+
			"[IP],"+
			"[DeviceType],"+
			"[LoginDate]"+
			" FROM [dbo].[UserLoginHistory]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnLogID(string whereSql, string orderBySql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[UserLoginHistory]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnLogIDdescByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "LogID Desc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[UserLoginHistory] where LogID < (select min(minLogID) from(select top " + (rowPerPage * pageNumber).ToString() + " LogID as minLogID from [dbo].[UserLoginHistory]" + subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[UserLoginHistory]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnLogIDascByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "LogID Asc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[UserLoginHistory] where LogID > (select max(maxLogID) from(select top " + (rowPerPage * pageNumber).ToString() + " LogID as maxLogID from [dbo].[UserLoginHistory]" +  subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[UserLoginHistory]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[UserLoginHistory]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "UserLoginHistory"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("LogID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("UserID",Type.GetType("System.Int32"));
			dataColumn = dataTable.Columns.Add("IP",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("DeviceType",Type.GetType("System.String"));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("LoginDate",Type.GetType("System.DateTime"));
			return dataTable;
		}
		public virtual UserLoginHistoryRow[] GetByUserID(int userID)
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
		public UserLoginHistoryRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual UserLoginHistoryRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="UserLoginHistoryRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="UserLoginHistoryRow"/> objects.</returns>
		public virtual UserLoginHistoryRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[UserLoginHistory]", top);
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
		public UserLoginHistoryRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			UserLoginHistoryRow[] rows = null;
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
		public DataTable GetUserLoginHistoryPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "LogID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "LogID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(LogID) AS TotalRow FROM [dbo].[UserLoginHistory] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,LogID,UserID,IP,DeviceType,LoginDate," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT [UserLoginHistory].*, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[UserLoginHistory] " + whereSql +
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
		public UserLoginHistoryItemsPaging GetUserLoginHistoryPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "LogID")
		{
		UserLoginHistoryItemsPaging obj = new UserLoginHistoryItemsPaging();
		DataTable dt = GetUserLoginHistoryPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		UserLoginHistoryItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new UserLoginHistoryItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.LogID = Convert.ToInt32(dt.Rows[i]["LogID"]);
			if (dt.Rows[i]["UserID"] != DBNull.Value)
			record.UserID = Convert.ToInt32(dt.Rows[i]["UserID"]);
			record.IP = dt.Rows[i]["IP"].ToString();
			record.DeviceType = dt.Rows[i]["DeviceType"].ToString();
			if (dt.Rows[i]["LoginDate"] != DBNull.Value)
			record.LoginDate = Convert.ToDateTime(dt.Rows[i]["LoginDate"]);
			recordList.Add(record);
		}
		obj.userLoginHistoryItems = (UserLoginHistoryItems[])(recordList.ToArray(typeof(UserLoginHistoryItems)));
		return obj;
		}
		public UserLoginHistoryRow GetByPrimaryKey(int logID)
		{
			string whereSql = "[LogID]=" + CreateSqlParameterName("LogID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "LogID", logID);
			UserLoginHistoryRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public int Insert(UserLoginHistoryRow value)		{
			string sqlStr = "INSERT INTO [dbo].[UserLoginHistory] (" +
			"[UserID], " + 
			"[IP], " + 
			"[DeviceType], " + 
			"[LoginDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("UserID") + ", " +
			CreateSqlParameterName("IP") + ", " +
			CreateSqlParameterName("DeviceType") + ", " +
			CreateSqlParameterName("LoginDate") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "UserID", value.IsUserIDNull ? DBNull.Value : (object)value.UserID);
			AddParameter(cmd, "IP", value.IP);
			AddParameter(cmd, "DeviceType", value.DeviceType);
			AddParameter(cmd, "LoginDate", value.IsLoginDateNull ? DBNull.Value : (object)value.LoginDate);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public int InsertOnlyPlainText(UserLoginHistoryRow value)		{
			string sqlStr = "INSERT INTO [dbo].[UserLoginHistory] (" +
			"[UserID], " + 
			"[IP], " + 
			"[DeviceType], " + 
			"[LoginDate]			" + 
			") VALUES (" +
			CreateSqlParameterName("UserID") + ", " +
			CreateSqlParameterName("IP") + ", " +
			CreateSqlParameterName("DeviceType") + ", " +
			CreateSqlParameterName("LoginDate") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "UserID", value.IsUserIDNull ? DBNull.Value : (object)value.UserID);
			AddParameter(cmd, "IP", Sanitizer.GetSafeHtmlFragment(value.IP));
			AddParameter(cmd, "DeviceType", Sanitizer.GetSafeHtmlFragment(value.DeviceType));
			AddParameter(cmd, "LoginDate", value.IsLoginDateNull ? DBNull.Value : (object)value.LoginDate);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public bool Update(UserLoginHistoryRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetLogID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetUserID)
				{
					strUpdate += "[UserID]=" + CreateSqlParameterName("UserID") + ",";
				}
				if (value._IsSetIP)
				{
					strUpdate += "[IP]=" + CreateSqlParameterName("IP") + ",";
				}
				if (value._IsSetDeviceType)
				{
					strUpdate += "[DeviceType]=" + CreateSqlParameterName("DeviceType") + ",";
				}
				if (value._IsSetLoginDate)
				{
					strUpdate += "[LoginDate]=" + CreateSqlParameterName("LoginDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[UserLoginHistory] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[LogID]=" + CreateSqlParameterName("LogID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "LogID", value.LogID);
					AddParameter(cmd, "UserID", value.IsUserIDNull ? DBNull.Value : (object)value.UserID);
					AddParameter(cmd, "IP", value.IP);
					AddParameter(cmd, "DeviceType", value.DeviceType);
					AddParameter(cmd, "LoginDate", value.IsLoginDateNull ? DBNull.Value : (object)value.LoginDate);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(LogID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(UserLoginHistoryRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetLogID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetUserID)
				{
					strUpdate += "[UserID]=" + CreateSqlParameterName("UserID") + ",";
				}
				if (value._IsSetIP)
				{
					strUpdate += "[IP]=" + CreateSqlParameterName("IP") + ",";
				}
				if (value._IsSetDeviceType)
				{
					strUpdate += "[DeviceType]=" + CreateSqlParameterName("DeviceType") + ",";
				}
				if (value._IsSetLoginDate)
				{
					strUpdate += "[LoginDate]=" + CreateSqlParameterName("LoginDate") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[UserLoginHistory] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[LogID]=" + CreateSqlParameterName("LogID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "LogID", value.LogID);
					AddParameter(cmd, "UserID", value.IsUserIDNull ? DBNull.Value : (object)value.UserID);
					AddParameter(cmd, "IP", Sanitizer.GetSafeHtmlFragment(value.IP));
					AddParameter(cmd, "DeviceType", Sanitizer.GetSafeHtmlFragment(value.DeviceType));
					AddParameter(cmd, "LoginDate", value.IsLoginDateNull ? DBNull.Value : (object)value.LoginDate);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(LogID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int logID)
		{
			string whereSql = "[LogID]=" + CreateSqlParameterName("LogID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "LogID", logID);
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
		protected UserLoginHistoryRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected UserLoginHistoryRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected UserLoginHistoryRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int logIDColumnIndex = reader.GetOrdinal("LogID");
			int userIDColumnIndex = reader.GetOrdinal("UserID");
			int iPColumnIndex = reader.GetOrdinal("IP");
			int deviceTypeColumnIndex = reader.GetOrdinal("DeviceType");
			int loginDateColumnIndex = reader.GetOrdinal("LoginDate");
			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			int countRecordRow = 0;
			while (reader.Read())
			{
				countRecordRow++;
				ri++;
				if (ri > 0 && ri <= length)
				{
					UserLoginHistoryRow record = new UserLoginHistoryRow();
					recordList.Add(record);
					record.LogID =  Convert.ToInt32(reader.GetValue(logIDColumnIndex));
					if (!reader.IsDBNull(userIDColumnIndex)) record.UserID =  Convert.ToInt32(reader.GetValue(userIDColumnIndex));

					if (!reader.IsDBNull(iPColumnIndex)) record.IP =  Convert.ToString(reader.GetValue(iPColumnIndex));

					if (!reader.IsDBNull(deviceTypeColumnIndex)) record.DeviceType =  Convert.ToString(reader.GetValue(deviceTypeColumnIndex));

					if (!reader.IsDBNull(loginDateColumnIndex)) record.LoginDate =  Convert.ToDateTime(reader.GetValue(loginDateColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (UserLoginHistoryRow[])(recordList.ToArray(typeof(UserLoginHistoryRow)));
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
				case "LogID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "UserID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "IP":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "DeviceType":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "LoginDate":
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

