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
	public partial class UserRenewTicketCollection_Base : MarshalByRefObject
	{
		public const string TicketIDColumnName = "TicketID";
		public const string IssueByColumnName = "IssueBy";
		public const string IssueDateColumnName = "IssueDate";
		public const string TokenColumnName = "Token";
		public const string ExpireDateColumnName = "ExpireDate";
		public const string UserIDColumnName = "UserID";
		public const string EmailColumnName = "Email";
		public const string RenewTypeColumnName = "RenewType";
		private int _processID;
		public SqlCommand cmd = null;
		public UserRenewTicketCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual UserRenewTicketRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}
		public virtual UserRenewTicketPaging GetPagingRelyOnTicketIDdesc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			UserRenewTicketPaging userRenewTicketPaging = new UserRenewTicketPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(TicketID) as TotalRow from [dbo].[UserRenewTicket]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			userRenewTicketPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			userRenewTicketPaging.totalPage = (int)Math.Ceiling((double) userRenewTicketPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnTicketID(whereSql, "TicketID Desc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			userRenewTicketPaging.userRenewTicketRow = MapRecords(command);
			return userRenewTicketPaging;
		}
		public virtual UserRenewTicketPaging GetPagingRelyOnTicketIDasc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			UserRenewTicketPaging userRenewTicketPaging = new UserRenewTicketPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(TicketID) as TotalRow from [dbo].[UserRenewTicket]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			userRenewTicketPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			userRenewTicketPaging.totalPage = (int)Math.Ceiling((double)userRenewTicketPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnTicketID(whereSql, "TicketID asc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			userRenewTicketPaging.userRenewTicketRow = MapRecords(command);
			return userRenewTicketPaging;
		}
		public virtual UserRenewTicketRow[] GetPagingRelyOnTicketIDdescNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minTicketID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And TicketID < " + minTicketID.ToString();
			}
			else
			{
				whereSql = "TicketID < " + minTicketID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnTicketID(whereSql, "TicketID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual UserRenewTicketRow[] GetPagingRelyOnTicketIDascNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minTicketID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And TicketID > " + minTicketID.ToString();
			}
			else
			{
				whereSql = "TicketID > " + minTicketID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnTicketID(whereSql, "TicketID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual UserRenewTicketRow[] GetPagingRelyOnTicketIDascPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxTicketID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And TicketID < " + maxTicketID.ToString();
			}
			else
			{
				whereSql = "TicketID < " + maxTicketID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnTicketID(whereSql, "TicketID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual UserRenewTicketRow[] GetPagingRelyOnTicketIDdescPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxTicketID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And TicketID > " + maxTicketID.ToString();
			}
			else
			{
				whereSql = "TicketID > " + maxTicketID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnTicketID(whereSql, "TicketID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual UserRenewTicketRow[] GetPagingRelyOnTicketIDdescByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber ,string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "TicketID Desc";
			}
			else
			{
				orderByColumn = orderByColumn + " Desc";
			}
			UserRenewTicketRow[] userRenewTicketRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnTicketID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				userRenewTicketRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnTicketIDdescByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				userRenewTicketRow = MapRecords(command);
			}
			return userRenewTicketRow;
		}
		public virtual UserRenewTicketRow[] GetPagingRelyOnTicketIDascByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber, string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "TicketID Asc";
			}
			else
			{
				orderByColumn = orderByColumn + " Asc";
			}
			UserRenewTicketRow[] userRenewTicketRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnTicketID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				userRenewTicketRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnTicketIDascByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				userRenewTicketRow = MapRecords(command);
			}
			return userRenewTicketRow;
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
			"[TicketID],"+
			"[IssueBy],"+
			"[IssueDate],"+
			"[Token],"+
			"[ExpireDate],"+
			"[UserID],"+
			"[Email],"+
			"[RenewType]"+
			" FROM [dbo].[UserRenewTicket]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnTicketID(string whereSql, string orderBySql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[UserRenewTicket]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnTicketIDdescByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "TicketID Desc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[UserRenewTicket] where TicketID < (select min(minTicketID) from(select top " + (rowPerPage * pageNumber).ToString() + " TicketID as minTicketID from [dbo].[UserRenewTicket]" + subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[UserRenewTicket]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnTicketIDascByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "TicketID Asc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[UserRenewTicket] where TicketID > (select max(maxTicketID) from(select top " + (rowPerPage * pageNumber).ToString() + " TicketID as maxTicketID from [dbo].[UserRenewTicket]" +  subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[UserRenewTicket]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[UserRenewTicket]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "UserRenewTicket"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("TicketID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("IssueBy",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("IssueDate",Type.GetType("System.DateTime"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("Token",Type.GetType("System.String"));
			dataColumn.MaxLength = 2147483647;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ExpireDate",Type.GetType("System.DateTime"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("UserID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("Email",Type.GetType("System.String"));
			dataColumn.MaxLength = 100;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("RenewType",Type.GetType("System.String"));
			dataColumn.MaxLength = 20;
			dataColumn.AllowDBNull = false;
			return dataTable;
		}
		public UserRenewTicketRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual UserRenewTicketRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="UserRenewTicketRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="UserRenewTicketRow"/> objects.</returns>
		public virtual UserRenewTicketRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[UserRenewTicket]", top);
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
		public UserRenewTicketRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			UserRenewTicketRow[] rows = null;
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
		public DataTable GetUserRenewTicketPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "TicketID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "TicketID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(TicketID) AS TotalRow FROM [dbo].[UserRenewTicket] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,TicketID,IssueBy,IssueDate,Token,ExpireDate,UserID,Email,RenewType," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT [UserRenewTicket].*, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[UserRenewTicket] " + whereSql +
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
		public UserRenewTicketItemsPaging GetUserRenewTicketPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "TicketID")
		{
		UserRenewTicketItemsPaging obj = new UserRenewTicketItemsPaging();
		DataTable dt = GetUserRenewTicketPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		UserRenewTicketItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new UserRenewTicketItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.TicketID = Convert.ToInt32(dt.Rows[i]["TicketID"]);
			record.IssueBy = Convert.ToInt32(dt.Rows[i]["IssueBy"]);
			record.IssueDate = Convert.ToDateTime(dt.Rows[i]["IssueDate"]);
			record.Token = dt.Rows[i]["Token"].ToString();
			record.ExpireDate = Convert.ToDateTime(dt.Rows[i]["ExpireDate"]);
			record.UserID = Convert.ToInt32(dt.Rows[i]["UserID"]);
			record.Email = dt.Rows[i]["Email"].ToString();
			record.RenewType = dt.Rows[i]["RenewType"].ToString();
			recordList.Add(record);
		}
		obj.userRenewTicketItems = (UserRenewTicketItems[])(recordList.ToArray(typeof(UserRenewTicketItems)));
		return obj;
		}
		public UserRenewTicketRow GetByPrimaryKey(int ticketID)
		{
			string whereSql = "[TicketID]=" + CreateSqlParameterName("TicketID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "TicketID", ticketID);
			UserRenewTicketRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public int Insert(UserRenewTicketRow value)		{
			string sqlStr = "INSERT INTO [dbo].[UserRenewTicket] (" +
			"[IssueBy], " + 
			"[IssueDate], " + 
			"[Token], " + 
			"[ExpireDate], " + 
			"[UserID], " + 
			"[Email], " + 
			"[RenewType]			" + 
			") VALUES (" +
			CreateSqlParameterName("IssueBy") + ", " +
			CreateSqlParameterName("IssueDate") + ", " +
			CreateSqlParameterName("Token") + ", " +
			CreateSqlParameterName("ExpireDate") + ", " +
			CreateSqlParameterName("UserID") + ", " +
			CreateSqlParameterName("Email") + ", " +
			CreateSqlParameterName("RenewType") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "IssueBy", value.IssueBy);
			AddParameter(cmd, "IssueDate", value.IsIssueDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.IssueDate);
			AddParameter(cmd, "Token",value.Token);
			AddParameter(cmd, "ExpireDate", value.IsExpireDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.ExpireDate);
			AddParameter(cmd, "UserID", value.UserID);
			AddParameter(cmd, "Email",value.Email);
			AddParameter(cmd, "RenewType",value.RenewType);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public int InsertOnlyPlainText(UserRenewTicketRow value)		{
			string sqlStr = "INSERT INTO [dbo].[UserRenewTicket] (" +
			"[IssueBy], " + 
			"[IssueDate], " + 
			"[Token], " + 
			"[ExpireDate], " + 
			"[UserID], " + 
			"[Email], " + 
			"[RenewType]			" + 
			") VALUES (" +
			CreateSqlParameterName("IssueBy") + ", " +
			CreateSqlParameterName("IssueDate") + ", " +
			CreateSqlParameterName("Token") + ", " +
			CreateSqlParameterName("ExpireDate") + ", " +
			CreateSqlParameterName("UserID") + ", " +
			CreateSqlParameterName("Email") + ", " +
			CreateSqlParameterName("RenewType") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "IssueBy", value.IssueBy);
			AddParameter(cmd, "IssueDate", value.IsIssueDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.IssueDate);
			AddParameter(cmd, "Token", Sanitizer.GetSafeHtmlFragment(value.Token));
			AddParameter(cmd, "ExpireDate", value.IsExpireDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.ExpireDate);
			AddParameter(cmd, "UserID", value.UserID);
			AddParameter(cmd, "Email", Sanitizer.GetSafeHtmlFragment(value.Email));
			AddParameter(cmd, "RenewType", Sanitizer.GetSafeHtmlFragment(value.RenewType));
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public bool Update(UserRenewTicketRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetTicketID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetIssueBy)
				{
					strUpdate += "[IssueBy]=" + CreateSqlParameterName("IssueBy") + ",";
				}
				if (value._IsSetIssueDate)
				{
					strUpdate += "[IssueDate]=" + CreateSqlParameterName("IssueDate") + ",";
				}
				if (value._IsSetToken)
				{
					strUpdate += "[Token]=" + CreateSqlParameterName("Token") + ",";
				}
				if (value._IsSetExpireDate)
				{
					strUpdate += "[ExpireDate]=" + CreateSqlParameterName("ExpireDate") + ",";
				}
				if (value._IsSetUserID)
				{
					strUpdate += "[UserID]=" + CreateSqlParameterName("UserID") + ",";
				}
				if (value._IsSetEmail)
				{
					strUpdate += "[Email]=" + CreateSqlParameterName("Email") + ",";
				}
				if (value._IsSetRenewType)
				{
					strUpdate += "[RenewType]=" + CreateSqlParameterName("RenewType") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[UserRenewTicket] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[TicketID]=" + CreateSqlParameterName("TicketID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "TicketID", value.TicketID);
					AddParameter(cmd, "IssueBy", value.IssueBy);
					AddParameter(cmd, "IssueDate", value.IsIssueDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.IssueDate);
					AddParameter(cmd, "Token",value.Token);
					AddParameter(cmd, "ExpireDate", value.IsExpireDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.ExpireDate);
					AddParameter(cmd, "UserID", value.UserID);
					AddParameter(cmd, "Email",value.Email);
					AddParameter(cmd, "RenewType",value.RenewType);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(TicketID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(UserRenewTicketRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetTicketID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetIssueBy)
				{
					strUpdate += "[IssueBy]=" + CreateSqlParameterName("IssueBy") + ",";
				}
				if (value._IsSetIssueDate)
				{
					strUpdate += "[IssueDate]=" + CreateSqlParameterName("IssueDate") + ",";
				}
				if (value._IsSetToken)
				{
					strUpdate += "[Token]=" + CreateSqlParameterName("Token") + ",";
				}
				if (value._IsSetExpireDate)
				{
					strUpdate += "[ExpireDate]=" + CreateSqlParameterName("ExpireDate") + ",";
				}
				if (value._IsSetUserID)
				{
					strUpdate += "[UserID]=" + CreateSqlParameterName("UserID") + ",";
				}
				if (value._IsSetEmail)
				{
					strUpdate += "[Email]=" + CreateSqlParameterName("Email") + ",";
				}
				if (value._IsSetRenewType)
				{
					strUpdate += "[RenewType]=" + CreateSqlParameterName("RenewType") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[UserRenewTicket] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[TicketID]=" + CreateSqlParameterName("TicketID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "TicketID", value.TicketID);
					AddParameter(cmd, "IssueBy", value.IssueBy);
					AddParameter(cmd, "IssueDate", value.IsIssueDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.IssueDate);
					AddParameter(cmd, "Token", Sanitizer.GetSafeHtmlFragment(value.Token));
					AddParameter(cmd, "ExpireDate", value.IsExpireDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.ExpireDate);
					AddParameter(cmd, "UserID", value.UserID);
					AddParameter(cmd, "Email", Sanitizer.GetSafeHtmlFragment(value.Email));
					AddParameter(cmd, "RenewType", Sanitizer.GetSafeHtmlFragment(value.RenewType));
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(TicketID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int ticketID)
		{
			string whereSql = "[TicketID]=" + CreateSqlParameterName("TicketID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "TicketID", ticketID);
			return 0 < cmd.ExecuteNonQuery();
		}
		protected UserRenewTicketRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected UserRenewTicketRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected UserRenewTicketRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int ticketIDColumnIndex = reader.GetOrdinal("TicketID");
			int issueByColumnIndex = reader.GetOrdinal("IssueBy");
			int issueDateColumnIndex = reader.GetOrdinal("IssueDate");
			int tokenColumnIndex = reader.GetOrdinal("Token");
			int expireDateColumnIndex = reader.GetOrdinal("ExpireDate");
			int userIDColumnIndex = reader.GetOrdinal("UserID");
			int emailColumnIndex = reader.GetOrdinal("Email");
			int renewTypeColumnIndex = reader.GetOrdinal("RenewType");
			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			int countRecordRow = 0;
			while (reader.Read())
			{
				countRecordRow++;
				ri++;
				if (ri > 0 && ri <= length)
				{
					UserRenewTicketRow record = new UserRenewTicketRow();
					recordList.Add(record);
					record.TicketID =  Convert.ToInt32(reader.GetValue(ticketIDColumnIndex));
					record.IssueBy =  Convert.ToInt32(reader.GetValue(issueByColumnIndex));
					record.IssueDate =  Convert.ToDateTime(reader.GetValue(issueDateColumnIndex));
					record.Token =  Convert.ToString(reader.GetValue(tokenColumnIndex));
					record.ExpireDate =  Convert.ToDateTime(reader.GetValue(expireDateColumnIndex));
					record.UserID =  Convert.ToInt32(reader.GetValue(userIDColumnIndex));
					record.Email =  Convert.ToString(reader.GetValue(emailColumnIndex));
					record.RenewType =  Convert.ToString(reader.GetValue(renewTypeColumnIndex));
					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (UserRenewTicketRow[])(recordList.ToArray(typeof(UserRenewTicketRow)));
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
				case "TicketID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "IssueBy":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "IssueDate":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "Token":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "ExpireDate":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "UserID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "Email":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "RenewType":
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

