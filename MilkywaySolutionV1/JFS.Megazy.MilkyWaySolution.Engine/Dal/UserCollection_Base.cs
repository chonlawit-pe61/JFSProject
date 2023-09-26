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
	public partial class UserCollection_Base : MarshalByRefObject
	{
		public const string UserIDColumnName = "UserID";
		public const string UserNameColumnName = "UserName";
		public const string AliasNameColumnName = "AliasName";
		public const string PasswordColumnName = "Password";
		public const string TitleColumnName = "Title";
		public const string FirstNameColumnName = "FirstName";
		public const string LastNameColumnName = "LastName";
		public const string CardIDColumnName = "CardID";
		public const string GenderColumnName = "Gender";
		public const string PhoneNumberColumnName = "PhoneNumber";
		public const string EmailColumnName = "Email";
		public const string DateOfBirthColumnName = "DateOfBirth";
		public const string RegistDateColumnName = "RegistDate";
		public const string UpdateDateColumnName = "UpdateDate";
		public const string IsVerifyByEmailColumnName = "IsVerifyByEmail";
		public const string IsRenewAccountColumnName = "IsRenewAccount";
		public const string UserStatusIDColumnName = "UserStatusID";
		public const string LastLoginDateColumnName = "LastLoginDate";
		public const string UserTypeIDColumnName = "UserTypeID";
		public const string UpdateByColumnName = "UpdateBy";
		public const string RenewTicketIDColumnName = "RenewTicketID";
		public const string DeleteFlagColumnName = "DeleteFlag";
		private int _processID;
		public SqlCommand cmd = null;
		public UserCollection_Base(int intProcessID)
		{
			_processID = intProcessID;
		}
		public void Dispose()
		{
			Close();
		}
		public virtual UserRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}
		public virtual UserPaging GetPagingRelyOnUserIDdesc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			UserPaging userPaging = new UserPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(UserID) as TotalRow from [dbo].[User]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			userPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			userPaging.totalPage = (int)Math.Ceiling((double) userPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnUserID(whereSql, "UserID Desc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			userPaging.userRow = MapRecords(command);
			return userPaging;
		}
		public virtual UserPaging GetPagingRelyOnUserIDasc(List<SqlParameter> sqlParameter, string whereSql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			UserPaging userPaging = new UserPaging();
			string whereCount = string.Empty;
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereCount = " WHERE " + whereSql;
			}
			string sql = "select count(UserID) as TotalRow from [dbo].[User]" + whereCount;
			SqlCommand command = CreateCommand(sql);
			command.Parameters.AddRange(sqlParameter.ToArray());
			DataTable dt = CreateDataTable(command);
			command.Parameters.Clear();
			userPaging.totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
			userPaging.totalPage = (int)Math.Ceiling((double)userPaging.totalRow / rowPerPage);
			command = CreateGetPagingRelyOnUserID(whereSql, "UserID asc",rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			userPaging.userRow = MapRecords(command);
			return userPaging;
		}
		public virtual UserRow[] GetPagingRelyOnUserIDdescNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minUserID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And UserID < " + minUserID.ToString();
			}
			else
			{
				whereSql = "UserID < " + minUserID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnUserID(whereSql, "UserID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual UserRow[] GetPagingRelyOnUserIDascNextPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage,int minUserID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And UserID > " + minUserID.ToString();
			}
			else
			{
				whereSql = "UserID > " + minUserID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnUserID(whereSql, "UserID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual UserRow[] GetPagingRelyOnUserIDascPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxUserID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And UserID < " + maxUserID.ToString();
			}
			else
			{
				whereSql = "UserID < " + maxUserID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnUserID(whereSql, "UserID Asc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual UserRow[] GetPagingRelyOnUserIDdescPreviousPage(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int maxUserID)
		{
			if (null != whereSql && 0 < whereSql.Length)
			{
				whereSql += " And UserID > " + maxUserID.ToString();
			}
			else
			{
				whereSql = "UserID > " + maxUserID.ToString();
			}
			SqlCommand command = CreateGetPagingRelyOnUserID(whereSql, "UserID Desc", rowPerPage);
			command.Parameters.AddRange(sqlParameter.ToArray());
			return MapRecords(command);
		}
		public virtual UserRow[] GetPagingRelyOnUserIDdescByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber ,string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "UserID Desc";
			}
			else
			{
				orderByColumn = orderByColumn + " Desc";
			}
			UserRow[] userRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnUserID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				userRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnUserIDdescByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				userRow = MapRecords(command);
			}
			return userRow;
		}
		public virtual UserRow[] GetPagingRelyOnUserIDascByPageNo(List<SqlParameter> sqlParameter, string whereSql,int rowPerPage, int pageNumber, string orderByColumn)
		{
			if (orderByColumn.Trim() == string.Empty)
			{
				orderByColumn = "UserID Asc";
			}
			else
			{
				orderByColumn = orderByColumn + " Asc";
			}
			UserRow[] userRow = null;
			int topRow = pageNumber - 1;
			if (topRow == 0)
			{
				SqlCommand command = CreateGetPagingRelyOnUserID(whereSql, orderByColumn, rowPerPage);
				command.Parameters.AddRange(sqlParameter.ToArray());
				userRow = MapRecords(command);
			}
			else
			{
				SqlCommand command = CreateGetPagingRelyOnUserIDascByPageNo(whereSql, orderByColumn, rowPerPage, topRow);
				command.Parameters.AddRange(sqlParameter.ToArray());
				userRow = MapRecords(command);
			}
			return userRow;
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
			"[UserID],"+
			"[UserName],"+
			"[AliasName],"+
			"[Password],"+
			"[Title],"+
			"[FirstName],"+
			"[LastName],"+
			"[CardID],"+
			"[Gender],"+
			"[PhoneNumber],"+
			"[Email],"+
			"[DateOfBirth],"+
			"[RegistDate],"+
			"[UpdateDate],"+
			"[IsVerifyByEmail],"+
			"[IsRenewAccount],"+
			"[UserStatusID],"+
			"[LastLoginDate],"+
			"[UserTypeID],"+
			"[UpdateBy],"+
			"[RenewTicketID],"+
			"[DeleteFlag]"+
			" FROM [dbo].[User]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnUserID(string whereSql, string orderBySql, int rowPerPage)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[User]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			if (null != orderBySql && 0 < orderBySql.Length)
			sql += " ORDER BY " + orderBySql;
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnUserIDdescByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "UserID Desc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[User] where UserID < (select min(minUserID) from(select top " + (rowPerPage * pageNumber).ToString() + " UserID as minUserID from [dbo].[User]" + subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[User]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected virtual SqlCommand CreateGetPagingRelyOnUserIDascByPageNo(string whereSql, string orderBySql, int rowPerPage, int pageNumber)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = string.Empty;
			if (orderBySql == "UserID Asc")
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
				sql = "SELECT TOP " + rowPerPage.ToString() + " * FROM [dbo].[User] where UserID > (select max(maxUserID) from(select top " + (rowPerPage * pageNumber).ToString() + " UserID as maxUserID from [dbo].[User]" +  subWhereSql + " order by " + orderBySql + ")T1";
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
				sql = "WITH OrderByRequirement AS (SELECT *, ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowNumber FROM[dbo].[User]) SELECT * FROM OrderByRequirement WHERE RowNumber BETWEEN " + ((pageNumber * rowPerPage) + 1) + " AND " + (rowPerPage * (pageNumber + 1)) + whereSql;
			}
			return CreateCommand(sql);
		}
		protected SqlCommand CreateDeleteCommand(string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			string sql = "DELETE FROM [dbo].[User]";
			if (null != whereSql && 0 < whereSql.Length)
			sql += " WHERE " + whereSql;
			return CreateCommand(sql);
		}
		public  DataTable CreateDataTable()
		{
			DataTable dataTable =  new DataTable
			{
				TableName = "User"
			};
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("UserID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("UserName",Type.GetType("System.String"));
			dataColumn.MaxLength = 100;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("AliasName",Type.GetType("System.String"));
			dataColumn.MaxLength = 100;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("Password",Type.GetType("System.String"));
			dataColumn.MaxLength = 500;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("Title",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("FirstName",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("LastName",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CardID",Type.GetType("System.String"));
			dataColumn.MaxLength = 13;
			dataColumn = dataTable.Columns.Add("Gender",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PhoneNumber",Type.GetType("System.String"));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("Email",Type.GetType("System.String"));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("DateOfBirth",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("RegistDate",Type.GetType("System.DateTime"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("UpdateDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("IsVerifyByEmail",Type.GetType("System.Boolean"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("IsRenewAccount",Type.GetType("System.Boolean"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("UserStatusID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("LastLoginDate",Type.GetType("System.DateTime"));
			dataColumn = dataTable.Columns.Add("UserTypeID",Type.GetType("System.String"));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("UpdateBy",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("RenewTicketID",Type.GetType("System.Int32"));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DeleteFlag",Type.GetType("System.Boolean"));
			return dataTable;
		}
		public UserRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(sqlParameter, whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}
		public virtual UserRow[] GetAsArray(List<SqlParameter> sqlParameter, string whereSql, string orderBySql, int startIndex, int length, ref int totalRecordCount)
		{
		SqlCommand command = CreateGetCommand(whereSql, orderBySql);
		command.Parameters.AddRange(sqlParameter.ToArray());
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}
		/// <summary>
		/// Gets an array of <see cref="UserRow"/> objects that
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="top">The Number of select top condition. For example: 
		/// <c>"10"</c>.</param>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName ='Sakon' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="UserRow"/> objects.</returns>
		public virtual UserRow[] GetTopAsArray(int top,List<SqlParameter> sqlParameter,string whereSql, string orderBySql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			if (top <= 0)
				top = 1;
			string sql = string.Format("SELECT TOP ({0}) * FROM [dbo].[User]", top);
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
		public UserRow GetRow(List<SqlParameter> sqlParameter,string whereSql)
		{
			AntiSqlInjection.CheckInput(whereSql);
			int totalRecordCount = -1;
			UserRow[] rows = null;
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
		public DataTable GetUserPagingAsDataTable(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "UserID")
		{
			AntiSqlInjection.CheckInput(whereSql);
		if (startRowIndex < 0)
			startRowIndex = 0;
		if (rowPerPage < 0)
			rowPerPage = 1;
		if (string.IsNullOrWhiteSpace(orderBySql))
			orderBySql = "UserID";
		string whereCount = string.Empty;
		string wherePaging = string.Empty;
		if (null != whereSql && 0 < whereSql.Length)
		{
			whereCount = " WHERE " + whereSql;
			wherePaging = " AND " + whereSql;
			whereSql = " WHERE   " + whereSql;
		}
		string sql = "SELECT COUNT(UserID) AS TotalRow FROM [dbo].[User] " + whereCount;
		SqlCommand command = CreateCommand(sql);
		command.Parameters.AddRange(sqlParameter.ToArray());
		DataTable dt = CreateDataTable(command);
		command.Parameters.Clear();
		var totalRow = Convert.ToInt32(dt.Rows[0]["TotalRow"]);
		var totalPage = (int)Math.Ceiling((double)totalRow / rowPerPage);
		sql = " SELECT RowRank,UserID,UserName,AliasName,Password,Title,FirstName,LastName,CardID,Gender,PhoneNumber,Email,DateOfBirth,RegistDate,UpdateDate,IsVerifyByEmail,IsRenewAccount,UserStatusID,LastLoginDate,UserTypeID,UpdateBy,RenewTicketID,DeleteFlag," + totalRow + " AS totalRow," + totalPage + " AS totalPage " +
		" FROM (SELECT [User].*, " +
		" ROW_NUMBER() OVER(ORDER BY " + orderBySql + ") AS RowRank " +
		" FROM [dbo].[User] " + whereSql +
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
		public UserItemsPaging GetUserPagingAsArray(List<SqlParameter> sqlParameter,string whereSql, int startRowIndex, int rowPerPage, string orderBySql = "UserID")
		{
		UserItemsPaging obj = new UserItemsPaging();
		DataTable dt = GetUserPagingAsDataTable(sqlParameter,whereSql,startRowIndex,rowPerPage,orderBySql);
		if(dt.Rows.Count !=0){
			obj.totalRow = Convert.ToInt32(dt.Rows[0]["totalRow"]);
			obj.totalPage = Convert.ToInt32(dt.Rows[0]["totalPage"]);
		}
		UserItems record;
		ArrayList recordList = new ArrayList();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			record = new UserItems();
			record.RowRank = Convert.ToInt32(dt.Rows[i]["RowRank"]);
			record.UserID = Convert.ToInt32(dt.Rows[i]["UserID"]);
			record.UserName = dt.Rows[i]["UserName"].ToString();
			record.AliasName = dt.Rows[i]["AliasName"].ToString();
			record.Password = dt.Rows[i]["Password"].ToString();
			record.Title = dt.Rows[i]["Title"].ToString();
			record.FirstName = dt.Rows[i]["FirstName"].ToString();
			record.LastName = dt.Rows[i]["LastName"].ToString();
			record.CardID = dt.Rows[i]["CardID"].ToString();
			record.Gender = Convert.ToInt32(dt.Rows[i]["Gender"]);
			record.PhoneNumber = dt.Rows[i]["PhoneNumber"].ToString();
			record.Email = dt.Rows[i]["Email"].ToString();
			if (dt.Rows[i]["DateOfBirth"] != DBNull.Value)
			record.DateOfBirth = Convert.ToDateTime(dt.Rows[i]["DateOfBirth"]);
			record.RegistDate = Convert.ToDateTime(dt.Rows[i]["RegistDate"]);
			if (dt.Rows[i]["UpdateDate"] != DBNull.Value)
			record.UpdateDate = Convert.ToDateTime(dt.Rows[i]["UpdateDate"]);
			record.IsVerifyByEmail = Convert.ToBoolean(dt.Rows[i]["IsVerifyByEmail"]);
			record.IsRenewAccount = Convert.ToBoolean(dt.Rows[i]["IsRenewAccount"]);
			record.UserStatusID = Convert.ToInt32(dt.Rows[i]["UserStatusID"]);
			if (dt.Rows[i]["LastLoginDate"] != DBNull.Value)
			record.LastLoginDate = Convert.ToDateTime(dt.Rows[i]["LastLoginDate"]);
			record.UserTypeID = dt.Rows[i]["UserTypeID"].ToString();
			record.UpdateBy = Convert.ToInt32(dt.Rows[i]["UpdateBy"]);
			record.RenewTicketID = Convert.ToInt32(dt.Rows[i]["RenewTicketID"]);
			if (dt.Rows[i]["DeleteFlag"] != DBNull.Value)
			record.DeleteFlag = Convert.ToBoolean(dt.Rows[i]["DeleteFlag"]);
			recordList.Add(record);
		}
		obj.userItems = (UserItems[])(recordList.ToArray(typeof(UserItems)));
		return obj;
		}
		public UserRow GetByPrimaryKey(int userID)
		{
			string whereSql = "[UserID]=" + CreateSqlParameterName("UserID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "UserID", userID);
			UserRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}
		public int Insert(UserRow value)		{
			string sqlStr = "INSERT INTO [dbo].[User] (" +
			"[UserName], " + 
			"[AliasName], " + 
			"[Password], " + 
			"[Title], " + 
			"[FirstName], " + 
			"[LastName], " + 
			"[CardID], " + 
			"[Gender], " + 
			"[PhoneNumber], " + 
			"[Email], " + 
			"[DateOfBirth], " + 
			"[RegistDate], " + 
			"[UpdateDate], " + 
			"[IsVerifyByEmail], " + 
			"[IsRenewAccount], " + 
			"[UserStatusID], " + 
			"[LastLoginDate], " + 
			"[UserTypeID], " + 
			"[UpdateBy], " + 
			"[RenewTicketID], " + 
			"[DeleteFlag]			" + 
			") VALUES (" +
			CreateSqlParameterName("UserName") + ", " +
			CreateSqlParameterName("AliasName") + ", " +
			CreateSqlParameterName("Password") + ", " +
			CreateSqlParameterName("Title") + ", " +
			CreateSqlParameterName("FirstName") + ", " +
			CreateSqlParameterName("LastName") + ", " +
			CreateSqlParameterName("CardID") + ", " +
			CreateSqlParameterName("Gender") + ", " +
			CreateSqlParameterName("PhoneNumber") + ", " +
			CreateSqlParameterName("Email") + ", " +
			CreateSqlParameterName("DateOfBirth") + ", " +
			CreateSqlParameterName("RegistDate") + ", " +
			CreateSqlParameterName("UpdateDate") + ", " +
			CreateSqlParameterName("IsVerifyByEmail") + ", " +
			CreateSqlParameterName("IsRenewAccount") + ", " +
			CreateSqlParameterName("UserStatusID") + ", " +
			CreateSqlParameterName("LastLoginDate") + ", " +
			CreateSqlParameterName("UserTypeID") + ", " +
			CreateSqlParameterName("UpdateBy") + ", " +
			CreateSqlParameterName("RenewTicketID") + ", " +
			CreateSqlParameterName("DeleteFlag") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "UserName",value.UserName);
			AddParameter(cmd, "AliasName",value.AliasName);
			AddParameter(cmd, "Password",value.Password);
			AddParameter(cmd, "Title", value.Title);
			AddParameter(cmd, "FirstName",value.FirstName);
			AddParameter(cmd, "LastName",value.LastName);
			AddParameter(cmd, "CardID", value.CardID);
			AddParameter(cmd, "Gender", value.Gender);
			AddParameter(cmd, "PhoneNumber", value.PhoneNumber);
			AddParameter(cmd, "Email", value.Email);
			AddParameter(cmd, "DateOfBirth", value.IsDateOfBirthNull ? DBNull.Value : (object)value.DateOfBirth);
			AddParameter(cmd, "RegistDate", value.IsRegistDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.RegistDate);
			AddParameter(cmd, "UpdateDate", value.IsUpdateDateNull ? DBNull.Value : (object)value.UpdateDate);
			AddParameter(cmd, "IsVerifyByEmail", value.IsVerifyByEmail);
			AddParameter(cmd, "IsRenewAccount", value.IsRenewAccount);
			AddParameter(cmd, "UserStatusID", value.UserStatusID);
			AddParameter(cmd, "LastLoginDate", value.IsLastLoginDateNull ? DBNull.Value : (object)value.LastLoginDate);
			AddParameter(cmd, "UserTypeID",value.UserTypeID);
			AddParameter(cmd, "UpdateBy", value.UpdateBy);
			AddParameter(cmd, "RenewTicketID", value.RenewTicketID);
			AddParameter(cmd, "DeleteFlag", value.IsDeleteFlagNull ? DBNull.Value : (object)value.DeleteFlag);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public int InsertOnlyPlainText(UserRow value)		{
			string sqlStr = "INSERT INTO [dbo].[User] (" +
			"[UserName], " + 
			"[AliasName], " + 
			"[Password], " + 
			"[Title], " + 
			"[FirstName], " + 
			"[LastName], " + 
			"[CardID], " + 
			"[Gender], " + 
			"[PhoneNumber], " + 
			"[Email], " + 
			"[DateOfBirth], " + 
			"[RegistDate], " + 
			"[UpdateDate], " + 
			"[IsVerifyByEmail], " + 
			"[IsRenewAccount], " + 
			"[UserStatusID], " + 
			"[LastLoginDate], " + 
			"[UserTypeID], " + 
			"[UpdateBy], " + 
			"[RenewTicketID], " + 
			"[DeleteFlag]			" + 
			") VALUES (" +
			CreateSqlParameterName("UserName") + ", " +
			CreateSqlParameterName("AliasName") + ", " +
			CreateSqlParameterName("Password") + ", " +
			CreateSqlParameterName("Title") + ", " +
			CreateSqlParameterName("FirstName") + ", " +
			CreateSqlParameterName("LastName") + ", " +
			CreateSqlParameterName("CardID") + ", " +
			CreateSqlParameterName("Gender") + ", " +
			CreateSqlParameterName("PhoneNumber") + ", " +
			CreateSqlParameterName("Email") + ", " +
			CreateSqlParameterName("DateOfBirth") + ", " +
			CreateSqlParameterName("RegistDate") + ", " +
			CreateSqlParameterName("UpdateDate") + ", " +
			CreateSqlParameterName("IsVerifyByEmail") + ", " +
			CreateSqlParameterName("IsRenewAccount") + ", " +
			CreateSqlParameterName("UserStatusID") + ", " +
			CreateSqlParameterName("LastLoginDate") + ", " +
			CreateSqlParameterName("UserTypeID") + ", " +
			CreateSqlParameterName("UpdateBy") + ", " +
			CreateSqlParameterName("RenewTicketID") + ", " +
			CreateSqlParameterName("DeleteFlag") + "); SELECT SCOPE_IDENTITY();";
			IDbCommand cmd = CreateCommand(sqlStr);
			AddParameter(cmd, "UserName", Sanitizer.GetSafeHtmlFragment(value.UserName));
			AddParameter(cmd, "AliasName", Sanitizer.GetSafeHtmlFragment(value.AliasName));
			AddParameter(cmd, "Password", Sanitizer.GetSafeHtmlFragment(value.Password));
			AddParameter(cmd, "Title", Sanitizer.GetSafeHtmlFragment(value.Title));
			AddParameter(cmd, "FirstName", Sanitizer.GetSafeHtmlFragment(value.FirstName));
			AddParameter(cmd, "LastName", Sanitizer.GetSafeHtmlFragment(value.LastName));
			AddParameter(cmd, "CardID", Sanitizer.GetSafeHtmlFragment(value.CardID));
			AddParameter(cmd, "Gender", value.Gender);
			AddParameter(cmd, "PhoneNumber", Sanitizer.GetSafeHtmlFragment(value.PhoneNumber));
			AddParameter(cmd, "Email", Sanitizer.GetSafeHtmlFragment(value.Email));
			AddParameter(cmd, "DateOfBirth", value.IsDateOfBirthNull ? DBNull.Value : (object)value.DateOfBirth);
			AddParameter(cmd, "RegistDate", value.IsRegistDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.RegistDate);
			AddParameter(cmd, "UpdateDate", value.IsUpdateDateNull ? DBNull.Value : (object)value.UpdateDate);
			AddParameter(cmd, "IsVerifyByEmail", value.IsVerifyByEmail);
			AddParameter(cmd, "IsRenewAccount", value.IsRenewAccount);
			AddParameter(cmd, "UserStatusID", value.UserStatusID);
			AddParameter(cmd, "LastLoginDate", value.IsLastLoginDateNull ? DBNull.Value : (object)value.LastLoginDate);
			AddParameter(cmd, "UserTypeID", Sanitizer.GetSafeHtmlFragment(value.UserTypeID));
			AddParameter(cmd, "UpdateBy", value.UpdateBy);
			AddParameter(cmd, "RenewTicketID", value.RenewTicketID);
			AddParameter(cmd, "DeleteFlag", value.IsDeleteFlagNull ? DBNull.Value : (object)value.DeleteFlag);
			return Convert.ToInt32(cmd.ExecuteScalar());
		}
		public bool Update(UserRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetUserID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetUserName)
				{
					strUpdate += "[UserName]=" + CreateSqlParameterName("UserName") + ",";
				}
				if (value._IsSetAliasName)
				{
					strUpdate += "[AliasName]=" + CreateSqlParameterName("AliasName") + ",";
				}
				if (value._IsSetPassword)
				{
					strUpdate += "[Password]=" + CreateSqlParameterName("Password") + ",";
				}
				if (value._IsSetTitle)
				{
					strUpdate += "[Title]=" + CreateSqlParameterName("Title") + ",";
				}
				if (value._IsSetFirstName)
				{
					strUpdate += "[FirstName]=" + CreateSqlParameterName("FirstName") + ",";
				}
				if (value._IsSetLastName)
				{
					strUpdate += "[LastName]=" + CreateSqlParameterName("LastName") + ",";
				}
				if (value._IsSetCardID)
				{
					strUpdate += "[CardID]=" + CreateSqlParameterName("CardID") + ",";
				}
				if (value._IsSetGender)
				{
					strUpdate += "[Gender]=" + CreateSqlParameterName("Gender") + ",";
				}
				if (value._IsSetPhoneNumber)
				{
					strUpdate += "[PhoneNumber]=" + CreateSqlParameterName("PhoneNumber") + ",";
				}
				if (value._IsSetEmail)
				{
					strUpdate += "[Email]=" + CreateSqlParameterName("Email") + ",";
				}
				if (value._IsSetDateOfBirth)
				{
					strUpdate += "[DateOfBirth]=" + CreateSqlParameterName("DateOfBirth") + ",";
				}
				if (value._IsSetRegistDate)
				{
					strUpdate += "[RegistDate]=" + CreateSqlParameterName("RegistDate") + ",";
				}
				if (value._IsSetUpdateDate)
				{
					strUpdate += "[UpdateDate]=" + CreateSqlParameterName("UpdateDate") + ",";
				}
				if (value._IsSetIsVerifyByEmail)
				{
					strUpdate += "[IsVerifyByEmail]=" + CreateSqlParameterName("IsVerifyByEmail") + ",";
				}
				if (value._IsSetIsRenewAccount)
				{
					strUpdate += "[IsRenewAccount]=" + CreateSqlParameterName("IsRenewAccount") + ",";
				}
				if (value._IsSetUserStatusID)
				{
					strUpdate += "[UserStatusID]=" + CreateSqlParameterName("UserStatusID") + ",";
				}
				if (value._IsSetLastLoginDate)
				{
					strUpdate += "[LastLoginDate]=" + CreateSqlParameterName("LastLoginDate") + ",";
				}
				if (value._IsSetUserTypeID)
				{
					strUpdate += "[UserTypeID]=" + CreateSqlParameterName("UserTypeID") + ",";
				}
				if (value._IsSetUpdateBy)
				{
					strUpdate += "[UpdateBy]=" + CreateSqlParameterName("UpdateBy") + ",";
				}
				if (value._IsSetRenewTicketID)
				{
					strUpdate += "[RenewTicketID]=" + CreateSqlParameterName("RenewTicketID") + ",";
				}
				if (value._IsSetDeleteFlag)
				{
					strUpdate += "[DeleteFlag]=" + CreateSqlParameterName("DeleteFlag") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[User] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[UserID]=" + CreateSqlParameterName("UserID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "UserID", value.UserID);
					AddParameter(cmd, "UserName",value.UserName);
					AddParameter(cmd, "AliasName",value.AliasName);
					AddParameter(cmd, "Password",value.Password);
					AddParameter(cmd, "Title", value.Title);
					AddParameter(cmd, "FirstName",value.FirstName);
					AddParameter(cmd, "LastName",value.LastName);
					AddParameter(cmd, "CardID", value.CardID);
					AddParameter(cmd, "Gender", value.Gender);
					AddParameter(cmd, "PhoneNumber", value.PhoneNumber);
					AddParameter(cmd, "Email", value.Email);
					AddParameter(cmd, "DateOfBirth", value.IsDateOfBirthNull ? DBNull.Value : (object)value.DateOfBirth);
					AddParameter(cmd, "RegistDate", value.IsRegistDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.RegistDate);
					AddParameter(cmd, "UpdateDate", value.IsUpdateDateNull ? DBNull.Value : (object)value.UpdateDate);
					AddParameter(cmd, "IsVerifyByEmail", value.IsVerifyByEmail);
					AddParameter(cmd, "IsRenewAccount", value.IsRenewAccount);
					AddParameter(cmd, "UserStatusID", value.UserStatusID);
					AddParameter(cmd, "LastLoginDate", value.IsLastLoginDateNull ? DBNull.Value : (object)value.LastLoginDate);
					AddParameter(cmd, "UserTypeID",value.UserTypeID);
					AddParameter(cmd, "UpdateBy", value.UpdateBy);
					AddParameter(cmd, "RenewTicketID", value.RenewTicketID);
					AddParameter(cmd, "DeleteFlag", value.IsDeleteFlagNull ? DBNull.Value : (object)value.DeleteFlag);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(UserID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool UpdateOnlyPlainText(UserRow value)
		{
			IDbCommand cmd = null;
			if ( value._IsSetUserID == true )
			{
				string strUpdate = string.Empty;
				if (value._IsSetUserName)
				{
					strUpdate += "[UserName]=" + CreateSqlParameterName("UserName") + ",";
				}
				if (value._IsSetAliasName)
				{
					strUpdate += "[AliasName]=" + CreateSqlParameterName("AliasName") + ",";
				}
				if (value._IsSetPassword)
				{
					strUpdate += "[Password]=" + CreateSqlParameterName("Password") + ",";
				}
				if (value._IsSetTitle)
				{
					strUpdate += "[Title]=" + CreateSqlParameterName("Title") + ",";
				}
				if (value._IsSetFirstName)
				{
					strUpdate += "[FirstName]=" + CreateSqlParameterName("FirstName") + ",";
				}
				if (value._IsSetLastName)
				{
					strUpdate += "[LastName]=" + CreateSqlParameterName("LastName") + ",";
				}
				if (value._IsSetCardID)
				{
					strUpdate += "[CardID]=" + CreateSqlParameterName("CardID") + ",";
				}
				if (value._IsSetGender)
				{
					strUpdate += "[Gender]=" + CreateSqlParameterName("Gender") + ",";
				}
				if (value._IsSetPhoneNumber)
				{
					strUpdate += "[PhoneNumber]=" + CreateSqlParameterName("PhoneNumber") + ",";
				}
				if (value._IsSetEmail)
				{
					strUpdate += "[Email]=" + CreateSqlParameterName("Email") + ",";
				}
				if (value._IsSetDateOfBirth)
				{
					strUpdate += "[DateOfBirth]=" + CreateSqlParameterName("DateOfBirth") + ",";
				}
				if (value._IsSetRegistDate)
				{
					strUpdate += "[RegistDate]=" + CreateSqlParameterName("RegistDate") + ",";
				}
				if (value._IsSetUpdateDate)
				{
					strUpdate += "[UpdateDate]=" + CreateSqlParameterName("UpdateDate") + ",";
				}
				if (value._IsSetIsVerifyByEmail)
				{
					strUpdate += "[IsVerifyByEmail]=" + CreateSqlParameterName("IsVerifyByEmail") + ",";
				}
				if (value._IsSetIsRenewAccount)
				{
					strUpdate += "[IsRenewAccount]=" + CreateSqlParameterName("IsRenewAccount") + ",";
				}
				if (value._IsSetUserStatusID)
				{
					strUpdate += "[UserStatusID]=" + CreateSqlParameterName("UserStatusID") + ",";
				}
				if (value._IsSetLastLoginDate)
				{
					strUpdate += "[LastLoginDate]=" + CreateSqlParameterName("LastLoginDate") + ",";
				}
				if (value._IsSetUserTypeID)
				{
					strUpdate += "[UserTypeID]=" + CreateSqlParameterName("UserTypeID") + ",";
				}
				if (value._IsSetUpdateBy)
				{
					strUpdate += "[UpdateBy]=" + CreateSqlParameterName("UpdateBy") + ",";
				}
				if (value._IsSetRenewTicketID)
				{
					strUpdate += "[RenewTicketID]=" + CreateSqlParameterName("RenewTicketID") + ",";
				}
				if (value._IsSetDeleteFlag)
				{
					strUpdate += "[DeleteFlag]=" + CreateSqlParameterName("DeleteFlag") + ",";
				}
				if (strUpdate != string.Empty)
				{
					strUpdate = strUpdate.Remove(strUpdate.Length - 1);
					strUpdate = "UPDATE [dbo].[User] SET " + strUpdate;
					strUpdate += " WHERE ";
					strUpdate += "[UserID]=" + CreateSqlParameterName("UserID");

					cmd = CreateCommand(strUpdate);
					AddParameter(cmd, "UserID", value.UserID);
					AddParameter(cmd, "UserName", Sanitizer.GetSafeHtmlFragment(value.UserName));
					AddParameter(cmd, "AliasName", Sanitizer.GetSafeHtmlFragment(value.AliasName));
					AddParameter(cmd, "Password", Sanitizer.GetSafeHtmlFragment(value.Password));
					AddParameter(cmd, "Title", Sanitizer.GetSafeHtmlFragment(value.Title));
					AddParameter(cmd, "FirstName", Sanitizer.GetSafeHtmlFragment(value.FirstName));
					AddParameter(cmd, "LastName", Sanitizer.GetSafeHtmlFragment(value.LastName));
					AddParameter(cmd, "CardID", Sanitizer.GetSafeHtmlFragment(value.CardID));
					AddParameter(cmd, "Gender", value.Gender);
					AddParameter(cmd, "PhoneNumber", Sanitizer.GetSafeHtmlFragment(value.PhoneNumber));
					AddParameter(cmd, "Email", Sanitizer.GetSafeHtmlFragment(value.Email));
					AddParameter(cmd, "DateOfBirth", value.IsDateOfBirthNull ? DBNull.Value : (object)value.DateOfBirth);
					AddParameter(cmd, "RegistDate", value.IsRegistDateNull ? DalBase.SqlNowIncludePd(_processID) : (object)value.RegistDate);
					AddParameter(cmd, "UpdateDate", value.IsUpdateDateNull ? DBNull.Value : (object)value.UpdateDate);
					AddParameter(cmd, "IsVerifyByEmail", value.IsVerifyByEmail);
					AddParameter(cmd, "IsRenewAccount", value.IsRenewAccount);
					AddParameter(cmd, "UserStatusID", value.UserStatusID);
					AddParameter(cmd, "LastLoginDate", value.IsLastLoginDateNull ? DBNull.Value : (object)value.LastLoginDate);
					AddParameter(cmd, "UserTypeID", Sanitizer.GetSafeHtmlFragment(value.UserTypeID));
					AddParameter(cmd, "UpdateBy", value.UpdateBy);
					AddParameter(cmd, "RenewTicketID", value.RenewTicketID);
					AddParameter(cmd, "DeleteFlag", value.IsDeleteFlagNull ? DBNull.Value : (object)value.DeleteFlag);
				}
				else
				{
					Exception ex = new Exception("Set at least 1 value");
					throw ex;
				}
			}
			else
			{
				Exception ex = new Exception("Set incorrect primarykey PK(UserID)");
				throw ex;
			}
			int rt = cmd.ExecuteNonQuery();
			return 0 != rt;
		}
		public bool DeleteByPrimaryKey(int userID)
		{
			string whereSql = "[UserID]=" + CreateSqlParameterName("UserID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "UserID", userID);
			return 0 < cmd.ExecuteNonQuery();
		}
		protected UserRow[] MapRecords(IDbCommand command)
		{
			using (IDataReader reader = ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}
		protected UserRow[] MapRecords(IDataReader reader)		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		protected UserRow[] MapRecords(IDataReader reader, int startIndex, int length, ref int totalRecordCount)		{
			if (0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if (0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");
			int userIDColumnIndex = reader.GetOrdinal("UserID");
			int userNameColumnIndex = reader.GetOrdinal("UserName");
			int aliasNameColumnIndex = reader.GetOrdinal("AliasName");
			int passwordColumnIndex = reader.GetOrdinal("Password");
			int titleColumnIndex = reader.GetOrdinal("Title");
			int firstNameColumnIndex = reader.GetOrdinal("FirstName");
			int lastNameColumnIndex = reader.GetOrdinal("LastName");
			int cardIDColumnIndex = reader.GetOrdinal("CardID");
			int genderColumnIndex = reader.GetOrdinal("Gender");
			int phoneNumberColumnIndex = reader.GetOrdinal("PhoneNumber");
			int emailColumnIndex = reader.GetOrdinal("Email");
			int dateOfBirthColumnIndex = reader.GetOrdinal("DateOfBirth");
			int registDateColumnIndex = reader.GetOrdinal("RegistDate");
			int updateDateColumnIndex = reader.GetOrdinal("UpdateDate");
			int isVerifyByEmailColumnIndex = reader.GetOrdinal("IsVerifyByEmail");
			int isRenewAccountColumnIndex = reader.GetOrdinal("IsRenewAccount");
			int userStatusIDColumnIndex = reader.GetOrdinal("UserStatusID");
			int lastloginDateColumnIndex = reader.GetOrdinal("LastLoginDate");
			int userTypeIDColumnIndex = reader.GetOrdinal("UserTypeID");
			int updateByColumnIndex = reader.GetOrdinal("UpdateBy");
			int renewTicketIDColumnIndex = reader.GetOrdinal("RenewTicketID");
			int deleteFlagColumnIndex = reader.GetOrdinal("DeleteFlag");
			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			int countRecordRow = 0;
			while (reader.Read())
			{
				countRecordRow++;
				ri++;
				if (ri > 0 && ri <= length)
				{
					UserRow record = new UserRow();
					recordList.Add(record);
					record.UserID =  Convert.ToInt32(reader.GetValue(userIDColumnIndex));
					record.UserName =  Convert.ToString(reader.GetValue(userNameColumnIndex));
					record.AliasName =  Convert.ToString(reader.GetValue(aliasNameColumnIndex));
					record.Password =  Convert.ToString(reader.GetValue(passwordColumnIndex));
					if (!reader.IsDBNull(titleColumnIndex)) record.Title =  Convert.ToString(reader.GetValue(titleColumnIndex));

					record.FirstName =  Convert.ToString(reader.GetValue(firstNameColumnIndex));
					record.LastName =  Convert.ToString(reader.GetValue(lastNameColumnIndex));
					if (!reader.IsDBNull(cardIDColumnIndex)) record.CardID =  Convert.ToString(reader.GetValue(cardIDColumnIndex));

					record.Gender =  Convert.ToInt32(reader.GetValue(genderColumnIndex));
					if (!reader.IsDBNull(phoneNumberColumnIndex)) record.PhoneNumber =  Convert.ToString(reader.GetValue(phoneNumberColumnIndex));

					if (!reader.IsDBNull(emailColumnIndex)) record.Email =  Convert.ToString(reader.GetValue(emailColumnIndex));

					if (!reader.IsDBNull(dateOfBirthColumnIndex)) record.DateOfBirth =  Convert.ToDateTime(reader.GetValue(dateOfBirthColumnIndex));

					record.RegistDate =  Convert.ToDateTime(reader.GetValue(registDateColumnIndex));
					if (!reader.IsDBNull(updateDateColumnIndex)) record.UpdateDate =  Convert.ToDateTime(reader.GetValue(updateDateColumnIndex));

					record.IsVerifyByEmail =  Convert.ToBoolean(reader.GetValue(isVerifyByEmailColumnIndex));
					record.IsRenewAccount =  Convert.ToBoolean(reader.GetValue(isRenewAccountColumnIndex));
					record.UserStatusID =  Convert.ToInt32(reader.GetValue(userStatusIDColumnIndex));
					if (!reader.IsDBNull(lastloginDateColumnIndex)) record.LastLoginDate =  Convert.ToDateTime(reader.GetValue(lastloginDateColumnIndex));

					record.UserTypeID =  Convert.ToString(reader.GetValue(userTypeIDColumnIndex));
					record.UpdateBy =  Convert.ToInt32(reader.GetValue(updateByColumnIndex));
					record.RenewTicketID =  Convert.ToInt32(reader.GetValue(renewTicketIDColumnIndex));
					if (!reader.IsDBNull(deleteFlagColumnIndex)) record.DeleteFlag =  Convert.ToBoolean(reader.GetValue(deleteFlagColumnIndex));

					if (ri == length && 0 != totalRecordCount)
						break;
				}
			}
			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (UserRow[])(recordList.ToArray(typeof(UserRow)));
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
				case "UserID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "UserName":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "AliasName":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "Password":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "Title":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "FirstName":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "LastName":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "CardID":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "Gender":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "PhoneNumber":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "Email":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "DateOfBirth":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "RegistDate":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "UpdateDate":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "IsVerifyByEmail":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "IsRenewAccount":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
					break;
				case "UserStatusID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "LastLoginDate":
					parameter = AddParameter(cmd, paramName, DbType.DateTime, value);
					break;
				case "UserTypeID":
					parameter = AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;
				case "UpdateBy":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "RenewTicketID":
					parameter = AddParameter(cmd, paramName, DbType.Int32, value);
					break;
				case "DeleteFlag":
					parameter = AddParameter(cmd, paramName, DbType.Boolean, value);
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

